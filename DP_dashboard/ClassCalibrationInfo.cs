using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TempController_dll;
using DpCommunication;
using multiplexing_dll;
using DeltaPlcCommunication;





namespace DP_dashboard
{

    public class ClassCalibrationSettings
    {
        public List<float> PressureUnderTestList = new List<float>();
        public List<float> TempUnderTestList = new List<float>();
        public int JigConfiguration = 16;
        public List<bool> ConnectedChanels = new List<bool>();

        public string PlcComPortName = Properties.Settings.Default.plcComPort;
        public string MultiPlexerComPortName = Properties.Settings.Default.multiplexingComPort;
        public string DpComPortName = Properties.Settings.Default.dpComPort;
        public string TempControllerComPortName = Properties.Settings.Default.TempControllerComPort;

        public int TempSkipTime = 600;         // 10 min
        public int TempSampleInterval = 300;   // 5 min
        public float TempDeltaRange = 0.5f;    // 0.5
        public int TempMaxWaitTime = 2700;     // 45 min
        public int TempSampleAmount = 3;

        public bool PressureAutoMode = true;
        public bool TechnicianApproveGoNext = false;
        public bool AlertToTechnican = false;
    }


    public class ClassCalibrationInfo
    {

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


        //timing parameters
        private const int MAX_TIME_WAIT_TO_PRESSURE_SET_POINT          = 2700;       //30 sec'
        private const int MAX_TIME_WAIT_TO_TEMP_SET_POINT               = 1800;     // 30 min 1800
        private const int GET_DP_INFO_TIMOUT                            = 1;       // 1 sec
        private const int READ_PRESSURE_INTERVAL                        = 1;
        private const int TEMP_WAIT_BETWEEN_TOW_SMPLINGS                = 300; // 5 min

        //constant parameters
        private const byte MAX_DP_DEVICES                               = 0x10;      //16
        private const byte MAX_PRESSURE_CALIB_POINT                     = 0x0f;      // 15
        private const byte MAX_TEMP_CALIB_POINT                         = 0x05;      // 5
        private const byte TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS      = 15;
        private const byte TEMP_SET_POINT_1_REGISTER_ADDRESSS           = 24;
        private const byte TEMP_SET_POINT_2_REGISTER_ADDRESSS           = 25;
        private const byte TEMP_PRESENT_VALUE_REGISTER_ADDRESSS         = 1;
        private const byte PRESSURE_STABLE_BIT_INDEX_FLAG               = 0;
        private const byte PRESSURE_VENT_BIT_INDEX_FLAG                 = 1;
        private const int PLC_FLAG_STATUS_REGISTER_ADDRESS              = 300;
        private const int PLC_PRESENT_VALUE_REGISTER_ADDRESS            = 301;
        private const int MAX_ALLOW_SEND_GET_INFO_CMD                   = 3;
        private const int TEMP_TEMP_TOLERANCE                           = 2;

        //Convert A2D to BAR constant
        private const int PLC_A2D_START_POINT                           = 6378;
        private const float PLC_A2D_A                                   = 0.07856f;
        private const float PLC_A2D_B                                   = 500f;




