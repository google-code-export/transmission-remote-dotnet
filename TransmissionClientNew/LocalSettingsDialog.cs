// transmission-remote-dotnet
// http://code.google.com/p/transmission-remote-dotnet/
// Copyright (C) 2009 Alan F
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public partial class LocalSettingsDialog : Form
    {
        private static LocalSettingsDialog instance = null;
        private static readonly object padlock = new object();

        public static LocalSettingsDialog Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new LocalSettingsDialog();
                    }
                }
                return instance;
            }
        }

        private string originalHost;
        private int originalPort;

        private LocalSettingsDialog()
        {
            InitializeComponent();
        }

        private void LoadCurrentProfile()
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            HostField.Text = originalHost = settings.Host;
            PortField.Value = originalPort = settings.Port;
            RefreshRateValue.Value = settings.RefreshRate;
            UseSSLCheckBox.Checked = settings.UseSSL;
            AutoConnectCheckBox.Checked = settings.AutoConnect;
            PassField.Enabled = UserField.Enabled = EnableAuthCheckBox.Checked = settings.AuthEnabled;
            UserField.Text = settings.User;
            PassField.Text = settings.Pass;
            MinToTrayCheckBox.Checked = settings.MinToTray;
            EnableProxyCombo.SelectedIndex = (int)settings.ProxyMode;
            ProxyPortField.Enabled = ProxyHostField.Enabled = settings.ProxyMode == ProxyMode.Enabled;
            ProxyHostField.Text = settings.ProxyHost;
            ProxyPortField.Value = settings.ProxyPort;
            ProxyAuthEnableCheckBox.Checked = settings.ProxyAuth;
            ProxyUserField.Enabled = ProxyPassField.Enabled = (settings.ProxyAuth && settings.ProxyMode == ProxyMode.Enabled);
            ProxyUserField.Text = settings.ProxyUser;
            ProxyPassField.Text = settings.ProxyPass;
            StartPausedCheckBox.Checked = settings.StartPaused;
            RetryLimitValue.Value = settings.RetryLimit;
            notificationOnAdditionCheckBox.Checked = settings.StartedBalloon;
            notificationOnCompletionCheckBox.Checked = settings.CompletedBaloon;
            minimizeOnCloseCheckBox.Checked = settings.MinOnClose;
            minimizeOnCloseCheckBox.Enabled = MinToTrayCheckBox.Checked;
            textBox2.Text = settings.PlinkPath;
            checkBox1.Checked = settings.PlinkEnable;
            textBox3.Text = settings.PlinkCmd;
        }

        private void LocalSettingsDialog_Load(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            List<string> profiles = settings.Profiles;
            for (int i = 0; i < profiles.Count; i++)
            {
                profileComboBox.Items.Add(profiles[i]);
                if (profiles[i].Equals(settings.CurrentProfile))
                {
                    profileComboBox.SelectedIndex = i;
                }
            }
            if (profileComboBox.SelectedIndex < 0)
            {
                profileComboBox.SelectedIndex = 0;
            }
            LoadCurrentProfile();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettings()
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            settings.Host = HostField.Text;
            settings.Port = (int)PortField.Value;
            settings.UseSSL = UseSSLCheckBox.Checked;
            settings.AutoConnect = AutoConnectCheckBox.Checked;
            settings.RefreshRate = (int)RefreshRateValue.Value;
            settings.AuthEnabled = EnableAuthCheckBox.Checked;
            settings.User = UserField.Text;
            settings.Pass = PassField.Text;
            Program.Form.notifyIcon.Visible = settings.MinToTray = MinToTrayCheckBox.Checked;
            settings.ProxyMode = (ProxyMode)EnableProxyCombo.SelectedIndex;
            settings.ProxyHost = ProxyHostField.Text;
            settings.ProxyPort = (int)ProxyPortField.Value;
            settings.ProxyAuth = ProxyAuthEnableCheckBox.Checked;
            settings.ProxyUser = ProxyUserField.Text;
            settings.ProxyPass = ProxyPassField.Text;
            settings.StartPaused = StartPausedCheckBox.Checked;
            settings.RetryLimit = (int)RetryLimitValue.Value;
            settings.StartedBalloon = notificationOnAdditionCheckBox.Checked;
            settings.CompletedBaloon = notificationOnCompletionCheckBox.Checked;
            settings.MinOnClose = minimizeOnCloseCheckBox.Checked;
            settings.PlinkCmd = textBox3.Text;
            settings.PlinkEnable = checkBox1.Checked;
            settings.PlinkPath = textBox2.Text;
            Program.Form.SetRemoteCmdButtonVisible(Program.Connected);
            settings.Commit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            if (Program.Connected && (settings.Host != originalHost || settings.Port != originalPort))
            {
                Program.Connected = false;
                Program.Form.Connect();
            }
            this.Close();
        }

        private void EnableAuthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PassField.Enabled = UserField.Enabled = EnableAuthCheckBox.Checked;
        }

        private void EnableProxyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProxyAuthEnableCheckBox.Enabled = ProxyHostField.Enabled = ProxyPortField.Enabled = (EnableProxyCombo.SelectedIndex == 1);
            ProxyUserField.Enabled = ProxyPassField.Enabled = (ProxyAuthEnableCheckBox.Checked && EnableProxyCombo.SelectedIndex == 1);
        }

        private void ProxyAuthEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ProxyUserField.Enabled = ProxyPassField.Enabled = ProxyAuthEnableCheckBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            if (Program.Connected)
            {
                Program.Connected = false;
            }
            Program.Form.Connect();
            this.Close();
        }

        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeProfileButton.Enabled = !profileComboBox.SelectedItem.ToString().Equals("Default");
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            string selectedProfile = profileComboBox.SelectedItem.ToString();
            foreach (ToolStripMenuItem item in Program.Form.connectButton.DropDownItems)
            {
                item.Checked = selectedProfile.Equals(item.ToString());
            }
            if (!selectedProfile.Equals(settings.CurrentProfile))
            {
                SaveSettings();
                settings.CurrentProfile = selectedProfile;
                LoadCurrentProfile();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            addProfileButton.Enabled = textBox1.Text.Length > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            ToolStripMenuItem profile = Program.Form.CreateProfileMenuItem(textBox1.Text);
            foreach (ToolStripMenuItem item in Program.Form.connectButton.DropDownItems)
            {
                item.Checked = false;
            }
            profile.Checked = true;
            settings.CreateProfile(textBox1.Text);
            profileComboBox.SelectedIndex = profileComboBox.Items.Add(textBox1.Text);
            textBox1.Text = "";
            LoadCurrentProfile();
        }

        private void removeProfileButton_Click(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            try
            {
                object selectedItem = profileComboBox.SelectedItem;
                settings.RemoveProfile(selectedItem.ToString());
                profileComboBox.SelectedIndex = 0;
                settings.CurrentProfile = "Default";
                profileComboBox.Items.Remove(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinToTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            minimizeOnCloseCheckBox.Enabled = MinToTrayCheckBox.Checked;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = textBox3.Enabled = ((CheckBox)sender).Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
