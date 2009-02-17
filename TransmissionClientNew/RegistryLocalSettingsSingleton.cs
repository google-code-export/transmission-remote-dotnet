#if !FILECONF
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public enum ProxyMode
    {
        Auto = 0,
        Enabled = 1,
        Disabled = 2
    }

    public sealed class LocalSettingsSingleton
    {
        /* Some unconfigurable variables. */
        private const string REGISTRY_KEY_ROOT = @"Software\TransmissionRemote";
        public const int COMPLETED_BALOON_TIMEOUT = 4;
        public const int FILES_REFRESH_MULTIPLICANT = 3;

        private Dictionary<string, object> confMap = new Dictionary<string, object>();

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
            REGKEY_CURRENTPROFILE = "currentProfile",
            REGKEY_CUSTOMPATH = "customPath";

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

        private LocalSettingsSingleton()
        {
            RegistryKey key = GetRootKey(false);
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

        public object GetObject(string key)
        {
            return this.confMap.ContainsKey(key) ? this.confMap[key] : null;
        }

        public void SetObject(string key, object value)
        {
            this.confMap[key] = value;
        }

        private RegistryKey GetProfileKey(string name, bool writeable)
        {
            if (name.Equals("Default"))
            {
                return GetRootKey(writeable);
            }
            else
            {
                return GetRootKey(false).OpenSubKey(name, writeable);
            }
        }

        public List<string> Profiles
        {
            get
            {
                List<string> profiles = new List<string>();
                profiles.AddRange(GetRootKey(false).GetSubKeyNames());
                profiles.Sort();
                profiles.Insert(0, "Default");
                return profiles;
            }
        }

        public void Commit()
        {
            RegistryKey profileKey = null;
            try
            {
                profileKey = GetProfileKey(this.CurrentProfile, true);
                if (profileKey != null)
                {
                    foreach (KeyValuePair<string, object> pair in this.confMap)
                    {
                        if (pair.Key != null && pair.Value != null)
                            profileKey.SetValue(pair.Key, pair.Value);
                    }
                }
                Program.Form.refreshTimer.Interval = RefreshRate * 1000;
                Program.Form.filesTimer.Interval = RefreshRate * 1000 * FILES_REFRESH_MULTIPLICANT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error writing settings to registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (profileKey != null)
                    profileKey.Close();
            }
        }

        public void CreateProfile(string name)
        {
            RegistryKey root = GetRootKey(true);
            root.CreateSubKey(name);
            root.Close();
            this.CurrentProfile = name;
        }

        private RegistryKey GetRootKey(bool writeable)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_ROOT, writeable);
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY_ROOT);
            return key;
        }

        public string CurrentProfile
        {
            get
            {
                RegistryKey rootKey = GetRootKey(false);
                if (rootKey.GetValue(REGKEY_CURRENTPROFILE) != null)
                {
                    return (string)rootKey.GetValue(REGKEY_CURRENTPROFILE);
                }
                else
                {
                    return "Default";
                }
            }
            set
            {
                RegistryKey profileKey = null;
                RegistryKey rootKey = null;
                if (Program.Connected)
                {
                    Program.Connected = false;
                }
                try
                {
                    rootKey = GetRootKey(true);
                    rootKey.SetValue(REGKEY_CURRENTPROFILE, value);
                    rootKey.Close();
                    profileKey = GetProfileKey(value, false);
                    this.confMap.Clear();
                    foreach (string subKey in profileKey.GetValueNames())
                    {
                        this.confMap[subKey] = profileKey.GetValue(subKey);
                    }
                    profileKey.Close();
                    if (Program.Form != null && AutoConnect)
                        Program.Form.Connect();
                }
                catch
                {
                    if (!value.Equals("Default"))
                        this.CurrentProfile = "Default";
                }
                finally
                {
                    if (profileKey != null)
                        profileKey.Close();
                    if (rootKey != null)
                        rootKey.Close();
                }
            }
        }

        public void RemoveProfile(string name)
        {
            RegistryKey key = GetRootKey(true);
            key.DeleteSubKeyTree(name);
            key.Close();
        }

        public string Host
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_HOST) ? (string)this.confMap[REGKEY_HOST] : "";
            }
            set
            {
                this.confMap[REGKEY_HOST] = value;
            }
        }

        public int Port
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PORT) ? (int)this.confMap[REGKEY_PORT] : 9091;
            }
            set
            {
                this.confMap[REGKEY_PORT] = value;
            }
        }

        public bool UseSSL
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_USESSL) ? IntToBool(this.confMap[REGKEY_USESSL]) : false;
            }
            set
            {
                this.confMap[REGKEY_USESSL] = BoolToInt(value);
            }
        }

        public int RefreshRate
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_REFRESHRATE) ? (int)this.confMap[REGKEY_REFRESHRATE] : 3;
            }
            set
            {
                this.confMap[REGKEY_REFRESHRATE] = value;
            }
        }

        public bool AutoConnect
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_AUTOCONNECT) ? IntToBool(this.confMap[REGKEY_AUTOCONNECT]) : false;
            }
            set
            {
                this.confMap[REGKEY_AUTOCONNECT] = BoolToInt(value);
            }
        }

        public string User
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_USER) ? (string)this.confMap[REGKEY_USER] : "";
            }
            set
            {
                this.confMap[REGKEY_USER] = value;
            }
        }

        public string Pass
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PASS) ? (string)this.confMap[REGKEY_PASS] : "";
            }
            set
            {
                this.confMap[REGKEY_PASS] = value;
            }
        }

        public bool AuthEnabled
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_AUTHENABLED) ? IntToBool(this.confMap[REGKEY_AUTHENABLED]) : false;
            }
            set
            {
                this.confMap[REGKEY_AUTHENABLED] = BoolToInt(value);
            }
        }

        private static bool IntToBool(object o)
        {
            return (int)o == 1;
        }

        private static int BoolToInt(bool b)
        {
            return b ? 1 : 0;
        }

        public bool MinToTray
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_MINTOTRAY) ? IntToBool(this.confMap[REGKEY_MINTOTRAY]) : false;
            }
            set
            {
                this.confMap[REGKEY_MINTOTRAY] = BoolToInt(value);
            }
        }

        public ProxyMode ProxyMode
        {
            get
            {
                if (this.confMap.ContainsKey(REGKEY_PROXYENABLED))
                {
                    return (ProxyMode)((int)this.confMap[REGKEY_PROXYENABLED]);
                }
                else
                {
                    return ProxyMode.Auto;
                }
            }
            set
            {
                this.confMap[REGKEY_PROXYENABLED] = (int)value;
            }
        }

        public string ProxyHost
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PROXYHOST) ? (string)this.confMap[REGKEY_PROXYHOST] : "";
            }
            set
            {
                this.confMap[REGKEY_PROXYHOST] = value;
            }
        }

        public int ProxyPort
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PROXYPORT) ? (int)this.confMap[REGKEY_PROXYPORT] : 8080;
            }
            set
            {
                this.confMap[REGKEY_PROXYPORT] = value;
            }
        }

        public string ProxyUser
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PROXYUSER) ? (string)this.confMap[REGKEY_PROXYUSER] : "";
            }
            set
            {
                this.confMap[REGKEY_PROXYUSER] = value;
            }
        }

        public string ProxyPass
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PROXYPASS) ? (string)this.confMap[REGKEY_PROXYPASS] : "";
            }
            set
            {
                this.confMap[REGKEY_PROXYPASS] = value;
            }
        }

        public bool ProxyAuth
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_PROXYAUTH) ? IntToBool(this.confMap[REGKEY_PROXYAUTH]) : false;
            }
            set
            {
                this.confMap[REGKEY_PROXYAUTH] = BoolToInt(value);
            }
        }

        public bool StartPaused
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_STARTPAUSED) ? IntToBool(this.confMap[REGKEY_STARTPAUSED]) : false;
            }
            set
            {
                this.confMap[REGKEY_STARTPAUSED] = BoolToInt(value);
            }
        }

        public int RetryLimit
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_RETRYLIMIT) ? (int)this.confMap[REGKEY_RETRYLIMIT] : 3;
            }
            set
            {
                this.confMap[REGKEY_RETRYLIMIT] = value;
            }
        }

        public string CustomPath
        {
            get
            {
                return this.confMap.ContainsKey(REGKEY_CUSTOMPATH) ? (string)this.confMap[REGKEY_CUSTOMPATH] : null;
            }
        }

        public string RpcUrl
        {
            get
            {
                return String.Format("{0}://{1}:{2}{3}rpc", new object[] { UseSSL ? "https" : "http", Host, Port, CustomPath == null ? "/transmission/" : CustomPath });
            }
        }
    }
}
#endif