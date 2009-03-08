using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commands
{     
    class UpdateFilesUpdateSubCommand : TransmissionCommand
    {
        private ListViewItem item;
        private long bytesCompleted;
        private string bytesCompletedStr;
        private decimal progress;

        public UpdateFilesUpdateSubCommand(ListViewItem item, long bytesCompleted)
        {
            this.item = item;
            this.bytesCompleted = bytesCompleted;
            this.bytesCompletedStr = Toolbox.GetFileSize(bytesCompleted);
            this.progress = Toolbox.CalcPercentage(bytesCompleted, (long)item.SubItems[1].Tag);
        }

        public void Execute()
        {
            item.SubItems[2].Tag = bytesCompleted;
            item.SubItems[2].Text = bytesCompletedStr;
            item.SubItems[3].Tag = progress;
            item.SubItems[3].Text = progress + "%";
        }
    }

    class UpdateFilesCreateSubCommand : TransmissionCommand
    {
        private ListViewItem item;

        public UpdateFilesCreateSubCommand(string name, long length, bool wanted,
            JsonNumber priority, long bytesCompleted)
        {
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
            item.Name = item.ToolTipText = name;
            item.SubItems.Add(Toolbox.GetFileSize(length));
            item.SubItems[1].Tag = length;
            item.SubItems.Add(Toolbox.GetFileSize(bytesCompleted));
            item.SubItems[2].Tag = bytesCompleted;
            decimal progress = Toolbox.CalcPercentage(bytesCompleted, length);
            item.SubItems.Add(progress + "%");
            item.SubItems[3].Tag = progress;
            item.SubItems.Add(wanted ? OtherStrings.No : OtherStrings.Yes);
            item.SubItems.Add(FormatPriority(priority));
            lock (Program.Form.FileItems)
            {
                Program.Form.FileItems.Add(item);
            }
        }

        public void Execute()
        {
            Program.Form.filesListView.Items.Add(item);
        }

        private string FormatPriority(JsonNumber n)
        {
            short s = n.ToInt16();
            if (s < 0)
            {
                return OtherStrings.Low;
            }
            else if (s > 0)
            {
                return OtherStrings.High;
            }
            else
            {
                return OtherStrings.Normal;
            }
        }
    }
}
