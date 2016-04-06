using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TempController_dll;
using DpCommunication;
using multiplexing_dll;

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
        private const byte MAX_TIME_WAIT_TO_PRESSURE_SET_POINT      = 1;      //30 sec'
        private const int  MAX_TIME_WAIT_TO_TEMP_SET_POINT          = 600;     // 10 min
        private const int  GET_DP_INFO_TIMOUT                       = 1;       // 1 sec

        //constant parameters
        private const byte MAX_DP_DEVICES                                     = 0x10;      //16
        private const byte MAX_PRESSURE_CALIB_POINT                           = 0x0f;      // 15
        private const byte MAX_TEMP_CALIB_POINT                               = 0x05;      // 5
        private const byte TEMP_SELECT_SET_POINT_REGISTER_ADDRESSS            = 15;
        private const byte TEMP_SET_POINT_1_REGISTER_ADDRESSS                 = 24;
        private const byte TEMP_SET_POINT_2_REGISTER_ADDRESSS                 = 25;
        private const byte TEMP_PRESENT_VALUE_REGISTER_ADDRESSS               = 1;


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
        public bool IncermentCalibPointStep= false;
        DateTime GetDpInforequestTime;
        //public TempControllerProtocol TempControllerInstanse = new TempControllerProtocol();

        public TempControllerProtocol ClassTempControllerInstanse;
        public ClassDpCommunication classDpCommunicationInstanse;
        public classMultiplexing classMultiplexingInstanse;
        public string TempControllerRxData = "";


        public ClassCalibrationInfo(TempControllerProtocol tempControllerInstanse , ClassDpCommunication ClassDpCommunication, classMultiplexing ClassMultiplexing)
        {
            CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            CalibrationTaskHandlerThread.Start();


            // DP TempController
            ClassTempControllerInstanse = tempControllerInstanse;

            // DP comunication
            classDpCommunicationInstanse = ClassDpCommunication;

            // Multiplexer comunication
            classMultiplexingInstanse = ClassMultiplexing;
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
            CurrentPressure = 500;
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
                                CurrentCalibDevice.DeviceCalibrationTime = DateTime.Now;

                                StateChangeState(StateSendTempSetPoints);
                            }
                            break;

                        case StateSendPressureSetPoints:
                            {
                                WritePressureSetPoint(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].pressureUnderTest);
                               // WriteTempSetPoint(TEMP_SET_POINT_1_REGISTER_ADDRESSS,CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest);
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
                                else if (CurrentPressure == CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex,CurrentCalibPressureIndex].pressureUnderTest)
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
                        //case StateSaveValues:
                        //    {
                        //        CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].extA2dPressureValue = GetPressureFromPlc();
                        //        StateChangeState(StateSendValusToDP);
                        //    }
                        //    break;
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
                        //case StateSendValusToDP:
                        //    {
                        //        SendCalibPointToDp(CurrentCalibDevice);
                        //        StateChangeState(StateEndOneCalibPoint);
                        //    }
                        //    break;
                        case StateEndOneCalibPoint:
                            {
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


        private bool WaitePressureFlag()
        {
            return false;
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
            



            //switch (dataType)
            //{
            //    case "Decimal":
                    for (int i = 0; i < pollLength; i++)
                    {
                        TempControllerRxData = Convert.ToString(pollStart + i + 40001)+
                        Convert.ToString(pollStart + i) + values[i].ToString();
                    }
            //        break;
            //    case "Hexadecimal":
            //        for (int i = 0; i < pollLength; i++)
            //        {
            //            itemString = "[" + Convert.ToString(pollStart + i + 40001) + "] , MB[" +
            //                Convert.ToString(pollStart + i) + "] = " + values[i].ToString("X");
            //            DoGUIUpdate(itemString);
            //        }
            //        break;
            //    case "Float":
            //        for (int i = 0; i < (pollLength / 2); i++)
            //        {
            //            int intValue = (int)values[2 * i];
            //            intValue <<= 16;
            //            intValue += (int)values[2 * i + 1];
            //            itemString = "[" + Convert.ToString(pollStart + 2 * i + 40001) + "] , MB[" +
            //                Convert.ToString(pollStart + 2 * i) + "] = " +
            //                (BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0)).ToString();
            //            DoGUIUpdate(itemString);
            //        }
            //        break;
            //    case "Reverse":
            //        for (int i = 0; i < (pollLength / 2); i++)
            //        {
            //            int intValue = (int)values[2 * i + 1];
            //            intValue <<= 16;
            //            intValue += (int)values[2 * i];
            //            itemString = "[" + Convert.ToString(pollStart + 2 * i + 40001) + "] , MB[" +
            //                Convert.ToString(pollStart + 2 * i) + "] = " +
            //                (BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0)).ToString();
            //            DoGUIUpdate(itemString);
            //        }
            //        break;
            //}
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
                        classDevices[i].CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempOnDevice = classDpCommunicationInstanse.dpInfo.CurrentTemp;

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

    }
}

                   