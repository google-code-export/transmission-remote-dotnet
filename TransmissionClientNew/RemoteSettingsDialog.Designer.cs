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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DownloadToField
            // 
            resources.ApplyResources(this.DownloadToField, "DownloadToField");
            this.DownloadToField.Name = "DownloadToField";
            // 
            // LimitUploadCheckBox
            // 
            resources.ApplyResources(this.LimitUploadCheckBox, "LimitUploadCheckBox");
            this.LimitUploadCheckBox.Name = "LimitUploadCheckBox";
            this.LimitUploadCheckBox.UseVisualStyleBackColor = true;
            this.LimitUploadCheckBox.CheckedChanged += new System.EventHandler(this.LimitUploadCheckBox_CheckedChanged);
            // 
            // LimitUploadValue
            // 
            resources.ApplyResources(this.LimitUploadValue, "LimitUploadValue");
            this.LimitUploadValue.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.LimitUploadValue.Name = "LimitUploadValue";
            // 
            // LimitDownloadCheckBox
            // 
            resources.ApplyResources(this.LimitDownloadCheckBox, "LimitDownloadCheckBox");
            this.LimitDownloadCheckBox.Name = "LimitDownloadCheckBox";
            this.LimitDownloadCheckBox.UseVisualStyleBackColor = true;
            this.LimitDownloadCheckBox.CheckedChanged += new System.EventHandler(this.LimitDownloadCheckBox_CheckedChanged);
            // 
            // LimitDownloadValue
            // 
            resources.ApplyResources(this.LimitDownloadValue, "LimitDownloadValue");
            this.LimitDownloadValue.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.LimitDownloadValue.Name = "LimitDownloadValue";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // IncomingPortValue
            // 
            resources.ApplyResources(this.IncomingPortValue, "IncomingPortValue");
            this.IncomingPortValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.IncomingPortValue.Name = "IncomingPortValue";
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CloseFormButton, "CloseFormButton");
            this.CloseFormButton.Name = "CloseFormButton";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PeerLimitValue
            // 
            resources.ApplyResources(this.PeerLimitValue, "PeerLimitValue");
            this.PeerLimitValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PeerLimitValue.Name = "PeerLimitValue";
            // 
            // PEXcheckBox
            // 
            resources.ApplyResources(this.PEXcheckBox, "PEXcheckBox");
            this.PEXcheckBox.Name = "PEXcheckBox";
            this.PEXcheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // PortForward
            // 
            resources.ApplyResources(this.PortForward, "PortForward");
            this.PortForward.Name = "PortForward";
            this.PortForward.UseVisualStyleBackColor = true;
            // 
            // EncryptionCombobox
            // 
            this.EncryptionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptionCombobox.FormattingEnabled = true;
            this.EncryptionCombobox.Items.AddRange(new object[] {
            resources.GetString("EncryptionCombobox.Items"),
            resources.GetString("EncryptionCombobox.Items1"),
            resources.GetString("EncryptionCombobox.Items2")});
            resources.ApplyResources(this.EncryptionCombobox, "EncryptionCombobox");
            this.EncryptionCombobox.Name = "EncryptionCombobox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LimitDownloadValue);
            this.groupBox2.Controls.Add(this.LimitDownloadCheckBox);
            this.groupBox2.Controls.Add(this.LimitUploadValue);
            this.groupBox2.Controls.Add(this.LimitUploadCheckBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // RemoteSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseFormButton;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RemoteSettingsDialog";
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