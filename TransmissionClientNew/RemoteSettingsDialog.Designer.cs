namespace TransmissionRemoteDotnet
{
    partial class RemoteSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteSettingsDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadToField = new System.Windows.Forms.TextBox();
            this.LimitUploadCheckBox = new System.Windows.Forms.CheckBox();
            this.LimitUploadValue = new System.Windows.Forms.NumericUpDown();
            this.LimitDownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.LimitDownloadValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.IncomingPortValue = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.SettingsWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.LimitUploadValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitDownloadValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingPortValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download To: ";
            // 
            // DownloadToField
            // 
            this.DownloadToField.Location = new System.Drawing.Point(118, 12);
            this.DownloadToField.Name = "DownloadToField";
            this.DownloadToField.Size = new System.Drawing.Size(176, 20);
            this.DownloadToField.TabIndex = 1;
            // 
            // LimitUploadCheckBox
            // 
            this.LimitUploadCheckBox.AutoSize = true;
            this.LimitUploadCheckBox.Location = new System.Drawing.Point(16, 68);
            this.LimitUploadCheckBox.Name = "LimitUploadCheckBox";
            this.LimitUploadCheckBox.Size = new System.Drawing.Size(82, 17);
            this.LimitUploadCheckBox.TabIndex = 4;
            this.LimitUploadCheckBox.Text = "Limit upload";
            this.LimitUploadCheckBox.UseVisualStyleBackColor = true;
            this.LimitUploadCheckBox.CheckedChanged += new System.EventHandler(this.LimitUploadCheckBox_CheckedChanged);
            // 
            // LimitUploadValue
            // 
            this.LimitUploadValue.Location = new System.Drawing.Point(118, 67);
            this.LimitUploadValue.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.LimitUploadValue.Name = "LimitUploadValue";
            this.LimitUploadValue.Size = new System.Drawing.Size(64, 20);
            this.LimitUploadValue.TabIndex = 5;
            // 
            // LimitDownloadCheckBox
            // 
            this.LimitDownloadCheckBox.AutoSize = true;
            this.LimitDownloadCheckBox.Location = new System.Drawing.Point(16, 94);
            this.LimitDownloadCheckBox.Name = "LimitDownloadCheckBox";
            this.LimitDownloadCheckBox.Size = new System.Drawing.Size(96, 17);
            this.LimitDownloadCheckBox.TabIndex = 6;
            this.LimitDownloadCheckBox.Text = "Limit download";
            this.LimitDownloadCheckBox.UseVisualStyleBackColor = true;
            this.LimitDownloadCheckBox.CheckedChanged += new System.EventHandler(this.LimitDownloadCheckBox_CheckedChanged);
            // 
            // LimitDownloadValue
            // 
            this.LimitDownloadValue.Location = new System.Drawing.Point(118, 93);
            this.LimitDownloadValue.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.LimitDownloadValue.Name = "LimitDownloadValue";
            this.LimitDownloadValue.Size = new System.Drawing.Size(64, 20);
            this.LimitDownloadValue.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Incoming port: ";
            // 
            // IncomingPortValue
            // 
            this.IncomingPortValue.Location = new System.Drawing.Point(118, 39);
            this.IncomingPortValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.IncomingPortValue.Name = "IncomingPortValue";
            this.IncomingPortValue.Size = new System.Drawing.Size(64, 20);
            this.IncomingPortValue.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 126);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Location = new System.Drawing.Point(93, 126);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(75, 23);
            this.CloseFormButton.TabIndex = 9;
            this.CloseFormButton.Text = "Close";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // SettingsWorker
            // 
            this.SettingsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SettingsWorker_DoWork);
            this.SettingsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SettingsWorker_RunWorkerCompleted);
            // 
            // RemoteSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 159);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.IncomingPortValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LimitDownloadValue);
            this.Controls.Add(this.LimitDownloadCheckBox);
            this.Controls.Add(this.LimitUploadValue);
            this.Controls.Add(this.LimitUploadCheckBox);
            this.Controls.Add(this.DownloadToField);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteSettingsDialog";
            this.Text = "Remote Settings";
            this.Load += new System.EventHandler(this.RemoteSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LimitUploadValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitDownloadValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingPortValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DownloadToField;
        private System.Windows.Forms.CheckBox LimitUploadCheckBox;
        private System.Windows.Forms.NumericUpDown LimitUploadValue;
        private System.Windows.Forms.CheckBox LimitDownloadCheckBox;
        private System.Windows.Forms.NumericUpDown LimitDownloadValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown IncomingPortValue;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseFormButton;
        private System.ComponentModel.BackgroundWorker SettingsWorker;
    }
}