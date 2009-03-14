using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    class PlinkCmd
    {
        public static void Start(Torrent t)
        {
            Process.Start(
                // plink path
                LocalSettingsSingleton.Instance.PlinkPath,
                // arguments
                String.Format(
                    "\"{0}\" \"{1}\"",
                    LocalSettingsSingleton.Instance.Host,
                    String.Format(
                        LocalSettingsSingleton.Instance.PlinkCmd.Replace("$DATA", "\\\"{0}\\\""),
                        String.Format("{0}{1}{2}", t.DownloadDir, !t.DownloadDir.EndsWith("/") ? "/" : null, t.Name))
                )
            );
        }
    }
}