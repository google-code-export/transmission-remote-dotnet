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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PeerLimitValue = new System.Windows.Forms.NumericUpDown();
            this.PEXcheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PortForward = new System.Windows.Forms.CheckBox();
            this.EncryptionCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LimitUploadValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitDownloadValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingPortValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeerLimitValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download To:";
            // 
            // DownloadToField
            // 
            this.DownloadToField.Location = new System.Drawing.Point(111, 24);
            this.DownloadToField.Name = "DownloadToField";
            this.DownloadToField.Size = new System.Drawing.Size(176, 20);
            this.DownloadToField.TabIndex = 1;
            // 
            // LimitUploadCheckBox
            // 
            this.LimitUploadCheckBox.AutoSize = true;
            this.LimitUploadCheckBox.Location = new System.Drawing.Point(9, 24);
            this.LimitUploadCheckBox.Name = "LimitUploadCheckBox";
            this.LimitUploadCheckBox.Size = new System.Drawing.Size(82, 17);
            this.LimitUploadCheckBox.TabIndex = 4;
            this.LimitUploadCheckBox.Text = "Limit upload";
            this.LimitUploadCheckBox.UseVisualStyleBackColor = true;
            this.LimitUploadCheckBox.CheckedChanged += new System.EventHandler(this.LimitUploadCheckBox_CheckedChanged);
            // 
            // LimitUploadValue
            // 
            this.LimitUploadValue.Location = new System.Drawing.Point(111, 23);
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
            this.LimitDownloadCheckBox.Location = new System.Drawing.Point(9, 50);
            this.LimitDownloadCheckBox.Name = "LimitDownloadCheckBox";
            this.LimitDownloadCheckBox.Size = new System.Drawing.Size(96, 17);
            this.LimitDownloadCheckBox.TabIndex = 6;
            this.LimitDownloadCheckBox.Text = "Limit download";
            this.LimitDownloadCheckBox.UseVisualStyleBackColor = true;
            this.LimitDownloadCheckBox.CheckedChanged += new System.EventHandler(this.LimitDownloadCheckBox_CheckedChanged);
            // 
            // LimitDownloadValue
            // 
            this.LimitDownloadValue.Location = new System.Drawing.Point(111, 49);
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
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Incoming port:";
            // 
            // IncomingPortValue
            // 
            this.IncomingPortValue.Location = new System.Drawing.Point(111, 51);
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
            this.SaveButton.Location = new System.Drawing.Point(158, 266);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseFormButton.Location = new System.Drawing.Point(239, 266);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PeerLimitValue);
            this.groupBox1.Controls.Add(this.PEXcheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PortForward);
            this.groupBox1.Controls.Add(this.EncryptionCombobox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DownloadToField);
            this.groupBox1.Controls.Add(this.IncomingPortValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 167);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // PeerLimitValue
            // 
            this.PeerLimitValue.Location = new System.Drawing.Point(111, 108);
            this.PeerLimitValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PeerLimitValue.Name = "PeerLimitValue";
            this.PeerLimitValue.Size = new System.Drawing.Size(64, 20);
            this.PeerLimitValue.TabIndex = 14;
            // 
            // PEXcheckBox
            // 
            this.PEXcheckBox.AutoSize = true;
            this.PEXcheckBox.Location = new System.Drawing.Point(9, 138);
            this.PEXcheckBox.Name = "PEXcheckBox";
            this.PEXcheckBox.Size = new System.Drawing.Size(135, 17);
            this.PEXcheckBox.TabIndex = 13;
            this.PEXcheckBox.Text = "Enable Peer Exchange";
            this.PEXcheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Peer Limit";
            // 
            // PortForward
            // 
            this.PortForward.AutoSize = true;
            this.PortForward.Location = new System.Drawing.Point(201, 52);
            this.PortForward.Name = "PortForward";
            this.PortForward.Size = new System.Drawing.Size(78, 17);
            this.PortForward.TabIndex = 11;
            this.PortForward.Text = "Use UPNP";
            this.PortForward.UseVisualStyleBackColor = true;
            // 
            // EncryptionCombobox
            // 
            this.EncryptionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptionCombobox.FormattingEnabled = true;
            this.EncryptionCombobox.Items.AddRange(new object[] {
            "tolerated",
            "preferred",
            "required"});
            this.EncryptionCombobox.Location = new System.Drawing.Point(111, 79);
            this.EncryptionCombobox.Name = "EncryptionCombobox";
            this.EncryptionCombobox.Size = new System.Drawing.Size(102, 21);
            this.EncryptionCombobox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Encryption:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LimitDownloadValue);
            this.groupBox2.Controls.Add(this.LimitDownloadCheckBox);
            this.groupBox2.Controls.Add(this.LimitUploadValue);
            this.groupBox2.Controls.Add(this.LimitUploadCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(9, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 82);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Global speed limit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "KB/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "KB/s";
            // 
            // RemoteSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseFormButton;
            this.ClientSize = new System.Drawing.Size(326, 297);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RemoteSettingsDialog";
            this.Text = "Remote Settings";
            this.Load += new System.EventHandler(this.RemoteSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LimitUploadValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitDownloadValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingPortValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeerLimitValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EncryptionCombobox;
        private System.Windows.Forms.CheckBox PortForward;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox PEXcheckBox;
        private System.Windows.Forms.NumericUpDown PeerLimitValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}