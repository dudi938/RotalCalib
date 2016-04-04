using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DP_dashboard
{
    public class ClassCalibrationInfo
    {

        //state machine stats
        private  byte CurrentState                     = StateStartCalib;
        private  byte NextState                        = 0x00;
        private  byte PreviousState                    = 0x00;

        private const byte StateStartCalib             = 0x01;
        private const byte StateSendSetPoints          = 0x02;
        private const byte StateWaitToSetPointsStable  = 0x03;
        private const byte StateReadInfoFromDp         = 0x04;
        private const byte StateSaveValues             = 0x05;
        private const byte StateSendValusToDP          = 0x06;
        private const byte StateEndOneCalibPoint       = 0x07;
        private const byte StateEndOneCalibTemp        = 0x08;
        private const byte StateFinishAllCalibPoint    = 0x09;
        private const byte StateError                  = 0x0a;


        private const byte MAX_TIME_WAIT_TO_SET_POINT  = 30; //30 sec'



        //constant parameters
        private const byte MAX_DP_DEVICES = 0x10; //16
        private const byte MAX_PRESSURE_CALIB_POINT = 0x0f; // 15
        private const byte MAX_TEMP_CALIB_POINT = 0x05; // 5


        private Thread CalibrationTaskHandlerThread;
        public ClassDevice[] classDevices = new ClassDevice[MAX_DP_DEVICES];
        public int DpCountAxist = 0;
        DateTime TimeFromSetPointRequest;
        public ClassDevice CurrentCalibDevice = new ClassDevice();
        public byte CurrentCalibDeviceIndex = 0;
        public byte CurrentCalibTempIndex = 0;
        public byte CurrentCalibPressureIndex = 0;
        public bool DoCalibration = false; 



        public ClassCalibrationInfo()
        {
            CalibrationTaskHandlerThread = new Thread(CalibrationTask);
            CalibrationTaskHandlerThread.Start();
        }

        //methods
        private void startCalibration()
        {

        }
        private void stopCalibration()
        {

        }


        private void CalibrationTask()
        {
            while (true)
            {
                while (DoCalibration)
                {
                    switch (CurrentState)
                    {
                        case StateStartCalib:
                            {
                                CurrentCalibDevice = classDevices[CurrentCalibDeviceIndex];
                                CurrentCalibDevice.DeviceCalibrationTime = DateTime.Now;

                                StateChangeState(StateSendSetPoints);
                            }
                            break;

                        case StateSendSetPoints:
                            {
                                // SendPressureSetPoint(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].pressureUnderTest);
                                // SendTempSetPoint(CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].tempUnderTest);
                                TimeFromSetPointRequest = DateTime.Now;

                                StateChangeState(StateWaitToSetPointsStable);
                            }
                            break;

                        case StateWaitToSetPointsStable:
                            {
                                if (CheckTimout(TimeFromSetPointRequest, MAX_TIME_WAIT_TO_SET_POINT))
                                {
                                    StateChangeState(StateError);
                                }
                                else if (WriteTempFlag() == true && WritePressureFlag() == true)
                                {
                                    StateChangeState(StateReadInfoFromDp);
                                }
                            }
                            break;
                        case StateReadInfoFromDp:
                            {
                                ReadInfoFromDp();
                                StateChangeState(StateSaveValues);
                            }
                            break;
                        case StateSaveValues:
                            {
                                CurrentCalibDevice.CalibrationData[CurrentCalibTempIndex, CurrentCalibPressureIndex].extA2dPressureValue = GetPressureFromPlc();
                                StateChangeState(StateSendValusToDP);
                            }
                            break;
                        case StateEndOneCalibTemp:
                            {
                                CurrentCalibTempIndex++;
                                CurrentCalibPressureIndex = 0;

                                if (CurrentCalibTempIndex < MAX_TEMP_CALIB_POINT)
                                {
                                    StateChangeState(StateSendSetPoints);
                                }
                                else
                                {
                                    CurrentCalibDevice.deviceStatus = DeviceStatus.Pass;
                                    StateChangeState(StateFinishAllCalibPoint);
                                }
                            }
                            break;
                        case StateSendValusToDP:
                            {
                                SendCalibPointToDp(CurrentCalibDevice);
                                StateChangeState(StateEndOneCalibPoint);
                            }
                            break;
                        case StateEndOneCalibPoint:
                            {
                                if (CurrentCalibPressureIndex < MAX_PRESSURE_CALIB_POINT)
                                {
                                    if (CurrentCalibDeviceIndex < DpCountAxist)
                                    {
                                        CurrentCalibDeviceIndex++;
                                        CurrentCalibDevice = classDevices[CurrentCalibDeviceIndex];

                                    }
                                    else
                                    {
                                        CurrentCalibPressureIndex++;
                                        CurrentCalibDeviceIndex = 0;
                                    }
                                    StateChangeState(StateSendSetPoints);
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
                                StateChangeState(StateStartCalib);
                            }
                            break;
                        case StateError:
                            {
                                CurrentCalibDevice.deviceStatus = DeviceStatus.Fail;
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
        }


        private bool WritePressureFlag()
        {
            return true;
        }
        private bool WriteTempFlag()
        {

            return false;
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


        }

        private bool CheckTimout(DateTime startTime, int timeout)
        {
            if (DateTime.Now.Subtract(startTime).TotalSeconds > timeout)
            {
                return true;
            }
            return false;
        }
    }
}
