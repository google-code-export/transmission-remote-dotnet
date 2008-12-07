using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace TransmissionClientNew
{
    public sealed class LocalSettingsSingleton
    {
        private readonly string REGISTRY_KEY = "Software\\TransmissionRemote";

        static LocalSettingsSingleton instance = null;

        static readonly object padlock = new object();

        public static LocalSettingsSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LocalSettingsSingleton();
                    }
                    return instance;
                }
            }
        }

        public string host = "";
        public int port = 9091;
        public int refreshRate = 5;
        public Boolean autoConnect = false;
        public string user = "";
        public string pass = "";
        public Boolean authEnabled = false;
        public Boolean minToTray = false;
        public int proxyEnabled = 0;
        public string proxyHost = "";
        public int proxyPort = 8080;
        public string proxyUser = "";
        public string proxyPass = "";
        public Boolean proxyAuth = false;
        public Boolean startPaused = false;
        public int retryLimit = 3;

        private LocalSettingsSingleton()
        {
            RegistryKey key;
            if ((key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY)) == null)
            {
                key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY);
            }
            if (key.GetValue("host") != null)
            {
                this.host = (string)key.GetValue("host");
            }
            if (key.GetValue("port") != null)
            {
                this.port = (int)key.GetValue("port");
            }
            if (key.GetValue("autoConnect") != null)
            {
                this.autoConnect = (int)key.GetValue("autoConnect") == 1;
            }
            if (key.GetValue("refreshRate") != null)
            {
                this.refreshRate = (int)key.GetValue("refreshRate");
            }
            if (key.GetValue("user") != null)
            {
                this.user = (string)key.GetValue("user");
            }
            if (key.GetValue("pass") != null)
            {
                this.pass = (string)key.GetValue("pass");
            }
            if (key.GetValue("authEnabled") != null)
            {
                this.authEnabled = (int)key.GetValue("authEnabled") == 1;
            }
            if (key.GetValue("minToTray") != null)
            {
                this.minToTray = (int)key.GetValue("minToTray") == 1;
            }
            if (key.GetValue("proxyEnabled") != null)
            {
                this.proxyEnabled = (int)key.GetValue("proxyEnabled");
            }
            if (key.GetValue("proxyHost") != null)
            {
                this.proxyHost = (string)key.GetValue("proxyHost");
            }
            if (key.GetValue("proxyPort") != null)
            {
                this.proxyPort = (int)key.GetValue("proxyPort");
            }
            if (key.GetValue("proxyUser") != null)
            {
                this.proxyUser = (string)key.GetValue("proxyUser");
            }
            if (key.GetValue("proxyPass") != null)
            {
                this.proxyPass = (string)key.GetValue("proxyPass");
            }
            if (key.GetValue("proxyAuth") != null)
            {
                this.proxyAuth = (int)key.GetValue("proxyAuth") == 1;
            }
            if (key.GetValue("startPaused") != null)
            {
                this.startPaused = (int)key.GetValue("startPaused") == 1;
            }
            if (key.GetValue("retryLimit") != null)
            {
                this.retryLimit = (int)key.GetValue("retryLimit");
            }
        }

        public void Commit()
        {
            try
            {
                RegistryKey key;
                if ((key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY, true)) == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY);
                }
                key.SetValue("host", this.host);
                key.SetValue("port", this.port);
                key.SetValue("refreshRate", this.refreshRate);
                key.SetValue("autoConnect", this.autoConnect ? 1 : 0);
                key.SetValue("user", this.user);
                key.SetValue("pass", this.pass);
                key.SetValue("authEnabled", this.authEnabled ? 1 : 0);
                key.SetValue("minToTray", this.minToTray ? 1 : 0);
                key.SetValue("proxyEnabled", this.proxyEnabled);
                key.SetValue("proxyHost", this.proxyHost);
                key.SetValue("proxyPort", this.proxyPort);
                key.SetValue("proxyUser", this.proxyUser);
                key.SetValue("proxyPass", this.proxyPass);
                key.SetValue("proxyAuth", this.proxyAuth ? 1 : 0);
                key.SetValue("startPaused", this.startPaused ? 1 : 0);
                key.SetValue("retryLimit", this.retryLimit);
                Program.form.RefreshTimer.Interval = refreshRate * 1000;
                Program.form.FilesTimer.Interval = refreshRate * 1000 * 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error writing settings to registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string URL
        {
            get
            {
                return "http://" + this.host + ":" + this.port + "/transmission/";
            }
        }
    }
}
