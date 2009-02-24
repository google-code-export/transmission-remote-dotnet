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
            this.UseSSLCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RetryLimitValue = new System.Windows.Forms.NumericUpDown();
            this.MinToTrayCheckBox = new System.Windows.Forms.CheckBox();
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
            this.StartPausedCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.notificationOnAdditionCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationOnCompletionCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.EnableAuthCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PassField = new System.Windows.Forms.TextBox();
            this.UserField = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.removeProfileButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.addProfileButton = new System.Windows.Forms.Button();
            this.minimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRateValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetryLimitValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPortField)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // HostField
            // 
            this.HostField.Location = new System.Drawing.Point(87, 18);
            this.HostField.Name = "HostField";
            this.HostField.Size = new System.Drawing.Size(156, 20);
            this.HostField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // PortField
            // 
            this.PortField.Location = new System.Drawing.Point(86, 44);
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
            this.SaveButton.Location = new System.Drawing.Point(13, 244);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(130, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseDialogButton.Location = new System.Drawing.Point(285, 244);
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.Size = new System.Drawing.Size(130, 23);
            this.CloseDialogButton.TabIndex = 5;
            this.CloseDialogButton.Text = "Cancel";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AutoConnectCheckBox
            // 
            this.AutoConnectCheckBox.AutoSize = true;
            this.AutoConnectCheckBox.Location = new System.Drawing.Point(273, 49);
            this.AutoConnectCheckBox.Name = "AutoConnectCheckBox";
            this.AutoConnectCheckBox.Size = new System.Drawing.Size(90, 17);
            this.AutoConnectCheckBox.TabIndex = 4;
            this.AutoConnectCheckBox.Text = "Auto connect";
            this.AutoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Refresh Rate:";
            // 
            // RefreshRateValue
            // 
            this.RefreshRateValue.Location = new System.Drawing.Point(86, 72);
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
            // UseSSLCheckBox
            // 
            this.UseSSLCheckBox.AutoSize = true;
            this.UseSSLCheckBox.Location = new System.Drawing.Point(273, 21);
            this.UseSSLCheckBox.Name = "UseSSLCheckBox";
            this.UseSSLCheckBox.Size = new System.Drawing.Size(89, 17);
            this.UseSSLCheckBox.TabIndex = 3;
            this.UseSSLCheckBox.Text = "Secure (SSL)";
            this.UseSSLCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Retry limit:";
            // 
            // RetryLimitValue
            // 
            this.RetryLimitValue.Location = new System.Drawing.Point(86, 100);
            this.RetryLimitValue.Name = "RetryLimitValue";
            this.RetryLimitValue.Size = new System.Drawing.Size(64, 20);
            this.RetryLimitValue.TabIndex = 7;
            // 
            // MinToTrayCheckBox
            // 
            this.MinToTrayCheckBox.AutoSize = true;
            this.MinToTrayCheckBox.Location = new System.Drawing.Point(10, 18);
            this.MinToTrayCheckBox.Name = "MinToTrayCheckBox";
            this.MinToTrayCheckBox.Size = new System.Drawing.Size(102, 17);
            this.MinToTrayCheckBox.TabIndex = 0;
            this.MinToTrayCheckBox.Text = "Enable tray icon";
            this.MinToTrayCheckBox.UseVisualStyleBackColor = true;
            this.MinToTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinToTrayCheckBox_CheckedChanged);
            // 
            // ProxyAuthEnableCheckBox
            // 
            this.ProxyAuthEnableCheckBox.AutoSize = true;
            this.ProxyAuthEnableCheckBox.Location = new System.Drawing.Point(274, 68);
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
            this.EnableProxyCombo.Location = new System.Drawing.Point(273, 39);
            this.EnableProxyCombo.Name = "EnableProxyCombo";
            this.EnableProxyCombo.Size = new System.Drawing.Size(83, 21);
            this.EnableProxyCombo.TabIndex = 4;
            this.EnableProxyCombo.SelectedIndexChanged += new System.EventHandler(this.EnableProxyCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Port:";
            // 
            // ProxyPassField
            // 
            this.ProxyPassField.Location = new System.Drawing.Point(87, 96);
            this.ProxyPassField.Name = "ProxyPassField";
            this.ProxyPassField.PasswordChar = '*';
            this.ProxyPassField.Size = new System.Drawing.Size(156, 20);
            this.ProxyPassField.TabIndex = 9;
            // 
            // ProxyUserField
            // 
            this.ProxyUserField.Location = new System.Drawing.Point(87, 70);
            this.ProxyUserField.Name = "ProxyUserField";
            this.ProxyUserField.Size = new System.Drawing.Size(156, 20);
            this.ProxyUserField.TabIndex = 6;
            // 
            // ProxyHostField
            // 
            this.ProxyHostField.Location = new System.Drawing.Point(87, 17);
            this.ProxyHostField.Name = "ProxyHostField";
            this.ProxyHostField.Size = new System.Drawing.Size(156, 20);
            this.ProxyHostField.TabIndex = 1;
            // 
            // ProxyPortField
            // 
            this.ProxyPortField.Location = new System.Drawing.Point(87, 43);
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
            this.label9.Location = new System.Drawing.Point(7, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "User:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Host:";
            // 
            // StartPausedCheckBox
            // 
            this.StartPausedCheckBox.AutoSize = true;
            this.StartPausedCheckBox.Location = new System.Drawing.Point(10, 41);
            this.StartPausedCheckBox.Name = "StartPausedCheckBox";
            this.StartPausedCheckBox.Size = new System.Drawing.Size(124, 17);
            this.StartPausedCheckBox.TabIndex = 1;
            this.StartPausedCheckBox.Text = "Start torrents paused";
            this.StartPausedCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(402, 167);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UseSSLCheckBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.HostField);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.RetryLimitValue);
            this.tabPage1.Controls.Add(this.PortField);
            this.tabPage1.Controls.Add(this.RefreshRateValue);
            this.tabPage1.Controls.Add(this.AutoConnectCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(394, 141);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.minimizeOnCloseCheckBox);
            this.tabPage4.Controls.Add(this.notificationOnAdditionCheckBox);
            this.tabPage4.Controls.Add(this.notificationOnCompletionCheckBox);
            this.tabPage4.Controls.Add(this.MinToTrayCheckBox);
            this.tabPage4.Controls.Add(this.StartPausedCheckBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(394, 141);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "General";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // notificationOnAdditionCheckBox
            // 
            this.notificationOnAdditionCheckBox.AutoSize = true;
            this.notificationOnAdditionCheckBox.Location = new System.Drawing.Point(10, 64);
            this.notificationOnAdditionCheckBox.Name = "notificationOnAdditionCheckBox";
            this.notificationOnAdditionCheckBox.Size = new System.Drawing.Size(134, 17);
            this.notificationOnAdditionCheckBox.TabIndex = 2;
            this.notificationOnAdditionCheckBox.Text = "Notification on addition";
            this.notificationOnAdditionCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationOnCompletionCheckBox
            // 
            this.notificationOnCompletionCheckBox.AutoSize = true;
            this.notificationOnCompletionCheckBox.Location = new System.Drawing.Point(10, 87);
            this.notificationOnCompletionCheckBox.Name = "notificationOnCompletionCheckBox";
            this.notificationOnCompletionCheckBox.Size = new System.Drawing.Size(148, 17);
            this.notificationOnCompletionCheckBox.TabIndex = 4;
            this.notificationOnCompletionCheckBox.Text = "Notification on completion";
            this.notificationOnCompletionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.EnableAuthCheckBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.PassField);
            this.tabPage2.Controls.Add(this.UserField);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(394, 141);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Authentication";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // EnableAuthCheckBox
            // 
            this.EnableAuthCheckBox.AutoSize = true;
            this.EnableAuthCheckBox.Location = new System.Drawing.Point(230, 21);
            this.EnableAuthCheckBox.Name = "EnableAuthCheckBox";
            this.EnableAuthCheckBox.Size = new System.Drawing.Size(129, 17);
            this.EnableAuthCheckBox.TabIndex = 2;
            this.EnableAuthCheckBox.Text = "Enable authentication";
            this.EnableAuthCheckBox.UseVisualStyleBackColor = true;
            this.EnableAuthCheckBox.CheckedChanged += new System.EventHandler(this.EnableAuthCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User:";
            // 
            // PassField
            // 
            this.PassField.Location = new System.Drawing.Point(84, 44);
            this.PassField.Name = "PassField";
            this.PassField.PasswordChar = '*';
            this.PassField.Size = new System.Drawing.Size(109, 20);
            this.PassField.TabIndex = 4;
            // 
            // UserField
            // 
            this.UserField.Location = new System.Drawing.Point(84, 18);
            this.UserField.Name = "UserField";
            this.UserField.Size = new System.Drawing.Size(109, 20);
            this.UserField.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ProxyAuthEnableCheckBox);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.EnableProxyCombo);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.ProxyPortField);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.ProxyHostField);
            this.tabPage3.Controls.Add(this.ProxyUserField);
            this.tabPage3.Controls.Add(this.ProxyPassField);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(394, 141);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Proxy";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save and Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // profileComboBox
            // 
            this.profileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(6, 19);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(133, 21);
            this.profileComboBox.TabIndex = 8;
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.profileComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.removeProfileButton);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.profileComboBox);
            this.groupBox5.Location = new System.Drawing.Point(13, 185);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 51);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Current profile";
            // 
            // removeProfileButton
            // 
            this.removeProfileButton.Enabled = false;
            this.removeProfileButton.Image = global::TransmissionRemoteDotnet.Properties.Resources._16x16_remove;
            this.removeProfileButton.Location = new System.Drawing.Point(150, 13);
            this.removeProfileButton.Name = "removeProfileButton";
            this.removeProfileButton.Size = new System.Drawing.Size(30, 30);
            this.removeProfileButton.TabIndex = 10;
            this.removeProfileButton.UseVisualStyleBackColor = true;
            this.removeProfileButton.Click += new System.EventHandler(this.removeProfileButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.addProfileButton);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Location = new System.Drawing.Point(225, 185);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 51);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "New profile";
            // 
            // addProfileButton
            // 
            this.addProfileButton.Enabled = false;
            this.addProfileButton.Image = global::TransmissionRemoteDotnet.Properties.Resources._16x16_add;
            this.addProfileButton.Location = new System.Drawing.Point(150, 13);
            this.addProfileButton.Name = "addProfileButton";
            this.addProfileButton.Size = new System.Drawing.Size(30, 30);
            this.addProfileButton.TabIndex = 11;
            this.addProfileButton.UseVisualStyleBackColor = true;
            this.addProfileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // minimizeOnCloseCheckBox
            // 
            this.minimizeOnCloseCheckBox.AutoSize = true;
            this.minimizeOnCloseCheckBox.Location = new System.Drawing.Point(10, 111);
            this.minimizeOnCloseCheckBox.Name = "minimizeOnCloseCheckBox";
            this.minimizeOnCloseCheckBox.Size = new System.Drawing.Size(109, 17);
            this.minimizeOnCloseCheckBox.TabIndex = 5;
            this.minimizeOnCloseCheckBox.Text = "Minimize on close";
            this.minimizeOnCloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // LocalSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseDialogButton;
            this.ClientSize = new System.Drawing.Size(431, 280);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LocalSettingsDialog";
            this.Text = "Local Settings";
            this.Load += new System.EventHandler(this.LocalSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PortField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshRateValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetryLimitValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPortField)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.CheckBox MinToTrayCheckBox;
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
        private System.Windows.Forms.CheckBox StartPausedCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown RetryLimitValue;
        private System.Windows.Forms.CheckBox UseSSLCheckBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addProfileButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button removeProfileButton;
        private System.Windows.Forms.CheckBox notificationOnAdditionCheckBox;
        private System.Windows.Forms.CheckBox notificationOnCompletionCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox EnableAuthCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.TextBox UserField;
        private System.Windows.Forms.CheckBox minimizeOnCloseCheckBox;
    }
}