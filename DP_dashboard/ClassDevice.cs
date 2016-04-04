using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_dashboard
{
    public class DpCalibPointData
    {
        public float tempUnderTest         {get;set;}           // temperature of the current temp value
        public float pressureUnderTest     {get;set;}           // Physical pressure of the current a2d pressure value
        public float extA2dPressureValue   {get;set;}           // value from extenal pressure sensor(from Shalom)
        public float a2dPressureValue1     {get;set;}           // A2D value 1 from DP 
        public int   a2dPressureValue2     {get;set;}           // A2D value 2 from DP 
    }

    public enum DeviceStatus { Wait, Pass, Fail, Runinng};

    public class ClassDevice
    {

        private const byte MAX_PRESSURE_CALIB_POINT = 0x0f; // 15
        private const byte MAX_TEMP_CALIB_POINT     = 0x05; // 5

        public string DeviceName { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string DeviceMacAddress { get; set; }
        public DateTime  DeviceCalibrationTime { get; set; }
        public DateTime DeviceProgramTime { get; set; }
        public DeviceStatus deviceStatus = DeviceStatus.Pass;
        public DpCalibPointData[,] CalibrationData = new DpCalibPointData[MAX_TEMP_CALIB_POINT, MAX_PRESSURE_CALIB_POINT];



        private List<float> TempUnderTestList = new List<float>();
        private List<float> PressureUnderTestList = new List<float>();

        

        //c'tor
        public ClassDevice()
        {

            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest1);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest2);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest3);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest4);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest5);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest6);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest7);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest8);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest9);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest10);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest11);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest12);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest13);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest14);
            PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest15);

            TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest1);
            TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest2);
            TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest3);
            TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest4);
            TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest5);




            DeviceName = "Default";
            DeviceSerialNumber = "000000";
            DeviceMacAddress = "111111";
            deviceStatus = (byte)DeviceStatus.Wait;
            for (int i = 0;  i< MAX_TEMP_CALIB_POINT; i++)
            {
                for (int j = 0; j < MAX_PRESSURE_CALIB_POINT; j++)
                {
                    DpCalibPointData newCalibPoint = new DpCalibPointData();

                    newCalibPoint.pressureUnderTest = PressureUnderTestList[j];
                    newCalibPoint.tempUnderTest = TempUnderTestList[i];

                    CalibrationData[i, j] = newCalibPoint;
                }

            }
        }

    }

}

