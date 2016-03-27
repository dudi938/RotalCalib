using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DpCommunication;

namespace DP_dashboard
{
    public partial class ConfigForm : Form
    {
        public static ConfigForm currentForm;
        ClassDpCommunication DpProtocolInstanse;


        public ConfigForm(ClassDpCommunication dpProtocolInstanse)
        {
            currentForm = this;
            InitializeComponent();
            DpProtocolInstanse = dpProtocolInstanse;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {            
            this.Hide();
            Form1.currentForm.Show();      
        }



        private void bt_saveCalibPoint_Click(object sender, EventArgs e)
        {
            DpProtocolInstanse.DPPressuresTable.Clear();

            MessageBox.Show("You go to delete the old configuration points");
            for (int i = 0; i < dgv_calibTempPointsTable.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell EnabelTempCell = new DataGridViewCheckBoxCell();
                EnabelTempCell = (DataGridViewCheckBoxCell)dgv_calibTempPointsTable.Rows[i].Cells[0];

                if (EnabelTempCell.Value != null)
                {
                    if ((bool)(dgv_calibTempPointsTable.Rows[i].Cells[0].Value))
                    {

                        DpCalibPointsInTemperature NewTempLine = new DpCalibPointsInTemperature();

                        for (int j = 0; j < dgv_calibPressuresPointsTable.Rows.Count; j++)
                        {

                            DataGridViewCheckBoxCell EnabelPressureCell = new DataGridViewCheckBoxCell();
                            EnabelPressureCell = (DataGridViewCheckBoxCell)dgv_calibPressuresPointsTable.Rows[j].Cells[0];

                            if (EnabelPressureCell.Value != null)
                            {
                                if (dgv_calibPressuresPointsTable.Rows[j].Cells[1].Value != null && dgv_calibTempPointsTable.Rows[i].Cells[1].Value != null)
                                {
                                    if ((bool)(dgv_calibPressuresPointsTable.Rows[j].Cells[0].Value))
                                    {

                                            float pressureValue = float.Parse(dgv_calibPressuresPointsTable.Rows[j].Cells[1].Value.ToString());
                                            float TempValue = float.Parse(dgv_calibTempPointsTable.Rows[i].Cells[1].Value.ToString());
                                            DpCalibPoint NewCalibPoint = new DpCalibPoint(pressureValue, TempValue);

                                            NewTempLine.oneTempLine.Add(NewCalibPoint);
                                     }
                                }
                             }
                        }
                        DpProtocolInstanse.DPPressuresTable.Add(NewTempLine);
                    }
                }
            }

            this.Hide();
            Form1.currentForm.Show();
        }





    }
}

