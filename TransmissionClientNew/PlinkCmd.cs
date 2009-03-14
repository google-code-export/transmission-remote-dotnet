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
        private Torrent t;

        public PlinkCmd(Torrent t)
        {
            this.t = t;
        }

        public void Start()
        {
            Process.Start(LocalSettingsSingleton.Instance.PlinkPath, String.Format("\"{0}\" \"{1}\" \"{2}\"", LocalSettingsSingleton.Instance.Host, LocalSettingsSingleton.Instance.PlinkCmd, String.Format("{0}/{1}", this.t.DownloadDir, this.t.Name)));
        }
    }
}