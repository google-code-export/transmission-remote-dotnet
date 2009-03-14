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
        public const int BALLOON_TIMEOUT = 4;
        public const int FILES_REFRESH_MULTIPLICANT = 3;

        private Dictionary<string, object> profileConfMap = new Dictionary<string, object>();
        private Dictionary<string, object> rootConfMap = new Dictionary<string, object>();

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
            REGKEY_STARTEDBALLOON = "startedBalloon",
            REGKEY_COMPLETEDBALLOON = "completedBalloon",
            REGKEY_MINONCLOSE = "minOnClose",
            REGKEY_PLINKPATH = "plinkPath",
            REGKEY_PLINKCMD = "plinkCmd",
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
            foreach (string subKey in key.GetValueNames())
            {
                if (subKey.StartsWith("_"))
                    this.rootConfMap[subKey.Remove(0, 1)] = key.GetValue(subKey);
            }
            if (this.rootConfMap.ContainsKey(REGKEY_CURRENTPROFILE))
            {
                this.CurrentProfile = (string)this.rootConfMap[REGKEY_CURRENTPROFILE];
            }
            else
            {
                this.CurrentProfile = "Default";
            }
            key.Close();
        }

        public object GetObject(string key)
        {
            return this.GetObject(key, true);
        }

        public object GetObject(string key, bool root)
        {
            if (root)
            {
                return this.rootConfMap.ContainsKey(key) ? this.rootConfMap[key] : null;
            }
            else
            {
                return this.profileConfMap.ContainsKey(key) ? this.profileConfMap[key] : null;
            }
        }

        public bool ContainsKey(string key, bool root)
        {
            return (root ? rootConfMap : profileConfMap).ContainsKey(key);
        }

        public bool ContainsKey(string key)
        {
            return this.ContainsKey(key, true);
        }

        public void SetObject(string key, object value)
        {
            this.SetObject(key, value, true);
        }

        public void SetObject(string key, object value, bool root)
        {
            if (root)
            {
                this.rootConfMap[key] = value;
            }
            else
            {
                this.profileConfMap[key] = value;
            }
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
            RegistryKey rootKey = null;
            try
            {
                rootKey = GetRootKey(true);
                foreach (KeyValuePair<string, object> pair in this.rootConfMap)
                {
                    if (pair.Key != null && pair.Value != null)
                        rootKey.SetValue("_"+pair.Key, pair.Value);
                }
                profileKey = GetProfileKey(this.CurrentProfile, true);
                if (profileKey != null)
                {
                    foreach (KeyValuePair<string, object> pair in this.profileConfMap)
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
                if (rootKey != null)
                    rootKey.Close();
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
                if (rootConfMap.ContainsKey(REGKEY_CURRENTPROFILE))
                {
                    return (string)rootConfMap[REGKEY_CURRENTPROFILE];
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
                    rootConfMap[REGKEY_CURRENTPROFILE] = value;
                    profileKey = GetProfileKey(value, false);
                    this.profileConfMap.Clear();
                    foreach (string subKey in profileKey.GetValueNames())
                    {
                        if (!subKey.StartsWith("_"))
                            this.profileConfMap[subKey] = profileKey.GetValue(subKey);
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
                return this.profileConfMap.ContainsKey(REGKEY_HOST) ? (string)this.profileConfMap[REGKEY_HOST] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_HOST] = value;
            }
        }

        public int Port
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PORT) ? (int)this.profileConfMap[REGKEY_PORT] : 9091;
            }
            set
            {
                this.profileConfMap[REGKEY_PORT] = value;
            }
        }

        public bool UseSSL
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_USESSL) ? IntToBool(this.profileConfMap[REGKEY_USESSL]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_USESSL] = BoolToInt(value);
            }
        }

        public int RefreshRate
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_REFRESHRATE) ? (int)this.profileConfMap[REGKEY_REFRESHRATE] : 3;
            }
            set
            {
                this.profileConfMap[REGKEY_REFRESHRATE] = value;
            }
        }

        public bool AutoConnect
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_AUTOCONNECT) ? IntToBool(this.profileConfMap[REGKEY_AUTOCONNECT]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_AUTOCONNECT] = BoolToInt(value);
            }
        }

        public string User
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_USER) ? (string)this.profileConfMap[REGKEY_USER] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_USER] = value;
            }
        }

        public string Pass
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PASS) ? (string)this.profileConfMap[REGKEY_PASS] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_PASS] = value;
            }
        }

        public bool AuthEnabled
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_AUTHENABLED) ? IntToBool(this.profileConfMap[REGKEY_AUTHENABLED]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_AUTHENABLED] = BoolToInt(value);
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
                return this.profileConfMap.ContainsKey(REGKEY_MINTOTRAY) ? IntToBool(this.profileConfMap[REGKEY_MINTOTRAY]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_MINTOTRAY] = BoolToInt(value);
            }
        }

        public ProxyMode ProxyMode
        {
            get
            {
                if (this.profileConfMap.ContainsKey(REGKEY_PROXYENABLED))
                {
                    return (ProxyMode)((int)this.profileConfMap[REGKEY_PROXYENABLED]);
                }
                else
                {
                    return ProxyMode.Auto;
                }
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYENABLED] = (int)value;
            }
        }

        public string ProxyHost
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PROXYHOST) ? (string)this.profileConfMap[REGKEY_PROXYHOST] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYHOST] = value;
            }
        }

        public string PlinkPath
        {
            get
            {
                return this.rootConfMap.ContainsKey(REGKEY_PLINKPATH) ? (string)this.rootConfMap[REGKEY_PLINKPATH] : @"c:\Program Files\PuTTY\plink.exe";
            }
            set
            {
                this.rootConfMap[REGKEY_PLINKPATH] = value;
            }
        }

        public string PlinkCmd
        {
            get
            {
                return rootConfMap.ContainsKey(REGKEY_PLINKCMD) ? (string)rootConfMap[REGKEY_PLINKCMD] : null;
            }
            set
            {
                rootConfMap[REGKEY_PLINKCMD] = value;
            }
        }

        public int ProxyPort
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PROXYPORT) ? (int)this.profileConfMap[REGKEY_PROXYPORT] : 8080;
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYPORT] = value;
            }
        }

        public string ProxyUser
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PROXYUSER) ? (string)this.profileConfMap[REGKEY_PROXYUSER] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYUSER] = value;
            }
        }

        public string ProxyPass
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PROXYPASS) ? (string)this.profileConfMap[REGKEY_PROXYPASS] : "";
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYPASS] = value;
            }
        }

        public bool ProxyAuth
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_PROXYAUTH) ? IntToBool(this.profileConfMap[REGKEY_PROXYAUTH]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_PROXYAUTH] = BoolToInt(value);
            }
        }

        public bool StartPaused
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_STARTPAUSED) ? IntToBool(this.profileConfMap[REGKEY_STARTPAUSED]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_STARTPAUSED] = BoolToInt(value);
            }
        }

        public int RetryLimit
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_RETRYLIMIT) ? (int)this.profileConfMap[REGKEY_RETRYLIMIT] : 3;
            }
            set
            {
                this.profileConfMap[REGKEY_RETRYLIMIT] = value;
            }
        }

        public string CustomPath
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_CUSTOMPATH) ? (string)this.profileConfMap[REGKEY_CUSTOMPATH] : null;
            }
        }

        public string RpcUrl
        {
            get
            {
                return String.Format("{0}://{1}:{2}{3}rpc", new object[] { UseSSL ? "https" : "http", Host, Port, CustomPath == null ? "/transmission/" : CustomPath });
            }
        }

        public bool StartedBalloon
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_STARTEDBALLOON) ? IntToBool(this.profileConfMap[REGKEY_STARTEDBALLOON]) : true;
            }
            set
            {
                this.profileConfMap[REGKEY_STARTEDBALLOON] = BoolToInt(value);
            }
        }

        public bool CompletedBaloon
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_COMPLETEDBALLOON) ? IntToBool(this.profileConfMap[REGKEY_COMPLETEDBALLOON]) : true;
            }
            set
            {
                this.profileConfMap[REGKEY_COMPLETEDBALLOON] = BoolToInt(value);
            }
        }

        public bool MinOnClose
        {
            get
            {
                return this.profileConfMap.ContainsKey(REGKEY_MINONCLOSE) ? IntToBool(this.profileConfMap[REGKEY_MINONCLOSE]) : false;
            }
            set
            {
                this.profileConfMap[REGKEY_MINONCLOSE] = BoolToInt(value);
            }
        }
    }
}
#endif