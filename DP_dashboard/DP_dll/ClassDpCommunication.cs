using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SerialPort_dll;

namespace DpCommunication
{

    public class DpIncomingInformation
    {
        public bool newControlTransmitMessage = false;
        public string controlTransmitMessage; // TX line
        public bool newControlReceiverMessage = false;
        public string controlReceiverMessage; // RX line
    }

    public class DpSingelPrssurePoint
    {
        public float temp;                  // temperature of the current pressure value
        public float pressure;                // Physical pressure of the current a2d pressure value
        public float a2dPressureValue;        // A2D value
    }

    public class DpTempLine
    {
       public List<DpSingelPrssurePoint> oneTempLine = new List<DpSingelPrssurePoint>();
    }


    public class ClassDpCommunication
    {

        private const byte MAX_TEMP_POINTS = 0x05;
        private const byte MAX_PRESSURE_POINTS = 0x0f;

        //op cod's//
        private const byte API_MSG_DP_ACK_OK              = 0x00;  //opcode
        private const byte API_MSG_DP_SEND_PRESSURE_TO_DP = 0x01;  //opcode
        private const byte API_MSG_DP_GET_DP_INFO         = 0x02;  //opcode
        



        public List<DpTempLine> DPPressuresTable = new List<DpTempLine>();
        private const byte API_RECEIVE_MSG_MAX_SIZE = 255;
        private DateTime communicationPacketTimeLast;

        private const byte COM_PACKET_MESSAGE_TX = 0x01;  //parameter
        private const byte COM_PACKET_MESSAGE_RX = 0x00;  //parameter
        private const byte API_MSG_MAG_BASIC_MASSEGE_LENGTH = 0x04;
        //optional preambles bytes that represent the start of the received packet
        private const byte API_MSG_PREAMBLE = 170;

        //optional indexes in the received packet
        private const byte COM_PACKET_INDEX_START_BYTE = 0; //index of the preamble byte data in the received packet
        private const byte COM_PACKET_INDEX_MESSAGE_SIZE = 1;	//index of the packet size data in the received packet
        private const byte COM_PACKET_INDEX_MESSAGE_TYPE = 2;	//index of the message type data in the received packet
        private const byte COM_PACKET_INDEX_MESSAGE_ID = 3; //index of the message id data in the received packet


        private DpIncomingInformation incomingInfo;
        private classSerial SerialPortInstanse;
        private Thread IncomingCommunicationBufferHandlerThread;

        public ClassDpCommunication(string portName, int baud, DpIncomingInformation info)
        {
            IncomingCommunicationBufferHandlerThread = new Thread(ApiTask);
            SerialPortInstanse = new classSerial(portName, 115200, null);
            incomingInfo = info;
            IncomingCommunicationBufferHandlerThread.Start();
        }
        public string GetCurrentTime()
        {
            DateTime dt = new DateTime();
            return dt.Second.ToString();
        }



        private void ApiTask()
        {

            byte[] incomingCommunicationBuffer = new byte[API_RECEIVE_MSG_MAX_SIZE]; //incoming communication buffer

            while (true)
            {
                try
                {
                    while (SerialPortInstanse.port.BytesToRead > 0)
                    {
                        do
                        {
                            SerialPortInstanse.port.Read(incomingCommunicationBuffer, 0, 1);
                        } while (incomingCommunicationBuffer[0] != API_MSG_PREAMBLE);

                        SerialPortInstanse.port.Read(incomingCommunicationBuffer, 1, 1);

                        for (int i = 2; i < incomingCommunicationBuffer[1]; i++)
                        {
                            SerialPortInstanse.port.Read(incomingCommunicationBuffer, i, 1);
                        }

                        analyzeIncomingCommunicationPacket(incomingCommunicationBuffer);
                        Array.Clear(incomingCommunicationBuffer, 0, incomingCommunicationBuffer.Length);
                    }
                }
                catch (Exception ex)
                {
                    SerialPortInstanse.port.DiscardInBuffer();
                    Array.Clear(incomingCommunicationBuffer, 0, incomingCommunicationBuffer.Length);
                }
            }

        }



