using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewTextComparer : IComparer
    {
        int column;
        bool caseSensitive;

        public ListViewTextComparer(int column, bool caseSensitive)
        {
            this.column = column;
            this.caseSensitive = caseSensitive;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            if (caseSensitive)
            {
                return lx.SubItems[column].Text.CompareTo(ly.SubItems[column].Text);
            }
            else
            {
                return ((new CaseInsensitiveComparer()).Compare(lx.SubItems[column].Text, ly.SubItems[column].Text));
            }
        }
    }
}
