using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionClientNew.Commmands
{
    class UpdateFilesCommand : TransmissionCommand
    {
        private JsonObject response;

        public UpdateFilesCommand(JsonObject response)
        {
            this.response = response;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            foreach (JsonObject torrent in torrents)
            {
                int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
                TorrentInfoDialog form;
                if (Program.infoDialogs.ContainsKey(id))
                {
                    form = Program.infoDialogs[id];
                }
                else
                {
                    continue;
                }
                UpdateFiles(torrent, form);
                form.StatusStripLabel.Text = "";
            }
            Program.form.FilesTimer.Enabled = true;
        }

        public static void UpdateFiles(JsonObject torrent, TorrentInfoDialog form)
        {
            JsonArray files = (JsonArray)torrent[ProtocolConstants.FIELD_FILES];
            if (files == null)
            {
                return;
            }
            JsonArray priorities = (JsonArray)torrent[ProtocolConstants.FIELD_PRIORITIES];
            JsonArray wanted = (JsonArray)torrent[ProtocolConstants.FIELD_WANTED];
            form.FilesListView.SuspendLayout();
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long length = ((JsonNumber)file["length"]).ToInt64();
                long done = ((JsonNumber)file["bytesCompleted"]).ToInt64();
                string lengthStr = Toolbox.GetFileSize(length);
                string percentStr = Toolbox.CalcPercentage(done, length) + "%";
                string completeStr = Toolbox.GetFileSize(done);
                string name = (string)file[ProtocolConstants.FIELD_NAME];
                if (i >= form.FilesListView.Items.Count)
                {
                    ListViewItem item = new ListViewItem(name);
                    item.Name = name;
                    item.ToolTipText = name;
                    item.SubItems.Add(percentStr);
                    item.SubItems.Add(lengthStr);
                    item.SubItems.Add(completeStr);
                    item.SubItems.Add(form.FormatPriority((JsonNumber)priorities[i]));
                    item.Checked = ((JsonNumber)wanted[i]).ToBoolean();
                    form.FilesListView.Items.Add(item);
                }
                else
                {
                    ListViewItem item = form.FilesListView.Items[i];
                    item.SubItems[1].Text = percentStr;
                    item.SubItems[2].Text = lengthStr;
                    item.SubItems[3].Text = completeStr;
                }
            }
            form.FilesListView.ResumeLayout();
        }
    }
}
