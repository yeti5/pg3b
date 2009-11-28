/*
 ********************************************************************************
 * UsbDriver.h
 *
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
 * $Rev: 155 $
 * $Author: rburke $
 * $LastChangedDate: 2009-09-23 13:10:11 -0400 (Wed, 23 Sep 2009) $
 ********************************************************************************
 */
#ifndef __USBDRIVER_H__
#define __USBDRIVER_H__

/*
 ****************************************************************************************************
 * USB Events
 *
 *   ,----------------------------------------------------  Device : Usb
 *   |             ,-------------------------------------- Trigger : UsbTrigger_t
 *   v             v             v------------------------   Value : UsbValue_t
 *  ------------- ------------- ------------- -------------
 * | D3 D2 D1 D0 | T3 T2 T1 T0 | V7 V6 V5 V4 | V3 V2 V1 V0 |
 *  ------------- ------------- ------------- -------------
 * |            Key            |         Value             |
 *  --------------------------- ---------------------------
 *
 ****************************************************************************************************
 */

// USB Events
#define USB_Control(c,v)		EVA_NewAction( EVA_NewActionKey( Usb, ( c ) ), ( v ) )
#define USB_ButtonPress(b)		EVA_NewAction( EVA_NewActionKey( Usb, XKeyPress ), (b) )
#define USB_ButtonRelease(b)	EVA_NewAction( EVA_NewActionKey( Usb, XKeyRelease ), (b) )
#define USB_FindByKey(v)		( ( EVA_EventDevice(v) == Usb )? ( EVA_EventTrigger(v) <= RightTrigger ) : 0 )

#endif
