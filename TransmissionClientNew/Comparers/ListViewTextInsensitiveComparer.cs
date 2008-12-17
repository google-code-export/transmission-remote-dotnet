using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewTextInsensitiveComparer : IComparer
    {
        int column;

        public ListViewTextInsensitiveComparer(int column)
        {
            this.column = column;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            return ((new CaseInsensitiveComparer()).Compare(lx.SubItems[column].Text, ly.SubItems[column].Text));
        }
    }
}
