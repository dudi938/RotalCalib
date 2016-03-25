#include "include_all_headers.h"

USB_CORE_HANDLE  USB_Device_dev ;

/* Private function prototypes -----------------------------------------------*/
void LEDInit(void);
void EXTI0_Config(void);
void TIM_Config(void);
void USARTInit(unsigned long baudrate);

/* Private functions ---------------------------------------------------------*/
/* Uncomment the line below to select your USB clock source */
//#define USE_USB_CLKSOURCE_CRSHSI48   1
//#define USE_USB_CLKSOURCE_PLL        1

#define 	XON   		  0x11
#define 	XOFF  		  0x13
#define 	LF	  		  0x0A
#define 	CR	  		  0x0D
#define  	SPACE 	   	  0x20

#define LED1ON  GPIO_ResetBits(GPIOC,GPIO_Pin_9);
#define LED1OFF  GPIO_SetBits(GPIOC,GPIO_Pin_9);
#define LED0ON  GPIO_ResetBits(GPIOC,GPIO_Pin_8);
#define LED0OFF  GPIO_SetBits(GPIOC,GPIO_Pin_8);

#define LED1HIGH   GPIOC->BSRR = GPIO_Pin_9
#define LED1LOW	   GPIOC->BRR = GPIO_Pin_9
#define LED2HIGH   GPIOC->BSRR = GPIO_Pin_8
#define LED2LOW	   GPIOC->BRR = GPIO_Pin_8

// STM32F042 defines
#define PWMACTIVE  'a'
#define CMDACTIVE  'c'
#define INACTIVE 'i'
#define YES     'y'
#define NO      'n'
#define HIGH	'h'
#define LOW		'l'

TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
TIM_OCInitTypeDef  TIM_OCInitStructure;
TIM_ICInitTypeDef  TIM_ICInitStructure;

FILE *fpout;

#define     USB_RX_BUFFERSIZE 512

int usbrxheadptr=0, usbrxtailptr=0;
unsigned char usbrxbuffer[USB_RX_BUFFERSIZE];

#define     USART3_TX_BUFSIZE 80
#define     USART3_RX_BUFSIZE 80

int tx3headptr,tx3tailptr,rx3headptr,rx3tailptr;
unsigned char rx3buffer[USART3_RX_BUFSIZE],tx3buffer[USART3_TX_BUFSIZE];

char flip=0,grnflip=0,redflip=0;
uint16_t TimerPeriod = 0;
uint16_t Channel1Pulse = 0, Channel2Pulse = 0, Channel3Pulse = 0, Channel4Pulse = 0;
unsigned int mseccountdown1,mseccountdown2,mseccountdown3;
__IO uint16_t IC2Value = 0;
__IO uint16_t DutyCycle = 0;
__IO uint32_t Frequency = 0;

/***********************************************
 *
 *  Initialization Functions
 *
 ***********************************************/
/**
  * @brief  Configures LED GPIO.
  */
void LED_Init(void)
{
	GPIO_InitTypeDef  GPIO_InitStructure;

	/* Enable the GPIO_LED Clock */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOC, ENABLE);

	/* Configure the GPIO_LED pin */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9;
	//  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOC, &GPIO_InitStructure);
}

/**
  * @brief  Configures COM port.  Supports buffered interrupt IO
  */
