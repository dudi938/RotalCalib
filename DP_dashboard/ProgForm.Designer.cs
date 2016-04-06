namespace DP_dashboard
{
    partial class ProgForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_dpTableInfo = new System.Windows.Forms.DataGridView();
            this.col_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dpExist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_startProgram = new System.Windows.Forms.Button();
            this.bt_stopProgram = new System.Windows.Forms.Button();
            this.bt_back = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dpTableInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(488, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programing DP Wizard";
            // 
            // dgv_dpTableInfo
            // 
            this.dgv_dpTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dpTableInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_number,
            this.col_dpExist,
            this.col_serialNumber,
            this.col_name});
            this.dgv_dpTableInfo.Location = new System.Drawing.Point(47, 121);
            this.dgv_dpTableInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_dpTableInfo.Name = "dgv_dpTableInfo";
            this.dgv_dpTableInfo.Size = new System.Drawing.Size(431, 542);
            this.dgv_dpTableInfo.TabIndex = 1;
            // 
            // col_number
            // 
            this.col_number.HeaderText = "NO";
            this.col_number.Name = "col_number";
            this.col_number.ReadOnly = true;
            this.col_number.Width = 40;
            // 
            // col_dpExist
            // 
            this.col_dpExist.HeaderText = "Exist";
            this.col_dpExist.Name = "col_dpExist";
            this.col_dpExist.ReadOnly = true;
            this.col_dpExist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_dpExist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_dpExist.Width = 40;
            // 
            // col_serialNumber
            // 
            this.col_serialNumber.HeaderText = "Serial number";
            this.col_serialNumber.Name = "col_serialNumber";
            this.col_serialNumber.ReadOnly = true;
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // bt_startProgram
            // 
            this.bt_startProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_startProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.bt_startProgram.ForeColor = System.Drawing.Color.Blue;
            this.bt_startProgram.Location = new System.Drawing.Point(677, 208);
            this.bt_startProgram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_startProgram.Name = "bt_startProgram";
            this.bt_startProgram.Size = new System.Drawing.Size(559, 122);
            this.bt_startProgram.TabIndex = 2;
            this.bt_startProgram.Text = "Start Program";
            this.bt_startProgram.UseVisualStyleBackColor = false;
            this.bt_startProgram.Click += new System.EventHandler(this.bt_startProgram_Click);
            // 
            // bt_stopProgram
            // 
            this.bt_stopProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_stopProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.bt_stopProgram.ForeColor = System.Drawing.Color.Blue;
            this.bt_stopProgram.Location = new System.Drawing.Point(677, 377);
            this.bt_stopProgram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_stopProgram.Name = "bt_stopProgram";
            this.bt_stopProgram.Size = new System.Drawing.Size(559, 122);
            this.bt_stopProgram.TabIndex = 3;
            this.bt_stopProgram.Text = "Stop program";
            this.bt_stopProgram.UseVisualStyleBackColor = false;
            this.bt_stopProgram.Click += new System.EventHandler(this.bt_stopProgram_Click);
            // 
            // bt_back
            // 
            this.bt_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_back.ForeColor = System.Drawing.Color.Blue;
            this.bt_back.Location = new System.Drawing.Point(677, 546);
            this.bt_back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(559, 122);
            this.bt_back.TabIndex = 4;
            this.bt_back.Text = "Back";
            this.bt_back.UseVisualStyleBackColor = false;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(117, 709);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(0, 17);
            this.lbl_info.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ProgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 742);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.bt_back);
            this.Controls.Add(this.bt_stopProgram);
            this.Controls.Add(this.bt_startProgram);
            this.Controls.Add(this.dgv_dpTableInfo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProgForm";
            this.Text = "ProgForm";
            this.Load += new System.EventHandler(this.ProgForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dpTableInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_dpTableInfo;
        private System.Windows.Forms.Button bt_startProgram;
        private System.Windows.Forms.Button bt_stopProgram;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_number;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_dpExist;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_serialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}