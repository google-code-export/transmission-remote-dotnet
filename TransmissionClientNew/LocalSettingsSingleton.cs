using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public sealed class LocalSettingsSingleton
    {
        /* Some unconfigurable variables. */
        private readonly string REGISTRY_KEY = "Software\\TransmissionRemote";
        public static readonly int COMPLETED_BALOON_TIMEOUT = 4;
        public static readonly int FILES_REFRESH_MULTIPLICANT = 3;

        /* Registry keys */
        private static readonly string REGKEY_HOST = "host",
            REGKEY_PORT = "port",
            REGKEY_USESSL = "usessl",
            REGKEY_AUTOCONNECT = "autoConnect",
            REGKEY_USER = "user",
            REGKEY_PASS = "pass",
            REGKEY_AUTHENABLED = "authEnabled",
            REGKEY_PROXYENABLED = "proxyEnabled",
            REGKEY_PROXYHOST = "proxyHost",
            REGKEY_PROXYPORT = "proxyPort",
            REGKEY_PROXYUSER = "proxyUser",
            REGKEY_PROXYPASS = "proxyPass",
            REGKEY_PROXYAUTH = "proxyAuth",
            REGKEY_STARTPAUSED = "startPaused",
            REGKEY_RETRYLIMIT = "retryLimit",
            REGKEY_MINTOTRAY = "minToTray",
            REGKEY_REFRESHRATE = "refreshRate";

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
        public Boolean useSSL = false;
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
            if (key.GetValue(REGKEY_HOST) != null)
            {
                this.host = (string)key.GetValue(REGKEY_HOST);
            }
            if (key.GetValue(REGKEY_PORT) != null)
            {
                this.port = (int)key.GetValue(REGKEY_PORT);
            }
            if (key.GetValue(REGKEY_USESSL) != null)
            {
                this.useSSL = (int)key.GetValue(REGKEY_USESSL) == 1;
            }
            if (key.GetValue(REGKEY_AUTOCONNECT) != null)
            {
                this.autoConnect = (int)key.GetValue(REGKEY_AUTOCONNECT) == 1;
            }
            if (key.GetValue(REGKEY_REFRESHRATE) != null)
            {
                this.refreshRate = (int)key.GetValue(REGKEY_REFRESHRATE);
            }
            if (key.GetValue(REGKEY_USER) != null)
            {
                this.user = (string)key.GetValue(REGKEY_USER);
            }
            if (key.GetValue(REGKEY_PASS) != null)
            {
                this.pass = (string)key.GetValue(REGKEY_PASS);
            }
            if (key.GetValue(REGKEY_AUTHENABLED) != null)
            {
                this.authEnabled = (int)key.GetValue(REGKEY_AUTHENABLED) == 1;
            }
            if (key.GetValue(REGKEY_MINTOTRAY) != null)
            {
                this.minToTray = (int)key.GetValue(REGKEY_MINTOTRAY) == 1;
            }
            if (key.GetValue(REGKEY_PROXYENABLED) != null)
            {
                this.proxyEnabled = (int)key.GetValue(REGKEY_PROXYENABLED);
            }
            if (key.GetValue(REGKEY_PROXYHOST) != null)
            {
                this.proxyHost = (string)key.GetValue(REGKEY_PROXYHOST);
            }
            if (key.GetValue(REGKEY_PROXYPORT) != null)
            {
                this.proxyPort = (int)key.GetValue(REGKEY_PROXYPORT);
            }
            if (key.GetValue(REGKEY_PROXYUSER) != null)
            {
                this.proxyUser = (string)key.GetValue(REGKEY_PROXYUSER);
            }
            if (key.GetValue(REGKEY_PROXYPASS) != null)
            {
                this.proxyPass = (string)key.GetValue(REGKEY_PROXYPASS);
            }
            if (key.GetValue(REGKEY_PROXYAUTH) != null)
            {
                this.proxyAuth = (int)key.GetValue(REGKEY_PROXYAUTH) == 1;
            }
            if (key.GetValue(REGKEY_STARTPAUSED) != null)
            {
                this.startPaused = (int)key.GetValue(REGKEY_STARTPAUSED) == 1;
            }
            if (key.GetValue(REGKEY_RETRYLIMIT) != null)
            {
                this.retryLimit = (int)key.GetValue(REGKEY_RETRYLIMIT);
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
                key.SetValue(REGKEY_HOST, this.host);
                key.SetValue(REGKEY_PORT, this.port);
                key.SetValue(REGKEY_USESSL, this.useSSL ? 1 : 0);
                key.SetValue(REGKEY_REFRESHRATE, this.refreshRate);
                key.SetValue(REGKEY_AUTOCONNECT, this.autoConnect ? 1 : 0);
                key.SetValue(REGKEY_USER, this.user);
                key.SetValue(REGKEY_PASS, this.pass);
                key.SetValue(REGKEY_AUTHENABLED, this.authEnabled ? 1 : 0);
                key.SetValue(REGKEY_MINTOTRAY, this.minToTray ? 1 : 0);
                key.SetValue(REGKEY_PROXYENABLED, this.proxyEnabled);
                key.SetValue(REGKEY_PROXYHOST, this.proxyHost);
                key.SetValue(REGKEY_PROXYPORT, this.proxyPort);
                key.SetValue(REGKEY_PROXYUSER, this.proxyUser);
                key.SetValue(REGKEY_PROXYPASS, this.proxyPass);
                key.SetValue(REGKEY_PROXYAUTH, this.proxyAuth ? 1 : 0);
                key.SetValue(REGKEY_STARTPAUSED, this.startPaused ? 1 : 0);
                key.SetValue(REGKEY_RETRYLIMIT, this.retryLimit);
                Program.form.refreshTimer.Interval = refreshRate * 1000;
                Program.form.filesTimer.Interval = refreshRate * 1000 * FILES_REFRESH_MULTIPLICANT;
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
                return (useSSL?"https":"http")+"://" + this.host + ":" + this.port + "/transmission/";
            }
        }
    }
}
