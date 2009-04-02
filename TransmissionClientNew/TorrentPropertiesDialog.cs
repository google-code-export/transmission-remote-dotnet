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
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTSET);
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            foreach (ListViewItem item in this.selections)
            {
                Torrent t = (Torrent)item.Tag;
                ids.Put(t.Id);
            }
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            arguments.Put(GetKey(uploadLimitEnableField), uploadLimitEnableField.Checked);
            arguments.Put(GetKey(uploadLimitField), uploadLimitField.Value);
            arguments.Put(GetKey(downloadLimitEnableField), downloadLimitEnableField.Checked);
            arguments.Put(GetKey(downloadLimitField), downloadLimitField.Value);
            arguments.Put(ProtocolConstants.FIELD_PEERLIMIT, peerLimitValue.Value);
            if (seedRatioLimitValue.Enabled)
                request.Put(ProtocolConstants.FIELD_SEEDRATIOLIMIT, seedRatioLimitValue.Value);
            if (honorsSessionLimits.Enabled)
                request.Put(ProtocolConstants.FIELD_HONORSSESSIONLIMITS, honorsSessionLimits.Checked);
            if (seedRatioLimitedCheckBox.Enabled)
                request.Put(ProtocolConstants.FIELD_SEEDRATIOLIMITED, seedRatioLimitedCheckBox.Checked);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            Program.Form.CreateActionWorker().RunWorkerAsync(request);
            this.Close();
        }

        private string GetKey(Control c)
        {
            return (string)c.Tag;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TorrentPropertiesDialog_Load(object sender, EventArgs e)
        {
            Torrent firstTorrent = (Torrent)selections[0].Tag;
            this.Text = selections.Count == 1 ? firstTorrent.Name : "Multiple Torrent Properties";
            uploadLimitField.Value = firstTorrent.SpeedLimitUp >= 0 && firstTorrent.SpeedLimitUp <= uploadLimitField.Maximum ? firstTorrent.SpeedLimitUp : 0;
            downloadLimitField.Value = firstTorrent.SpeedLimitDown >= 0 && firstTorrent.SpeedLimitDown <= downloadLimitField.Maximum ? firstTorrent.SpeedLimitDown : 0;
            uploadLimitField.Enabled = uploadLimitEnableField.Checked = firstTorrent.SpeedLimitUpEnabled;
            downloadLimitField.Enabled = downloadLimitEnableField.Checked = firstTorrent.SpeedLimitDownEnabled;
            uploadLimitField.Tag = Program.DaemonDescriptor.Revision >= 8100 ? ProtocolConstants.FIELD_UPLOADLIMIT : ProtocolConstants.FIELD_SPEEDLIMITUP;
            downloadLimitField.Tag = Program.DaemonDescriptor.Revision >= 8100 ? ProtocolConstants.FIELD_DOWNLOADLIMIT : ProtocolConstants.FIELD_SPEEDLIMITDOWN;
            uploadLimitEnableField.Tag = Program.DaemonDescriptor.Revision >= 8100 ? ProtocolConstants.FIELD_UPLOADLIMITED : ProtocolConstants.FIELD_SPEEDLIMITUPENABLED;
            downloadLimitEnableField.Tag = Program.DaemonDescriptor.Revision >= 8100 ? ProtocolConstants.FIELD_DOWNLOADLIMITED : ProtocolConstants.FIELD_SPEEDLIMITDOWNENABLED;
            try
            {
                honorsSessionLimits.Checked = firstTorrent.HonorsSessionLimits;
                honorsSessionLimits.Enabled = true;
            }
            catch
            {
                honorsSessionLimits.Enabled = false;
            }
            try
            {
                seedRatioLimitValue.Value = (decimal)firstTorrent.SeedRatioLimit;
                seedRatioLimitedCheckBox.Enabled = firstTorrent.SeedRatioMode;
                seedRatioLimitedCheckBox.Enabled = seedRatioLimitValue.Enabled = true;
            }
            catch
            {
                seedRatioLimitValue.Enabled = seedRatioLimitedCheckBox.Enabled = false;
            }
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
