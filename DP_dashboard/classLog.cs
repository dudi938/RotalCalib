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


        public string OpenFileForLogging(List<float> pressuresUnderTeat,string path,ClassDevice dpDevice)
        {
            string title1 = ",";
            for(int i = 0; i< pressuresUnderTeat.Count; i++)
            {
                title1 += "P = " + pressuresUnderTeat[i].ToString() + "[Bar]" + ",";
            }
            title1 += "DP_MAC_Address,DP_SN,DP_Name,";


            DateTime now = DateTime.Now;

            sizeWrittenToFile = 0;

            sPath = path;

            logFileName = string.Format("{0:0000}_{1:00}_{2:00}_{3:00}_{4:00}_{5:00}_{6}",now.Year,now.Month,now.Day,now.Hour,now.Minute,now.Second, dpDevice.DeviceSerialNumber) + ".csv";
            dpDevice.CSVFileName = logFileName;
            CreateDirectoryIfNotExist(path);

            try
            {
                file = new StreamWriter(path + @"\" +  logFileName,false);
                file.WriteLine(title1);     

            }
            catch( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return logFileName;
        }

        public void PrintLogRecordToFile(ClassDevice device, List<float> pressuresUnderTeat, string path, byte tempIndex)
        {
            string path1 = path + @"\" + device.CSVFileName;
            file = new StreamWriter(path1, true);
      

            if (file != null)
            {

                //write ext pressure
                string line = string.Format("Temp#{0}-PLC_pressure," , tempIndex);
                for(int i = 0; i < pressuresUnderTeat.Count; i++ )
                {
                    line += pressuresUnderTeat[i].ToString() + ",";
                }
                line += string.Format("{0},{1},{2},", device.DeviceMacAddress, device.DeviceSerialNumber, device.DeviceName);
                file.WriteLine(line);

                //write dp A2D1
                line = string.Empty;
                line = string.Format("Temp#{0}-DP_A2D_1,", tempIndex);
                for (int i = 0; i < pressuresUnderTeat.Count; i++)
                {
                    line += device.CalibrationData[tempIndex, i].A2DValue1.ToString() + ",";
                }
                line += string.Format("{0},{1},{2},", device.DeviceMacAddress, device.DeviceSerialNumber, device.DeviceName);
                file.WriteLine(line);

                //write dp A2D2
                line = string.Empty;
                line = string.Format("Temp#{0}-DP_A2D_2,", tempIndex);
                for (int i = 0; i < pressuresUnderTeat.Count; i++)
                {
                    line += device.CalibrationData[tempIndex, i].A2DValue2.ToString() + ",";
                }
                line += string.Format("{0},{1},{2},", device.DeviceMacAddress, device.DeviceSerialNumber, device.DeviceName);
                file.WriteLine(line);


                //write  dp temp
                line = string.Empty;
                line = string.Format("Temp#{0}-DP_Temp,", tempIndex);
                for (int i = 0; i < pressuresUnderTeat.Count; i++)
                {
                    line += device.CalibrationData[tempIndex, i].tempOnDevice.ToString() + ",";
                }
                line += string.Format("{0},{1},{2},", device.DeviceMacAddress, device.DeviceSerialNumber, device.DeviceName);
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
