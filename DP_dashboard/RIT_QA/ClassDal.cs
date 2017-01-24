using System;
using System.Linq;
//using log4net;
using System.Reflection;
using System.Collections.Generic;
using log4net;

namespace DP_dashboard.RIT_QA
{
    static public class ClassDal
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static bool AddCalibrationRow(CalibrationData row)
        {
            using (RIT_QAEntities db = new RIT_QAEntities())
            {
                if(db.Devices.Find(row.SerialNo) == null)
                {
                    Device dev = new Device();
                    dev.SerialNo = row.SerialNo;
                    db.Devices.Add(dev);
                    SaveDbChenges(db);
                }

                db.CalibrationDatas.Add(row);

                return SaveDbChenges(db);
            }
        }


        public static bool AddOneTempertureTable(List<CalibrationData>  tampertureTable)
        {
            foreach (CalibrationData row in tampertureTable)
            {
                if(!AddCalibrationRow(row))
                {
                    return false;
                }
            }
            return true;
        }



        static public Device GetDeviceBySerialNumber(string serialNo)
        {
            Device dev;
            using (RIT_QAEntities db = new RIT_QAEntities())
            {
                dev = db.Devices.Find(serialNo);
            }
            return dev;
        }


        static public User GetUserByID(int id)
        {
            User user;
            using (RIT_QAEntities db = new RIT_QAEntities())
            {
                user = db.Users.Find(id);
            }
            return user;
        }


        public static int GetFirstUserID()
        {
            using (RIT_QAEntities db = new RIT_QAEntities())
            {
                User user = db.Users.FirstOrDefault();
                if(user == null)
                {
                    user = new User();
                    user.Name = "david";
                    user.Password = "123456";
                    db.Users.Add(user);

                    SaveDbChenges(db);
                }
                return user.Id;
            }
        }

        static bool SaveDbChenges(RIT_QAEntities db)
        {
            try
            {
                db.SaveChanges();

                Logger.Info("Save chenges success");

                return true;
            }
            catch(Exception ex)
            {
                Logger.Error("Save chenges failed" + "    "  + ex.StackTrace.ToString() + ex.InnerException.ToString());

                return false;
            }
        }


    }
}
