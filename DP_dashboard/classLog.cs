using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DpCommunication;

namespace DP_dashboard
{
    class classLog
    {
        private string logFileName;
        private StreamWriter file;
        private int sizeWrittenToFile;
        private int fileIndex = 0;
        private string sPath;
        private string sHostVersion;
        private string sFwVersion;

        private string GetTime()
        {
            DateTime now = DateTime.Now;
            return string.Format("{0}:{1}:{2}:{3}",now.Hour,now.Minute,now.Second,now.Millisecond);
        }

        void CreateDirectoryIfNotExist(string path)
        {
            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);
        }


        public string OpenFileForLogging(string path,ClassDevice dpDevice)
        {
            string title1 = string.Format(",DP MAC address,{0},,DP SN,{1},", dpDevice.DeviceMacAddress.ToString(), dpDevice.DeviceSerialNumber.ToString());
            string title2 = string.Format(",DP Name,{0},", dpDevice.DeviceName);

            string title3 = string.Format(",P_1 = {0},P_2 = {1},P_3 = {2},P_4 = {3},P_5 = {4},P_6 = {5},P_7 = {6},P_8 = {7},P_9 = {8},P_10 = {9},P_11 = {10},P_12 = {11},P_13 = {12},P_14 = {13},P_15 = {14},",
            dpDevice.CalibrationData[0, 0].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 1].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 2].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 3].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 4].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 5].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 6].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 7].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 8].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 9].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 10].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 11].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 12].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 13].pressureUnderTest.ToString(),
            dpDevice.CalibrationData[0, 14].pressureUnderTest.ToString()
            );
            DateTime now = DateTime.Now;

            sizeWrittenToFile = 0;

            sPath = path;

            logFileName = string.Format("{0:0000}_{1:00}_{2:00}_{3:00}_{4:00}_{5:00}_hv{6}",now.Year,now.Month,now.Day,now.Hour,now.Minute,now.Second, dpDevice.DeviceName) + ".csv";
            dpDevice.CSVFileName = logFileName;
            CreateDirectoryIfNotExist(path);

            try
            {
                file = new StreamWriter(path + @"\" +  logFileName,false);
                file.WriteLine(title1);
                file.WriteLine(title2);

                file.WriteLine("");
                file.WriteLine("");

                file.WriteLine(title3);

            }
            catch( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return logFileName;
        }

        public void PrintLogRecordToFile(ClassDevice dpDevice, string path, byte tempIndex)
        {
            string path1 = path + @"\" + dpDevice.CSVFileName;
            file = new StreamWriter(path1, true);
      

            if (file != null)
            {
                string line = string.Format("Temp(UT)= {0}," , dpDevice.CalibrationData[tempIndex, 0].tempUnderTest.ToString());
                for(int i = 0; i <15 ; i++ )
                {
                    line += dpDevice.CalibrationData[tempIndex, i].extA2dPressureValue.ToString() + ",";
                }
                file.WriteLine(line);
                file.Close();

            }
        }

        public void CloseFileForLogging()
        {
            file.Close();
            file = null;
        }
    }
}
