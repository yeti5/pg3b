/*
 ********************************************************************************
 * Copyright (c) 2009 Richard Burke
 * All rights reserved.
 *
 * This module handles the USB interface, overall system configuration and
 * initialization. The scheduler TASK_LIST is defined here and scheduling is
 * started at the end of the initialization sequence.
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
 * $Rev: 227 $
 * $Author: rburke $
 * $LastChangedDate: 2009-11-27 21:37:10 -0500 (Fri, 27 Nov 2009) $
 ********************************************************************************
 */
#include <avr/io.h>
#include <avr/wdt.h>
#include <avr/power.h>
#include <avr/pgmspace.h>
#include <avr/interrupt.h>
#include <util/delay.h>

#include "usb_serial.h"
#include "RingBuffer.h"
#include "XBox360Controller.h"
#include "KeyboardDriver.h"
#include "MouseDriver.h"
#include "XBoxDriver.h"
#include "UsbDriver.h"
#include "EventAction.h"
#include "System.h"
#include "Profile.h"

/*
 ********************************************************************************
 * Local Functions and Variables
 ********************************************************************************
 */
static void ExecuteCommand( uint8_t *buffer, uint8_t size );
static uint8_t ReceiveString( uint8_t *buffer, uint8_t size );
static void DoWhileIdle( void );
static void EnableDataCollection( uint8_t collection );
static void WriteEeprom( uint8_t page, uint8_t *data );
void main( void ) __attribute__ ((noreturn));

system_t Configuration;

#define CPU_PRESCALE(n) (CLKPR = 0x80, CLKPR = (n))

/*
 ********************************************************************************
 * DoWhileIdle
 ********************************************************************************
 */
static void DoWhileIdle( void )
{
    KB_EventTask( );
//  MS_EventTask( );
}

/*
 ********************************************************************************
 * main
 ********************************************************************************
 */
void main( void )
{
    uint8_t buffer[128];

    /* Disable watchdog if enabled by bootloader/fuses */
    MCUSR &= ~(1 << WDRF);
    wdt_disable();

    /* Disable clock division */
    CPU_PRESCALE(0);

    // Don't log data to the USB port
    EnableDataCollection( 0 );

    /* Initialize Keyboard Driver */
    KB_Init();

    /* Initialize Mouse Driver */
    MS_Init();

    /* Initialize XBox Driver */
    XB_Init( );

    sei( );

    usb_init( );
    while( ! usb_configured( ) ) 
        DoWhileIdle( );
    _delay_ms( 1000 );

    while( 1 )
    {
        // wait for the user to run their terminal emulator program
        // which sets DTR to indicate it is ready to receive.
        while ( ! ( usb_serial_get_control( ) & USB_SERIAL_DTR ) )
            DoWhileIdle( );

        // discard anything that was received prior.  Sometimes the
        // operating system or other software will send a modem
        // "AT command", which can still be buffered.
        usb_serial_flush_input();

        // Listen for commands and process them
        while( 1 )
        {
            uint8_t size = ReceiveString( buffer, sizeof( buffer ) );
            if( size == 255 ) break;
            ExecuteCommand( buffer, size );
        }
    }
}

/*
 ****************************************************************************************************
 * ReceiveString
 *
 * Receive a string from the USB serial port.  The string is stored
 * in the buffer and this function will not exceed the buffer size.
 * A carriage return or newline completes the string, and is not
 * stored into the buffer.
 *
 * The return value is the number of characters received, or 255 if
 * the virtual serial connection was closed while waiting.
 ****************************************************************************************************
 */
static uint8_t ReceiveString( uint8_t *buffer, uint8_t size )
{
    int16_t r;
    uint8_t count = 0;

    while( count < size )
    {
        while( usb_serial_available( ) == 0 )
            DoWhileIdle( );
        r = usb_serial_getchar( );
        if( r == -1 )
        {
            if( ! usb_configured( ) || ! ( usb_serial_get_control( ) & USB_SERIAL_DTR ) )
                return 255; // user no longer connected
        }
        else
        {
            if( r == '\r' || r == '\n')
                return count;
            if ( r >= ' ' && r <= '~' )
            {
                *buffer++ = r;
                count++;
            }
        }
    }

    return count;
}

/*
 ****************************************************************************************************
 * Hexadecimal to Binary Convertion Functions (no error checking ... pass in a valid string or
 * experience bad mojo.
 ****************************************************************************************************
 */
