using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace TransmissionRemoteDotnet.Commmands
{
    public class ResolveHostCommand : TransmissionCommand
    {
        private ListViewItem item;
        private IPHostEntry host;

        public ResolveHostCommand(ListViewItem item)
        {
            this.item = item;
            try
            {
                this.host = Dns.GetHostEntry(item.SubItems[0].Text);
            }
            catch { }
        }

        public void Execute()
        {
            if (this.host != null && !host.HostName.Equals(this.item.SubItems[0].Text))
            {
                item.SubItems[1].Text = item.ToolTipText = host.HostName;
            }
        }
    }
}
