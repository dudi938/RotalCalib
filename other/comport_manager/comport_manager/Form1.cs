using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;


namespace comport_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    
        }

        private void button2_Click(object sender, EventArgs e)
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
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }
        }
    }
}
