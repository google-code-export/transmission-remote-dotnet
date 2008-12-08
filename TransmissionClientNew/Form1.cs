using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;
using TransmissionClientNew.Commmands;

namespace TransmissionClientNew
{
    public partial class Form1 : Form
    {
        public Boolean minimise = false;
        private ListViewItemSorter lvwColumnSorter;
        private ContextMenu noSelectionMenu;
        private ContextMenu yesSelectionMenu;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void LocalSettingsMenuItem_Click(object sender, EventArgs e)
        {
            LocalSettingsDialog dialog = new LocalSettingsDialog();
            dialog.Show();
        }

        public void ConnectButton_Click(object sender, EventArgs e)
        {
            Connect();
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
                ConnectButton.Enabled = false;
                toolStripStatusLabel1.Text = "Connecting...";
                BackgroundWorker connectWorker = new BackgroundWorker();
                connectWorker.DoWork += new DoWorkEventHandler(ConnectWorker_DoWork);
                connectWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ConnectWorker_RunWorkerCompleted);
                connectWorker.RunWorkerAsync();
            }
        }

        private void RefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TransmissionCommand command = CommandFactory.Request(Requests.TorrentGet((Boolean)e.Argument));
            command.Execute();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (!RefreshWorker.IsBusy)
            {
                RefreshWorker.RunWorkerAsync(false);
            }
        }

        public void DisconnectButton_Click(object sender, EventArgs e)
        {
            Program.Connected = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean enable = TorrentListView.SelectedItems.Count > 0;
            StartButton.Enabled = enable;
            StopButton.Enabled = enable;
            RemoveButton.Enabled = enable;
            DetailsButton.Enabled = enable;
            TorrentListView.ContextMenu = enable ? this.yesSelectionMenu : this.noSelectionMenu;
        }

        private void ActionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request((JsonObject)e.Argument);
        }

        private JsonArray BuildIdArray()
        {
            JsonArray ids = new JsonArray();
            foreach(ListViewItem item in TorrentListView.SelectedItems)
            {
                Torrent t = (Torrent)item.Tag;
                ids.Put(t.Id);
            }
            return ids;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveTorrentsPrompt();
        }

        private void RemoveTorrentsPrompt()
        {
            if (TorrentListView.SelectedItems.Count == 1
                && MessageBox.Show("Do you want to remove " + TorrentListView.SelectedItems[0].Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    RemoveTorrents();
            }
            else if (TorrentListView.SelectedItems.Count > 1
                && MessageBox.Show("You have selected " + TorrentListView.SelectedItems.Count + " torrents for removal. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveTorrents();
            }
        }

        private void RemoveTorrents()
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic("torrent-remove", BuildIdArray()));
            StripeListView();
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            foreach (ListViewItem item in TorrentListView.SelectedItems)
            {
                Torrent t = (Torrent)item.Tag;
                if (Program.infoDialogs.ContainsKey(t.Id))
                {
                    Program.infoDialogs[t.Id].Activate();
                }
                else
                {
                    TorrentInfoDialog dialog = new TorrentInfoDialog(t);
                    dialog.Show();
                }
            }
        }

        public void ExitApplicationHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            RefreshTimer.Interval = settings.refreshRate * 1000;
            FilesTimer.Interval = settings.refreshRate * 1000 * 2;
            lvwColumnSorter = new ListViewItemSorter();
            TorrentListView.ListViewItemSorter = lvwColumnSorter;
            if (settings.autoConnect)
            {
                Connect();
            }
            this.yesSelectionMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Start", new EventHandler(this.StartButton_ButtonClick)),
                new MenuItem("Stop", new EventHandler(this.StopButton_ButtonClick)),
                new MenuItem("Remove", new EventHandler(this.RemoveButton_Click)),
                new MenuItem("Show details", new EventHandler(this.DetailsButton_Click))
            });
            TorrentListView.ContextMenu = this.noSelectionMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Select All", new EventHandler(this.SelectAll)),
                new MenuItem("-"),
                new MenuItem("Exit", new EventHandler(this.ExitApplicationHandler))
            });
            if (NotifyIcon.Visible = settings.minToTray)
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

        private delegate void UpdateStatusDelegate(string text);
        public void UpdateStatus(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), text);
            }
            else
            {
                toolStripStatusLabel1.Text = text;
                NotifyIcon.Text = text.Length < 64 ? text : text.Substring(0, 63);
            }
        }

        public void Connected(Boolean b)
        {
            this.ConnectButton.Visible = !b;
            this.DisconnectButton.Visible = b;
            this.TorrentListView.Enabled = b;
            this.UploadButton.Visible = b;
            this.StartButton.Visible = b;
            this.RemoteSettingsMenuItem.Visible = b;
            this.StopButton.Visible = b;
            this.DetailsButton.Visible = b;
            this.RemoveButton.Visible = b;
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

        private void ActionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
            /* Everything seemed to go OK, so do an update if not already. */
            if (command.GetType() != typeof(ErrorCommand) && !RefreshWorker.IsBusy)
            {
                RefreshWorker.RunWorkerAsync(false);
            }
        }

        private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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

        private void UploadButton_Click(object sender, EventArgs e)
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

        private void UploadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private void RemoteSettingsMenuItem_Click(object sender, EventArgs e)
        {
            RemoteSettingsDialog dialog = new RemoteSettingsDialog();
            dialog.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Program.form.NotifyIcon.Visible && FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void StopButton_ButtonClick(object sender, EventArgs e)
        {
            if (TorrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTOP, BuildIdArray()));
            }
        }

        private void StartButton_ButtonClick(object sender, EventArgs e)
        {
            if (TorrentListView.SelectedItems.Count > 0)
            {
                CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTART, BuildIdArray()));
            }
        }

        public void startAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTART, null));
        }

        public void stopAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateActionWorker().RunWorkerAsync(Requests.Generic(ProtocolConstants.METHOD_TORRENTSTOP, null));
        }
         
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.TorrentListView.Sort();
            this.StripeListView();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveTorrentsPrompt();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ShowDetails();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                TorrentListView.Focus();
                Toolbox.SelectAll(TorrentListView);
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
                if (settings.proxyEnabled == 0)
                {
                    settings.proxyEnabled = 1;
                    settings.Commit();
                    toolStripStatusLabel1.Text = "Proxy enabled.";
                }
                else if (settings.proxyEnabled == 1)
                {
                    settings.proxyEnabled = 2;
                    settings.Commit();
                    toolStripStatusLabel1.Text = "Proxy disabled.";
                }
                else
                {
                    settings.proxyEnabled = 0;
                    settings.Commit();
                    toolStripStatusLabel1.Text = "Proxy dependent on IE settings.";
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (this.minimise)
            {
                this.minimise = false;
                this.Hide();
            }
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

        public void ShowHandler(object sender, EventArgs e)
        {
            this.InvokeShow();
        }

        public void StripeListView()
        {
            Toolbox.StripeListView(TorrentListView);
        }

        private void FilesTimer_Tick(object sender, EventArgs e)
        {
            if (!FilesWorker.IsBusy)
            {
                FilesTimer.Enabled = false;
                foreach (KeyValuePair<int, TorrentInfoDialog> pair in Program.infoDialogs)
                {
                    pair.Value.StatusStripLabel.Text = "Updating files information...";
                }
                FilesWorker.RunWorkerAsync();
            }
        }

        private void FilesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            JsonArray ids = new JsonArray();
            foreach (KeyValuePair<int, TorrentInfoDialog> pair in Program.infoDialogs)
            {
                ids.Put(pair.Key);
            }
            e.Result = CommandFactory.Request(Requests.Files(ids));
        }

        private void FilesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private void ConnectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request(Requests.SessionGet());
        }

        private void ConnectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ConnectButton.Enabled = true;
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.InvokeShow();
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            Toolbox.SelectAll(TorrentListView);
        }

        private delegate void SuspendListViewDelegate();
        public void SuspendListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SuspendListViewDelegate(this.SuspendListView));
            }
            else
            {
                TorrentListView.SuspendLayout();
            }
        }

        private delegate void ResumeListViewDelegate();
        public void ResumeListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ResumeListViewDelegate(this.ResumeListView));
            }
            else
            {
                TorrentListView.ResumeLayout();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.Show();
        }
    }
}
