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
 * $Rev: 231 $
 * $Author: rburke $
 * $LastChangedDate: 2009-11-28 00:12:57 -0500 (Sat, 28 Nov 2009) $
 ********************************************************************************
 */
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using PG3B.Interface;

namespace Pg3bWindowsFormsApplication.SubForm
{
    public partial class TestAndDiagnostics : Form
    {
        private const long iterationsPerTest = 100;
        private const long ticksPerMillisecond = 100000000;
        private const long ticksPerTest = ticksPerMillisecond / iterationsPerTest;
        private const long ticksRoundUp = ticksPerTest / 2;

        private const long expectedRoundTripTime = 16;
        private const long expectedUnicastTime = 6;
        private const float expectedLowTrigger = 0.0F;
        private const float expectedHighTrigger = 1.0F;
        private const float expectedLowThumbstick = -1.0F;
        private const float expectedHighThumbstick = 1.0F;

        private enum PictureBoxStatus { Unknown, Good, Bad };

        delegate void SetButton(XBoxButtonState v);
        delegate Microsoft.Xna.Framework.Input.ButtonState GetButton();

        delegate void SetTrigger(float v);
        delegate float GetTrigger();

        delegate void SetThumbstick(float v);
        delegate float GetThumbstick();

        XBoxController xboxController;
        GamepadController gamepadController;

        public TestAndDiagnostics()
        {
            InitializeComponent();
        }

        private void unicastButtonTest(string buttonName, SetButton setButton, PictureBox pictureBox)
        {
            if (stopButton.Enabled == false)
                return;

            try
            {
                long ticksEpoch = DateTime.Now.Ticks;
                for (int i = 0; i < iterationsPerTest && stopButton.Enabled; i++)
                    setButton(XBoxButtonState.Released);
                long ticksNow = DateTime.Now.Ticks;
                long unicastTime = (ticksNow - ticksEpoch + ticksRoundUp) / ticksPerTest;
                string entryLog = String.Format("{0:G} : {1} Button : Unicast {2} mS{3}", DateTime.Now, buttonName, unicastTime, Environment.NewLine);
                diagnosticsTextBox.AppendText(entryLog);
                SetPictureBoxStatus(pictureBox, unicastTime <= expectedUnicastTime ? PictureBoxStatus.Good : PictureBoxStatus.Bad);
            }
            catch
            {
                SetPictureBoxStatus(pictureBox, PictureBoxStatus.Bad);
            }
        }

        private void roundTripButtonTest(string buttonName, SetButton setButton, GetButton getButton, PictureBox pictureBox)
        {
            if (stopButton.Enabled == false)
                return;

            try
            {
                setButton(XBoxButtonState.Released);
                DateTime timeOut = DateTime.Now.AddMilliseconds(100);
                while (getButton() == Microsoft.Xna.Framework.Input.ButtonState.Pressed && DateTime.Now < timeOut)
                    ;

                long ticksEpoch = DateTime.Now.Ticks;
                for (int i = 0; i < iterationsPerTest && stopButton.Enabled; i++)
                {
                    // Press Key
                    setButton(XBoxButtonState.Pressed);
                    timeOut = DateTime.Now.AddMilliseconds(100);
                    while (getButton() == Microsoft.Xna.Framework.Input.ButtonState.Released && DateTime.Now < timeOut)
                        ;
                    // Release Key
                    setButton(XBoxButtonState.Released);
                    timeOut = DateTime.Now.AddMilliseconds(100);
                    while (getButton() == Microsoft.Xna.Framework.Input.ButtonState.Pressed && DateTime.Now < timeOut)
                        ;
                    Application.DoEvents();
                }
                long ticksNow = DateTime.Now.Ticks;
                long roundTripTime = (ticksNow - ticksEpoch + ticksRoundUp) / ticksPerTest;
                string entryLog = String.Format("{0:G} : {1} Button : Round Trip Time {2} mS{3}", DateTime.Now, buttonName, roundTripTime, Environment.NewLine);
                diagnosticsTextBox.AppendText(entryLog);
                SetPictureBoxStatus(pictureBox, roundTripTime <= expectedRoundTripTime ? PictureBoxStatus.Good : PictureBoxStatus.Bad);
            }
            catch
            {
                SetPictureBoxStatus(pictureBox, PictureBoxStatus.Bad);
            }
        }

        private void testButton(string buttonName, SetButton setButton, GetButton getButton, PictureBox pictureBox)
        {
            roundTripButtonTest(buttonName, setButton, getButton, pictureBox);
            unicastButtonTest(buttonName, setButton, pictureBox);
        }

