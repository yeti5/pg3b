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
    partial class EventActions
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
            this.evaDataGridView = new System.Windows.Forms.DataGridView();
            this.eventCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actionCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.evaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // evaDataGridView
            // 
            this.evaDataGridView.AutoGenerateColumns = false;
            this.evaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.evaDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.evaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.evaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventCodeDataGridViewTextBoxColumn,
            this.actionCodeDataGridViewTextBoxColumn});
            this.evaDataGridView.DataMember = "Eva";
            this.evaDataGridView.DataSource = this.evaBindingSource;
            this.evaDataGridView.Location = new System.Drawing.Point(0, 0);
            this.evaDataGridView.Name = "evaDataGridView";
            this.evaDataGridView.Size = new System.Drawing.Size(784, 508);
            this.evaDataGridView.TabIndex = 4;
            // 
            // eventCodeDataGridViewTextBoxColumn
            // 
            this.eventCodeDataGridViewTextBoxColumn.DataPropertyName = "EventCode";
            this.eventCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.eventCodeDataGridViewTextBoxColumn.DisplayMember = "EventValue.ValueFullName";
            this.eventCodeDataGridViewTextBoxColumn.HeaderText = "Event";
            this.eventCodeDataGridViewTextBoxColumn.Name = "eventCodeDataGridViewTextBoxColumn";
            this.eventCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eventCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eventCodeDataGridViewTextBoxColumn.ValueMember = "EventValue.ValueCode";
            // 
            // evaBindingSource
            // 
            this.evaBindingSource.AllowNew = false;
            this.evaBindingSource.DataSource = typeof(Pg3bWindowsFormsApplication.EvaDataSet);
            this.evaBindingSource.Position = 0;
            // 
            // actionCodeDataGridViewTextBoxColumn
            // 
            this.actionCodeDataGridViewTextBoxColumn.DataPropertyName = "ActionCode";
            this.actionCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.actionCodeDataGridViewTextBoxColumn.DisplayMember = "ActionValue.ValueFullName";
            this.actionCodeDataGridViewTextBoxColumn.HeaderText = "Action";
            this.actionCodeDataGridViewTextBoxColumn.Name = "actionCodeDataGridViewTextBoxColumn";
            this.actionCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.actionCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.actionCodeDataGridViewTextBoxColumn.ValueMember = "ActionValue.ValueCode";
            // 
            // EventActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.evaDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventActions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "EventActions";
            this.Load += new System.EventHandler(this.EventActions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.evaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView evaDataGridView;
        private System.Windows.Forms.BindingSource evaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn eventCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn actionCodeDataGridViewTextBoxColumn;


    }
}