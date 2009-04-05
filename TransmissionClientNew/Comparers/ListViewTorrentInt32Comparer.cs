using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class ListViewTorrentInt32Comparer : IComparer
    {
        string jsonKey;

        public ListViewTorrentInt32Comparer(string jsonKey)
        {
            this.jsonKey = jsonKey;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            Torrent tx = (Torrent)lx.Tag;
            Torrent ty = (Torrent)ly.Tag;
            int nx = Toolbox.ToInt(tx.Info[jsonKey]);
            int ny = Toolbox.ToInt(ty.Info[jsonKey]);
            return nx.CompareTo(ny);
        }
    }
}