        private void testTrigger(string buttonName, SetTrigger setTrigger, GetTrigger getTrigger, PictureBox pictureBox)
        {
            if (stopButton.Enabled == false)
                return;

            try
            {
                float minValue = float.MaxValue;
                float maxValue = float.MinValue;
                for (float f = 0.0F; f <= 1.0 && stopButton.Enabled; f += 1.0F / 256.0F)
                {
                    setTrigger(f);
                    Application.DoEvents();
                    Thread.Sleep(16);
                    minValue = Math.Min(minValue, getTrigger());
                    maxValue = Math.Max(maxValue, getTrigger());
                    string entryLog = String.Format("{0:G} : {1} Trigger : Target = {2:F4}, Value = {3:F4}{4}", DateTime.Now, buttonName, f, getTrigger(), Environment.NewLine);
                    diagnosticsTextBox.AppendText(entryLog);
                }
                setTrigger(0.0F);
                string summaryLog = String.Format("{0:G} : {1} Trigger : Min = {2:F4}, Max = {3:F4}{4}", DateTime.Now, buttonName, minValue, maxValue, Environment.NewLine);
                diagnosticsTextBox.AppendText(summaryLog);
                SetPictureBoxStatus(pictureBox, (minValue == expectedLowTrigger && maxValue == expectedHighTrigger) ? PictureBoxStatus.Good : PictureBoxStatus.Bad);
            }
            catch
            {
                SetPictureBoxStatus(pictureBox, PictureBoxStatus.Bad);
            }
        }

        private void testThumbstick(string buttonName, SetThumbstick setThumbstick, GetThumbstick getThumbstick, PictureBox pictureBox)
        {
            if (stopButton.Enabled == false)
                return;

            try
            {
                float minValue = float.MaxValue;
                float maxValue = float.MinValue;
                for (float f = -1.0F; f <= 1.0 && stopButton.Enabled; f += 2.0F / 256.0F)
                {
                    setThumbstick(f);
                    Application.DoEvents();
                    Thread.Sleep(16);
                    minValue = Math.Min(minValue, getThumbstick());
                    maxValue = Math.Max(maxValue, getThumbstick());
                    string entryLog = String.Format("{0:G} : {1} Thumbstick : Target = {2:F4}, Value = {3:F4}{4}", DateTime.Now, buttonName, f, getThumbstick(), Environment.NewLine);
                    diagnosticsTextBox.AppendText(entryLog);
                }
                setThumbstick(0.0F);
                string summaryLog = String.Format("{0:G} : {1} Thumbstick : Min = {2:F4}, Max = {3:F4}{4}", DateTime.Now, buttonName, minValue, maxValue, Environment.NewLine);
                diagnosticsTextBox.AppendText(summaryLog);
                SetPictureBoxStatus(pictureBox, (minValue == expectedLowThumbstick && maxValue == expectedHighThumbstick) ? PictureBoxStatus.Good : PictureBoxStatus.Bad);
            }
            catch
            {
                SetPictureBoxStatus(pictureBox, PictureBoxStatus.Bad);
            }
        }

        private void SetPictureBoxStatus(PictureBox pictureBox, PictureBoxStatus newStatus)
        {
            try
            {
                Image[] map = new Image[] { Pg3bWindowsFormsApplication.Properties.Resources.GreyDot,
                                            Pg3bWindowsFormsApplication.Properties.Resources.GreenDot,
                                            Pg3bWindowsFormsApplication.Properties.Resources.RedDot };

                PictureBoxStatus oldStatus = (PictureBoxStatus)pictureBox.Tag;
                if (newStatus > oldStatus)
                {
                    pictureBox.Tag = newStatus;
                    pictureBox.Image = map[(int)newStatus];
                }
            }
            catch
            {
                pictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
                pictureBox.Tag = PictureBoxStatus.Unknown;
            }
        }

        private void ResetPictureBoxes()
        {
            buttonsPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            buttonsPictureBox.Tag = PictureBoxStatus.Unknown;
            dpadPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            dpadPictureBox.Tag = PictureBoxStatus.Unknown;
            backButtonPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            backButtonPictureBox.Tag = PictureBoxStatus.Unknown;
            startButtonPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            startButtonPictureBox.Tag = PictureBoxStatus.Unknown;
            leftShoulderPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            leftShoulderPictureBox.Tag = PictureBoxStatus.Unknown;
            rightShoulderPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            rightShoulderPictureBox.Tag = PictureBoxStatus.Unknown;
            leftStickPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            leftStickPictureBox.Tag = PictureBoxStatus.Unknown;
            rightStickPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            rightStickPictureBox.Tag = PictureBoxStatus.Unknown;
            leftTriggerPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            leftTriggerPictureBox.Tag = PictureBoxStatus.Unknown;
            rightTriggerPictureBox.Image = Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            rightTriggerPictureBox.Tag = PictureBoxStatus.Unknown;
        }
        
