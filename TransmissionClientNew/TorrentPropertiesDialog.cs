// transmission-remote-dotnet
// http://code.google.com/p/transmission-remote-dotnet/
// Copyright (C) 2009 Alan F
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

﻿using System;
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
            JsonObject request = Requests.CreateBasicObject(ProtocolConstants.METHOD_TORRENTSET);
            JsonObject arguments = Requests.GetArgObject(request);
            JsonArray ids = new JsonArray();
            foreach (ListViewItem item in this.selections)
            {
                Torrent t = (Torrent)item.Tag;
                ids.Put(t.Id);
            }
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            arguments.Put(GetKey(uploadLimitEnableField), uploadLimitEnableField.Checked ? 1 : 0);
            arguments.Put(GetKey(uploadLimitField), uploadLimitField.Value);
            arguments.Put(GetKey(downloadLimitEnableField), downloadLimitEnableField.Checked ? 1 : 0);
            arguments.Put(GetKey(downloadLimitField), downloadLimitField.Value);
            arguments.Put(ProtocolConstants.FIELD_PEERLIMIT, peerLimitValue.Value);
            if (seedRatioLimitValue.Enabled)
                arguments.Put(ProtocolConstants.FIELD_SEEDRATIOLIMIT, seedRatioLimitValue.Value);
            if (honorsSessionLimits.Enabled)
                arguments.Put(ProtocolConstants.FIELD_HONORSSESSIONLIMITS, honorsSessionLimits.Checked);
            if (seedRatioLimitedCheckBox.Enabled)
                arguments.Put(ProtocolConstants.FIELD_SEEDRATIOMODE, seedRatioLimitedCheckBox.Checked ? 1 : 0);
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
                seedRatioLimitedCheckBox.Checked = firstTorrent.SeedRatioMode;
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
