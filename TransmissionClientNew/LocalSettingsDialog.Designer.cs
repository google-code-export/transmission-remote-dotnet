namespace TransmissionRemoteDotnet
{
    partial class LocalSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalSettingsDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.HostField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortField = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseDialogButton = new System.Windows.Forms.Button();
            this.AutoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RefreshRateValue = new System.Windows.Forms.NumericUpDown();
            this.UserField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EnableAuthCheckBox = new System.Windows.Forms.CheckBox();
            this.PassField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MinToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProxyAuthEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableProxyCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ProxyPassField = new System.Windows.Forms.TextBox();
            this.ProxyUserField = new System.Windows.Forms.TextBox();
            this.ProxyHostField = new System.Windows.Forms.TextBox();
            this.ProxyPortField = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StartPausedCheckBox = new System.Windows.Forms.CheckBox();
            this.RetryLimitValue = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.UseSSLCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRateValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPortField)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetryLimitValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host: ";
            // 
            // HostField
            // 
            this.HostField.Location = new System.Drawing.Point(88, 22);
            this.HostField.Name = "HostField";
            this.HostField.Size = new System.Drawing.Size(196, 20);
            this.HostField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port: ";
            // 
            // PortField
            // 
            this.PortField.Location = new System.Drawing.Point(87, 48);
            this.PortField.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortField.Name = "PortField";
            this.PortField.Size = new System.Drawing.Size(64, 20);
            this.PortField.TabIndex = 2;
            this.PortField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(13, 449);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(81, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.Location = new System.Drawing.Point(101, 449);
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.Size = new System.Drawing.Size(81, 23);
            this.CloseDialogButton.TabIndex = 5;
            this.CloseDialogButton.Text = "Cancel";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AutoConnectCheckBox
            // 
            this.AutoConnectCheckBox.AutoSize = true;
            this.AutoConnectCheckBox.Location = new System.Drawing.Point(201, 79);
            this.AutoConnectCheckBox.Name = "AutoConnectCheckBox";
            this.AutoConnectCheckBox.Size = new System.Drawing.Size(90, 17);
            this.AutoConnectCheckBox.TabIndex = 4;
            this.AutoConnectCheckBox.Text = "Auto connect";
            this.AutoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Refresh Rate:";
            // 
            // RefreshRateValue
            // 
            this.RefreshRateValue.Location = new System.Drawing.Point(87, 76);
            this.RefreshRateValue.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.RefreshRateValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RefreshRateValue.Name = "RefreshRateValue";
            this.RefreshRateValue.Size = new System.Drawing.Size(64, 20);
            this.RefreshRateValue.TabIndex = 6;
            this.RefreshRateValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UserField
            // 
            this.UserField.Location = new System.Drawing.Point(85, 22);
            this.UserField.Name = "UserField";
            this.UserField.Size = new System.Drawing.Size(109, 20);
            this.UserField.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User: ";
            // 
            // EnableAuthCheckBox
            // 
            this.EnableAuthCheckBox.AutoSize = true;
            this.EnableAuthCheckBox.Location = new System.Drawing.Point(202, 25);
            this.EnableAuthCheckBox.Name = "EnableAuthCheckBox";
            this.EnableAuthCheckBox.Size = new System.Drawing.Size(59, 17);
            this.EnableAuthCheckBox.TabIndex = 2;
            this.EnableAuthCheckBox.Text = "Enable";
            this.EnableAuthCheckBox.UseVisualStyleBackColor = true;
            this.EnableAuthCheckBox.CheckedChanged += new System.EventHandler(this.EnableAuthCheckBox_CheckedChanged);
            // 
            // PassField
            // 
            this.PassField.Location = new System.Drawing.Point(85, 48);
            this.PassField.Name = "PassField";
            this.PassField.PasswordChar = '*';
            this.PassField.Size = new System.Drawing.Size(109, 20);
            this.PassField.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.EnableAuthCheckBox);
            this.groupBox1.Controls.Add(this.PassField);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UserField);
            this.groupBox1.Location = new System.Drawing.Point(13, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UseSSLCheckBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.RetryLimitValue);
            this.groupBox2.Controls.Add(this.AutoConnectCheckBox);
            this.groupBox2.Controls.Add(this.RefreshRateValue);
            this.groupBox2.Controls.Add(this.PortField);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.HostField);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // MinToTrayCheckBox
            // 
            this.MinToTrayCheckBox.AutoSize = true;
            this.MinToTrayCheckBox.Location = new System.Drawing.Point(12, 19);
            this.MinToTrayCheckBox.Name = "MinToTrayCheckBox";
            this.MinToTrayCheckBox.Size = new System.Drawing.Size(102, 17);
            this.MinToTrayCheckBox.TabIndex = 0;
            this.MinToTrayCheckBox.Text = "Enable tray icon";
            this.MinToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProxyAuthEnableCheckBox);
            this.groupBox3.Controls.Add(this.EnableProxyCombo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ProxyPassField);
            this.groupBox3.Controls.Add(this.ProxyUserField);
            this.groupBox3.Controls.Add(this.ProxyHostField);
            this.groupBox3.Controls.Add(this.ProxyPortField);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 130);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proxy";
            // 
            // ProxyAuthEnableCheckBox
            // 
            this.ProxyAuthEnableCheckBox.AutoSize = true;
            this.ProxyAuthEnableCheckBox.Location = new System.Drawing.Point(202, 78);
            this.ProxyAuthEnableCheckBox.Name = "ProxyAuthEnableCheckBox";
            this.ProxyAuthEnableCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ProxyAuthEnableCheckBox.TabIndex = 7;
            this.ProxyAuthEnableCheckBox.Text = "Authenticate";
            this.ProxyAuthEnableCheckBox.UseVisualStyleBackColor = true;
            this.ProxyAuthEnableCheckBox.CheckedChanged += new System.EventHandler(this.ProxyAuthEnableCheckBox_CheckedChanged);
            // 
            // EnableProxyCombo
            // 
            this.EnableProxyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnableProxyCombo.FormattingEnabled = true;
            this.EnableProxyCombo.Items.AddRange(new object[] {
            "Auto",
            "Enabled",
            "Disabled"});
            this.EnableProxyCombo.Location = new System.Drawing.Point(201, 49);
            this.EnableProxyCombo.Name = "EnableProxyCombo";
            this.EnableProxyCombo.Size = new System.Drawing.Size(83, 21);
            this.EnableProxyCombo.TabIndex = 4;
            this.EnableProxyCombo.SelectedIndexChanged += new System.EventHandler(this.EnableProxyCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Port: ";
            // 
            // ProxyPassField
            // 
            this.ProxyPassField.Location = new System.Drawing.Point(87, 101);
            this.ProxyPassField.Name = "ProxyPassField";
            this.ProxyPassField.PasswordChar = '*';
            this.ProxyPassField.Size = new System.Drawing.Size(109, 20);
            this.ProxyPassField.TabIndex = 9;
            // 
            // ProxyUserField
            // 
            this.ProxyUserField.Location = new System.Drawing.Point(87, 75);
            this.ProxyUserField.Name = "ProxyUserField";
            this.ProxyUserField.Size = new System.Drawing.Size(109, 20);
            this.ProxyUserField.TabIndex = 6;
            // 
            // ProxyHostField
            // 
            this.ProxyHostField.Location = new System.Drawing.Point(87, 22);
            this.ProxyHostField.Name = "ProxyHostField";
            this.ProxyHostField.Size = new System.Drawing.Size(109, 20);
            this.ProxyHostField.TabIndex = 1;
            // 
            // ProxyPortField
            // 
            this.ProxyPortField.Location = new System.Drawing.Point(87, 48);
            this.ProxyPortField.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ProxyPortField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProxyPortField.Name = "ProxyPortField";
            this.ProxyPortField.Size = new System.Drawing.Size(64, 20);
            this.ProxyPortField.TabIndex = 3;
            this.ProxyPortField.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Password: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "User: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Host: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MinToTrayCheckBox);
            this.groupBox4.Controls.Add(this.StartPausedCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 69);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // StartPausedCheckBox
            // 
            this.StartPausedCheckBox.AutoSize = true;
            this.StartPausedCheckBox.Location = new System.Drawing.Point(12, 42);
            this.StartPausedCheckBox.Name = "StartPausedCheckBox";
            this.StartPausedCheckBox.Size = new System.Drawing.Size(124, 17);
            this.StartPausedCheckBox.TabIndex = 1;
            this.StartPausedCheckBox.Text = "Start torrents paused";
            this.StartPausedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RetryLimitValue
            // 
            this.RetryLimitValue.Location = new System.Drawing.Point(87, 104);
            this.RetryLimitValue.Name = "RetryLimitValue";
            this.RetryLimitValue.Size = new System.Drawing.Size(64, 20);
            this.RetryLimitValue.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Retry limit: ";
            // 
            // UseSSLCheckBox
            // 
            this.UseSSLCheckBox.AutoSize = true;
            this.UseSSLCheckBox.Location = new System.Drawing.Point(201, 51);
            this.UseSSLCheckBox.Name = "UseSSLCheckBox";
            this.UseSSLCheckBox.Size = new System.Drawing.Size(89, 17);
            this.UseSSLCheckBox.TabIndex = 3;
            this.UseSSLCheckBox.Text = "Secure (SSL)";
            this.UseSSLCheckBox.UseVisualStyleBackColor = true;
            // 
            // LocalSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 482);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocalSettingsDialog";
            this.Text = "Local Settings";
            this.Load += new System.EventHandler(this.LocalSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PortField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRateValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPortField)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetryLimitValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HostField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PortField;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseDialogButton;
        private System.Windows.Forms.CheckBox AutoConnectCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RefreshRateValue;
        private System.Windows.Forms.TextBox UserField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox EnableAuthCheckBox;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox MinToTrayCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProxyHostField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ProxyPortField;
        private System.Windows.Forms.ComboBox EnableProxyCombo;
        private System.Windows.Forms.TextBox ProxyPassField;
        private System.Windows.Forms.TextBox ProxyUserField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ProxyAuthEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox StartPausedCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown RetryLimitValue;
        private System.Windows.Forms.CheckBox UseSSLCheckBox;
    }
}