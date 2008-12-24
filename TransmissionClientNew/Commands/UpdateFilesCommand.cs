using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    public class UpdateFilesCommand : TransmissionCommand
    {
        private bool first;
        private List<UpdateFilesSubCommand> uiUpdateBatch;

        public UpdateFilesCommand(JsonObject response)
        {
            Program.ResetFailCount();
            uiUpdateBatch = new List<UpdateFilesSubCommand>();

            MainWindow form = Program.form;
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
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long bytesCompleted = ((JsonNumber)file[ProtocolConstants.FIELD_BYTESCOMPLETED]).ToInt64();
                long length = ((JsonNumber)file[ProtocolConstants.FIELD_LENGTH]).ToInt64();
                if (first)
                {
                    string name = (string)file[ProtocolConstants.FIELD_NAME];
                    UpdateFilesSubCommand subCommand = new UpdateFilesSubCommand(name, length, ((JsonNumber)wanted[i]).ToBoolean(), (JsonNumber)priorities[i], bytesCompleted);
                    uiUpdateBatch.Add(subCommand);
                }
                else if (i < form.fileItems.Count)
                {
                    ListViewItem item = form.fileItems[i];
                    UpdateFilesSubCommand subCommand = new UpdateFilesSubCommand(item, bytesCompleted);
                    uiUpdateBatch.Add(subCommand);
                }
            }
        }

        public void Execute()
        {
            MainWindow form = Program.form;
            lock (form.filesListView)
            {
                form.filesListView.SuspendLayout();
                foreach (UpdateFilesSubCommand uiUpdate in uiUpdateBatch)
                {
                    uiUpdate.Execute();
                }
                if (first)
                {
                    form.filesListView.Enabled = true;
                    Toolbox.StripeListView(form.filesListView);
                }
                form.filesListView.ResumeLayout();
            }
            form.filesTimer.Enabled = true;
        }
    }
}
