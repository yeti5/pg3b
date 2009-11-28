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
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using PG3B.Interface;

namespace Pg3bWindowsFormsApplication
{
    public partial class MainForm : Form
    {
        private Pg3bWindowsFormsApplication.SubForm.Devices devicesForm;
        private Pg3bWindowsFormsApplication.SubForm.Triggers triggersForm;
        private Pg3bWindowsFormsApplication.SubForm.Events eventsForm;
        private Pg3bWindowsFormsApplication.SubForm.Actions actionsForm;
        private Pg3bWindowsFormsApplication.SubForm.Targets targetsForm;
        private Pg3bWindowsFormsApplication.SubForm.EventActions eventActionsForm;
        private Pg3bWindowsFormsApplication.SubForm.TestAndDiagnostics testAndDiagnosticsForm;
        private Pg3bWindowsFormsApplication.SubForm.CalibrateAnalogControls calibrateAnalogControls;

        private GamepadController gamepadController;
        private XBoxController xboxController;

        private DataSet configDataSet;
        private Form activeSubForm;

        public enum ApplicationState { Information, Normal, Alert, Warning };

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeSubForms()
        {
            devicesForm = new Pg3bWindowsFormsApplication.SubForm.Devices();
            devicesForm.TopLevel = false;
            devicesForm.Parent = mainPanel;
            devicesToolStripMenuItem.Tag = devicesForm;

            triggersForm = new Pg3bWindowsFormsApplication.SubForm.Triggers();
            triggersForm.TopLevel = false;
            triggersForm.Parent = mainPanel;
            triggersToolStripMenuItem.Tag = triggersForm;

            eventsForm = new Pg3bWindowsFormsApplication.SubForm.Events();
            eventsForm.TopLevel = false;
            eventsForm.Parent = mainPanel;
            eventsToolStripMenuItem.Tag = eventsForm;

            actionsForm = new Pg3bWindowsFormsApplication.SubForm.Actions();
            actionsForm.TopLevel = false;
            actionsForm.Parent = mainPanel;
            actionsToolStripMenuItem.Tag = actionsForm;

            targetsForm = new Pg3bWindowsFormsApplication.SubForm.Targets();
            targetsForm.TopLevel = false;
            targetsForm.Parent = mainPanel;
            targetsToolStripMenuItem.Tag = targetsForm;

            eventActionsForm = new Pg3bWindowsFormsApplication.SubForm.EventActions();
            eventActionsForm.TopLevel = false;
            eventActionsForm.Parent = mainPanel;
            eventActionsToolStripMenuItem.Tag = eventActionsForm;

            testAndDiagnosticsForm = new Pg3bWindowsFormsApplication.SubForm.TestAndDiagnostics();
            testAndDiagnosticsForm.TopLevel = false;
            testAndDiagnosticsForm.Parent = mainPanel;
            diagnosticsToolStripMenuItem.Tag = testAndDiagnosticsForm;

            calibrateAnalogControls = new Pg3bWindowsFormsApplication.SubForm.CalibrateAnalogControls();
            calibrateAnalogControls.TopLevel = false;
            calibrateAnalogControls.Parent = mainPanel;
            calibrationToolStripMenuItem.Tag = calibrateAnalogControls;

            activeSubForm = testAndDiagnosticsForm;
            activeSubForm.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                evaDataSet.BeginInit();
                evaDataSet.EnforceConstraints = true;
                evaDataSet.ReadXml("EventAction.xml", XmlReadMode.IgnoreSchema);
                evaDataSet.EndInit();
            }
            catch
            {
                updateApplicationStatus(ApplicationState.Alert, @"Unable to read EventAction XML database.");
            }

            try
            {
                configDataSet = new DataSet();
                configDataSet.BeginInit();
                configDataSet.ReadXml("Configuration.xml");
                configDataSet.EndInit();
            }
            catch
            {
                updateApplicationStatus(ApplicationState.Alert, @"Unable to read Configuration XML database.");
            }

            try
            {
                DataTable dataTable = configDataSet.Tables["GamepadController"];
                DataRow dataRow = dataTable.Rows[0];
                int playerIndex = Convert.ToInt32(dataRow["player"]);
                gamepadController = new PG3B.Interface.GamepadController(playerIndex);
            }
            catch
            {
                updateApplicationStatus(ApplicationState.Warning, @"Unable to initialize GamePad.");
            }