        private void diagnosticsButton_Click(object sender, EventArgs e)
        {
            clearLogButton.Enabled = false;
            stopButton.Enabled = true;
            diagnosticsButton.Enabled = false;
            stopButton.Select();
            ResetPictureBoxes();

            if ((diagnosticsScopeComboBox.Text == "All" | diagnosticsScopeComboBox.Text == "Buttons") && stopButton.Enabled)
            {
                testButton("A", (v) => xboxController.Buttons.A = v, () => gamepadController.Buttons.A, buttonsPictureBox);
                testButton("B", (v) => xboxController.Buttons.B = v, () => gamepadController.Buttons.B, buttonsPictureBox);
                testButton("X", (v) => xboxController.Buttons.X = v, () => gamepadController.Buttons.X, buttonsPictureBox);
                testButton("Y", (v) => xboxController.Buttons.Y = v, () => gamepadController.Buttons.Y, buttonsPictureBox);

                testButton("Up", (v) => xboxController.DPad.Up = v, () => gamepadController.DPad.Up, dpadPictureBox);
                testButton("Down", (v) => xboxController.DPad.Down = v, () => gamepadController.DPad.Down, dpadPictureBox);
                testButton("Left", (v) => xboxController.DPad.Left = v, () => gamepadController.DPad.Left, dpadPictureBox);
                testButton("Right", (v) => xboxController.DPad.Right = v, () => gamepadController.DPad.Right, dpadPictureBox);

                testButton("Back", (v) => xboxController.Buttons.Back = v, () => gamepadController.Buttons.Back, backButtonPictureBox);
                testButton("Start", (v) => xboxController.Buttons.Start = v, () => gamepadController.Buttons.Start, startButtonPictureBox);
                testButton("LeftShoulder", (v) => xboxController.Buttons.LeftShoulder = v, () => gamepadController.Buttons.LeftShoulder, leftShoulderPictureBox);
                testButton("RightShoulder", (v) => xboxController.Buttons.RightShoulder = v, () => gamepadController.Buttons.RightShoulder, rightShoulderPictureBox);
                testButton("LeftStick", (v) => xboxController.Buttons.LeftStick = v, () => gamepadController.Buttons.LeftStick, leftStickPictureBox);
                testButton("RightStick", (v) => xboxController.Buttons.RightStick = v, () => gamepadController.Buttons.RightStick, rightStickPictureBox);
            }

            if ((diagnosticsScopeComboBox.Text == "All" | diagnosticsScopeComboBox.Text == "Triggers") && stopButton.Enabled)
            {
                testTrigger("Left", (v) => xboxController.Triggers.Left = v, () => gamepadController.Triggers.Left, leftTriggerPictureBox);
                testTrigger("Right", (v) => xboxController.Triggers.Right = v, () => gamepadController.Triggers.Right, rightTriggerPictureBox);
            }

            if ((diagnosticsScopeComboBox.Text == "All" | diagnosticsScopeComboBox.Text == "Thumbsticks") && stopButton.Enabled)
            {
                testThumbstick("Left X", (v) => xboxController.ThumbSticks.Left.X = v, () => gamepadController.ThumbSticks.Left.X, leftStickPictureBox);
                testThumbstick("Left Y", (v) => xboxController.ThumbSticks.Left.Y = v, () => gamepadController.ThumbSticks.Left.Y, leftStickPictureBox);
                testThumbstick("Right X", (v) => xboxController.ThumbSticks.Right.X = v, () => gamepadController.ThumbSticks.Right.X, rightStickPictureBox);
                testThumbstick("Right Y", (v) => xboxController.ThumbSticks.Right.Y = v, () => gamepadController.ThumbSticks.Right.Y, rightStickPictureBox);
            }

            stopButton.Enabled = false;
            clearLogButton.Enabled = true;
            diagnosticsButton.Enabled = true;
        }

        private void TestAndDiagnostics_Load(object sender, EventArgs e)
        {
            MainForm mainForm = Parent.Parent as MainForm;
            xboxController = mainForm.SharedXBoxController();
            gamepadController = mainForm.SharedGamepadController();
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            diagnosticsTextBox.Clear();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
        }
    }
}
