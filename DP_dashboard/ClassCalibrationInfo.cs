﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TempController_dll;
using DpCommunication;
using multiplexing_dll;
using DeltaPlcCommunication;
using log4net;
using System.Reflection;
using System.IO;

namespace DP_dashboard
{

    public class ClassCalibrationSettings
    {
        #region variables
        public SwVersion Versions;


        public String UserName = "";
        public int StationId = 0;
        public string Batch;

        public List<float> PressureUnderTestList = new List<float>();
        public List<float> TempUnderTestList = new List<float>();
        public List<int> TempSkipStartTime = new List<int>();

        public string DeviceLicens = "1";

        public int JigConfiguration = 16;
        public List<bool> ConnectedChanels = new List<bool>();

        public string PlcComPortName = Properties.Settings.Default.plcComPort;
        public string MultiPlexerComPortName = Properties.Settings.Default.multiplexingComPort;
        public string DpComPortName = Properties.Settings.Default.dpComPort;
        public string TempControllerComPortName = Properties.Settings.Default.TempControllerComPort;

        public int TempSkipTime = 600;         // 10 min
        public int TempSampleInterval = 300;   // 5 min
        public float TempDeltaRange = 0.5f;    // 0.5
        public int MaxTimeWaitToTemp = 2700;     // 45 min
        public int TempSampleAmount = 3;

        public bool PressureAutoMode = true;
        public bool TechnicianApproveGoNext = false;
        public bool AlertToTechnican = false;
        #endregion

        #region c'tor    
        public ClassCalibrationSettings(SwVersion versions)
        {
            Versions = versions;
            StationId = Properties.Settings.Default.StationId;
        }
        #endregion
    }


    public class ClassCalibrationInfo
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region state machine states
        //state machine stats
        public byte CurrentState = StateStartCalib;
        public byte NextState = 0x00;
        public byte PreviousState = 0x00;


        private const byte StateStartCalib                              = 0x01;
        private const byte StateSendPressureSetPoints                   = 0x02;
        private const byte StateSendTempSetPoints                       = 0x03;
        private const byte StateWaitToSetPressureStable                 = 0x04;
        private const byte StateWaitToTechnicanApprovePressure          = 0x05;
        private const byte StateWaitToSetTempStable                     = 0x06;
        private const byte StateRunOfAllDp                              = 0x07;
        private const byte StateSaveValues                              = 0x08;
        private const byte StateSendValusToDP                           = 0x09;
        private const byte StateEndOneCalibPoint                        = 0x0a;
        private const byte StateEndOneCalibTemp                         = 0x0b;
        private const byte StateFinishAllCalibPoint                     = 0x0c;
        private const byte StatePressureStableError                     = 0x0d;
        private const byte StateTempStableError                         = 0x0e;
        #endregion

        #region parameters
        //timing parameters
        private const int MAX_TIME_WAIT_TO_PRESSURE_SET_POINT           = 2700;       //45 minutes'
        private const int MAX_TIME_WAIT_TO_TEMP_SET_POINT               = 1800;     // 30 min 1800
        private const int GET_DP_INFO_TIMOUT                            = 1;       // 1 sec
        private const int READ_PRESSURE_INTERVAL                        = 2;
        private const int TEMP_WAIT_BETWEEN_TWO_SMPLINGS_CYCLE          = 300; // 5 min
        private const int READ_OVE_TEMP_FREQ                            = 1;   // 1 sec
        //constant parameters
        private const byte MAX_DP_DEVICES                               = 0x10;      //16
        private const byte MAX_PRESSURE_CALIB_POINT                     = 0x0f;      // 15
        private const byte MAX_TEMP_CALIB_POINT                         = 0x05;      // 5
        private const byte TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS      = 15;
        private const byte TEMP_TARGET_SETPOINT_REGISTER_ADDRESSS       = 2;
        private const byte TEMP_SET_POINT_1_REGISTER_ADDRESSS           = 24;
        private const byte TEMP_SET_POINT_2_REGISTER_ADDRESSS           = 25;
        private const byte TEMP_PRESENT_VALUE_REGISTER_ADDRESSS         = 1;
        private const byte PRESSURE_STABLE_BIT_INDEX_FLAG               = 0;
        private const byte PRESSURE_VENT_BIT_INDEX_FLAG                 = 1;
        private const int PLC_FLAG_STATUS_REGISTER_ADDRESS              = 300;
        private const int PLC_PRESENT_VALUE_REGISTER_ADDRESS            = 301;
        private const int MAX_ALLOW_SEND_GET_INFO_CMD                   = 3;
        private const int MAX_SEND_TARGET_TEMP_TO_OVEN                  = 3;
        private const int TEMP_TEMP_TOLERANCE                           = 2;

        //Convert A2D to BAR constant
        private const int PLC_A2D_START_POINT                           = 6378;
        private const float PLC_A2D_A                                   = 0.07856f;
        private const float PLC_A2D_B                                   = 500f;
        #endregion


