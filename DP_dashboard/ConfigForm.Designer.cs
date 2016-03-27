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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_saveCalibPoint = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Temperture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_calibPressuresPointsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_calibTempPointsTable
            // 
            this.dgv_calibTempPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibTempPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Temperture});
            this.dgv_calibTempPointsTable.Location = new System.Drawing.Point(20, 83);
            this.dgv_calibTempPointsTable.Name = "dgv_calibTempPointsTable";
            this.dgv_calibTempPointsTable.Size = new System.Drawing.Size(239, 197);
            this.dgv_calibTempPointsTable.TabIndex = 0;
            this.dgv_calibTempPointsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_calibPressuresPointsTable);
            this.panel1.Controls.Add(this.bt_Cancel);
            this.panel1.Controls.Add(this.bt_saveCalibPoint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_calibTempPointsTable);
            this.panel1.Location = new System.Drawing.Point(54, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 543);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Calibration point: pressures & temp";
            // 
            // bt_saveCalibPoint
            // 
            this.bt_saveCalibPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bt_saveCalibPoint.CausesValidation = false;
            this.bt_saveCalibPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_saveCalibPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_saveCalibPoint.Location = new System.Drawing.Point(59, 494);
            this.bt_saveCalibPoint.Name = "bt_saveCalibPoint";
            this.bt_saveCalibPoint.Size = new System.Drawing.Size(176, 36);
            this.bt_saveCalibPoint.TabIndex = 3;
            this.bt_saveCalibPoint.Text = "Save calib point";
            this.bt_saveCalibPoint.UseVisualStyleBackColor = false;
            this.bt_saveCalibPoint.Click += new System.EventHandler(this.bt_saveCalibPoint_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bt_Cancel.CausesValidation = false;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Cancel.Location = new System.Drawing.Point(373, 494);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(176, 36);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
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
            // dgv_calibPressuresPointsTable
            // 
            this.dgv_calibPressuresPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_calibPressuresPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.Pressure});
            this.dgv_calibPressuresPointsTable.Location = new System.Drawing.Point(350, 83);
            this.dgv_calibPressuresPointsTable.Name = "dgv_calibPressuresPointsTable";
            this.dgv_calibPressuresPointsTable.Size = new System.Drawing.Size(239, 197);
            this.dgv_calibPressuresPointsTable.TabIndex = 5;
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
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 713);
            this.Controls.Add(this.panel1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibTempPointsTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_calibPressuresPointsTable)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_calibPressuresPointsTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pressure;
    }
}