void USART3_Init(unsigned long baudrate)
{
    GPIO_InitTypeDef GPIO_InitStructure;
    USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

    // Initialize interrupt tx rx buffers
    tx3headptr = tx3tailptr = rx3headptr = rx3tailptr = 0;

    /* USARTx configured as follow:
    - BaudRate = 115200 baud
    - Word Length = 8 Bits
    - One Stop Bit
    - No parity
    - Hardware flow control disabled (RTS and CTS signals)
    - Receive and transmit enabled
    */
    USART_InitStructure.USART_BaudRate = baudrate;
    //USART_InitStructure.USART_BaudRate = 115200;
    USART_InitStructure.USART_WordLength = USART_WordLength_8b;
    USART_InitStructure.USART_StopBits = USART_StopBits_1;
    USART_InitStructure.USART_Parity = USART_Parity_No;
    USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
    USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;

    /* Enable GPIO clock */
    RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOB, ENABLE);

    /* Enable USART clock */
    RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3, ENABLE);

    /* Connect PXx to USARTx_Tx */
    GPIO_PinAFConfig(GPIOB, GPIO_PinSource10, GPIO_AF_4);

    /* Connect PXx to USARTx_Rx */
    GPIO_PinAFConfig(GPIOB, GPIO_PinSource11, GPIO_AF_4);

    /* Configure USART Tx, Rx as alternate function push-pull */
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10 | GPIO_Pin_11;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
    GPIO_Init(GPIOB, &GPIO_InitStructure);

    /* USART configuration */
    USART_Init(USART3, &USART_InitStructure);

    USART_ITConfig(USART3, USART_IT_RXNE, ENABLE);
    USART_ITConfig(USART3, USART_IT_TXE, ENABLE);

	/* Enable the USART3 global Interrupt */
	NVIC_InitStructure.NVIC_IRQChannel = USART3_4_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);

    /* Enable USART */
    USART_Cmd(USART3, ENABLE);
}

/**
  * @brief  Configure the TIM1 Pins.
  */
void TIM1_Config(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;

	/* GPIOA Clocks enable */
	RCC_AHBPeriphClockCmd( RCC_AHBPeriph_GPIOA, ENABLE);

	/* GPIOA Configuration: Channel 1, 2 as alternate function push-pull */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_11;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP ;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	GPIO_PinAFConfig(GPIOA, GPIO_PinSource8, GPIO_AF_2);
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource11, GPIO_AF_2);
}

// PWM output example - TIM2 can generat four different pwm outputs
void TIM1_ConfigPWM(void)
{
	/* Compute the value to be set in ARR regiter to generate signal frequency at 17.57 Khz */
	TimerPeriod = (SystemCoreClock / 17570 ) - 1;
	/* Compute CCR1 value to generate a duty cycle at 50% for channel 1 */
	Channel1Pulse = (uint16_t) (((uint32_t) 5 * (TimerPeriod - 1)) / 10);
	/* Compute CCR2 value to generate a duty cycle at 37.5%  for channel 2 */
	Channel2Pulse = (uint16_t) (((uint32_t) 375 * (TimerPeriod - 1)) / 1000);

	/* TIM1 clock enable */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1 , ENABLE);

	/* Time Base configuration */
	TIM_TimeBaseStructure.TIM_Prescaler = 0;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseStructure.TIM_Period = TimerPeriod;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;
	TIM_TimeBaseStructure.TIM_RepetitionCounter = 0;

	TIM_TimeBaseInit(TIM1, &TIM_TimeBaseStructure);

	/* Channel 1, 2, 3 and 4 Configuration in PWM mode */
	TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM1;
	TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
	TIM_OCInitStructure.TIM_OutputNState = TIM_OutputNState_Enable;
	TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;
	TIM_OCInitStructure.TIM_OCNPolarity = TIM_OCNPolarity_High;
	TIM_OCInitStructure.TIM_OCIdleState = TIM_OCIdleState_Set;
	TIM_OCInitStructure.TIM_OCNIdleState = TIM_OCIdleState_Reset;

	TIM_OCInitStructure.TIM_Pulse = Channel1Pulse;
	TIM_OC1Init(TIM1, &TIM_OCInitStructure);

	TIM_OCInitStructure.TIM_Pulse = Channel2Pulse;
	TIM_OC2Init(TIM1, &TIM_OCInitStructure);

	/* TIM1 counter enable */
	TIM_Cmd(TIM1, ENABLE);

	/* TIM1 Main Output Enable */
	TIM_CtrlPWMOutputs(TIM1, ENABLE);
}

