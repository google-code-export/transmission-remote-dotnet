using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jayrock.Json;
using System.Net;
using TransmissionRemoteDotnet.Commmands;

namespace TransmissionRemoteDotnet
{
    public delegate void ConnStatusChangedDelegate(bool connected);
    public delegate void TorrentsUpdatedDelegate();
    public delegate void OnErrorDelegate();

    static class Program
    {
        public static event ConnStatusChangedDelegate onConnStatusChanged;
        public static event TorrentsUpdatedDelegate onTorrentsUpdated;
        public static event OnErrorDelegate onError;

        private static Boolean connected = false;
        private static MainWindow form;

        public static MainWindow Form
        {
            get { return Program.form; }
            set { Program.form = value; }
        }
        private static Dictionary<int, Torrent> torrentIndex = new Dictionary<int, Torrent>();

        public static Dictionary<int, Torrent> TorrentIndex
        {
            get { return Program.torrentIndex; }
            set { Program.torrentIndex = value; }
        }
        private static TransmissionDaemonDescriptor daemonDescriptor = new TransmissionDaemonDescriptor();

        public static TransmissionDaemonDescriptor DaemonDescriptor
        {
            get { return Program.daemonDescriptor; }
            set { Program.daemonDescriptor = value; }
        }
        private static List<ListViewItem> logItems = new List<ListViewItem>();

        public static List<ListViewItem> LogItems
        {
            get { return Program.logItems; }
            set { Program.logItems = value; }
        }
        private static string[] uploadArgs;

        public static string[] UploadArgs
        {
            get { return Program.uploadArgs; }
            set { Program.uploadArgs = value; }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Guid guid = new Guid("{1a4ec788-d8f8-46b4-bb6b-598bc39f6307}");
            using (SingleInstance singleInstance = new SingleInstance(guid))
            {
                if (singleInstance.IsFirstInstance)
                {
                    ServicePointManager.Expect100Continue = false;
                    #if !MONO
                    ServicePointManager.ServerCertificateValidationCallback = TransmissionWebClient.ValidateServerCertificate;
                    #endif
                    /* Store a list of torrents to upload after connect? */
                    if (LocalSettingsSingleton.Instance.autoConnect && args.Length > 0)
                    {
                        Program.uploadArgs = args;
                    }
                    singleInstance.ArgumentsReceived += singleInstance_ArgumentsReceived;
                    singleInstance.ListenForArgumentsFromSuccessiveInstances();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(form = new MainWindow());
                }
                else
                {
                    singleInstance.PassArgumentsToFirstInstance(args);
                }
            }
        }

        public static void Log(string title, string body)
        {
            ListViewItem logItem = new ListViewItem(DateTime.Now.ToString());
            logItem.SubItems.Add(title);
            logItem.SubItems.Add(body);
            logItems.Add(logItem);
            if (onError != null)
            {
                onError();
            }
        }

        static void singleInstance_ArgumentsReceived(object sender, ArgumentsReceivedEventArgs e)
        {
            if (form != null)
            {
                if (e.Args.Length > 1)
                {
                    if (connected)
                    {
                        form.CreateUploadWorker().RunWorkerAsync(e.Args);
                    }
                    else
                    {
                        form.ShowMustBeConnectedDialog();
                    }
                }
                else
                {
                    form.InvokeShow();
                }
            }
        }

        public static void RaisePostUpdateEvent()
        {
            if (onTorrentsUpdated != null)
            {
                onTorrentsUpdated();
            }
        }

        public static bool Connected
        {
            set
            {
                connected = value;
                if (!connected)
                {
                    lock (torrentIndex)
                    {
                        torrentIndex.Clear();
                    }
                }
                if (onConnStatusChanged != null)
                {
                    onConnStatusChanged(connected);
                }
            }
            get
            {
                return connected;
            }
        }
    }
}
