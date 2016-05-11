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
        public static CalibForm calibForm;
        ClassDpCommunication DpProtocolInstanse;


        public ConfigForm(ClassDpCommunication dpProtocolInstanse, CalibForm calibFormcaller)
        {
            calibForm = calibFormcaller;
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
            calibForm.Show();
        }



        private void bt_saveCalibPoint_Click(object sender, EventArgs e)
        {
            calibForm.classCalibrationInfo.TempUnderTestList.Clear();
            calibForm.classCalibrationInfo.PressureUnderTestList.Clear();

            MessageBox.Show("You go to delete the old configuration points");

            //save temp points
            for (int i = 0; i < dgv_calibTempPointsTable.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell EnabelTempCell = new DataGridViewCheckBoxCell();
                EnabelTempCell = (DataGridViewCheckBoxCell)dgv_calibTempPointsTable.Rows[i].Cells[0];

                if (EnabelTempCell.Value != null)
                {
                    if ((bool)(dgv_calibTempPointsTable.Rows[i].Cells[0].Value))
                    {

                        calibForm.classCalibrationInfo.TempUnderTestList.Add(float.Parse(dgv_calibTempPointsTable.Rows[i].Cells[1].Value.ToString()));
                    }
                }
            }



            //save pressure points
            for (int i = 0; i < dgv_calibPressuresPointsTable.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell EnabelTempCell = new DataGridViewCheckBoxCell();
                EnabelTempCell = (DataGridViewCheckBoxCell)dgv_calibPressuresPointsTable.Rows[i].Cells[0];
                if (EnabelTempCell.Value != null)
                {
                    if ((bool)(dgv_calibPressuresPointsTable.Rows[i].Cells[0].Value))
                    {
                        calibForm.classCalibrationInfo.PressureUnderTestList.Add(float.Parse(dgv_calibPressuresPointsTable.Rows[i].Cells[1].Value.ToString()));
                    }
                }

            }

            // update jig configuration
            if (cmb_jigConfiguration.SelectedItem != null)
            {

                if (cmb_jigConfiguration.SelectedItem.ToString() != "")
                {
                    calibForm.classCalibrationInfo.JigConfiguration = int.Parse(cmb_jigConfiguration.SelectedItem.ToString());
                }
                else
                {
                    calibForm.classCalibrationInfo.JigConfiguration = 8;
                }
            }
            else
            {
                calibForm.classCalibrationInfo.JigConfiguration = 8;
            }

            this.Hide();
            calibForm.Show();
        }

        private void dgv_calibTempPointsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_calibTempPointsTable.Rows[e.RowIndex].Cells[1].Value != null)
            {
                if (dgv_calibTempPointsTable.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                {
                    dgv_calibTempPointsTable.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void dgv_calibPressuresPointsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_calibPressuresPointsTable.Rows[e.RowIndex].Cells[1].Value != null)
            {
                if (dgv_calibPressuresPointsTable.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                {
                    dgv_calibPressuresPointsTable.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void bt_loadDefoult_Click(object sender, EventArgs e)
        {
            dgv_calibTempPointsTable.Rows.Clear();

            dgv_calibTempPointsTable.Rows.Add(true, Properties.Settings.Default.TempUnderTest1.ToString());
            dgv_calibTempPointsTable.Rows.Add(true, Properties.Settings.Default.TempUnderTest2.ToString());
            dgv_calibTempPointsTable.Rows.Add(true, Properties.Settings.Default.TempUnderTest3.ToString());
            dgv_calibTempPointsTable.Rows.Add(true, Properties.Settings.Default.TempUnderTest4.ToString());
            dgv_calibTempPointsTable.Rows.Add(true, Properties.Settings.Default.TempUnderTest5.ToString());


            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest1.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest2.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest3.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest4.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest5.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest6.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest7.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest8.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest9.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest10.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest11.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest12.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest13.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest14.ToString());
            dgv_calibPressuresPointsTable.Rows.Add(true, Properties.Settings.Default.PressureUnderTest15.ToString());
        }
    }
}

        

