namespace DP_dashboard
{
    partial class Form1
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
            this.dgv_prressureTable = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A2D_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_readPressureTableFromPlc = new System.Windows.Forms.Button();
            this.bt_writePressureTableToPlc = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_plcControl = new System.Windows.Forms.Panel();
            this.bt_programDP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_connectToDp = new System.Windows.Forms.Button();
            this.cmb_dpDeviceNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_getDPinfo = new System.Windows.Forms.Button();
            this.bt_writePressursToDP = new System.Windows.Forms.Button();
            this.bt_exportPressursTableToCSVfile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bt_configuration = new System.Windows.Forms.Button();
            this.tb_dpSerialNumber = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).BeginInit();
            this.pnl_plcControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_prressureTable
            // 
            this.dgv_prressureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prressureTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.A2D_Value,
            this.Pressure});
            this.dgv_prressureTable.Location = new System.Drawing.Point(187, 23);
            this.dgv_prressureTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_prressureTable.Name = "dgv_prressureTable";
            this.dgv_prressureTable.RowTemplate.Height = 24;
            this.dgv_prressureTable.Size = new System.Drawing.Size(471, 377);
            this.dgv_prressureTable.TabIndex = 11;
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
            // bt_readPressureTableFromPlc
            // 
            this.bt_readPressureTableFromPlc.Location = new System.Drawing.Point(31, 124);
            this.bt_readPressureTableFromPlc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_readPressureTableFromPlc.Name = "bt_readPressureTableFromPlc";
            this.bt_readPressureTableFromPlc.Size = new System.Drawing.Size(132, 42);
            this.bt_readPressureTableFromPlc.TabIndex = 10;
            this.bt_readPressureTableFromPlc.Text = "Read Pressure Table From PLC";
            this.bt_readPressureTableFromPlc.UseVisualStyleBackColor = true;
            this.bt_readPressureTableFromPlc.Click += new System.EventHandler(this.bt_readPressureTableFromPlc_Click);
            // 
            // bt_writePressureTableToPlc
            // 
            this.bt_writePressureTableToPlc.Location = new System.Drawing.Point(31, 53);
            this.bt_writePressureTableToPlc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_writePressureTableToPlc.Name = "bt_writePressureTableToPlc";
            this.bt_writePressureTableToPlc.Size = new System.Drawing.Size(132, 42);
            this.bt_writePressureTableToPlc.TabIndex = 9;
            this.bt_writePressureTableToPlc.Text = "Write Pressure Table To PLC";
            this.bt_writePressureTableToPlc.UseVisualStyleBackColor = true;
            this.bt_writePressureTableToPlc.Click += new System.EventHandler(this.bt_writePressureTableToPlc_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(187, 423);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(471, 149);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_plcControl
            // 
            this.pnl_plcControl.Controls.Add(this.dgv_prressureTable);
            this.pnl_plcControl.Controls.Add(this.rtbLog);
            this.pnl_plcControl.Controls.Add(this.bt_readPressureTableFromPlc);
            this.pnl_plcControl.Controls.Add(this.bt_writePressureTableToPlc);
            this.pnl_plcControl.Location = new System.Drawing.Point(13, 15);
            this.pnl_plcControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_plcControl.Name = "pnl_plcControl";
            this.pnl_plcControl.Size = new System.Drawing.Size(688, 609);
            this.pnl_plcControl.TabIndex = 12;
            this.pnl_plcControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_plcControl_Paint);
            // 
            // bt_programDP
            // 
            this.bt_programDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_programDP.ForeColor = System.Drawing.Color.Black;
            this.bt_programDP.Location = new System.Drawing.Point(400, 102);
            this.bt_programDP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_programDP.Name = "bt_programDP";
            this.bt_programDP.Size = new System.Drawing.Size(136, 97);
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
            this.panel1.Location = new System.Drawing.Point(1017, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 240);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_disconnect.ForeColor = System.Drawing.Color.Black;
            this.bt_disconnect.Location = new System.Drawing.Point(29, 155);
            this.bt_disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(136, 66);
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
            this.label2.Location = new System.Drawing.Point(365, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DP NO";
            // 
            // bt_connectToDp
            // 
            this.bt_connectToDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_connectToDp.ForeColor = System.Drawing.Color.Black;
            this.bt_connectToDp.Location = new System.Drawing.Point(27, 70);
            this.bt_connectToDp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_connectToDp.Name = "bt_connectToDp";
            this.bt_connectToDp.Size = new System.Drawing.Size(136, 66);
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
            this.cmb_dpDeviceNumber.Location = new System.Drawing.Point(317, 166);
            this.cmb_dpDeviceNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_dpDeviceNumber.Name = "cmb_dpDeviceNumber";
            this.cmb_dpDeviceNumber.Size = new System.Drawing.Size(160, 24);
            this.cmb_dpDeviceNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(213, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.panel2.Location = new System.Drawing.Point(1017, 288);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 235);
            this.panel2.TabIndex = 14;
            // 
            // bt_getDPinfo
            // 
            this.bt_getDPinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_getDPinfo.ForeColor = System.Drawing.Color.Black;
            this.bt_getDPinfo.Location = new System.Drawing.Point(212, 102);
            this.bt_getDPinfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_getDPinfo.Name = "bt_getDPinfo";
            this.bt_getDPinfo.Size = new System.Drawing.Size(136, 97);
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
            this.bt_writePressursToDP.Location = new System.Drawing.Point(29, 102);
            this.bt_writePressursToDP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_writePressursToDP.Name = "bt_writePressursToDP";
            this.bt_writePressursToDP.Size = new System.Drawing.Size(136, 97);
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
            this.bt_exportPressursTableToCSVfile.Location = new System.Drawing.Point(563, 102);
            this.bt_exportPressursTableToCSVfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_exportPressursTableToCSVfile.Name = "bt_exportPressursTableToCSVfile";
            this.bt_exportPressursTableToCSVfile.Size = new System.Drawing.Size(136, 97);
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
            this.label4.Location = new System.Drawing.Point(327, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "DP control";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // bt_configuration
            // 
            this.bt_configuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_configuration.ForeColor = System.Drawing.Color.Black;
            this.bt_configuration.Location = new System.Drawing.Point(1017, 566);
            this.bt_configuration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_configuration.Name = "bt_configuration";
            this.bt_configuration.Size = new System.Drawing.Size(165, 58);
            this.bt_configuration.TabIndex = 16;
            this.bt_configuration.TabStop = false;
            this.bt_configuration.Text = "Configuration";
            this.bt_configuration.UseVisualStyleBackColor = false;
            this.bt_configuration.Click += new System.EventHandler(this.bt_configuration_Click);
            // 
            // tb_dpSerialNumber
            // 
            this.tb_dpSerialNumber.Location = new System.Drawing.Point(29, 42);
            this.tb_dpSerialNumber.Name = "tb_dpSerialNumber";
            this.tb_dpSerialNumber.Size = new System.Drawing.Size(136, 22);
            this.tb_dpSerialNumber.TabIndex = 14;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(67, 4);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "DP serial no";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 657);
            this.Controls.Add(this.bt_configuration);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_plcControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).EndInit();
            this.pnl_plcControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_prressureTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn A2D_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pressure;
        private System.Windows.Forms.Button bt_readPressureTableFromPlc;
        private System.Windows.Forms.Button bt_writePressureTableToPlc;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnl_plcControl;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button bt_configuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_dpSerialNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

