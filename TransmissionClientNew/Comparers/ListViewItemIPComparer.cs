using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewItemIPComparer : IComparer
    {
        int columnIndex;

        public ListViewItemIPComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            char splitChar = '.';
            string[] qx = lx.SubItems[columnIndex].Text.Split(splitChar);
            string[] qy = ly.SubItems[columnIndex].Text.Split(splitChar);
            for (int i = 0; i < qx.Length; i++)
            {
                int qpx = Int32.Parse(qx[i]);
                int qpy = Int32.Parse(qy[i]);
                if (!qpx.Equals(qpy))
                {
                    return qpx.CompareTo(qpy);
                }
            }
            return 0;
        }
    }
}
