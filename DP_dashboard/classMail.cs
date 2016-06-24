using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace DP_dashboard
{
    static public class ClassMail
    {
        static MailMessage mail = new MailMessage();
        static SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");


        static public bool SendCalibrationDone()
        {           
            return SendMessage("Calibration done", string.Format("{0} - Calibration done.", DateTime.Now.ToString()));
        }

        static public bool SendCalibrationFailed()
        {
            return SendMessage("Calibration Fail", string.Format("{0} - Calibration fail.", DateTime.Now.ToString()));
        }



        static public bool SendMessage(string Sub, string Body)
        {
            try
            {

                //new System.Net.NetworkCredential("dotnet4918", "49184918dot");
                //mail.From = new MailAddress("dotnet4918@gmail.com");

                new System.Net.NetworkCredential("dudi938", "Dudi0542151661");
                mail.From = new MailAddress("dudi938@gmail.com");


                mail.To.Add("dudi938@gmail.com");
                mail.Subject = Sub;
                mail.Body = Body;

                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

