#if FILECONF
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;
using System.IO;
using Jayrock.Json.Conversion;

namespace TransmissionRemoteDotnet
{
    public sealed class LocalSettingsSingleton
    {
        private JsonObject rootObject;

        /* Some unconfigurable variables. */
        private const string CONF_FILENAME = "settings.json";

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

        public void CreateProfile(string name)
        {
            rootObject.Put(name, new JsonObject());
            this.CurrentProfile = name;
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
                if (Program.Connected)
                {
                    Program.Connected = false;
                }
                this.currentProfile = value;
                LoadCurrentProfile();
                //Commit();
                if (Program.Form != null && autoConnect)
                {
                    Program.Form.Connect();
                }
            }
        }

        public void RemoveProfile(string name)
        {
            this.rootObject.Remove(name);
            Commit();
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
        public string customPath;
        private string urlCache;

        private string ConfFile
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), CONF_FILENAME);
            }
        }

        private LocalSettingsSingleton()
        {
            try
            {
                FileStream inFile = new FileStream(ConfFile, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                this.rootObject = (JsonObject)JsonConvert.Import(reader.ReadLine());
                reader.Close();
                this.CurrentProfile = rootObject.Contains("currentProfile") ? (string)rootObject["currentProfile"] : "Default";
            }
            catch
            {
                this.rootObject = new JsonObject();
                this.CurrentProfile = "Default";
            }
        }

        public void LoadCurrentProfile()
        {
            JsonObject key = GetCurrentProfileKey();
            this.customPath = key.Contains("customPath") ? (string)key["customPath"] : null;
            if (key.Contains(REGKEY_HOST))
            {
                this.host = (string)key[REGKEY_HOST];
            }
            else
            {
                this.host = "";
            }
            if (key.Contains(REGKEY_PORT))
            {
                this.port = (int)key[REGKEY_PORT];
            }
            else
            {
                this.port = 9091;
            }
            if (key.Contains(REGKEY_USESSL))
            {
                this.useSSL = ((JsonNumber)key[REGKEY_USESSL]).ToBoolean();
            }
            else
            {
                this.useSSL = false;
            }
            if (key.Contains(REGKEY_AUTOCONNECT))
            {
                this.autoConnect = ((JsonNumber)key[REGKEY_AUTOCONNECT]).ToBoolean();
            }
            else
            {
                this.autoConnect = false;
            }
            if (key.Contains(REGKEY_REFRESHRATE))
            {
                this.refreshRate = ((JsonNumber)key[REGKEY_REFRESHRATE]).ToInt32();
            }
            else
            {
                this.refreshRate = 2;
            }
            if (key.Contains(REGKEY_USER))
            {
                this.user = (string)key[REGKEY_USER];
            }
            else
            {
                this.user = "";
            }
            if (key.Contains(REGKEY_PASS))
            {
                this.pass = (string)key[REGKEY_PASS];
            }
            else
            {
                this.pass = "";
            }
            if (key.Contains(REGKEY_AUTHENABLED))
            {
                this.authEnabled = ((JsonNumber)key[REGKEY_AUTHENABLED]).ToBoolean();
            }
            else
            {
                this.authEnabled = false;
            }
            if (key.Contains(REGKEY_MINTOTRAY))
            {
                this.minToTray = ((JsonNumber)key[REGKEY_MINTOTRAY]).ToBoolean();
            }
            else
            {
                this.minToTray = false;
            }
            if (key.Contains(REGKEY_PROXYENABLED))
            {
                this.proxyEnabled = ((JsonNumber)key[REGKEY_PROXYENABLED]).ToInt32();
            }
            else
            {
                this.proxyEnabled = 0;
            }
            if (key.Contains(REGKEY_PROXYHOST))
            {
                this.proxyHost = (string)key[REGKEY_PROXYHOST];
            }
            else
            {
                this.proxyHost = "";
            }
            if (key.Contains(REGKEY_PROXYPORT))
            {
                this.proxyPort = ((JsonNumber)key[REGKEY_PROXYPORT]).ToInt32();
            }
            else
            {
                this.proxyPort = 8080;
            }
            if (key.Contains(REGKEY_PROXYUSER))
            {
                this.proxyUser = (string)key[REGKEY_PROXYUSER];
            }
            else
            {
                this.proxyUser = "";
            }
            if (key.Contains(REGKEY_PROXYPASS))
            {
                this.proxyPass = (string)key[REGKEY_PROXYPASS];
            }
            else
            {
                this.proxyPass = "";
            }
            if (key.Contains(REGKEY_PROXYAUTH))
            {
                this.proxyAuth = ((JsonNumber)key[REGKEY_PROXYAUTH]).ToBoolean();
            }
            else
            {
                this.proxyAuth = false;
            }
            if (key.Contains(REGKEY_STARTPAUSED))
            {
                this.startPaused = ((JsonNumber)key[REGKEY_STARTPAUSED]).ToBoolean();
            }
            else
            {
                this.startPaused = false;
            }
            if (key.Contains(REGKEY_RETRYLIMIT))
            {
                this.retryLimit = ((JsonNumber)key[REGKEY_RETRYLIMIT]).ToInt32();
            }
            else
            {
                this.retryLimit = 3;
            }
            RefreshUrlCache();
        }

        private JsonObject GetCurrentProfileKey()
        {
            return (JsonObject)this.rootObject[this.currentProfile];
        }

        public List<string> Profiles
        {
            get
            {
                List<string> profiles = new List<string>();
                foreach (string key in this.rootObject.Names)
                {
                    if (this.rootObject[key].GetType() == typeof(JsonObject))
                    {
                        profiles.Add(key);
                    }
                }
                profiles.Sort();
                profiles.Insert(0, "Default");
                return profiles;
            }
        }

        public void SaveProfileSelection()
        {
            this.rootObject["currentProfile"] = this.currentProfile;
        }

        public void Commit()
        {
            try
            {
                SaveProfileSelection();
                JsonObject profileKey = GetCurrentProfileKey();
                if (profileKey != null)
                {
                    profileKey.Put(REGKEY_HOST, this.host);
                    profileKey.Put(REGKEY_PORT, this.port);
                    profileKey.Put(REGKEY_USESSL, this.useSSL ? 1 : 0);
                    profileKey.Put(REGKEY_REFRESHRATE, this.refreshRate);
                    profileKey.Put(REGKEY_AUTOCONNECT, this.autoConnect ? 1 : 0);
                    profileKey.Put(REGKEY_USER, this.user);
                    profileKey.Put(REGKEY_PASS, this.pass);
                    profileKey.Put(REGKEY_AUTHENABLED, this.authEnabled ? 1 : 0);
                    profileKey.Put(REGKEY_MINTOTRAY, this.minToTray ? 1 : 0);
                    profileKey.Put(REGKEY_PROXYENABLED, this.proxyEnabled);
                    profileKey.Put(REGKEY_PROXYHOST, this.proxyHost);
                    profileKey.Put(REGKEY_PROXYPORT, this.proxyPort);
                    profileKey.Put(REGKEY_PROXYUSER, this.proxyUser);
                    profileKey.Put(REGKEY_PROXYPASS, this.proxyPass);
                    profileKey.Put(REGKEY_PROXYAUTH, this.proxyAuth ? 1 : 0);
                    profileKey.Put(REGKEY_STARTPAUSED, this.startPaused ? 1 : 0);
                    profileKey.Put(REGKEY_RETRYLIMIT, this.retryLimit);
                }
                FileStream inFile = new FileStream(ConfFile, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(inFile);
                writer.Write(this.rootObject.ToString());
                writer.Close();
                RefreshUrlCache();
                Program.Form.refreshTimer.Interval = refreshRate * 1000;
                Program.Form.filesTimer.Interval = refreshRate * 1000 * FILES_REFRESH_MULTIPLICANT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error writing settings to registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshUrlCache()
        {
            this.urlCache = String.Format("{0}://{1}:{2}{3}rpc", new object[] { useSSL ? "https" : "http", host, port, customPath == null ? "/transmission/" : customPath });
        }

        public string RpcUrl
        {
            get
            {
                return this.urlCache;
            }
        }
    }
}
#endif