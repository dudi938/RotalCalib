using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using FtdAdapter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;
using System.IO.Ports;
using Modbus.Serial;
using Protocol;

namespace ModBusProtocol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Driver.ModbusSerialAsciiMasterReadRegisters();
        }
    }
}
