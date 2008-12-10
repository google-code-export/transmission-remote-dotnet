using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock.Json;

namespace TransmissionClientNew
{
    class Toolbox
    {
        private const int stripe_offset = 15;

        public static void StripeListView(ListView list)
        {
            Color window = SystemColors.Window;
            /* Check for weird window backgrounds */
            if (window.R >= stripe_offset && window.G >= stripe_offset && window.B >= stripe_offset)
            {
                foreach (ListViewItem item in list.Items)
                {
                    item.BackColor = item.Index % 2 == 1 ?
                        Color.FromArgb(window.R - stripe_offset,
                            window.G - stripe_offset,
                            window.B - stripe_offset)
                        : window;
                }
            }
        }

        public static DateTime DateFromEpoch(double e)
        {
            DateTime epoch = new DateTime(1970, 1, 1);
            return epoch.Add(TimeSpan.FromSeconds(e));
        }

        public static double CalcPercentage(long x, long total)
        {
            if (total > 0)
            {
                return Math.Round((x / (double)total) * 100, 2);
            }
            else
            {
                return 100;
            }
        }

        public static decimal CalcRatio(long upload_total, long download_total)
        {
            if (download_total <= 0 || upload_total <= 0)
            {
                return -1;
            }
            else
            {
                return Math.Round((decimal)upload_total / download_total, 3);
            }
        }

        public static string GetFileSize(long Bytes)
        {
            if (Bytes >= 1073741824)
            {
                Decimal size = Decimal.Divide(Bytes, 1073741824);
                return String.Format("{0:##.##} GB", size);
            }
            else if (Bytes >= 1048576)
            {
                Decimal size = Decimal.Divide(Bytes, 1048576);
                return String.Format("{0:##.##} MB", size);
            }
            else if (Bytes >= 1024)
            {
                Decimal size = Decimal.Divide(Bytes, 1024);
                return String.Format("{0:##.##} KB", size);
            }
            else if (Bytes > 0 & Bytes < 1024)
            {
                Decimal size = Bytes;
                return String.Format("{0:##.##} B", size);
            }
            else
            {
                return "0 B";
            }
        }

        public static void SelectAll(ListView lv)
        {
            foreach (ListViewItem item in lv.Items)
            {
                item.Selected = true;
            }
        }
    }
}
