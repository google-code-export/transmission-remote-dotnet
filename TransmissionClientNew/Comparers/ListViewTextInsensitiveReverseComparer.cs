using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewTextInsensitiveReverseComparer : IComparer
    {
        int column;

        public ListViewTextInsensitiveReverseComparer(int column)
        {
            this.column = column;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            string sx = ReverseString(lx.SubItems[column].Text);
            string sy = ReverseString(ly.SubItems[column].Text);
            return ((new CaseInsensitiveComparer()).Compare(sx, sy));
        }

        string ReverseString(string str)
        {
            char[] strArray = str.ToCharArray();
            Array.Reverse(strArray);
            return new string(strArray);
        }
    }
}
