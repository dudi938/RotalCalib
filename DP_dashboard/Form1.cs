using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using multiplexing_dll;
using DeltaPlcCommunication;
using DpCommunication;
using System.Diagnostics;





namespace DP_dashboard
{

    public partial class Form1 : Form
    {
        public static Form1 currentForm;

        //cosntants
        private const int MAX_PRESSURE_POINT = 10;

        // mult plexing protocol instance
        private MultiplexingIncomingInformation MultiplexingInfo;
        private classMultiplexing MultiplexingProtocolInstanse;
        // end

        // plc protocol instance
        private classDeltaProtocol DeltaProtocolInstanse;
        private DeltaIncomingInformation PLCinfo;
        private DeltaReturnedData IncumingParametersFromPLC;
        // end

        // DP protocol instance
        private ClassDpCommunication DpProtocolInstanse;
        private DpIncomingInformation DPinfo;
        // end  

        private classLog log = new classLog();

        public Form1()
        {
            InitializeComponent();
            currentForm = this;
#if xx
            // plc protocol init          
            PLCinfo = new DeltaIncomingInformation();
            DeltaProtocolInstanse = new classDeltaProtocol(Properties.Settings.Default.plcComPort, 9600, PLCinfo);
#endif
            // multplexing protocol init 
            MultiplexingInfo = new MultiplexingIncomingInformation();
            MultiplexingProtocolInstanse = new classMultiplexing(Properties.Settings.Default.multiplexingComPort, 115200, MultiplexingInfo);

#if xx

            // DP protocol init

            DPinfo = new DpIncomingInformation();
            DpProtocolInstanse = new ClassDpCommunication(Properties.Settings.Default.dpComPort, 115200, DPinfo);
            //DpProtocolInstanse.Simulation();
#endif
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 300; i < 310; i++)
            {
                dgv_prressureTable.Rows.Add(i.ToString());
            }
            
        }

        private void bt_writePressureTableToPlc_Click(object sender, EventArgs e)
        {
            List<UInt16> preshureTable = new List<UInt16>();
            for (int i = 1; i <= MAX_PRESSURE_POINT; i++)
            {
                if (dgv_prressureTable.Rows[i - 1].Cells[1].Value == null)
                {
                    preshureTable.Add(0);
                    continue;
                }
                preshureTable.Add(UInt16.Parse(dgv_prressureTable.Rows[i - 1].Cells[1].Value.ToString()));
            }
            DeltaProtocolInstanse.SendNewMessage(DeltaMsgType.PresetMultipleRegister, DeltaMemType.D, 300, (byte)preshureTable.Count, preshureTable);
        }

        private void bt_readPressureTableFromPlc_Click(object sender, EventArgs e)
        {
            IncumingParametersFromPLC = DeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 300, MAX_PRESSURE_POINT);

            if (DeltaProtocolInstanse.newPressureTableReceive == true)
            {
                DeltaProtocolInstanse.newPressureTableReceive = false;


                for (int i = 1; i <= MAX_PRESSURE_POINT; i++)
                {
                    dgv_prressureTable.Rows[i - 1].Cells[1].Value = IncumingParametersFromPLC.IntValue[i - 1].ToString();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //rtbLog.Lines = PLCinfo.listDebugInfo.ToArray();
        }

        private void pnl_plcControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_connectToDp_Click(object sender, EventArgs e)
        {
            byte DpId = (byte)(int.Parse(cmb_dpDeviceNumber.SelectedItem.ToString()));
            MultiplexingProtocolInstanse.ConnectDpDevice(DpId);            
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            MultiplexingProtocolInstanse.DisConnectAllDp();
        }

        private bool FlashDpDevice( string fileName )
        {
            string path = @"C:\Program Files (x86)\Texas Instruments\SmartRF Tools\Flash Programmer\bin\SmartRFProgConsole.exe";
            string args = string.Format("S() EPV F={0}",fileName);
            Process burn = new Process();
            burn.StartInfo.FileName = path;
            burn.StartInfo.Arguments = args;
            burn.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            burn.Start();
            burn.WaitForExit();
            return burn.ExitCode==0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = FlashDpDevice(@"C:\work\grow_me\projects\BLE-CC254x-1.4.0\Projects\ble\grow_me\CC2541DB\CC2541\Exe\SimpleBLEPeripheral.hex");

            if( !res)
            {
                MessageBox.Show("burn fail");
            }
        }

        private void bt_writePressursToDP_Click(object sender, EventArgs e)
        {
            DpProtocolInstanse.SendPressuresTableToDP();
        }

        private void bt_exportPressursTableToCSVfile_Click(object sender, EventArgs e)
        {
            log.OpenFileForLogging(Application.StartupPath + @"\Logs", "1.0.0", "1.0.0","6778899");
            log.PrintLogRecordToFile(DpProtocolInstanse);
            log.CloseFileForLogging();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_getDPinfo_Click(object sender, EventArgs e)
        {
            DpProtocolInstanse.DPgetDpInfo();
        }

        private void bt_configuration_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm(DpProtocolInstanse);
            this.Hide();
            configForm.Show();
        }
    }
}
