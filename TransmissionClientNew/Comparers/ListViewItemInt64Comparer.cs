using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewItemInt64Comparer : IComparer
    {
        int columnIndex;

        public ListViewItemInt64Comparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            long nx = (long)lx.SubItems[columnIndex].Tag;
            long ny = (long)ly.SubItems[columnIndex].Tag;
            return nx.CompareTo(ny);
        }
    }
}