static inline uint8_t nibble( uint8_t *digits )
{
    if( *digits > '9' )
        return *digits - 'A' + 10;

    return *digits - '0';
}

static inline uint8_t byte( uint8_t *digits  )
{
    return ( nibble( digits ) << 4 ) + nibble( digits + 1 );
}

static inline uint16_t word( uint8_t *digits )
{
    return ( byte( digits ) << 8 ) + byte( digits + 2 );
}

/*
 ****************************************************************************************************
 * Reads a command from the Rx_Buffer of the form: X [SSSS] [A|E] [VVVV]\r where,
 *       X: Offset 0: Literal 'X' character meaning eXecute command;
 *    SSSS: Offset 2: Sequence identifier with four ASCII characters. It must have 4 characters.
 *   A | E: Offset 7: Literal 'A' for action code, or literal 'E' for event code.
 *    VVVV: Offset 9: EVA action or event code (0000 - FFFF). It must have 4 digits.
 *      \r: Offset 13: Literal ASCII CR 0x0D (13)
 *  Filler: Offsets 1, 6, 8: Any ASCII character but spaces are more readable.
 * Example: X 5A5A A 000D\r
 *
 * Acknowledge is sent in response: X [SSSS] OK\r
 *       X: Offset 0: Literal 'X' character meaning eXecute command;
 *    SSSS: Offset 2: Sequence identifier with four ASCII characters. Whatever was given in the command.
 *    OK\r: Offset 7: Literal "OK\r".
 * Example: X 5A5A OK\r
 *
 * Acknowledgement means the command was received. It does not mean the command completed successfully.
 * The command may invoke a sequence of actions including delays and timers. It is up to the action
 * sequence to report state and completion codes.
 ****************************************************************************************************
 */
static void ExecuteCommand( uint8_t *buffer, uint8_t size )
{
    uint8_t command = *( buffer + 7 );
    uint16_t word0 = word( buffer + 9 );
    uint8_t byte0 = byte( buffer + 9 );

    if( buffer[0] != 'X' )
        return;

    buffer[7] = 'O';
    buffer[8] = 'K';
    buffer[9] = '\n';
    usb_serial_write( buffer, 10 );

    switch( command )
    {
        case 'A': EVA_PerformAction( word0 ); break;
        case 'C': XB_EnableCalibration( byte0 ); break;
        case 'D': EnableDataCollection( byte0 ); break;
        case 'E': EVA_InvokeEventAction( word0 ); break;
        case 'F': MS_SetFrequency( byte0 ); break;
        case 'G': XB_SetIsWireless( byte0 ); break;
        case 'R': MS_SetResolution( byte0 ); break;
        case 'S': MS_SetScaling( byte0 ); break;
        case 'P': PROF_Initialize( ); break;
        case 'Q': PROF_Finalize( ); break;
        case 'W': WriteEeprom( byte0, buffer + 11 ); break;
    }
}

/*
 ********************************************************************************
 * EnableDataCollection
 *
 * This function sets or clears the datacollection flag. When enabled, debug
 * events are reported to the USB port.
 ********************************************************************************
 */
static void EnableDataCollection( uint8_t collection )
{
    Configuration.datacollection = collection > 0;
}

/*
 ****************************************************************************************************
 * WriteEeprom
 ****************************************************************************************************
 */
