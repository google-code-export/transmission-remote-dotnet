using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock.Json;
using System.Net;
using System.IO;

namespace TransmissionRemoteDotnet
{
    class Toolbox
    {
        private const int STRIPE_OFFSET = 15;

        public static void CopyListViewToClipboard(ListView listView)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                sb.Append(listView.Columns[i].Text);
                if (i != listView.Columns.Count - 1)
                {
                    sb.Append(',');
                }
                else
                {
                    sb.Append("\r\n");
                }
            }
            lock (listView)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        System.Windows.Forms.ListViewItem.ListViewSubItem si = item.SubItems[i];
                        sb.Append(si.Text);
                        if (i != item.SubItems.Count - 1)
                        {
                            sb.Append(',');
                        }
                        else
                        {
                            sb.Append("\r\n");
                        }
                    }
                }
            }
            Clipboard.SetText(sb.ToString());
        }

        public static Exception UploadFile(string file, bool deleteAfter)
        {
            return UploadFile(file, deleteAfter, null);
        }

        public static Exception UploadFile(string file, bool deleteAfter, UploadProgressChangedEventHandler progressHandler)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            Exception exception = null;
            if (!Program.Connected || file == null || !File.Exists(file))
            {
                return null;
            }
            try
            {
                using (TransmissionWebClient wc = new TransmissionWebClient())
                {
                    if (progressHandler != null)
                    {
                        wc.UploadProgressChanged += progressHandler;
                    }
                    wc.UploadFile(settings.URL + "upload?paused=" + (settings.startPaused ? "true" : "false"), file);
                }
                Program.form.RefreshIfNotRefreshing();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            if (deleteAfter && File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
            return exception;
        }

        public static void StripeListView(ListView list)
        {
            Color window = SystemColors.Window;
            lock (list)
            {
                list.SuspendLayout();
                foreach (ListViewItem item in list.Items)
                {
                    item.BackColor = item.Index % 2 == 1 ?
                        Color.FromArgb(window.R - STRIPE_OFFSET,
                            window.G - STRIPE_OFFSET,
                            window.B - STRIPE_OFFSET)
                        : window;
                }
                list.ResumeLayout();
            }
        }

        public static DateTime DateFromEpoch(double e)
        {
            DateTime epoch = new DateTime(1970, 1, 1);
            return epoch.Add(TimeSpan.FromSeconds(e));
        }

        public static decimal CalcPercentage(long x, long total)
        {
            if (total > 0)
            {
                return Math.Round((x / (decimal)total) * 100, 2);
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
            lock (lv)
            {
                lv.SuspendLayout();
                foreach (ListViewItem item in lv.Items)
                {
                    item.Selected = true;
                }
                lv.ResumeLayout();
            }
        }
    }
}
