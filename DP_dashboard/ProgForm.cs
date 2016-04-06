using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using multiplexing_dll;
using DpCommunication;

namespace DP_dashboard
{
    public partial class ProgForm : Form
    {
        // mult plexing protocol instance
        private MultiplexingIncomingInformation MultiplexingInfo;
        private classMultiplexing MultiplexingProtocolInstanse;
        // end

        // DP protocol instance
        private ClassDpCommunication DpProtocolInstanse;
        private DpIncomingInformation DPinfo;
        // end  


        ClassCalibrationInfo classCalibrationInfo;
        StartForm startForm;
        bool EnableProgram = false;

        public ProgForm(ClassCalibrationInfo CalibrationInfo, StartForm SenderForm)
        {
            InitializeComponent();

            //init calibration data
            classCalibrationInfo = CalibrationInfo;
            startForm = SenderForm;

            // multplexing protocol init 
            MultiplexingInfo = new MultiplexingIncomingInformation();
            MultiplexingProtocolInstanse = CalibrationInfo.classMultiplexingInstanse;

            // DP protocol init
            //DPinfo = new DpIncomingInformation();
            DpProtocolInstanse = CalibrationInfo.classDpCommunicationInstanse;


        }

        private void ProgForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateExistDevicesTable()
        {
            dgv_dpTableInfo.Rows.Clear();
            for (int i = 0; i < classCalibrationInfo.DpCountAxist ;  i++)
            {
                dgv_dpTableInfo.Rows.Add(i.ToString(),true,classCalibrationInfo.classDevices[i].DeviceSerialNumber,classCalibrationInfo.classDevices[i].DeviceName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_info.Text = DateTime.Now.ToString();

            //UpdateExistDevicesTable();

            
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            EnableProgram = false;
            this.Hide();
            startForm.Show();
        }

        private void bt_startProgram_Click(object sender, EventArgs e)
        {
            EnableProgram = true;
            for (byte i = 0 ; i < classCalibrationInfo.DpCountAxist && EnableProgram == true;i++)
            {
                MultiplexingProtocolInstanse.ConnectDpDevice(i);
                // need implamnt wait to insure that the device are connected


                string RealTimeData = string.Format("Start Program DP Number {0}. Serial number:{1}. Name: {2}.",i.ToString(), classCalibrationInfo.classDevices[i].DeviceSerialNumber.ToString(), classCalibrationInfo.classDevices[i].DeviceName.ToString());
                lbl_info.Text = RealTimeData; 

                bool res = FlashDpDevice(@"C:\work\grow_me\projects\BLE-CC254x-1.4.0\Projects\ble\grow_me\CC2541DB\CC2541\Exe\SimpleBLEPeripheral.hex");

                if (!res)
                {
                    //MessageBox.Show("burn fail");
                }
            }
            EnableProgram = false;
        }

        private bool FlashDpDevice(string fileName)
        {
            string path = @"C:\Program Files (x86)\Texas Instruments\SmartRF Tools\Flash Programmer\bin\SmartRFProgConsole.exe";
            string args = string.Format("S() EPV F={0}", fileName);
            Process burn = new Process();
            burn.StartInfo.FileName = path;
            burn.StartInfo.Arguments = args;
            burn.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            burn.Start();
            burn.WaitForExit();
            return burn.ExitCode == 0;
        }

        private void bt_stopProgram_Click(object sender, EventArgs e)
        {
            EnableProgram = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateExistDevicesTable();
        }
    }
}
