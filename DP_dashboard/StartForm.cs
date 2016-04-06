using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempController_dll;
using DpCommunication;
using multiplexing_dll;

namespace DP_dashboard
{
    public partial class StartForm : Form
    {

        //constant parameters
        private const byte MAX_DP_DEVICES = 0x10; // 16


        //init forms
        public CalibForm calibForm;
        public ProgForm progForm;
        public  TempControllerProtocol tempControllerInstanse;
        // data members
        ClassCalibrationInfo classCalibrationInfo;



        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            StartDpTable();
        }



        public void StartDpTable()
        {
            dgv_registerDpPacket.Rows.Clear();

            for (int i = 1; i <= MAX_DP_DEVICES ; i++)
            {
                dgv_registerDpPacket.Rows.Add(i.ToString());
            }

        }

        private void bt_next_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.StationType == "CalibrationStation")
            {

                if (calibForm == null)
                {
                    MultiplexingIncomingInformation MultiplexingInfo = new MultiplexingIncomingInformation();
                    classMultiplexing classMultiplexing = new classMultiplexing(Properties.Settings.Default.multiplexingComPort, 115200, MultiplexingInfo);

                    DpIncomingInformation DPinfo = new DpIncomingInformation();
                    ClassDpCommunication ClassDpCommunication = new ClassDpCommunication(Properties.Settings.Default.dpComPort, 115200, DPinfo);

                    tempControllerInstanse = new TempControllerProtocol(Properties.Settings.Default.TempControllerComPort, 9600);

                    classCalibrationInfo = new ClassCalibrationInfo(tempControllerInstanse, ClassDpCommunication, classMultiplexing);
                    calibForm = new CalibForm(classCalibrationInfo);
                }
            }



            else if (Properties.Settings.Default.StationType == "ProgramStation")
            {
                if (progForm == null)
                {

                    MultiplexingIncomingInformation MultiplexingInfo = new MultiplexingIncomingInformation();
                    classMultiplexing classMultiplexing = new classMultiplexing(Properties.Settings.Default.multiplexingComPort, 115200, MultiplexingInfo);

                    DpIncomingInformation DPinfo = new DpIncomingInformation();
                    ClassDpCommunication ClassDpCommunication = new ClassDpCommunication(Properties.Settings.Default.dpComPort, 115200, DPinfo);

                    tempControllerInstanse = new TempControllerProtocol(Properties.Settings.Default.TempControllerComPort, 9600);

                    classCalibrationInfo = new ClassCalibrationInfo(tempControllerInstanse, ClassDpCommunication, classMultiplexing);
                    progForm = new ProgForm(classCalibrationInfo, this);
                }
            }


            classCalibrationInfo.DpCountAxist = 0;
            for (int i = 0; i <= MAX_DP_DEVICES; i++)
            {

                if (dgv_registerDpPacket.Rows[i].Cells[1].Value == null)
                {
                    break;
                }

                ClassDevice NewExistDevice = new ClassDevice();
                classCalibrationInfo.DpCountAxist++;

                if (dgv_registerDpPacket.Rows[i].Cells[2].Value != null)
                {
                    NewExistDevice.DeviceSerialNumber = dgv_registerDpPacket.Rows[i].Cells[2].Value.ToString();
                }


                if (dgv_registerDpPacket.Rows[i].Cells[3].Value != null)
                {
                    NewExistDevice.DeviceName = dgv_registerDpPacket.Rows[i].Cells[3].Value.ToString();
                }

                classCalibrationInfo.classDevices[i] = NewExistDevice;
            }


            string UpdateMassege = string.Format("{0} DP devices added.", classCalibrationInfo.DpCountAxist.ToString());
            MessageBox.Show(UpdateMassege);


            this.Hide();
            if (Properties.Settings.Default.StationType == "CalibrationStation")
            {
                calibForm.Show();
            }
            else if (Properties.Settings.Default.StationType == "ProgramStation")
            {
                progForm.Show();
            }
        }


    }
}
