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
            Program.failCount = 0;
        }

        public void Execute()
        {
            JsonObject arguments = (JsonObject)response["arguments"];
            JsonArray torrents = (JsonArray)arguments["torrents"];
            foreach (JsonObject torrent in torrents)
            {
                int id = ((JsonNumber)torrent["id"]).ToInt32();
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
            JsonArray files = (JsonArray)torrent["files"];
            if (files == null)
            {
                return;
            }
            JsonArray priorities = (JsonArray)torrent["priorities"];
            if (priorities == null)
            {
                return;
            }
            JsonArray wanted = (JsonArray)torrent["wanted"];
            if (wanted == null)
            {
                return;
            }
            form.FilesListView.SuspendLayout();
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long length = ((JsonNumber)file["length"]).ToInt64();
                long done = ((JsonNumber)file["bytesCompleted"]).ToInt64();
                string lengthStr = Toolbox.GetFileSize(length);
                string percentStr = Math.Round((done / (decimal)length) * 100, 2) + "%";
                string completeStr = Toolbox.GetFileSize(done);
                string name = (string)file["name"];
                ListViewItem item;
                if ((item = GetFileItem(form.FilesListView, name)) == null)
                {
                    item = new ListViewItem(name);
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
                    item.SubItems[1].Text = percentStr;
                    item.SubItems[2].Text = lengthStr;
                    item.SubItems[3].Text = completeStr;
                }
            }
            form.FilesListView.ResumeLayout();
        }

        private static ListViewItem GetFileItem(ListView list, string name)
        {
            foreach (ListViewItem item in list.Items)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
