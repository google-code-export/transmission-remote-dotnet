using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    public partial class TorrentPropertiesDialog : Form
    {
        private ListView.SelectedListViewItemCollection selections;

        public TorrentPropertiesDialog(ListView.SelectedListViewItemCollection selections)
        {
            this.selections = selections;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, "torrent-set");
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            foreach (ListViewItem item in this.selections)
            {
                Torrent t = (Torrent)item.Tag;
                ids.Put(t.Id);
            }
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            arguments.Put("speed-limit-up-enabled", uploadLimitEnableField.Checked);
            arguments.Put("speed-limit-up", uploadLimitField.Value);
            arguments.Put("speed-limit-down-enabled", downloadLimitEnableField.Checked);
            arguments.Put("speed-limit-down", downloadLimitField.Value);
            arguments.Put("peer-limit", peerLimitValue.Value);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            Program.Form.CreateActionWorker().RunWorkerAsync(request);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TorrentPropertiesDialog_Load(object sender, EventArgs e)
        {
            Torrent firstTorrent = (Torrent)selections[0].Tag;
            this.Text = selections.Count == 1 ? firstTorrent.Name : "Multiple Torrent Properties";
            uploadLimitField.Enabled = uploadLimitEnableField.Checked = firstTorrent.UploadLimitMode;
            downloadLimitField.Enabled = downloadLimitEnableField.Checked = firstTorrent.DownloadLimitMode;
            uploadLimitField.Value = firstTorrent.UploadLimit >= 0 && firstTorrent.UploadLimit <= uploadLimitField.Maximum ? firstTorrent.UploadLimit : 0;
            downloadLimitField.Value = firstTorrent.DownloadLimit >= 0 && firstTorrent.DownloadLimit <= downloadLimitField.Maximum ? firstTorrent.DownloadLimit : 0;
            peerLimitValue.Value = firstTorrent.MaxConnectedPeers;
        }

        private void downloadLimitEnableField_CheckedChanged(object sender, EventArgs e)
        {
            downloadLimitField.Enabled = downloadLimitEnableField.Checked;
        }

        private void uploadLimitEnableField_CheckedChanged(object sender, EventArgs e)
        {
            uploadLimitField.Enabled = uploadLimitEnableField.Checked;
        }
    }
}