        public Thread CalibrationTaskHandlerThread;
        public Thread DetectDevicesTaskHandlerThread;
        public ClassDevice[] classDevices = new ClassDevice[MAX_DP_DEVICES];
        public int DpCountAxist = 0;
        public DateTime TimeFromSetPressurePointRequest;
        public DateTime TimeFromSetTempPointRequest;
        public ClassDevice CurrentCalibDevice = new ClassDevice();
        public byte CurrentCalibDeviceIndex = 0;
        public byte CurrentCalibTempIndex = 0;
        public byte CurrentCalibPressureIndex = 0;
        public bool DoCalibration = false;
        public bool FinishCalibrationEvent = false;
        public bool ChengeStateEvent = false;
        public float CurrentTempControllerValue;
        public float CurrentTempOnDP;
        public Int16 CurrentPressure;
        public bool PressureStableFlag = false;
        public bool Pressure0AfterVentStable = false;
        public bool PressureVentleFlag = false;
        public bool IncermentCalibPointStep = false;
        public bool ConnectingToDP = false;
        public DateTime LastPressureSample = DateTime.Now;
        private classLog log = new classLog();
        public bool DetectFlag = false;
        //public int JigConfiguration = 8;
        public bool EndDetectEvent = false;
        public bool CalibrationPaused = false;
        //public List<float> PressureUnderTestList = new List<float>();
        //public List<float> TempUnderTestList = new List<float>();
        public ClassCalibrationSettings classCalibrationSettings = new ClassCalibrationSettings();
        public string ErrorMessage = "";
        public bool ErrorEvent = false;
        public bool CriticalStates = false;
        public bool TempTimoutErrorEvent = false;
        public bool NextAfterTempTimoutErrorEvent = false;
        public bool PressureTimoutErrorEvent = false;
        public bool NextAfterPressureTimoutErrorEvent = false;

        DateTime GetDpInforequestTime;
        //public TempControllerProtocol TempControllerInstanse = new TempControllerProtocol();

        public TempControllerProtocol ClassTempControllerInstanse;
        public ClassDpCommunication classDpCommunicationInstanse;
        public classMultiplexing classMultiplexingInstanse;
        public string TempControllerRxData = "";
        public classDeltaProtocol classDeltaProtocolInstanse;






        public ClassCalibrationInfo(TempControllerProtocol tempControllerInstanse, ClassDpCommunication ClassDpCommunication, classMultiplexing ClassMultiplexing, classDeltaProtocol classDeltaIncomingInformation)
        {

            // DP TempController
            ClassTempControllerInstanse = tempControllerInstanse;

            // DP comunication
            classDpCommunicationInstanse = ClassDpCommunication;

            // Multiplexer comunication
            classMultiplexingInstanse = ClassMultiplexing;

            //delta protocol 
            classDeltaProtocolInstanse = classDeltaIncomingInformation;

        }

        //methods
        private void startCalibration()
        {

        }
        private void stopCalibration()
        {

        }

        private void UpdateRealTimeData()
        {
            CurrentTempControllerValue = TempControllerReadTemp();

            ReadPressureFromPlc();
        }
        private void CalibrationTask()
        {
            while (DoCalibration)
            {
                while (!CalibrationPaused && DoCalibration)
                {
                    UpdateRealTimeData();

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
                                    List<Int16> SetPointPressure = new List<short>();
                                    SetPointPressure.Add(PlcBar2Adc(classCalibrationSettings.PressureUnderTestList[CurrentCalibPressureIndex]));
                                    classDeltaProtocolInstanse.classDeltaWriteSetpoint(SetPointPressure);

                                    TimeFromSetPressurePointRequest = DateTime.Now;

                                    StateChangeState(StateWaitToSetPressureStable);
                                    IncermentCalibPointStep = true;
                                }
                                else
                                {

                                    // noo need set 0 bar becouse i still set  when i sent temp setpoint.
                                    TimeFromSetPressurePointRequest = DateTime.Now;

                                    StateChangeState(StateWaitToSetPressureStable);
                                    IncermentCalibPointStep = true;
                                }
                            }
                            break;

                        case StateSendTempSetPoints:
                            {
                                ResetPressureAndTemp();

                                TimeFromSetTempPointRequest = DateTime.Now;

                                CriticalStates = false;

                                StateChangeState(StateWaitToSetTempStable);

                            }
                            break;

                        case StateWaitToSetPressureStable:
                            {
                                if (CheckTimout(TimeFromSetPressurePointRequest, MAX_TIME_WAIT_TO_PRESSURE_SET_POINT))
                                {
                                    PressureTimoutErrorEvent = true;
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

                                else if (Pressure0AfterVentStable && CurrentCalibPressureIndex == 0)
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
                                if (CheckTimout(TimeFromSetTempPointRequest, classCalibrationSettings.TempMaxWaitTime))
                                {
                                    StateChangeState(StateTempStableError);
                                    TempTimoutErrorEvent = true;
                                }
                                else
                                if (CheckTimout(TimeFromSetTempPointRequest, classCalibrationSettings.TempSkipTime))
                                {

                                        if (CheckTempStableOnOneDp(classCalibrationSettings.TempDeltaRange))
                                        {
                                            StateChangeState(StateSendPressureSetPoints);
                                        }
                                        else
                                        {
                                            Thread.Sleep(TEMP_WAIT_BETWEEN_TOW_SMPLINGS * 1000);
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

                                WriteOneLineToFile();//write line to csv file

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
                                    NextAfterTempTimoutErrorEvent = false;
                                }
                            }
                            break;
                    }

                }
                CalibrationTaskHandlerThread = null;
            }
            CriticalStates = false;
        }

