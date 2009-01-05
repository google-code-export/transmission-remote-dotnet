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
        private const string REGISTRY_KEY_ROOT = "Software\\TransmissionRemote";
        public const int COMPLETED_BALOON_TIMEOUT = 4;
        public const int FILES_REFRESH_MULTIPLICANT = 3;

        /* Registry keys */
        private const string REGKEY_HOST = "host",
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
            REGKEY_REFRESHRATE = "refreshRate",
            REGKEY_CURRENTPROFILE = "currentProfile";

        private static LocalSettingsSingleton instance = null;
        private static readonly object padlock = new object();

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

        private string currentProfile;

        public string CurrentProfile
        {
            get
            {
                return this.currentProfile;
            }
            set
            {
                //Commit();
                if (Program.Connected)
                {
                    Program.Connected = false;
                }
                this.currentProfile = value;
                LoadCurrentProfile();
            }
        }

        public void RemoveProfile(string name)
        {
            if (name.Length > 0)
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_ROOT, true);
                    key.DeleteSubKey(name, false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string host;
        public int port;
        public Boolean useSSL;
        public int refreshRate;
        public Boolean autoConnect;
        public string user;
        public string pass;
        public Boolean authEnabled;
        public Boolean minToTray;
        public int proxyEnabled;
        public string proxyHost;
        public int proxyPort;
        public string proxyUser;
        public string proxyPass;
        public Boolean proxyAuth;
        public Boolean startPaused;
        public int retryLimit;

        private LocalSettingsSingleton()
        {
            RegistryKey key;
            if ((key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_ROOT)) == null)
            {
                key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY_ROOT);
            }
            if (key.GetValue(REGKEY_CURRENTPROFILE) != null)
            {
                this.CurrentProfile = (string)key.GetValue(REGKEY_CURRENTPROFILE);
            }
            else
            {
                this.CurrentProfile = "Default";
            }
            key.Close();
        }

        public void LoadCurrentProfile()
        {
            RegistryKey key;
            if ((key = Registry.CurrentUser.OpenSubKey(this.CurrentKey)) == null)
            {
                key = Registry.CurrentUser.CreateSubKey(this.CurrentKey);
            }
            if (key.GetValue(REGKEY_HOST) != null)
            {
                this.host = (string)key.GetValue(REGKEY_HOST);
            }
            else
            {
                this.host = "";
            }
            if (key.GetValue(REGKEY_PORT) != null)
            {
                this.port = (int)key.GetValue(REGKEY_PORT);
            }
            else
            {
                this.port = 9091;
            }
            if (key.GetValue(REGKEY_USESSL) != null)
            {
                this.useSSL = (int)key.GetValue(REGKEY_USESSL) == 1;
            }
            else
            {
                this.useSSL = false;
            }
            if (key.GetValue(REGKEY_AUTOCONNECT) != null)
            {
                this.autoConnect = (int)key.GetValue(REGKEY_AUTOCONNECT) == 1;
            }
            else
            {
                this.autoConnect = false;
            }
            if (key.GetValue(REGKEY_REFRESHRATE) != null)
            {
                this.refreshRate = (int)key.GetValue(REGKEY_REFRESHRATE);
            }
            else
            {
                this.refreshRate = 2;
            }
            if (key.GetValue(REGKEY_USER) != null)
            {
                this.user = (string)key.GetValue(REGKEY_USER);
            }
            else
            {
                this.user = "";
            }
            if (key.GetValue(REGKEY_PASS) != null)
            {
                this.pass = (string)key.GetValue(REGKEY_PASS);
            }
            else
            {
                this.pass = "";
            }
            if (key.GetValue(REGKEY_AUTHENABLED) != null)
            {
                this.authEnabled = (int)key.GetValue(REGKEY_AUTHENABLED) == 1;
            }
            else
            {
                this.authEnabled = false;
            }
            if (key.GetValue(REGKEY_MINTOTRAY) != null)
            {
                this.minToTray = (int)key.GetValue(REGKEY_MINTOTRAY) == 1;
            }
            else
            {
                this.minToTray = false;
            }
            if (key.GetValue(REGKEY_PROXYENABLED) != null)
            {
                this.proxyEnabled = (int)key.GetValue(REGKEY_PROXYENABLED);
            }
            else
            {
                this.proxyEnabled = 0;
            }
            if (key.GetValue(REGKEY_PROXYHOST) != null)
            {
                this.proxyHost = (string)key.GetValue(REGKEY_PROXYHOST);
            }
            else
            {
                this.proxyHost = "";
            }
            if (key.GetValue(REGKEY_PROXYPORT) != null)
            {
                this.proxyPort = (int)key.GetValue(REGKEY_PROXYPORT);
            }
            else
            {
                this.proxyPort = 8080;
            }
            if (key.GetValue(REGKEY_PROXYUSER) != null)
            {
                this.proxyUser = (string)key.GetValue(REGKEY_PROXYUSER);
            }
            else
            {
                this.proxyUser = "";
            }
            if (key.GetValue(REGKEY_PROXYPASS) != null)
            {
                this.proxyPass = (string)key.GetValue(REGKEY_PROXYPASS);
            }
            else
            {
                this.proxyPass = "";
            }
            if (key.GetValue(REGKEY_PROXYAUTH) != null)
            {
                this.proxyAuth = (int)key.GetValue(REGKEY_PROXYAUTH) == 1;
            }
            else
            {
                this.proxyAuth = false;
            }
            if (key.GetValue(REGKEY_STARTPAUSED) != null)
            {
                this.startPaused = (int)key.GetValue(REGKEY_STARTPAUSED) == 1;
            }
            else
            {
                this.startPaused = false;
            }
            if (key.GetValue(REGKEY_RETRYLIMIT) != null)
            {
                this.retryLimit = (int)key.GetValue(REGKEY_RETRYLIMIT);
            }
            else
            {
                this.retryLimit = 3;
            }
            key.Close();
        }

        private string CurrentKey
        {
            get
            {
                if (currentProfile.Equals("Default"))
                {
                    return REGISTRY_KEY_ROOT;
                }
                else
                {
                    return REGISTRY_KEY_ROOT + "\\" + currentProfile;
                }
            }
        }

        public List<string> Profiles
        {
            get
            {
                List<string> profiles = new List<string>();
                RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_ROOT);
                profiles.Add("Default");
                profiles.AddRange(key.GetSubKeyNames());
                return profiles;
            }
        }

        public void Commit()
        {
            try
            {
                RegistryKey rootKey;
                if ((rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_ROOT, true)) == null)
                {
                    rootKey = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY_ROOT);
                }
                rootKey.SetValue(REGKEY_CURRENTPROFILE, this.currentProfile);
                rootKey.Close();
                RegistryKey profileKey;
                if ((profileKey = Registry.CurrentUser.OpenSubKey(this.CurrentKey, true)) == null)
                {
                    profileKey = Registry.CurrentUser.CreateSubKey(this.CurrentKey);
                }
                profileKey.SetValue(REGKEY_HOST, this.host);
                profileKey.SetValue(REGKEY_PORT, this.port);
                profileKey.SetValue(REGKEY_USESSL, this.useSSL ? 1 : 0);
                profileKey.SetValue(REGKEY_REFRESHRATE, this.refreshRate);
                profileKey.SetValue(REGKEY_AUTOCONNECT, this.autoConnect ? 1 : 0);
                profileKey.SetValue(REGKEY_USER, this.user);
                profileKey.SetValue(REGKEY_PASS, this.pass);
                profileKey.SetValue(REGKEY_AUTHENABLED, this.authEnabled ? 1 : 0);
                profileKey.SetValue(REGKEY_MINTOTRAY, this.minToTray ? 1 : 0);
                profileKey.SetValue(REGKEY_PROXYENABLED, this.proxyEnabled);
                profileKey.SetValue(REGKEY_PROXYHOST, this.proxyHost);
                profileKey.SetValue(REGKEY_PROXYPORT, this.proxyPort);
                profileKey.SetValue(REGKEY_PROXYUSER, this.proxyUser);
                profileKey.SetValue(REGKEY_PROXYPASS, this.proxyPass);
                profileKey.SetValue(REGKEY_PROXYAUTH, this.proxyAuth ? 1 : 0);
                profileKey.SetValue(REGKEY_STARTPAUSED, this.startPaused ? 1 : 0);
                profileKey.SetValue(REGKEY_RETRYLIMIT, this.retryLimit);
                profileKey.Close();
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
                return (useSSL ? "https" : "http") + "://" + this.host + ":" + this.port + "/transmission/";
            }
        }
    }
}
