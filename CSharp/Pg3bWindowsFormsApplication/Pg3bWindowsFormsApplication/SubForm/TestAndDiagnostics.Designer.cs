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
 * $Rev: 201 $
 * $Author: rburke $
 * $LastChangedDate: 2009-11-17 20:06:21 -0500 (Tue, 17 Nov 2009) $
 ********************************************************************************
 */
namespace Pg3bWindowsFormsApplication.SubForm
{
    partial class TestAndDiagnostics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diagnosticsButton = new System.Windows.Forms.Button();
            this.diagnosticsTextBox = new System.Windows.Forms.TextBox();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.diagnosticsPanel = new System.Windows.Forms.Panel();
            this.buttonsPictureBox = new System.Windows.Forms.PictureBox();
            this.rightStickPictureBox = new System.Windows.Forms.PictureBox();
            this.dpadPictureBox = new System.Windows.Forms.PictureBox();
            this.leftStickPictureBox = new System.Windows.Forms.PictureBox();
            this.startButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.bigButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.backButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.rightShoulderPictureBox = new System.Windows.Forms.PictureBox();
            this.leftShoulderPictureBox = new System.Windows.Forms.PictureBox();
            this.rightTriggerPictureBox = new System.Windows.Forms.PictureBox();
            this.leftTriggerPictureBox = new System.Windows.Forms.PictureBox();
            this.diagnosticsScopeComboBox = new System.Windows.Forms.ComboBox();
            this.diagnosticsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStickPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftStickPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightShoulderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftShoulderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTriggerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTriggerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // diagnosticsButton
            // 
            this.diagnosticsButton.Location = new System.Drawing.Point(697, 476);
            this.diagnosticsButton.Name = "diagnosticsButton";
            this.diagnosticsButton.Size = new System.Drawing.Size(75, 23);
            this.diagnosticsButton.TabIndex = 1;
            this.diagnosticsButton.Text = "Diagnostics";
            this.diagnosticsButton.UseVisualStyleBackColor = true;
            this.diagnosticsButton.Click += new System.EventHandler(this.diagnosticsButton_Click);
            // 
            // diagnosticsTextBox
            // 
            this.diagnosticsTextBox.Location = new System.Drawing.Point(13, 321);
            this.diagnosticsTextBox.Multiline = true;
            this.diagnosticsTextBox.Name = "diagnosticsTextBox";
            this.diagnosticsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.diagnosticsTextBox.Size = new System.Drawing.Size(759, 146);
            this.diagnosticsTextBox.TabIndex = 2;
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(616, 476);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(75, 23);
            this.clearLogButton.TabIndex = 8;
            this.clearLogButton.Text = "Clear Log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(535, 476);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // diagnosticsPanel
            // 
            this.diagnosticsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.diagnosticsPanel.BackgroundImage = global::Pg3bWindowsFormsApplication.Properties.Resources.XBox360Controller;
            this.diagnosticsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.diagnosticsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagnosticsPanel.Controls.Add(this.buttonsPictureBox);
            this.diagnosticsPanel.Controls.Add(this.rightStickPictureBox);
            this.diagnosticsPanel.Controls.Add(this.dpadPictureBox);
            this.diagnosticsPanel.Controls.Add(this.leftStickPictureBox);
            this.diagnosticsPanel.Controls.Add(this.startButtonPictureBox);
            this.diagnosticsPanel.Controls.Add(this.bigButtonPictureBox);
            this.diagnosticsPanel.Controls.Add(this.backButtonPictureBox);
            this.diagnosticsPanel.Controls.Add(this.rightShoulderPictureBox);
            this.diagnosticsPanel.Controls.Add(this.leftShoulderPictureBox);
            this.diagnosticsPanel.Controls.Add(this.rightTriggerPictureBox);
            this.diagnosticsPanel.Controls.Add(this.leftTriggerPictureBox);
            this.diagnosticsPanel.Location = new System.Drawing.Point(12, 12);
            this.diagnosticsPanel.Name = "diagnosticsPanel";
            this.diagnosticsPanel.Size = new System.Drawing.Size(760, 302);
            this.diagnosticsPanel.TabIndex = 0;
            // 
            // buttonsPictureBox
            // 
            this.buttonsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.buttonsPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.buttonsPictureBox.InitialImage = null;
            this.buttonsPictureBox.Location = new System.Drawing.Point(531, 199);
            this.buttonsPictureBox.Name = "buttonsPictureBox";
            this.buttonsPictureBox.Size = new System.Drawing.Size(16, 16);
            this.buttonsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonsPictureBox.TabIndex = 10;
            this.buttonsPictureBox.TabStop = false;
            // 
            // rightStickPictureBox
            // 
            this.rightStickPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.rightStickPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.rightStickPictureBox.InitialImage = null;
            this.rightStickPictureBox.Location = new System.Drawing.Point(462, 227);
            this.rightStickPictureBox.Name = "rightStickPictureBox";
            this.rightStickPictureBox.Size = new System.Drawing.Size(16, 16);
            this.rightStickPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightStickPictureBox.TabIndex = 9;
            this.rightStickPictureBox.TabStop = false;
            // 
            // dpadPictureBox
            // 
            this.dpadPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.dpadPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.dpadPictureBox.InitialImage = null;
            this.dpadPictureBox.Location = new System.Drawing.Point(330, 233);
            this.dpadPictureBox.Name = "dpadPictureBox";
            this.dpadPictureBox.Size = new System.Drawing.Size(16, 16);
            this.dpadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dpadPictureBox.TabIndex = 8;
            this.dpadPictureBox.TabStop = false;
            // 
            // leftStickPictureBox
            // 
            this.leftStickPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.leftStickPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.leftStickPictureBox.InitialImage = null;
            this.leftStickPictureBox.Location = new System.Drawing.Point(218, 218);
            this.leftStickPictureBox.Name = "leftStickPictureBox";
            this.leftStickPictureBox.Size = new System.Drawing.Size(16, 16);
            this.leftStickPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftStickPictureBox.TabIndex = 7;
            this.leftStickPictureBox.TabStop = false;
            // 
            // startButtonPictureBox
            // 
            this.startButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.startButtonPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.startButtonPictureBox.InitialImage = null;
            this.startButtonPictureBox.Location = new System.Drawing.Point(427, 157);
            this.startButtonPictureBox.Name = "startButtonPictureBox";
            this.startButtonPictureBox.Size = new System.Drawing.Size(16, 16);
            this.startButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.startButtonPictureBox.TabIndex = 6;
            this.startButtonPictureBox.TabStop = false;
            // 
            // bigButtonPictureBox
            // 
            this.bigButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bigButtonPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.bigButtonPictureBox.InitialImage = null;
            this.bigButtonPictureBox.Location = new System.Drawing.Point(369, 157);
            this.bigButtonPictureBox.Name = "bigButtonPictureBox";
            this.bigButtonPictureBox.Size = new System.Drawing.Size(16, 16);
            this.bigButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bigButtonPictureBox.TabIndex = 5;
            this.bigButtonPictureBox.TabStop = false;
            // 
            // backButtonPictureBox
            // 
            this.backButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.backButtonPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.backButtonPictureBox.InitialImage = null;
            this.backButtonPictureBox.Location = new System.Drawing.Point(307, 157);
            this.backButtonPictureBox.Name = "backButtonPictureBox";
            this.backButtonPictureBox.Size = new System.Drawing.Size(16, 16);
            this.backButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.backButtonPictureBox.TabIndex = 4;
            this.backButtonPictureBox.TabStop = false;
            // 
            // rightShoulderPictureBox
            // 
            this.rightShoulderPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.rightShoulderPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.rightShoulderPictureBox.InitialImage = null;
            this.rightShoulderPictureBox.Location = new System.Drawing.Point(542, 105);
            this.rightShoulderPictureBox.Name = "rightShoulderPictureBox";
            this.rightShoulderPictureBox.Size = new System.Drawing.Size(16, 16);
            this.rightShoulderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightShoulderPictureBox.TabIndex = 3;
            this.rightShoulderPictureBox.TabStop = false;
            // 
            // leftShoulderPictureBox
            // 
            this.leftShoulderPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.leftShoulderPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.leftShoulderPictureBox.InitialImage = null;
            this.leftShoulderPictureBox.Location = new System.Drawing.Point(203, 105);
            this.leftShoulderPictureBox.Name = "leftShoulderPictureBox";
            this.leftShoulderPictureBox.Size = new System.Drawing.Size(16, 16);
            this.leftShoulderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftShoulderPictureBox.TabIndex = 2;
            this.leftShoulderPictureBox.TabStop = false;
            // 
            // rightTriggerPictureBox
            // 
            this.rightTriggerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.rightTriggerPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.rightTriggerPictureBox.InitialImage = null;
            this.rightTriggerPictureBox.Location = new System.Drawing.Point(512, 45);
            this.rightTriggerPictureBox.Name = "rightTriggerPictureBox";
            this.rightTriggerPictureBox.Size = new System.Drawing.Size(16, 16);
            this.rightTriggerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightTriggerPictureBox.TabIndex = 1;
            this.rightTriggerPictureBox.TabStop = false;
            // 
            // leftTriggerPictureBox
            // 
            this.leftTriggerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.leftTriggerPictureBox.Image = global::Pg3bWindowsFormsApplication.Properties.Resources.GreyDot;
            this.leftTriggerPictureBox.InitialImage = null;
            this.leftTriggerPictureBox.Location = new System.Drawing.Point(230, 45);
            this.leftTriggerPictureBox.Name = "leftTriggerPictureBox";
            this.leftTriggerPictureBox.Size = new System.Drawing.Size(16, 16);
            this.leftTriggerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftTriggerPictureBox.TabIndex = 0;
            this.leftTriggerPictureBox.TabStop = false;
            // 
            // diagnosticsScopeComboBox
            // 
            this.diagnosticsScopeComboBox.FormattingEnabled = true;
            this.diagnosticsScopeComboBox.Items.AddRange(new object[] {
            "All",
            "Buttons",
            "Thumbsticks",
            "Triggers"});
            this.diagnosticsScopeComboBox.Location = new System.Drawing.Point(408, 477);
            this.diagnosticsScopeComboBox.Name = "diagnosticsScopeComboBox";
            this.diagnosticsScopeComboBox.Size = new System.Drawing.Size(121, 21);
            this.diagnosticsScopeComboBox.TabIndex = 10;
            this.diagnosticsScopeComboBox.Text = "All";
            // 
            // TestAndDiagnostics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.diagnosticsScopeComboBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.diagnosticsTextBox);
            this.Controls.Add(this.diagnosticsButton);
            this.Controls.Add(this.diagnosticsPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestAndDiagnostics";
            this.Text = "TestAndDiagnostics";
            this.Load += new System.EventHandler(this.TestAndDiagnostics_Load);
            this.diagnosticsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStickPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftStickPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightShoulderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftShoulderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTriggerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTriggerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel diagnosticsPanel;
        private System.Windows.Forms.Button diagnosticsButton;
        private System.Windows.Forms.TextBox diagnosticsTextBox;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox leftTriggerPictureBox;
        private System.Windows.Forms.PictureBox rightTriggerPictureBox;
        private System.Windows.Forms.PictureBox leftShoulderPictureBox;
        private System.Windows.Forms.PictureBox rightShoulderPictureBox;
        private System.Windows.Forms.PictureBox startButtonPictureBox;
        private System.Windows.Forms.PictureBox bigButtonPictureBox;
        private System.Windows.Forms.PictureBox backButtonPictureBox;
        private System.Windows.Forms.PictureBox leftStickPictureBox;
        private System.Windows.Forms.PictureBox dpadPictureBox;
        private System.Windows.Forms.PictureBox rightStickPictureBox;
        private System.Windows.Forms.PictureBox buttonsPictureBox;
        private System.Windows.Forms.ComboBox diagnosticsScopeComboBox;
    }
}