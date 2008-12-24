using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commands
{
    public enum UpdateFilesSubCommandMode
    {
        Create,
        Update
    }
     
    class UpdateFilesSubCommand : TransmissionCommand
    {
        private UpdateFilesSubCommandMode mode;
        private ListViewItem item;
        private long bytesCompleted;
        private string bytesCompletedStr;
        private decimal progress;

        public UpdateFilesSubCommand(string name, long length, bool wanted,
            JsonNumber priority, long bytesCompleted)
        {
            this.mode = UpdateFilesSubCommandMode.Create;
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
            this.item = new ListViewItem(name);
            item.Name = name;
            item.ToolTipText = name;
            item.SubItems.Add(Toolbox.GetFileSize(length));
            item.SubItems[1].Tag = length;
            item.SubItems.Add(Toolbox.GetFileSize(bytesCompleted));
            item.SubItems[2].Tag = bytesCompleted;
            decimal progress = Toolbox.CalcPercentage(bytesCompleted, length);
            item.SubItems.Add(progress + "%");
            item.SubItems[3].Tag = progress;
            item.SubItems.Add(wanted ? "No" : "Yes");
            item.SubItems.Add(FormatPriority(priority));
            lock (Program.form.fileItems)
            {
                Program.form.fileItems.Add(item);
            }
        }

        public UpdateFilesSubCommand(ListViewItem item, long bytesCompleted)
        {
            this.mode = UpdateFilesSubCommandMode.Update;
            this.item = item;
            this.bytesCompleted = bytesCompleted;
            this.bytesCompletedStr = Toolbox.GetFileSize(bytesCompleted);
            this.progress = Toolbox.CalcPercentage(bytesCompleted, (long)item.SubItems[1].Tag);
        }

        public void Execute()
        {
            if (this.mode == UpdateFilesSubCommandMode.Create)
            {
                Program.form.filesListView.Items.Add(item);
            }
            else if (this.mode == UpdateFilesSubCommandMode.Update)
            {
                item.SubItems[2].Tag = bytesCompleted;
                item.SubItems[2].Text = bytesCompletedStr;
                item.SubItems[3].Tag = progress;
                item.SubItems[3].Text = progress + "%";
            }
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
