using System;
using System.Collections.Generic;
using System.Collections;
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
            long nx = Toolbox.ToLong(tx.Info[jsonKey]);
            long ny = Toolbox.ToLong(ty.Info[jsonKey]);
            return nx.CompareTo(ny);
        }
    }
}
