#ifndef _API_TASK_H_
#define _API_TASK_H_

#include "utilities.h"
#include "stdint.h"


//Multiplexing OP-CODS//
#define API_MSG_CONNECT_CH 				    0x01
#define API_MSG_DISCONNECT_CH 		    0x02
#define API_MSG_CONNECT_ALL_CH 				0x03
#define API_MSG_DISCONNECT_ALL_CH 		0x04


//general
#define API_MSG_MAG_BASIC_LENGTH 4

/* Public define ------------------------------------------------------------*/
//API communication required baud rate
#define API_COMMUNICATION_BAUD_RATE UART_BAUD_RATE_19200
#define API_COMMUNICATION_BAUD_RATE_ID UART_BAUD_RATE_ID_19200

//maximum length of a API communication message that can be transmitted
#define API_TRANSMIT_MSG_MAX_SIZE 250
#define API_TRANSMIT_DOUBLE_BUFFER_SIZE 1000


//maximum length of a API communication message that can be received.
//we should make sure that the size we use here is enough to support the longest message type.
#define API_RECEIVE_MSG_MAX_SIZE 200

//defines for the api_info.receive_buffer_interrupt buffer
#define	API_RECEIVE_CYCLIC_BUFFER_SIZE_MASK 0x3f//used for operations on the api_info.receive_buffer_interrupt buffer
#define API_RECEIVE_CYCLIC_BUFFER_SIZE 0x40//size of api_info.receive_buffer_interrupt buffer

//user messages defines
#define API_MSG_PREAMBLE 0xaa//the start byte of received and sent packets
#define API_MSG_BLE_PREAMBLE 0xab//the start byte of received and sent packets
#define API_MSG_PREAMBLE_INDEX 0//index in received or sent packets which represents the message preamble byte
#define API_MSG_SIZE_INDEX 1//index in received or sent packets which indicates what is the size of the packet in bytes
#define API_MSG_TYPE_INDEX 2//index in received or sent packets which indicates what is the type of the packet 




/* Public macro -------------------------------------------------------------*/
/**************************************************
* Function name	: API_active
* Returns		:
* Arg			:
* Created by	: Ido Ikar
* Date created	: 10.6.12
* Description	: indicates if API is active
* Notes			:
**************************************************/
#define API_ACTIVE() (api_info.active)

/**************************************************
* Function name	: API_special_information_type
* Returns		:
* Arg			:
* Created by	: Ido Ikar
* Date created	: 30.01.12
* Description	: get API current active user special information type
* Notes			:
**************************************************/
#define API_SPECIAL_INFORMATION_TYPE() (api_info.special_information_msg_info.type)

#define API_MSG_EXTERNAL_DATA_TYPE() (api_info.external_data_msg_info.type)

typedef enum
{
	etComSourcePC = 0,
}ApiComSource;



//used for handling the API communication packet ID information
//this data is used for example to enable external applications to synchronize between their requests from the robot and the robot's response
typedef  struct
{
	uint8_t data[2];//data bytes
} ApiPacketIdInfoType;

//used for handling the API msg information
//this data is used for example to enable communication that required some changes in the system configuration, for example
//toggle between communication source or toggle between bluetooth operation mode
typedef  struct
{
	bool enable;//indicates of the struct info should be applied
	bool init;//indicates if the data should be initialize
	bool ackEnable;//indicates if ack should be send
	uint8_t msgType1;//optional messages id
	int16_t msgType2;//optional message id inner id
	uint8_t count;//counter used for miscellaneous operations
	ApiPacketIdInfoType packetIdInfo;//API communication packet ID information
	uint8_t msgCheckSum;//indicates the message check sum that need to be send
	uint8_t msgPacketCheckSum;//indicates the all packet check sum that need to be send
} ApiMsgInfoType;

//used for handling the API information
typedef  struct
{
	uint16_t active;//indicates if API between the robot and any other source is active
	volatile uint8_t receiveBufferInterruptPC[API_RECEIVE_CYCLIC_BUFFER_SIZE];//buffer for receiving characters in the receive ISR
	volatile uint8_t receiveBufferCyclicIndexPC;//current active zero based index of the api_info.receive_buffer_interrupt buffer
	uint8_t receiveBufferPC[API_RECEIVE_MSG_MAX_SIZE];//buffer used for receiving user messages
	uint8_t transmitBuffer[API_TRANSMIT_MSG_MAX_SIZE];//buffer used for transmission of user messages
	volatile uint8_t receiveBufferInterruptBLE[API_RECEIVE_CYCLIC_BUFFER_SIZE];//buffer for receiving characters in the receive ISR
	volatile uint8_t receiveBufferCyclicIndexBLE;//current active zero based index of the api_info.receive_buffer_interrupt buffer
	uint8_t receiveBufferBLE[API_RECEIVE_MSG_MAX_SIZE];//buffer used for receiving user messages
	//uint8_t imidiateResponse;
	//bool bitTestResultSend;//indicates if we should send the BIT test/calibration results through the API
	//uint8_t uiState;//UI state during API_MSG_TYPE_WC_MISCELLANEOUS_TYPE_UI_STATE_SET
	//ApiPacketIdInfoType packetIdInfo;//API communication packet ID information
	
	ApiComSource comSource;
} ApiInfoType;

/* Public variables ---------------------------------------------------------*/
extern ApiInfoType apiInfo;

/* Public function prototypes -----------------------------------------------*/
void ApiTaskInit(void);
void ApiTaskReset(void);
void ApiTaskCommunicationReceivePC(void);
void ApiTaskHandler(void);
void ApiTaskSendPrepareShortValue(uint8_t* packet, uint16_t value);
uint16_t ApiTaskReceivePrepareShortValue(uint8_t* packet);
void ApiTaskSendPrepareLongValue(uint8_t* packet, uint32_t value);
uint32_t ApiTaskReceivePrepareLongValue(uint8_t* packet);
void ApiTaskMsgAcknowledgeSend(void);
void ApiTaskMsgBitSend(uint16_t result);
void ApiTaskPacketSend(uint8_t* packet, uint8_t size);
void ApiTaskByteSend(uint8_t value, uint8_t uart_id);
void ApiTaskByteHexSend(uint8_t value, uint8_t uart_id);
void ApiTaskShortHexSend(uint16_t value, uint8_t uart_id);
void ApiTaskLongHexSend(uint32_t value, uint8_t uart_id);
void ApiTaskStrSend(uint8_t* packet, uint16_t size, uint8_t uart_id);
void ApiTaskHandChecking(void);
void ApiTaskSendDebugInfoToPC(char message[]);
void ApiTaskPacketSend(uint8_t* packet, uint8_t size);

void UartTask(void* ptr);
void InitUartTask(void);
bool ApiTaskCommunicationGetByte(void);

#endif /*_API_TASK_H_*/

