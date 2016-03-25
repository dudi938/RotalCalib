#include "include_all_headers.h"


/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
//time in 250ms resolution we need to be without any API communication in order to declare that API communication is not active
#define API_ACTIVE_TIME 1200 

int GetCharnw(void);

ApiInfoType apiInfo;//API information

/* Private function prototypes -----------------------------------------------*/
void ApiTaskPacketAnalyze(uint8_t* packet);
void API_msg_info_reset(void);
void ApiTaskMsgExternalDataSend(uint16_t external_data_type, uint8_t* external_data_value, uint8_t external_data_value_size);
void API_msg_external_data_reset(void);
void API_msg_special_information_reset(void);
//void API_set_time_and_date(uint8_t time_fields[TIME_FIELD_NUMBER], uint8_t date_fields[DATE_FIELD_NUMBER]); //NEED_TO_IMPLEMENT
bool API_eeprom_param_set_enable(uint8_t api_msg_type_index,uint16_t eeprom_param_index);
void API_eeprom_param_init(uint16_t eeprom_param_index,uint32_t value);
bool ApiTaskCommunicationEnable(void);


/* Private functions ---------------------------------------------------------*/

void ApiTaskInit(void)
{
	//reset API
	ApiTaskReset();
}

void ApiTaskReset(void)
{
	//NEED_TO_IMPLEMENT
}

void ApiTaskCommunicationReceivePC(void)
{
	//optional API communication states
	#define API_COM_STATE_PREAMBLE (0)//waiting for the first byte
	#define API_COM_STATE_PACKET_SIZE (API_COM_STATE_PREAMBLE+1)//packet size 
	#define API_COM_STATE_PACKET_DATA (API_COM_STATE_PACKET_SIZE+1)//packet data

	static uint8_t state = API_COM_STATE_PREAMBLE;//state of the API communication state machine
	static uint8_t receive_buffer_cyclic_index_previous = 0;//used for analyzing received characters
	static uint8_t byte_index;//current byte index in the api_info.receive_buffer variable
	static uint8_t byte_receive;//received byte


	    if(GetCharnw() != (-1))
	    {
			while(apiInfo.receiveBufferCyclicIndexPC != receive_buffer_cyclic_index_previous)
			{
				//save the received byte
				byte_receive = apiInfo.receiveBufferInterruptPC[receive_buffer_cyclic_index_previous];
				receive_buffer_cyclic_index_previous = ((receive_buffer_cyclic_index_previous+1) & API_RECEIVE_CYCLIC_BUFFER_SIZE_MASK);
				//ApiTaskPacketSend(byte_receive,apiInfo.receiveBufferPC[API_MSG_SIZE_INDEX]);
				//analyze the received byte
				switch(state)
				{
						case API_COM_STATE_PREAMBLE:
							{
								apiInfo.receiveBufferPC[0] = byte_receive;
								if(byte_receive == API_MSG_PREAMBLE)
									state = API_COM_STATE_PACKET_SIZE;
							}
							break;

						case API_COM_STATE_PACKET_SIZE:
							{
								state = API_COM_STATE_PACKET_DATA;
								apiInfo.receiveBufferPC[API_MSG_SIZE_INDEX] = byte_receive;
								byte_index = 2;
							}
							break;

						case API_COM_STATE_PACKET_DATA:
							{
								//check if byte_index is valid in order to prevent access to wrong address
								if(byte_index < API_RECEIVE_MSG_MAX_SIZE)
								{
									apiInfo.receiveBufferPC[byte_index++] = byte_receive;
									if(byte_index == apiInfo.receiveBufferPC[API_MSG_SIZE_INDEX])//check if end of packet
									{
										state = API_COM_STATE_PREAMBLE;
										apiInfo.comSource = etComSourcePC;
										ApiTaskPacketAnalyze(apiInfo.receiveBufferPC);
									}
								}
								else
								{
									//if we reached here than we exceeded the maximal number of byte allowed
									//for a message and we should initialize API communication data reception process
									state = API_COM_STATE_PREAMBLE;
								}
							}
							break;

							default:
							{
								state = API_COM_STATE_PREAMBLE;
							}
							break;
				}
			}
	    }
}


