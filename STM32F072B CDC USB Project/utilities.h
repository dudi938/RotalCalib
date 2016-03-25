/*
 * utilities.h
 *
 *  Created on: May 5, 2015
 *      Author: roy
 */

#ifndef UTILITIES_H_
#define UTILITIES_H_


#include "include_all_headers.h"


#define MILISEC_IN_SECOND 1000


typedef struct __TimeStamp
{
	volatile uint32_t seconds;
	volatile uint16_t mili;
}TimeStamp;

void DelayMs( int delay);
TimeStamp* UtilitiesGetSystemClock(void);
void UtilitiesDelayMs( int delay);
void UtilitiesIncMiliSysTick(void);
bool UtilitiesCheckTimeout( TimeStamp* start, uint32_t miliSecondTimeout);
uint32_t UtilitiesDeltaTotalMiliSeconds( TimeStamp* start );
uint8_t UtilitiesCheckSum(uint8_t* data, uint16_t length);
uint32_t UtilitiesIsqrt( uint32_t num );
short UtilitiesArcTan2( int x , int y );
#endif /* UTILITIES_H_ */