// PWM timer setup example - input sets pwm output
void TIM2_ConfigIRQ()
{
	/* ---------------------------------------------------------------------------
	TIM2 configuration: PWM Input mode

	In this example TIM2 input clock (TIM2CLK) is set to APB1 clock (PCLK1)
	  TIM2CLK = PCLK1
	  => TIM2CLK = HCLK = SystemCoreClock

	External Signal Frequency = TIM2 counter clock / TIM2_CCR2 in Hz.

	External Signal DutyCycle = (TIM2_CCR1*100)/(TIM2_CCR2) in %.

	--------------------------------------------------------------------------- */

	TIM_ICInitStructure.TIM_Channel = TIM_Channel_2;
	TIM_ICInitStructure.TIM_ICPolarity = TIM_ICPolarity_Rising;
	TIM_ICInitStructure.TIM_ICSelection = TIM_ICSelection_DirectTI;
	TIM_ICInitStructure.TIM_ICPrescaler = TIM_ICPSC_DIV1;
	TIM_ICInitStructure.TIM_ICFilter = 0x0;

	TIM_PWMIConfig(TIM2, &TIM_ICInitStructure);

	/* Select the TIM2 Input Trigger: TI2FP2 */
	TIM_SelectInputTrigger(TIM2, TIM_TS_TI2FP2);

	/* Select the slave Mode: Reset Mode */
	TIM_SelectSlaveMode(TIM2, TIM_SlaveMode_Reset);
	TIM_SelectMasterSlaveMode(TIM2,TIM_MasterSlaveMode_Enable);

	/* TIM enable counter */
	TIM_Cmd(TIM2, ENABLE);

	/* Enable the CC2 Interrupt Request */
	TIM_ITConfig(TIM2, TIM_IT_CC2, ENABLE);
}

/**
  * @brief  Configure the TIM2 IRQ Handler.
  */
void TIM2_Config(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	/* TIM2 clock enable */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);

	/* GPIOA clock enable */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOA, ENABLE);

	/* TIM2 chennel2 configuration : PA.01 */
	GPIO_InitStructure.GPIO_Pin   = GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_AF;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd  = GPIO_PuPd_UP ;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	/* Connect TIM pin to AF2 */
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource1, GPIO_AF_2);

	/* Enable the TIM2 global Interrupt */
	NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}

/**
  * @brief  Configure the TIM3 IRQ Handler.
  */
void TIM3_Config(void)
{
	NVIC_InitTypeDef NVIC_InitStructure;

	/* TIM3 clock enable */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);

	/* Enable the TIM3 global Interrupt */
	NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}

// Setup Timer 3 as a 1msec time delay interrupt
void TIM3_Init(void)
{
	uint16_t CCR3_Val,PrescalerValue;

	/* TIM Configuration */
	TIM3_Config();

	/* -----------------------------------------------------------------------
	TIM3 Configuration: Output Compare Timing Mode:

	In this example TIM3 input clock (TIM3CLK) is set to APB1 clock (PCLK1),
	  => TIM3CLK = PCLK1 = SystemCoreClock = 48 MHz

	To get TIM3 counter clock at 6 MHz, the prescaler is computed as follows:
	   Prescaler = (TIM3CLK / TIM3 counter clock) - 1
	   Prescaler = (PCLK1 /6 MHz) - 1

	CC3 update rate = TIM3 counter clock / CCR3_Val = 439.4 Hz
	==> Toggling frequency = 219.7 Hz

	----------------------------------------------------------------------- */

	/* Compute the prescaler value */
	PrescalerValue = (uint16_t) (SystemCoreClock  / 6000000) - 1;
	//PrescalerValue = 0;

	CCR3_Val = 1000;
	mseccountdown1 = mseccountdown2 = mseccountdown3 = 0;

	/* Time base configuration */
	TIM_TimeBaseStructure.TIM_Period = 65535;
	TIM_TimeBaseStructure.TIM_Prescaler = 0;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);

	/* Prescaler configuration */
	TIM_PrescalerConfig(TIM3, PrescalerValue, TIM_PSCReloadMode_Immediate);

	/* Output Compare Timing Mode configuration: Channel1 */
	//TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_Timing;
	//TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;

	/* Output Compare Timing Mode configuration: Channel3 */
	TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
	TIM_OCInitStructure.TIM_Pulse = CCR3_Val;

	TIM_OC3Init(TIM3, &TIM_OCInitStructure);

	TIM_OC3PreloadConfig(TIM3, TIM_OCPreload_Disable);

	/* TIM Interrupts enable */
	TIM_ITConfig(TIM3, TIM_IT_CC3, ENABLE);

	/* TIM3 enable counter */
	TIM_Cmd(TIM3, ENABLE);
}

