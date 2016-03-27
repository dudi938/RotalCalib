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


        public string OpenFileForLogging(string path, string hostVersion, string fwVersion ,string dpMacNumber)
        {
            string title = ",P_1,P_2,P_3,P_4,P_5,P_6,P_7,P_8,P_9,P_10,P_11,P_12,P_13,P_14,P_15,";
            DateTime now = DateTime.Now;

            sizeWrittenToFile = 0;

            sPath = path;
            sHostVersion = hostVersion;
            sFwVersion = fwVersion;

            logFileName = string.Format("{0:0000}_{1:00}_{2:00}_{3:00}_{4:00}_{5:00}_hv{6}fw{7}_{8}",now.Year,now.Month,now.Day,now.Hour,now.Minute,now.Second,hostVersion,fwVersion, dpMacNumber) + ".csv";
            
            CreateDirectoryIfNotExist(path);

            try
            {
                file = new StreamWriter(path + @"\" +  logFileName,false);
                file.WriteLine(title);
            }
            catch( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return logFileName;
        }

        public void PrintLogRecordToFile(ClassDpCommunication DpProtocolInstanse)
        {



          string line;
//       
          if (file != null)
          {
                //line = string.Format("{0},",);
                foreach (DpCalibPointsInTemperature curTemp in DpProtocolInstanse.DPPressuresTable)
                {
                    line = curTemp.oneTempLine[0].temp.ToString() + ",";
                    foreach (DpCalibPoint currentPoint in curTemp.oneTempLine)
                    {
                        line += currentPoint.a2dPressureValue.ToString() + ",";
                    }
                    file.WriteLine(line);
                }

          }
        }

        public void CloseFileForLogging()
        {
            file.Close();
            file = null;
        }
    }
}
