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
 * $Rev: 224 $
 * $Author: rburke $
 * $LastChangedDate: 2009-11-27 01:34:22 -0500 (Fri, 27 Nov 2009) $
 ********************************************************************************
 */
using System;
using System.Text;
using System.IO.Ports;
using Microsoft.Xna.Framework.Input;

namespace PG3B.Interface
{
    public enum XBoxButtonState { Pressed, Released }

    public enum Device_t { Null, Keyboard, Mouse, Usb, XBox, Arcade, Joystick, Script };
    public enum XBTarget_t { LeftStickX, LeftStickY, RightStickX, RightStickY, LeftTrigger, RightTrigger, XKeyPress, XKeyRelease };
    public enum XBButton_t { AButton, BButton, XButton, YButton, UpPad, DownPad, LeftPad, RightPad, LeftShoulderButton, RightShoulderButton, LeftStickButton, RightStickButton, StartButton, GuideButton, BackButton };

    public class XBoxController
    {
        private XBoxConnection xboxConnection;
        private XBoxButtons xboxButtons;
        private XBoxDPad xboxDPad;
        private XBoxTriggers xboxTriggers;
        private XBoxThumbSticks xboxThumbSticks;
        private bool calibrationEnabled;
        private bool isWireless;

        public bool IsConnected { get { return xboxConnection.IsConnected; } }
        public int PacketNumber { get { return xboxConnection.PacketNumber; } }
        public bool CalibrationEnabled { get { return calibrationEnabled; } set { calibrationEnabled = value; xboxConnection.SetCalibration(value); } }
        public bool IsWireless { get { return isWireless; } set { isWireless = value; xboxConnection.SetGamePadIsWireless(value); } }

        public XBoxButtons Buttons { get { return xboxButtons; } }
        public XBoxDPad DPad { get { return xboxDPad; } }
        public XBoxTriggers Triggers { get { return xboxTriggers; } }
        public XBoxThumbSticks ThumbSticks { get { return xboxThumbSticks; } }

        public XBoxController(string portName)
        {
            xboxConnection = new XBoxConnection(portName);
            xboxButtons = new XBoxButtons(xboxConnection);
            xboxDPad = new XBoxDPad(xboxConnection);
            xboxTriggers = new XBoxTriggers(xboxConnection);
            xboxThumbSticks = new XBoxThumbSticks(xboxConnection);
            CalibrationEnabled = false;
            IsWireless = false;
        }
    }

    public class XBoxButtons
    {
        private XBoxConnection xboxConnection;