// Setup usec delay timer
void TIM15_Init(void)
{
	uint16_t CCR3_Val,PrescalerValue;

	/* TIM15 clock enable */
	RCC_APB1PeriphClockCmd(RCC_APB2Periph_TIM15, ENABLE);

	/* Compute the prescaler value */
	PrescalerValue = (uint16_t) (SystemCoreClock  / 1000000) - 1;
	//PrescalerValue = 0;

	CCR3_Val = 0;

	/* Time base configuration */
	TIM_TimeBaseStructure.TIM_Period = 65535;
	TIM_TimeBaseStructure.TIM_Prescaler = 0;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

	TIM_TimeBaseInit(TIM15, &TIM_TimeBaseStructure);

	/* Prescaler configuration */
	TIM_PrescalerConfig(TIM15, PrescalerValue, TIM_PSCReloadMode_Immediate);

	/* Output Compare Timing Mode configuration: Channel3 */
	//TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
	//TIM_OCInitStructure.TIM_Pulse = CCR3_Val;

	//TIM_OC3Init(TIM15, &TIM_OCInitStructure);

	//TIM_OC1PreloadConfig(TIM15, TIM_OCPreload_Disable);

	/* TIM Interrupts enable */
	//TIM_ITConfig(TIM15, TIM_IT_CC1, ENABLE);

	/* TIM3 enable counter */
	//TIM_Cmd(TIM15, ENABLE);
}

/***********************************************
 *
 *  ISRs
 *
 ***********************************************/
/**
  * @brief  This function handles TIM2 global interrupt request.
  */
void TIM2_IRQHandler(void)
{
	/* Clear TIM2 Capture compare interrupt pending bit */
	//TIM_ClearITPendingBit(TIM2, TIM_IT_CC2);
	TIM2->SR = (uint16_t)~TIM_IT_CC2;

	/* Get the Input Capture value */
	//IC2Value = TIM_GetCapture2(TIM2);
	IC2Value = TIM2->CCR2;
}

// 1 msec interrupt handler for delay countdown
void TIM3_IRQHandler(void)
{
    if (TIM_GetITStatus(TIM3, TIM_IT_CC3) != RESET)  {
		TIM_ClearITPendingBit(TIM3, TIM_IT_CC3);
		//LED2HIGH;
		if(mseccountdown1) mseccountdown1--;
		if(mseccountdown2) mseccountdown2--;
		if(mseccountdown3) mseccountdown3--;
		TIM_SetCounter(TIM3, 0);
		//LED2LOW;
    	}
}

// Interrupt handler for USART3  TX and RX buffer size set by USART3_TX_BUFSIZE and USART3_RX_BUFSIZE
void USART3_4_IRQHandler(void)
{
	// Check receive interrupt
    if (USART_GetITStatus(USART3, USART_IT_RXNE) != RESET)  {
    	USART_ClearITPendingBit(USART3, USART_IT_RXNE);
    	//LED1LOW;
		rx3buffer[rx3headptr++] = (uint8_t)(USART3->RDR & (uint16_t)0x00FF);
		if(rx3headptr==USART3_RX_BUFSIZE) rx3headptr = 0;
		if(rx3headptr==rx3tailptr) {
			rx3tailptr++;
			if(rx3tailptr==USART3_RX_BUFSIZE) rx3tailptr = 0;
			}
    	}
    // Check transmit interrupt
    if (USART_GetITStatus(USART3, USART_IT_TXE) != RESET)  {
    	USART_ClearITPendingBit(USART3, USART_IT_TXE);
    	//LED2LOW;
		USART3->TDR = tx3buffer[tx3tailptr++];
		if(tx3tailptr==USART3_TX_BUFSIZE) tx3tailptr = 0;
		// Turn off interrupt is not more data to transmit
		if(tx3tailptr==tx3headptr)  USART_ITConfig(USART3, USART_IT_TXE, DISABLE);
    	}
}

