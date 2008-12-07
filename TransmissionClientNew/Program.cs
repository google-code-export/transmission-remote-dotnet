using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionClientNew
{
    static class Program
    {
        private static Boolean connected = false;
        public static Form1 form;
        public static Dictionary<int, Torrent> torrentIndex = new Dictionary<int, Torrent>();
        public static long updateSerial = 0;
        public static JsonObject sessionData;
        public static Dictionary<int, TorrentInfoDialog> infoDialogs = new Dictionary<int, TorrentInfoDialog>();
        public static string[] uploadArgs;
        public static Object updateLock = new Object();
        public static int failCount = 0;
        public static bool preAuthenticate = false;

        [STAThread]
        static void Main(string[] args)
        {
            Guid guid = new Guid("{1a4ec788-d8f8-46b4-bb6b-598bc39f6307}");
            using (SingleInstance singleInstance = new SingleInstance(guid))
            {
                if (singleInstance.IsFirstInstance)
                {
                    System.Net.ServicePointManager.Expect100Continue = false;
                    /* Store a list of torrents to upload after connect? */
                    if (LocalSettingsSingleton.Instance.autoConnect && args.Length > 0)
                    {
                        Program.uploadArgs = args;
                    }
                    singleInstance.ArgumentsReceived += singleInstance_ArgumentsReceived;
                    singleInstance.ListenForArgumentsFromSuccessiveInstances();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(form = new Form1());
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

        public static Boolean Connected
        {
            set
            {
                connected = value;
                ContextMenu trayMenu = new ContextMenu();
                if (connected)
                {
                    trayMenu.MenuItems.Add("Start all", new EventHandler(form.startAllToolStripMenuItem_Click));
                    trayMenu.MenuItems.Add("Stop all", new EventHandler(form.stopAllToolStripMenuItem_Click));
                    trayMenu.MenuItems.Add("-");
                    trayMenu.MenuItems.Add("Disconnect", new EventHandler(form.DisconnectButton_Click));
                    form.toolStripStatusLabel1.Text = "Connected.";
                    form.Text = "Transmission BitTorrent Controller - " + LocalSettingsSingleton.Instance.host;
                    updateSerial = 0;
                }
                else
                {
                    lock (updateLock)
                    {
                        foreach (KeyValuePair<int, TorrentInfoDialog> pair in Program.infoDialogs)
                        {
                            pair.Value.Close();
                        }
                        torrentIndex.Clear();
                    }
                    trayMenu.MenuItems.Add("Connect", new EventHandler(form.ConnectButton_Click));
                    form.toolStripStatusLabel1.Text = "Disconnected.";
                    form.Text = "Transmission BitTorrent Controller";
                    form.RefreshTimer.Enabled = false;
                    lock (updateLock)
                    {
                        form.TorrentListView.Items.Clear();
                    }
                }
                form.NotifyIcon.Text = "Transmission BitTorrent Controller";
                form.Connected(connected);
                trayMenu.MenuItems.Add("-");
                trayMenu.MenuItems.Add("Exit", new EventHandler(form.ExitApplicationHandler));
                form.NotifyIcon.ContextMenu = trayMenu;
            }
            get
            {
                return connected;
            }
        }
    }
}
