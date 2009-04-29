using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public class ListViewDoneDateComparer : IComparer
    {
        private int index;

        public ListViewDoneDateComparer(int index)
        {
            this.index = index;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            Torrent tx = (Torrent)lx.Tag;
            Torrent ty = (Torrent)ly.Tag;
            if (tx.DoneDate == null)
            {
                return 1;
            }
            else if (ty.DoneDate == null)
            {
                return -1;
            }
            else
            {
                return ((DateTime)tx.DoneDate).CompareTo((DateTime)ty.DoneDate);
            }
        }
    }
}
