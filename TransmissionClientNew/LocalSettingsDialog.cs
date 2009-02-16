using System;
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
        private bool ignoreProfileIndexChanged = true;

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
            ignoreProfileIndexChanged = false;
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
            if (!ignoreProfileIndexChanged)
            {
                LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
                string selectedProfile = profileComboBox.SelectedItem.ToString();
                foreach (ToolStripMenuItem item in Program.Form.connectButton.DropDownItems)
                {
                    if (selectedProfile.Equals(item.ToString()))
                    {
                        item.Checked = true;
                    }
                    else
                    {
                        item.Checked = false;
                    }
                }
                if (!selectedProfile.Equals(settings.CurrentProfile))
                {
                    SaveSettings();
                    settings.CurrentProfile = selectedProfile;
                    LoadCurrentProfile();
                }
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
            ignoreProfileIndexChanged = true;
            settings.CreateProfile(textBox1.Text);
            profileComboBox.SelectedIndex = profileComboBox.Items.Add(textBox1.Text);
            ignoreProfileIndexChanged = false;
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
                profileComboBox.Items.Remove(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
