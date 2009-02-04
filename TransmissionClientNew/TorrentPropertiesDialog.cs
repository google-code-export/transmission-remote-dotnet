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
        private Torrent torrent;
        public TorrentPropertiesDialog(Torrent torrent)
        {
            this.torrent = torrent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, "torrent-set");
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            ids.Put(torrent.Id);
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            arguments.Put("speed-limit-up-enabled", uploadLimitEnableField.Checked);
            arguments.Put("speed-limit-up", uploadLimitField.Value);
            arguments.Put("speed-limit-down-enabled", downloadLimitEnableField.Checked);
            arguments.Put("speed-limit-down", downloadLimitField.Value);
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
            this.Text = torrent.Name + " - Torrent Properties";
            uploadLimitField.Enabled = uploadLimitEnableField.Checked = torrent.UploadLimitMode;
            downloadLimitField.Enabled = downloadLimitEnableField.Checked = torrent.DownloadLimitMode;
            uploadLimitField.Value = torrent.UploadLimit >= 0 && torrent.UploadLimit <= uploadLimitField.Maximum ? torrent.UploadLimit : 0;
            downloadLimitField.Value = torrent.DownloadLimit >= 0 && torrent.DownloadLimit <= downloadLimitField.Maximum ? torrent.DownloadLimit : 0;
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
