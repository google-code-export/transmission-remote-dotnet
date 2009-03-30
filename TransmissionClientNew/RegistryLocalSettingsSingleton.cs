#if !FILECONF
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using Jayrock.Json;
using Jayrock.Json.Conversion;

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
            REGKEY_PLINKENABLE = "plinkEnable",
            REGKEY_LOCALE = "locale",
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
                    rootConfMap[subKey.Remove(0, 1)] = key.GetValue(subKey);
            }
            if (rootConfMap.ContainsKey(REGKEY_CURRENTPROFILE))
            {
                this.CurrentProfile = (string)rootConfMap[REGKEY_CURRENTPROFILE];
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
                return rootConfMap.ContainsKey(key) ? rootConfMap[key] : null;
            }
            else
            {
                return profileConfMap.ContainsKey(key) ? profileConfMap[key] : null;
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
                rootConfMap[key] = value;
            }
            else
            {
                profileConfMap[key] = value;
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
                foreach (KeyValuePair<string, object> pair in rootConfMap)
                {
                    if (pair.Key != null && pair.Value != null)
                        rootKey.SetValue("_"+pair.Key, pair.Value);
                }
                profileKey = GetProfileKey(this.CurrentProfile, true);
                if (profileKey != null)
                {
                    foreach (KeyValuePair<string, object> pair in profileConfMap)
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
                    profileConfMap.Clear();
                    foreach (string subKey in profileKey.GetValueNames())
                    {
                        if (!subKey.StartsWith("_"))
                            profileConfMap[subKey] = profileKey.GetValue(subKey);
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
                return profileConfMap.ContainsKey(REGKEY_HOST) ? (string)profileConfMap[REGKEY_HOST] : "";
            }
            set
            {
                profileConfMap[REGKEY_HOST] = value;
            }
        }

        public int Port
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PORT) ? (int)profileConfMap[REGKEY_PORT] : 9091;
            }
            set
            {
                profileConfMap[REGKEY_PORT] = value;
            }
        }

        public bool UseSSL
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_USESSL) ? IntToBool(profileConfMap[REGKEY_USESSL]) : false;
            }
            set
            {
                profileConfMap[REGKEY_USESSL] = BoolToInt(value);
            }
        }

        public int RefreshRate
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_REFRESHRATE) ? (int)profileConfMap[REGKEY_REFRESHRATE] : 3;
            }
            set
            {
                profileConfMap[REGKEY_REFRESHRATE] = value;
            }
        }

        public bool AutoConnect
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_AUTOCONNECT) ? IntToBool(profileConfMap[REGKEY_AUTOCONNECT]) : false;
            }
            set
            {
                profileConfMap[REGKEY_AUTOCONNECT] = BoolToInt(value);
            }
        }

        public string User
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_USER) ? (string)profileConfMap[REGKEY_USER] : "";
            }
            set
            {
                profileConfMap[REGKEY_USER] = value;
            }
        }

        public string Pass
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PASS) ? (string)profileConfMap[REGKEY_PASS] : "";
            }
            set
            {
                profileConfMap[REGKEY_PASS] = value;
            }
        }

        public bool AuthEnabled
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_AUTHENABLED) ? IntToBool(profileConfMap[REGKEY_AUTHENABLED]) : false;
            }
            set
            {
                profileConfMap[REGKEY_AUTHENABLED] = BoolToInt(value);
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
                return profileConfMap.ContainsKey(REGKEY_MINTOTRAY) ? IntToBool(profileConfMap[REGKEY_MINTOTRAY]) : false;
            }
            set
            {
                profileConfMap[REGKEY_MINTOTRAY] = BoolToInt(value);
            }
        }

        public ProxyMode ProxyMode
        {
            get
            {
                if (profileConfMap.ContainsKey(REGKEY_PROXYENABLED))
                {
                    return (ProxyMode)((int)profileConfMap[REGKEY_PROXYENABLED]);
                }
                else
                {
                    return ProxyMode.Auto;
                }
            }
            set
            {
                profileConfMap[REGKEY_PROXYENABLED] = (int)value;
            }
        }

        public string ProxyHost
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PROXYHOST) ? (string)profileConfMap[REGKEY_PROXYHOST] : "";
            }
            set
            {
                profileConfMap[REGKEY_PROXYHOST] = value;
            }
        }

        public string PlinkPath
        {
            get
            {
                return rootConfMap.ContainsKey(REGKEY_PLINKPATH) ? (string)rootConfMap[REGKEY_PLINKPATH] : null;
            }
            set
            {
                rootConfMap[REGKEY_PLINKPATH] = value;
            }
        }

        public string Locale
        {
            get
            {
                return rootConfMap.ContainsKey(REGKEY_LOCALE) ? (string)rootConfMap[REGKEY_LOCALE] : "en-GB";
            }
            set
            {
                rootConfMap[REGKEY_LOCALE] = value;
            }
        }

        public string PlinkCmd
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PLINKCMD) ? (string)profileConfMap[REGKEY_PLINKCMD] : "ls -lh \"$DATA\"; read";
            }
            set
            {
                profileConfMap[REGKEY_PLINKCMD] = value;
            }
        }

        public bool PlinkEnable
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PLINKENABLE) ? IntToBool(profileConfMap[REGKEY_PLINKENABLE]) : false;
            }
            set
            {
                profileConfMap[REGKEY_PLINKENABLE] = BoolToInt(value);
            }
        }

        public int ProxyPort
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PROXYPORT) ? (int)profileConfMap[REGKEY_PROXYPORT] : 8080;
            }
            set
            {
                profileConfMap[REGKEY_PROXYPORT] = value;
            }
        }

        public string ProxyUser
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PROXYUSER) ? (string)profileConfMap[REGKEY_PROXYUSER] : "";
            }
            set
            {
                profileConfMap[REGKEY_PROXYUSER] = value;
            }
        }

        public string ProxyPass
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PROXYPASS) ? (string)profileConfMap[REGKEY_PROXYPASS] : "";
            }
            set
            {
                profileConfMap[REGKEY_PROXYPASS] = value;
            }
        }

        public bool ProxyAuth
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_PROXYAUTH) ? IntToBool(profileConfMap[REGKEY_PROXYAUTH]) : false;
            }
            set
            {
                profileConfMap[REGKEY_PROXYAUTH] = BoolToInt(value);
            }
        }

        public bool StartPaused
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_STARTPAUSED) ? IntToBool(profileConfMap[REGKEY_STARTPAUSED]) : false;
            }
            set
            {
                profileConfMap[REGKEY_STARTPAUSED] = BoolToInt(value);
            }
        }

        public int RetryLimit
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_RETRYLIMIT) ? (int)profileConfMap[REGKEY_RETRYLIMIT] : 3;
            }
            set
            {
                profileConfMap[REGKEY_RETRYLIMIT] = value;
            }
        }

        public string CustomPath
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_CUSTOMPATH) ? (string)profileConfMap[REGKEY_CUSTOMPATH] : null;
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
                return profileConfMap.ContainsKey(REGKEY_STARTEDBALLOON) ? IntToBool(profileConfMap[REGKEY_STARTEDBALLOON]) : true;
            }
            set
            {
                profileConfMap[REGKEY_STARTEDBALLOON] = BoolToInt(value);
            }
        }

        public bool CompletedBaloon
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_COMPLETEDBALLOON) ? IntToBool(profileConfMap[REGKEY_COMPLETEDBALLOON]) : true;
            }
            set
            {
                profileConfMap[REGKEY_COMPLETEDBALLOON] = BoolToInt(value);
            }
        }

        public bool MinOnClose
        {
            get
            {
                return profileConfMap.ContainsKey(REGKEY_MINONCLOSE) ? IntToBool(profileConfMap[REGKEY_MINONCLOSE]) : false;
            }
            set
            {
                profileConfMap[REGKEY_MINONCLOSE] = BoolToInt(value);
            }
        }
    }
}
#endif