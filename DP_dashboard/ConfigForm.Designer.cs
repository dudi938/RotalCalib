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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_PLCComPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DPComPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_multiplexerComPort = new System.Windows.Forms.ComboBox();
            this.lbl_tempControllerComPort = new System.Windows.Forms.Label();
            this.lbl_jigConfiguration = new System.Windows.Forms.Label();
            this.cmb_tempControllerComPort = new System.Windows.Forms.ComboBox();
            this.cmb_jigConfiguration = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_tempSampleNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_tempMaxWaitTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_tempDeltaRange = new System.Windows.Forms.TextBox();
            this.tb_temSpampleInterval = new System.Windows.Forms.TextBox();
            this.tb_tempSkipTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_settingsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_calibPressuresPointsTable = new System.Windows.Forms.DataGridView();
            this.prs_Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txb_pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TempStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv_calibTempPointsTable = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_settingsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_loadCustomerConfigFile
            // 
            this.bt_loadCustomerConfigFile.AutoEllipsis = true;
            this.bt_loadCustomerConfigFile.BackColor = System.Drawing.Color.Silver;
            this.bt_loadCustomerConfigFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bt_loadCustomerConfigFile.ForeColor = System.Drawing.Color.Blue;
            this.bt_loadCustomerConfigFile.Location = new System.Drawing.Point(257, 546);
            this.bt_loadCustomerConfigFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_loadCustomerConfigFile.Name = "bt_loadCustomerConfigFile";
            this.bt_loadCustomerConfigFile.Size = new System.Drawing.Size(177, 58);
            this.bt_loadCustomerConfigFile.TabIndex = 6;
            this.bt_loadCustomerConfigFile.Text = "Load configuration";
            this.bt_loadCustomerConfigFile.UseVisualStyleBackColor = false;
            this.bt_loadCustomerConfigFile.Click += new System.EventHandler(this.bt_loadConfigFile_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_Cancel.CausesValidation = false;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.ForeColor = System.Drawing.Color.Blue;
            this.bt_Cancel.Location = new System.Drawing.Point(76, 699);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(162, 58);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_saveCalibPoint
            // 
            this.bt_saveCalibPoint.BackColor = System.Drawing.Color.Silver;
            this.bt_saveCalibPoint.CausesValidation = false;
            this.bt_saveCalibPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_saveCalibPoint.ForeColor = System.Drawing.Color.Blue;
            this.bt_saveCalibPoint.Location = new System.Drawing.Point(64, 546);
            this.bt_saveCalibPoint.Name = "bt_saveCalibPoint";
            this.bt_saveCalibPoint.Size = new System.Drawing.Size(162, 58);
            this.bt_saveCalibPoint.TabIndex = 3;
            this.bt_saveCalibPoint.Text = "Save configuration";
            this.bt_saveCalibPoint.UseVisualStyleBackColor = false;
            this.bt_saveCalibPoint.Click += new System.EventHandler(this.bt_saveCalibPoint_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmb_PLCComPort);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_DPComPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmb_multiplexerComPort);
            this.panel2.Controls.Add(this.lbl_tempControllerComPort);
            this.panel2.Controls.Add(this.lbl_jigConfiguration);
            this.panel2.Controls.Add(this.cmb_tempControllerComPort);
            this.panel2.Controls.Add(this.cmb_jigConfiguration);
            this.panel2.Location = new System.Drawing.Point(922, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 179);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "PLC Com Port";
            // 
            // cmb_PLCComPort
            // 
            this.cmb_PLCComPort.FormattingEnabled = true;
            this.cmb_PLCComPort.Location = new System.Drawing.Point(163, 68);
            this.cmb_PLCComPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_PLCComPort.Name = "cmb_PLCComPort";
            this.cmb_PLCComPort.Size = new System.Drawing.Size(92, 21);
            this.cmb_PLCComPort.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "DP Com Port";
            // 
            // cmb_DPComPort
            // 
            this.cmb_DPComPort.FormattingEnabled = true;
            this.cmb_DPComPort.Location = new System.Drawing.Point(163, 103);
            this.cmb_DPComPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_DPComPort.Name = "cmb_DPComPort";
            this.cmb_DPComPort.Size = new System.Drawing.Size(92, 21);
            this.cmb_DPComPort.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Multiplexer Com Port";
            // 
            // cmb_multiplexerComPort
            // 
            this.cmb_multiplexerComPort.FormattingEnabled = true;
            this.cmb_multiplexerComPort.Location = new System.Drawing.Point(163, 138);
            this.cmb_multiplexerComPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_multiplexerComPort.Name = "cmb_multiplexerComPort";
            this.cmb_multiplexerComPort.Size = new System.Drawing.Size(92, 21);
            this.cmb_multiplexerComPort.TabIndex = 11;
            // 
            // lbl_tempControllerComPort
            // 
            this.lbl_tempControllerComPort.AutoSize = true;
            this.lbl_tempControllerComPort.Location = new System.Drawing.Point(6, 42);
            this.lbl_tempControllerComPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tempControllerComPort.Name = "lbl_tempControllerComPort";
            this.lbl_tempControllerComPort.Size = new System.Drawing.Size(149, 15);
            this.lbl_tempControllerComPort.TabIndex = 10;
            this.lbl_tempControllerComPort.Text = "Temp Controller Com Port";
            // 
            // lbl_jigConfiguration
            // 
            this.lbl_jigConfiguration.AutoSize = true;
            this.lbl_jigConfiguration.Location = new System.Drawing.Point(49, 13);
            this.lbl_jigConfiguration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_jigConfiguration.Name = "lbl_jigConfiguration";
            this.lbl_jigConfiguration.Size = new System.Drawing.Size(99, 15);
            this.lbl_jigConfiguration.TabIndex = 8;
            this.lbl_jigConfiguration.Text = "Jig Configuration";
            // 
            // cmb_tempControllerComPort
            // 
            this.cmb_tempControllerComPort.FormattingEnabled = true;
            this.cmb_tempControllerComPort.Location = new System.Drawing.Point(163, 37);
            this.cmb_tempControllerComPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_tempControllerComPort.Name = "cmb_tempControllerComPort";
            this.cmb_tempControllerComPort.Size = new System.Drawing.Size(92, 21);
            this.cmb_tempControllerComPort.TabIndex = 7;
            // 
            // cmb_jigConfiguration
            // 
            this.cmb_jigConfiguration.FormattingEnabled = true;
            this.cmb_jigConfiguration.Items.AddRange(new object[] {
            "8",
            "16"});
            this.cmb_jigConfiguration.Location = new System.Drawing.Point(163, 4);
            this.cmb_jigConfiguration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_jigConfiguration.Name = "cmb_jigConfiguration";
            this.cmb_jigConfiguration.Size = new System.Drawing.Size(92, 21);
            this.cmb_jigConfiguration.TabIndex = 5;
            this.cmb_jigConfiguration.Text = "16";
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
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.tb_tempDeltaRange);
            this.panel3.Controls.Add(this.tb_temSpampleInterval);
            this.panel3.Controls.Add(this.tb_tempSkipTime);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(749, 308);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 214);
            this.panel3.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label11.Location = new System.Drawing.Point(293, 63);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Sample num";
            // 
            // tb_tempSampleNum
            // 
            this.tb_tempSampleNum.Location = new System.Drawing.Point(413, 60);
            this.tb_tempSampleNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_tempSampleNum.Name = "tb_tempSampleNum";
            this.tb_tempSampleNum.Size = new System.Drawing.Size(76, 20);
            this.tb_tempSampleNum.TabIndex = 27;
            this.tb_tempSampleNum.Text = "10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Max wait time[minutes]";
            // 
            // tb_tempMaxWaitTime
            // 
            this.tb_tempMaxWaitTime.Location = new System.Drawing.Point(210, 184);
            this.tb_tempMaxWaitTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_tempMaxWaitTime.Name = "tb_tempMaxWaitTime";
            this.tb_tempMaxWaitTime.Size = new System.Drawing.Size(76, 20);
            this.tb_tempMaxWaitTime.TabIndex = 25;
            this.tb_tempMaxWaitTime.Text = "45";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 105);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Sample interval[sec]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Delta range[c]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Skip time[minutes]";
            this.label7.Visible = false;
            // 
            // tb_tempDeltaRange
            // 
            this.tb_tempDeltaRange.Location = new System.Drawing.Point(210, 145);
            this.tb_tempDeltaRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_tempDeltaRange.Name = "tb_tempDeltaRange";
            this.tb_tempDeltaRange.Size = new System.Drawing.Size(76, 20);
            this.tb_tempDeltaRange.TabIndex = 21;
            this.tb_tempDeltaRange.Text = "0.5";
            // 
            // tb_temSpampleInterval
            // 
            this.tb_temSpampleInterval.Location = new System.Drawing.Point(210, 104);
            this.tb_temSpampleInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_temSpampleInterval.Name = "tb_temSpampleInterval";
            this.tb_temSpampleInterval.Size = new System.Drawing.Size(76, 20);
            this.tb_temSpampleInterval.TabIndex = 20;
            this.tb_temSpampleInterval.Text = "1";
            // 
            // tb_tempSkipTime
            // 
            this.tb_tempSkipTime.Location = new System.Drawing.Point(210, 60);
            this.tb_tempSkipTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_tempSkipTime.Name = "tb_tempSkipTime";
            this.tb_tempSkipTime.Size = new System.Drawing.Size(76, 20);
            this.tb_tempSkipTime.TabIndex = 19;
            this.tb_tempSkipTime.Text = "5";
            this.tb_tempSkipTime.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(5, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Temperature stable settings";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_settingsPanel
            // 
            this.pnl_settingsPanel.Controls.Add(this.panel1);
            this.pnl_settingsPanel.Controls.Add(this.panel2);
            this.pnl_settingsPanel.Controls.Add(this.bt_loadCustomerConfigFile);
            this.pnl_settingsPanel.Controls.Add(this.panel3);
            this.pnl_settingsPanel.Controls.Add(this.bt_saveCalibPoint);
            this.pnl_settingsPanel.Location = new System.Drawing.Point(12, 12);
            this.pnl_settingsPanel.Name = "pnl_settingsPanel";
            this.pnl_settingsPanel.Size = new System.Drawing.Size(1446, 641);
            this.pnl_settingsPanel.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgv_calibPressuresPointsTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_calibTempPointsTable);
            this.panel1.Location = new System.Drawing.Point(29, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 498);
            this.panel1.TabIndex = 2;
            // 
            // dgv_calibPressuresPointsTable
            // 
            this.dgv_calibPressuresPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibPressuresPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prs_Enable,
            this.txb_pressure});
            this.dgv_calibPressuresPointsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_calibPressuresPointsTable.Location = new System.Drawing.Point(353, 57);
            this.dgv_calibPressuresPointsTable.Name = "dgv_calibPressuresPointsTable";
            this.dgv_calibPressuresPointsTable.Size = new System.Drawing.Size(262, 416);
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
            this.label1.Location = new System.Drawing.Point(186, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = " pressures and temp";
            // 
            // TempStartTime
            // 
            this.TempStartTime.HeaderText = "Temp skip start time[Min]";
            this.TempStartTime.Name = "TempStartTime";
            // 
            // Temperture
            // 
            this.Temperture.HeaderText = "Temperture[c]";
            this.Temperture.Name = "Temperture";
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Enable.Width = 50;
            // 
            // dgv_calibTempPointsTable
            // 
            this.dgv_calibTempPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibTempPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Temperture,
            this.TempStartTime});
            this.dgv_calibTempPointsTable.Location = new System.Drawing.Point(33, 57);
            this.dgv_calibTempPointsTable.Name = "dgv_calibTempPointsTable";
            this.dgv_calibTempPointsTable.Size = new System.Drawing.Size(270, 410);
            this.dgv_calibTempPointsTable.TabIndex = 0;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 824);
            this.Controls.Add(this.pnl_settingsPanel);
            this.Controls.Add(this.bt_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnl_settingsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_saveCalibPoint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_PLCComPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_DPComPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_multiplexerComPort;
        private System.Windows.Forms.Label lbl_tempControllerComPort;
        private System.Windows.Forms.Label lbl_jigConfiguration;
        private System.Windows.Forms.ComboBox cmb_tempControllerComPort;
        private System.Windows.Forms.ComboBox cmb_jigConfiguration;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_tempDeltaRange;
        private System.Windows.Forms.TextBox tb_temSpampleInterval;
        private System.Windows.Forms.TextBox tb_tempSkipTime;
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
    }
}