namespace DP_dashboard
{
    partial class CalibForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_calibrationPanel = new System.Windows.Forms.Panel();
            this.tb_tempIndexAfterPause = new System.Windows.Forms.TextBox();
            this.bt_pauseStartCalib = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.bt_stopCalibration = new System.Windows.Forms.Button();
            this.bt_startCalibration = new System.Windows.Forms.Button();
            this.dgv_deviceData = new System.Windows.Forms.DataGridView();
            this.col_extPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp1_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp1_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_temp2_p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp2_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_temp3_p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp3_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_temp4_p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp4_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_temp5_p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Temp5_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_devicesQueue = new System.Windows.Forms.DataGridView();
            this.col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_deviceMacAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevicePositionOnBoard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_TempData = new System.Windows.Forms.Panel();
            this.tb_temperatureOnDP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_targetTemperature = new System.Windows.Forms.TextBox();
            this.tb_currentTemperature = new System.Windows.Forms.TextBox();
            this.tb_connectionStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_dpList = new System.Windows.Forms.ComboBox();
            this.bt_disConnectDP = new System.Windows.Forms.Button();
            this.bt_connectDP = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_preeStable = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_pressTargetPressure = new System.Windows.Forms.TextBox();
            this.tb_pressCurrentPressure = new System.Windows.Forms.TextBox();
            this.tb_presConnectionStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_detectDp = new System.Windows.Forms.Button();
            this.bt_settings = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_calibrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).BeginInit();
            this.pnl_TempData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_calibrationPanel
            // 
            this.pnl_calibrationPanel.Controls.Add(this.tb_tempIndexAfterPause);
            this.pnl_calibrationPanel.Controls.Add(this.bt_pauseStartCalib);
            this.pnl_calibrationPanel.Controls.Add(this.bt_clear);
            this.pnl_calibrationPanel.Controls.Add(this.rtb_info);
            this.pnl_calibrationPanel.Controls.Add(this.bt_stopCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.bt_startCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_deviceData);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_devicesQueue);
            this.pnl_calibrationPanel.Location = new System.Drawing.Point(40, 38);
            this.pnl_calibrationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_calibrationPanel.Name = "pnl_calibrationPanel";
            this.pnl_calibrationPanel.Size = new System.Drawing.Size(1402, 810);
            this.pnl_calibrationPanel.TabIndex = 15;
            this.pnl_calibrationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_calibrationPanel_Paint);
            // 
            // tb_tempIndexAfterPause
            // 
            this.tb_tempIndexAfterPause.Location = new System.Drawing.Point(1136, 714);
            this.tb_tempIndexAfterPause.Name = "tb_tempIndexAfterPause";
            this.tb_tempIndexAfterPause.Size = new System.Drawing.Size(100, 22);
            this.tb_tempIndexAfterPause.TabIndex = 9;
            this.tb_tempIndexAfterPause.Text = "0";
            // 
            // bt_pauseStartCalib
            // 
            this.bt_pauseStartCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_pauseStartCalib.ForeColor = System.Drawing.Color.Black;
            this.bt_pauseStartCalib.Location = new System.Drawing.Point(1000, 694);
            this.bt_pauseStartCalib.Margin = new System.Windows.Forms.Padding(4);
            this.bt_pauseStartCalib.Name = "bt_pauseStartCalib";
            this.bt_pauseStartCalib.Size = new System.Drawing.Size(106, 60);
            this.bt_pauseStartCalib.TabIndex = 8;
            this.bt_pauseStartCalib.Text = "Pause";
            this.bt_pauseStartCalib.UseVisualStyleBackColor = true;
            this.bt_pauseStartCalib.Click += new System.EventHandler(this.bt_pauseStartCalib_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(29, 675);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(84, 67);
            this.bt_clear.TabIndex = 7;
            this.bt_clear.Text = "Clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // rtb_info
            // 
            this.rtb_info.Location = new System.Drawing.Point(120, 590);
            this.rtb_info.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(872, 205);
            this.rtb_info.TabIndex = 6;
            this.rtb_info.Text = "";
            // 
            // bt_stopCalibration
            // 
            this.bt_stopCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_stopCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_stopCalibration.Location = new System.Drawing.Point(1000, 603);
            this.bt_stopCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.bt_stopCalibration.Name = "bt_stopCalibration";
            this.bt_stopCalibration.Size = new System.Drawing.Size(106, 60);
            this.bt_stopCalibration.TabIndex = 5;
            this.bt_stopCalibration.Text = "Stop Calibration";
            this.bt_stopCalibration.UseVisualStyleBackColor = true;
            this.bt_stopCalibration.Click += new System.EventHandler(this.bt_stopCalibration_Click);
            // 
            // bt_startCalibration
            // 
            this.bt_startCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_startCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_startCalibration.Location = new System.Drawing.Point(1136, 603);
            this.bt_startCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.bt_startCalibration.Name = "bt_startCalibration";
            this.bt_startCalibration.Size = new System.Drawing.Size(114, 60);
            this.bt_startCalibration.TabIndex = 3;
            this.bt_startCalibration.Text = "Start Calibration";
            this.bt_startCalibration.UseVisualStyleBackColor = true;
            this.bt_startCalibration.Click += new System.EventHandler(this.bt_startCalibration_Click);
            // 
            // dgv_deviceData
            // 
            this.dgv_deviceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_deviceData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_extPressure,
            this.col_Temp1_1,
            this.col_Temp1_2,
            this.col_temp2_p1,
            this.col_Temp2_2,
            this.col_temp3_p1,
            this.col_Temp3_2,
            this.col_temp4_p1,
            this.col_Temp4_2,
            this.col_temp5_p1,
            this.col_Temp5_2});
            this.dgv_deviceData.Location = new System.Drawing.Point(551, 53);
            this.dgv_deviceData.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceData.Name = "dgv_deviceData";
            this.dgv_deviceData.Size = new System.Drawing.Size(847, 529);
            this.dgv_deviceData.TabIndex = 1;
            this.dgv_deviceData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_deviceData_CellContentClick);
            // 
            // col_extPressure
            // 
            this.col_extPressure.HeaderText = "Ext P";
            this.col_extPressure.Name = "col_extPressure";
            this.col_extPressure.ReadOnly = true;
            this.col_extPressure.Width = 50;
            // 
            // col_Temp1_1
            // 
            this.col_Temp1_1.HeaderText = "Temp1  Left A2D";
            this.col_Temp1_1.Name = "col_Temp1_1";
            this.col_Temp1_1.ReadOnly = true;
            this.col_Temp1_1.Width = 50;
            // 
            // col_Temp1_2
            // 
            this.col_Temp1_2.HeaderText = "Temp1 Right A2D";
            this.col_Temp1_2.Name = "col_Temp1_2";
            this.col_Temp1_2.ReadOnly = true;
            this.col_Temp1_2.Width = 50;
            // 
            // col_temp2_p1
            // 
            this.col_temp2_p1.HeaderText = "Temp2 Left A2D";
            this.col_temp2_p1.Name = "col_temp2_p1";
            this.col_temp2_p1.ReadOnly = true;
            this.col_temp2_p1.Width = 50;
            // 
            // col_Temp2_2
            // 
            this.col_Temp2_2.HeaderText = "Temp2 Right A2D";
            this.col_Temp2_2.Name = "col_Temp2_2";
            this.col_Temp2_2.ReadOnly = true;
            this.col_Temp2_2.Width = 50;
            // 
            // col_temp3_p1
            // 
            this.col_temp3_p1.HeaderText = "Temp3 Left A2D";
            this.col_temp3_p1.Name = "col_temp3_p1";
            this.col_temp3_p1.ReadOnly = true;
            this.col_temp3_p1.Width = 50;
            // 
            // col_Temp3_2
            // 
            this.col_Temp3_2.HeaderText = "Temp3 Right A2D";
            this.col_Temp3_2.Name = "col_Temp3_2";
            this.col_Temp3_2.ReadOnly = true;
            this.col_Temp3_2.Width = 50;
            // 
            // col_temp4_p1
            // 
            this.col_temp4_p1.HeaderText = "Temp4 Left Right A2D";
            this.col_temp4_p1.Name = "col_temp4_p1";
            this.col_temp4_p1.ReadOnly = true;
            this.col_temp4_p1.Width = 50;
            // 
            // col_Temp4_2
            // 
            this.col_Temp4_2.HeaderText = "Temp4 Right A2D";
            this.col_Temp4_2.Name = "col_Temp4_2";
            this.col_Temp4_2.ReadOnly = true;
            this.col_Temp4_2.Width = 50;
            // 
            // col_temp5_p1
            // 
            this.col_temp5_p1.HeaderText = "Temp5 Left A2D";
            this.col_temp5_p1.Name = "col_temp5_p1";
            this.col_temp5_p1.ReadOnly = true;
            this.col_temp5_p1.Width = 50;
            // 
            // col_Temp5_2
            // 
            this.col_Temp5_2.HeaderText = "Temp5 Right A2D";
            this.col_Temp5_2.Name = "col_Temp5_2";
            this.col_Temp5_2.ReadOnly = true;
            this.col_Temp5_2.Width = 50;
            // 
            // dgv_devicesQueue
            // 
            this.dgv_devicesQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_devicesQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_no,
            this.col_deviceMacAddress,
            this.col_serialNumber,
            this.DevicePositionOnBoard,
            this.BoardNumber});
            this.dgv_devicesQueue.Location = new System.Drawing.Point(29, 53);
            this.dgv_devicesQueue.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_devicesQueue.Name = "dgv_devicesQueue";
            this.dgv_devicesQueue.Size = new System.Drawing.Size(491, 529);
            this.dgv_devicesQueue.TabIndex = 0;
            this.dgv_devicesQueue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_devicesQueue_CellClick);
            this.dgv_devicesQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_devicesQueue_CellContentClick);
            this.dgv_devicesQueue.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_devicesQueue_CellEnter);
            // 
            // col_no
            // 
            this.col_no.HeaderText = "NO";
            this.col_no.Name = "col_no";
            this.col_no.ReadOnly = true;
            this.col_no.Width = 40;
            // 
            // col_deviceMacAddress
            // 
            this.col_deviceMacAddress.HeaderText = "Mac address";
            this.col_deviceMacAddress.Name = "col_deviceMacAddress";
            this.col_deviceMacAddress.ReadOnly = true;
            // 
            // col_serialNumber
            // 
            this.col_serialNumber.HeaderText = "Serial Number ";
            this.col_serialNumber.Name = "col_serialNumber";
            this.col_serialNumber.ReadOnly = true;
            // 
            // DevicePositionOnBoard
            // 
            this.DevicePositionOnBoard.HeaderText = "Board position ";
            this.DevicePositionOnBoard.Name = "DevicePositionOnBoard";
            this.DevicePositionOnBoard.ReadOnly = true;
            // 
            // BoardNumber
            // 
            this.BoardNumber.HeaderText = "Board number";
            this.BoardNumber.Name = "BoardNumber";
            this.BoardNumber.ReadOnly = true;
            // 
            // pnl_TempData
            // 
            this.pnl_TempData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_TempData.Controls.Add(this.tb_temperatureOnDP);
            this.pnl_TempData.Controls.Add(this.label10);
            this.pnl_TempData.Controls.Add(this.label8);
            this.pnl_TempData.Controls.Add(this.tb_targetTemperature);
            this.pnl_TempData.Controls.Add(this.tb_currentTemperature);
            this.pnl_TempData.Controls.Add(this.tb_connectionStatus);
            this.pnl_TempData.Controls.Add(this.label7);
            this.pnl_TempData.Controls.Add(this.label6);
            this.pnl_TempData.Controls.Add(this.label5);
            this.pnl_TempData.Location = new System.Drawing.Point(1460, 38);
            this.pnl_TempData.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_TempData.Name = "pnl_TempData";
            this.pnl_TempData.Size = new System.Drawing.Size(426, 211);
            this.pnl_TempData.TabIndex = 16;
            this.pnl_TempData.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_TempData_Paint);
            // 
            // tb_temperatureOnDP
            // 
            this.tb_temperatureOnDP.Location = new System.Drawing.Point(295, 134);
            this.tb_temperatureOnDP.Margin = new System.Windows.Forms.Padding(4);
            this.tb_temperatureOnDP.Name = "tb_temperatureOnDP";
            this.tb_temperatureOnDP.ReadOnly = true;
            this.tb_temperatureOnDP.Size = new System.Drawing.Size(99, 22);
            this.tb_temperatureOnDP.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(21, 134);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(227, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Current temperture on DP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(103, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Temperature Info";
            // 
            // tb_targetTemperature
            // 
            this.tb_targetTemperature.Location = new System.Drawing.Point(295, 173);
            this.tb_targetTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.tb_targetTemperature.Name = "tb_targetTemperature";
            this.tb_targetTemperature.ReadOnly = true;
            this.tb_targetTemperature.Size = new System.Drawing.Size(99, 22);
            this.tb_targetTemperature.TabIndex = 5;
            // 
            // tb_currentTemperature
            // 
            this.tb_currentTemperature.Location = new System.Drawing.Point(295, 85);
            this.tb_currentTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.tb_currentTemperature.Name = "tb_currentTemperature";
            this.tb_currentTemperature.ReadOnly = true;
            this.tb_currentTemperature.Size = new System.Drawing.Size(99, 22);
            this.tb_currentTemperature.TabIndex = 4;
            // 
            // tb_connectionStatus
            // 
            this.tb_connectionStatus.Location = new System.Drawing.Point(295, 47);
            this.tb_connectionStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tb_connectionStatus.Name = "tb_connectionStatus";
            this.tb_connectionStatus.ReadOnly = true;
            this.tb_connectionStatus.Size = new System.Drawing.Size(99, 22);
            this.tb_connectionStatus.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(19, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Oven current temperture";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(21, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "TargetTemperture";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(23, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Connection status";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_dpList);
            this.panel1.Controls.Add(this.bt_disConnectDP);
            this.panel1.Controls.Add(this.bt_connectDP);
            this.panel1.Location = new System.Drawing.Point(1495, 532);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 147);
            this.panel1.TabIndex = 13;
            // 
            // cmb_dpList
            // 
            this.cmb_dpList.DisplayMember = "0";
            this.cmb_dpList.FormattingEnabled = true;
            this.cmb_dpList.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmb_dpList.Location = new System.Drawing.Point(223, 36);
            this.cmb_dpList.Name = "cmb_dpList";
            this.cmb_dpList.Size = new System.Drawing.Size(77, 24);
            this.cmb_dpList.TabIndex = 11;
            // 
            // bt_disConnectDP
            // 
            this.bt_disConnectDP.Location = new System.Drawing.Point(37, 89);
            this.bt_disConnectDP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_disConnectDP.Name = "bt_disConnectDP";
            this.bt_disConnectDP.Size = new System.Drawing.Size(132, 42);
            this.bt_disConnectDP.TabIndex = 10;
            this.bt_disConnectDP.Text = "Disconnect";
            this.bt_disConnectDP.UseVisualStyleBackColor = true;
            this.bt_disConnectDP.Click += new System.EventHandler(this.bt_disConnectDP_Click);
            // 
            // bt_connectDP
            // 
            this.bt_connectDP.Location = new System.Drawing.Point(37, 27);
            this.bt_connectDP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_connectDP.Name = "bt_connectDP";
            this.bt_connectDP.Size = new System.Drawing.Size(132, 42);
            this.bt_connectDP.TabIndex = 9;
            this.bt_connectDP.Text = "Connect DP NO";
            this.bt_connectDP.UseVisualStyleBackColor = true;
            this.bt_connectDP.Click += new System.EventHandler(this.bt_connectDP_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tb_preeStable);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tb_pressTargetPressure);
            this.panel2.Controls.Add(this.tb_pressCurrentPressure);
            this.panel2.Controls.Add(this.tb_presConnectionStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1460, 257);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 239);
            this.panel2.TabIndex = 17;
            // 
            // tb_preeStable
            // 
            this.tb_preeStable.Location = new System.Drawing.Point(307, 189);
            this.tb_preeStable.Margin = new System.Windows.Forms.Padding(4);
            this.tb_preeStable.Name = "tb_preeStable";
            this.tb_preeStable.ReadOnly = true;
            this.tb_preeStable.Size = new System.Drawing.Size(99, 22);
            this.tb_preeStable.TabIndex = 8;
            this.tb_preeStable.Text = "no";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(20, 189);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Stable";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(103, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pressure info";
            // 
            // tb_pressTargetPressure
            // 
            this.tb_pressTargetPressure.Location = new System.Drawing.Point(306, 143);
            this.tb_pressTargetPressure.Margin = new System.Windows.Forms.Padding(4);
            this.tb_pressTargetPressure.Name = "tb_pressTargetPressure";
            this.tb_pressTargetPressure.ReadOnly = true;
            this.tb_pressTargetPressure.Size = new System.Drawing.Size(99, 22);
            this.tb_pressTargetPressure.TabIndex = 5;
            // 
            // tb_pressCurrentPressure
            // 
            this.tb_pressCurrentPressure.Location = new System.Drawing.Point(303, 100);
            this.tb_pressCurrentPressure.Margin = new System.Windows.Forms.Padding(4);
            this.tb_pressCurrentPressure.Name = "tb_pressCurrentPressure";
            this.tb_pressCurrentPressure.ReadOnly = true;
            this.tb_pressCurrentPressure.Size = new System.Drawing.Size(99, 22);
            this.tb_pressCurrentPressure.TabIndex = 4;
            // 
            // tb_presConnectionStatus
            // 
            this.tb_presConnectionStatus.Location = new System.Drawing.Point(303, 62);
            this.tb_presConnectionStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tb_presConnectionStatus.Name = "tb_presConnectionStatus";
            this.tb_presConnectionStatus.ReadOnly = true;
            this.tb_presConnectionStatus.Size = new System.Drawing.Size(99, 22);
            this.tb_presConnectionStatus.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current  pressure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target pressure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connection status";
            // 
            // bt_detectDp
            // 
            this.bt_detectDp.BackColor = System.Drawing.Color.SteelBlue;
            this.bt_detectDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_detectDp.ForeColor = System.Drawing.Color.Black;
            this.bt_detectDp.Location = new System.Drawing.Point(1739, 713);
            this.bt_detectDp.Margin = new System.Windows.Forms.Padding(4);
            this.bt_detectDp.Name = "bt_detectDp";
            this.bt_detectDp.Size = new System.Drawing.Size(147, 99);
            this.bt_detectDp.TabIndex = 18;
            this.bt_detectDp.Text = "Detect DP devices";
            this.bt_detectDp.UseVisualStyleBackColor = false;
            this.bt_detectDp.Click += new System.EventHandler(this.bt_detectDp_Click);
            // 
            // bt_settings
            // 
            this.bt_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_settings.ForeColor = System.Drawing.Color.Black;
            this.bt_settings.Location = new System.Drawing.Point(1545, 713);
            this.bt_settings.Margin = new System.Windows.Forms.Padding(4);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(147, 99);
            this.bt_settings.TabIndex = 19;
            this.bt_settings.Text = "Settings";
            this.bt_settings.UseVisualStyleBackColor = false;
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // CalibForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 837);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.bt_detectDp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TempData);
            this.Controls.Add(this.pnl_calibrationPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalibForm";
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_calibrationPanel.ResumeLayout(false);
            this.pnl_calibrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).EndInit();
            this.pnl_TempData.ResumeLayout(false);
            this.pnl_TempData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnl_calibrationPanel;
        private System.Windows.Forms.Button bt_stopCalibration;
        private System.Windows.Forms.Button bt_startCalibration;
        private System.Windows.Forms.DataGridView dgv_deviceData;
        private System.Windows.Forms.DataGridView dgv_devicesQueue;
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.Panel pnl_TempData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_targetTemperature;
        private System.Windows.Forms.TextBox tb_currentTemperature;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_dpList;
        private System.Windows.Forms.Button bt_disConnectDP;
        private System.Windows.Forms.Button bt_connectDP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_preeStable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_pressTargetPressure;
        private System.Windows.Forms.TextBox tb_pressCurrentPressure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_connectionStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_presConnectionStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_detectDp;
        private System.Windows.Forms.Button bt_settings;
        private System.Windows.Forms.Button bt_pauseStartCalib;
        private System.Windows.Forms.TextBox tb_tempIndexAfterPause;
        private System.Windows.Forms.TextBox tb_temperatureOnDP;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_deviceMacAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_serialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevicePositionOnBoard;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_extPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp1_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp1_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_temp2_p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp2_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_temp3_p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp3_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_temp4_p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp4_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_temp5_p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Temp5_2;
    }
}

