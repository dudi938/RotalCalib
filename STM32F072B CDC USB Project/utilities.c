#include "include_all_headers.h"


/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
#define BITSPERINT 32
#define TOP2BITS(x) ((x & (3L << (BITSPERINT-2))) >> (BITSPERINT-2))
#define ARCTAN_LOOKUP_TABLE_SIZE 		67
#define ARCTAN_RESOLUTION				 (0.015f)

uint8_t arcTan[ARCTAN_LOOKUP_TABLE_SIZE] =
{
  1,  2,  3,  3,  4,  5,  6,  7,  8,  9,  9, 10, 11, 12, 13, 13, 14, 15, 16, 17, 17, 18, 19, 20, 21,
 21, 22, 23, 24, 24, 25, 26, 26, 27, 28, 28, 29, 30, 30, 31, 32, 32, 33, 33, 34, 35, 35, 36, 36, 37,
 37, 38, 38, 39, 40, 40, 41, 41, 42, 42, 42, 43, 43, 44, 44, 45, 45
};

/* Private macro -------------------------------------------------------------*/    
/* Private variables ---------------------------------------------------------*/
/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/

static TimeStamp sSystemClock = {0,0};
static volatile long ticks;


//***************  SystemClk functions ************* //

void DelayMs( int delay)
{
	volatile long start = ticks;
	while( start + delay > ticks );
}

void UtilitiesIncMiliSysTick(void)
{
	sSystemClock.mili++ ;
	ticks++;

	if(sSystemClock.mili == 1000)
	{
		sSystemClock.seconds++;
		sSystemClock.mili = 0 ;
		
	 }
}

TimeStamp* UtilitiesGetSystemClock(void)
{
	return &sSystemClock;
}

void UtilitiesDelayMs( int delay)
{
	TimeStamp start = sSystemClock;
	while(1)
	{
		if((sSystemClock.seconds-start.seconds)*MILISEC_IN_SECOND + sSystemClock.mili-start.mili > delay)
		{
			break;
		}
	}
}

bool UtilitiesCheckTimeout( TimeStamp* start, uint32_t miliSecondTimeout)
{
	volatile int32_t val = ((sSystemClock.seconds- start->seconds)*MILISEC_IN_SECOND) + sSystemClock.mili - start->mili;
	return (bool)(val >= miliSecondTimeout); 
}

uint32_t UtilitiesDeltaTotalMiliSeconds( TimeStamp* start )
{
	return ((sSystemClock.seconds- start->seconds)*MILISEC_IN_SECOND) + sSystemClock.mili - start->mili;
}

uint8_t UtilitiesCheckSum(uint8_t* data, uint16_t length)
{
	uint16_t i;
	uint32_t sum;

	//initialize variables
	sum = 0;

	//calculate checksum
	for(i=0; i<length; i++)
		sum += data[i];

	return((uint8_t)(~sum));
}

uint32_t UtilitiesIsqrt( uint32_t num )
{
    volatile uint32_t res = 0;
    volatile uint32_t bit = 1 << 30;
 
    // "bit" starts at the highest power of four <= the argument.
    while(bit > num)
		{
        bit >>= 2;
		} 
    
		while(bit != 0)
		{
        if (num >= res + bit) 
				{
           num -= res + bit;
           res = (res >> 1) + bit;
        }
        else
				{
            res >>= 1;
				}
        bit >>= 2;
    }
    return res;
}
#if 0
short UtilitiesArcTan2( int x , int y )
{
		volatile float proportion = fabs( (float)x / (float)y );
		volatile short deg;
		volatile char index;
		if( proportion < ARCTAN_RESOLUTION ) 
		{
				if( x == 0 && y > 0 ) return 90;
				if( x == 0 && y < 0 ) return -90;
		}
		else
		{
			index = (char)(proportion / ARCTAN_RESOLUTION);
			deg = arcTan[ index ];
			if( x > 0 )
			{				
				return deg;
			}
			else
			{
				if(y >= 0 )
				{
					return deg + 180;
				}
				else
				{
					return deg - 180;
				}
			}
		}
}
#endif