        #region variables
        public Thread CalibrationTaskHandlerThread;
        public Thread DetectDevicesTaskHandlerThread;
        public ClassDevice[] classDevices = new ClassDevice[MAX_DP_DEVICES];
        public int DpCountAxist = 0;
        public DateTime TimeFromSetPressurePointRequest;
        public DateTime TimeFromSetTempPointRequest;
        public DateTime TimeFromTempEndSkipTime;
        public ClassDevice CurrentCalibDevice = new ClassDevice();
        public byte CurrentCalibDeviceIndex = 0;
        public byte CurrentCalibTempIndex = 0;
        public byte CurrentCalibPressureIndex = 0;
        public bool DoCalibration = false;
        public bool FinishCalibrationEvent = false;
        public bool ChengeStateEvent = false;
        public float CurrentTempControllerValue;
        public float CurrentTempOnDP;
        public Int16 CurrentPLCPressure;
        public bool PressureStableFlag = false;
        public bool Pressure0AfterVentStable = false;
        public bool PressureVentleFlag = false;
        public bool IncermentCalibPointStep = false;
        public bool ConnectingToDP = false;
        public DateTime LastPressureSample = DateTime.Now;
        public DateTime LastOvenReadTime = DateTime.Now;
        private classLog log = new classLog();
        public bool DetectFlag = false;
        //public int JigConfiguration = 8;
        public bool EndDetectEvent = false;
        public bool CalibrationPaused = false;


        public string ErrorMessage = "";
        public string TraceInfo = "";
        public bool ErrorEvent = false;
        public bool CriticalStates = false;
        public bool TempTimoutErrorEvent = false;
        public bool NextAfterTempTimoutErrorEvent = false;
        public bool PressureTimoutErrorEvent = false;
        public bool NextAfterPressureTimoutErrorEvent = false;

        public TempControllerProtocol ClassTempControllerInstanse;
        public ClassDpCommunication classDpCommunicationInstanse;
        public classMultiplexing classMultiplexingInstanse;
        public string TempControllerRxData = "";
        public classDeltaProtocol classDeltaProtocolInstanse;

        public ClassCalibrationSettings classCalibrationSettings;
        public int OvenSendTargeTempCounter = 0;
        #endregion

        #region c'tor
        public ClassCalibrationInfo(TempControllerProtocol tempControllerInstanse, ClassDpCommunication ClassDpCommunication, classMultiplexing ClassMultiplexing, classDeltaProtocol classDeltaIncomingInformation, SwVersion version)
        {

            // DP TempController
            ClassTempControllerInstanse = tempControllerInstanse;

            // DP comunication
            classDpCommunicationInstanse = ClassDpCommunication;

            // Multiplexer comunication
            classMultiplexingInstanse = ClassMultiplexing;

            //delta protocol 
            classDeltaProtocolInstanse = classDeltaIncomingInformation;

            //update sw/fw versions
            classCalibrationSettings = new ClassCalibrationSettings(version);
        }
        #endregion

        public void UpdateRealTimeData(CalibForm form = null)
        {
            //cancel becouse is stuck the proccess
            if (CheckTimout(LastOvenReadTime, READ_OVE_TEMP_FREQ))
            {
                LastOvenReadTime = DateTime.Now;
                CurrentTempControllerValue = TempControllerReadTemp();
                if (CurrentTempControllerValue > (-100))
                {
                    if (form != null)
                        form.UpdateCurrentTemp(CurrentTempControllerValue.ToString());
                }
            }

            //CurrentTempControllerValue = 0;
            ReadPressureFromPlc();
        }

        #region main calibration task
        private void CalibrationTask()
        {
            while (DoCalibration)
            {
                while (!CalibrationPaused && DoCalibration)
                {
                    //UpdateRealTimeData();

                    switch (CurrentState)
                    {
                        case StateStartCalib:
                            {
                                CurrentCalibDevice = classDevices[CurrentCalibDeviceIndex];
                                StateChangeState(StateSendTempSetPoints);
                                CurrentCalibPressureIndex = 0;
                                CurrentCalibTempIndex = 0;

                                CriticalStates = true;
                            }
                            break;

                        case StateSendPressureSetPoints:
                            {
                                CriticalStates = true;

                                if (CurrentCalibPressureIndex > 0)
                                {
                                    List<short> SetPointPressure = new List<short>();
                                    SetPointPressure.Add(PlcBar2Adc(classCalibrationSettings.PressureUnderTestList[CurrentCalibPressureIndex]));
                                    classDeltaProtocolInstanse.classDeltaWriteSetpoint(SetPointPressure);

                                    TimeFromSetPressurePointRequest = DateTime.Now;

                                    StateChangeState(StateWaitToSetPressureStable);
                                    IncermentCalibPointStep = true;
                                }
                                else
                                {

                                    // no need set 0 bar becouse i still set  when i sent temp setpoint.
                                    TimeFromSetPressurePointRequest = DateTime.Now;

                                    StateChangeState(StateWaitToSetPressureStable);
                                    IncermentCalibPointStep = true;
                                }
                            }
                            break;

                        case StateSendTempSetPoints:
                            {
                                // send 0[bar] to PLC comtroller
                                VentToRead0Bar(); // vent system after finish calib.

                                WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS, classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex]);
                                SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 0);
                                OvenSendTargeTempCounter++;

                                Thread.Sleep(1000);
                                
                                if (ValidOvenTargetSp(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex]))
                                {
                                    TimeFromSetTempPointRequest = DateTime.Now;

                                    CriticalStates = false;

                                    ////TIME TO TEMP STABLE ERROR = CURRENT SKIP TIME + ERROR TIMEOUT
                                    //classCalibrationSettings.TempToTimoutError +=  

                                    OvenSendTargeTempCounter = 0;
                                    StateChangeState(StateWaitToSetTempStable);
                                }
                                else if(OvenSendTargeTempCounter >= MAX_SEND_TARGET_TEMP_TO_OVEN)
                                {
                                    StateChangeState(StateTempStableError);
                                }
                            }
                            break;

