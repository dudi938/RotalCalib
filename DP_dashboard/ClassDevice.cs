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
        public float a2dPressureValue2     {get;set;}           // A2D value 2 from DP 
        public float tempOnDevice          {get;set;}           // temperature on device.
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
        public string CSVFileName;
        

        //c'tor
        public ClassDevice()
        {
            DeviceName = "Default";
            DeviceSerialNumber = "000000";
            DeviceMacAddress = "111111";
            deviceStatus = (byte)DeviceStatus.Wait;
        }

    }

}

