using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Commands;

namespace TransmissionRemoteDotnet.Commmands
{
    public class UpdateFilesCommand : TransmissionCommand
    {
        private bool first;
        private List<TransmissionCommand> uiUpdateBatch;

        public UpdateFilesCommand(JsonObject response)
        {
            Program.DaemonDescriptor.ResetFailCount();
            MainWindow form = Program.Form;
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            if (torrents.Count != 1)
            {
                return;
            }
            JsonObject torrent = (JsonObject)torrents[0];
            int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
            Torrent t = null;
            form.Invoke(new MethodInvoker(delegate()
            {
                ListView torrentListView = form.torrentListView;
                lock (torrentListView)
                {
                    if (torrentListView.SelectedItems.Count == 1)
                    {
                        t = (Torrent)torrentListView.SelectedItems[0].Tag;
                    }
                }
            }));
            if (t == null || t.Id != id)
            {
                return;
            }
            JsonArray files = (JsonArray)torrent[ProtocolConstants.FIELD_FILES];
            if (files == null)
            {
                return;
            }
            JsonArray priorities = (JsonArray)torrent[ProtocolConstants.FIELD_PRIORITIES];
            JsonArray wanted = (JsonArray)torrent[ProtocolConstants.FIELD_WANTED];
            first = (priorities != null && wanted != null);
            uiUpdateBatch = new List<TransmissionCommand>();
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long bytesCompleted = ((JsonNumber)file[ProtocolConstants.FIELD_BYTESCOMPLETED]).ToInt64();
                long length = ((JsonNumber)file[ProtocolConstants.FIELD_LENGTH]).ToInt64();
                if (first)
                {
                    string name = (string)file[ProtocolConstants.FIELD_NAME];
                    UpdateFilesCreateSubCommand subCommand = new UpdateFilesCreateSubCommand(name, length, Toolbox.ToBool(wanted[i]), (JsonNumber)priorities[i], bytesCompleted);
                    uiUpdateBatch.Add((TransmissionCommand)subCommand);
                }
                else
                {
                    lock (form.FileItems)
                    {
                        if (i < form.FileItems.Count)
                        {
                            ListViewItem item = form.FileItems[i];
                            UpdateFilesUpdateSubCommand subCommand = new UpdateFilesUpdateSubCommand(item, bytesCompleted);
                            uiUpdateBatch.Add((TransmissionCommand)subCommand);
                        }
                    }
                }
            }
        }

        public void Execute()
        {
            if (uiUpdateBatch == null)
            {
                return;
            }
            MainWindow form = Program.Form;
            lock (form.filesListView)
            {
                form.filesListView.SuspendLayout();
                foreach (TransmissionCommand uiUpdate in uiUpdateBatch)
                {
                    uiUpdate.Execute();
                }
                if (first)
                {
                    form.filesListView.Enabled = true;
                }
                form.filesListView.Sort();
                Toolbox.StripeListView(form.filesListView);
                form.filesListView.ResumeLayout();
            }
            form.filesTimer.Enabled = true;
        }
    }
}
