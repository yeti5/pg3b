/*
 ********************************************************************************
 * Profile.c
 *
 * Copyright (C) 2009 Richard Burke
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * * Redistributions of source code must retain the above copyright
 *   notice, this list of conditions and the following disclaimer.
 *
 * * Redistributions in binary form must reproduce the above copyright
 *   notice, this list of conditions and the following disclaimer in
 *   the documentation and/or other materials provided with the
 *   distribution.
 *
 * * Neither the name of the copyright holders nor the names of
 *   contributors may be used to endorse or promote products derived
 *   from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 * $Rev: 223 $
 * $Author: rburke $
 * $Date: 2009-11-27 01:31:22 -0500 (Fri, 27 Nov 2009) $
 *
 ********************************************************************************
 */
#include <stdint.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/pgmspace.h>
#include "Profile.h"

#ifdef ENABLE_PROFILE
static volatile uint16_t profile_overflow;
static uint8_t  profile_enabled;
static uint32_t profile_count;
static uint32_t profile_time;
static uint32_t profile_min;
static uint32_t profile_max;
static uint64_t profile_total;
#endif

/*
 ********************************************************************************
 * PROF_Initialize
 ********************************************************************************
 */
void PROF_Initialize( void )
{
	#ifdef ENABLE_PROFILE
	TCCR0A =	( 0 << COM0A1 ) |	// Normal port operation, OC0A disconnected.
				( 0 << COM0A0 ) |
				( 0 << COM0B1 ) |	// Normal port operation, OC0B disconnected.
				( 0 << COM0B0 ) |
				( 0 << WGM01 ) |	// Normal, TOP = 0xFF, Update 0CR0 at Immediate, TOV = MAX
				( 0 << WGM00 );
	TCCR0B =	( 0 << WGM02 ) |	// Normal, TOP = 0xFF, Update 0CR0 at Immediate, TOV = MAX
				( 0 << CS02 ) |		// No Clock.
				( 0 << CS01 ) |
				( 0 << CS00 );
	TIMSK0 =	( 0 << OCIE0B ) |	// Compare Match B Interrupt Disable
				( 0 << OCIE0A )	|	// Compare Match A Interrupt Disable
				( 1 << TOIE0 );		// Overflow Interrupt Enable
	TIFR0 =		( 0 << OCF0B ) |	// Ignore Timer/Counter 0 Compare B Match Flag
				( 0 << OCF0A ) |	// Ignore Timer/Counter 0 Compare A Match Flag
				( 1 << TOV0 );		// Clear Timer/Counter0 Overflow Flag

	profile_overflow = 0;
	profile_enabled = 1;
	profile_count = 0;
	profile_time = 0;
	profile_min = UINT32_MAX;
	profile_max = 0;
	profile_total = 0;
	
	#endif
}

/*
 ********************************************************************************
 * PROF_Prologue
 ********************************************************************************
 */
void PROF_Prologue( void )
{
	#ifdef ENABLE_PROFILE
	if( profile_enabled )
	{
		profile_count++;
		profile_overflow = 0;
		TCNT0 =	0;
		TCCR0B =	( 0 << WGM02 ) |	// Normal, TOP = 0xFF, Update 0CR0 at Immediate, TOV = MAX
					( 0 << CS02 ) |		// Prescale clkIO/8 (From prescaler), 1MHz
					( 1 << CS01 ) |
					( 0 << CS00 );
	}
	#endif
}

/*
 ********************************************************************************
 * PROF_Epilogue
 ********************************************************************************
 */
void PROF_Epilogue( void )
{
	#ifdef ENABLE_PROFILE
	if( profile_enabled )
	{
		TCCR0B =	( 0 << WGM02 ) |	// Normal, TOP = 0xFF, Update 0CR0 at Immediate, TOV = MAX
					( 0 << CS02 ) |		// No clock.
					( 0 << CS01 ) |
					( 0 << CS00 );

		profile_time = profile_overflow << 8 | TCNT0;
		if( profile_time > profile_max )
			profile_max = profile_time;
		if( profile_time < profile_min )
			profile_min = profile_time;
		profile_total += profile_time;
	}
	#endif
}

/*
 ********************************************************************************
 * Hex ASCII Functions
 ********************************************************************************
 */
#ifdef ENABLE_PROFILE

static char *hexuint4( char *string, uint8_t uint4 )
{
	uint4 &= 0x0F;
	*string = ( uint4 > 9 )? uint4 + 'A' - 10 : uint4 + '0';

	return string;
}

static char *hexuint8( char *string, uint8_t uint8 )
{
	hexuint4( string, uint8 >> 4 );
	hexuint4( string + sizeof(uint8_t), uint8 );
	string[sizeof(uint8_t) << 1] = '\0';

	return string;
}

static char *hexuint16( char *string, uint16_t uint16 )
{
	hexuint8( string, uint16 >> 8 );
	hexuint8( string + sizeof(uint16_t), uint16 );
	string[sizeof(uint16_t) << 1] = '\0';

	return string;
}

static char *hexuint32( char *string, uint32_t uint32 )
{
	hexuint16( string, uint32 >> 16 );
	hexuint16( string + sizeof(uint32_t), uint32 );
	string[sizeof(uint32_t) << 1] = '\0';

	return string;
}

static char *hexuint64( char *string, uint64_t uint64 )
{
	hexuint32( string, uint64 >> 32 );
	hexuint32( string + sizeof(uint64_t), uint64 );
	string[sizeof(uint64_t) << 1] = '\0';

	return string;
}

static void String( char *string )
{
	while( *string )
		usb_serial_putchar( *string++ );
}

static void P_String( char *string )
{
	while( pgm_read_byte( string ) )
		usb_serial_putchar( pgm_read_byte( string++ ) );
}

#endif

/*
 ********************************************************************************
 * PROF_Finalize
 ********************************************************************************
 */
void PROF_Finalize( void )
{
	#ifdef ENABLE_PROFILE
	char buffer[( sizeof(uint64_t) << 2 ) + 1];

	profile_enabled = 0;

	P_String( PSTR( "\n    Count : " ) ); String( hexuint32( buffer, profile_count ) );
	P_String( PSTR( "\nLast Time : " ) ); String( hexuint32( buffer, profile_time ) );
	P_String( PSTR( "\n      Min : " ) ); String( hexuint32( buffer, profile_min ) );
	P_String( PSTR( "\n      Max : " ) ); String( hexuint32( buffer, profile_max ) );
	P_String( PSTR( "\n    Total : " ) ); String( hexuint64( buffer, profile_total ) );
	P_String( PSTR( "\n" ) );
	#endif
}

/*
 ********************************************************************************
 * TIMER0_OVF_vect
 ********************************************************************************
 */
#ifdef ENABLE_PROFILE
ISR( TIMER0_OVF_vect )
{
	profile_overflow++;
}
#endif
