using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace SerialQueryDriver
{

    public class Device
    {
        public string comName { get; set; }
        public string id { get; set; }
        public bool paired = false;

        public override string ToString()
        {
            string deviceStr = string.Format("\r\n\r\nDevice detiles:\r\nid = {0}.\r\nCom name = {1}.\r\nCom is busy - {2}\r\n\r\n", id, comName, paired == true ? "YES." : "NO.");
            return deviceStr;
        }
    }

    public static class classSerialQueryDriver
    {

        static public List<Device> devices = new List<Device>();

        public static void GetComPortName(ref string multiplexerComName, string multiplexerID, ref string plcComName, string plcID, ref string dpComName, string dpID, ref string tempControllerComName, string tempControllerID)
        {
            //Below is code pasted from WMICodeCreator
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\WMI",
                    "SELECT * FROM MSSerial_PortName");

                foreach (ManagementObject queryObj in searcher.Get())
                {



                    Device newDevice = new Device();
                    newDevice.comName = queryObj["PortName"].ToString();
                    newDevice.id = queryObj["InstanceName"].ToString();





                    if (string.Equals(queryObj["InstanceName"].ToString(), multiplexerID) )
                    {
                        multiplexerComName = queryObj["PortName"].ToString();
                        newDevice.paired = true;
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), plcID))
                    {
                        plcComName = queryObj["PortName"].ToString();
                        newDevice.paired = true;
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), dpID))
                    {
                        dpComName = queryObj["PortName"].ToString();
                        newDevice.paired = true;
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), tempControllerID))
                    {
                        tempControllerComName = queryObj["PortName"].ToString();
                        newDevice.paired = true;
                    }

                    Console.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);
                    Console.WriteLine("PortName: {0}", queryObj["PortName"]);
                    if (queryObj["InstanceName"].ToString().Contains("USB"))
                    {
                        Console.WriteLine(queryObj["PortName"] + " is a USB to SERIAL adapter / converter");
                    }

                    devices.Add(newDevice);
                }
            }
            catch (ManagementException ex)
            {
              //MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }



#if false  //this is an example of existing serial devices query

                    public void GetComPortName(string device)
        {
            //Below is code pasted from WMICodeCreator
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\WMI",
                    "SELECT * FROM MSSerial_PortName");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSSerial_PortName instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSSerial_PortName instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("PortName: {0}", queryObj["PortName"]);

                    //If the serial port's instance name contains USB 
                    //it must be a USB to serial device
                    if (queryObj["InstanceName"].ToString().Contains("USB"))
                    {
                        Console.WriteLine(queryObj["PortName"] + " is a USB to SERIAL adapter / converter");
                    }
                }
            }
            catch (ManagementException ex)
            {
              //MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }

#endif

        }
    }
}
