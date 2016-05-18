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
        public int JigConfiguration = 8;
        public List<bool> ConnectedChanels = new List<bool>();

        public string PlcComPortName = Properties.Settings.Default.plcComPort;
        public string MultiPlexerComPortName = Properties.Settings.Default.multiplexingComPort;
        public string DpComPortName = Properties.Settings.Default.dpComPort;
        public string TempControllerComPortName = Properties.Settings.Default.TempControllerComPort;
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
        private const byte StateWaitToSetTempStable                     = 0x05;
        private const byte StateRunOfAllDp                              = 0x06;
        private const byte StateSaveValues                              = 0x07;
        private const byte StateSendValusToDP                           = 0x08;
        private const byte StateEndOneCalibPoint                        = 0x09;
        private const byte StateEndOneCalibTemp                         = 0x0a;
        private const byte StateFinishAllCalibPoint                     = 0x0b;
        private const byte StatePressureStableError                     = 0x0c;
        private const byte StateTempStableError                         = 0x0d;


        //timing parameters
        private const byte MAX_TIME_WAIT_TO_PRESSURE_SET_POINT          = 180;       //30 sec'
        private const int MAX_TIME_WAIT_TO_TEMP_SET_POINT               = 1800;     // 30 min 1800
        private const int GET_DP_INFO_TIMOUT                            = 1;       // 1 sec
        private const int READ_PRESSURE_INTERVAL                        = 1;


        //constant parameters
        private const byte MAX_DP_DEVICES                               = 0x10;      //16
        private const byte MAX_PRESSURE_CALIB_POINT                     = 0x0f;      // 15
        private const byte MAX_TEMP_CALIB_POINT                         = 0x05;      // 5
        private const byte TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS      = 15;
        private const byte TEMP_SET_POINT_1_REGISTER_ADDRESSS           = 24;
        private const byte TEMP_SET_POINT_2_REGISTER_ADDRESSS           = 25;
        private const byte TEMP_PRESENT_VALUE_REGISTER_ADDRESSS         = 1;
        private const byte PRESSURE_STABLE_BIT_INDEX_FLAG               = 0;
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
        DateTime TimeFromSetPointRequest;
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



        DateTime GetDpInforequestTime;
        //public TempControllerProtocol TempControllerInstanse = new TempControllerProtocol();

        public TempControllerProtocol ClassTempControllerInstanse;
        public ClassDpCommunication classDpCommunicationInstanse;
        public classMultiplexing classMultiplexingInstanse;
        public string TempControllerRxData = "";
        public classDeltaProtocol classDeltaProtocolInstanse;






        public ClassCalibrationInfo(TempControllerProtocol tempControllerInstanse, ClassDpCommunication ClassDpCommunication, classMultiplexing ClassMultiplexing, classDeltaProtocol classDeltaIncomingInformation)
        {
            //CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            //CalibrationTaskHandlerThread.Start();
            //InitCalibTread();


            //DetectDevicesTaskHandlerThread = new Thread(DetectDevicesTask);
            //DetectDevicesTaskHandlerThread.Start();

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
                            }
                            break;

                        case StateSendPressureSetPoints:
                            {
                                List<Int16> SetPointPressure = new List<short>();
                                SetPointPressure.Add(PlcBar2Adc(classCalibrationSettings.PressureUnderTestList[CurrentCalibPressureIndex]));
                                classDeltaProtocolInstanse.classDeltaWriteSetpoint(SetPointPressure);

                                TimeFromSetPointRequest = DateTime.Now;

                                StateChangeState(StateWaitToSetPressureStable);
                                IncermentCalibPointStep = true;
                            }
                            break;

                        case StateSendTempSetPoints:
                            {
                                //WritePressureSetPoint(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].pressureUnderTest);
                                WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS, classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex]);
                                SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 0);
                                TimeFromSetPointRequest = DateTime.Now;

                                StateChangeState(StateWaitToSetTempStable);
                                //IncermentCalibPointStep = true;
                            }
                            break;

                        case StateWaitToSetPressureStable:
                            {
                                if (CheckTimout(TimeFromSetPointRequest, MAX_TIME_WAIT_TO_PRESSURE_SET_POINT))
                                {
                                    StateChangeState(StatePressureStableError);
                                }
                                //else if (PressureStableFlag)
                                //{
                                StateChangeState(StateRunOfAllDp);
                                //}
                            }
                            break;

                        case StateWaitToSetTempStable:
                            {
                                if (CheckTimout(TimeFromSetPointRequest, MAX_TIME_WAIT_TO_TEMP_SET_POINT))
                                {
                                    StateChangeState(StateTempStableError);
                                }
                                //else if (CurrentTempControllerValue == classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex])
                                //{
                                //    StateChangeState(StateSendPressureSetPoints);
                                //}
                                else if (CheckTempStableOnOneDp(TEMP_TEMP_TOLERANCE))
                                {
                                    StateChangeState(StateSendPressureSetPoints);
                                }
                                else
                                {
                                    Thread.Sleep(1000);
                                }
                                
                            }
                            break;

                        case StateTempStableError:
                            {
                                StateChangeState(StateEndOneCalibTemp);
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
                                StateChangeState(StateStartCalib);
                            }
                            break;
                        case StatePressureStableError:
                            {
                                StateChangeState(StateEndOneCalibPoint);
                            }
                            break;
                    }

                }
                CalibrationTaskHandlerThread = null;
            }
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

        private float ReadPressureFromPlc()
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
                while (!ClassTempControllerInstanse.SendFc3(Convert.ToByte(Properties.Settings.Default.TempControllerSlaveAddress), pollStart, pollLength, ref values)) ;
            }
            catch (Exception err)
            {

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
#if false
            DUMY();

#else
            int DpPtr = 0;
            for (byte i = 0; i < classCalibrationSettings.JigConfiguration; i++)
            {
                if (classCalibrationSettings.ConnectedChanels[i] == true)
                {
                    classMultiplexingInstanse.ConnectDpDevice(i);
                    Thread.Sleep(250);

                    //write preaaure value to DP

                    classDpCommunicationInstanse.DpWritePressurePointToDevice(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex], CurrentCalibTempIndex, classCalibrationSettings.PressureUnderTestList[CurrentCalibPressureIndex], CurrentCalibPressureIndex);
                    //classDpCommunicationInstanse.DpWritePressurePointToDevice(classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex], CurrentCalibTempIndex, PlcAdc2Bar(CurrentPressure), CurrentCalibPressureIndex);
                    Thread.Sleep(1000);

                    int SendGetInfoCMDCount = 0;

                    for (SendGetInfoCMDCount = 0; SendGetInfoCMDCount < MAX_ALLOW_SEND_GET_INFO_CMD; SendGetInfoCMDCount++)
                    {
                        classDpCommunicationInstanse.NewDpInfoEvent = false;
                        classDpCommunicationInstanse.DPgetDpInfo();
                        Thread.Sleep(1000);

                        /*
                        it's fo debug
                        */
                        //classDpCommunicationInstanse.NewDpInfoEvent = true;




                        if (classDpCommunicationInstanse.NewDpInfoEvent) // check if recieve data from DP
                        {
                            //save the data on the current device and current calibpoint..
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue1 = classDpCommunicationInstanse.dpInfo.S1Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].PressureValue2 = classDpCommunicationInstanse.dpInfo.S2Pressure;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempOnDevice = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].A2DValue1 = classDpCommunicationInstanse.dpInfo.A2D1;
                            classDevices[DpPtr].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].A2DValue2 = classDpCommunicationInstanse.dpInfo.A2D2;
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
                            break;
                        }
                        else
                        {
                            if (SendGetInfoCMDCount == MAX_ALLOW_SEND_GET_INFO_CMD)
                            {
                                classDevices[DpPtr].deviceStatus = DeviceStatus.Fail;
                            }
                            Thread.Sleep(100);
                        }
                    }
                    DpPtr++;
                }
            }
