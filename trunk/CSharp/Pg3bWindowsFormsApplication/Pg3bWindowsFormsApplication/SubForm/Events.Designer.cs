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
    partial class Events
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
            this.eventValueDataGridView = new System.Windows.Forms.DataGridView();
            this.triggerCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valueNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueEnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eventValueDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eventValueDataGridView
            // 
            this.eventValueDataGridView.AutoGenerateColumns = false;
            this.eventValueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventValueDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.eventValueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventValueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.triggerCodeDataGridViewTextBoxColumn,
            this.valueNameDataGridViewTextBoxColumn,
            this.valueEnumDataGridViewTextBoxColumn});
            this.eventValueDataGridView.DataMember = "EventValue";
            this.eventValueDataGridView.DataSource = this.evaBindingSource;
            this.eventValueDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventValueDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eventValueDataGridView.Name = "eventValueDataGridView";
            this.eventValueDataGridView.Size = new System.Drawing.Size(784, 508);
            this.eventValueDataGridView.TabIndex = 1;
            // 
            // triggerCodeDataGridViewTextBoxColumn
            // 
            this.triggerCodeDataGridViewTextBoxColumn.DataPropertyName = "TriggerCode";
            this.triggerCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.triggerCodeDataGridViewTextBoxColumn.DisplayMember = "EventTrigger.TriggerFullName";
            this.triggerCodeDataGridViewTextBoxColumn.HeaderText = "Trigger Key";
            this.triggerCodeDataGridViewTextBoxColumn.Name = "triggerCodeDataGridViewTextBoxColumn";
            this.triggerCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.triggerCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.triggerCodeDataGridViewTextBoxColumn.ValueMember = "EventTrigger.TriggerCode";
            // 
            // evaBindingSource
            // 
            this.evaBindingSource.AllowNew = false;
            this.evaBindingSource.DataSource = typeof(Pg3bWindowsFormsApplication.EvaDataSet);
            this.evaBindingSource.Position = 0;
            // 
            // valueNameDataGridViewTextBoxColumn
            // 
            this.valueNameDataGridViewTextBoxColumn.DataPropertyName = "ValueName";
            this.valueNameDataGridViewTextBoxColumn.HeaderText = "Event Name";
            this.valueNameDataGridViewTextBoxColumn.Name = "valueNameDataGridViewTextBoxColumn";
            // 
            // valueEnumDataGridViewTextBoxColumn
            // 
            this.valueEnumDataGridViewTextBoxColumn.DataPropertyName = "ValueEnum";
            this.valueEnumDataGridViewTextBoxColumn.HeaderText = "Event Value";
            this.valueEnumDataGridViewTextBoxColumn.Name = "valueEnumDataGridViewTextBoxColumn";
            // 
            // Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.eventValueDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Events";
            this.Text = "Events";
            this.Load += new System.EventHandler(this.Events_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventValueDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView eventValueDataGridView;
        private System.Windows.Forms.BindingSource evaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn triggerCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueEnumDataGridViewTextBoxColumn;
    }
}