/***********************************************
 *
 *  Serial IO Functions for USB and USART3
 *
 ***********************************************/
int GetCharnw3(void)
{
	int intchar;

	// Uncomment this call if rx buffer is experiencing an overrun condition
	//if(USART_GetFlagStatus(USART3, USART_FLAG_ORE) == SET) {
	//	USART_ClearFlag(USART3, USART_FLAG_ORE);
	//	}

	if(rx3headptr!=rx3tailptr) {
		intchar = rx3buffer[rx3tailptr++];
		if(rx3tailptr==USART3_RX_BUFSIZE) rx3tailptr = 0;
		return intchar;
		}
	else return -1;
}

unsigned char GetChar3(void)
{
	int intchar;

	while((intchar=GetCharnw3())==-1) ;
	return (unsigned char) intchar;
}

void PutChar3(unsigned char outchar)
{
	if(tx3headptr==tx3tailptr) {
		tx3buffer[tx3headptr++] = outchar;
		if(tx3headptr==USART3_TX_BUFSIZE) tx3headptr = 0;
		USART_ITConfig(USART3, USART_IT_TXE, ENABLE);
		}
	else {
		tx3buffer[tx3headptr++] = outchar;
		if(tx3headptr==USART3_TX_BUFSIZE) tx3headptr = 0;
		if(tx3tailptr==tx3headptr) {
			tx3tailptr++;
			if(tx3tailptr==USART3_TX_BUFSIZE) tx3tailptr = 0;
			}
		}
}

void Puts3(unsigned char *outstrg)
{
	int i;

	for(i=0; i<strlen(outstrg); i++) PutChar3(outstrg[i]);
}

// Formated output for USART3
int printf3(const char *fmt, ...)
{
	va_list args;
	int i,j;
	char printbuffer[150];

	va_start (args, fmt);
	i = vsnprintf (printbuffer, 150, fmt, args);
	va_end (args);

	// Print the string
	j = 0;
	while(printbuffer[j]!=0) PutChar3(printbuffer[j++]);

	return i;
}

int scanf3(const char *fmt, ...)
{
	char inchar;
	va_list args;
	int i,ptr;
	char scanbuffer[120];

	ptr = 0;
	while((inchar=GetChar3())!=CR) {
        scanbuffer[ptr++] = inchar;
		//putchar(inchar);
		}
	scanbuffer[ptr] = 0;

	va_start (args, fmt);
	i = vsscanf(scanbuffer, fmt, args);
	va_end (args);

	return i;
}

// Buffers for USB serial IO
// Hack into Serial to USB bridge code - this could be cleaned up and streamlined
extern uint8_t  APP_Rx_Buffer []; /* Write CDC received data in this buffer.
                                     These data will be sent over USB IN endpoint
                                     in the CDC core functions. */
extern uint32_t APP_Rx_ptr_in;    /* Increment this pointer or roll it back to
                                     start address when writing received data
                                     in the buffer APP_Rx_Buffer. */

/**
  * @brief  VCP_DataTx
  *         CDC received data to be send over USB IN endpoint are managed in
  *         this function.
  * @param  Buf: Buffer of data to be sent
  * @param  Len: Number of data to be sent (in bytes)
  * @retval Result of the operation: USBD_OK if all operations are OK else VCP_FAIL
  */
static uint16_t VCP_DataTx2(uint8_t* Buf, uint32_t Len)
{
	int i;

    for(i=0; i<Len; i++) {
    	APP_Rx_Buffer[APP_Rx_ptr_in++] = Buf[i];
    	//PutChar(Buf[i]);
    	if(APP_Rx_ptr_in == APP_RX_DATA_SIZE)  APP_Rx_ptr_in = 0;
    	}

  return USBD_OK;
}

