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
using TempController_dll;




namespace DP_dashboard
{

    public partial class CalibForm : Form
    {
        public static CalibForm currentForm;

        //cosntants
        private const int MAX_PRESSURE_POINT = 0x0f;

        // mult plexing protocol instance
        private MultiplexingIncomingInformation MultiplexingInfo;
        private classMultiplexing classMultiplexing;
        // end

        // plc protocol instance
        private classDeltaProtocol ClassDeltaProtocol;
        private DeltaIncomingInformation PLCinfo;
        private DeltaReturnedData IncumingParametersFromPLC;
        // end   

        // DP protocol instance  
        private ClassDpCommunication classDpCommunication;
        private DpIncomingInformation DPinfo;
        // end  

        private classLog log = new classLog();
        public ClassCalibrationInfo classCalibrationInfo;
        private string CurrentSnDeviceIsFocus = "";

        // temp controller protocol instance
        TempControllerProtocol tempControllerInstanse;

        ConfigForm ConfigFormInstanse;





        public CalibForm()
        {
            InitializeComponent();
            currentForm = this;


            // plc protocol init          
            PLCinfo = new DeltaIncomingInformation();
            ClassDeltaProtocol = new classDeltaProtocol(Properties.Settings.Default.plcComPort, 9600, PLCinfo);

            // multplexing protocol init 
            MultiplexingInfo = new MultiplexingIncomingInformation();
            classMultiplexing = new classMultiplexing(Properties.Settings.Default.multiplexingComPort, 115200, MultiplexingInfo);


            // DP protocol init

            DPinfo = new DpIncomingInformation();
            classDpCommunication = new ClassDpCommunication(Properties.Settings.Default.dpComPort, 115200, DPinfo);


            // Temp controller protocol init
            tempControllerInstanse = new TempControllerProtocol(Properties.Settings.Default.TempControllerComPort, 9600);


            // Calibration class init           
            classCalibrationInfo = new ClassCalibrationInfo(tempControllerInstanse, classDpCommunication, classMultiplexing, ClassDeltaProtocol);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //UpdateDeviceTable();
            LoadDefoultCalibPointToList();


        }

        private void bt_writePressureTableToPlc_Click(object sender, EventArgs e)
        {

            //List<Int16> PressureTable = new List<Int16>();
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest1 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest2 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest3 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest4 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest5 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest6 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest7 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest8 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest9 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest10 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest11 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest12 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest13 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest14 * 10));
            //PressureTable.Add((Int16)(Properties.Settings.Default.PressureUnderTest15 * 10));

            //rtb_info.Text += "PLC ->  " +  classCalibrationInfo.classDeltaProtocolInstanse.WritePressureTableToPLC(PressureTable) +  "\r\n";


            // SHLOM integration
            //List<Int16> SetPointPressure = new List<Int16>();

