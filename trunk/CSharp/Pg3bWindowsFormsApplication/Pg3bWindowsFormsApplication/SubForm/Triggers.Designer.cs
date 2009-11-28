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
    partial class Triggers
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
            this.components = new System.ComponentModel.Container();
            this.eventTriggerDataGridView = new System.Windows.Forms.DataGridView();
            this.deviceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.triggerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.triggerEnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eventTriggerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eventTriggerDataGridView
            // 
            this.eventTriggerDataGridView.AutoGenerateColumns = false;
            this.eventTriggerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventTriggerDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.eventTriggerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventTriggerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceCodeDataGridViewTextBoxColumn,
            this.triggerNameDataGridViewTextBoxColumn,
            this.triggerEnumDataGridViewTextBoxColumn});
            this.eventTriggerDataGridView.DataMember = "EventTrigger";
            this.eventTriggerDataGridView.DataSource = this.evaBindingSource;
            this.eventTriggerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventTriggerDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eventTriggerDataGridView.Name = "eventTriggerDataGridView";
            this.eventTriggerDataGridView.Size = new System.Drawing.Size(784, 508);
            this.eventTriggerDataGridView.TabIndex = 1;
            // 
            // deviceCodeDataGridViewTextBoxColumn
            // 
            this.deviceCodeDataGridViewTextBoxColumn.DataPropertyName = "DeviceCode";
            this.deviceCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.deviceCodeDataGridViewTextBoxColumn.DisplayMember = "Device.DeviceName";
            this.deviceCodeDataGridViewTextBoxColumn.HeaderText = "Device Name";
            this.deviceCodeDataGridViewTextBoxColumn.Name = "deviceCodeDataGridViewTextBoxColumn";
            this.deviceCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deviceCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.deviceCodeDataGridViewTextBoxColumn.ValueMember = "Device.DeviceCode";
            // 
            // evaBindingSource
            // 
            this.evaBindingSource.AllowNew = false;
            this.evaBindingSource.DataSource = typeof(Pg3bWindowsFormsApplication.EvaDataSet);
            this.evaBindingSource.Position = 0;
            // 
            // triggerNameDataGridViewTextBoxColumn
            // 
            this.triggerNameDataGridViewTextBoxColumn.DataPropertyName = "TriggerName";
            this.triggerNameDataGridViewTextBoxColumn.HeaderText = "Trigger Name";
            this.triggerNameDataGridViewTextBoxColumn.Name = "triggerNameDataGridViewTextBoxColumn";
            // 
            // triggerEnumDataGridViewTextBoxColumn
            // 
            this.triggerEnumDataGridViewTextBoxColumn.DataPropertyName = "TriggerEnum";
            this.triggerEnumDataGridViewTextBoxColumn.HeaderText = "Trigger Number";
            this.triggerEnumDataGridViewTextBoxColumn.Name = "triggerEnumDataGridViewTextBoxColumn";
            // 
            // Triggers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.eventTriggerDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Triggers";
            this.Text = "Triggers";
            this.Load += new System.EventHandler(this.Triggers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventTriggerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView eventTriggerDataGridView;
        private System.Windows.Forms.BindingSource evaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn deviceCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn triggerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn triggerEnumDataGridViewTextBoxColumn;
    }
}