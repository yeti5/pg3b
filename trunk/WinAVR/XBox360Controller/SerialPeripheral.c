/*
 ********************************************************************************
 * Copyright (c) 2009 Richard Burke
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
 * $Rev: 151 $
 * $Author: rburke $
 * $LastChangedDate: 2009-09-21 14:37:20 -0400 (Mon, 21 Sep 2009) $
 ********************************************************************************
 */
#include <avr/io.h>
#include <util/delay.h>
#include "Libdefs.h"
#include "SerialPeripheral.h"

/*
 ********************************************************************************
 * Configure the chip select lines for MCP42010 A, B, C to output high. The common
 * reset line is configured as an output and toggled low for 500 us. The Reset pin
 * will set all potentiometers to mid-scale (Code 80h).
 ********************************************************************************
 */
void SPI_InitMCP42010( void )
{
    // Set-up SPI SS Pins for MCP42010 A, B, C
    sbi( PORTB, PB4 );      // Set SS MCP42010 A High.
    sbi( PORTB, PB5 );      // Set SS MCP42010 B High.
    sbi( PORTB, PB6 );      // Set SS MCP42010 C High.
    sbi( DDRB, PB4 );       // SS output for MCP42010 A
    sbi( DDRB, PB5 );       // SS output for MCP42010 B
    sbi( DDRB, PB6 );       // SS output for MCP42010 C

    // Set common reset signal for MCP42010 A, B, C to high.
    sbi( PORTB, PB7 );      // Set slave reset to high
    sbi( DDRB, PB7 );       // Set slave reset as output for MCP42010 A, B, C

    // Pull the reset line low for at least 150 ns
    cbi( PORTB, PB7 );      // Reset slave MCP42010 A, B, C. All potentiometers to mid-scale.
    _delay_us( 5 );         // Reset for 500 us
    sbi( PORTB, PB7 );
}

/*
 ********************************************************************************
 * SPI_InitMaster
 ********************************************************************************
 */
void SPI_InitMaster( void )
{
    // Set-up SPI I/O pins
    sbi( PORTB, PB1 );      // set SCK High
    sbi( PORTB, PB0 );      // Set SS High

    sbi( DDRB, PB1 );       // set SCK as output
    cbi( DDRB, PB3 );       // set MISO as input
    sbi( DDRB, PB2 );       // set MOSI as output
    sbi( DDRB, PB0 );       // set SS to output for Master Mode

    // setup SPI interface
    cbi( PRR0, PRSPI );

    // master mode
    sbi( SPCR, MSTR );

    // clock = fosc/2
    cbi( SPCR, SPI2X );
    cbi( SPCR, SPR0 );
    cbi( SPCR, SPR1 );

    // Sample (Rising), Setup (Falling), SPI Mode 0
    cbi( SPCR, CPOL );
    cbi( SPCR, CPHA );

    // Data order MSB first
    cbi( SPCR, DORD );

    // enable SPI
    sbi( SPCR, SPE );

    // clear status
    inb( SPSR );
}

/*
 ********************************************************************************
 * SPI_TransferBits
 ********************************************************************************
 */
uint8_t SPI_TransferBits( uint8_t bit, uint8_t data )
{
    // send the given data
    SPDR = data;

    // wait for transfer to complete
    while( ! ( SPSR & ( 1 << SPIF ) ) )
        ;

    // Return the reply
    return SPDR;
}

/*
 ********************************************************************************
 * SPI_TransferByte
 ********************************************************************************
 */
uint8_t SPI_TransferByte( uint8_t bit, uint8_t txdata )
{
    uint8_t rxdata = 0;

    // Select slave
    cbi( PORTB, bit );	// Set SS Low.
    _delay_us( 12 );

    rxdata = SPI_TransferBits( bit, txdata );

    sbi( PORTB, bit );	// Set SS High.
    _delay_us( 12 );

    // Return the reply
    return rxdata;
}

/*
 ********************************************************************************
 * SPI_TransferBytes
 ********************************************************************************
 */
void SPI_TransferBytes( uint8_t bit, uint8_t byte0, uint8_t byte1 )
{
    // Select slave
    cbi( PORTB, bit );  // Set SS Low.
    _delay_us( 2 );

    // send MS byte of given data
    SPI_TransferBits( bit, byte0 );

    // send LS byte of given data
    SPI_TransferBits( bit, byte1 );

    sbi( PORTB, bit );	// Set SS High.
    _delay_us( 2 );
}
