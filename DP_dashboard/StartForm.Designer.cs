namespace DP_dashboard
{
    partial class StartForm
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
            this.dgv_registerDpPacket = new System.Windows.Forms.DataGridView();
            this.col_dpNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_exist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_registerDpPacket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_registerDpPacket
            // 
            this.dgv_registerDpPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_registerDpPacket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_dpNumber,
            this.col_exist,
            this.col_SerialNumber,
            this.col_dpName});
            this.dgv_registerDpPacket.GridColor = System.Drawing.Color.LightGray;
            this.dgv_registerDpPacket.Location = new System.Drawing.Point(74, 93);
            this.dgv_registerDpPacket.Name = "dgv_registerDpPacket";
            this.dgv_registerDpPacket.Size = new System.Drawing.Size(339, 412);
            this.dgv_registerDpPacket.TabIndex = 0;
            // 
            // col_dpNumber
            // 
            this.col_dpNumber.HeaderText = "NO";
            this.col_dpNumber.Name = "col_dpNumber";
            this.col_dpNumber.ReadOnly = true;
            this.col_dpNumber.Width = 40;
            // 
            // col_exist
            // 
            this.col_exist.HeaderText = "Exist";
            this.col_exist.Name = "col_exist";
            this.col_exist.Width = 40;
            // 
            // col_SerialNumber
            // 
            this.col_SerialNumber.HeaderText = "S/N";
            this.col_SerialNumber.Name = "col_SerialNumber";
            this.col_SerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_SerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_dpName
            // 
            this.col_dpName.HeaderText = "Name";
            this.col_dpName.Name = "col_dpName";
            this.col_dpName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_dpName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add the extant DP devices ";
            // 
            // bt_next
            // 
            this.bt_next.BackColor = System.Drawing.Color.Silver;
            this.bt_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_next.Location = new System.Drawing.Point(74, 533);
            this.bt_next.Name = "bt_next";
            this.bt_next.Size = new System.Drawing.Size(339, 76);
            this.bt_next.TabIndex = 2;
            this.bt_next.Text = "Next";
            this.bt_next.UseVisualStyleBackColor = false;
            this.bt_next.Click += new System.EventHandler(this.bt_next_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 730);
            this.Controls.Add(this.bt_next);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_registerDpPacket);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_registerDpPacket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_registerDpPacket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_next;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dpNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dpName;
    }
}