            //SetPointPressure.Add(Int16.Parse(tb_setpoint.Text));
            //classCalibrationInfo.classDeltaProtocolInstanse.classDeltaWriteSetpoint(SetPointPressure);
        }

        private void bt_readPressureTableFromPlc_Click(object sender, EventArgs e)
        {
            //IncumingParametersFromPLC = DeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 300, MAX_PRESSURE_POINT);

            //if (DeltaProtocolInstanse.newPressureTableReceive == true)
            //{
            //    DeltaProtocolInstanse.newPressureTableReceive = false;


            //    for (int i = 1; i <= MAX_PRESSURE_POINT; i++)
            //    {
            //        //dgv_prressureTable.Rows[i - 1].Cells[1].Value = IncumingParametersFromPLC.IntValue[i - 1].ToString();
            //    }

            //}

            //classCalibrationInfo.classDeltaProtocolInstanse.SendNewMessage
            //Shalom integration
            IncumingParametersFromPLC = classCalibrationInfo.classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 300, 1);
            rtb_info.Text += "flag register " + IncumingParametersFromPLC.IntValue[0].ToString() + "\r\n";

            IncumingParametersFromPLC = classCalibrationInfo.classDeltaProtocolInstanse.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 301, 1);
            rtb_info.Text += "PV = " + IncumingParametersFromPLC.IntValue[0].ToString() + "\r\n";



        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //rtbLog.Lines = PLCinfo.listDebugInfo.ToArray();



            //debug only
            //classDpCommunication.DPgetDpInfo();



            CalibrationButtonHandele();

            MarkConnectedDevice();

            if (classCalibrationInfo.FinishCalibrationEvent)
            {
                classCalibrationInfo.FinishCalibrationEvent = false;
                UpdateColorStatus();
                UpdateDataTable(CurrentSnDeviceIsFocus);
                MessageBox.Show("Calibration done!");
            }

            if(classCalibrationInfo.classCalibrationSettings.AlertToTechnican)
            {
                classCalibrationInfo.classCalibrationSettings.AlertToTechnican = false;
                DialogResult result = MessageBox.Show("Pressure stable. the system wait to tachnicatan approve.", "Pressure info", MessageBoxButtons.OK);
                if(result ==  DialogResult.OK)
                {
                    classCalibrationInfo.classCalibrationSettings.TechnicianApproveGoNext = true;   
                }
            }

            if (classCalibrationInfo.EndDetectEvent)
            {
                classCalibrationInfo.EndDetectEvent = false;

                UpdateDeviceTable();

            }

            if (classCalibrationInfo.DoCalibration)
            {
                UpdateRealTimeData();
            }

            if (classCalibrationInfo.ErrorEvent)
            {
                classCalibrationInfo.ErrorEvent = false;
                rtb_info.Text += "Error:   " + classCalibrationInfo.ErrorMessage + "\r\n";
            }

            if (classCalibrationInfo.IncermentCalibPointStep)
            {
                classCalibrationInfo.IncermentCalibPointStep = false;
                string Message = string.Format("Calibration in process : Temp index:{0}. Pressure index:{1}", classCalibrationInfo.CurrentCalibTempIndex.ToString(), classCalibrationInfo.CurrentCalibPressureIndex.ToString());
                rtb_info.Text += Message + "\r\n";

                UpdateDataTable(CurrentSnDeviceIsFocus);
            }

            if (classCalibrationInfo.ClassTempControllerInstanse.TempControllerConnectionEvent)
            {
                classCalibrationInfo.ClassTempControllerInstanse.TempControllerConnectionEvent = false;
                if (classCalibrationInfo.ClassTempControllerInstanse.TempControllerConnectionStatus)
                {
                    classCalibrationInfo.ClassTempControllerInstanse.TempControllerConnectionStatus = false;
                    tb_connectionStatus.Text = "Connected";
                }
                else
                {
                    tb_connectionStatus.Text = "Not connected";
                }
            }

            if (classCalibrationInfo.ChengeStateEvent)
            {

            }

        }

        private void pnl_plcControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_connectToDp_Click(object sender, EventArgs e)
        {
            //byte DpId = (byte)(int.Parse(cmb_dpDeviceNumber.SelectedItem.ToString()));
            //MultiplexingProtocolInstanse.ConnectDpDevice(DpId);            
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            classMultiplexing.DisConnectAllDp();
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = FlashDpDevice(@"C:\work\grow_me\projects\BLE-CC254x-1.4.0\Projects\ble\grow_me\CC2541DB\CC2541\Exe\SimpleBLEPeripheral.hex");

            if (!res)
            {
                MessageBox.Show("burn fail");
            }
        }

        private void bt_writePressursToDP_Click(object sender, EventArgs e)
        {
            // DpProtocolInstanse.SendDpSerialNumber(System.Text.Encoding.ASCII.GetBytes(tb_dpSerialNumber.Text));

            classDpCommunication.SendPressuresTableToDP();
        }

        private void bt_exportPressursTableToCSVfile_Click(object sender, EventArgs e)
        {
            //log.OpenFileForLogging(Application.StartupPath + @"\Logs", "1.0.0", "1.0.0","6778899");
            //log.PrintLogRecordToFile(DpProtocolInstanse);
            //log.CloseFileForLogging();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_getDPinfo_Click(object sender, EventArgs e)
        {
            classDpCommunication.DPgetDpInfo();
        }

        private void bt_configuration_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm(classDpCommunication, this);
            this.Hide();
            configForm.Show();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_startCalibration_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.DetectFlag = true;
            classCalibrationInfo.InitDetectTread();

            //wait to finish the detect.
            while (!classCalibrationInfo.EndDetectEvent) ;


            if (classCalibrationInfo.DpCountAxist > 0)
            {
                classCalibrationInfo.EndDetectEvent = false;
                classCalibrationInfo.EndDetectEvent = false;
                UpdateDeviceTable();


                classDpCommunication.SendStartCalibration();

                classCalibrationInfo.ResetStateMachine();
                classCalibrationInfo.DoCalibration = true;
                classCalibrationInfo.CalibrationPaused = false;
                classCalibrationInfo.InitCalibTread();
                classCalibrationInfo.CreateLogFiles();
                ClearColorIndication();
            }
            else
            {
                MessageBox.Show("No exist dp devices!");
            }

        }

        private void UpdateDeviceTable()
        {
            dgv_devicesQueue.Rows.Clear();
            for (int i = 0; i < classCalibrationInfo.DpCountAxist; i++)
            {
                dgv_devicesQueue.Rows.Add(i.ToString(),
                    classCalibrationInfo.classDevices[i].DeviceMacAddress.ToString(),
                    classCalibrationInfo.classDevices[i].DeviceSerialNumber.ToString(),
                    classCalibrationInfo.classDevices[i].PositionOnBoard.ToString(),
                    classCalibrationInfo.classDevices[i].BoardNumber.ToString());
            }
        }
        private void UpdateDataTable(string serialNumber)
        {
            bool ExistDevice = false;
            int i = 0;
            for (i = 0; i < classCalibrationInfo.DpCountAxist; i++)
            {
                if (classCalibrationInfo.classDevices[i].DeviceSerialNumber == serialNumber)
                {
                    ExistDevice = true;
                    break;
                }
            }

            int deviceIndex = i;

            if (ExistDevice)
            {
                dgv_deviceData.Rows.Clear();
                ExistDevice = false;
                string[] dataRow = new string[classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Count * 2 + 1];

                for (i = 0; i < classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Count; i++)
                {
                    dataRow[0] = classCalibrationInfo.classCalibrationSettings.PressureUnderTestList[i].ToString();
                    for (int j = 0; j < classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Count; j++)
                    {
                        dataRow[j * 2 + 1] = classCalibrationInfo.classDevices[deviceIndex].CalibrationData[j, i].LeftA2DValue.ToString();
                        dataRow[j * 2 + 2] = classCalibrationInfo.classDevices[deviceIndex].CalibrationData[j, i].RightA2DValue.ToString();
                    }
                    dgv_deviceData.Rows.Add(dataRow);
                }
            }

        }

        private void dgv_devicesQueue_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_devicesQueue.Rows[e.RowIndex].Cells[2].Value != null)
            {
                CurrentSnDeviceIsFocus = dgv_devicesQueue.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

            UpdateDataTable(CurrentSnDeviceIsFocus);

        }


        void UpdateRealTimeData()
        {
            //temp controller
            tb_currentTemperature.Text = classCalibrationInfo.CurrentTempControllerValue.ToString();
            tb_targetTemperature.Text = classCalibrationInfo.classCalibrationSettings.TempUnderTestList[classCalibrationInfo.CurrentCalibTempIndex].ToString();
            tb_temperatureOnDP.Text = classCalibrationInfo.CurrentTempOnDP.ToString();

            //pressure
            tb_pressCurrentPressure.Text = classCalibrationInfo.CurrentPressure.ToString();
            tb_pressTargetPressure.Text = classCalibrationInfo.PlcBar2Adc(classCalibrationInfo.classCalibrationSettings.PressureUnderTestList[classCalibrationInfo.CurrentCalibPressureIndex]).ToString();

            if (classCalibrationInfo.PressureStableFlag)
            {
                tb_preeStable.Text = "Yes";
            }
            else
            {
                tb_preeStable.Text = "No";
            }

        }


        private void dgv_deviceData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_stopCalibration_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.DoCalibration = false;
            classCalibrationInfo.StateMachineReset();




        }

        private void pnl_TempData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            rtb_info.Text = "";


            //string CutSn = tb_tempIndexAfterPause.Text.Substring(4);

            //byte[] SN = System.Text.Encoding.ASCII.GetBytes(CutSn);
            //classDpCommunication.SendDpSerialNumber(SN);

            //classDpCommunication.DPgetDpInfo();
        }

        private void bt_connectDP_Click(object sender, EventArgs e)
        {
            byte DpId = (byte)(int.Parse(cmb_dpList.SelectedItem.ToString()));
            classCalibrationInfo.classMultiplexingInstanse.ConnectDpDevice(DpId);
        }

        private void bt_disConnectDP_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.classMultiplexingInstanse.DisConnectAllDp();
        }

        private void dgv_devicesQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnl_calibrationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (ConfigFormInstanse == null)
            {
                ConfigFormInstanse = new ConfigForm(classDpCommunication, this);
            }
            ConfigFormInstanse.Show();
        }

        private void bt_detectDp_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.DetectFlag = true;
            classCalibrationInfo.InitDetectTread();
        }

        public void LoadDefoultCalibPointToList()
        {

            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Clear();
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Clear();


            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest1);
            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest2);
            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest3);
            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest4);
            classCalibrationInfo.classCalibrationSettings.TempUnderTestList.Add(Properties.Settings.Default.TempUnderTest5);


            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest1);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest2);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest3);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest4);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest5);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest6);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest7);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest8);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest9);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest10);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest11);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest12);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest13);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest14);
            classCalibrationInfo.classCalibrationSettings.PressureUnderTestList.Add(Properties.Settings.Default.PressureUnderTest15);
        }

        private void DGVSetCellColor(DataGridView dgv, int col, int row, Color color)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = color;
            dgv_devicesQueue[col, row].Style = style;
        }

        private void ClearColorIndication()
        {
            for (int i = 0; i < dgv_devicesQueue.Rows.Count; i++)
            {
                DGVSetCellColor(dgv_devicesQueue, 1, i, Color.White);
            }

        }


        private void UpdateColorStatus()
        {
            for (int i = 0; i < dgv_devicesQueue.Rows.Count - 1; i++)
            {
                int j = 0;
                while (j < classCalibrationInfo.DpCountAxist)
                {
                    if (dgv_devicesQueue.Rows[i].Cells[2].Value.ToString().Equals(classCalibrationInfo.classDevices[j].DeviceSerialNumber.ToString()))
                    {
                        DGVSetCellColor(dgv_devicesQueue, 1, i, classCalibrationInfo.classDevices[j].deviceStatus == DeviceStatus.Pass ? Color.Green : Color.Red);
                        break;
                    }
                    j++;
                }
            }
        }

        private void CalibForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            classCalibrationInfo.DoCalibration = false;
            classCalibrationInfo.DetectFlag = false;

            ClassDeltaProtocol.CloseComPort();
            classDpCommunication.CloseComPort();
            classMultiplexing.CloseComPort();
            tempControllerInstanse.CloseComPort();

        }

        private void CalibrationButtonHandele()
        {

            if (classCalibrationInfo.DoCalibration == true)
            {
                bt_startCalibration.Enabled = false;

                if (!classCalibrationInfo.ConnectingToDP)
                {
                    if (classCalibrationInfo.CalibrationPaused)
                    {
                        bt_pauseStartCalib.Text = "Start";
                    }
                    else
                    {
                        bt_pauseStartCalib.Text = "Pause";
                    }
                    bt_pauseStartCalib.Enabled = true;

                    bt_stopCalibration.Enabled = true;
                }
                else
                {
                    if (classCalibrationInfo.CalibrationPaused)
                    {
                        bt_startCalibration.Enabled = false;
                    }

                    bt_pauseStartCalib.Text = "Pause";
                    bt_pauseStartCalib.Enabled = false;

                    bt_stopCalibration.Enabled = false;
                }

            }
            else
            {
                bt_startCalibration.Enabled = true;

                bt_pauseStartCalib.Text = "Pause";
                bt_pauseStartCalib.Enabled = false;

                bt_stopCalibration.Enabled = false;
            }

        }

        private void bt_pauseStartCalib_Click(object sender, EventArgs e)
        {
            classCalibrationInfo.CalibrationPaused = !classCalibrationInfo.CalibrationPaused;

            if (classCalibrationInfo.CalibrationPaused == false)
            {
                byte tempIndex;
                if (tb_tempIndexAfterPause.Text.ToString() != "")
                {
                    tempIndex = byte.Parse(tb_tempIndexAfterPause.Text.ToString());
                }
                else
                {
                    tempIndex = 0;
                }
                classCalibrationInfo.StateMachineResetAfterPause(tempIndex);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string CutSn = tb_tempIndexAfterPause.Text.Substring(4);

            byte[] SN = System.Text.Encoding.ASCII.GetBytes(CutSn);
            classDpCommunication.SendDpSerialNumber(SN);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TEST
            classCalibrationInfo.classDpCommunicationInstanse.DPgetDpInfo();
        }

        private void dgv_devicesQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        public void MarkConnectedDevice()
        {
            try
            {
                DataGridViewCellStyle spatialStyle = new DataGridViewCellStyle();
                DataGridViewCellStyle normalStyle = new DataGridViewCellStyle();
                spatialStyle.ForeColor = Color.Yellow;
                normalStyle.ForeColor = Color.Black;


                for (int RowCount = 0; RowCount < dgv_devicesQueue.Rows.Count; RowCount++)
                {
                    foreach (DataGridViewCell cell in dgv_devicesQueue.Rows[RowCount].Cells)
                    {
                        if (RowCount == Convert.ToInt32(classMultiplexing.ConnectedChanel))
                        {
                            cell.Style.ForeColor = spatialStyle.ForeColor;
                        }
                        else
                        {
                            cell.Style.ForeColor = normalStyle.ForeColor;
                        }
                    }
                }
            }
            catch(Exception ex)
            { }
          }

        private void chb_pressureAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            classCalibrationInfo.classCalibrationSettings.PressureAutoMode = chb_pressureAutoMode.Checked;
        }
    }
}           
