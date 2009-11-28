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
    partial class Actions
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
            this.actionTargetDataGridView = new System.Windows.Forms.DataGridView();
            this.targetCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valueNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueEnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.actionTargetDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // actionTargetDataGridView
            // 
            this.actionTargetDataGridView.AllowUserToOrderColumns = true;
            this.actionTargetDataGridView.AutoGenerateColumns = false;
            this.actionTargetDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actionTargetDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.actionTargetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actionTargetDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targetCodeDataGridViewTextBoxColumn,
            this.valueNameDataGridViewTextBoxColumn,
            this.valueEnumDataGridViewTextBoxColumn});
            this.actionTargetDataGridView.DataMember = "ActionValue";
            this.actionTargetDataGridView.DataSource = this.evaBindingSource;
            this.actionTargetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionTargetDataGridView.Location = new System.Drawing.Point(0, 0);
            this.actionTargetDataGridView.Name = "actionTargetDataGridView";
            this.actionTargetDataGridView.Size = new System.Drawing.Size(784, 508);
            this.actionTargetDataGridView.TabIndex = 1;
            // 
            // targetCodeDataGridViewTextBoxColumn
            // 
            this.targetCodeDataGridViewTextBoxColumn.DataPropertyName = "TargetCode";
            this.targetCodeDataGridViewTextBoxColumn.DataSource = this.evaBindingSource;
            this.targetCodeDataGridViewTextBoxColumn.DisplayMember = "ActionTarget.TargetFullName";
            this.targetCodeDataGridViewTextBoxColumn.HeaderText = "TargetCode";
            this.targetCodeDataGridViewTextBoxColumn.Name = "targetCodeDataGridViewTextBoxColumn";
            this.targetCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.targetCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.targetCodeDataGridViewTextBoxColumn.ValueMember = "ActionTarget.TargetCode";
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
            this.valueNameDataGridViewTextBoxColumn.HeaderText = "ValueName";
            this.valueNameDataGridViewTextBoxColumn.Name = "valueNameDataGridViewTextBoxColumn";
            // 
            // valueEnumDataGridViewTextBoxColumn
            // 
            this.valueEnumDataGridViewTextBoxColumn.DataPropertyName = "ValueEnum";
            this.valueEnumDataGridViewTextBoxColumn.HeaderText = "ValueEnum";
            this.valueEnumDataGridViewTextBoxColumn.Name = "valueEnumDataGridViewTextBoxColumn";
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 508);
            this.Controls.Add(this.actionTargetDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Actions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Actions";
            this.Load += new System.EventHandler(this.Actions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actionTargetDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView actionTargetDataGridView;
        private System.Windows.Forms.BindingSource evaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn targetCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueEnumDataGridViewTextBoxColumn;
    }
}