            try
            {
                DataTable dataTable = configDataSet.Tables["XBoxController"];
                DataRow dataRow = dataTable.Rows[0];
                string portName = Convert.ToString(dataRow["port"]);
                xboxController = new PG3B.Interface.XBoxController(portName);
                switch (Convert.ToString(dataRow["model"]))
                {
                    case "WiredCommonLine":
                        xboxController.IsWireless = false;
                        break;
                    case "WirelessCommonGround":
                        xboxController.IsWireless = true;
                        break;
                }
            }
            catch
            {
                updateApplicationStatus(ApplicationState.Alert, @"Unable to initialize PG3B using Config.xml file.");
            }

            UpdateControllerStatus();
            InitializeSubForms();
        }

        private void UpdateControllerStatus()
        {
            try
            {
                gamepadToolStripStatusLabel.Image = gamepadController.IsConnected ? Pg3bWindowsFormsApplication.Properties.Resources.Green : Pg3bWindowsFormsApplication.Properties.Resources.Red;
            }
            catch
            {
                gamepadToolStripStatusLabel.Image = Pg3bWindowsFormsApplication.Properties.Resources.Red;
            }

            try
            {
                xboxToolStripStatusLabel.Image = xboxController.IsConnected ? Pg3bWindowsFormsApplication.Properties.Resources.Green : Pg3bWindowsFormsApplication.Properties.Resources.Red;
            }
            catch
            {
                xboxToolStripStatusLabel.Image = Pg3bWindowsFormsApplication.Properties.Resources.Red;
            }
        }

        private void refreshToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            UpdateControllerStatus();
        }

        private void updateApplicationStatus(ApplicationState applicationState, string applicationMessage)
        {
            Image[] map = new Image[] { Pg3bWindowsFormsApplication.Properties.Resources.BlueNote,
                                        Pg3bWindowsFormsApplication.Properties.Resources.GreenNote,
                                        Pg3bWindowsFormsApplication.Properties.Resources.RedNote,
                                        Pg3bWindowsFormsApplication.Properties.Resources.YellowNote };
            try
            {
                mainToolStripStatusLabel2.Image = map[(int)applicationState];
                mainToolStripStatusLabel2.Text = applicationMessage;
            }
            catch
            {
                mainToolStripStatusLabel2.Image = Pg3bWindowsFormsApplication.Properties.Resources.RedNote;
                mainToolStripStatusLabel2.Text = @"Error setting application message.";
            }
        }

        public EvaDataSet SharedEvaDataSet()
        {
            return evaDataSet;
        }

        public XBoxController SharedXBoxController()
        {
            return xboxController;
        }

        public GamepadController SharedGamepadController()
        {
            return gamepadController;
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evaDataSet.WriteXml("EventAction.xml", XmlWriteMode.IgnoreSchema);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
            }
        }

        private void subformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (activeSubForm != null)
            {
                activeSubForm.Hide();
            }
            activeSubForm = toolStripMenuItem.Tag as Form;
            activeSubForm.Show();
        }

#if false
        private void copyToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            copyToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow dataRow in evaDataSet.Tables["EventTrigger"].Rows)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "EventTrigger" + dataRow["TriggerName"];
                toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                toolStripMenuItem.Text = dataRow["TriggerName"].ToString();
                toolStripMenuItem.Tag = dataRow;
                toolStripMenuItem.Click += new System.EventHandler(copyTriggerToolStripMenuItem_Click);
                copyToolStripMenuItem.DropDownItems.Add(toolStripMenuItem); 
            }
        }
#endif

#if false
        private void copyTriggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eventTriggerDataGridView.SelectedRows.Count == 1)
            {
                DataRowView sourceTriggerView = (DataRowView)eventTriggerDataGridView.SelectedRows[0].DataBoundItem;
                DataRow sourceTriggerRow = sourceTriggerView.Row;
                DataRow[] sourceValueRows = sourceTriggerRow.GetChildRows("EventTrigger_EventValue");

                ToolStripDropDownItem toolStripMenuItem = (ToolStripDropDownItem)sender;
                DataRow targetTriggerRow = (DataRow)toolStripMenuItem.Tag;

                DataTable valueTable = evaDataSet.Tables["EventValue"];
                foreach (DataRow sourceValueRow in sourceValueRows)
                {
                    DataRow valueRow = valueTable.NewRow();
                    valueRow.BeginEdit();
                    valueRow["TriggerCode"] = targetTriggerRow["TriggerCode"];
                    valueRow["ValueEnum"] = sourceValueRow["ValueEnum"];
                    valueRow["ValueName"] = sourceValueRow["ValueName"];
                    valueRow.EndEdit();
                    valueTable.Rows.Add(valueRow);
                }
            }
        }
#endif
    }
}