// USB putchar
void PutChar(unsigned char outchar)
{
	unsigned char outbuf[2];

	outbuf[0] = outchar;
	VCP_DataTx2(outbuf,1);
	char *str= "test1\r\n";
}

// USB no wait getchar
int GetCharnw(void)
{
	int intchar;
    bool NewData = false;
	while(usbrxheadptr!=usbrxtailptr)
	{
		apiInfo.receiveBufferInterruptPC[apiInfo.receiveBufferCyclicIndexPC] = usbrxbuffer[usbrxtailptr++];
		apiInfo.receiveBufferCyclicIndexPC = ((apiInfo.receiveBufferCyclicIndexPC + 1) & API_RECEIVE_CYCLIC_BUFFER_SIZE_MASK);
		intchar = apiInfo.receiveBufferInterruptPC[apiInfo.receiveBufferCyclicIndexPC];
		if(usbrxtailptr==USB_RX_BUFFERSIZE) usbrxtailptr = 0;
		NewData = true;
	}
	if(NewData)
		return 1;
	return -1;
}

// USB wait getchar
unsigned char GetChar(void)
{
	int intchar;

	while((intchar=GetCharnw())==-1) ;
	return (unsigned int) intchar;
}

// Formated USB serial output
int printf(const char *fmt, ...)
{
	va_list args;
	int i;
	char printbuffer[150];

	va_start (args, fmt);
	i = vsnprintf (printbuffer, 150, fmt, args);
	va_end (args);

	// Print the string
	VCP_DataTx2(printbuffer,i);

	return i;
}

// Formated USB input - CR terminates input
int scanf(const char *fmt, ...)
{
	char inchar;
	va_list args;
	int i,ptr;
	char scanbuffer[120];

	//printf("\n\rFormat: %s  args=%d",fmt,args);

	ptr = 0;
	while((inchar=GetChar())!=CR) {
        scanbuffer[ptr++] = inchar;
		//putchar(inchar);
		}
	scanbuffer[ptr] = 0;

	va_start (args, fmt);
	i = vsscanf(scanbuffer, fmt, args);
	va_end (args);

	return i;
}

/***********************************************
 *
 *  Utility Functions
 *
 ***********************************************/
void TIM15_Start(void)
{
	TIM_SetCounter(TIM3, 0);
	TIM_Cmd(TIM15,ENABLE);
}

void TIM15_Stop(void)
{
	TIM_Cmd(TIM15,DISABLE);
}

void delay_us(unsigned long ult)
{
	TIM15_Start();

	while(TIM_GetCounter(TIM3)<ult) ;
	TIM15_Stop();
}

void delay_ms(unsigned int ult)
{
	mseccountdown1 = ult;
	while(mseccountdown1) ;
}

void Toggle_Leds(int grncnt,int redcnt)
{
	if(!mseccountdown2) {
		mseccountdown2 = grncnt;
		if(grnflip) {
			LED1LOW;
			grnflip = 0;
			}
		else {
			LED1HIGH;
			grnflip = 1;
			}
		}
	if(!mseccountdown3) {
		mseccountdown3 = redcnt;
		if(redflip) {
			LED2LOW;
			redflip = 0;
			}
		else {
			LED2HIGH;
			redflip = 1;
			}
		}
}

/***********************************************
 *
 *  Work Functions
 *
 ***********************************************/
void Short_Init(void)
{
	LED_Init();   // Leds on PC8 and PC9

	TIM3_Init();  // Setup 1msec count down timer
	TIM15_Init(); // Setup usec count down timer

	LED1OFF;  // Turn LEDs off
	LED0OFF;

	USART3_Init(38400);  // Setup USART3
}