                        case StateWaitToSetPressureStable:
                            {
                                if (CheckTimout(TimeFromSetPressurePointRequest, MAX_TIME_WAIT_TO_PRESSURE_SET_POINT))
                                {
                                    PressureTimoutErrorEvent = true;

                                    ResetPressureAndTemp();

                                    StateChangeState(StatePressureStableError);
                                }

                                else
                                if (PressureStableFlag)
                                {
                                    if (classCalibrationSettings.PressureAutoMode)
                                    {
                                        StateChangeState(StateRunOfAllDp);
                                    }

                                    else
                                    {
                                        classCalibrationSettings.AlertToTechnican = true;
                                        StateChangeState(StateWaitToTechnicanApprovePressure);
                                    }
                                }

                                else if (CurrentCalibPressureIndex == 0)
                                {
                                    Pressure0AfterVentStable = false;
                                    StateChangeState(StateRunOfAllDp);
                                }
                            }
                            break;
                            

                        case StateWaitToTechnicanApprovePressure:
                            {
                                if (classCalibrationSettings.TechnicianApproveGoNext)
                                {
                                    classCalibrationSettings.TechnicianApproveGoNext = false;
                                    StateChangeState(StateRunOfAllDp);
                                }
                            }
                            break;

                        case StateWaitToSetTempStable:
                            {

                                // timout error -> current skip time  + max time wait to temp
                                if (CheckTimout(TimeFromSetTempPointRequest, classCalibrationSettings.MaxTimeWaitToTemp + classCalibrationSettings.TempSkipStartTime[CurrentCalibTempIndex]))
                                {
                                    StateChangeState(StateTempStableError);

                                    ResetPressureAndTemp();

                                    TempTimoutErrorEvent = true;
                                }
                                else
                                    //if (CheckTimout(TimeFromSetTempPointRequest, 1))//debug mode
                                if (CheckTimout(TimeFromSetTempPointRequest, classCalibrationSettings.TempSkipStartTime[CurrentCalibTempIndex]))
                                {
                                    if (CheckTempStableOnOneDp(classCalibrationSettings.TempDeltaRange))
                                    {
                                        StateChangeState(StateSendPressureSetPoints);
                                    }
                                    else
                                    {
                                        Thread.Sleep(TEMP_WAIT_BETWEEN_TWO_SMPLINGS_CYCLE * 1000);
                                    }                                   
                                }

                                //StateChangeState(StateSendPressureSetPoints);

                            }
                            break;

                        case StateTempStableError:
                            {
                                if (NextAfterTempTimoutErrorEvent)
                                {                                 
                                    StateChangeState(StateSendTempSetPoints);
                                    NextAfterTempTimoutErrorEvent = false;
                                }
                                TraceInfo += "Fail to set temperature.\r\n" + "Close calibration proccess.\r\n";
                                DoCalibration = false;
                                StateMachineReset();
                            }
                            break;
                            
