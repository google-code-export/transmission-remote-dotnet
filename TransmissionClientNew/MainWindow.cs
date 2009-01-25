using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TransmissionRemoteDotnet.Commmands;
using TransmissionRemoteDotnet.Comparers;
using Jayrock.Json;
using MaxMind;
using System.IO;

namespace TransmissionRemoteDotnet
{
    public partial class MainWindow : Form
    {
        private const string DEFAULT_WINDOW_TITLE = "Transmission Remote";
        private const string GEOIP_DATABASE_FILE = "GeoIP.dat";

        private Boolean minimise = false;
        private ListViewItemSorter lvwColumnSorter;
        private FilesListViewItemSorter filesLvwColumnSorter;
        private PeersListViewItemSorter peersLvwColumnSorter;
        private ContextMenu torrentSelectionMenu;
        private ContextMenu noTorrentSelectionMenu;
        private ContextMenu fileSelectionMenu;
        private ContextMenu noFileSelectionMenu;
        private BackgroundWorker connectWorker;
        private TabPage peersTabPageSaved;
        private GeoIPCountry geo;
        private List<ListViewItem> fileItems = new List<ListViewItem>();

        public List<ListViewItem> FileItems
        {
            get { return fileItems; }
            set { fileItems = value; }
        }

        public MainWindow()
        {
            Program.onConnStatusChanged += new ConnStatusChangedDelegate(Program_connStatusChanged);
            Program.onTorrentsUpdated += new TorrentsUpdatedDelegate(Program_onTorrentsUpdated);
            InitializeComponent();
            tabControlImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.folder16);
            filesTabPage.ImageIndex = 0;
            tabControlImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.peer16);
            peersTabPage.ImageIndex = 1;
            tabControlImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.server16);
            trackersTabPage.ImageIndex = 2;
            tabControlImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.pipe16);
            speedTabPage.ImageIndex = 3;
            tabControlImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.info16);
            generalTabPage.ImageIndex = 4;
            mainVerticalSplitContainer.Panel1Collapsed = torrentAndTabsSplitContainer.Panel2Collapsed = true;
            this.peersTabPageSaved = this.peersTabPage;
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            refreshTimer.Interval = settings.refreshRate * 1000;
            filesTimer.Interval = settings.refreshRate * 1000 * LocalSettingsSingleton.FILES_REFRESH_MULTIPLICANT;
            torrentListView.ListViewItemSorter = lvwColumnSorter = new ListViewItemSorter();
            filesListView.ListViewItemSorter = filesLvwColumnSorter = new FilesListViewItemSorter();
            peersListView.ListViewItemSorter = peersLvwColumnSorter = new PeersListViewItemSorter();
            InitStaticContextMenus();
            InitStateListBox();
            speedGraph.AddLine("Download", Color.Green);
            speedGraph.AddLine("Upload", Color.Yellow);
            speedResComboBox.SelectedIndex = 2;
        }

        private void InitStateListBox()
        {
            stateListBox.SuspendLayout();
            ImageList stateListBoxImageList = new ImageList();
            stateListBoxImageList.ColorDepth = ColorDepth.Depth32Bit;
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources._16x16_ledblue);
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.down16);
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.player_pause16);
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.apply16);
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.up16);
            stateListBoxImageList.Images.Add(global::TransmissionRemoteDotnet.Properties.Resources.player_reload16);
            stateListBox.ImageList = stateListBoxImageList;
            stateListBox.Items.Add(new GListBoxItem("All", 0));
            stateListBox.Items.Add(new GListBoxItem("Downloading", 1));
            stateListBox.Items.Add(new GListBoxItem("Paused", 2));
            stateListBox.Items.Add(new GListBoxItem("Checking", 5));
            stateListBox.Items.Add(new GListBoxItem("Complete", 3));
            stateListBox.Items.Add(new GListBoxItem("Seeding", 4));
            stateListBox.Items.Add(new GListBoxItem(""));
            stateListBox.ResumeLayout();
        }

        private void InitStaticContextMenus()
        {
            this.peersListView.ContextMenu = new ContextMenu(new MenuItem[]{
                new MenuItem("Select All", new EventHandler(this.SelectAllPeersHandler)),
                new MenuItem("Copy as CSV", new EventHandler(this.PeersToClipboardHandler))
            });
            this.noTorrentSelectionMenu = torrentListView.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Select All", new EventHandler(this.SelectAllTorrentsHandler))
            });
            this.fileSelectionMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("High Priority", new EventHandler(this.SetHighPriorityHandler)),
                new MenuItem("Normal Priority", new EventHandler(this.SetNormalPriorityHandler)),
                new MenuItem("Low Priority", new EventHandler(this.SetLowPriorityHandler)),
                new MenuItem("-"),
                new MenuItem("Download", new EventHandler(this.SetWantedHandler)),
                new MenuItem("Skip", new EventHandler(this.SetUnwantedHandler)),
                new MenuItem("-"),
                new MenuItem("Select All", new EventHandler(this.SelectAllFilesHandler)),
                new MenuItem("Copy as CSV", new EventHandler(this.FilesToClipboardHandler))
            });
            this.noFileSelectionMenu = this.filesListView.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Select All", new EventHandler(this.SelectAllFilesHandler))
            });
        }

        private void CreateTorrentSelectionContextMenu()
        {
            this.torrentSelectionMenu = new ContextMenu();
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Start", new EventHandler(this.startTorrentButton_Click)));
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Pause", new EventHandler(this.pauseTorrentButton_Click)));
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Remove", new EventHandler(this.removeTorrentButton_Click)));
            if (Program.DaemonDescriptor.Revision >= 7331)
            {
                this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Remove and delete", new EventHandler(this.removeAndDeleteButton_Click)));
            }
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Recheck", new EventHandler(this.recheckTorrentButton_Click)));
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("-"));
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Properties", new EventHandler(this.ShowTorrentPropsHandler)));
            this.torrentSelectionMenu.MenuItems.Add(new MenuItem("Copy as CSV", new EventHandler(this.TorrentsToClipboardHandler)));
        }

        private void OpenGeoipDatabase()
        {
            try
            {
                geo = new GeoIPCountry(GEOIP_DATABASE_FILE);
                for (int i = 1; i < GeoIPCountry.CountryCodes.Length; i++)
                {
                    string flagname = "flags_" + GeoIPCountry.CountryCodes[i].ToLower();
                    Bitmap flag = global::TransmissionRemoteDotnet.Properties.Flags.GetFlags(flagname);
                    if (flag != null)
                    {
                        flagsImageList.Images.Add(flagname, flag);
                    }
                }
                this.peersListView.SmallImageList = this.flagsImageList;
            }
            catch (Exception ex)
            {
                Program.Log("GeoIP init error (" + ex.GetType().ToString() + ")", ex.Message);
            }
        }

        private void Program_onTorrentsUpdated()
        {
            lock (torrentListView)
            {
                UpdateInfoPanel(false);
                torrentListView.Enabled = true;
                mainVerticalSplitContainer.Panel1Collapsed = false;
            }
            refreshTimer.Enabled = true;
            FilterByStateOrTracker();
            torrentListView.Sort();
            Toolbox.StripeListView(torrentListView);
        }

        private void Program_connStatusChanged(Boolean connected)
        {
            ContextMenu trayMenu = new ContextMenu();
            if (connected)
            {
                CreateTorrentSelectionContextMenu();
                trayMenu.MenuItems.Add("Start all", new EventHandler(this.startAllMenuItem_Click));
                trayMenu.MenuItems.Add("Stop all", new EventHandler(this.stopAllMenuItem_Click));
                trayMenu.MenuItems.Add("-");
                if (Program.DaemonDescriptor.RpcVersion >= 4)
                {
                    trayMenu.MenuItems.Add("Display Statistics", new EventHandler(this.sessionStatsButton_Click));
                }
                trayMenu.MenuItems.Add("Disconnect", new EventHandler(this.disconnectButton_Click));
                this.toolStripStatusLabel.Text = "Connected. Getting torrent information...";
                this.Text = MainWindow.DEFAULT_WINDOW_TITLE + " - " + LocalSettingsSingleton.Instance.host;
                speedGraph.GetLineHandle("Download").Clear();
                speedGraph.GetLineHandle("Upload").Clear();
                speedGraph.Push(0, "Download");
                speedGraph.Push(0, "Upload");
            }
            else
            {
                torrentListView.Enabled = false;
                torrentListView.ContextMenu = this.torrentSelectionMenu = null;
                lock (this.torrentListView)
                {
                    this.torrentListView.Items.Clear();
                }
                trayMenu.MenuItems.Add("Connect", new EventHandler(this.connectButton_Click));
                this.toolStripStatusLabel.Text = "Disconnected.";
                this.Text = MainWindow.DEFAULT_WINDOW_TITLE;
                this.torrentAndTabsSplitContainer.Panel2Collapsed = this.mainVerticalSplitContainer.Panel1Collapsed = true;
                if (this.stateListBox.Items.Count > 6)
                {
                    lock (this.stateListBox)
                    {
                        for (int i = this.stateListBox.Items.Count-1; i > 6; i--)
                        {
                            stateListBox.Items.RemoveAt(i);
                        }
                    }
                }
            }
            this.notifyIcon.Text = MainWindow.DEFAULT_WINDOW_TITLE;
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", new EventHandler(this.exitToolStripMenuItem_Click));
            this.notifyIcon.ContextMenu = trayMenu;
            connectButton.Visible = connectToolStripMenuItem.Visible
                = !connected;
            disconnectButton.Visible = addTorrentToolStripMenuItem.Visible
                = addTorrentButton.Visible = addWebTorrentButton.Visible
                = remoteConfigureButton.Visible = pauseTorrentButton.Visible
                = removeTorrentButton.Visible = toolStripSeparator4.Visible
                = toolStripSeparator1.Visible = disconnectToolStripMenuItem.Visible
                = toolStripSeparator2.Visible = torrentTabControl.Enabled
                = remoteSettingsToolStripMenuItem.Visible = fileMenuItemSeperator1.Visible
                = addTorrentFromUrlToolStripMenuItem.Visible = startTorrentButton.Visible
                = refreshTimer.Enabled = recheckTorrentButton.Visible
                = connected;
            removeAndDeleteButton.Visible = connected && Program.DaemonDescriptor.Revision >= 7331;
            sessionStatsButton.Visible = connected && Program.DaemonDescriptor.RpcVersion >= 4;
        }

        public void TorrentsToClipboardHandler(object sender, EventArgs e)
        {
            Toolbox.CopyListViewToClipboard(torrentListView);
        }

        public void FilesToClipboardHandler(object sender, EventArgs e)
        {
            Toolbox.CopyListViewToClipboard(filesListView);
        }

        public void PeersToClipboardHandler(object sender, EventArgs e)
        {
            Toolbox.CopyListViewToClipboard(peersListView);
        }

        public void startAllMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTART, null));
        }

        public void stopAllMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTOP, null));
        }

        public void SuspendTorrentListView()
        {
            torrentListView.SuspendLayout();
        }

        public void ResumeTorrentListView()
        {
            torrentListView.ResumeLayout();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            if (notifyIcon.Visible = settings.minToTray)
            {
                foreach (string arg in Environment.GetCommandLineArgs())
                {
                    if (arg.Equals("/m", StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this.minimise = true;
                    }
                }
            }
            OpenGeoipDatabase();
            if (settings.autoConnect)
            {
                Connect();
            }
        }

        private void SelectAllFilesHandler(object sender, EventArgs e)
        {
            Toolbox.SelectAll(filesListView);
        }

        private void SelectAllTorrentsHandler(object sender, EventArgs e)
        {
            Toolbox.SelectAll(torrentListView);
        }

        private void SelectAllPeersHandler(object sender, EventArgs e)
        {
            Toolbox.SelectAll(peersListView);
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (Program.Connected)
            {
                CreateUploadWorker().RunWorkerAsync(e.Data.GetData(DataFormats.FileDrop));
            }
            else
            {
                ShowMustBeConnectedDialog();
            }
        }

        public void ShowMustBeConnectedDialog()
        {
            if (MessageBox.Show("You must be connected to add torrents. Would you like to connect now?", "Not connected", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Connect();
            }
        }

        public BackgroundWorker CreateUploadWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.UploadWorker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.UploadWorker_RunWorkerCompleted);
            return worker;
        }

        public BackgroundWorker CreateActionWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.ActionWorker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ActionWorker_RunWorkerCompleted);
            return worker;
        }

        private void ActionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request((JsonObject)e.Argument);
        }

        private void ActionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
            /* Everything seemed to go OK, so do an update if not already. */
            if (command.GetType() != typeof(ErrorCommand))
            {
                RefreshIfNotRefreshing();
            }
        }

        private void UploadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (string file in (string[])e.Argument)
                {
                    if (file == null)
                    {
                        continue;
                    }
                    if ((e.Result = CommandFactory.Request(Requests.TorrentAddByFile(file, false))).GetType() == typeof(ErrorCommand))
                    {
                        /* An exception occured, so display it. */
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = new ErrorCommand(ex, true);
            }
        }

        private void UploadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((TransmissionCommand)e.Result).Execute();
            RefreshIfNotRefreshing();
        }

        private JsonArray BuildIdArray()
        {
            JsonArray ids = new JsonArray();
            lock (torrentListView)
            {
                foreach (ListViewItem item in torrentListView.SelectedItems)
                {
                    Torrent t = (Torrent)item.Tag;
                    ids.Put(t.Id);
                }
            }
            return ids;
        }

        private void RemoveTorrentsPrompt()
        {
            if (torrentListView.SelectedItems.Count == 1
                && MessageBox.Show("Do you want to remove " + torrentListView.SelectedItems[0].Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveTorrents(false);
            }
            else if (torrentListView.SelectedItems.Count > 1
                && MessageBox.Show("You have selected " + torrentListView.SelectedItems.Count + " torrents for removal. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveTorrents(false);
            }
        }

        private void RemoveAndDeleteTorrentsPrompt()
        {
            if (Program.DaemonDescriptor.Revision >= 7331)
            {
                if (torrentListView.SelectedItems.Count == 1
                    && MessageBox.Show("Do you want to remove " + torrentListView.SelectedItems[0].Text + "?\r\n\r\nALL THE DATA FROM THIS TORRENT WILL BE REMOVED.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RemoveTorrents(true);
                }
                else if (torrentListView.SelectedItems.Count > 1
                    && MessageBox.Show("You have selected " + torrentListView.SelectedItems.Count + " torrents for removal. Are you sure?\r\n\r\nALL THE DATA FROM THESE TORRENTS WILL BE REMOVED.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RemoveTorrents(true);
                }
            }
        }

        private void RemoveTorrents(bool delete)
        {
            if (torrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.RemoveTorrent(BuildIdArray(), delete));
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.InvokeShow();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog.Instance.Show();
            AboutDialog.Instance.BringToFront();
        }

        private delegate void InvokeShowDelegate();
        public void InvokeShow()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InvokeShowDelegate(this.InvokeShow));
            }
            else
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                this.Activate();
            }
        }

        private void connectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request(Requests.SessionGet());
        }

        private void connectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker senderBW = (BackgroundWorker)sender;
            if (this.connectWorker != null && this.connectWorker.Equals(senderBW))
            {
                this.connectWorker = null;
                ((TransmissionCommand)e.Result).Execute();
            }
        }

        public void Connect()
        {
            toolStripStatusLabel.Text = "Connecting...";
            BackgroundWorker connectWorker = this.connectWorker = new BackgroundWorker();
            connectWorker.DoWork += new DoWorkEventHandler(connectWorker_DoWork);
            connectWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connectWorker_RunWorkerCompleted);
            connectWorker.RunWorkerAsync();
        }

        private void refreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request(Requests.TorrentGet());
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshIfNotRefreshing();
        }

        public void RefreshIfNotRefreshing()
        {
            if (!refreshWorker.IsBusy)
            {
                refreshWorker.RunWorkerAsync();
            }
        }

        private void localConfigureButton_Click(object sender, EventArgs e)
        {
            LocalSettingsDialog.Instance.Show();
            LocalSettingsDialog.Instance.BringToFront();
        }

        private void remoteConfigureButton_Click(object sender, EventArgs e)
        {
            RemoteSettingsDialog.Instance.Show();
            RemoteSettingsDialog.Instance.BringToFront();
        }

        private void torrentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (torrentListView)
            {
                int count = torrentListView.SelectedItems.Count;
                bool oneOrMore = count > 0;
                bool one = count == 1;
                torrentListView.ContextMenu = oneOrMore ? this.torrentSelectionMenu : this.noTorrentSelectionMenu;
                startTorrentButton.Enabled = pauseTorrentButton.Enabled
                    = removeTorrentButton.Enabled = recheckTorrentButton.Enabled
                    = removeAndDeleteButton.Enabled
                    = oneOrMore;
                lock (filesListView)
                {
                    filesListView.Items.Clear();
                }
                lock (fileItems)
                {
                    fileItems.Clear();
                }
                lock (peersListView)
                {
                    peersListView.Items.Clear();
                }
                lock (trackersListView)
                {
                    trackersListView.Items.Clear();
                }
                if (one)
                {
                    filesListView.Enabled = false;
                    peersListView.Tag = 0;
                    Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                    CreateActionWorker().RunWorkerAsync(Requests.FilesAndPriorities(t.Id));
                }
                UpdateInfoPanel(true);
                torrentAndTabsSplitContainer.Panel2Collapsed = !one;
                refreshElapsedTimer.Enabled = filesTimer.Enabled = one;
            }
        }

        private void ShowTorrentPropsHandler(object sender, EventArgs e)
        {
            lock (torrentListView)
            {
                foreach (ListViewItem item in torrentListView.SelectedItems)
                {
                    Torrent t = (Torrent)item.Tag;
                    TorrentPropertiesDialog dialog = new TorrentPropertiesDialog(t);
                    dialog.Show();
                }
            }
        }

        private void removeTorrentButton_Click(object sender, EventArgs e)
        {
            RemoveTorrentsPrompt();
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startTorrentButton_Click(object sender, EventArgs e)
        {
            if (torrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTART, BuildIdArray()));
            }
        }

        private void pauseTorrentButton_Click(object sender, EventArgs e)
        {
            if (torrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTOP, BuildIdArray()));
            }
        }

        public void UpdateGraph(int downspeed, int upspeed)
        {
            speedGraph.Push(downspeed, "Download");
            speedGraph.Push(upspeed, "Upload");
            speedGraph.UpdateGraph();
        }

        public void UpdateStatus(string text)
        {
            toolStripStatusLabel.Text = text;
            notifyIcon.Text = text.Length < 64 ? text : text.Substring(0, 63);
        }

        private void addTorrentButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "BitTorrent Metafile (*.torrent)|*.torrent|All Files (*.*)|*.*";
            openFile.RestoreDirectory = true;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                CreateUploadWorker().RunWorkerAsync(openFile.FileNames);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X && !Program.Connected)
            {
                Connect();
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                Program.Connected = false;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                LocalSettingsDialog.Instance.Show();
                LocalSettingsDialog.Instance.BringToFront();
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
                if (settings.proxyEnabled == 0 && settings.proxyHost.Length > 0)
                {
                    settings.proxyEnabled = 1;
                    toolStripStatusLabel.Text = "Proxy enabled.";
                }
                else if (settings.proxyEnabled <= 1)
                {
                    settings.proxyEnabled = 2;
                    toolStripStatusLabel.Text = "Proxy disabled.";
                }
                else
                {
                    settings.proxyEnabled = 0;
                    toolStripStatusLabel.Text = "Proxy dependent on IE settings.";
                }
                settings.Commit();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (this.minimise)
            {
                this.minimise = false;
                this.Hide();
            }
        }

        private void torrentListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                lvwColumnSorter.Order = (lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.torrentListView.Sort();
            Toolbox.StripeListView(torrentListView);
        }

        public void disconnectButton_Click(object sender, EventArgs e)
        {
            Program.Connected = false;
        }

        public void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void addWebTorrentButton_Click(object sender, EventArgs e)
        {
            UriPromptWindow uriPrompt = new UriPromptWindow();
            uriPrompt.Show();
        }

        private void stateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByStateOrTracker();
            torrentListView.Sort();
            Toolbox.StripeListView(torrentListView);
        }

        private void FilterByStateOrTracker()
        {
            ListBox box = stateListBox;
            torrentListView.SuspendLayout();
            lock (Program.TorrentIndex)
            {
                if (box.SelectedIndex == 1)
                {
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_DOWNLOADING);
                }
                else if (box.SelectedIndex == 2)
                {
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_STOPPED);
                }
                else if (box.SelectedIndex == 3)
                {
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_CHECKING | ProtocolConstants.STATUS_WAITING_TO_CHECK);
                }
                else if (box.SelectedIndex == 4)
                {
                    foreach (KeyValuePair<int, Torrent> pair in Program.TorrentIndex)
                    {
                        Torrent t = pair.Value;
                        if (t.Percentage >= 100 || t.StatusCode == ProtocolConstants.STATUS_SEEDING)
                        {
                            t.Show();
                        }
                        else
                        {
                            t.Remove();
                        }
                    }
                }
                else if (box.SelectedIndex == 5)
                {
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_SEEDING);
                }
                else if (box.SelectedIndex > 6)
                {
                    foreach (KeyValuePair<int, Torrent> pair in Program.TorrentIndex)
                    {
                        Torrent t = pair.Value;
                        if (t.Item.SubItems[13].Text.Equals(box.SelectedItem.ToString()))
                        {
                            t.Show();
                        }
                        else
                        {
                            t.Remove();
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, Torrent> pair in Program.TorrentIndex)
                    {
                        Torrent t = pair.Value;
                        t.Show();
                    }
                }
            }
            torrentListView.ResumeLayout();
        }

        private void ShowTorrentIfStatus(short statusCode)
        {
            foreach (KeyValuePair<int, Torrent> pair in Program.TorrentIndex)
            {
                Torrent t = pair.Value;
                if ((t.StatusCode & statusCode) > 0)
                {
                    t.Show();
                }
                else
                {
                    t.Remove();
                }
            }
        }

        private void filesTimer_Tick(object sender, EventArgs e)
        {
            if (!filesWorker.IsBusy)
            {
                filesTimer.Enabled = false;
                lock (torrentListView)
                {
                    if (torrentListView.SelectedItems.Count == 1)
                    {
                        Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                        filesWorker.RunWorkerAsync(t.Id);
                    }
                }
            }
        }

        private void filesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = (int)e.Argument;
            e.Result = CommandFactory.Request(Requests.Files(id));
        }

        private void filesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((TransmissionCommand)e.Result).Execute();
        }

        private void SetHighPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                filesListView.SuspendLayout();
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[5].Text = "High";
                }
                filesListView.ResumeLayout();
            }
            DispatchFilesUpdate();
        }

        private void SetLowPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                filesListView.SuspendLayout();
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[5].Text = "Low";
                }
                filesListView.ResumeLayout();
            }
            DispatchFilesUpdate();
        }

        private void SetNormalPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                filesListView.SuspendLayout();
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[5].Text = "Normal";
                }
                filesListView.ResumeLayout();
            }
            DispatchFilesUpdate();
        }

        private void SetUnwantedHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                filesListView.SuspendLayout();
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[4].Text = "Yes";
                }
                filesListView.ResumeLayout();
            }
            DispatchFilesUpdate();
        }

        private void SetWantedHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                filesListView.SuspendLayout();
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[4].Text = "No";
                }
                filesListView.ResumeLayout();
            }
            DispatchFilesUpdate();
        }

        private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            filesListView.ContextMenu = filesListView.SelectedItems.Count > 0 ? this.fileSelectionMenu : this.noFileSelectionMenu;
        }

        private void DispatchFilesUpdate()
        {
            JsonArray high = new JsonArray();
            JsonArray normal = new JsonArray();
            JsonArray low = new JsonArray();
            JsonArray wanted = new JsonArray();
            JsonArray unwanted = new JsonArray();
            Torrent t;
            lock (torrentListView)
            {
                if (torrentListView.SelectedItems.Count != 1)
                {
                    return;
                }
                t = (Torrent)torrentListView.SelectedItems[0].Tag;
            }
            lock (fileItems)
            {
                foreach (ListViewItem item in fileItems)
                {
                    if (item.SubItems[4].Text.Equals("Yes"))
                    {
                        unwanted.Add(item.Index);
                    }
                    else
                    {
                        wanted.Add(item.Index);
                    }
                    switch (item.SubItems[5].Text)
                    {
                        case "High":
                            high.Add(item.Index);
                            break;
                        case "Normal":
                            normal.Add(item.Index);
                            break;
                        case "Low":
                            low.Add(item.Index);
                            break;
                    }
                }
            }
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, "torrent-set");
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            ids.Put(t.Id);
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            if (high.Count > 0)
            {
                arguments.Put("priority-high", high);
            }
            else if (high.Count == fileItems.Count)
            {
                arguments.Put("priority-high", new JsonArray());
            }

            if (normal.Count > 0)
            {
                arguments.Put("priority-normal", normal);
            }
            else if (normal.Count == fileItems.Count)
            {
                arguments.Put("priority-normal", new JsonArray());
            }

            if (low.Count > 0)
            {
                arguments.Put("priority-low", low);
            }
            else if (low.Count == fileItems.Count)
            {
                arguments.Put("priority-low", new JsonArray());
            }

            if (wanted.Count > 0)
            {
                arguments.Put("files-wanted", wanted);
            }
            else if (wanted.Count == fileItems.Count)
            {
                arguments.Put("files-wanted", new JsonArray());
            }

            if (unwanted.Count > 0)
            {
                arguments.Put("files-unwanted", unwanted);
            }
            else if (unwanted.Count == fileItems.Count)
            {
                arguments.Put("files-unwanted", new JsonArray());
            }

            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            CreateActionWorker().RunWorkerAsync(request);
        }

        // lock torrentListView BEFORE calling this method
        public void UpdateInfoPanel(bool first)
        {
            if (torrentListView.SelectedItems.Count == 1)
            {
                Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                if (first)
                {
                    generalTorrentNameGroupBox.Text = peersTorrentNameGroupBox.Text
                        = trackersTorrentNameGroupBox.Text = filesTorrentNameGroupBox.Text
                        = t.Name;
                    startedAtLabel.Text = t.Added.ToString();
                    createdAtLabel.Text = t.Created;
                    createdByLabel.Text = t.Creator;
                    commentLabel.Text = t.Comment;
                    if (t.Peers != null && !torrentTabControl.TabPages.Contains(peersTabPageSaved))
                    {
                        torrentTabControl.TabPages.Add(peersTabPageSaved);
                    }
                    else if (t.Peers == null && torrentTabControl.TabPages.Contains(peersTabPageSaved))
                    {
                        torrentTabControl.TabPages.Remove(peersTabPageSaved);
                    }
                    trackersListView.SuspendLayout();
                    foreach (JsonObject tracker in t.Trackers)
                    {
                        int tier = ((JsonNumber)tracker["tier"]).ToInt32();
                        string announceUrl = (string)tracker["announce"];
                        string scrapeUrl = (string)tracker["scrape"];
                        ListViewItem item = new ListViewItem(tier.ToString());
                        item.SubItems.Add(announceUrl);
                        item.SubItems.Add(scrapeUrl);
                        trackersListView.Items.Add(item);
                    }
                    Toolbox.StripeListView(trackersListView);
                    trackersListView.ResumeLayout();
                }
                remainingLabel.Text = t.GetLongETA();
                uploadedLabel.Text = t.UploadedString;
                uploadLimitLabel.Text = t.UploadLimitMode ? Toolbox.KbpsString(t.UploadLimit) : "∞";
                uploadRateLabel.Text = t.UploadRate;
                seedersLabel.Text = String.Format("{0} of {1} connected", t.PeersSendingToUs, t.Seeders < 0 ? "?" : t.Seeders.ToString());
                leechersLabel.Text = String.Format("{0} of {1} connected", t.PeersGettingFromUs, t.Leechers < 0 ? "?" : t.Leechers.ToString());
                ratioLabel.Text = t.RatioString;
                progressBar.Value = (int)t.Percentage;
                percentageLabel.Text = t.Percentage.ToString() + "%";
                downloadedLabel.Text = t.HaveValidString;
                downloadSpeedLabel.Text = t.DownloadRate;
                downloadLimitLabel.Text = t.DownloadLimitMode ? Toolbox.KbpsString(t.DownloadLimit) : "∞";
                statusLabel.Text = t.Status;
                labelForErrorLabel.Visible = errorLabel.Visible = !(errorLabel.Text = t.ErrorString).Equals("");
                RefreshElapsedTimer();
                if (t.Peers != null)
                {
                    peersListView.Enabled = t.StatusCode != ProtocolConstants.STATUS_STOPPED;
                    peersListView.Tag = (int)peersListView.Tag + 1;
                    peersListView.SuspendLayout();
                    foreach (JsonObject peer in t.Peers)
                    {
                        ListViewItem item = FindPeerItem(peer["address"].ToString());
                        if (item == null)
                        {
                            item = new ListViewItem((string)peer["address"]); // 0
                            item.SubItems.Add(""); // 1
                            IPAddress ip = null;
                            try
                            {
                                ip = IPAddress.Parse(item.SubItems[0].Text);
                            }
                            catch { }
                            int countryIndex = -1;
                            if (geo != null)
                            {
                                if (ip == null)
                                {
                                    countryIndex = 0;
                                }
                                else
                                {
                                    countryIndex = geo.FindIndex(ip);
                                }
                                item.SubItems.Add(GeoIPCountry.CountryNames[countryIndex]);
                            }
                            else
                            {
                                item.SubItems.Add("");
                            }
                            item.SubItems.Add((string)peer[ProtocolConstants.FIELD_FLAGSTR]);
                            item.SubItems.Add((string)peer[ProtocolConstants.FIELD_CLIENTNAME]);
                            item.ToolTipText = item.SubItems[0].Text;
                            decimal progress = Toolbox.ParseProgress((string)peer[ProtocolConstants.FIELD_PROGRESS]);
                            item.SubItems.Add(progress + "%");
                            item.SubItems[5].Tag = progress;
                            long rateToClient = ((JsonNumber)peer[ProtocolConstants.FIELD_RATETOCLIENT]).ToInt64();
                            item.SubItems.Add(Toolbox.GetSpeed(rateToClient));
                            item.SubItems[6].Tag = rateToClient;
                            long rateToPeer = ((JsonNumber)peer[ProtocolConstants.FIELD_RATETOPEER]).ToInt64();
                            item.SubItems.Add(Toolbox.GetSpeed(rateToPeer));
                            item.SubItems[7].Tag = rateToPeer;
                            peersListView.Items.Add(item);
                            Toolbox.StripeListView(peersListView);
                            if (countryIndex >= 0)
                            {
                                item.ImageIndex = flagsImageList.Images.IndexOfKey("flags_" + GeoIPCountry.CountryCodes[countryIndex].ToLower());
                            }
                            CreateHostnameResolutionWorker().RunWorkerAsync(new object[] { item, ip });
                        }
                        else
                        {
                            decimal progress = Toolbox.ParseProgress((string)peer[ProtocolConstants.FIELD_PROGRESS]);
                            item.SubItems[3].Text = (string)peer[ProtocolConstants.FIELD_FLAGSTR];
                            item.SubItems[5].Text = progress + "%";
                            long rateToClient = ((JsonNumber)peer[ProtocolConstants.FIELD_RATETOCLIENT]).ToInt64();
                            item.SubItems[6].Text = Toolbox.GetSpeed(rateToClient);
                            item.SubItems[6].Tag = rateToClient;
                            long rateToPeer = ((JsonNumber)peer[ProtocolConstants.FIELD_RATETOPEER]).ToInt64();
                            item.SubItems[7].Text = Toolbox.GetSpeed(rateToPeer);
                            item.SubItems[7].Tag = rateToPeer;
                        }
                        item.Tag = peersListView.Tag;
                    }
                    Queue<ListViewItem> removalQueue = new Queue<ListViewItem>();
                    lock (peersListView)
                    {
                        foreach (ListViewItem item in peersListView.Items)
                        {
                            if ((int)item.Tag != (int)peersListView.Tag)
                            {
                                removalQueue.Enqueue(item);
                            }
                        }
                        foreach (ListViewItem item in removalQueue)
                        {
                            peersListView.Items.Remove(item);
                        }
                    }
                    peersListView.Sort();
                    Toolbox.StripeListView(peersListView);
                    peersListView.ResumeLayout();
                }
            }
        }

        private BackgroundWorker CreateHostnameResolutionWorker()
        {
            BackgroundWorker resolveHostWorker = new BackgroundWorker();
            resolveHostWorker.DoWork += new DoWorkEventHandler(resolveHostWorker_DoWork);
            resolveHostWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(resolveHostWorker_RunWorkerCompleted);
            return resolveHostWorker;
        }

        private void resolveHostWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((TransmissionCommand)e.Result).Execute();
        }

        private void resolveHostWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            e.Result = new ResolveHostCommand((ListViewItem)args[0], (IPAddress)args[1]);
        }

        private ListViewItem FindPeerItem(string address)
        {
            lock (peersListView)
            {
                foreach (ListViewItem peer in peersListView.Items)
                {
                    if (peer.SubItems[0].Text.Equals(address))
                    {
                        return peer;
                    }
                }
            }
            return null;
        }

        private void refreshElapsedTimer_Tick(object sender, EventArgs e)
        {
            RefreshElapsedTimer();
        }

        private void RefreshElapsedTimer()
        {
            lock (torrentListView)
            {
                if (torrentListView.SelectedItems.Count == 1)
                {
                    Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                    TimeSpan ts = DateTime.Now.Subtract(t.Added);
                    timeElapsedLabel.Text = ts.Ticks > 0 ? Toolbox.FormatTimespanLong(ts) : "Unknown (negative result)";
                }
                else
                {
                    refreshElapsedTimer.Enabled = false;
                }
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (notifyIcon.Visible && FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void projectSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AboutDialog.PROJECT_SITE);
        }

        private void showErrorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorLogWindow.Instance.Show();
            ErrorLogWindow.Instance.BringToFront();
        }

        private void filesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == filesLvwColumnSorter.SortColumn)
            {
                filesLvwColumnSorter.Order = (filesLvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            }
            else
            {
                filesLvwColumnSorter.SortColumn = e.Column;
                filesLvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.filesListView.Sort();
            Toolbox.StripeListView(filesListView);
        }

        private void peersListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == peersLvwColumnSorter.SortColumn)
            {
                peersLvwColumnSorter.Order = (peersLvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            }
            else
            {
                peersLvwColumnSorter.SortColumn = e.Column;
                peersLvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.peersListView.Sort();
            Toolbox.StripeListView(peersListView);
        }

        private void SpeedResComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (speedResComboBox.SelectedIndex)
            {
                case 3:
                    speedGraph.LineInterval = 0.5F;
                    break;
                case 2:
                    speedGraph.LineInterval = 5;
                    break;
                case 1:
                    speedGraph.LineInterval = 15;
                    break;
                default:
                    speedGraph.LineInterval = 30;
                    break;
            }
            speedGraph.UpdateGraph();
        }

        private void torrentListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                RemoveAndDeleteTorrentsPrompt();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                RemoveTorrentsPrompt();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                Toolbox.SelectAll(torrentListView);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Toolbox.CopyListViewToClipboard(torrentListView);
            }
        }

        private void torrentDetailsTabListView_KeyDown(object sender, KeyEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (e.KeyCode == Keys.A && e.Control)
            {
                Toolbox.SelectAll(listView);
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                Toolbox.CopyListViewToClipboard(listView);
            }
        }

        private void refreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((TransmissionCommand)e.Result).Execute();
        }

        private void recheckTorrentButton_Click(object sender, EventArgs e)
        {
            if (torrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTVERIFY, BuildIdArray()));
            }
        }

        private void removeAndDeleteButton_Click(object sender, EventArgs e)
        {
            RemoveAndDeleteTorrentsPrompt();
        }

        private void sessionStatsButton_Click(object sender, EventArgs e)
        {
            StatsDialog.Instance.Show();
            StatsDialog.Instance.BringToFront();
        }
    }
}
