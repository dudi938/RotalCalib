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
    public class ClassCalibrationInfo
    {

        //state machine stats
        public byte CurrentState                       = StateStartCalib;
        public byte NextState                          = 0x00;
        public byte PreviousState                      = 0x00;

        private const byte StateStartCalib               = 0x01;
        private const byte StateSendPressureSetPoints    = 0x02;
        private const byte StateSendTempSetPoints        = 0x03;
        private const byte StateWaitToSetPressureStable  = 0x04;
        private const byte StateWaitToSetTempStable      = 0x05;
        private const byte StateRunOfAllDp               = 0x06;
        private const byte StateSaveValues               = 0x07;
        private const byte StateSendValusToDP            = 0x08;
        private const byte StateEndOneCalibPoint         = 0x09;
        private const byte StateEndOneCalibTemp          = 0x0a;
        private const byte StateFinishAllCalibPoint      = 0x0b;
        private const byte StateError                    = 0x0c;


        //timing parameters
        private const byte MAX_TIME_WAIT_TO_PRESSURE_SET_POINT      = 180;      //30 sec'
        private const int  MAX_TIME_WAIT_TO_TEMP_SET_POINT          = 600;     // 10 min
        private const int  GET_DP_INFO_TIMOUT                       = 1;       // 1 sec
        private const int READ_PRESSURE_INTERVAL                    = 1;


        //constant parameters
        private const byte MAX_DP_DEVICES                                     = 0x10;      //16
        private const byte MAX_PRESSURE_CALIB_POINT                           = 0x0f;      // 15
        private const byte MAX_TEMP_CALIB_POINT                               = 0x05;      // 5
        private const byte TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS            = 15;
        private const byte TEMP_SET_POINT_1_REGISTER_ADDRESSS                 = 24;
        private const byte TEMP_SET_POINT_2_REGISTER_ADDRESSS                 = 25;
        private const byte TEMP_PRESENT_VALUE_REGISTER_ADDRESSS               = 1;
        private const byte PRESSURE_STABLE_BIT_INDEX_FLAG                     = 0;
        private const int  PLC_FLAG_STATUS_REGISTER_ADDRESS                   = 300;
        private const int  PLC_PRESENT_VALUE_REGISTER_ADDRESS                 = 301;
        
        //Convert A2D to BAR constant
        private const int  PLC_A2D_START_POINT = 6378;
        private const float PLC_A2D_A = 0.07856f;
        private const float PLC_A2D_B = 500f;




        private Thread CalibrationTaskHandlerThread;
        public ClassDevice[] classDevices = new ClassDevice[MAX_DP_DEVICES];
        public int DpCountAxist = 0;
        DateTime TimeFromSetPointRequest;
        public ClassDevice CurrentCalibDevice = new ClassDevice();
        public byte CurrentCalibDeviceIndex = 0;
        public byte CurrentCalibTempIndex = 0;
        public byte CurrentCalibPressureIndex = 0;
        public bool DoCalibration = false;
        public bool ChengeStateEvent = false;
        public float CurrentTemp;
        public float CurrentPressure;
        public bool PressureStableFlag = false;
        public bool IncermentCalibPointStep= false;
        public DateTime LastPressureSample = DateTime.Now;

        public string ErrorMessage = "";
        public bool ErrorEvent = false;



        DateTime GetDpInforequestTime;
        //public TempControllerProtocol TempControllerInstanse = new TempControllerProtocol();

        public TempControllerProtocol ClassTempControllerInstanse;
        public ClassDpCommunication classDpCommunicationInstanse;
        public classMultiplexing classMultiplexingInstanse;
        public string TempControllerRxData = "";
        public  classDeltaProtocol classDeltaProtocolInstanse;






        public ClassCalibrationInfo(TempControllerProtocol tempControllerInstanse , ClassDpCommunication ClassDpCommunication, classMultiplexing ClassMultiplexing , classDeltaProtocol classDeltaIncomingInformation)
        {
            CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            CalibrationTaskHandlerThread.Start();


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
            CurrentTemp = TempControllerReadTemp();

            ReadPressureFromPlc();
        }
        private void CalibrationTask()
        {
            while (true)
            {
                while (DoCalibration)
                {
                    UpdateRealTimeData();

                    switch (CurrentState)
                    {
                        case StateStartCalib:
                            {
                                CurrentCalibDevice = classDevices[CurrentCalibDeviceIndex];
                                StateChangeState(StateSendTempSetPoints);
                            }
                            break;

                        case StateSendPressureSetPoints:
                            {
                                List<Int16> SetPointPressure = new List<short>();
                                SetPointPressure.Add(PlcBar2Adc(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex,CurrentCalibPressureIndex].pressureUnderTest));
                                classDeltaProtocolInstanse.classDeltaWriteSetpoint(SetPointPressure);

                                TimeFromSetPointRequest = DateTime.Now;

                                StateChangeState(StateWaitToSetPressureStable);
                                IncermentCalibPointStep = true;
                            }
                            break;

                        case StateSendTempSetPoints:
                            {
                                //WritePressureSetPoint(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].pressureUnderTest);
                                WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS, CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest);
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
                                    StateChangeState(StateError);
                                }
                                //else if (CurrentPressure == CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex,CurrentCalibPressureIndex].pressureUnderTest && PressureStableFlag)
                                //{
                                //    StateChangeState(StateRunOfAllDp);
                                //}
                                else if (PressureStableFlag)
                                {
                                    StateChangeState(StateRunOfAllDp);
                                }
                            }
                            break;

                        case StateWaitToSetTempStable:
                            {
                                if (CheckTimout(TimeFromSetPointRequest, MAX_TIME_WAIT_TO_TEMP_SET_POINT))
                                {
                                    StateChangeState(StateError);
                                }
                                else if (CurrentTemp == CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest)
                                {
                                    StateChangeState(StateSendPressureSetPoints);
                                }
                            }
                            break;
                        case StateRunOfAllDp:
                            {
                                ReadInfoFromDp();//loop of all dp's
                                StateChangeState(StateEndOneCalibPoint);
                            }
                            break;
                        case StateEndOneCalibTemp:
                            {
                                CurrentCalibPressureIndex = 0;

                                if (CurrentCalibTempIndex < (MAX_TEMP_CALIB_POINT - 1))
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
                                if (CurrentCalibPressureIndex < (MAX_PRESSURE_CALIB_POINT - 1))
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
                                if (CurrentCalibDevice.deviceStatus != DeviceStatus.Fail)
                                {
                                    CurrentCalibDevice.deviceStatus = DeviceStatus.Pass;
                                }

                                DoCalibration = false;
                                StateChangeState(StateStartCalib);
                            }
                            break;
                        case StateError:
                            {
                                StateChangeState(StateEndOneCalibPoint);
                            }
                            break;
                    }
                }
            }
        }

        private void StateChangeState(byte nextState)
        {
            PreviousState = CurrentState;
            CurrentState = nextState;
            ChengeStateEvent = true;
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
                    CurrentPressure = DataFromPLC.IntValue[0];
                }

                catch(Exception ex)
                {
                    ErrorMessage =  "PLC ERROR-" + ex.ToString();
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
        private void ReadInfoFromDp()
        {
            for (byte i = 0; i < DpCountAxist; i++)
            {
                if (classDevices[i].deviceStatus != DeviceStatus.Fail)
                {
                    classMultiplexingInstanse.ConnectDpDevice(i);
                    Thread.Sleep(1000);

                    classDpCommunicationInstanse.NewDpInfoEvent = false;
                    classDpCommunicationInstanse.DPgetDpInfo();
                    GetDpInforequestTime = DateTime.Now;

                    while (!classDpCommunicationInstanse.NewDpInfoEvent)
                    {
                        if (CheckTimout(GetDpInforequestTime, GET_DP_INFO_TIMOUT))
                        {
                            break;
                        }
                    }

                    if (classDpCommunicationInstanse.NewDpInfoEvent) // check if recieve data from DP
                    {
                        //save the data on the current device and current calibpoint..
                        classDevices[i].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].a2dPressureValue1 = classDpCommunicationInstanse.dpInfo.S1Pressure;
                        classDevices[i].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].a2dPressureValue1 = classDpCommunicationInstanse.dpInfo.S2Pressure;
                        classDevices[i].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempOnDevice      = classDpCommunicationInstanse.dpInfo.CurrentTemp;
                        classDevices[i].DeviceMacAddress = classDpCommunicationInstanse.dpInfo.DeviseMacAddress;
                        classDpCommunicationInstanse.NewDpInfoEvent = false;
                    }

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



        private void WriteTempSetPoint(Byte registerAddress,float tempValue)
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


        float PlcAdc2Bar(Int16 a2d)
        {
            float bar = 0;
            bar = (float)((a2d * PLC_A2D_A) - PLC_A2D_B) / 100;
            return bar;
        }

        public Int16 PlcBar2Adc(float barValue)
        {
            Int16 A2DValue = 0;
            A2DValue =(Int16) ((100 * barValue + PLC_A2D_B) / PLC_A2D_A);
            return A2DValue;
        }


    }
}

                   