﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialPort_dll;
using System.Threading;
namespace multiplexing_dll
{


    public class MultiplexingIncomingInformation
    {
        public bool newControlTransmitMessage = false;
        public string controlTransmitMessage; // TX line
        public bool newControlReceiverMessage = false;
        public string controlReceiverMessage; // RX line
    }

    public class classMultiplexing
    {
        // op code's
        private const byte API_MSG_MAG_HAND_CHECKING = 0x0B;



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


        private MultiplexingIncomingInformation incomingInfo;
        private classSerial SerialPortInstanse;
        private Thread IncomingCommunicationBufferHandlerThread;

        public classMultiplexing(string portName, int baud, MultiplexingIncomingInformation info)
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
                    case API_MSG_MAG_HAND_CHECKING:
                        {
                            byte[] data = new byte[API_MSG_MAG_BASIC_MASSEGE_LENGTH];
                            data[0] = API_MSG_PREAMBLE;
                            data[1] = (byte)data.Count();
                            data[2] = 55;  //opcode
                            data[data.Count() - 1] = CheckCum(data, data.Count());

                            SerialPortInstanse.Send(data, data.Count());
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
    }

}