// More extension initialization
void STMF072_Init(void)
{
	 // Setup All ports
	GPIO_InitTypeDef  GPIO_InitStructure;

	/* Enable the GPIO_LED Clock */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOA, ENABLE);

	/* Configure the GPIOA output pins */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_14 | GPIO_Pin_13 | GPIO_Pin_12 | GPIO_Pin_11 |
								  GPIO_Pin_8 | GPIO_Pin_3;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	/* Configure the GPIOA inpout pins */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	//GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	/* Configure the GPIOB output pins */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOB, ENABLE);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7 | GPIO_Pin_5 | GPIO_Pin_4 | GPIO_Pin_3 | GPIO_Pin_0;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	/* Configure the GPIOB input pins */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6 | GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	//GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	/* Configure the GPIOF pins */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_GPIOF, ENABLE);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1 | GPIO_Pin_0;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOF, &GPIO_InitStructure);

	LED_Init();   // Leds on PC8 and PC9

	TIM3_Init();  // Setup 1msec count down timer
	TIM15_Init(); // Setup usec count down timer

	LED1OFF;  // Turn LEDs off
	LED0OFF;

	USART3_Init(38400);  // Setup USART3
}

void Printf_RCC_Clocks(void)
{
	RCC_ClocksTypeDef RCC_Clocks;
	RCC_GetClocksFreq(&RCC_Clocks);

	printf("\n\rRCC Clocks\n\r");
	printf("RCC_Clocks->SYSCLK_Frequency = %ld\n\r",RCC_Clocks.SYSCLK_Frequency);
	printf("RCC_Clocks->USBCLK_Frequency = %ld\n\r>",RCC_Clocks.USBCLK_Frequency);
}

int InitGpio()
{
	GPIO_InitTypeDef GPIO_InitStructure;

	RCC_AHBPeriphClockCmd(	RCC_AHBPeriph_GPIOA | RCC_AHBPeriph_GPIOB , ENABLE);



	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;

	//GPIOA OUT
	GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_8 | GPIO_Pin_9 ;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	//GPIOB OUT
	GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_All; //all 16 pin are out
	GPIO_Init(GPIOB, &GPIO_InitStructure);


	return 0;
}

// Work begins here
int main(void)
{
	char inchar;
	int intchar;
	float a,b,c;

	// Initialize all basic functions
	Short_Init();
	InitGpio();
	//STMF072_Init();

	// Fire up the USB CDC subsystem
	USBD_Init(&USB_Device_dev,
	            &USR_desc,
	            &USBD_CDC_cb,
	            &USR_cb);


	while(1) {

		ApiTaskCommunicationReceivePC();
#if 0
		//intchar = GetCharnw();
		if(intchar==-1)
		{
			inchar = 0;
		}
		else
		{
			GPIOA->BRR = GPIO_Pin_8 | GPIO_Pin_9;
			GPIOB->BRR = GPIO_Pin_All;
			inchar = intchar;
			printf("%d\r\n",inchar);

		}

		switch(inchar)
		{
			case '0':
				GPIOA->BSRR |= GPIO_Pin_8;
				break;
			case '1':
				GPIOA->BSRR |= GPIO_Pin_9;
				break;
			case '2':
				GPIOB->BSRR |= GPIO_Pin_2;
				break;
			case '3':
				GPIOB->BSRR |= GPIO_Pin_3;
				break;
			case '4':
				GPIOB->BSRR |= GPIO_Pin_4;
				break;
			case '5':
				GPIOB->BSRR |= GPIO_Pin_5;
				break;
			case '6':
				GPIOB->BSRR |= GPIO_Pin_6;
				break;
			case '7':
				GPIOB->BSRR |= GPIO_Pin_7;
				break;
			case '8':
				GPIOB->BSRR |= GPIO_Pin_8;
				break;
			case '9':
				GPIOB->BSRR |= GPIO_Pin_9;
				break;
			case 'a':
				GPIOB->BSRR |= GPIO_Pin_10;
				break;
			case 'b':
				GPIOB->BSRR |= GPIO_Pin_11;
				break;
			case 'c':
				GPIOB->BSRR |= GPIO_Pin_12;
				break;
			case 'd':
				GPIOB->BSRR |= GPIO_Pin_13;
				break;
			case 'e':
				GPIOB->BSRR |= GPIO_Pin_14;
				break;
			case 'f':
				GPIOB->BSRR |= GPIO_Pin_15;
				break;
			}
#endif
		Toggle_Leds(100,200);
		}
}
