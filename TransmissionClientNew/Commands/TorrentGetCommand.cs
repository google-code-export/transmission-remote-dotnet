using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    public class TorrentGetCommand : TransmissionCommand
    {
        private JsonObject response;
        private Boolean beginLoop;

        public TorrentGetCommand(JsonObject response, Boolean beginLoop)
        {
            this.response = response;
            this.beginLoop = beginLoop;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            if (!Program.Connected)
            {
                return;
            }
            long totalUpload = 0;
            long totalDownload = 0;
            int totalTorrents = 0;
            int totalSeeding = 0;
            int totalDownloading = 0;
            long totalSize = 0;
            long totalDownloadedSize = 0;
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            Program.updateSerial++;
            MainWindow form = Program.form;
            form.SuspendTorrentListView();
            foreach (JsonObject torrent in torrents)
            {
                int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
                totalUpload += ((JsonNumber)torrent[ProtocolConstants.FIELD_RATEUPLOAD]).ToInt64();
                totalDownload += ((JsonNumber)torrent[ProtocolConstants.FIELD_RATEDOWNLOAD]).ToInt64();
                totalSize += ((JsonNumber)torrent[ProtocolConstants.FIELD_TOTALSIZE]).ToInt64();
                totalDownloadedSize += ((JsonNumber)torrent[ProtocolConstants.FIELD_HAVEVALID]).ToInt64();
                totalTorrents++;
                short status = ((JsonNumber)torrent[ProtocolConstants.FIELD_STATUS]).ToInt16();
                if (status == ProtocolConstants.STATUS_DOWNLOADING)
                {
                    totalDownloading++;
                }
                else if (status == ProtocolConstants.STATUS_SEEDING)
                {
                    totalSeeding++;
                }
                lock (Program.torrentIndex)
                {
                    if (Program.torrentIndex.ContainsKey(id))
                    {
                        Program.torrentIndex[id].Update(torrent);
                    }
                    else
                    {
                        Program.torrentIndex[id] = new Torrent(torrent);
                    }
                }
            }
            form.ResumeTorrentListView();
            form.UpdateStatus("Connected | " + Toolbox.GetFileSize(totalDownload) + "/s down, " + Toolbox.GetFileSize(totalUpload) + "/s up | " + totalTorrents + " torrents: " + totalDownloading + " downloading, " + totalSeeding + " seeding | " + Toolbox.GetFileSize(totalDownloadedSize) + " / " + Toolbox.GetFileSize(totalSize));
            Queue<int> removeQueue = new Queue<int>();
            foreach (KeyValuePair<int, Torrent> pair in Program.torrentIndex)
            {
                Torrent t = pair.Value;
                if (t.updateSerial != Program.updateSerial)
                {
                    t.Remove();
                    removeQueue.Enqueue(pair.Key);
                }
            }
            lock (Program.torrentIndex)
            {
                foreach (int id in removeQueue)
                {
                    Program.torrentIndex.Remove(id);
                }
            }
            PostUpdateUiOperations();
        }

        private delegate void PostUpdateUiOperationsDelegate();
        private void PostUpdateUiOperations()
        {
            MainWindow form = Program.form;
            if (form.InvokeRequired)
            {
                form.Invoke(new PostUpdateUiOperationsDelegate(this.PostUpdateUiOperations));
            }
            else
            {
                if (beginLoop)
                {
                    form.refreshTimer.Enabled = true;
                }
                Program.RaisePostUpdateEvent();
            }
        }
    }
}
