namespace CalibrationPLCControlTester
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_writePressureTableToPlc = new System.Windows.Forms.Button();
            this.bt_readPressureTableFromPlc = new System.Windows.Forms.Button();
            this.dgv_prressureTable = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A2D_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(136, 317);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(354, 122);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_writePressureTableToPlc
            // 
            this.bt_writePressureTableToPlc.Location = new System.Drawing.Point(19, 24);
            this.bt_writePressureTableToPlc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_writePressureTableToPlc.Name = "bt_writePressureTableToPlc";
            this.bt_writePressureTableToPlc.Size = new System.Drawing.Size(99, 34);
            this.bt_writePressureTableToPlc.TabIndex = 5;
            this.bt_writePressureTableToPlc.Text = "Write Pressure Table To PLC";
            this.bt_writePressureTableToPlc.UseVisualStyleBackColor = true;
            this.bt_writePressureTableToPlc.Click += new System.EventHandler(this.writePressureTableToPlc_Click);
            // 
            // bt_readPressureTableFromPlc
            // 
            this.bt_readPressureTableFromPlc.Location = new System.Drawing.Point(19, 82);
            this.bt_readPressureTableFromPlc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_readPressureTableFromPlc.Name = "bt_readPressureTableFromPlc";
            this.bt_readPressureTableFromPlc.Size = new System.Drawing.Size(99, 34);
            this.bt_readPressureTableFromPlc.TabIndex = 6;
            this.bt_readPressureTableFromPlc.Text = "Read Pressure Table From PLC";
            this.bt_readPressureTableFromPlc.UseVisualStyleBackColor = true;
            this.bt_readPressureTableFromPlc.Click += new System.EventHandler(this.bt_readPressureTableFromPlc_Click);
            // 
            // dgv_prressureTable
            // 
            this.dgv_prressureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prressureTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.A2D_Value,
            this.Pressure});
            this.dgv_prressureTable.Location = new System.Drawing.Point(136, 6);
            this.dgv_prressureTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_prressureTable.Name = "dgv_prressureTable";
            this.dgv_prressureTable.RowTemplate.Height = 24;
            this.dgv_prressureTable.Size = new System.Drawing.Size(353, 306);
            this.dgv_prressureTable.TabIndex = 7;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 448);
            this.Controls.Add(this.dgv_prressureTable);
            this.Controls.Add(this.bt_readPressureTableFromPlc);
            this.Controls.Add(this.bt_writePressureTableToPlc);
            this.Controls.Add(this.rtbLog);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prressureTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_writePressureTableToPlc;
        private System.Windows.Forms.Button bt_readPressureTableFromPlc;
        private System.Windows.Forms.DataGridView dgv_prressureTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn A2D_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pressure;
    }
}

