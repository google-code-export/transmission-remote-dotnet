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
            MainWindow form = Program.form;
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            if (torrents.Count != 1)
            {
                return;
            }
            JsonObject torrent = (JsonObject)torrents[0];
            int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
            Torrent t;
            lock (form.torrentListView)
            {
                if (form.torrentListView.SelectedItems.Count != 1)
                {
                    return;
                }
                else
                {
                    t = (Torrent)form.torrentListView.SelectedItems[0].Tag;
                }
            }
            if (t.Id != id)
            {
                return;
            }
            form.filesListView.SuspendLayout();
            JsonArray files = (JsonArray)torrent[ProtocolConstants.FIELD_FILES];
            if (files == null)
            {
                return;
            }
            JsonArray priorities = (JsonArray)torrent[ProtocolConstants.FIELD_PRIORITIES];
            JsonArray wanted = (JsonArray)torrent[ProtocolConstants.FIELD_WANTED];
            ListView filesListView = form.filesListView;
            for (int i = 0; i < files.Length; i++)
            {
                JsonObject file = (JsonObject)files[i];
                long done = ((JsonNumber)file[ProtocolConstants.FIELD_BYTESCOMPLETED]).ToInt64();
                long length = ((JsonNumber)file[ProtocolConstants.FIELD_LENGTH]).ToInt64();
                decimal progress = Toolbox.CalcPercentage(done, length);
                lock (filesListView)
                {
                    if (i >= filesListView.Items.Count && priorities != null && wanted != null)
                    {
                        string name = (string)file[ProtocolConstants.FIELD_NAME];
                        int fwdSlashPos = name.IndexOf('/');
                        if (fwdSlashPos > 0)
                        {
                            name = name.Remove(0, fwdSlashPos + 1);
                        }
                        else
                        {
                            int bckSlashPos = name.IndexOf('\\');
                            if (bckSlashPos > 0)
                            {
                                name = name.Remove(0, bckSlashPos + 1);
                            }
                        }
                        ListViewItem item = new ListViewItem(name);
                        item.Name = name;
                        item.Tag = file;
                        item.ToolTipText = name;
                        item.SubItems.Add(Toolbox.GetFileSize(length));
                        item.SubItems[1].Tag = length;
                        item.SubItems.Add(Toolbox.GetFileSize(done));
                        item.SubItems[2].Tag = done;
                        item.SubItems.Add(progress + "%");
                        item.SubItems[3].Tag = progress;
                        item.SubItems.Add(((JsonNumber)wanted[i]).ToBoolean() ? "No" : "Yes");
                        item.SubItems.Add(FormatPriority((JsonNumber)priorities[i]));
                        filesListView.Items.Add(item);
                    }
                    else if (i < filesListView.Items.Count)
                    {
                        ListViewItem item = form.fileItems[i];
                        item.SubItems[2].Text = Toolbox.GetFileSize(done);
                        item.SubItems[2].Tag = done;
                        item.SubItems[3].Text = progress + "%";
                        item.SubItems[3].Tag = progress;
                    }
                }
            }
            if (includePriorities)
            {
                form.filesListView.Enabled = true;
                Toolbox.StripeListView(form.filesListView);
                Toolbox.CloneListViewItemCollection(form.filesListView, form.fileItems);
            }
            form.filesListView.ResumeLayout();
            form.filesTimer.Enabled = true;
        }

        private string FormatPriority(JsonNumber n)
        {
            short s = n.ToInt16();
            if (s < 0)
            {
                return "Low";
            }
            else if (s > 0)
            {
                return "High";
            }
            else
            {
                return "Normal";
            }
        }
    }
}
