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

        public TorrentGetCommand(JsonObject response)
        {
            this.response = response;
            Program.ResetFailCount();
        }

        private delegate void ExecuteDelegate();
        public void Execute()
        {
            MainWindow form = Program.form;
            if (form.InvokeRequired)
            {
                form.Invoke(new ExecuteDelegate(this.Execute));
            }
            else
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
                form.UpdateGraph((int)totalDownload, (int)totalUpload);
                form.UpdateStatus(String.Format(
                    "Connected | {0} down, {1} up | {2} torrents: {3} downloading, {4} seeding | {5} / {6}",
                    new object[] {
                        Toolbox.GetSpeed(totalDownload),
                        Toolbox.GetSpeed(totalUpload),
                        totalTorrents,
                        totalDownloading,
                        totalSeeding,
                        Toolbox.GetFileSize(totalDownloadedSize),
                        Toolbox.GetFileSize(totalSize)
                    }
                ));
                Queue<KeyValuePair<int, Torrent>> removeQueue = null;
                lock (Program.torrentIndex)
                {
                    foreach (KeyValuePair<int, Torrent> pair in Program.torrentIndex)
                    {
                        Torrent t = pair.Value;
                        if (t.updateSerial != Program.updateSerial)
                        {
                            if (removeQueue == null)
                            {
                                removeQueue = new Queue<KeyValuePair<int, Torrent>>();
                            }
                            removeQueue.Enqueue(pair);
                        }
                    }
                    if (removeQueue != null)
                    {
                        foreach (KeyValuePair<int, Torrent> pair in removeQueue)
                        {
                            Program.torrentIndex.Remove(pair.Key);
                            pair.Value.Remove();
                        }
                    }
                }
                Program.RaisePostUpdateEvent();
            }
        }
    }
}
