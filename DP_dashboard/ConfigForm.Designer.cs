namespace DP_dashboard
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.bt_loadCustomerConfigFile = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_saveCalibPoint = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_tempSampleNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_tempMaxWaitTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_jigConfiguration = new System.Windows.Forms.Label();
            this.tb_tempDeltaRange = new System.Windows.Forms.TextBox();
            this.cmb_jigConfiguration = new System.Windows.Forms.ComboBox();
            this.tb_temSpampleInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_settingsPanel = new System.Windows.Forms.Panel();
            this.tb_batch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_stationId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_fwVersion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_calibPressuresPointsTable = new System.Windows.Forms.DataGridView();
            this.prs_Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txb_pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_calibTempPointsTable = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Temperture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCapabilities = new System.Windows.Forms.GroupBox();
            this.chkDataLogger = new System.Windows.Forms.CheckBox();
            this.chkWash = new System.Windows.Forms.CheckBox();
            this.chkDPS = new System.Windows.Forms.CheckBox();
            this.chkDPT = new System.Windows.Forms.CheckBox();
            this.chkPT = new System.Windows.Forms.CheckBox();
            this.chkPS = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.pnl_settingsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).BeginInit();
            this.grpCapabilities.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_loadCustomerConfigFile
            // 
            this.bt_loadCustomerConfigFile.AutoEllipsis = true;
            this.bt_loadCustomerConfigFile.BackColor = System.Drawing.Color.Silver;
            this.bt_loadCustomerConfigFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_loadCustomerConfigFile.ForeColor = System.Drawing.Color.Blue;
            this.bt_loadCustomerConfigFile.Location = new System.Drawing.Point(251, 641);
            this.bt_loadCustomerConfigFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_loadCustomerConfigFile.Name = "bt_loadCustomerConfigFile";
            this.bt_loadCustomerConfigFile.Size = new System.Drawing.Size(153, 57);
            this.bt_loadCustomerConfigFile.TabIndex = 6;
            this.bt_loadCustomerConfigFile.Text = "Load configuration";
            this.bt_loadCustomerConfigFile.UseVisualStyleBackColor = false;
            this.bt_loadCustomerConfigFile.Click += new System.EventHandler(this.bt_loadConfigFile_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_Cancel.CausesValidation = false;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.ForeColor = System.Drawing.Color.Blue;
            this.bt_Cancel.Location = new System.Drawing.Point(109, 731);
            this.bt_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(149, 52);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_saveCalibPoint
            // 
            this.bt_saveCalibPoint.BackColor = System.Drawing.Color.Silver;
            this.bt_saveCalibPoint.CausesValidation = false;
            this.bt_saveCalibPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_saveCalibPoint.ForeColor = System.Drawing.Color.Blue;
            this.bt_saveCalibPoint.Location = new System.Drawing.Point(93, 641);
            this.bt_saveCalibPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_saveCalibPoint.Name = "bt_saveCalibPoint";
            this.bt_saveCalibPoint.Size = new System.Drawing.Size(149, 57);
            this.bt_saveCalibPoint.TabIndex = 3;
            this.bt_saveCalibPoint.Text = "Save configuration";
            this.bt_saveCalibPoint.UseVisualStyleBackColor = false;
            this.bt_saveCalibPoint.Click += new System.EventHandler(this.bt_saveCalibPoint_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tb_tempSampleNum);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tb_tempMaxWaitTime);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbl_jigConfiguration);
            this.panel3.Controls.Add(this.tb_tempDeltaRange);
            this.panel3.Controls.Add(this.cmb_jigConfiguration);
            this.panel3.Controls.Add(this.tb_temSpampleInterval);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(992, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 344);
            this.panel3.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label11.Location = new System.Drawing.Point(8, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Sample num";
            // 
            // tb_tempSampleNum
            // 
            this.tb_tempSampleNum.Location = new System.Drawing.Point(211, 78);
            this.tb_tempSampleNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_tempSampleNum.Name = "tb_tempSampleNum";
            this.tb_tempSampleNum.Size = new System.Drawing.Size(100, 22);
            this.tb_tempSampleNum.TabIndex = 27;
            this.tb_tempSampleNum.Text = "10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Max wait time[minutes]";
            // 
            // tb_tempMaxWaitTime
            // 
            this.tb_tempMaxWaitTime.Location = new System.Drawing.Point(211, 228);
            this.tb_tempMaxWaitTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_tempMaxWaitTime.Name = "tb_tempMaxWaitTime";
            this.tb_tempMaxWaitTime.Size = new System.Drawing.Size(100, 22);
            this.tb_tempMaxWaitTime.TabIndex = 25;
            this.tb_tempMaxWaitTime.Text = "45";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Sample interval[sec]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Delta range[c]";
            // 
            // lbl_jigConfiguration
            // 
            this.lbl_jigConfiguration.AutoSize = true;
            this.lbl_jigConfiguration.Location = new System.Drawing.Point(8, 290);
            this.lbl_jigConfiguration.Name = "lbl_jigConfiguration";
            this.lbl_jigConfiguration.Size = new System.Drawing.Size(114, 17);
            this.lbl_jigConfiguration.TabIndex = 8;
            this.lbl_jigConfiguration.Text = "Jig Configuration";
            // 
            // tb_tempDeltaRange
            // 
            this.tb_tempDeltaRange.Location = new System.Drawing.Point(211, 180);
            this.tb_tempDeltaRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_tempDeltaRange.Name = "tb_tempDeltaRange";
            this.tb_tempDeltaRange.Size = new System.Drawing.Size(100, 22);
            this.tb_tempDeltaRange.TabIndex = 21;
            this.tb_tempDeltaRange.Text = "0.5";
            // 
            // cmb_jigConfiguration
            // 
            this.cmb_jigConfiguration.FormattingEnabled = true;
            this.cmb_jigConfiguration.Items.AddRange(new object[] {
            "8",
            "16"});
            this.cmb_jigConfiguration.Location = new System.Drawing.Point(211, 286);
            this.cmb_jigConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_jigConfiguration.Name = "cmb_jigConfiguration";
            this.cmb_jigConfiguration.Size = new System.Drawing.Size(121, 24);
            this.cmb_jigConfiguration.TabIndex = 5;
            this.cmb_jigConfiguration.Text = "16";
            // 
            // tb_temSpampleInterval
            // 
            this.tb_temSpampleInterval.Location = new System.Drawing.Point(211, 130);
            this.tb_temSpampleInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_temSpampleInterval.Name = "tb_temSpampleInterval";
            this.tb_temSpampleInterval.Size = new System.Drawing.Size(100, 22);
            this.tb_temSpampleInterval.TabIndex = 20;
            this.tb_temSpampleInterval.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(63, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Temperature stable settings";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_settingsPanel
            // 
            this.pnl_settingsPanel.Controls.Add(this.grpCapabilities);
            this.pnl_settingsPanel.Controls.Add(this.tb_batch);
            this.pnl_settingsPanel.Controls.Add(this.label7);
            this.pnl_settingsPanel.Controls.Add(this.tb_userName);
            this.pnl_settingsPanel.Controls.Add(this.label5);
            this.pnl_settingsPanel.Controls.Add(this.tb_stationId);
            this.pnl_settingsPanel.Controls.Add(this.label4);
            this.pnl_settingsPanel.Controls.Add(this.label2);
            this.pnl_settingsPanel.Controls.Add(this.tb_fwVersion);
            this.pnl_settingsPanel.Controls.Add(this.panel1);
            this.pnl_settingsPanel.Controls.Add(this.bt_loadCustomerConfigFile);
            this.pnl_settingsPanel.Controls.Add(this.panel3);
            this.pnl_settingsPanel.Controls.Add(this.bt_saveCalibPoint);
            this.pnl_settingsPanel.Location = new System.Drawing.Point(1, 1);
            this.pnl_settingsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_settingsPanel.Name = "pnl_settingsPanel";
            this.pnl_settingsPanel.Size = new System.Drawing.Size(1547, 711);
            this.pnl_settingsPanel.TabIndex = 8;
            // 
            // tb_batch
            // 
            this.tb_batch.Location = new System.Drawing.Point(1167, 473);
            this.tb_batch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_batch.Name = "tb_batch";
            this.tb_batch.Size = new System.Drawing.Size(100, 22);
            this.tb_batch.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(995, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Batch";
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(1167, 427);
            this.tb_userName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(100, 22);
            this.tb_userName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(995, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "User name";
            // 
            // tb_stationId
            // 
            this.tb_stationId.Location = new System.Drawing.Point(1167, 389);
            this.tb_stationId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_stationId.Name = "tb_stationId";
            this.tb_stationId.Size = new System.Drawing.Size(100, 22);
            this.tb_stationId.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(995, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Station id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(981, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = " * FW version";
            // 
            // tb_fwVersion
            // 
            this.tb_fwVersion.Location = new System.Drawing.Point(1167, 515);
            this.tb_fwVersion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_fwVersion.Name = "tb_fwVersion";
            this.tb_fwVersion.Size = new System.Drawing.Size(100, 22);
            this.tb_fwVersion.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgv_calibPressuresPointsTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_calibTempPointsTable);
            this.panel1.Location = new System.Drawing.Point(39, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 605);
            this.panel1.TabIndex = 2;
            // 
            // dgv_calibPressuresPointsTable
            // 
            this.dgv_calibPressuresPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibPressuresPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prs_Enable,
            this.txb_pressure});
            this.dgv_calibPressuresPointsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_calibPressuresPointsTable.Location = new System.Drawing.Point(471, 70);
            this.dgv_calibPressuresPointsTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_calibPressuresPointsTable.Name = "dgv_calibPressuresPointsTable";
            this.dgv_calibPressuresPointsTable.Size = new System.Drawing.Size(349, 512);
            this.dgv_calibPressuresPointsTable.TabIndex = 5;
            // 
            // prs_Enable
            // 
            this.prs_Enable.HeaderText = "Enable";
            this.prs_Enable.Name = "prs_Enable";
            this.prs_Enable.Width = 50;
            // 
            // txb_pressure
            // 
            this.txb_pressure.HeaderText = "Pressure[bar]";
            this.txb_pressure.Name = "txb_pressure";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(248, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = " pressures and temp";
            // 
            // dgv_calibTempPointsTable
            // 
            this.dgv_calibTempPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibTempPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Temperture,
            this.TempStartTime});
            this.dgv_calibTempPointsTable.Location = new System.Drawing.Point(44, 70);
            this.dgv_calibTempPointsTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_calibTempPointsTable.Name = "dgv_calibTempPointsTable";
            this.dgv_calibTempPointsTable.Size = new System.Drawing.Size(360, 505);
            this.dgv_calibTempPointsTable.TabIndex = 0;
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Enable.Width = 50;
            // 
            // Temperture
            // 
            this.Temperture.HeaderText = "Temperture[c]";
            this.Temperture.Name = "Temperture";
            // 
            // TempStartTime
            // 
            this.TempStartTime.HeaderText = "Temp skip start time[Min]";
            this.TempStartTime.Name = "TempStartTime";
            // 
            // grpCapabilities
            // 
            this.grpCapabilities.Controls.Add(this.chkDataLogger);
            this.grpCapabilities.Controls.Add(this.chkWash);
            this.grpCapabilities.Controls.Add(this.chkDPS);
            this.grpCapabilities.Controls.Add(this.chkDPT);
            this.grpCapabilities.Controls.Add(this.chkPT);
            this.grpCapabilities.Controls.Add(this.chkPS);
            this.grpCapabilities.Location = new System.Drawing.Point(992, 567);
            this.grpCapabilities.Margin = new System.Windows.Forms.Padding(4);
            this.grpCapabilities.Name = "grpCapabilities";
            this.grpCapabilities.Padding = new System.Windows.Forms.Padding(4);
            this.grpCapabilities.Size = new System.Drawing.Size(334, 100);
            this.grpCapabilities.TabIndex = 11;
            this.grpCapabilities.TabStop = false;
            this.grpCapabilities.Text = "Capabilities";
            // 
            // chkDataLogger
            // 
            this.chkDataLogger.AutoSize = true;
            this.chkDataLogger.Location = new System.Drawing.Point(181, 26);
            this.chkDataLogger.Margin = new System.Windows.Forms.Padding(4);
            this.chkDataLogger.Name = "chkDataLogger";
            this.chkDataLogger.Size = new System.Drawing.Size(109, 21);
            this.chkDataLogger.TabIndex = 8;
            this.chkDataLogger.Text = "Data Logger";
            this.chkDataLogger.UseVisualStyleBackColor = true;
            // 
            // chkWash
            // 
            this.chkWash.AutoSize = true;
            this.chkWash.Location = new System.Drawing.Point(181, 69);
            this.chkWash.Margin = new System.Windows.Forms.Padding(4);
            this.chkWash.Name = "chkWash";
            this.chkWash.Size = new System.Drawing.Size(131, 21);
            this.chkWash.TabIndex = 9;
            this.chkWash.Text = "Wash Controller";
            this.chkWash.UseVisualStyleBackColor = true;
            // 
            // chkDPS
            // 
            this.chkDPS.AutoSize = true;
            this.chkDPS.Location = new System.Drawing.Point(19, 26);
            this.chkDPS.Margin = new System.Windows.Forms.Padding(4);
            this.chkDPS.Name = "chkDPS";
            this.chkDPS.Size = new System.Drawing.Size(58, 21);
            this.chkDPS.TabIndex = 4;
            this.chkDPS.Text = "DPS";
            this.chkDPS.UseVisualStyleBackColor = true;
            // 
            // chkDPT
            // 
            this.chkDPT.AutoSize = true;
            this.chkDPT.Location = new System.Drawing.Point(19, 69);
            this.chkDPT.Margin = new System.Windows.Forms.Padding(4);
            this.chkDPT.Name = "chkDPT";
            this.chkDPT.Size = new System.Drawing.Size(58, 21);
            this.chkDPT.TabIndex = 5;
            this.chkDPT.Text = "DPT";
            this.chkDPT.UseVisualStyleBackColor = true;
            // 
            // chkPT
            // 
            this.chkPT.AutoSize = true;
            this.chkPT.Location = new System.Drawing.Point(108, 69);
            this.chkPT.Margin = new System.Windows.Forms.Padding(4);
            this.chkPT.Name = "chkPT";
            this.chkPT.Size = new System.Drawing.Size(48, 21);
            this.chkPT.TabIndex = 7;
            this.chkPT.Text = "PT";
            this.chkPT.UseVisualStyleBackColor = true;
            // 
            // chkPS
            // 
            this.chkPS.AutoSize = true;
            this.chkPS.Location = new System.Drawing.Point(108, 26);
            this.chkPS.Margin = new System.Windows.Forms.Padding(4);
            this.chkPS.Name = "chkPS";
            this.chkPS.Size = new System.Drawing.Size(48, 21);
            this.chkPS.TabIndex = 6;
            this.chkPS.Text = "PS";
            this.chkPS.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 837);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.pnl_settingsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnl_settingsPanel.ResumeLayout(false);
            this.pnl_settingsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).EndInit();
            this.grpCapabilities.ResumeLayout(false);
            this.grpCapabilities.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_saveCalibPoint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_tempDeltaRange;
        private System.Windows.Forms.TextBox tb_temSpampleInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_tempMaxWaitTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_tempSampleNum;
        private System.Windows.Forms.Button bt_loadCustomerConfigFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnl_settingsPanel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgv_calibPressuresPointsTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn prs_Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn txb_pressure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_calibTempPointsTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperture;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempStartTime;
        private System.Windows.Forms.Label lbl_jigConfiguration;
        private System.Windows.Forms.ComboBox cmb_jigConfiguration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_fwVersion;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_stationId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_batch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpCapabilities;
        private System.Windows.Forms.CheckBox chkDataLogger;
        private System.Windows.Forms.CheckBox chkWash;
        private System.Windows.Forms.CheckBox chkDPS;
        private System.Windows.Forms.CheckBox chkDPT;
        private System.Windows.Forms.CheckBox chkPT;
        private System.Windows.Forms.CheckBox chkPS;
    }
}