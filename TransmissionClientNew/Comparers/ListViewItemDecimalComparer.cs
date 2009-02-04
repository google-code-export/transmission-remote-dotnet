using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewItemDecimalComparer : IComparer
    {
        int columnIndex;

        public ListViewItemDecimalComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            decimal nx = (decimal)lx.SubItems[columnIndex].Tag;
            decimal ny = (decimal)ly.SubItems[columnIndex].Tag;
            return nx.CompareTo(ny);
        }
    }
}
