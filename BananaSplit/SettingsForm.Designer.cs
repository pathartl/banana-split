﻿namespace BananaSplit
{
    partial class SettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FFMPEGArgumentsLegend = new System.Windows.Forms.Label();
            this.FFMPEGArgumentsInput = new System.Windows.Forms.TextBox();
            this.ReferenceFrameOffsetLabel = new System.Windows.Forms.Label();
            this.ReferenceFrameOffsetInput = new System.Windows.Forms.NumericUpDown();
            this.DeleteOriginalCheckbox = new System.Windows.Forms.CheckBox();
            this.ProcessTypeLabel = new System.Windows.Forms.Label();
            this.ProcessTypeComboBox = new System.Windows.Forms.ComboBox();
            this.BlackFrameDurationInput = new System.Windows.Forms.NumericUpDown();
            this.BlackFrameThresholdInput = new System.Windows.Forms.NumericUpDown();
            this.BlackFrameThresholdLabel = new System.Windows.Forms.Label();
            this.BlackFrameDurationLabel = new System.Windows.Forms.Label();
            this.FFMPEGArgumentsGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(14, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsLegend);
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsInput);
            this.tabPage1.Controls.Add(this.ReferenceFrameOffsetLabel);
            this.tabPage1.Controls.Add(this.ReferenceFrameOffsetInput);
            this.tabPage1.Controls.Add(this.DeleteOriginalCheckbox);
            this.tabPage1.Controls.Add(this.ProcessTypeLabel);
            this.tabPage1.Controls.Add(this.ProcessTypeComboBox);
            this.tabPage1.Controls.Add(this.BlackFrameDurationInput);
            this.tabPage1.Controls.Add(this.BlackFrameThresholdInput);
            this.tabPage1.Controls.Add(this.BlackFrameThresholdLabel);
            this.tabPage1.Controls.Add(this.BlackFrameDurationLabel);
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(471, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FFMPEGArgumentsLegend
            // 
            this.FFMPEGArgumentsLegend.AutoSize = true;
            this.FFMPEGArgumentsLegend.Location = new System.Drawing.Point(381, 170);
            this.FFMPEGArgumentsLegend.Name = "FFMPEGArgumentsLegend";
            this.FFMPEGArgumentsLegend.Size = new System.Drawing.Size(74, 75);
            this.FFMPEGArgumentsLegend.TabIndex = 11;
            this.FFMPEGArgumentsLegend.Text = "Legend:\r\n{source}\r\n{destination}\r\n{start}\r\n{end}\r\n{duration}";
            // 
            // FFMPEGArgumentsInput
            // 
            this.FFMPEGArgumentsInput.Location = new System.Drawing.Point(16, 167);
            this.FFMPEGArgumentsInput.Multiline = true;
            this.FFMPEGArgumentsInput.Name = "FFMPEGArgumentsInput";
            this.FFMPEGArgumentsInput.Size = new System.Drawing.Size(359, 217);
            this.FFMPEGArgumentsInput.TabIndex = 8;
            // 
            // ReferenceFrameOffsetLabel
            // 
            this.ReferenceFrameOffsetLabel.AutoSize = true;
            this.ReferenceFrameOffsetLabel.Location = new System.Drawing.Point(156, 69);
            this.ReferenceFrameOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReferenceFrameOffsetLabel.Name = "ReferenceFrameOffsetLabel";
            this.ReferenceFrameOffsetLabel.Size = new System.Drawing.Size(146, 15);
            this.ReferenceFrameOffsetLabel.TabIndex = 3;
            this.ReferenceFrameOffsetLabel.Text = "Reference Frame Offset (s)";
            // 
            // ReferenceFrameOffsetInput
            // 
            this.ReferenceFrameOffsetInput.DecimalPlaces = 1;
            this.ReferenceFrameOffsetInput.Location = new System.Drawing.Point(7, 66);
            this.ReferenceFrameOffsetInput.Name = "ReferenceFrameOffsetInput";
            this.ReferenceFrameOffsetInput.Size = new System.Drawing.Size(140, 23);
            this.ReferenceFrameOffsetInput.TabIndex = 5;
            this.ReferenceFrameOffsetInput.Tag = "Settings.BlackFrameDuration";
            this.ReferenceFrameOffsetInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DeleteOriginalCheckbox
            // 
            this.DeleteOriginalCheckbox.AutoSize = true;
            this.DeleteOriginalCheckbox.Location = new System.Drawing.Point(7, 123);
            this.DeleteOriginalCheckbox.Name = "DeleteOriginalCheckbox";
            this.DeleteOriginalCheckbox.Size = new System.Drawing.Size(155, 19);
            this.DeleteOriginalCheckbox.TabIndex = 7;
            this.DeleteOriginalCheckbox.Text = "Delete/Replace Originals";
            this.DeleteOriginalCheckbox.UseVisualStyleBackColor = true;
            // 
            // ProcessTypeLabel
            // 
            this.ProcessTypeLabel.AutoSize = true;
            this.ProcessTypeLabel.Location = new System.Drawing.Point(156, 99);
            this.ProcessTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProcessTypeLabel.Name = "ProcessTypeLabel";
            this.ProcessTypeLabel.Size = new System.Drawing.Size(109, 15);
            this.ProcessTypeLabel.TabIndex = 3;
            this.ProcessTypeLabel.Text = "Processing Method";
            // 
            // ProcessTypeComboBox
            // 
            this.ProcessTypeComboBox.FormattingEnabled = true;
            this.ProcessTypeComboBox.Location = new System.Drawing.Point(7, 95);
            this.ProcessTypeComboBox.Name = "ProcessTypeComboBox";
            this.ProcessTypeComboBox.Size = new System.Drawing.Size(140, 23);
            this.ProcessTypeComboBox.TabIndex = 6;
            this.ProcessTypeComboBox.Tag = "Settings.ProcessType";
            // 
            // BlackFrameDurationInput
            // 
            this.BlackFrameDurationInput.DecimalPlaces = 1;
            this.BlackFrameDurationInput.Location = new System.Drawing.Point(7, 7);
            this.BlackFrameDurationInput.Name = "BlackFrameDurationInput";
            this.BlackFrameDurationInput.Size = new System.Drawing.Size(140, 23);
            this.BlackFrameDurationInput.TabIndex = 5;
            this.BlackFrameDurationInput.Tag = "Settings.BlackFrameDuration";
            this.BlackFrameDurationInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BlackFrameThresholdInput
            // 
            this.BlackFrameThresholdInput.DecimalPlaces = 1;
            this.BlackFrameThresholdInput.Location = new System.Drawing.Point(7, 37);
            this.BlackFrameThresholdInput.Name = "BlackFrameThresholdInput";
            this.BlackFrameThresholdInput.Size = new System.Drawing.Size(140, 23);
            this.BlackFrameThresholdInput.TabIndex = 4;
            this.BlackFrameThresholdInput.Tag = "BlackFrameThreshold";
            this.BlackFrameThresholdInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BlackFrameThresholdLabel
            // 
            this.BlackFrameThresholdLabel.AutoSize = true;
            this.BlackFrameThresholdLabel.Location = new System.Drawing.Point(156, 40);
            this.BlackFrameThresholdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlackFrameThresholdLabel.Name = "BlackFrameThresholdLabel";
            this.BlackFrameThresholdLabel.Size = new System.Drawing.Size(126, 15);
            this.BlackFrameThresholdLabel.TabIndex = 3;
            this.BlackFrameThresholdLabel.Text = "Black Frame Threshold";
            // 
            // BlackFrameDurationLabel
            // 
            this.BlackFrameDurationLabel.AutoSize = true;
            this.BlackFrameDurationLabel.Location = new System.Drawing.Point(156, 12);
            this.BlackFrameDurationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlackFrameDurationLabel.Name = "BlackFrameDurationLabel";
            this.BlackFrameDurationLabel.Size = new System.Drawing.Size(136, 15);
            this.BlackFrameDurationLabel.TabIndex = 1;
            this.BlackFrameDurationLabel.Text = "Black Frame Duration (s)";
            // 
            // FFMPEGArgumentsGroupBox
            // 
            this.FFMPEGArgumentsGroupBox.Location = new System.Drawing.Point(7, 148);
            this.FFMPEGArgumentsGroupBox.Name = "FFMPEGArgumentsGroupBox";
            this.FFMPEGArgumentsGroupBox.Size = new System.Drawing.Size(455, 246);
            this.FFMPEGArgumentsGroupBox.TabIndex = 10;
            this.FFMPEGArgumentsGroupBox.TabStop = false;
            this.FFMPEGArgumentsGroupBox.Text = "FFMPEG Arguments";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(414, 449);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 478);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label BlackFrameThresholdLabel;
        private System.Windows.Forms.Label BlackFrameDurationLabel;
        private System.Windows.Forms.NumericUpDown BlackFrameDurationInput;
        private System.Windows.Forms.NumericUpDown BlackFrameThresholdInput;
        private System.Windows.Forms.Label ProcessTypeLabel;
        private System.Windows.Forms.ComboBox ProcessTypeComboBox;
        private System.Windows.Forms.Label FFMPEGArgumentsLegend;
        private System.Windows.Forms.TextBox FFMPEGArgumentsInput;
        private System.Windows.Forms.Label ReferenceFrameOffsetLabel;
        private System.Windows.Forms.NumericUpDown ReferenceFrameOffsetInput;
        private System.Windows.Forms.CheckBox DeleteOriginalCheckbox;
        private System.Windows.Forms.GroupBox FFMPEGArgumentsGroupBox;
        private System.Windows.Forms.Button SaveButton;
    }
}