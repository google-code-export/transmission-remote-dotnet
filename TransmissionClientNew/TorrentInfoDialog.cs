using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionClientNew
{
    public partial class TorrentInfoDialog : Form
    {
        public Torrent t;
        public JsonArray priorities;
        public ContextMenu noSelectionMenu;
        public ContextMenu yesSelectionMenu;

        public string FormatPriority(JsonNumber n)
        {
            short s = n.ToInt16();
            if (s < 0)
            {
                return "Low";
            }
            else if (s > 0)
            {
                return "High";
            }
            else
            {
                return "Normal";
            }
        }

        public TorrentInfoDialog(Torrent t)
        {
            this.t = t;
            InitializeComponent();
        }

        private JsonArray GetId()
        {
            JsonArray id = new JsonArray();
            id.Put(t.Id);
            return id;
        }

        private void TorrentInfoDialog_Load(object sender, EventArgs e)
        {
            Program.infoDialogs.Add(t.Id, this);
            Program.form.FilesTimer.Enabled = true;
            Program.form.CreateActionWorker().RunWorkerAsync(Requests.Priorities(t.Id));
            this.yesSelectionMenu = new ContextMenu();
            this.yesSelectionMenu.MenuItems.Add("High Priority", new EventHandler(this.SetHighPriorityHandler));
            this.yesSelectionMenu.MenuItems.Add("Normal Priority", new EventHandler(this.SetNormalPriorityHandler));
            this.yesSelectionMenu.MenuItems.Add("Low Priority", new EventHandler(this.SetLowPriorityHandler));
            this.yesSelectionMenu.MenuItems.Add("-");
            this.yesSelectionMenu.MenuItems.Add("Download", new EventHandler(this.SetWantedHandler));
            this.yesSelectionMenu.MenuItems.Add("Skip", new EventHandler(this.SetUnwantedHandler));
            this.yesSelectionMenu.MenuItems.Add("-");
            this.yesSelectionMenu.MenuItems.Add("Select All", new EventHandler(this.SelectAll));
            FilesListView.ContextMenu = this.noSelectionMenu = new ContextMenu(new MenuItem[] { new MenuItem("Select All", new EventHandler(this.SelectAll)) });
            this.UpdateInfo();
        }

        private delegate void UpdateInfoDelegate();
        public void UpdateInfo()
        {
            Form1 form = Program.form;
            if (form.InvokeRequired)
            {
                form.Invoke(new UpdateInfoDelegate(this.UpdateInfo));
            }
            else
            {
                JsonObject info = t.info;
                this.Text = this.NameLabel.Text = t.Name;
                DownloadedLabel.Text = t.HaveValidString;
                UploadedLabel.Text = t.UploadedString;
                CommentLabel.Text = t.Comment;
                SizeLabel.Text = t.TotalSizeString;
                double percentage = t.Percentage;
                PercentLabel.Text = percentage.ToString() + "%";
                DownloadSpeedLabel.Text = percentage >= 100 ? "N/A" : t.DownloadRate;
                UploadSpeedLabel.Text = t.UploadRate;
                ETALabel.Text = t.ETA;
                SwarmSpeed.Text = t.SwarmSpeed;
                SeedersLabel.Text = t.Seeders + ", " + t.PeersSendingToUs + " to us";
                LeechersLabel.Text = t.Leechers + ", " + t.PeersGettingFromUs + " from us";
                AddedLabel.Text = t.Added;
                CreatedLabel.Text = t.Created;
                CreatedByLabel.Text = (string)info["creator"];
                ErrorLabelLabel.Visible = ErrorLabel.Visible = (string)info["errorString"] != "";
                ErrorLabel.Text = (string)info["errorString"];
                StopStartButton.Text = (t.StatusCode == 16 ? "Start" : "Stop");
                StatusLabel.Text = t.Status;
                AnnounceURLLabel.Text = (string)info[ProtocolConstants.FIELD_ANNOUNCEURL];
            }
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TorrentInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.infoDialogs.ContainsKey(t.Id))
            {
                Program.infoDialogs.Remove(t.Id);
            }
            if (Program.infoDialogs.Count <= 0)
            {
                Program.form.FilesTimer.Enabled = false;
            }
        }

        private void StopStartButton_Click(object sender, EventArgs e)
        {
            Program.form.CreateActionWorker().RunWorkerAsync(Requests.Generic(((JsonNumber)t.info[ProtocolConstants.FIELD_STATUS]).ToInt16() == ProtocolConstants.STATUS_STOPPED ? ProtocolConstants.METHOD_TORRENTSTART : ProtocolConstants.METHOD_TORRENTSTOP, GetId()));
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove '" + this.Text + "'?", "Confirm removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Program.form.CreateActionWorker().RunWorkerAsync(Requests.Generic("torrent-remove", GetId()));
                this.Close();
            }
        }

        private void SetHighPriorityHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesListView.SelectedItems)
            {
                item.SubItems[4].Text = "High";
            }
        }

        private void SetLowPriorityHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesListView.SelectedItems)
            {
                item.SubItems[4].Text = "Low";
            }
        }

        private void SetNormalPriorityHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesListView.SelectedItems)
            {
                item.SubItems[4].Text = "Normal";
            }
        }

        private void SetUnwantedHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesListView.SelectedItems)
            {
                item.Checked = false;
            }
        }

        private void SetWantedHandler(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesListView.SelectedItems)
            {
                item.Checked = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            JsonArray high = new JsonArray();
            JsonArray normal = new JsonArray();
            JsonArray low = new JsonArray();
            JsonArray wanted = new JsonArray();
            JsonArray unwanted = new JsonArray();
            foreach (ListViewItem item in FilesListView.Items)
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
            arguments.Put("speed-limit-up-enabled", UploadLimitEnable.Checked);
            arguments.Put("speed-limit-up", UploadLimitField.Value);
            arguments.Put("speed-limit-down-enabled", DownloadLimitEnable.Checked);
            arguments.Put("speed-limit-down", DownloadLimitField.Value);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            Program.form.CreateActionWorker().RunWorkerAsync(request);
            this.Close();
        }

        private void DownloadLimitEnable_CheckedChanged(object sender, EventArgs e)
        {
            DownloadLimitField.Enabled = DownloadLimitEnable.Checked;
        }

        private void UploadLimitEnable_CheckedChanged(object sender, EventArgs e)
        {
            UploadLimitField.Enabled = UploadLimitEnable.Checked;
        }

        private void FilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilesListView.ContextMenu = FilesListView.SelectedItems.Count > 0 ? this.yesSelectionMenu : this.noSelectionMenu;
        }

        private void FilesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Toolbox.SelectAll(FilesListView);
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            Toolbox.SelectAll(FilesListView);
        }
    }
}