#endif
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

            //SelectSetPoint(TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS, 1);
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

        int Count = 0;
        void DUMY()
        {
            classMultiplexingInstanse.ConnectDpDevice(0);
            Thread.Sleep(1000);

            //classDpCommunicationInstanse.DpWritePressurePointToDevice(classDevices[0].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest, CurrentCalibTempIndex, CurrentPressure, CurrentCalibPressureIndex);
            classDpCommunicationInstanse.NewDpInfoEvent = false;
            classDpCommunicationInstanse.DPgetDpInfo();
            Thread.Sleep(1000);

            if (classDpCommunicationInstanse.NewDpInfoEvent)
            {
                classDpCommunicationInstanse.DpWritePressurePointToDevice(classDevices[0].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest, CurrentCalibTempIndex, CurrentPressure, CurrentCalibPressureIndex);
                Count++;
            }


            classMultiplexingInstanse.ConnectDpDevice(1);
            Thread.Sleep(1000);



            classDpCommunicationInstanse.NewDpInfoEvent = false;
            classDpCommunicationInstanse.DPgetDpInfo();
            Thread.Sleep(1000);

            if (classDpCommunicationInstanse.NewDpInfoEvent)
            {
                classDpCommunicationInstanse.DpWritePressurePointToDevice(classDevices[1].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest, CurrentCalibTempIndex, CurrentPressure, CurrentCalibPressureIndex);
                Count++;
            }

        }

        private bool CheckTempStableOnOneDp(float Tollerance)
        {
            for (byte i = 0; i < classCalibrationSettings.JigConfiguration; i++)
            {
                if (classCalibrationSettings.ConnectedChanels[i])
                {
                    classMultiplexingInstanse.ConnectDpDevice(i);
                    Thread.Sleep(250);

                    classDpCommunicationInstanse.NewDpInfoEvent = false;
                    classDpCommunicationInstanse.DPgetDpInfo();
                    Thread.Sleep(500);

                    if (classDpCommunicationInstanse.NewDpInfoEvent)
                    {
                        classDpCommunicationInstanse.NewDpInfoEvent = false;
                        CurrentTempOnDP = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                        int HigeLimit = Convert.ToInt32((classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex] + Tollerance));
                        int LoweLimit = Convert.ToInt32((classCalibrationSettings.TempUnderTestList[CurrentCalibTempIndex] - Tollerance));
                        if (CurrentTempOnDP >= LoweLimit  && CurrentTempOnDP <= HigeLimit)
                        {
                            return true;
                        }
                    }

                }

            }
            return false;
        }
    }
}

                   