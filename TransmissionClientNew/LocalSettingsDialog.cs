using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public partial class LocalSettingsDialog : Form
    {
        private string originalHost;
        private int originalPort;

        public LocalSettingsDialog()
        {
            InitializeComponent();
        }

        private void LocalSettingsDialog_Load(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            HostField.Text = originalHost = settings.host;
            PortField.Value = originalPort = settings.port;
            RefreshRateValue.Value = settings.refreshRate;
            UseSSLCheckBox.Checked = settings.useSSL;
            AutoConnectCheckBox.Checked = settings.autoConnect;
            PassField.Enabled = UserField.Enabled = EnableAuthCheckBox.Checked = settings.authEnabled;
            UserField.Text = settings.user;
            PassField.Text = settings.pass;
            MinToTrayCheckBox.Checked = settings.minToTray;
            EnableProxyCombo.SelectedIndex = settings.proxyEnabled;
            ProxyPortField.Enabled = ProxyHostField.Enabled = settings.proxyEnabled == 1;
            ProxyHostField.Text = settings.proxyHost;
            ProxyPortField.Value = settings.proxyPort;
            ProxyAuthEnableCheckBox.Checked = settings.proxyAuth;
            ProxyUserField.Enabled = ProxyPassField.Enabled = (settings.proxyAuth && settings.proxyEnabled ==1);
            ProxyUserField.Text = settings.proxyUser;
            ProxyPassField.Text = settings.proxyPass;
            StartPausedCheckBox.Checked = settings.startPaused;
            RetryLimitValue.Value = settings.retryLimit;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            settings.host = HostField.Text;
            settings.port = (int)PortField.Value;
            settings.useSSL = UseSSLCheckBox.Checked;
            settings.autoConnect = AutoConnectCheckBox.Checked;
            settings.refreshRate = (int)RefreshRateValue.Value;
            settings.authEnabled = EnableAuthCheckBox.Checked;
            settings.user = UserField.Text;
            settings.pass = PassField.Text;
            Program.form.notifyIcon.Visible = settings.minToTray = MinToTrayCheckBox.Checked;
            settings.proxyEnabled = EnableProxyCombo.SelectedIndex;
            settings.proxyHost = ProxyHostField.Text;
            settings.proxyPort = (int)ProxyPortField.Value;
            settings.proxyAuth = ProxyAuthEnableCheckBox.Checked;
            settings.proxyUser = ProxyUserField.Text;
            settings.proxyPass = ProxyPassField.Text;
            settings.startPaused = StartPausedCheckBox.Checked;
            settings.retryLimit = (int)RetryLimitValue.Value;
            settings.Commit();
            if (Program.Connected && (settings.host != originalHost || settings.port != originalPort))
            {
                Program.Connected = false;
                Program.form.Connect();
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
    }
}