        void analyzeIncomingCommunicationPacket(byte[] incomingData)
        {
            //check that received packet is legal
            //1) packet preamble byte is API_MSG_PREAMBLE
            //2) packet length is none zero
            //3) check sum is valid
            if ((incomingData[COM_PACKET_INDEX_START_BYTE] == API_MSG_PREAMBLE) &&
            (incomingData[COM_PACKET_INDEX_MESSAGE_SIZE] > 0) &&
            (incomingData[incomingData[COM_PACKET_INDEX_MESSAGE_SIZE] - 1] == CheckCum(incomingData, incomingData[COM_PACKET_INDEX_MESSAGE_SIZE])))
            {
                SendRxTxStringAsHex(incomingData, COM_PACKET_MESSAGE_RX, incomingData[COM_PACKET_INDEX_MESSAGE_SIZE]);
                incomingInfo.newControlReceiverMessage = true;


                int packetType;
                //initialize variable
                packetType = incomingData[COM_PACKET_INDEX_MESSAGE_TYPE];


                communicationPacketTimeLast = DateTime.Now;

                switch (packetType)
                {
                    case API_MSG_DP_ACK_OK:
                        {

                        }
                        break;
                    case API_MSG_DP_SEND_PRESSURE_TO_DP:
                        {

                        }
                        break;
                    case API_MSG_DP_GET_DP_INFO:
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void SendRxTxStringAsHex(byte[] data, byte dataDirection, byte length)
        {
            incomingInfo.controlReceiverMessage = "";
            incomingInfo.controlTransmitMessage = "";

            for (int i = 0; i < length - 1; i++)
            {
                if (dataDirection == COM_PACKET_MESSAGE_TX)
                {
                    incomingInfo.controlTransmitMessage += string.Format("{0:x}", data[i]);
                }
                else if (dataDirection == COM_PACKET_MESSAGE_RX)
                {
                    incomingInfo.controlReceiverMessage += string.Format("{0:x}", data[i]);
                }
            }

        }

        private byte CheckCum(byte[] data, int length)
        {
            int sum;
            int i;
            byte sumByteValue;

            //initialize variable
            sum = 0;
            i = 0;

            //getting packet sum
            for (i = 0; i < length - 1; i++)
                sum += data[i];


            //convert to byte value range
            sumByteValue = (byte)(sum % 256);

            //return value
            return (byte)~sumByteValue;
        }

        public void DpWritePressurePointToDevice(float a2dValue, byte TempN, byte PreesureN)
        {
            byte[] data = new byte[API_MSG_MAG_BASIC_MASSEGE_LENGTH + 4];
            data[0] = API_MSG_PREAMBLE;
            data[1] = (byte)data.Count();
            data[2] = API_MSG_DP_SEND_PRESSURE_TO_DP;  //opcode
            data[3] = (byte)(a2dValue / 256);
            data[4] = (byte)(a2dValue);
            data[5] = TempN;
            data[6] = PreesureN;
            data[data.Count() - 1] = CheckCum(data, data.Count());

            SerialPortInstanse.Send(data, data.Count());

            //SendRxTxStringAsHex(data, COM_PACKET_MESSAGE_TX, data[1]);  // send to consule (DEBUG)
            //incomingInfo.newControlTransmitMessage = true;
        }

        public void Simulation()
        {
            for (int i = 0; i < MAX_TEMP_POINTS; i++)
            {
                DpTempLine newTempLine = new DpTempLine();
                for (int j = 0; j < MAX_PRESSURE_POINTS; j++)
                {
                    DpSingelPrssurePoint newPoint = new DpSingelPrssurePoint();
                    newPoint.a2dPressureValue = 1000 * j;
                    newTempLine.oneTempLine.Add(newPoint);
                }
                DPPressuresTable.Add(newTempLine);
            }

        }
        public void DPgetDpInfo()
        {
            byte[] data = new byte[API_MSG_MAG_BASIC_MASSEGE_LENGTH];
            data[0] = API_MSG_PREAMBLE;
            data[1] = (byte)data.Count();
            data[2] = API_MSG_DP_GET_DP_INFO;  //opcode

            data[data.Count() - 1] = CheckCum(data, data.Count());

            SerialPortInstanse.Send(data, data.Count());
        }
    }
}
