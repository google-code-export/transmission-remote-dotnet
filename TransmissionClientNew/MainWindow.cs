using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Commmands;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    public partial class MainWindow : Form
    {
        public static readonly string DEFAULT_WINDOW_TITLE = "Transmission Remote";

        public Boolean minimise = false;
        private ListViewItemSorter lvwColumnSorter;
        private ContextMenu torrentSelectionMenu;
        private ContextMenu fileSelectionMenu;
        private ContextMenu noFileSelectionMenu;

        public MainWindow()
        {
            Program.connStatusChanged += new ConnStatusChangedDelegate(Program_connStatusChanged);
            InitializeComponent();
            torrentAndTabsSplitContainer.Panel2Collapsed = true;
        }

        private void Program_connStatusChanged(Boolean connected)
        {
            ContextMenu trayMenu = new ContextMenu();
            if (connected)
            {
                trayMenu.MenuItems.Add("Start all", new EventHandler(this.startAllMenuItem_Click));
                trayMenu.MenuItems.Add("Stop all", new EventHandler(this.stopAllMenuItem_Click));
                trayMenu.MenuItems.Add("-");
                trayMenu.MenuItems.Add("Disconnect", new EventHandler(this.disconnectButton_Click));
                this.toolStripStatusLabel.Text = "Connected. Getting torrent information...";
                this.Text = MainWindow.DEFAULT_WINDOW_TITLE + " - " + LocalSettingsSingleton.Instance.host;
                this.notifyIcon.Text = "[CONNECTED] " + MainWindow.DEFAULT_WINDOW_TITLE;
            }
            else
            {
                lock (this.filesListView)
                {
                    this.filesListView.Items.Clear();
                }
                lock (this.torrentListView)
                {
                    this.torrentListView.Items.Clear();
                }
                trayMenu.MenuItems.Add("Connect", new EventHandler(this.connectButton_Click));
                this.toolStripStatusLabel.Text = "Disconnected.";
                this.notifyIcon.Text = "[DISCONNECTED] " + MainWindow.DEFAULT_WINDOW_TITLE;
                this.Text = MainWindow.DEFAULT_WINDOW_TITLE;
                this.refreshTimer.Enabled = false;
                this.torrentAndTabsSplitContainer.Panel2Collapsed = true;
            }
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", new EventHandler(this.exitToolStripMenuItem_Click));
            this.notifyIcon.ContextMenu = trayMenu;
            connectButton.Visible = mainVerticalSplitContainer.Panel1Collapsed = !connected;
            disconnectButton.Visible = torrentListView.Enabled
                = addTorrentButton.Visible = addWebTorrentButton.Visible
                = startTorrentButton.Visible = remoteConfigureButton.Visible
                = pauseTorrentButton.Visible = removeTorrentButton.Visible
                = toolStripSeparator4.Visible = toolStripSeparator1.Visible
                = toolStripSeparator2.Visible = torrentTabControl.Enabled
                = remoteSettingsToolStripMenuItem.Visible
                = connected;
        }

        public void startAllMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTART, null));
        }

        public void stopAllMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTOP, null));
        }

        private delegate void SuspendTorrentListViewDelegate();
        public void SuspendTorrentListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SuspendTorrentListViewDelegate(this.SuspendTorrentListView));
            }
            else
            {
                torrentListView.SuspendLayout();
            }
        }

        private delegate void ResumeTorrentListViewDelegate();
        public void ResumeTorrentListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ResumeTorrentListViewDelegate(this.ResumeTorrentListView));
            }
            else
            {
                torrentListView.ResumeLayout();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            refreshTimer.Interval = settings.refreshRate * 1000;
            filesTimer.Interval = settings.refreshRate * 1000 * 3;
            torrentListView.ListViewItemSorter = lvwColumnSorter = new ListViewItemSorter();
            if (settings.autoConnect)
            {
                Connect();
            }
            this.torrentSelectionMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Start", new EventHandler(this.startTorrentButton_Click)),
                new MenuItem("Pause", new EventHandler(this.pauseTorrentButton_Click)),
                new MenuItem("Remove", new EventHandler(this.removeTorrentButton_Click)),
                new MenuItem("-"),
                new MenuItem("Properties", new EventHandler(this.ShowTorrentPropsHandler))
            });
            this.fileSelectionMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("High Priority", new EventHandler(this.SetHighPriorityHandler)),
                new MenuItem("Normal Priority", new EventHandler(this.SetNormalPriorityHandler)),
                new MenuItem("Low Priority", new EventHandler(this.SetLowPriorityHandler)),
                new MenuItem("-"),
                new MenuItem("Download", new EventHandler(this.SetWantedHandler)),
                new MenuItem("Skip", new EventHandler(this.SetUnwantedHandler)),
                new MenuItem("-"),
                new MenuItem("Select All", new EventHandler(this.SelectAllFilesHandler))
            });
            this.noFileSelectionMenu = this.filesListView.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Select All", new EventHandler(this.SelectAllFilesHandler))
            });
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

        }

        private void SelectAllFilesHandler(object sender, EventArgs e)
        {
            Toolbox.SelectAll(filesListView);
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

        public BackgroundWorker CreateUriUploadWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.UploadWorker_DoWorkUri);
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
            if (command.GetType() != typeof(ErrorCommand) && !refreshWorker.IsBusy)
            {
                refreshWorker.RunWorkerAsync(false);
            }
        }

        private void UploadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string file in (string[])e.Argument)
            {
                if ((e.Result = CommandFactory.UploadFile(file)) != null)
                {
                    /* An exception occured, so display it. */
                    return;
                }
            }
            e.Result = new NoCommand();
        }

        private void UploadWorker_DoWorkUri(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.UploadFile((Uri)e.Argument);
            if (e.Result == null)
            {
                e.Result = new NoCommand();
            }
        }

        private void UploadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private JsonArray BuildIdArray()
        {
            JsonArray ids = new JsonArray();
            foreach (ListViewItem item in torrentListView.SelectedItems)
            {
                Torrent t = (Torrent)item.Tag;
                ids.Put(t.Id);
            }
            return ids;
        }

        private JsonArray BuildFirstIdArray()
        {
            JsonArray ids = new JsonArray();
            Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
            ids.Put(t.Id);
            return ids;
        }

        private void RemoveTorrentsPrompt()
        {
            if (torrentListView.SelectedItems.Count == 1
                && MessageBox.Show("Do you want to remove " + torrentListView.SelectedItems[0].Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveTorrents();
            }
            else if (torrentListView.SelectedItems.Count > 1
                && MessageBox.Show("You have selected " + torrentListView.SelectedItems.Count + " torrents for removal. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveTorrents();
            }
        }

        private void RemoveTorrents()
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic("torrent-remove", BuildIdArray()));
            StripeListView();
        }

        public void StripeListView()
        {
            Toolbox.StripeListView(torrentListView);
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
            AboutDialog dialog = new AboutDialog();
            dialog.Show();
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
            this.connectButton.Enabled = true;
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private delegate void ConnectDelegate();
        public void Connect()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ConnectDelegate(this.Connect));
            }
            else
            {
                connectButton.Enabled = false;
                toolStripStatusLabel.Text = "Connecting...";
                BackgroundWorker connectWorker = new BackgroundWorker();
                connectWorker.DoWork += new DoWorkEventHandler(connectWorker_DoWork);
                connectWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connectWorker_RunWorkerCompleted);
                connectWorker.RunWorkerAsync();
            }
        }

        private void refreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TransmissionCommand command = CommandFactory.Request(Requests.TorrentGet((Boolean)e.Argument));
            command.Execute();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (!refreshWorker.IsBusy)
            {
                refreshWorker.RunWorkerAsync(false);
            }
        }

        private void localConfigureButton_Click(object sender, EventArgs e)
        {
            LocalSettingsDialog dialog = new LocalSettingsDialog();
            dialog.Show();
        }

        private void remoteConfigureButton_Click(object sender, EventArgs e)
        {
            RemoteSettingsDialog dialog = new RemoteSettingsDialog();
            dialog.Show();
        }

        private void torrentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = torrentListView.SelectedItems.Count;
            bool oneOrMore = count > 0;
            bool one = count == 1;
            torrentListView.ContextMenu = oneOrMore ? this.torrentSelectionMenu : null;
            startTorrentButton.Enabled = pauseTorrentButton.Enabled
                = removeTorrentButton.Enabled = oneOrMore;
            filesTimer.Enabled = false;
            MainWindow form = Program.form;
            lock (form.filesListView)
            {
                form.filesListView.Items.Clear();
            }
            lock (form.peersListView)
            {
                form.peersListView.Items.Clear();
            }
            lock (form.trackersListView)
            {
                trackersListView.Items.Clear();
            }
            if (one)
            {
                peersListView.Tag = 0;
                Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                CreateActionWorker().RunWorkerAsync(Requests.FilesAndPriorities(t.Id));
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
            torrentAndTabsSplitContainer.Panel2Collapsed = !one;
            refreshElapsedTimer.Enabled = one;
            UpdateInfoPanel(true);
        }

        private void ShowTorrentPropsHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in torrentListView.SelectedItems)
            {
                Torrent t = (Torrent)item.Tag;
                TorrentPropertiesDialog dialog = new TorrentPropertiesDialog(t);
                dialog.Show();
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

        private delegate void UpdateStatusDelegate(string text);
        public void UpdateStatus(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), text);
            }
            else
            {
                toolStripStatusLabel.Text = text;
                notifyIcon.Text = text.Length < 64 ? text : text.Substring(0, 63);
            }
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
            if (e.KeyCode == Keys.Delete)
            {
                RemoveTorrentsPrompt();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                torrentListView.Focus();
                Toolbox.SelectAll(torrentListView);
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
                if (settings.proxyEnabled == 0)
                {
                    settings.proxyEnabled = 1;
                    settings.Commit();
                    toolStripStatusLabel.Text = "Proxy enabled.";
                }
                else if (settings.proxyEnabled == 1)
                {
                    settings.proxyEnabled = 2;
                    settings.Commit();
                    toolStripStatusLabel.Text = "Proxy disabled.";
                }
                else
                {
                    settings.proxyEnabled = 0;
                    settings.Commit();
                    toolStripStatusLabel.Text = "Proxy dependent on IE settings.";
                }
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Connect();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                Program.Connected = false;
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
            this.StripeListView();
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
            UriPromptWindow uriPrompt = new UriPromptWindow(new UriDelegate(this.addWebTorrent_UriChosen));
            uriPrompt.Show();
        }

        private void addWebTorrent_UriChosen(Uri uri)
        {
            CreateUriUploadWorker().RunWorkerAsync(uri);
        }

        private void stateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            torrentListView.SuspendLayout();
            switch (box.SelectedIndex)
            {
                case 1: // downloading
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_DOWNLOADING);
                    break;
                case 2: // paused
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_STOPPED);
                    break;
                case 3: // completed
                    foreach (KeyValuePair<int, Torrent> pair in Program.torrentIndex)
                    {
                        Torrent t = pair.Value;
                        if (t.Percentage >= 100)
                        {
                            t.Show();
                        }
                        else
                        {
                            t.Remove();
                        }
                    }
                    break;
                case 4: // seeding
                    ShowTorrentIfStatus(ProtocolConstants.STATUS_SEEDING);
                    break;
                default: // all
                    foreach (KeyValuePair<int, Torrent> pair in Program.torrentIndex)
                    {
                        Torrent t = pair.Value;
                        t.Show();
                    }
                    break;
            }
            Toolbox.StripeListView(this.torrentListView);
            torrentListView.ResumeLayout();
        }

        private void ShowTorrentIfStatus(short statusCode)
        {
            foreach (KeyValuePair<int, Torrent> pair in Program.torrentIndex)
            {
                Torrent t = pair.Value;
                if (t.StatusCode == statusCode)
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
                try
                {
                    filesWorker.RunWorkerAsync(Requests.Files(BuildFirstIdArray()));
                }
                catch { }
            }
        }

        private void filesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request((JsonObject)e.Argument);
        }

        private void filesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private void SetHighPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[4].Text = "High";
                }
            }
            DispatchFilesUpdate();
        }

        private void SetLowPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[4].Text = "Low";
                }
            }
            DispatchFilesUpdate();
        }

        private void SetNormalPriorityHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.SubItems[4].Text = "Normal";
                }
            }
            DispatchFilesUpdate();
        }

        private void SetUnwantedHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.Checked = false;
                }
            }
            DispatchFilesUpdate();
        }

        private void SetWantedHandler(object sender, EventArgs e)
        {
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.SelectedItems)
                {
                    item.Checked = true;
                }
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
            lock (filesListView)
            {
                foreach (ListViewItem item in filesListView.Items)
                {
                    if (item.Checked)
                    {
                        wanted.Add(item.Index);
                    }
                    else
                    {
                        unwanted.Add(item.Index);
                    }
                    switch (item.SubItems[4].Text)
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
            Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
            ids.Put(t.Id);
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            if (high.Count > 0)
            {
                arguments.Put("priority-high", high);
            }
            if (normal.Count > 0)
            {
                arguments.Put("priority-normal", normal);
            }
            if (low.Count > 0)
            {
                arguments.Put("priority-low", low);
            }
            if (wanted.Count > 0)
            {
                arguments.Put("files-wanted", wanted);
            }
            if (wanted.Count > 0)
            {
                arguments.Put("files-unwanted", unwanted);
            }
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            CreateActionWorker().RunWorkerAsync(request);
        }

        private delegate void UpdateInfoPanelDelegate(bool first);
        public void UpdateInfoPanel(bool first)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoPanelDelegate(this.UpdateInfoPanel), first);
            }
            else
            {
                if (torrentListView.SelectedItems.Count == 1)
                {
                    Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                    if (first)
                    {
                        torrentDetailGroupBox.Text = t.Name;
                        startedAtLabel.Text = t.Added.ToString();
                        createdAtLabel.Text = t.Created;
                        createdByLabel.Text = t.Creator;
                        commentLabel.Text = t.Comment;
                    }
                    remainingLabel.Text = t.GetLongETA();
                    uploadedLabel.Text = t.UploadedString;
                    uploadLimitLabel.Text = t.UploadLimitMode ? Toolbox.KbpsString(t.UploadLimit) : "∞";
                    uploadRateLabel.Text = t.UploadRate;
                    seedersLabel.Text = String.Format("{0} of {0} connected", t.PeersSendingToUs, t.Seeders);
                    leechersLabel.Text = String.Format("{0} of {0} connected", t.PeersGettingFromUs, t.Leechers);
                    ratioLabel.Text = t.RatioString;
                    progressBar.Value = (int)t.Percentage;
                    percentageLabel.Text = t.Percentage.ToString() + "%";
                    downloadedLabel.Text = t.HaveValidString;
                    downloadSpeedLabel.Text = t.DownloadRate;
                    downloadLimitLabel.Text = t.DownloadLimitMode ? Toolbox.KbpsString(t.DownloadLimit) : "∞";
                    statusLabel.Text = t.Status;
                    if (!(errorLabel.Text = t.ErrorString).Equals(""))
                    {
                        labelForErrorLabel.Visible = errorLabel.Visible;
                    }
                    RefreshElapsedTimer();
                    peersListView.Tag = (int)peersListView.Tag + 1;
                    peersListView.SuspendLayout();
                    foreach (JsonObject peer in t.Peers)
                    {
                        ListViewItem item = FindPeerItem(peer["address"].ToString(), peer["clientName"].ToString());
                        if (item == null)
                        {
                            item = new ListViewItem((string)peer["address"]);
                            item.SubItems.Add((string)peer["clientName"]);
                            item.SubItems.Add((string)peer["progress"] + "%");
                            item.SubItems.Add(Toolbox.GetFileSize(((JsonNumber)peer["rateToClient"]).ToInt64()));
                            item.SubItems.Add(Toolbox.GetFileSize(((JsonNumber)peer["rateToPeer"]).ToInt64()));
                            peersListView.Items.Add(item);
                            Toolbox.StripeListView(peersListView);
                        }
                        else
                        {
                            item.SubItems[2].Text = (string)peer["progress"] + "%";
                            item.SubItems[3].Text = Toolbox.GetFileSize(((JsonNumber)peer["rateToClient"]).ToInt64());
                            item.SubItems[4].Text = Toolbox.GetFileSize(((JsonNumber)peer["rateToPeer"]).ToInt64());
                        } 
                        item.Tag = peersListView.Tag;
                    }
                    Queue<ListViewItem> removalQueue = new Queue<ListViewItem>();
                    foreach (ListViewItem item in peersListView.Items)
                    {
                        if ((int)item.Tag != (int)peersListView.Tag)
                        {
                            removalQueue.Enqueue(item);
                        }
                    }
                    foreach(ListViewItem item in removalQueue)
                    {
                        peersListView.Items.Remove(item);
                    }
                    peersListView.ResumeLayout();
                }
            }
        }

        private ListViewItem FindPeerItem(string address, string clientName)
        {
            foreach (ListViewItem peer in peersListView.Items)
            {
                if (peer.SubItems[0].Text.Equals(address) && peer.SubItems[1].Text.Equals(clientName))
                {
                    return peer;
                }
            }
            return null;
        }

        private void filesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void refreshElapsedTimer_Tick(object sender, EventArgs e)
        {
            RefreshElapsedTimer();
        }

        private void RefreshElapsedTimer()
        {
            if (torrentListView.SelectedItems.Count == 1)
            {
                Torrent t = (Torrent)torrentListView.SelectedItems[0].Tag;
                timeElapsedLabel.Text = Toolbox.FormatTimespanLong(DateTime.Now.Subtract(t.Added));
            }
            else
            {
                refreshElapsedTimer.Enabled = false;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (notifyIcon.Visible && FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }
    }
}
