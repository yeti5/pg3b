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
    partial class Targets
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
            this.actionValueDataGridView = new System.Windows.Forms.DataGridView();
            this.deviceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.targetNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetEnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.actionValueDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // actionValueDataGridView
            // 
            this.actionValueDataGridView.AllowUserToOrderColumns = true;
            this.actionValueDataGridView.AutoGenerateColumns = false;
            this.actionValueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actionValueDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.actionValueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actionValueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceCodeDataGridViewTextBoxColumn,
            this.targetNameDataGridViewTextBoxColumn,
            this.targetEnumDataGridViewTextBoxColumn});
            this.actionValueDataGridView.DataMember = "ActionTarget";
            this.actionValueDataGridView.DataSource = this.evaBindingSource;
            this.actionValueDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionValueDataGridView.Location = new System.Drawing.Point(0, 0);
            this.actionValueDataGridView.Name = "actionValueDataGridView";
            this.actionValueDataGridView.Size = new System.Drawing.Size(784, 508);
            this.actionValueDataGridView.TabIndex = 1;
            // 
            // deviceCodeDataGridViewTextBoxColumn
            // 
            this.deviceCodeDataGridViewTextBoxColumn.DataPropertyName = "DeviceCode";
            this.deviceCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.deviceCodeDataGridViewTextBoxColumn.DisplayMember = "Device.DeviceName";
            this.deviceCodeDataGridViewTextBoxColumn.HeaderText = "Device";
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
            // targetNameDataGridViewTextBoxColumn
            // 
            this.targetNameDataGridViewTextBoxColumn.DataPropertyName = "TargetName";
            this.targetNameDataGridViewTextBoxColumn.HeaderText = "Target Name";
            this.targetNameDataGridViewTextBoxColumn.Name = "targetNameDataGridViewTextBoxColumn";
            // 
            // targetEnumDataGridViewTextBoxColumn
            // 
            this.targetEnumDataGridViewTextBoxColumn.DataPropertyName = "TargetEnum";
            this.targetEnumDataGridViewTextBoxColumn.HeaderText = "Target Value";
            this.targetEnumDataGridViewTextBoxColumn.Name = "targetEnumDataGridViewTextBoxColumn";
            // 
            // Targets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.actionValueDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Targets";
            this.Text = "Targets";
            this.Load += new System.EventHandler(this.Targets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actionValueDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView actionValueDataGridView;
        private System.Windows.Forms.BindingSource evaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn deviceCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetEnumDataGridViewTextBoxColumn;
    }
}