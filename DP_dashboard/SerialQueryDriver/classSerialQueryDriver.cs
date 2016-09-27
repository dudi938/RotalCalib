using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace SerialQueryDriver
{
    public static class classSerialQueryDriver
    {
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

                    if(string.Equals(queryObj["InstanceName"].ToString(), multiplexerID) )
                    {
                        multiplexerComName = queryObj["PortName"].ToString();
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), plcID))
                    {
                        plcComName = queryObj["PortName"].ToString();
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), dpID))
                    {
                        dpComName = queryObj["PortName"].ToString();
                    }

                    if (string.Equals(queryObj["InstanceName"].ToString(), tempControllerID))
                    {
                        tempControllerComName = queryObj["PortName"].ToString();
                    }

                    Console.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);
                    Console.WriteLine("PortName: {0}", queryObj["PortName"]);
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
