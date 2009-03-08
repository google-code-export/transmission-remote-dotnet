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
            this.minimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // HostField
            // 
            resources.ApplyResources(this.HostField, "HostField");
            this.HostField.Name = "HostField";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // PortField
            // 
            resources.ApplyResources(this.PortField, "PortField");
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
            this.PortField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CloseDialogButton, "CloseDialogButton");
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AutoConnectCheckBox
            // 
            resources.ApplyResources(this.AutoConnectCheckBox, "AutoConnectCheckBox");
            this.AutoConnectCheckBox.Name = "AutoConnectCheckBox";
            this.AutoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // RefreshRateValue
            // 
            resources.ApplyResources(this.RefreshRateValue, "RefreshRateValue");
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
            this.RefreshRateValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UseSSLCheckBox
            // 
            resources.ApplyResources(this.UseSSLCheckBox, "UseSSLCheckBox");
            this.UseSSLCheckBox.Name = "UseSSLCheckBox";
            this.UseSSLCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // RetryLimitValue
            // 
            resources.ApplyResources(this.RetryLimitValue, "RetryLimitValue");
            this.RetryLimitValue.Name = "RetryLimitValue";
            // 
            // MinToTrayCheckBox
            // 
            resources.ApplyResources(this.MinToTrayCheckBox, "MinToTrayCheckBox");
            this.MinToTrayCheckBox.Name = "MinToTrayCheckBox";
            this.MinToTrayCheckBox.UseVisualStyleBackColor = true;
            this.MinToTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinToTrayCheckBox_CheckedChanged);
            // 
            // ProxyAuthEnableCheckBox
            // 
            resources.ApplyResources(this.ProxyAuthEnableCheckBox, "ProxyAuthEnableCheckBox");
            this.ProxyAuthEnableCheckBox.Name = "ProxyAuthEnableCheckBox";
            this.ProxyAuthEnableCheckBox.UseVisualStyleBackColor = true;
            this.ProxyAuthEnableCheckBox.CheckedChanged += new System.EventHandler(this.ProxyAuthEnableCheckBox_CheckedChanged);
            // 
            // EnableProxyCombo
            // 
            this.EnableProxyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnableProxyCombo.FormattingEnabled = true;
            this.EnableProxyCombo.Items.AddRange(new object[] {
            resources.GetString("EnableProxyCombo.Items"),
            resources.GetString("EnableProxyCombo.Items1"),
            resources.GetString("EnableProxyCombo.Items2")});
            resources.ApplyResources(this.EnableProxyCombo, "EnableProxyCombo");
            this.EnableProxyCombo.Name = "EnableProxyCombo";
            this.EnableProxyCombo.SelectedIndexChanged += new System.EventHandler(this.EnableProxyCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ProxyPassField
            // 
            resources.ApplyResources(this.ProxyPassField, "ProxyPassField");
            this.ProxyPassField.Name = "ProxyPassField";
            // 
            // ProxyUserField
            // 
            resources.ApplyResources(this.ProxyUserField, "ProxyUserField");
            this.ProxyUserField.Name = "ProxyUserField";
            // 
            // ProxyHostField
            // 
            resources.ApplyResources(this.ProxyHostField, "ProxyHostField");
            this.ProxyHostField.Name = "ProxyHostField";
            // 
            // ProxyPortField
            // 
            resources.ApplyResources(this.ProxyPortField, "ProxyPortField");
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
            this.ProxyPortField.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // StartPausedCheckBox
            // 
            resources.ApplyResources(this.StartPausedCheckBox, "StartPausedCheckBox");
            this.StartPausedCheckBox.Name = "StartPausedCheckBox";
            this.StartPausedCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
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
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.minimizeOnCloseCheckBox);
            this.tabPage4.Controls.Add(this.notificationOnAdditionCheckBox);
            this.tabPage4.Controls.Add(this.notificationOnCompletionCheckBox);
            this.tabPage4.Controls.Add(this.MinToTrayCheckBox);
            this.tabPage4.Controls.Add(this.StartPausedCheckBox);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // minimizeOnCloseCheckBox
            // 
            resources.ApplyResources(this.minimizeOnCloseCheckBox, "minimizeOnCloseCheckBox");
            this.minimizeOnCloseCheckBox.Name = "minimizeOnCloseCheckBox";
            this.minimizeOnCloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationOnAdditionCheckBox
            // 
            resources.ApplyResources(this.notificationOnAdditionCheckBox, "notificationOnAdditionCheckBox");
            this.notificationOnAdditionCheckBox.Name = "notificationOnAdditionCheckBox";
            this.notificationOnAdditionCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationOnCompletionCheckBox
            // 
            resources.ApplyResources(this.notificationOnCompletionCheckBox, "notificationOnCompletionCheckBox");
            this.notificationOnCompletionCheckBox.Name = "notificationOnCompletionCheckBox";
            this.notificationOnCompletionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.EnableAuthCheckBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.PassField);
            this.tabPage2.Controls.Add(this.UserField);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // EnableAuthCheckBox
            // 
            resources.ApplyResources(this.EnableAuthCheckBox, "EnableAuthCheckBox");
            this.EnableAuthCheckBox.Name = "EnableAuthCheckBox";
            this.EnableAuthCheckBox.UseVisualStyleBackColor = true;
            this.EnableAuthCheckBox.CheckedChanged += new System.EventHandler(this.EnableAuthCheckBox_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // PassField
            // 
            resources.ApplyResources(this.PassField, "PassField");
            this.PassField.Name = "PassField";
            // 
            // UserField
            // 
            resources.ApplyResources(this.UserField, "UserField");
            this.UserField.Name = "UserField";
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
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // profileComboBox
            // 
            this.profileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.profileComboBox, "profileComboBox");
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.profileComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.removeProfileButton);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.profileComboBox);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // removeProfileButton
            // 
            resources.ApplyResources(this.removeProfileButton, "removeProfileButton");
            this.removeProfileButton.Image = global::TransmissionRemoteDotnet.Properties.Resources._16x16_remove;
            this.removeProfileButton.Name = "removeProfileButton";
            this.removeProfileButton.UseVisualStyleBackColor = true;
            this.removeProfileButton.Click += new System.EventHandler(this.removeProfileButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.addProfileButton);
            this.groupBox6.Controls.Add(this.textBox1);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // addProfileButton
            // 
            resources.ApplyResources(this.addProfileButton, "addProfileButton");
            this.addProfileButton.Image = global::TransmissionRemoteDotnet.Properties.Resources._16x16_add;
            this.addProfileButton.Name = "addProfileButton";
            this.addProfileButton.UseVisualStyleBackColor = true;
            this.addProfileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // LocalSettingsDialog
            // 
            this.AcceptButton = this.SaveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseDialogButton;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LocalSettingsDialog";
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