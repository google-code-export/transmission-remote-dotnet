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
        int IComparer.Compare(object x, object y)
        {
            ListViewItem lx = (ListViewItem)x;
            ListViewItem ly = (ListViewItem)y;
            IPAddress ix = (IPAddress)lx.SubItems[0].Tag;
            IPAddress iy = (IPAddress)ly.SubItems[0].Tag;
            if (ix.AddressFamily == iy.AddressFamily)
            {
                byte[] bx = ix.GetAddressBytes();
                byte[] by = iy.GetAddressBytes();
                for (int i = 0; i < bx.Length; i++)
                {
                    if (!bx[i].Equals(by[i]))
                        return bx[i].CompareTo(by[i]);
                }
                return 0;
            }
            else
            {
                return ix.AddressFamily.ToString().CompareTo(iy.AddressFamily.ToString());
            }
        }
    }
}
