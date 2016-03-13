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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_connectToDp = new System.Windows.Forms.Button();
            this.cmb_dpDeviceNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).BeginInit();
            this.pnl_plcControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_prressureTable
            // 
            this.dgv_prressureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prressureTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.A2D_Value,
            this.Pressure});
            this.dgv_prressureTable.Location = new System.Drawing.Point(140, 19);
            this.dgv_prressureTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_prressureTable.Name = "dgv_prressureTable";
            this.dgv_prressureTable.RowTemplate.Height = 24;
            this.dgv_prressureTable.Size = new System.Drawing.Size(353, 306);
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
            this.bt_readPressureTableFromPlc.Location = new System.Drawing.Point(23, 101);
            this.bt_readPressureTableFromPlc.Margin = new System.Windows.Forms.Padding(2);
            this.bt_readPressureTableFromPlc.Name = "bt_readPressureTableFromPlc";
            this.bt_readPressureTableFromPlc.Size = new System.Drawing.Size(99, 34);
            this.bt_readPressureTableFromPlc.TabIndex = 10;
            this.bt_readPressureTableFromPlc.Text = "Read Pressure Table From PLC";
            this.bt_readPressureTableFromPlc.UseVisualStyleBackColor = true;
            this.bt_readPressureTableFromPlc.Click += new System.EventHandler(this.bt_readPressureTableFromPlc_Click);
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
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(140, 344);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(354, 122);
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
            this.pnl_plcControl.Controls.Add(this.button1);
            this.pnl_plcControl.Controls.Add(this.dgv_prressureTable);
            this.pnl_plcControl.Controls.Add(this.rtbLog);
            this.pnl_plcControl.Controls.Add(this.bt_readPressureTableFromPlc);
            this.pnl_plcControl.Controls.Add(this.bt_writePressureTableToPlc);
            this.pnl_plcControl.Location = new System.Drawing.Point(12, 12);
            this.pnl_plcControl.Name = "pnl_plcControl";
            this.pnl_plcControl.Size = new System.Drawing.Size(516, 495);
            this.pnl_plcControl.TabIndex = 12;
            this.pnl_plcControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_plcControl_Paint);
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
            this.panel1.Location = new System.Drawing.Point(590, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 261);
            this.panel1.TabIndex = 13;
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_disconnect.ForeColor = System.Drawing.Color.Black;
            this.bt_disconnect.Location = new System.Drawing.Point(20, 182);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(102, 54);
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
            this.label2.Location = new System.Drawing.Point(192, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "DP NO";
            // 
            // bt_connectToDp
            // 
            this.bt_connectToDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_connectToDp.ForeColor = System.Drawing.Color.Black;
            this.bt_connectToDp.Location = new System.Drawing.Point(20, 101);
            this.bt_connectToDp.Name = "bt_connectToDp";
            this.bt_connectToDp.Size = new System.Drawing.Size(102, 54);
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
            this.cmb_dpDeviceNumber.Location = new System.Drawing.Point(157, 128);
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
            this.label1.Location = new System.Drawing.Point(34, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "DP connection control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_plcControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).EndInit();
            this.pnl_plcControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
    }
}

