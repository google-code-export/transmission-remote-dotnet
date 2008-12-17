using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    class UpdateFilesCommand : TransmissionCommand
    {
        private JsonObject response;
        private bool includePriorities;

        public UpdateFilesCommand(JsonObject response, bool includePriorities)
        {
            this.includePriorities = includePriorities;
            this.response = response;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            MainWindow form = Program.form;
            if (torrents.Count != 1 || form.torrentListView.SelectedItems.Count != 1)
            {
                return;
            }
            JsonObject torrent = (JsonObject)torrents[0];
            int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
            Torrent t = (Torrent)form.torrentListView.SelectedItems[0].Tag;
            if (t.Id == id)
            {
                form.filesListView.SuspendLayout();
                UpdateFiles(torrent, form.filesListView);
                if (includePriorities)
                {
                    form.filesTimer.Enabled = true;
                    form.filesListView.Enabled = true;
                    Toolbox.StripeListView(form.filesListView);
                }
                form.filesListView.ResumeLayout();
            }
        }

        public static void UpdateFiles(JsonObject torrent, ListView listView)
        {
            JsonArray files = (JsonArray)torrent[ProtocolConstants.FIELD_FILES];
            if (files == null)
            {
                return;
            }
            JsonArray priorities = (JsonArray)torrent[ProtocolConstants.FIELD_PRIORITIES];
            JsonArray wanted = (JsonArray)torrent[ProtocolConstants.FIELD_WANTED];
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long length = ((JsonNumber)file["length"]).ToInt64();
                long done = ((JsonNumber)file["bytesCompleted"]).ToInt64();
                string lengthStr = Toolbox.GetFileSize(length);
                string percentStr = Toolbox.CalcPercentage(done, length) + "%";
                string completeStr = Toolbox.GetFileSize(done);
                string name = (string)file[ProtocolConstants.FIELD_NAME];
                if (i >= listView.Items.Count && priorities != null)
                {
                    ListViewItem item = new ListViewItem(name);
                    item.Name = name;
                    item.ToolTipText = name;
                    item.SubItems.Add(lengthStr);
                    item.SubItems.Add(completeStr);
                    item.SubItems.Add(percentStr);
                    item.SubItems.Add(Toolbox.FormatPriority((JsonNumber)priorities[i]));
                    item.Checked = ((JsonNumber)wanted[i]).ToBoolean();
                    listView.Items.Add(item);
                }
                else
                {
                    ListViewItem item = listView.Items[i];
                    item.SubItems[1].Text = lengthStr;
                    item.SubItems[2].Text = completeStr;
                    item.SubItems[3].Text = percentStr;
                }
            }
            listView.ResumeLayout();
        }
    }
}
