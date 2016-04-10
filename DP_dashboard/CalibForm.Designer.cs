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
            this.bt_writePressureTableToPlc = new System.Windows.Forms.Button();
            this.bt_readPressureTableFromPlc = new System.Windows.Forms.Button();
            this.pnl_plcControl = new System.Windows.Forms.Panel();
            this.pnl_calibrationPanel = new System.Windows.Forms.Panel();
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
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_devicesQueue = new System.Windows.Forms.DataGridView();
            this.col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_deviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_TempData = new System.Windows.Forms.Panel();
            this.tb_targetTemperature = new System.Windows.Forms.TextBox();
            this.tb_currentTemperature = new System.Windows.Forms.TextBox();
            this.tb_connectionStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_disConnectDP = new System.Windows.Forms.Button();
            this.bt_connectDP = new System.Windows.Forms.Button();
            this.cmb_dpList = new System.Windows.Forms.ComboBox();
            this.pnl_plcControl.SuspendLayout();
            this.pnl_calibrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).BeginInit();
            this.pnl_TempData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_writePressureTableToPlc
            // 
            this.bt_writePressureTableToPlc.Location = new System.Drawing.Point(54, 51);
            this.bt_writePressureTableToPlc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_writePressureTableToPlc.Name = "bt_writePressureTableToPlc";
            this.bt_writePressureTableToPlc.Size = new System.Drawing.Size(132, 42);
            this.bt_writePressureTableToPlc.TabIndex = 9;
            this.bt_writePressureTableToPlc.Text = "Write Pressure Table To PLC";
            this.bt_writePressureTableToPlc.UseVisualStyleBackColor = true;
            this.bt_writePressureTableToPlc.Click += new System.EventHandler(this.bt_writePressureTableToPlc_Click);
            // 
            // bt_readPressureTableFromPlc
            // 
            this.bt_readPressureTableFromPlc.Location = new System.Drawing.Point(262, 51);
            this.bt_readPressureTableFromPlc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_readPressureTableFromPlc.Name = "bt_readPressureTableFromPlc";
            this.bt_readPressureTableFromPlc.Size = new System.Drawing.Size(132, 42);
            this.bt_readPressureTableFromPlc.TabIndex = 10;
            this.bt_readPressureTableFromPlc.Text = "Read Pressure Table From PLC";
            this.bt_readPressureTableFromPlc.UseVisualStyleBackColor = true;
            this.bt_readPressureTableFromPlc.Click += new System.EventHandler(this.bt_readPressureTableFromPlc_Click);
            // 
            // pnl_plcControl
            // 
            this.pnl_plcControl.Controls.Add(this.bt_readPressureTableFromPlc);
            this.pnl_plcControl.Controls.Add(this.bt_writePressureTableToPlc);
            this.pnl_plcControl.Location = new System.Drawing.Point(1500, 462);
            this.pnl_plcControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_plcControl.Name = "pnl_plcControl";
            this.pnl_plcControl.Size = new System.Drawing.Size(412, 147);
            this.pnl_plcControl.TabIndex = 12;
            this.pnl_plcControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_plcControl_Paint);
            // 
            // pnl_calibrationPanel
            // 
            this.pnl_calibrationPanel.Controls.Add(this.bt_clear);
            this.pnl_calibrationPanel.Controls.Add(this.rtb_info);
            this.pnl_calibrationPanel.Controls.Add(this.bt_stopCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.bt_startCalibration);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_deviceData);
            this.pnl_calibrationPanel.Controls.Add(this.dgv_devicesQueue);
            this.pnl_calibrationPanel.Location = new System.Drawing.Point(40, 38);
            this.pnl_calibrationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_calibrationPanel.Name = "pnl_calibrationPanel";
            this.pnl_calibrationPanel.Size = new System.Drawing.Size(1435, 810);
            this.pnl_calibrationPanel.TabIndex = 15;
            // 
            // rtb_info
            // 
            this.rtb_info.Location = new System.Drawing.Point(90, 595);
            this.rtb_info.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(1058, 205);
            this.rtb_info.TabIndex = 6;
            this.rtb_info.Text = "";
            // 
            // bt_stopCalibration
            // 
            this.bt_stopCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_stopCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_stopCalibration.Location = new System.Drawing.Point(1173, 625);
            this.bt_stopCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.bt_stopCalibration.Name = "bt_stopCalibration";
            this.bt_stopCalibration.Size = new System.Drawing.Size(237, 60);
            this.bt_stopCalibration.TabIndex = 5;
            this.bt_stopCalibration.Text = "Stop Calibration";
            this.bt_stopCalibration.UseVisualStyleBackColor = true;
            this.bt_stopCalibration.Click += new System.EventHandler(this.bt_stopCalibration_Click);
            // 
            // bt_startCalibration
            // 
            this.bt_startCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_startCalibration.ForeColor = System.Drawing.Color.Black;
            this.bt_startCalibration.Location = new System.Drawing.Point(1173, 714);
            this.bt_startCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.bt_startCalibration.Name = "bt_startCalibration";
            this.bt_startCalibration.Size = new System.Drawing.Size(237, 60);
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
            this.dgv_deviceData.Location = new System.Drawing.Point(551, 53);
            this.dgv_deviceData.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceData.Name = "dgv_deviceData";
            this.dgv_deviceData.Size = new System.Drawing.Size(859, 529);
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
            // dgv_devicesQueue
            // 
            this.dgv_devicesQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_devicesQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_no,
            this.col_deviceName,
            this.col_serialNumber});
            this.dgv_devicesQueue.Location = new System.Drawing.Point(29, 53);
            this.dgv_devicesQueue.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_devicesQueue.Name = "dgv_devicesQueue";
            this.dgv_devicesQueue.Size = new System.Drawing.Size(375, 529);
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
            // pnl_TempData
            // 
            this.pnl_TempData.Controls.Add(this.tb_targetTemperature);
            this.pnl_TempData.Controls.Add(this.tb_currentTemperature);
            this.pnl_TempData.Controls.Add(this.tb_connectionStatus);
            this.pnl_TempData.Controls.Add(this.label7);
            this.pnl_TempData.Controls.Add(this.label6);
            this.pnl_TempData.Controls.Add(this.label5);
            this.pnl_TempData.Location = new System.Drawing.Point(1500, 38);
            this.pnl_TempData.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_TempData.Name = "pnl_TempData";
            this.pnl_TempData.Size = new System.Drawing.Size(475, 386);
            this.pnl_TempData.TabIndex = 16;
            this.pnl_TempData.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_TempData_Paint);
            // 
            // tb_targetTemperature
            // 
            this.tb_targetTemperature.Location = new System.Drawing.Point(303, 277);
            this.tb_targetTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.tb_targetTemperature.Name = "tb_targetTemperature";
            this.tb_targetTemperature.ReadOnly = true;
            this.tb_targetTemperature.Size = new System.Drawing.Size(132, 22);
            this.tb_targetTemperature.TabIndex = 5;
            // 
            // tb_currentTemperature
            // 
            this.tb_currentTemperature.Location = new System.Drawing.Point(303, 174);
            this.tb_currentTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.tb_currentTemperature.Name = "tb_currentTemperature";
            this.tb_currentTemperature.ReadOnly = true;
            this.tb_currentTemperature.Size = new System.Drawing.Size(132, 22);
            this.tb_currentTemperature.TabIndex = 4;
            // 
            // tb_connectionStatus
            // 
            this.tb_connectionStatus.Location = new System.Drawing.Point(303, 75);
            this.tb_connectionStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tb_connectionStatus.Name = "tb_connectionStatus";
            this.tb_connectionStatus.ReadOnly = true;
            this.tb_connectionStatus.Size = new System.Drawing.Size(132, 22);
            this.tb_connectionStatus.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(19, 166);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Current temperture";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(19, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "TargetTemperture";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(19, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Connection status";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(8, 652);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(75, 97);
            this.bt_clear.TabIndex = 7;
            this.bt_clear.Text = "Clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_dpList);
            this.panel1.Controls.Add(this.bt_disConnectDP);
            this.panel1.Controls.Add(this.bt_connectDP);
            this.panel1.Location = new System.Drawing.Point(1500, 663);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 147);
            this.panel1.TabIndex = 13;
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
            // cmb_dpList
            // 
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
            this.cmb_dpList.Size = new System.Drawing.Size(121, 24);
            this.cmb_dpList.TabIndex = 11;
            // 
            // CalibForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 863);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TempData);
            this.Controls.Add(this.pnl_calibrationPanel);
            this.Controls.Add(this.pnl_plcControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalibForm";
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_plcControl.ResumeLayout(false);
            this.pnl_calibrationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_devicesQueue)).EndInit();
            this.pnl_TempData.ResumeLayout(false);
            this.pnl_TempData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_writePressureTableToPlc;
        private System.Windows.Forms.Button bt_readPressureTableFromPlc;
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
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.Panel pnl_TempData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_targetTemperature;
        private System.Windows.Forms.TextBox tb_currentTemperature;
        private System.Windows.Forms.TextBox tb_connectionStatus;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_dpList;
        private System.Windows.Forms.Button bt_disConnectDP;
        private System.Windows.Forms.Button bt_connectDP;
    }
}

