using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewTorrentInt64Comparer : IComparer
    {
        string jsonKey;

        public ListViewTorrentInt64Comparer(string jsonKey)
        {
            this.jsonKey = jsonKey;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            Torrent tx = (Torrent)lx.Tag;
            Torrent ty = (Torrent)ly.Tag;
            long nx = ((JsonNumber)tx.info[jsonKey]).ToInt64();
            long ny = ((JsonNumber)ty.info[jsonKey]).ToInt64();
            return nx.CompareTo(ny);
        }
    }
}
