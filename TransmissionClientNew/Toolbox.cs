using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    class Toolbox
    {
        private static readonly int STRIPE_OFFSET = 15;

        public static void StripeListView(ListView list)
        {
            list.SuspendLayout();
            Color window = SystemColors.Window;
            /* Check for weird window backgrounds */
            if (window.R >= STRIPE_OFFSET && window.G >= STRIPE_OFFSET && window.B >= STRIPE_OFFSET)
            {
                lock (list)
                {
                    foreach (ListViewItem item in list.Items)
                    {
                        item.BackColor = item.Index % 2 == 1 ?
                            Color.FromArgb(window.R - STRIPE_OFFSET,
                                window.G - STRIPE_OFFSET,
                                window.B - STRIPE_OFFSET)
                            : window;
                    }
                }
            }
            list.ResumeLayout();
        }

        public static string FormatPriority(JsonNumber n)
        {
            short s = n.ToInt16();
            if (s < 0)
            {
                return "Low";
            }
            else if (s > 0)
            {
                return "High";
            }
            else
            {
                return "Normal";
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

        public static string KbpsString(int rate)
        {
            return rate + " KB/s";
        }

        public static string FormatTimespanLong(TimeSpan span)
        {
            return String.Format("{0}d {1}h {2}m {3}s", new object[] { span.Days, span.Hours, span.Minutes, span.Seconds });
        }

        public static string GetSpeed(long bytes)
        {
            return GetFileSize(bytes) + "/s";
        }

        public static string GetFileSize(long bytes)
        {
            if (bytes >= 1073741824)
            {
                Decimal size = Decimal.Divide(bytes, 1073741824);
                return String.Format("{0:##.##} GB", size);
            }
            else if (bytes >= 1048576)
            {
                Decimal size = Decimal.Divide(bytes, 1048576);
                return String.Format("{0:##.##} MB", size);
            }
            else if (bytes >= 1024)
            {
                Decimal size = Decimal.Divide(bytes, 1024);
                return String.Format("{0:##.##} KB", size);
            }
            else if (bytes > 0 & bytes < 1024)
            {
                Decimal size = bytes;
                return String.Format("{0:##.##} B", size);
            }
            else
            {
                return "0 B";
            }
        }

        public static void SelectAll(ListView lv)
        {
            lv.SuspendLayout();
            lock (lv)
            {
                foreach (ListViewItem item in lv.Items)
                {
                    item.Selected = true;
                }
            }
            lv.ResumeLayout();
        }
    }
}
