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
            this.dgv_calibTempPointsTable = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Temperture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_calibPressuresPointsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_saveCalibPoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
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
            this.bt_loadDefoult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_calibTempPointsTable
            // 
            this.dgv_calibTempPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibTempPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Temperture});
            this.dgv_calibTempPointsTable.Location = new System.Drawing.Point(15, 102);
            this.dgv_calibTempPointsTable.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_calibTempPointsTable.Name = "dgv_calibTempPointsTable";
            this.dgv_calibTempPointsTable.Size = new System.Drawing.Size(295, 391);
            this.dgv_calibTempPointsTable.TabIndex = 0;
            this.dgv_calibTempPointsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_calibPressuresPointsTable_CellEndEdit);
            this.dgv_calibTempPointsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_calibTempPointsTable_CellEndEdit);
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Temperture
            // 
            this.Temperture.HeaderText = "Temperture[c]";
            this.Temperture.Name = "Temperture";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_loadDefoult);
            this.panel1.Controls.Add(this.dgv_calibPressuresPointsTable);
            this.panel1.Controls.Add(this.bt_Cancel);
            this.panel1.Controls.Add(this.bt_saveCalibPoint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_calibTempPointsTable);
            this.panel1.Location = new System.Drawing.Point(31, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 615);
            this.panel1.TabIndex = 1;
            // 
            // dgv_calibPressuresPointsTable
            // 
            this.dgv_calibPressuresPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibPressuresPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.Pressure});
            this.dgv_calibPressuresPointsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_calibPressuresPointsTable.Location = new System.Drawing.Point(318, 102);
            this.dgv_calibPressuresPointsTable.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_calibPressuresPointsTable.Name = "dgv_calibPressuresPointsTable";
            this.dgv_calibPressuresPointsTable.Size = new System.Drawing.Size(346, 391);
            this.dgv_calibPressuresPointsTable.TabIndex = 5;
            this.dgv_calibPressuresPointsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_calibPressuresPointsTable_CellEndEdit);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Enable";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Pressure
            // 
            this.Pressure.HeaderText = "Pressure[bar]";
            this.Pressure.Name = "Pressure";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_Cancel.CausesValidation = false;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.ForeColor = System.Drawing.Color.Blue;
            this.bt_Cancel.Location = new System.Drawing.Point(424, 520);
            this.bt_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(153, 71);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_saveCalibPoint
            // 
            this.bt_saveCalibPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_saveCalibPoint.CausesValidation = false;
            this.bt_saveCalibPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_saveCalibPoint.ForeColor = System.Drawing.Color.Blue;
            this.bt_saveCalibPoint.Location = new System.Drawing.Point(45, 520);
            this.bt_saveCalibPoint.Margin = new System.Windows.Forms.Padding(4);
            this.bt_saveCalibPoint.Name = "bt_saveCalibPoint";
            this.bt_saveCalibPoint.Size = new System.Drawing.Size(152, 71);
            this.bt_saveCalibPoint.TabIndex = 3;
            this.bt_saveCalibPoint.Text = "Save configuration";
            this.bt_saveCalibPoint.UseVisualStyleBackColor = false;
            this.bt_saveCalibPoint.Click += new System.EventHandler(this.bt_saveCalibPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Calibration point: pressures and temp";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
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
            this.panel2.Location = new System.Drawing.Point(727, 42);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 615);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(38, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(519, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Enter Calibration point: pressures and temp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "PLC Com Port";
            // 
            // cmb_PLCComPort
            // 
            this.cmb_PLCComPort.FormattingEnabled = true;
            this.cmb_PLCComPort.Location = new System.Drawing.Point(318, 235);
            this.cmb_PLCComPort.Name = "cmb_PLCComPort";
            this.cmb_PLCComPort.Size = new System.Drawing.Size(121, 24);
            this.cmb_PLCComPort.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "DP Com Port";
            // 
            // cmb_DPComPort
            // 
            this.cmb_DPComPort.FormattingEnabled = true;
            this.cmb_DPComPort.Location = new System.Drawing.Point(318, 305);
            this.cmb_DPComPort.Name = "cmb_DPComPort";
            this.cmb_DPComPort.Size = new System.Drawing.Size(121, 24);
            this.cmb_DPComPort.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Multiplexer Com Port";
            // 
            // cmb_multiplexerComPort
            // 
            this.cmb_multiplexerComPort.FormattingEnabled = true;
            this.cmb_multiplexerComPort.Location = new System.Drawing.Point(318, 375);
            this.cmb_multiplexerComPort.Name = "cmb_multiplexerComPort";
            this.cmb_multiplexerComPort.Size = new System.Drawing.Size(121, 24);
            this.cmb_multiplexerComPort.TabIndex = 11;
            // 
            // lbl_tempControllerComPort
            // 
            this.lbl_tempControllerComPort.AutoSize = true;
            this.lbl_tempControllerComPort.Location = new System.Drawing.Point(109, 168);
            this.lbl_tempControllerComPort.Name = "lbl_tempControllerComPort";
            this.lbl_tempControllerComPort.Size = new System.Drawing.Size(171, 17);
            this.lbl_tempControllerComPort.TabIndex = 10;
            this.lbl_tempControllerComPort.Text = "Temp Controller Com Port";
            // 
            // lbl_jigConfiguration
            // 
            this.lbl_jigConfiguration.AutoSize = true;
            this.lbl_jigConfiguration.Location = new System.Drawing.Point(166, 102);
            this.lbl_jigConfiguration.Name = "lbl_jigConfiguration";
            this.lbl_jigConfiguration.Size = new System.Drawing.Size(114, 17);
            this.lbl_jigConfiguration.TabIndex = 8;
            this.lbl_jigConfiguration.Text = "Jig Configuration";
            // 
            // cmb_tempControllerComPort
            // 
            this.cmb_tempControllerComPort.FormattingEnabled = true;
            this.cmb_tempControllerComPort.Location = new System.Drawing.Point(318, 161);
            this.cmb_tempControllerComPort.Name = "cmb_tempControllerComPort";
            this.cmb_tempControllerComPort.Size = new System.Drawing.Size(121, 24);
            this.cmb_tempControllerComPort.TabIndex = 7;
            // 
            // cmb_jigConfiguration
            // 
            this.cmb_jigConfiguration.FormattingEnabled = true;
            this.cmb_jigConfiguration.Items.AddRange(new object[] {
            "8",
            "16"});
            this.cmb_jigConfiguration.Location = new System.Drawing.Point(318, 91);
            this.cmb_jigConfiguration.Name = "cmb_jigConfiguration";
            this.cmb_jigConfiguration.Size = new System.Drawing.Size(121, 24);
            this.cmb_jigConfiguration.TabIndex = 5;
            // 
            // bt_loadDefoult
            // 
            this.bt_loadDefoult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_loadDefoult.CausesValidation = false;
            this.bt_loadDefoult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_loadDefoult.ForeColor = System.Drawing.Color.Blue;
            this.bt_loadDefoult.Location = new System.Drawing.Point(235, 520);
            this.bt_loadDefoult.Margin = new System.Windows.Forms.Padding(4);
            this.bt_loadDefoult.Name = "bt_loadDefoult";
            this.bt_loadDefoult.Size = new System.Drawing.Size(154, 71);
            this.bt_loadDefoult.TabIndex = 6;
            this.bt_loadDefoult.Text = "Load defoult ";
            this.bt_loadDefoult.UseVisualStyleBackColor = false;
            this.bt_loadDefoult.Click += new System.EventHandler(this.bt_loadDefoult_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 878);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_calibTempPointsTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_saveCalibPoint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperture;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pressure;
        public System.Windows.Forms.DataGridView dgv_calibPressuresPointsTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button bt_loadDefoult;
    }
}