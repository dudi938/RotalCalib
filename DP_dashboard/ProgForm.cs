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

        Process burn = new Process();


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
            UpdateExistDevicesTable();
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

                bool res = FlashDpDevice(@"C:\Users\dudi9\Desktop\DPT.hex");

                DGVSetCellColor(dgv_dpTableInfo, 1, i, res ? Color.Green: Color.Red);
              
            }
            EnableProgram = false;
        }

        private bool FlashDpDevice(string fileName)
        {
            string path = @"C:\Program Files (x86)\Texas Instruments\SmartRF Tools\Flash Programmer\bin\SmartRFProgConsole.exe";
            string args = string.Format("S() EPV F={0}", fileName);

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
            burn.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void DGVSetCellColor(DataGridView dgv, int col, int row, Color color)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = color;
            dgv_dpTableInfo[col, row].Style = style;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.classMultiplexingInstanse.ConnectDpDevice(byte.Parse(tb_connectdp.Text.ToString()));
        }
    }
}
