using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    public class Torrent
    {
        public ListViewItem item;
        public JsonObject info;
        public long updateSerial;

        public Torrent(JsonObject info)
        {
            this.updateSerial = Program.updateSerial;
            this.info = info;
            item = new ListViewItem(this.Name);
            item.ToolTipText = item.Name;
            item.Tag = this;
            item.SubItems.Add(this.TotalSizeString);
            decimal percentage = this.Percentage;
            item.SubItems.Add(percentage.ToString() + "%");
            item.SubItems.Add(this.Status);
            item.SubItems.Add(this.Seeders + " (" + this.PeersSendingToUs + ")");
            item.SubItems.Add(this.Leechers + " (" + this.PeersGettingFromUs + ")");
            item.SubItems.Add(percentage >= 100 ? "N/A" : this.DownloadRate);
            item.SubItems.Add(this.UploadRate);
            item.SubItems.Add(this.GetShortETA());
            item.SubItems.Add(this.UploadedString);
            item.SubItems.Add(this.RatioString);
            item.SubItems.Add(this.Added.ToString());
            item.SubItems.Add(percentage >= 100 ? "Unknown" : "N/A");
            Program.torrentIndex[this.Id] = this;
            Add();
            LogError();
        }

        private void LogError()
        {
            if (this.ErrorString != null && !this.ErrorString.Equals(""))
            {
                List<ListViewItem> logItems = Program.logItems;
                if (logItems.Count <= 0 || (logItems.Count > 0 && !Program.logItems[Program.logItems.Count - 1].SubItems[1].Text.Equals(this.Name)))
                {
                    Program.Log(this.Name, this.ErrorString);
                }
            }
        }

        public void Show()
        {
            ListView.ListViewItemCollection itemCollection = Program.form.torrentListView.Items;
            lock (Program.form.torrentListView)
            {
                if (!itemCollection.Contains(item))
                {
                    itemCollection.Add(item);
                }
            }
        }

        private delegate void AddDelegate();
        private void Add()
        {
            MainWindow form = Program.form;
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
                LogError();
            }
        }

        private delegate void RemoveDelegate();
        public void Remove()
        {
            MainWindow form = Program.form;
            if (form.InvokeRequired)
            {
                form.Invoke(new RemoveDelegate(this.Remove));
            }
            else
            {
                lock (form.torrentListView)
                {
                    ListView.ListViewItemCollection itemCollection = form.torrentListView.Items;
                    if (itemCollection.Contains(item))
                    {
                        itemCollection.Remove(item);
                    }
                }
            }
        }


        private delegate void UpdateDelegate(JsonObject info);
        public void Update(JsonObject info)
        {
            MainWindow form = Program.form;
            if (form.InvokeRequired)
            {
                form.Invoke(new UpdateDelegate(this.Update), info);
            }
            else
            {
                if (Program.form.notifyIcon.Visible == true
                    && ((JsonNumber)this.info[ProtocolConstants.FIELD_STATUS]).ToInt16() == ProtocolConstants.STATUS_DOWNLOADING
                    && ((JsonNumber)this.info[ProtocolConstants.FIELD_LEFTUNTILDONE]).ToInt64() > 0
                    && ((JsonNumber)info[ProtocolConstants.FIELD_LEFTUNTILDONE]).ToInt64() == 0)
                {
                    Program.form.notifyIcon.ShowBalloonTip(LocalSettingsSingleton.COMPLETED_BALOON_TIMEOUT, this.Name, "This torrent has finished downloading.", ToolTipIcon.Info);
                    item.SubItems[12].Text = DateTime.Now.ToString();
                }
                this.info = info;
                item.SubItems[0].Text = this.Name;
                item.SubItems[1].Text = this.TotalSizeString;
                decimal percentage = this.Percentage;
                item.SubItems[2].Text = percentage.ToString() + "%";
                item.SubItems[3].Text = this.Status;
                item.SubItems[4].Text = this.Seeders + " (" + this.PeersSendingToUs + ")";
                item.SubItems[5].Text = this.Leechers + " (" + this.PeersGettingFromUs + ")";
                item.SubItems[6].Text = percentage >= 100 ? "N/A" : this.DownloadRate;
                item.SubItems[7].Text = this.UploadRate;
                item.SubItems[8].Text = this.GetShortETA();
                item.SubItems[9].Text = this.UploadedString;
                item.SubItems[10].Text = this.RatioString;
                item.SubItems[11].Text = this.Added.ToString();
                //completed
                this.updateSerial = Program.updateSerial;
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
                return (string)info["creator"];
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
            if (this.Percentage >= 100)
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
                return Toolbox.GetSpeed(((JsonNumber)info["swarmSpeed"]).ToInt64());
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
                return ((JsonNumber)info["peersSendingToUs"]).ToInt32();
            }
        }

        public int PeersGettingFromUs
        {
            get
            {
                return ((JsonNumber)info["peersGettingFromUs"]).ToInt32();
            }
        }

        public string Created
        {
            get
            {
                return Toolbox.DateFromEpoch(((JsonNumber)info["dateCreated"]).ToDouble()).ToString();
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
