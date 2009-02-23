using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class IPv6StringComparer : IComparer
    {
        private const char IPV6_DELIMITER = ':';

        int IComparer.Compare(object x, object y)
        {
            IPAddress ix = IPAddress.Parse((string)x);
            IPAddress iy = IPAddress.Parse((string)y);
            byte[] bx = ix.GetAddressBytes();
            byte[] by = iy.GetAddressBytes();
            for (int i = 0; i < bx.Length; i++)
            {
                if (!bx[i].Equals(by[i]))
                    return bx[i].CompareTo(by[i]);
            }
            return 0;
        }
    }
}