                        case StateRunOfAllDp:
                            {
                                ConnectingToDP = true;
                                WriteReadInfoFromDp();//loop of all dp's
                                ConnectingToDP = false;

                                StateChangeState(StateEndOneCalibPoint);
                            }
                            break;
                        case StateEndOneCalibTemp:
                            {
                                CurrentCalibPressureIndex = 0;

                                WriteOneTempertureToFile();//write line to csv file

                                if (Properties.Settings.Default.WriteToDB)
                                {
                                    SaveOneTempertureOnDB();//write line to data base
                                }
                                if (CurrentCalibTempIndex < classCalibrationSettings.TempUnderTestList.Count - 1)
                                {
                                    CurrentCalibTempIndex++;
                                    StateChangeState(StateSendTempSetPoints);
                                }
                                else
                                {
                                    StateChangeState(StateFinishAllCalibPoint);
                                }
                            }
                            break;
                        case StateEndOneCalibPoint:
                            {
                                PressureStableFlag = false;
                                if (CurrentCalibPressureIndex < classCalibrationSettings.PressureUnderTestList.Count - 1)
                                {
                                    CurrentCalibPressureIndex++;
                                    StateChangeState(StateSendPressureSetPoints);
                                }
                                else
                                {
                                    StateChangeState(StateEndOneCalibTemp);
                                }
                            }
                            break;
                        case StateFinishAllCalibPoint:
                            {
                                SetLicense();
                                DoCalibration = false;
                                FinishCalibrationEvent = true;
                                
                                ResetPressureAndTemp();

                                StateChangeState(StateStartCalib);
                            }
                            break;
                        case StatePressureStableError:
                            {
                                if (NextAfterPressureTimoutErrorEvent)
                                {
                                    StateChangeState(StateSendPressureSetPoints);
                                    NextAfterPressureTimoutErrorEvent = false;
                                }
                            }
                            break;
                    }

                }
                CalibrationTaskHandlerThread = null;
            }
            CriticalStates = false;
        }
        #endregion



        /// ResetPressureAndTemp()
        /// return the pressure and oven temperature to idle
        /// pressure -> 0[bar]
        /// temperture - 18[c]> 
        /// </summary>
        private void ResetPressureAndTemp()
        {
            // send 0[bar] to PLC comtroller
            VentToRead0Bar(); // vent system after finish calib.

            // send 18[c] to temp comtroller
            WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS, 18);
            SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 0);
        }

        /// <summary>
        /// StateChangeState(byte nextState)
        /// discription: this function change state machine state
        /// <param name="nextState"></param>
        /// </summary>
        public void StateChangeState(byte nextState)
        {
            PreviousState = CurrentState;
            CurrentState = nextState;
            ChengeStateEvent = true;

            Logger.Debug("Calibration state machine: from 111 to 222");
        }

        /// <summary>
        /// discription: ResetStateMachine() return back the calibration state to start state
        /// </summary>
        public void ResetStateMachine()
        {
            PreviousState = StateStartCalib;
            CurrentState = StateStartCalib;

            CurrentCalibPressureIndex = 0;
            CurrentCalibTempIndex = 0;
            ChengeStateEvent = true;
        }

        public void StateMachineReset()
        {
            PreviousState = StateStartCalib;
            CurrentState = StateStartCalib;
            ChengeStateEvent = false;
        }

        /// <summary>
        /// discription: StateMachineResetAfterPause function rerun the calibration process afteruser was stoped
        /// param: byte tempIndex
        /// </summary>
        public void StateMachineResetAfterPause(byte tempIndex)
        {
            CurrentState = StateSendTempSetPoints;
            ChengeStateEvent = false;
            CurrentCalibTempIndex = tempIndex;
            CurrentCalibPressureIndex = 0;
        }

        /// <summary>
        /// discription: ReadPressureFromPlc read and return the pressure from the PLC
        /// param: none
        /// return: float current pressure
        /// </summary>
        public float ReadPressureFromPlc()
        {

            if (CheckTimout(LastPressureSample, READ_PRESSURE_INTERVAL))
            {

                DeltaReturnedData pressure = new DeltaReturnedData();
                DeltaReturnedData flags = new DeltaReturnedData();
                lock (this)
                {
                    try
                    {
                        LastPressureSample = DateTime.Now;

                        flags = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_FLAG_STATUS_REGISTER_ADDRESS, 1);
                        if (flags.IntValue != null)
                        {
                            PressureStableFlag = IsBitSet(Convert.ToByte((byte)flags.IntValue[0]), PRESSURE_STABLE_BIT_INDEX_FLAG);
                            //PressureStableFlag = true;
                        }

                        Thread.Sleep(100);

                        pressure = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_PRESENT_VALUE_REGISTER_ADDRESS, 1);
                        if (pressure.IntValue != null)
                        {
                            CurrentPLCPressure = (Int16)pressure.IntValue[0];
                        }
                        //CurrentPLCPressure = 23;
                    }

                    catch (Exception ex)
                    {
                        ErrorMessage = "PLC ERROR-" + ex.ToString();
                        ErrorEvent = true;

                    }
                }
            }
            return CurrentPLCPressure;

        }

        /// <summary>
        /// discription: TempControllerReadTemp read and return the temperature from the oven
        /// param: none
        /// return: uint16 current temp
        /// </summary>
        public float TempControllerReadTemp()
        {
            //Create array to accept read values:
            short[] values = new short[Convert.ToInt32(1)];
            ushort pollStart;
            ushort pollLength;

            pollStart = TEMP_PRESENT_VALUE_REGISTER_ADDRESSS;
            pollStart = Convert.ToUInt16(1);
            pollLength = Convert.ToUInt16(1);

            //Read registers and display data in desired format:
            bool commstatus = false;
            try
            {
                commstatus = ClassTempControllerInstanse.SendFc3(Convert.ToByte(Properties.Settings.Default.TempControllerSlaveAddress), pollStart, pollLength, ref values);            
            }
            catch (Exception err)
            {
                ClassTempControllerInstanse.ComPortOk = false;
                ClassTempControllerInstanse.ComPortErrorMessage = string.Format("Error: {0} connection error. function - Temp controller.", ClassTempControllerInstanse.sp.PortName);
            }
            
            float value = float.Parse(values[0].ToString()) / 10;
            if (!commstatus)
                return (-200);

            return value;
        }

        private float GetPressureFromPlc()
        {
            return 0.5f;
        }



        /// <summary>
        /// discription: WriteReadInfoFromDp write calib point and read a2d values from all connected DP's
        /// param: none
        /// return: none
        /// </summary>  
        /// 
        private void WriteReadInfoFromDp()
        {
            int DpPtr = 0;

            for (byte i = 0; i < classCalibrationSettings.JigConfiguration; i++)
            {
                if (classCalibrationSettings.ConnectedChanels[i] == true)
                {
                    for (int j = 0; j < MAX_ALLOW_SEND_GET_INFO_CMD; j++)
                    {
                        classMultiplexingInstanse.ConnectDpDevice(i);

                        //read current pressure from plc...
                        ReadPressureFromPlc();

                        classDpCommunicationInstanse.NewDpInfoEvent = false;
                        classDpCommunicationInstanse.DpWritePressurePointToDevice(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex], CurrentCalibTempIndex, PlcAdc2Bar(CurrentPLCPressure), CurrentCalibPressureIndex);

                        //Thread.Sleep(1000);
                        
                        if (classDpCommunicationInstanse.WaitForResponse(2000)) // check if recieve data from DP
                        {
                            //save the data on the current device and current calibpoint..
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue1 = classDpCommunicationInstanse.dpInfo.S1Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue2 = classDpCommunicationInstanse.dpInfo.S2Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempOnDevice = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].LeftA2DValue = classDpCommunicationInstanse.dpInfo.LeftA2D;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].RightA2DValue = classDpCommunicationInstanse.dpInfo.RightA2D;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].time = DateTime.Now;
                            classDevices[DpPtr].DeviceSerialNumber = classDpCommunicationInstanse.dpInfo.DeviseSerialNumber;
                            classDevices[DpPtr].DeviceMacAddress = classDpCommunicationInstanse.dpInfo.DeviceMacAddress;

                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].extA2dPressureValue = PlcAdc2Bar(CurrentPLCPressure);

                            classDpCommunicationInstanse.NewDpInfoEvent = false;
                            
                            j = MAX_ALLOW_SEND_GET_INFO_CMD; // break the for loop...
                        }
                        else
                        {
                            if (j == MAX_ALLOW_SEND_GET_INFO_CMD)
                            {
                                classDevices[DpPtr].deviceStatus = DeviceStatus.Fail;
                            }
                        }
                    }
                    DpPtr++;
                }
            }
        }

        public void SetLicense()
        {
            WriteToFile("Start Licensing");
            int DpPtr = 0;
            for (byte i = 0; i < classCalibrationSettings.JigConfiguration; i++)
            {
                if (classCalibrationSettings.ConnectedChanels[i] == true)
                {
                    classDpCommunicationInstanse.LicenseAck = false;

                    WriteToFile("Connecting to channel" + i + ", DpPtr=" + DpPtr);
                    classMultiplexingInstanse.ConnectDpDevice(i);
                    //set license on the device
                    
                    //MAC + Capabilities
                    WriteToFile("\tRequest License [" + DpPtr + "]");
                    byte[] license = new LicenceSupport().GetKey(classCalibrationSettings.DeviceLicens, classDevices[DpPtr].DeviceMacAddress);

                    if (license != null)
                        if (license.Length > 0)
                        {
                            classDpCommunicationInstanse.SendDpLicense(license);
                            WriteToFile("\tMAC = " + classDevices[DpPtr].DeviceMacAddress + "[" + DpPtr + "]");
                        }

                    if (classDpCommunicationInstanse.LicenseAck)
                    {
                        classDpCommunicationInstanse.LicenseAck = false;
                        TraceInfo += "License Accepted: Barecode = " + classDevices[DpPtr].DeviceBarcode + ", Chanel = " + i + ".\r\n";
                        WriteToFile("\tLicense Acepted [" + DpPtr + "]");
                    }
                    else
                    {
                        //Not license response
                        TraceInfo += ">>>>>>License Error: Barecode = " + classDevices[DpPtr].DeviceBarcode + ", Chanel = " + i + "<<<<<<<<.\r\n";
                        classDevices[DpPtr].deviceStatus = DeviceStatus.Fail;
                        WriteToFile("\tLicense Error [" + DpPtr + "]");
                    }

                    //send end calibration CMD
                    WriteToFile("\tClose calibration [" + DpPtr + "]");

                    classDpCommunicationInstanse.SendEndCalibration();
                    if (classDevices[DpPtr].deviceStatus == DeviceStatus.Wait)
                    {
                        classDevices[DpPtr].deviceStatus = DeviceStatus.Pass;
                    }
                    DpPtr++;
                }
            }
            WriteToFile("End Licensing");
        }

        private void WriteToFile(string msg)
        {
            /*
            using (StreamWriter sw = File.AppendText("liclog.txt"))
            {
                sw.WriteLine(msg);
            }
            */
        }

        private bool CheckTimout(DateTime startTime, int timeout)
        {
            if (DateTime.Now.Subtract(startTime).TotalSeconds > timeout)
            {
                return true;
            }
            return false;
        }

        private void WritePressureSetPoint(float targetPressure)
        {

        }

        bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        public void WriteOneTempertureToFile()
        {
            for (int i = 0; i < DpCountAxist; i++)
            {
                TraceInfo += "\r\n" + log.PrintLogRecordToFile(classDevices[i], classCalibrationSettings.PressureUnderTestList, Properties.Settings.Default.LogPath, CurrentCalibTempIndex);
            }
        }



        /// <summary>
        /// discription: ValidOvenTargetSp write temp setpoint to the oven
        /// param: float target setpoint
        /// return: bool if valid ok
        /// </summary> 
        /// 
        public bool ValidOvenTargetSp(float target)
        {
            target = target * 10;
            short[] values = new short[1];
            float value = 0.0f;

            try
            {
                SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 0);
                Thread.Sleep(200);
                if (ClassTempControllerInstanse.SendFc3(Convert.ToByte(Properties.Settings.Default.TempControllerSlaveAddress), TEMP_TARGET_SETPOINT_REGISTER_ADDRESSS, 1, ref values))
                {
                    value = float.Parse(values[0].ToString());
                    if (value == target)
                    {
                        return true;
                    }
                    else
                        return false;

                }
                else
                { 
                    TraceInfo += "Error: Fail to valid temperatue set point on oven\r\n" + "Current Target temperature on oven is " + value.ToString() + ":\r\n";
                    return false;
                }
                
            }
            catch (Exception err)
            {
                TraceInfo += "Error: Fail to valid temperatue set point\r\n" + "Current Target temperature on oven is " + value.ToString() + ":\r\n" + err.ToString();
                return false;
            }


            return true;
        }

        /// <summary>
        /// discription: WriteTempSetPoint write temp setpoint to the oven
        /// param: Byte registerAddress
        /// param: float tempValue
        /// return: none
        /// </summary>  
        private void WriteTempSetPoint(Byte registerAddress, float tempValue)
        {
            tempValue = tempValue * 10;
            short[] value = new short[1];
            value[0] = Convert.ToInt16(tempValue);

            try
            {
                ClassTempControllerInstanse.SendFc16(Properties.Settings.Default.TempControllerSlaveAddress, registerAddress, (ushort)1, value);
            }
            catch (Exception err)
            {
                string error = err.ToString();
            }
        }

        /// <summary>
        /// discription: SelectSetPoint select the active setpoint on the oven
        /// param: Byte registerAddress
        /// param: float SPn - setpoint number(0/1)
        /// return: none
        /// </summary> 
        private void SelectSetPoint(Byte registerAddress, float SPn)
        {
            SPn = SPn * 10;
            short[] value = new short[1];
            value[0] = Convert.ToInt16(SPn);

            try
            {
                ClassTempControllerInstanse.SendFc16(Properties.Settings.Default.TempControllerSlaveAddress, registerAddress, (ushort)1, value) ;
            }
            catch (Exception err)
            {
                string error = err.ToString();
            }
        }

        public void CreateLogFiles()
        {
            for (int i = 0; i < DpCountAxist; i++)
            {

                log.OpenFileForLogging(classCalibrationSettings.PressureUnderTestList, Properties.Settings.Default.LogPath, classDevices[i]);
                log.CloseFileForLogging();
            }

        }

        /// <summary>
        /// discription: PlcAdc2Bar convert a2d to pressure
        /// param: Int16 a2d
        /// return: float bar
        /// </summary> 
        float PlcAdc2Bar(Int16 a2d)
        {
            float bar = 0;
            bar = (float)((a2d * PLC_A2D_A) - PLC_A2D_B) / 100;
            return bar;
        }

        /// <summary>
        /// discription: PlcBar2Adc convert pressure to a2d
        /// param: float barValue
        /// return: Int16 a2d
        /// </summary> 
        public Int16 PlcBar2Adc(float barValue)
        {
            Int16 A2DValue = 0;
            A2DValue = (Int16)((100 * barValue + PLC_A2D_B) / PLC_A2D_A);
            return A2DValue;
        }

        /// <summary>
        /// discription: DetectDevicesTask scan witch chanels in the multiplexer is connected to dp
        /// param: none
        /// return: none
        /// </summary> 
        void DetectDevicesTask()
        {
            while (DetectFlag)
            {
                classDevices = null;
                classDevices = new ClassDevice[MAX_DP_DEVICES];
                DpCountAxist = 0;
                classCalibrationSettings.ConnectedChanels.Clear();
                bool connection_ok = false;

                for (int i = 0; i < classCalibrationSettings.JigConfiguration; i++)
                {
                    connection_ok = false;
                    for (int j = 0; j < MAX_ALLOW_SEND_GET_INFO_CMD; j++)
                    {
                        
                        classMultiplexingInstanse.ConnectDpDevice((byte)i);

                        classDpCommunicationInstanse.NewDpInfoEvent = false;
                        classDpCommunicationInstanse.DPgetDpInfo();

                        // check if recieve data from DP
                        if (classDpCommunicationInstanse.WaitForResponse(1000)) 
                        {
                            classDpCommunicationInstanse.NewDpInfoEvent = false;


                            if (classDpCommunicationInstanse.dpInfo.DeviceBarcode == "" || classDpCommunicationInstanse.dpInfo.DeviceBarcode.StartsWith("\0"))
                            {
                                classCalibrationSettings.ConnectedChanels.Add(false);

                                //TraceInfo += string.Format("Scan devices error: board position = {0}. DP serial number = {1}. not can start calibration proccess\r\n Serial namber must have minimum 8 digits.\r\n",i, classDpCommunicationInstanse.dpInfo.DeviceSerialNumber);

                                continue;
                            }

                            ClassDevice newDeviceExist = new ClassDevice();

                            newDeviceExist.PositionOnBoard = i;
                            newDeviceExist.BoardNumber = (i >= 0 && i < 8) ? 1 : 2;

                            newDeviceExist.DeviceSerialNumber = classDpCommunicationInstanse.dpInfo.DeviseSerialNumber;
                            newDeviceExist.DeviceMacAddress = classDpCommunicationInstanse.dpInfo.DeviceMacAddress;
                            newDeviceExist.DeviceBarcode= classDpCommunicationInstanse.dpInfo.DeviceBarcode;

                            classDevices[DpCountAxist] = newDeviceExist;

                            UpdatePressAndTempOnDPBeforCalib(newDeviceExist);

                            DpCountAxist++;
                            connection_ok = true;
                            break;
                        }
                    }
                    classCalibrationSettings.ConnectedChanels.Add(connection_ok);
                    if (connection_ok == false)
                        Logger.Error("Scan devices process: DP in chanel " +   i + "nor responce.");
                }

                DetectFlag = false;
                EndDetectEvent = true;
            }
            DetectDevicesTaskHandlerThread = null;
        }

        /// <summary>
        /// discription: UpdatePressAndTempOnDPBeforCalib build temp,pressure calib point for all devices according the calibration setup
        /// param: ClassDevice deviceToUpdate
        /// return: none
        /// </summary>
        void UpdatePressAndTempOnDPBeforCalib(ClassDevice deviceToUpdate)
        {
            for (int i = 0; i < classCalibrationSettings.TempUnderTestList.Count; i++)
            {
                for (int j = 0; j < classCalibrationSettings.PressureUnderTestList.Count; j++)
                {
                    DpCalibPointData newPoint = new DpCalibPointData();
                    //newPoint.pressureUnderTest = PressureUnderTestList[j];
                    //newPoint.tempUnderTest = TempUnderTestList[i];

                    deviceToUpdate.CalibrationData[i, j] = newPoint;
                }
            }
        }

        /// <summary>
        /// discription: InitCalibTread build init the thread of the calib task
        /// param: none
        /// return: none
        /// </summary>
        public void InitCalibTread()
        {
            CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            CalibrationTaskHandlerThread.IsBackground = false;
            CalibrationTaskHandlerThread.Start();
        }

        /// <summary>
        /// discription: InitDetectTread build init the thread of the scen devices task
        /// param: none
        /// return: none
        /// </summary>
        public void InitDetectTread()
        {
            DetectDevicesTaskHandlerThread = new Thread(DetectDevicesTask);
            DetectDevicesTaskHandlerThread.IsBackground = false;
            DetectDevicesTaskHandlerThread.Start();
        }


        /// <summary>
        /// discription: CheckTempStableOnOneDp check if the dp's temperature is stable
        /// param: float Tollerance
        /// return: none
        /// </summary>
        private bool CheckTempStableOnOneDp(float Tollerance)
        {
            List<float> DpTempSamples = new List<float>();

            classMultiplexingInstanse.ConnectDpDevice((byte)classDevices[0].PositionOnBoard);

            for (int i = 0; i < classCalibrationSettings.TempSampleAmount; i++)
            {

                UpdateRealTimeData();

                classDpCommunicationInstanse.NewDpInfoEvent = false;
                classDpCommunicationInstanse.DPgetDpInfo();

                if (classDpCommunicationInstanse.WaitForResponse(500))
                {
                    classDpCommunicationInstanse.NewDpInfoEvent = false;
                    CurrentTempOnDP = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                    DpTempSamples.Add(CurrentTempOnDP);
                }
                Thread.Sleep(classCalibrationSettings.TempSampleInterval * 1000);
            }

            if (DpTempSamples.Count > 2)
            {
                if (Math.Abs(DpTempSamples[DpTempSamples.Count - 1] - DpTempSamples[0]) < classCalibrationSettings.TempDeltaRange &&
                    Math.Abs(DpTempSamples.Average() - DpTempSamples[DpTempSamples.Count - 1]) < classCalibrationSettings.TempDeltaRange)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        /// <summary>
        /// discription: VentToRead0Bar send vent system command to PLC
        /// param: none
        /// return: none
        /// </summary>
        private Int16 VentToRead0Bar()
        {
#if false
            List<short> l = new List<short>();
            DeltaReturnedData DataFromPLC = new DeltaReturnedData();

            l.Clear();
            l.Add(0); // a2d value   = 0
            classDeltaProtocolInstanse.classDeltaWriteSetpoint(l);
            Thread.Sleep(1000);

            try
            {
                DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_FLAG_STATUS_REGISTER_ADDRESS, 1);
                PressureVentleFlag = IsBitSet(Convert.ToByte(DataFromPLC.IntValue[0]), PRESSURE_VENT_BIT_INDEX_FLAG);


                if (PressureVentleFlag)
                {
                    Thread.Sleep(2000);

                    Pressure0AfterVentStable = true;

                    DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_PRESENT_VALUE_REGISTER_ADDRESS, 1);
                    CurrentPLCPressure = (Int16)DataFromPLC.IntValue[0];
                }
            }
            catch(Exception ex)
            {

            }
#else

            List<short> l = new List<short>();
            l.Clear();
            l.Add(0); // a2d value   = 0
            classDeltaProtocolInstanse.classDeltaWriteSetpoint(l);

            Thread.Sleep(1000);
#endif
            return CurrentPLCPressure;            
        }

        /// <summary>
        /// discription: SaveOneTempertureOnDB add calib data of the current temperature
        /// param: none
        /// return: none
        /// </summary>
        public void SaveOneTempertureOnDB()
        {
            List<RIT_QA.CalibrationData> tempTable = new List<RIT_QA.CalibrationData>();

            try
            {
                for (int unitCounter = 0; unitCounter < DpCountAxist; unitCounter++)
                {
                    for (int pressureCounter = 0; pressureCounter < classCalibrationSettings.PressureUnderTestList.Count; pressureCounter++)
                    {
                        RIT_QA.CalibrationData oneRowOfDevice = new RIT_QA.CalibrationData();

                        oneRowOfDevice.CalibrationToolVer = classCalibrationSettings.Versions.CalibrationTool;
                        oneRowOfDevice.DpFwVer = classCalibrationSettings.Versions.DpFw;
                        oneRowOfDevice.MultiPlexerFwVer = classCalibrationSettings.Versions.MultiPlexerFw;
                        oneRowOfDevice.BatchID = classCalibrationSettings.Batch;
                        oneRowOfDevice.Barcode = classDevices[unitCounter].DeviceBarcode;
                        oneRowOfDevice.MAC_ADDRESS = classDevices[unitCounter].DeviceMacAddress;
                        oneRowOfDevice.StationID = classCalibrationSettings.StationId;
                        oneRowOfDevice.UserID = RIT_QA.ClassDal.GetFirstUserID();
                        oneRowOfDevice.PressureSP = classCalibrationSettings.PressureUnderTestList[pressureCounter];
                        oneRowOfDevice.PressurePLC = classDevices[unitCounter].CalibrationData[CurrentCalibTempIndex, pressureCounter].extA2dPressureValue;
                        oneRowOfDevice.TempSP = classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex];
                        oneRowOfDevice.TempDP = classDevices[unitCounter].CalibrationData[CurrentCalibTempIndex, pressureCounter].tempOnDevice;
                        oneRowOfDevice.RightA2D = (int)classDevices[unitCounter].CalibrationData[CurrentCalibTempIndex, pressureCounter].RightA2DValue;
                        oneRowOfDevice.LeftA2D = (int)classDevices[unitCounter].CalibrationData[CurrentCalibTempIndex, pressureCounter].LeftA2DValue;
                        oneRowOfDevice.Datetime = classDevices[unitCounter].CalibrationData[CurrentCalibTempIndex, pressureCounter].time;
                        tempTable.Add(oneRowOfDevice);
                    }
                }

                RIT_QA.ClassDal.AddOneTempertureTable(tempTable, classDevices);
            }
            catch (Exception ex)
            {
                TraceInfo += "Faile to add table to database.\r\n   " + ex.StackTrace.ToString() + "\r\n\r\n" + ex.InnerException.ToString() + ".\r\n\r\n";
                Logger.Error("Faile to add table to database.   " + ex.StackTrace.ToString() +"       "+  ex.InnerException.ToString());
            }

        }
    }
}