void ApiTaskPacketAnalyze(uint8_t* packet)
{
	volatile uint8_t crcPos    = packet[API_MSG_SIZE_INDEX]-1; 
	volatile uint8_t adminPos  = packet[API_MSG_SIZE_INDEX]-2; 
	volatile uint8_t activePos = packet[API_MSG_SIZE_INDEX]-3; 


	if( (UtilitiesCheckSum(packet,packet[API_MSG_SIZE_INDEX]-1) == packet[crcPos]) &&
		(packet[API_MSG_SIZE_INDEX] <= API_RECEIVE_MSG_MAX_SIZE) )
	{
		apiInfo.active = API_ACTIVE_TIME;
		//NEED_TO_IMPLEMENT software_version_release_id = Software_version_release_id();
		//update the menu authorization level to the maximal level during API communication
		//NEED_TO_IMPLEMENT Menu_set_authorization_level(MENU_AUTHORIZATION_LEVEL_MAX);

		//analyze packet
		switch(packet[API_MSG_TYPE_INDEX])
		{
			case API_MSG_CONNECT_CH:
			{
				GPIOA->BRR = GPIO_Pin_8 | GPIO_Pin_9;
				GPIOB->BRR = GPIO_Pin_All;

				//ApiTaskPacketSend(packet,packet[API_MSG_SIZE_INDEX]);
				//printf(4);
				switch(packet[API_MSG_TYPE_INDEX +1])
				{
					case 0:
						GPIOA->BSRR |= GPIO_Pin_8;
						break;
					case 1:
						GPIOA->BSRR |= GPIO_Pin_9;
						break;
					case 2:
						GPIOB->BSRR |= GPIO_Pin_2;
						break;
					case 3:
						GPIOB->BSRR |= GPIO_Pin_3;
						break;
					case 4:
						GPIOB->BSRR |= GPIO_Pin_4;
						break;
					case 5:
						GPIOB->BSRR |= GPIO_Pin_5;
						break;
					case 6:
						GPIOB->BSRR |= GPIO_Pin_6;
						break;
					case 7:
						GPIOB->BSRR |= GPIO_Pin_7;
						break;
					case 8:
						GPIOB->BSRR |= GPIO_Pin_8;
						break;
					case 9:
						GPIOB->BSRR |= GPIO_Pin_9;
						break;
					case 0x0a:
						GPIOB->BSRR |= GPIO_Pin_10;
						break;
					case 0x0b:
						GPIOB->BSRR |= GPIO_Pin_11;
						break;
					case 0x0c:
						GPIOB->BSRR |= GPIO_Pin_12;
						break;
					case 0x0d:
						GPIOB->BSRR |= GPIO_Pin_13;
						break;
					case 0x0e:
						GPIOB->BSRR |= GPIO_Pin_14;
						break;
					case 0x0f:
						GPIOB->BSRR |= GPIO_Pin_15;
						break;
					}
			}
			break;	
			case API_MSG_DISCONNECT_CH:
			{

			}
			break;	
			case API_MSG_CONNECT_ALL_CH:
			{

			}
			break;	
			case API_MSG_DISCONNECT_ALL_CH:
			{
				GPIOA->BRR = GPIO_Pin_8 | GPIO_Pin_9;
				GPIOB->BRR = GPIO_Pin_All;
			}
			break;				
			default:
			break;
		}
		}
	}


void ApiTaskPacketSend(uint8_t* packet, uint8_t size)
{
	int i = 0;
	for(i = 0; i < size; i++)
	{
	   printf("%d",packet[i]);
	}
	printf("\r\n");
}

uint32_t ApiTaskReceivePrepareLongValue(uint8_t* packet)
{
	return((16777216UL*(uint32_t)packet[0])+(65536UL*(uint32_t)packet[1])+(256UL*(uint32_t)packet[2])+(uint32_t)packet[3]);
}

uint16_t ApiTaskReceivePrepareShortValue(uint8_t* packet)
{
	return((uint16_t)((256UL*(uint32_t)packet[0])+(uint32_t)packet[1]));
}

void ApiTaskSendPrepareShortValue(uint8_t* packet, uint16_t value)
{
	packet[0] = (uint8_t)(value>>8);
	packet[1] = (uint8_t)value;
}

void ApiTaskSendPrepareLongValue(uint8_t* packet, uint32_t value)
{
	packet[0] = (uint8_t)(value>>24);
	packet[1] = (uint8_t)(value>>16);
	packet[2] = (uint8_t)(value>>8);
	packet[3] = (uint8_t)value;
}

void ApiTaskHandler(void)
{
	//NEED_TO_IMPLEMENT
}

void ApiTaskByteSend(uint8_t value, uint8_t uart_id)
{
	//NEED_TO_IMPLEMENT
}
void ApiTaskByteHexSend(uint8_t value, uint8_t uart_id)
{
	uint8_t hex_char_array[2];

	//convert byte to hex
	//Number_convert_byte_to_hex(value, hex_char_array);

	//send hex characters
	ApiTaskByteSend(hex_char_array[0], uart_id);
	ApiTaskByteSend(hex_char_array[1], uart_id);
}

void ApiTaskShortHexSend(uint16_t value, uint8_t uart_id)
{
	ApiTaskByteHexSend((uint8_t)(value >> 8), uart_id);
	ApiTaskByteHexSend((uint8_t)(value), uart_id);
}

void ApiTaskLongHexSend(uint32_t value, uint8_t uart_id)
{
	ApiTaskShortHexSend((uint16_t)(value >> 16), uart_id);
	ApiTaskShortHexSend((uint16_t)(value), uart_id);
}

void ApiTaskStrSend(uint8_t* packet, uint16_t size, uint8_t uart_id)
{
    uint16_t i;
	bool str_end;
	uint8_t str_char;//string character

	//initialize variables
	str_end = false;

	//send packet
	for(i = 0; i < size; i++)
	{
		//to prevent unwanted characters we replace all the characters
		//from first null character to size with spaces

		//initialize variables
		str_char = packet[i];

		if ((str_end) || (str_char == NULL))
		{
			str_end = true;
			str_char = ' ';
		}
	
		//send character
		ApiTaskByteSend(str_char, uart_id);
	}
}

bool ApiTaskCommunicationEnable(void)
{
	#define API_COMMUNICATION_POWERUP_DELAY 100

	bool result;//indicates if API communication is enabled

	//initialize variables
	result = true;

	//we should disable the user API communication if the system time since powerup is less than API_COMMUNICATION_POWERUP_DELAY
	//if(!System_time_since_powerup(API_COMMUNICATION_POWERUP_DELAY))
		//result = FALSE;

	//NEED_TO_IMPLEMENT

	return(result);
}




bool ApiTaskCommunicationGetByte(void)
{
	int8_t byte = (int8_t)GetCharnw();
	if(byte != (-1))
	{
		apiInfo.receiveBufferInterruptPC[apiInfo.receiveBufferCyclicIndexPC] = byte;
		apiInfo.receiveBufferCyclicIndexPC = ((apiInfo.receiveBufferCyclicIndexPC + 1) & API_RECEIVE_CYCLIC_BUFFER_SIZE_MASK);
		return true;
	}
	return false;
}

