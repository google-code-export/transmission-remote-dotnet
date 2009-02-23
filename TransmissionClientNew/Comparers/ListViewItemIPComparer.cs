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
        private const char
            IPV4_DELIMITER = '.',
            IPV6_DELIMITER = ':';

        int columnIndex;

        public ListViewItemIPComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            string sx = lx.SubItems[columnIndex].Text;
            string sy = ly.SubItems[columnIndex].Text;
            if (sx.IndexOf(IPV4_DELIMITER) > 0 && sy.IndexOf(IPV4_DELIMITER) > 0)
            {
                IComparer cmp = new IPv4StringComparer();
                return cmp.Compare(sx, sy);
            }
            else if (sx.IndexOf(IPV6_DELIMITER) >= 0 && sy.IndexOf(IPV6_DELIMITER) >= 0)
            {
                IComparer cmp = new IPv6StringComparer();
                return cmp.Compare(sx, sy);
            }
            else if (sx.IndexOf(IPV4_DELIMITER) > 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
