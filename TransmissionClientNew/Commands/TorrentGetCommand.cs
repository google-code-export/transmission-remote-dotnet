using System;
using System.Collections.Generic;
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
            Program.DaemonDescriptor.ResetFailCount();
        }

        private delegate void ExecuteDelegate();
        public void Execute()
        {
            MainWindow form = Program.Form;
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
                Program.DaemonDescriptor.UpdateSerial++;
                form.SuspendTorrentListView();
                foreach (JsonObject torrent in torrents)
                {
                    string hash = (string)torrent[ProtocolConstants.FIELD_HASHSTRING];
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
                    Torrent t = null;
                    lock (Program.TorrentIndex)
                    {
                        if (Program.TorrentIndex.ContainsKey(hash))
                        {
                            t = Program.TorrentIndex[hash];
                        }
                    }
                    if (t == null)
                    {
                        t = new Torrent(torrent);
                    }
                    else
                    {
                        t.Update(torrent);
                    }
                }
                form.ResumeTorrentListView();
                form.UpdateGraph((int)totalDownload, (int)totalUpload);
                form.UpdateStatus(String.Format(
                    "{0} {1}, {2} {3} | {4} {5}: {6} {7}, {8} {9} | {10} / {11}",
                    new object[] {
                        Toolbox.GetSpeed(totalDownload),
                        OtherStrings.Down.ToLower(),
                        Toolbox.GetSpeed(totalUpload),
                        OtherStrings.Up.ToLower(),
                        totalTorrents,
                        OtherStrings.Torrents.ToLower(),
                        totalDownloading,
                        OtherStrings.Downloading.ToLower(),
                        totalSeeding,
                        OtherStrings.Seeding.ToLower(),
                        Toolbox.GetFileSize(totalDownloadedSize),
                        Toolbox.GetFileSize(totalSize)
                    }
                ));
                Queue<KeyValuePair<string, Torrent>> removeQueue = null;
                lock (Program.TorrentIndex)
                {
                    foreach (KeyValuePair<string, Torrent> pair in Program.TorrentIndex)
                    {
                        Torrent t = pair.Value;
                        if (t.UpdateSerial != Program.DaemonDescriptor.UpdateSerial)
                        {
                            if (removeQueue == null)
                            {
                                removeQueue = new Queue<KeyValuePair<string, Torrent>>();
                            }
                            removeQueue.Enqueue(pair);
                        }
                    }
                    if (removeQueue != null)
                    {
                        foreach (KeyValuePair<string, Torrent> pair in removeQueue)
                        {
                            Program.TorrentIndex.Remove(pair.Key);
                            pair.Value.Remove();
                        }
                    }
                }
                Program.RaisePostUpdateEvent();
            }
        }
    }
}
