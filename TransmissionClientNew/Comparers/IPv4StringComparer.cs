using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Jayrock.Json;

namespace TransmissionRemoteDotnet.Comparers
{
    public class IPv4StringComparer : IComparer
    {
        private const char IPV4_DELIMITER = '.';

        int IComparer.Compare(object x, object y)
        {
            string[] qx = ((string)x).Split(IPV4_DELIMITER);
            string[] qy = ((string)y).Split(IPV4_DELIMITER);
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