        public XBoxButtonState A { set { xboxConnection.SetButton(XBButton_t.AButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState B { set { xboxConnection.SetButton(XBButton_t.BButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState X { set { xboxConnection.SetButton(XBButton_t.XButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Y { set { xboxConnection.SetButton(XBButton_t.YButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Back { set { xboxConnection.SetButton(XBButton_t.BackButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Start { set { xboxConnection.SetButton(XBButton_t.StartButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState BigButton { set { xboxConnection.SetButton(XBButton_t.GuideButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState LeftShoulder { set { xboxConnection.SetButton(XBButton_t.LeftShoulderButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState RightShoulder { set { xboxConnection.SetButton(XBButton_t.RightShoulderButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState LeftStick { set { xboxConnection.SetButton(XBButton_t.LeftStickButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState RightStick { set { xboxConnection.SetButton(XBButton_t.RightStickButton, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }

        public XBoxButtons(XBoxConnection _xboxConnection)
        {
            xboxConnection = _xboxConnection;
        }
    }

    public class XBoxDPad
    {
        private XBoxConnection xboxConnection;

        public XBoxButtonState Up { set { xboxConnection.SetButton(XBButton_t.UpPad, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Down { set { xboxConnection.SetButton(XBButton_t.DownPad, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Left { set { xboxConnection.SetButton(XBButton_t.LeftPad, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }
        public XBoxButtonState Right { set { xboxConnection.SetButton(XBButton_t.RightPad, value == XBoxButtonState.Pressed ? XBTarget_t.XKeyPress : XBTarget_t.XKeyRelease); } }

        public XBoxDPad(XBoxConnection _xboxConnection)
        {
            xboxConnection = _xboxConnection;
        }
    }

    public class XBoxTriggers
    {
        private XBoxConnection xboxConnection;

        public float Left { set {  xboxConnection.SetTrigger(XBTarget_t.LeftTrigger, value); } }
        public float Right { set { xboxConnection.SetTrigger(XBTarget_t.RightTrigger, value); } }

        public XBoxTriggers(XBoxConnection _xboxConnection)
        {
            xboxConnection = _xboxConnection;
        }
    }

    public class XBoxThumbSticks
    {
        private XBoxConnection xboxConnection;
        private XBoxVector2 leftThumbStick;
        private XBoxVector2 rightThumbStick;

        public XBoxVector2 Left { get { return leftThumbStick; } }
        public XBoxVector2 Right { get { return rightThumbStick; } }

        public XBoxThumbSticks(XBoxConnection _xboxConnection)
        {
            xboxConnection = _xboxConnection;
            leftThumbStick = new XBoxVector2(xboxConnection, XBTarget_t.LeftStickX, XBTarget_t.LeftStickY);
            rightThumbStick = new XBoxVector2(xboxConnection, XBTarget_t.RightStickX, XBTarget_t.RightStickY);
        }
    }

    public class XBoxVector2
    {
        private XBoxConnection xboxConnection;
        private XBTarget_t targetCodeX;
        private XBTarget_t targetCodeY;

        public float X { set { xboxConnection.SetThumbStick(targetCodeX, value); } }
        public float Y { set { xboxConnection.SetThumbStick(targetCodeY, value); } }

        public XBoxVector2(XBoxConnection _xboxConnection, XBTarget_t _targetCodeX, XBTarget_t _targetCodeY)
        {
            xboxConnection = _xboxConnection;
            targetCodeX = _targetCodeX;
            targetCodeY = _targetCodeY;
        }
    }
    
    public class XBoxConnection
    {
        private SerialPort serialPort;
        private Int16 sequenceNumber;

        public bool IsConnected { get { return PingController(); } }
        public int PacketNumber { get { return sequenceNumber; } }

        public XBoxConnection(string portName)
        {
            try
            {
                OpenSerialPort(portName);
            }
            catch
            {
                CloseSerialPort();
            }
        }

        private void OpenSerialPort(string portName)
        {
            OpenSerialPort(portName, 100);
        }

        private void OpenSerialPort(string portName, int timeout)
        {
            serialPort = new SerialPort(portName, 230400, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.None;
            serialPort.WriteTimeout = timeout;
            serialPort.ReadTimeout = timeout;
            serialPort.NewLine = "\n";
            serialPort.Open();
            serialPort.DtrEnable = true;
        }

        private void CloseSerialPort()
        {
            if (serialPort != null)
                serialPort.Close();
            serialPort = null;
        }

        private bool PingController()
        {
            bool reply = false;

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    Command('D', 0);    // 'D'ebug Messages Enabled <boolean>
                    reply = true;
                }
            }
            catch
            {
            }

            return reply;
        }

        private void Command(char commandCode, int commandArgument)
        {
            Primitive(commandCode, commandArgument, 2);
        }

        private void Action(int actionCode)
        {
            Primitive('A', actionCode, 4);  // 'A'ction <actionCode>
        }

        private void Primitive(char commandCode, int commandArgument, int argumentSize)
        {
            serialPort.DiscardInBuffer();

            string actionString = (argumentSize == 2) ?
                String.Format("X {0:X4} {1} {2:X2}\r", sequenceNumber, commandCode, commandArgument) :
                String.Format("X {0:X4} {1} {2:X4}\r", sequenceNumber, commandCode, commandArgument);

            byte[] actionBytes = Encoding.ASCII.GetBytes(actionString);
            serialPort.Write(actionBytes, 0, actionBytes.Length);

            string responseString;
            do
            {
                responseString = serialPort.ReadLine();
            } while (responseString != String.Format("X {0:X4} OK", sequenceNumber));

            sequenceNumber++;
        }

        private Int16 EVA_NewAction(Int16 k, Int16 v)
        {
            return ((Int16)((k)|(v)));
        }

        private Int16 EVA_NewActionKey(Int16 d,Int16 t)
        {
            return ((Int16)(((d)<<12)|((t)<<8)));
        }

        private Int16 EVA_NewActionValue(Int16 v)
        {
            return ((Int16)(v));
        }

        public void SetButton(XBButton_t buttonCode, XBTarget_t buttonState)
        {
            Int16 actionKey = EVA_NewActionKey((Int16)Device_t.XBox, (Int16)buttonState);
            Int16 actionCode = EVA_NewAction((Int16)actionKey, (Int16)buttonCode);
            Action(actionCode);
        }

        public void SetTrigger(XBTarget_t targetCode, float triggerState)
        {
            float wiperState = triggerState * byte.MaxValue;
            wiperState = (float)byte.MaxValue - wiperState;
            wiperState = Math.Max(wiperState, (float)byte.MinValue);
            wiperState = Math.Min(wiperState, (float)byte.MaxValue);

            Int16 wiperValue = Convert.ToInt16(wiperState);
            Int16 actionKey = EVA_NewActionKey((Int16)Device_t.XBox, (Int16)targetCode);
            Int16 actionCode = EVA_NewAction((Int16)actionKey, (Int16)wiperValue);
            Action(actionCode);
        }

        public void SetThumbStick(XBTarget_t targetCode, float targetState)
        {
            float wiperState = (targetState + 1.0F) / 2 * (float)byte.MaxValue;
            if (targetCode == XBTarget_t.LeftStickX || targetCode == XBTarget_t.RightStickX)
                wiperState = (float)byte.MaxValue - wiperState;
            wiperState = Math.Max(wiperState, (float)byte.MinValue);
            wiperState = Math.Min(wiperState, (float)byte.MaxValue);

            Int16 wiperValue = Convert.ToInt16(wiperState);
            Int16 actionKey = EVA_NewActionKey((Int16)Device_t.XBox, (Int16)targetCode);
            Int16 actionCode = EVA_NewAction((Int16)actionKey, (Int16)wiperValue);
            Action(actionCode);
        }

        public void SetCalibration(bool calibrationEnabled)
        {
            Command('C', calibrationEnabled ? 1 : 0);   // 'C'alibration Enabled <boolean>
        }

        public void SetGamePadIsWireless(bool isWireless)
        {
            Command('G', isWireless ? 1 : 0);           // 'G'amePad IsWireless <boolean>
        }
    }
}
