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
            string fullPath = String.Format("{0}/{1}", t.DownloadDir, t.Name);
            Process.Start(
                // plink path
                LocalSettingsSingleton.Instance.PlinkPath,
                // arguments
                String.Format("\"{0}\" \"{1}\"",
                    LocalSettingsSingleton.Instance.Host,
                    String.Format(LocalSettingsSingleton.Instance.PlinkCmd, fullPath)
                )
            );
        }
    }
}