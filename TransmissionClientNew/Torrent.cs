using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace TransmissionRemoteDotnet
{
    public class Torrent
    {
        private ListViewItem item;

        public ListViewItem Item
        {
            get { return item; }
        }
        private JsonObject info;

        public JsonObject Info
        {
            get { return info; }
        }
        private long updateSerial;

        public long UpdateSerial
        {
            get { return updateSerial; }
        }

        public Torrent(JsonObject info)
        {
            this.updateSerial = Program.DaemonDescriptor.UpdateSerial;
            this.info = info;
            item = new ListViewItem(this.Name);
            if (this.HasError)
            {
                item.ForeColor = Color.Red;
            }
            item.ToolTipText = item.Name;
            item.Tag = this;
            item.SubItems.Add(this.TotalSizeString);
            decimal percentage = this.StatusCode == ProtocolConstants.STATUS_CHECKING ? this.RecheckPercentage : this.Percentage;
            item.SubItems.Add(percentage.ToString() + "%");
            item.SubItems[2].Tag = percentage;
            item.SubItems.Add(this.Status);
            item.SubItems.Add((this.Seeders < 0 ? "?" : this.Seeders.ToString()) + " (" + this.PeersSendingToUs + ")");
            item.SubItems.Add((this.Leechers < 0 ? "?" : this.Leechers.ToString()) + " (" + this.PeersGettingFromUs + ")");
            item.SubItems.Add(this.StatusCode == ProtocolConstants.STATUS_DOWNLOADING && this.Percentage <= 100 ? this.DownloadRate : "N/A");
            item.SubItems.Add(this.StatusCode == ProtocolConstants.STATUS_SEEDING || this.StatusCode == ProtocolConstants.STATUS_DOWNLOADING ? this.UploadRate : "N/A");
            item.SubItems.Add(this.GetShortETA());
            item.SubItems.Add(this.UploadedString);
            item.SubItems.Add(this.RatioString);
            item.SubItems.Add(this.Added.ToString());
            item.SubItems.Add(percentage >= 100 || this.StatusCode == ProtocolConstants.STATUS_SEEDING ? "Unknown" : "N/A");
            item.SubItems.Add(GetFirstTracker(true));
            Program.TorrentIndex[this.Id] = this;
            Add();
        }

        private delegate void AddDelegate();
        private void Add()
        {
            MainWindow form = Program.Form;
            if (form.InvokeRequired)
            {
                form.Invoke(new AddDelegate(this.Add));
            }
            else
            {
                lock (form.torrentListView)
                {
                    form.torrentListView.Items.Add(item);
                }
                lock (form.stateListBox)
                {
                    if (!form.stateListBox.Items.Contains(item.SubItems[13].Text))
                    {
                        form.stateListBox.Items.Add(item.SubItems[13].Text);
                    }
                }
                LogError();
            }
        }

        private void LogError()
        {
            if (this.HasError)
            {
                List<ListViewItem> logItems = Program.LogItems;
                lock (logItems)
                {
                    if (logItems.Count > 0)
                    {
                        foreach (ListViewItem item in logItems)
                        {
                            if (item.Tag != null && this.updateSerial-(long)item.Tag < 2 && item.SubItems[1].Text.Equals(this.Name) && item.SubItems[2].Text.Equals(this.ErrorString))
                            {
                                item.Tag = this.updateSerial;
                                return;
                            }
                        }
                    }
                }
                Program.Log(this.Name, this.ErrorString, this.updateSerial);
            }
        }

        public void Show()
        {
            ListView.ListViewItemCollection itemCollection = Program.Form.torrentListView.Items;
            if (!itemCollection.Contains(item))
            {
                lock (Program.Form.torrentListView)
                {
                    if (!itemCollection.Contains(item))
                    {
                        itemCollection.Add(item);
                    }
                }
            }
        }

        public void Remove()
        {
            MainWindow form = Program.Form;
            int matchingTrackers = 0;
            ListView.ListViewItemCollection itemCollection = form.torrentListView.Items;
            if (itemCollection.Contains(item))
            {
                lock (form.torrentListView)
                {
                    if (itemCollection.Contains(item))
                    {
                        itemCollection.Remove(item);
                    }
                }
            }
            else
            {
                return;
            }
            lock (Program.TorrentIndex)
            {
                foreach (KeyValuePair<int, Torrent> pair in Program.TorrentIndex)
                {
                    if (this.item.SubItems[13].Text.Equals(pair.Value.item.SubItems[13].Text))
                    {
                        matchingTrackers++;
                    }
                }
            }
            if (matchingTrackers <= 0)
            {
                lock (form.stateListBox)
                {
                    form.stateListBox.Items.Remove(item.SubItems[13].Text);
                }
            }
        }

        public delegate void UpdateDelegate(JsonObject info);
        public void Update(JsonObject info)
        {
            MainWindow form = Program.Form;
            if (form.InvokeRequired)
            {
                form.Invoke(new UpdateDelegate(this.Update), info);
            }
            else
            {
                if (form.notifyIcon.Visible == true
                    && this.StatusCode == ProtocolConstants.STATUS_DOWNLOADING
                    && ((JsonNumber)this.info[ProtocolConstants.FIELD_LEFTUNTILDONE]).ToInt64() > 0
                    && (((JsonNumber)info[ProtocolConstants.FIELD_LEFTUNTILDONE]).ToInt64() == 0
                        || ((JsonNumber)info[ProtocolConstants.FIELD_STATUS]).ToInt16() == ProtocolConstants.STATUS_SEEDING))
                {
                    form.notifyIcon.ShowBalloonTip(LocalSettingsSingleton.COMPLETED_BALOON_TIMEOUT, this.Name, "This torrent has finished downloading.", ToolTipIcon.Info);
                    item.SubItems[12].Text = DateTime.Now.ToString();
                }
                this.info = info;
                item.SubItems[0].Text = this.Name;
                item.ForeColor = this.HasError ? Color.Red : SystemColors.WindowText;
                item.SubItems[1].Text = this.TotalSizeString;
                decimal percentage = this.StatusCode == ProtocolConstants.STATUS_CHECKING ? this.RecheckPercentage : this.Percentage;
                item.SubItems[2].Tag = percentage;
                item.SubItems[2].Text = percentage.ToString() + "%";
                item.SubItems[3].Text = this.Status;
                item.SubItems[4].Text = (this.Seeders < 0 ? "?" : this.Seeders.ToString()) + " (" + this.PeersSendingToUs + ")";
                item.SubItems[5].Text = (this.Leechers < 0 ? "?" : this.Leechers.ToString()) + " (" + this.PeersGettingFromUs + ")";
                item.SubItems[6].Text = this.StatusCode == ProtocolConstants.STATUS_DOWNLOADING && this.Percentage <= 100 ? this.DownloadRate : "N/A";
                item.SubItems[7].Text = this.StatusCode == ProtocolConstants.STATUS_SEEDING || this.StatusCode == ProtocolConstants.STATUS_DOWNLOADING ? this.UploadRate : "N/A";
                item.SubItems[8].Text = this.GetShortETA();
                item.SubItems[9].Text = this.UploadedString;
                item.SubItems[10].Text = this.RatioString;
                item.SubItems[11].Text = this.Added.ToString();
                this.updateSerial = Program.DaemonDescriptor.UpdateSerial;
                LogError();
            }
        }

        public JsonArray Peers
        {
            get
            {
                return (JsonArray)info[ProtocolConstants.FIELD_PEERS];
            }
        }

        public string GetFirstTracker(bool trim)
        {
            try
            {
                JsonObject tracker = (JsonObject)this.Trackers[0];
                Uri announceUrl = new Uri((string)tracker["announce"]);
                if (!trim)
                {
                    return announceUrl.Host;
                }
                else
                {
                    return Regex.Replace(Regex.Replace(Regex.Replace(announceUrl.Host, "^tracker.", ""), "^www.", ""), "^torrent.", "");
                }
            }
            catch
            {
                return "";
            }
        }

        public int MaxConnectedPeers
        {
            get
            {
                return ((JsonNumber)this.info[ProtocolConstants.FIELD_MAXCONNECTEDPEERS]).ToInt32();
            }
        }

        public JsonArray Trackers
        {
            get
            {
                return (JsonArray)info[ProtocolConstants.FIELD_TRACKERS];
            }
        }

        public string Name
        {
            get
            {
                return (string)info[ProtocolConstants.FIELD_NAME];
            }
        }

        public string Status
        {
            get
            {
                switch (this.StatusCode)
                {
                    case 1:
                        return "Waiting to check";
                    case 2:
                        return "Checking";
                    case 4:
                        return "Downloading";
                    case 8:
                        return "Seeding";
                    case 16:
                        return "Paused";
                    default:
                        return "Unknown";
                }
            }
        }

        public short StatusCode
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_STATUS]).ToInt16();
            }
        }

        public int Id
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_ID]).ToInt32();
            }
        }

        public int DownloadLimit
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_DOWNLOADLIMIT]).ToInt32();
            }
        }

        public bool DownloadLimitMode
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_DOWNLOADLIMITMODE]).ToBoolean();
            }
        }

        public int UploadLimit
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_UPLOADLIMIT]).ToInt32();
            }
        }

        public bool UploadLimitMode
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_UPLOADLIMITMODE]).ToBoolean();
            }
        }

        public bool HasError
        {
            get
            {
                return this.ErrorString != null && !this.ErrorString.Equals("");
            }
        }

        public string ErrorString
        {
            get
            {
                return (string)info[ProtocolConstants.FIELD_ERRORSTRING];
            }
        }

        public string Creator
        {
            get
            {
                return (string)info[ProtocolConstants.FIELD_CREATOR];
            }
        }

        public string GetShortETA()
        {
            return GetETA(true);
        }

        public string GetLongETA()
        {
            return GetETA(false);
        }

        private string GetETA(bool small)
        {
            if (this.Percentage >= 100 || this.StatusCode == ProtocolConstants.STATUS_SEEDING)
            {
                return "N/A";
            }
            else
            {
                double eta = ((JsonNumber)info[ProtocolConstants.FIELD_ETA]).ToDouble();
                if (eta > 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(eta);
                    if (small)
                    {
                        return ts.ToString();
                    }
                    else
                    {
                        return Toolbox.FormatTimespanLong(ts);
                    }
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        public decimal RecheckPercentage
        {
            get
            {
                return Toolbox.ParseProgress((string)info[ProtocolConstants.FIELD_RECHECKPROGRESS]);
            }
        }

        public decimal Percentage
        {
            get
            {
                return Toolbox.CalcPercentage(this.HaveTotal, this.TotalSize);
            }
        }

        public int Seeders
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_SEEDERS]).ToInt32();
            }
        }

        public int Leechers
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_LEECHERS]).ToInt32();
            }
        }

        public string SwarmSpeed
        {
            get
            {
                return Toolbox.GetSpeed(((JsonNumber)info[ProtocolConstants.FIELD_SWARMSPEED]).ToInt64());
            }
        }

        public long TotalSize
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_TOTALSIZE]).ToInt64();
            }
        }

        public string TotalSizeString
        {
            get
            {
                return Toolbox.GetFileSize(this.TotalSize);
            }
        }

        public DateTime Added
        {
            get
            {
                return Toolbox.DateFromEpoch(((JsonNumber)info[ProtocolConstants.FIELD_ADDEDDATE]).ToDouble());
            }
        }

        public int PeersSendingToUs
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_PEERSSENDINGTOUS]).ToInt32();
            }
        }

        public int PeersGettingFromUs
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_PEERSGETTINGFROMUS]).ToInt32();
            }
        }

        public string Created
        {
            get
            {
                return Toolbox.DateFromEpoch(((JsonNumber)info[ProtocolConstants.FIELD_DATECREATED]).ToDouble()).ToString();
            }
        }

        public long Uploaded
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_UPLOADEDEVER]).ToInt64();
            }
        }

        public string UploadedString
        {
            get
            {
                return Toolbox.GetFileSize(this.Uploaded);
            }
        }

        public long HaveTotal
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_HAVEVALID]).ToInt64() + ((JsonNumber)info[ProtocolConstants.FIELD_HAVEUNCHECKED]).ToInt64();
            }
        }

        public string HaveValidString
        {
            get
            {
                return Toolbox.GetFileSize(this.HaveTotal);
            }
        }

        public string DownloadRate
        {
            get
            {
                return Toolbox.GetSpeed(((JsonNumber)info[ProtocolConstants.FIELD_RATEDOWNLOAD]).ToInt64());
            }
        }

        public string UploadRate
        {
            get
            {
                return Toolbox.GetSpeed(((JsonNumber)info[ProtocolConstants.FIELD_RATEUPLOAD]).ToInt64());
            }
        }

        public decimal Ratio
        {
            get
            {
                return Toolbox.CalcRatio(this.Uploaded, this.HaveTotal);
            }
        }

        public string RatioString
        {
            get
            {
                decimal ratio = this.Ratio;
                return ratio < 0 ? "∞" : ratio.ToString();
            }
        }

        public string Comment
        {
            get
            {
                return (string)info[ProtocolConstants.FIELD_COMMENT];
            }
        }
    }
}
