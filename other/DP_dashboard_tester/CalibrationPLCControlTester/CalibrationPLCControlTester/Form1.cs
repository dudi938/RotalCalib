using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeltaPlcCommunication;

namespace CalibrationPLCControlTester
{
    public partial class Form1 : Form
    {
        private DeltaProtocol connection;
        private IncomingInformation info;
        private DeltaReturnedData IncumingParametersFromPLC;

        private const int MAX_PRESSURE_POINT = 10;  
        
        public Form1()
        {
            InitializeComponent();
            info = new IncomingInformation();
            connection = new DeltaProtocol("com1", 9600, info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.SendNewMessage(DeltaMsgType.ForceSingleCoil, DeltaMemType.Y, 0, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.SendNewMessage(DeltaMsgType.ForceSingleCoil, DeltaMemType.Y, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rtbLog.Lines = info.listDebugInfo.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 300, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void writePressureTableToPlc_Click(object sender, EventArgs e)
        {
            List<UInt16> preshureTable = new List<UInt16>();
            for(int i = 1;i<= MAX_PRESSURE_POINT;i++)
            {
                if (dgv_prressureTable.Rows[i - 1].Cells[1].Value == null)
                {
                    preshureTable.Add(0);
                    continue;
                }
                preshureTable.Add(UInt16.Parse(dgv_prressureTable.Rows[i-1].Cells[1].Value.ToString()));
            }
            connection.SendNewMessage(DeltaMsgType.PresetMultipleRegister, DeltaMemType.D, 300, (byte)preshureTable.Count, preshureTable);
        }

        private void bt_readPressureTableFromPlc_Click(object sender, EventArgs e)
        {
            IncumingParametersFromPLC = connection.SendNewMessage(DeltaMsgType.ReadHoldingRegisters, DeltaMemType.D, 300, MAX_PRESSURE_POINT);
            
            if (connection.newPressureTableReceive == true)
            {
                connection.newPressureTableReceive = false;
                

                for(int i = 1; i <= MAX_PRESSURE_POINT; i++)
                {
                    dgv_prressureTable.Rows[i - 1].Cells[1].Value = IncumingParametersFromPLC.IntValue[i - 1].ToString();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 300; i < 310; i++)
            {
                dgv_prressureTable.Rows.Add(i.ToString());
            }
        }

        private void dgv_prressureTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