        private void ResetPressureAndTemp()
        {
            // send 0[bar] to PLC comtroller
            VentToRead0Bar(); // vent system after finish calib.

            // send 18[c] to temp comtroller
            WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS, 18);
            SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 0);
        }

        public void StateChangeState(byte nextState)
        {
            PreviousState = CurrentState;
            CurrentState = nextState;
            ChengeStateEvent = true;
        }

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

        public void StateMachineResetAfterPause(byte tempIndex)
        {
            CurrentState = StateSendTempSetPoints;
            ChengeStateEvent = false;
            CurrentCalibTempIndex = tempIndex;
            CurrentCalibPressureIndex = 0;
        }

        public float ReadPressureFromPlc()
        {
            if (CheckTimout(LastPressureSample, READ_PRESSURE_INTERVAL))
            {
                try
                {
                    LastPressureSample = DateTime.Now;

                    DeltaReturnedData DataFromPLC = new DeltaReturnedData();
                    DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_FLAG_STATUS_REGISTER_ADDRESS, 1);
                    PressureStableFlag = IsBitSet(Convert.ToByte(DataFromPLC.IntValue[0]), PRESSURE_STABLE_BIT_INDEX_FLAG);


                    DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_PRESENT_VALUE_REGISTER_ADDRESS, 1);
                    CurrentPressure = (Int16)DataFromPLC.IntValue[0];
                }

                catch (Exception ex)
                {
                    ErrorMessage = "PLC ERROR-" + ex.ToString();
                    ErrorEvent = true;

                }
            }
            return CurrentPressure;
        }


        private float TempControllerReadTemp()
        {
            //Create array to accept read values:
            short[] values = new short[Convert.ToInt32(1)];
            ushort pollStart;
            ushort pollLength;

            pollStart = TEMP_PRESENT_VALUE_REGISTER_ADDRESSS;
            pollStart = Convert.ToUInt16(1);
            pollLength = Convert.ToUInt16(1);

            //Read registers and display data in desired format:
            try
            {
               ClassTempControllerInstanse.SendFc3(Convert.ToByte(Properties.Settings.Default.TempControllerSlaveAddress), pollStart, pollLength, ref values);            
            }
            catch (Exception err)
            {
                ClassTempControllerInstanse.ComPortOk = false;
                ClassTempControllerInstanse.ComPortErrorMessage = string.Format("Error: {0} connection error. function - Temp controller.", ClassTempControllerInstanse.sp.PortName);
            }

            float value = float.Parse(values[0].ToString()) / 10;

            return value;
        }
        private float GetPressureFromPlc()
        {
            return 0.5f;
        }

        private void SendCalibPointToDp(ClassDevice CurrentCalibDevice)
        {


        }
   
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
                        Thread.Sleep(250);

                        //classDpCommunicationInstanse.DpWritePressurePointToDevice(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex], CurrentCalibTempIndex, classCalibrationSettings.PressureUnderTestList[CurrentCalibPressureIndex], CurrentCalibPressureIndex);
                        classDpCommunicationInstanse.DpWritePressurePointToDevice(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex], CurrentCalibTempIndex, PlcAdc2Bar(CurrentPressure), CurrentCalibPressureIndex);
                        Thread.Sleep(2000);

                        if (classDpCommunicationInstanse.NewDpInfoEvent) // check if recieve data from DP
                        {
                            //save the data on the current device and current calibpoint..
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue1 = classDpCommunicationInstanse.dpInfo.S1Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue2 = classDpCommunicationInstanse.dpInfo.S2Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempOnDevice = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].LeftA2DValue = classDpCommunicationInstanse.dpInfo.LeftA2D;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].RightA2DValue = classDpCommunicationInstanse.dpInfo.RightA2D;
                            classDevices[DpPtr].DeviceMacAddress = classDpCommunicationInstanse.dpInfo.DeviseMacAddress;

                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].extA2dPressureValue = PlcAdc2Bar(CurrentPressure);

                            classDpCommunicationInstanse.NewDpInfoEvent = false;
                            //classDpCommunicationInstanse.DPgetDpInfo();

                            if (CurrentCalibPressureIndex == (classCalibrationSettings.PressureUnderTestList.Count - 1) && (CurrentCalibTempIndex == classCalibrationSettings.TempUnderTestList.Count - 1))
                            {
                                //send end calibration CMD
                                classDpCommunicationInstanse.SendEndCalibration();
                                if (classDevices[DpPtr].deviceStatus == DeviceStatus.Wait)
                                {
                                    classDevices[DpPtr].deviceStatus = DeviceStatus.Pass;
                                }
                            }
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

        public void WriteOneLineToFile()
        {
            for (int i = 0; i < DpCountAxist; i++)
            {
                log.PrintLogRecordToFile(classDevices[i], classCalibrationSettings.PressureUnderTestList, Properties.Settings.Default.LogPath, CurrentCalibTempIndex);
            }

        }


        private void WriteTempSetPoint(Byte registerAddress, float tempValue)
        {
            tempValue = tempValue * 10;
            short[] value = new short[1];
            value[0] = Convert.ToInt16(tempValue);

            try
            {
                while (!ClassTempControllerInstanse.SendFc16(Properties.Settings.Default.TempControllerSlaveAddress, registerAddress, (ushort)1, value)) ;
            }
            catch (Exception err)
            {
                string error = err.ToString();
            }
        }

        private void SelectSetPoint(Byte registerAddress, float SPn)
        {
            SPn = SPn * 10;
            short[] value = new short[1];
            value[0] = Convert.ToInt16(SPn);

            try
            {
                while (!ClassTempControllerInstanse.SendFc16(Properties.Settings.Default.TempControllerSlaveAddress, registerAddress, (ushort)1, value)) ;
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


        float PlcAdc2Bar(Int16 a2d)
        {
            float bar = 0;
            bar = (float)((a2d * PLC_A2D_A) - PLC_A2D_B) / 100;
            return bar;
        }

        public Int16 PlcBar2Adc(float barValue)
        {
            Int16 A2DValue = 0;
            A2DValue = (Int16)((100 * barValue + PLC_A2D_B) / PLC_A2D_A);
            return A2DValue;
        }


        void DetectDevicesTask()
        {
            while (DetectFlag)
            {
                classDevices = null;
                classDevices = new ClassDevice[MAX_DP_DEVICES];
                DpCountAxist = 0;
                classCalibrationSettings.ConnectedChanels.Clear();
                for (int i = 0; i < classCalibrationSettings.JigConfiguration; i++)
                {
                    bool Ch = new bool();
                    classMultiplexingInstanse.ConnectDpDevice((byte)i);
                    Thread.Sleep(250);

                    classDpCommunicationInstanse.DPgetDpInfo();
                    Thread.Sleep(300);


                    //classDpCommunicationInstanse.NewDpInfoEvent = true;
                    if (classDpCommunicationInstanse.NewDpInfoEvent) // check if recieve data from DP
                    {
                        classDpCommunicationInstanse.NewDpInfoEvent = false;

                        ClassDevice newDeviceExist = new ClassDevice();

                        newDeviceExist.PositionOnBoard = i;
                        newDeviceExist.BoardNumber = (i >= 0 && i < 8) ? 1 : 2;

                        newDeviceExist.DeviceMacAddress = classDpCommunicationInstanse.dpInfo.DeviseMacAddress;
                        newDeviceExist.DeviceSerialNumber = classDpCommunicationInstanse.dpInfo.DeviceSerialNumber;
                        classDevices[DpCountAxist] = newDeviceExist;

                        UpdatePressAndTempOnDPBeforCalib(newDeviceExist);

                        DpCountAxist++;

                        Ch = true;
                        classCalibrationSettings.ConnectedChanels.Add(Ch);
                    }
                    else
                    {
                        Ch = false;
                        classCalibrationSettings.ConnectedChanels.Add(Ch);
                    }
                }
                DetectFlag = false;
                EndDetectEvent = true;
            }
            DetectDevicesTaskHandlerThread = null;
        }


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

        public void InitCalibTread()
        {
            CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            CalibrationTaskHandlerThread.Start();
        }


        public void InitDetectTread()
        {
            DetectDevicesTaskHandlerThread = new Thread(DetectDevicesTask);
            DetectDevicesTaskHandlerThread.Start();
        }


        private bool CheckTempStableOnOneDp(float Tollerance)
        {
            List<float> DpTempSamples = new List<float>();

            classMultiplexingInstanse.ConnectDpDevice((byte)classDevices[0].PositionOnBoard);
            Thread.Sleep(250);
            for (int i = 0; i < classCalibrationSettings.TempSampleAmount; i++)
            {

                UpdateRealTimeData();

                classDpCommunicationInstanse.NewDpInfoEvent = false;
                classDpCommunicationInstanse.DPgetDpInfo();
                Thread.Sleep(500);

                if (classDpCommunicationInstanse.NewDpInfoEvent)
                {
                    classDpCommunicationInstanse.NewDpInfoEvent = false;
                    CurrentTempOnDP = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                    DpTempSamples.Add(CurrentTempOnDP);
                }
                Thread.Sleep(classCalibrationSettings.TempSampleInterval * 1000);
            }


            float x = Math.Abs(DpTempSamples[DpTempSamples.Count - 1] - DpTempSamples[0]);
            float y = Math.Abs(DpTempSamples.Average() - DpTempSamples[DpTempSamples.Count - 1]);


            if (Math.Abs(DpTempSamples[DpTempSamples.Count - 1] - DpTempSamples[0]) < classCalibrationSettings.TempDeltaRange &&
                Math.Abs(DpTempSamples.Average() - DpTempSamples[DpTempSamples.Count - 1]) < classCalibrationSettings.TempDeltaRange)
            {
                return true;
            }
            return false;

        }

        private Int16 VentToRead0Bar()
        {
            List<short> l = new List<short>();
            DeltaReturnedData DataFromPLC = new DeltaReturnedData();

            l.Clear();
            l.Add(0); // a2d value   = 0
            classDeltaProtocolInstanse.classDeltaWriteSetpoint(l);

            Thread.Sleep(1000);


            DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_FLAG_STATUS_REGISTER_ADDRESS, 1);
            PressureVentleFlag = IsBitSet(Convert.ToByte(DataFromPLC.IntValue[0]), PRESSURE_VENT_BIT_INDEX_FLAG);

            if(PressureVentleFlag)
            {
                Thread.Sleep(2000);

                Pressure0AfterVentStable = true; 

                DataFromPLC = classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, PLC_PRESENT_VALUE_REGISTER_ADDRESS, 1);
                CurrentPressure = (Int16)DataFromPLC.IntValue[0];
            }
            return CurrentPressure; 
        }
    }
}



