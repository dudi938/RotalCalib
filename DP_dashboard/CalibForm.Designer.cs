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
            this.bt_programDP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_connectToDp = new System.Windows.Forms.Button();
            this.cmb_dpDeviceNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_dpSerialNumber = new System.Windows.Forms.TextBox();
            this.bt_getDPinfo = new System.Windows.Forms.Button();
            this.bt_writePressursToDP = new System.Windows.Forms.Button();
            this.bt_exportPressursTableToCSVfile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_writePressureTableToPlc = new System.Windows.Forms.Button();
            this.bt_readPressureTableFromPlc = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.dgv_prressureTable = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A2D_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_plcControl = new System.Windows.Forms.Panel();
            this.pnl_calibrationPanel = new System.Windows.Forms.Panel();
            this.bt_stopCalibration = new System.Windows.Forms.Button();
            this.bt_startCalibration = new System.Windows.Forms.Button();
            this.dgv_deviceData = new System.Windows.Forms.DataGridView();
            this.dgv_devicesQueue = new System.Windows.Forms.DataGridView();
            this.col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_deviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_info = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).BeginInit();
            this.pnl_plcControl.SuspendLayout();
            this.pnl_calibrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_programDP
            // 
            this.bt_programDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_programDP.ForeColor = System.Drawing.Color.Black;
            this.bt_programDP.Location = new System.Drawing.Point(300, 83);
            this.bt_programDP.Name = "bt_programDP";
            this.bt_programDP.Size = new System.Drawing.Size(102, 79);
            this.bt_programDP.TabIndex = 12;
            this.bt_programDP.Text = "Program DP";
            this.bt_programDP.UseVisualStyleBackColor = true;
            this.bt_programDP.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.bt_disconnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_connectToDp);
            this.panel1.Controls.Add(this.cmb_dpDeviceNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.panel1.Location = new System.Drawing.Point(1279, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 144);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_disconnect.ForeColor = System.Drawing.Color.Black;
            this.bt_disconnect.Location = new System.Drawing.Point(22, 131);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(120, 49);
            this.bt_disconnect.TabIndex = 4;
            this.bt_disconnect.TabStop = false;
            this.bt_disconnect.Text = "Disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(274, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DP NO";
            // 
            // bt_connectToDp
            // 
            this.bt_connectToDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_connectToDp.ForeColor = System.Drawing.Color.Black;
            this.bt_connectToDp.Location = new System.Drawing.Point(20, 62);
            this.bt_connectToDp.Name = "bt_connectToDp";
            this.bt_connectToDp.Size = new System.Drawing.Size(120, 49);
            this.bt_connectToDp.TabIndex = 2;
            this.bt_connectToDp.Text = "Connect to DP";
            this.bt_connectToDp.UseVisualStyleBackColor = true;
            this.bt_connectToDp.Click += new System.EventHandler(this.bt_connectToDp_Click);
            // 
            // cmb_dpDeviceNumber
            // 
            this.cmb_dpDeviceNumber.FormattingEnabled = true;
            this.cmb_dpDeviceNumber.Items.AddRange(new object[] {
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
            this.cmb_dpDeviceNumber.Location = new System.Drawing.Point(238, 135);
            this.cmb_dpDeviceNumber.Name = "cmb_dpDeviceNumber";
            this.cmb_dpDeviceNumber.Size = new System.Drawing.Size(121, 21);
            this.cmb_dpDeviceNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(160, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Multiplexing control";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tb_dpSerialNumber);
            this.panel2.Controls.Add(this.bt_getDPinfo);
            this.panel2.Controls.Add(this.bt_programDP);
            this.panel2.Controls.Add(this.bt_writePressursToDP);
            this.panel2.Controls.Add(this.bt_exportPressursTableToCSVfile);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.panel2.Location = new System.Drawing.Point(1279, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 121);
            this.panel2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "DP serial no";
            // 
            // tb_dpSerialNumber
            // 
            this.tb_dpSerialNumber.Location = new System.Drawing.Point(22, 34);
            this.tb_dpSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tb_dpSerialNumber.Name = "tb_dpSerialNumber";
            this.tb_dpSerialNumber.Size = new System.Drawing.Size(103, 20);
            this.tb_dpSerialNumber.TabIndex = 14;
            // 
            // bt_getDPinfo
            // 
            this.bt_getDPinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_getDPinfo.ForeColor = System.Drawing.Color.Black;
            this.bt_getDPinfo.Location = new System.Drawing.Point(159, 83);
            this.bt_getDPinfo.Name = "bt_getDPinfo";
            this.bt_getDPinfo.Size = new System.Drawing.Size(102, 79);
            this.bt_getDPinfo.TabIndex = 13;
            this.bt_getDPinfo.TabStop = false;
            this.bt_getDPinfo.Text = "Get DP Info";
            this.bt_getDPinfo.UseVisualStyleBackColor = true;
            this.bt_getDPinfo.Click += new System.EventHandler(this.bt_getDPinfo_Click);
            // 
            // bt_writePressursToDP
            // 
            this.bt_writePressursToDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_writePressursToDP.ForeColor = System.Drawing.Color.Black;
            this.bt_writePressursToDP.Location = new System.Drawing.Point(22, 83);
            this.bt_writePressursToDP.Name = "bt_writePressursToDP";
            this.bt_writePressursToDP.Size = new System.Drawing.Size(102, 79);
            this.bt_writePressursToDP.TabIndex = 4;
            this.bt_writePressursToDP.TabStop = false;
            this.bt_writePressursToDP.Text = "Write pressurs table to DP";
            this.bt_writePressursToDP.UseVisualStyleBackColor = true;
            this.bt_writePressursToDP.Click += new System.EventHandler(this.bt_writePressursToDP_Click);
            // 
            // bt_exportPressursTableToCSVfile
            // 
            this.bt_exportPressursTableToCSVfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exportPressursTableToCSVfile.ForeColor = System.Drawing.Color.Black;
            this.bt_exportPressursTableToCSVfile.Location = new System.Drawing.Point(422, 83);
            this.bt_exportPressursTableToCSVfile.Name = "bt_exportPressursTableToCSVfile";
            this.bt_exportPressursTableToCSVfile.Size = new System.Drawing.Size(102, 79);
            this.bt_exportPressursTableToCSVfile.TabIndex = 2;
            this.bt_exportPressursTableToCSVfile.Text = "Export pressurs table to CSV file";
            this.bt_exportPressursTableToCSVfile.UseVisualStyleBackColor = true;
            this.bt_exportPressursTableToCSVfile.Click += new System.EventHandler(this.bt_exportPressursTableToCSVfile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(245, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "DP control";
            // 
            // bt_writePressureTableToPlc
            // 
            this.bt_writePressureTableToPlc.Location = new System.Drawing.Point(23, 43);
            this.bt_writePressureTableToPlc.Margin = new System.Windows.Forms.Padding(2);
            this.bt_writePressureTableToPlc.Name = "bt_writePressureTableToPlc";
            this.bt_writePressureTableToPlc.Size = new System.Drawing.Size(99, 34);
            this.bt_writePressureTableToPlc.TabIndex = 9;
            this.bt_writePressureTableToPlc.Text = "Write Pressure Table To PLC";
            this.bt_writePressureTableToPlc.UseVisualStyleBackColor = true;
            this.bt_writePressureTableToPlc.Click += new System.EventHandler(this.bt_writePressureTableToPlc_Click);
            // 
            // bt_readPressureTableFromPlc
            // 
            this.bt_readPressureTableFromPlc.Location = new System.Drawing.Point(23, 101);
            this.bt_readPressureTableFromPlc.Margin = new System.Windows.Forms.Padding(2);
            this.bt_readPressureTableFromPlc.Name = "bt_readPressureTableFromPlc";
            this.bt_readPressureTableFromPlc.Size = new System.Drawing.Size(99, 34);
            this.bt_readPressureTableFromPlc.TabIndex = 10;
            this.bt_readPressureTableFromPlc.Text = "Read Pressure Table From PLC";
            this.bt_readPressureTableFromPlc.UseVisualStyleBackColor = true;
            this.bt_readPressureTableFromPlc.Click += new System.EventHandler(this.bt_readPressureTableFromPlc_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(140, 344);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(354, 122);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // dgv_prressureTable
            // 
            this.dgv_prressureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prressureTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.A2D_Value,
            this.Pressure});
            this.dgv_prressureTable.Location = new System.Drawing.Point(1345, 572);
            this.dgv_prressureTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_prressureTable.Name = "dgv_prressureTable";
            this.dgv_prressureTable.RowTemplate.Height = 24;
            this.dgv_prressureTable.Size = new System.Drawing.Size(147, 114);
            this.dgv_prressureTable.TabIndex = 11;
            this.dgv_prressureTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_prressureTable_CellContentClick);
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // A2D_Value
            // 
            this.A2D_Value.HeaderText = "A2D Value";
            this.A2D_Value.Name = "A2D_Value";
            // 
            // Pressure
            // 
            this.Pressure.HeaderText = "Pressure[b]";
            this.Pressure.Name = "Pressure";
            // 
            // pnl_plcControl
            // 
            this.pnl_plcControl.Controls.Add(this.rtbLog);
            this.pnl_plcControl.Controls.Add(this.bt_readPressureTableFromPlc);
            this.pnl_plcControl.Controls.Add(this.bt_writePressureTableToPlc);
            this.pnl_plcControl.Location = new System.Drawing.Point(1329, 381);
            this.pnl_plcControl.Name = "pnl_plcControl";
            this.pnl_plcControl.Size = new System.Drawing.Size(152, 177);
            this.pnl_plcControl.TabIndex = 12;
            this.pnl_plcControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_plcControl_Paint);
            // 
            // pnl_calibrationPanel
            // 
            this.pnl_calibrationPanel.Controls.Add(this.lbl_info);
            this.pnl_calibrationPanel.Controls.Add(this.bt_stopCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.bt_startCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_deviceData);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_devicesQueue);
            this.pnl_calibrationPanel.Location = new System.Drawing.Point(30, 31);
            this.pnl_calibrationPanel.Name = "pnl_calibrationPanel";
            this.pnl_calibrationPanel.Size = new System.Drawing.Size(1076, 658);
            this.pnl_calibrationPanel.TabIndex = 15;
            // 
            // bt_stopCalibration
            // 
            this.bt_stopCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_stopCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_stopCalibration.Location = new System.Drawing.Point(646, 498);
            this.bt_stopCalibration.Name = "bt_stopCalibration";
            this.bt_stopCalibration.Size = new System.Drawing.Size(178, 74);
            this.bt_stopCalibration.TabIndex = 5;
            this.bt_stopCalibration.Text = "Stop Calibration";
            this.bt_stopCalibration.UseVisualStyleBackColor = true;
            // 
            // bt_startCalibration
            // 
            this.bt_startCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_startCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_startCalibration.Location = new System.Drawing.Point(413, 498);
            this.bt_startCalibration.Name = "bt_startCalibration";
            this.bt_startCalibration.Size = new System.Drawing.Size(178, 74);
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
            this.col_Temp5_2,
            this.col_status});
            this.dgv_deviceData.Location = new System.Drawing.Point(413, 43);
            this.dgv_deviceData.Name = "dgv_deviceData";
            this.dgv_deviceData.Size = new System.Drawing.Size(644, 430);
            this.dgv_deviceData.TabIndex = 1;
            this.dgv_deviceData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_deviceData_CellContentClick);
            // 
            // dgv_devicesQueue
            // 
            this.dgv_devicesQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_devicesQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_no,
            this.col_deviceName,
            this.col_serialNumber});
            this.dgv_devicesQueue.Location = new System.Drawing.Point(22, 43);
            this.dgv_devicesQueue.Name = "dgv_devicesQueue";
            this.dgv_devicesQueue.Size = new System.Drawing.Size(281, 442);
            this.dgv_devicesQueue.TabIndex = 0;
            this.dgv_devicesQueue.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_devicesQueue_CellEnter);
            // 
            // col_no
            // 
            this.col_no.HeaderText = "NO";
            this.col_no.Name = "col_no";
            this.col_no.ReadOnly = true;
            this.col_no.Width = 40;
            // 
            // col_deviceName
            // 
            this.col_deviceName.HeaderText = "Device name";
            this.col_deviceName.Name = "col_deviceName";
            this.col_deviceName.ReadOnly = true;
            // 
            // col_serialNumber
            // 
            this.col_serialNumber.HeaderText = "Serial Number ";
            this.col_serialNumber.Name = "col_serialNumber";
            this.col_serialNumber.ReadOnly = true;
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
            this.col_Temp1_1.HeaderText = "Temp1 p1";
            this.col_Temp1_1.Name = "col_Temp1_1";
            this.col_Temp1_1.ReadOnly = true;
            this.col_Temp1_1.Width = 50;
            // 
            // col_Temp1_2
            // 
            this.col_Temp1_2.HeaderText = "Temp1 p2";
            this.col_Temp1_2.Name = "col_Temp1_2";
            this.col_Temp1_2.ReadOnly = true;
            this.col_Temp1_2.Width = 50;
            // 
            // col_temp2_p1
            // 
            this.col_temp2_p1.HeaderText = "Temp2 p1";
            this.col_temp2_p1.Name = "col_temp2_p1";
            this.col_temp2_p1.ReadOnly = true;
            this.col_temp2_p1.Width = 50;
            // 
            // col_Temp2_2
            // 
            this.col_Temp2_2.HeaderText = "Temp2 p2";
            this.col_Temp2_2.Name = "col_Temp2_2";
            this.col_Temp2_2.ReadOnly = true;
            this.col_Temp2_2.Width = 50;
            // 
            // col_temp3_p1
            // 
            this.col_temp3_p1.HeaderText = "Temp3 p1";
            this.col_temp3_p1.Name = "col_temp3_p1";
            this.col_temp3_p1.ReadOnly = true;
            this.col_temp3_p1.Width = 50;
            // 
            // col_Temp3_2
            // 
            this.col_Temp3_2.HeaderText = "Temp3 p2";
            this.col_Temp3_2.Name = "col_Temp3_2";
            this.col_Temp3_2.ReadOnly = true;
            this.col_Temp3_2.Width = 50;
            // 
            // col_temp4_p1
            // 
            this.col_temp4_p1.HeaderText = "Temp4 p1";
            this.col_temp4_p1.Name = "col_temp4_p1";
            this.col_temp4_p1.ReadOnly = true;
            this.col_temp4_p1.Width = 50;
            // 
            // col_Temp4_2
            // 
            this.col_Temp4_2.HeaderText = "Temp4 p2";
            this.col_Temp4_2.Name = "col_Temp4_2";
            this.col_Temp4_2.ReadOnly = true;
            this.col_Temp4_2.Width = 50;
            // 
            // col_temp5_p1
            // 
            this.col_temp5_p1.HeaderText = "Temp5 p1";
            this.col_temp5_p1.Name = "col_temp5_p1";
            this.col_temp5_p1.ReadOnly = true;
            this.col_temp5_p1.Width = 50;
            // 
            // col_Temp5_2
            // 
            this.col_Temp5_2.HeaderText = "Temp5 p2";
            this.col_Temp5_2.Name = "col_Temp5_2";
            this.col_Temp5_2.ReadOnly = true;
            this.col_Temp5_2.Width = 50;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(413, 603);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(0, 15);
            this.lbl_info.TabIndex = 6;
            // 
            // CalibForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 701);
            this.Controls.Add(this.dgv_prressureTable);
            this.Controls.Add(this.pnl_calibrationPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_plcControl);
            this.Name = "CalibForm";
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).EndInit();
            this.pnl_plcControl.ResumeLayout(false);
            this.pnl_calibrationPanel.ResumeLayout(false);
            this.pnl_calibrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_connectToDp;
        private System.Windows.Forms.ComboBox cmb_dpDeviceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Button bt_programDP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_writePressursToDP;
        private System.Windows.Forms.Button bt_exportPressursTableToCSVfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_getDPinfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_dpSerialNumber;
        private System.Windows.Forms.Button bt_writePressureTableToPlc;
        private System.Windows.Forms.Button bt_readPressureTableFromPlc;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.DataGridView dgv_prressureTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn A2D_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pressure;
        private System.Windows.Forms.Panel pnl_plcControl;
        private System.Windows.Forms.Panel pnl_calibrationPanel;
        private System.Windows.Forms.Button bt_stopCalibration;
        private System.Windows.Forms.Button bt_startCalibration;
        private System.Windows.Forms.DataGridView dgv_deviceData;
        private System.Windows.Forms.DataGridView dgv_devicesQueue;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_deviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_serialNumber;
        private System.Windows.Forms.Label lbl_info;
    }
}

