using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jayrock.Json;
using System.Net;

namespace TransmissionRemoteDotnet
{
    public delegate void ConnStatusChangedDelegate(bool connected);

    static class Program
    {
        public static event ConnStatusChangedDelegate connStatusChanged;
        private static Boolean connected = false;
        public static MainWindow form;
        public static Dictionary<int, Torrent> torrentIndex = new Dictionary<int, Torrent>();
        public static long updateSerial = 0;
        public static JsonObject sessionData;
        public static string[] uploadArgs;
        public static int failCount = 0;
        public static double transmissionVersion = 1.41;

        [STAThread]
        static void Main(string[] args)
        {
            Guid guid = new Guid("{1a4ec788-d8f8-46b4-bb6b-598bc39f6307}");
            using (SingleInstance singleInstance = new SingleInstance(guid))
            {
                if (singleInstance.IsFirstInstance)
                {
                    ServicePointManager.Expect100Continue = false;
                    ServicePointManager.ServerCertificateValidationCallback = TransmissionWebClient.ValidateServerCertificate;
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

        public static void ResetFailCount()
        {
            failCount = 0;
        }

        public static bool Connected
        {
            set
            {
                connected = value;
                if (connected)
                {
                    updateSerial = 0;
                }
                else
                {
                    lock (torrentIndex)
                    {
                        torrentIndex.Clear();
                    }
                }
                if (connStatusChanged != null)
                {
                    connStatusChanged(connected);
                }
            }
            get
            {
                return connected;
            }
        }
    }
}
