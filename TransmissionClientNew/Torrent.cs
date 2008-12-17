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
            double percentage = this.Percentage;
            item.SubItems.Add(percentage.ToString() + "%");
            item.SubItems.Add(this.Status);
            item.SubItems.Add(this.Seeders + " (" + this.PeersSendingToUs + ")");
            item.SubItems.Add("");
            item.SubItems.Add(percentage >= 100 ? "N/A" : this.DownloadRate);
            item.SubItems.Add(this.UploadRate);
            item.SubItems.Add(this.ETA);
            item.SubItems.Add(this.UploadedString);
            item.SubItems.Add(this.RatioString);
            item.SubItems.Add("");
            item.SubItems.Add(this.Added);
            Program.torrentIndex[this.Id] = this;
            Add();
        }

        public void Show()
        {
            ListView.ListViewItemCollection itemCollection = Program.form.torrentListView.Items;
            if (!itemCollection.Contains(item))
            {
                itemCollection.Add(item);
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
                form.torrentListView.Items.Add(item);
                form.StripeListView();
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
                ListView.ListViewItemCollection itemCollection = Program.form.torrentListView.Items;
                if (itemCollection.Contains(item))
                {
                    itemCollection.Remove(item);
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
                    item.SubItems[13].Text = DateTime.Now.ToString();
                }
                this.info = info;
                item.SubItems[0].Text = this.Name;
                item.SubItems[1].Text = this.TotalSizeString;
                double percentage = this.Percentage;
                item.SubItems[2].Text = percentage.ToString() + "%";
                item.SubItems[3].Text = this.Status;
                item.SubItems[4].Text = this.Seeders + " (" + this.PeersSendingToUs + ")";
                //peers
                item.SubItems[6].Text = percentage >= 100 ? "N/A" : this.DownloadRate;
                item.SubItems[7].Text = this.UploadRate;
                item.SubItems[8].Text = this.ETA;
                item.SubItems[9].Text = this.UploadedString;
                item.SubItems[10].Text = this.RatioString;
                item.SubItems[11].Text = this.Added;
                //completed
                this.updateSerial = Program.updateSerial;
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

        public string ETA
        {
            get
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
                        return TimeSpan.FromSeconds(eta).ToString();
                    }
                    else
                    {
                        return "Unknown";
                    }
                }
            }
        }

        public double Percentage
        {
            get
            {
                return Toolbox.CalcPercentage(this.HaveValid, this.TotalSize);
            }
        }

        public string Seeders
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_SEEDERS]).ToString();
            }
        }

        public string Leechers
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_LEECHERS]).ToString();
            }
        }

        public string SwarmSpeed
        {
            get
            {
                return Toolbox.GetFileSize(((JsonNumber)info["swarmSpeed"]).ToInt64()) + "/s";
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

        public string Added
        {
            get
            {
                return Toolbox.DateFromEpoch(((JsonNumber)info[ProtocolConstants.FIELD_ADDEDDATE]).ToDouble()).ToString();
            }
        }

        public string PeersSendingToUs
        {
            get
            {
                return ((JsonNumber)info["peersSendingToUs"]).ToString();
            }
        }

        public string PeersGettingFromUs
        {
            get
            {
                return ((JsonNumber)info["peersGettingFromUs"]).ToString();
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

        public long HaveValid
        {
            get
            {
                return ((JsonNumber)info[ProtocolConstants.FIELD_HAVEVALID]).ToInt64();
            }
        }

        public string HaveValidString
        {
            get
            {
                return Toolbox.GetFileSize(this.HaveValid);
            }
        }

        public string DownloadRate
        {
            get
            {
                return Toolbox.GetFileSize(((JsonNumber)info[ProtocolConstants.FIELD_RATEDOWNLOAD]).ToInt64()) + "/s";
            }
        }

        public string UploadRate
        {
            get
            {
                return Toolbox.GetFileSize(((JsonNumber)info[ProtocolConstants.FIELD_RATEUPLOAD]).ToInt64()) + "/s";
            }
        }

        public decimal Ratio
        {
            get
            {
                return Toolbox.CalcRatio(this.Uploaded, this.HaveValid);
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