static void WriteEeprom( uint8_t page, uint8_t *data )
{
    static const uint8_t crcTable[] PROGMEM = {
        0x00, 0x31, 0x62, 0x53, 0xC4, 0xF5, 0xA6, 0x97,
        0xB9, 0x88, 0xDB, 0xEA, 0x7D, 0x4C, 0x1F, 0x2E,
        0x43, 0x72, 0x21, 0x10, 0x87, 0xB6, 0xE5, 0xD4,
        0xFA, 0xCB, 0x98, 0xA9, 0x3E, 0x0F, 0x5C, 0x6D,
        0x86, 0xB7, 0xE4, 0xD5, 0x42, 0x73, 0x20, 0x11,
        0x3F, 0x0E, 0x5D, 0x6C, 0xFB, 0xCA, 0x99, 0xA8,
        0xC5, 0xF4, 0xA7, 0x96, 0x01, 0x30, 0x63, 0x52,
        0x7C, 0x4D, 0x1E, 0x2F, 0xB8, 0x89, 0xDA, 0xEB,
        0x3D, 0x0C, 0x5F, 0x6E, 0xF9, 0xC8, 0x9B, 0xAA,
        0x84, 0xB5, 0xE6, 0xD7, 0x40, 0x71, 0x22, 0x13,
        0x7E, 0x4F, 0x1C, 0x2D, 0xBA, 0x8B, 0xD8, 0xE9,
        0xC7, 0xF6, 0xA5, 0x94, 0x03, 0x32, 0x61, 0x50,
        0xBB, 0x8A, 0xD9, 0xE8, 0x7F, 0x4E, 0x1D, 0x2C,
        0x02, 0x33, 0x60, 0x51, 0xC6, 0xF7, 0xA4, 0x95,
        0xF8, 0xC9, 0x9A, 0xAB, 0x3C, 0x0D, 0x5E, 0x6F,
        0x41, 0x70, 0x23, 0x12, 0x85, 0xB4, 0xE7, 0xD6,
        0x7A, 0x4B, 0x18, 0x29, 0xBE, 0x8F, 0xDC, 0xED,
        0xC3, 0xF2, 0xA1, 0x90, 0x07, 0x36, 0x65, 0x54,
        0x39, 0x08, 0x5B, 0x6A, 0xFD, 0xCC, 0x9F, 0xAE,
        0x80, 0xB1, 0xE2, 0xD3, 0x44, 0x75, 0x26, 0x17,
        0xFC, 0xCD, 0x9E, 0xAF, 0x38, 0x09, 0x5A, 0x6B,
        0x45, 0x74, 0x27, 0x16, 0x81, 0xB0, 0xE3, 0xD2,
        0xBF, 0x8E, 0xDD, 0xEC, 0x7B, 0x4A, 0x19, 0x28,
        0x06, 0x37, 0x64, 0x55, 0xC2, 0xF3, 0xA0, 0x91,
        0x47, 0x76, 0x25, 0x14, 0x83, 0xB2, 0xE1, 0xD0,
        0xFE, 0xCF, 0x9C, 0xAD, 0x3A, 0x0B, 0x58, 0x69,
        0x04, 0x35, 0x66, 0x57, 0xC0, 0xF1, 0xA2, 0x93,
        0xBD, 0x8C, 0xDF, 0xEE, 0x79, 0x48, 0x1B, 0x2A,
        0xC1, 0xF0, 0xA3, 0x92, 0x05, 0x34, 0x67, 0x56,
        0x78, 0x49, 0x1A, 0x2B, 0xBC, 0x8D, 0xDE, 0xEF,
        0x82, 0xB3, 0xE0, 0xD1, 0x46, 0x77, 0x24, 0x15,
        0x3B, 0x0A, 0x59, 0x68, 0xFF, 0xCE, 0x9D, 0xAC
    };

    uint8_t buffer[EEPROM_PAGE_SIZE];
    uint8_t crc8 = 0xFF;

    for( uint8_t i = 0; i < sizeof(buffer); i++ )
    {
        uint8_t value = byte( data + ( i << 1 ) );
        crc8 = pgm_read_byte( &crcTable[(crc8 ^ value)] );
        buffer[i] = value;
    }

//    if( crc8 == byte( data + ( sizeof(buffer) << 1 ) ) )
//        eeprom_write_block( buffer, (void *)( page * sizeof( buffer ) ), sizeof( buffer ) );
}

/*
 ****************************************************************************************************
 * LogByte
 ****************************************************************************************************
 */
static uint8_t hex4digit( uint8_t data )
{
    data &= 0x0F;
    return data + ( ( data < 10 )? '0' : 'A' - 10 );
}

uint8_t LogByte( uint8_t prefix, uint8_t data )
{
    if( Configuration.datacollection )
    {
        usb_serial_putchar( prefix );
        usb_serial_putchar( ' ' );
        usb_serial_putchar( hex4digit( data >> 4 ) );
        usb_serial_putchar( hex4digit( data ) );
        usb_serial_putchar( '\n' );
    }

    return data;
}

/*
 ****************************************************************************************************
 * LogWord
 ****************************************************************************************************
 */
uint16_t LogWord( uint8_t prefix, uint16_t data )
{
    if( Configuration.datacollection )
    {
        usb_serial_putchar( prefix );
        usb_serial_putchar( ' ' );
        usb_serial_putchar( hex4digit( data >> 12 ) );
        usb_serial_putchar( hex4digit( data >> 8 ) );
        usb_serial_putchar( hex4digit( data >> 4 ) );
        usb_serial_putchar( hex4digit( data ) );
        usb_serial_putchar( '\n' );
    }

    return data;
}
