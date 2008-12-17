using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;
using System.Net;

namespace TransmissionRemoteDotnet.Commmands
{
    public class SessionCommand : TransmissionCommand
    {
        public SessionCommand(JsonObject response, WebHeaderCollection headers)
        {
            /* I'm not exactly sure if the version numbers here are correct
             * but for the purposes of what it's used for these heuristics
             * work fine at the moment. I'll make use of the content of the
             * version response after the next release. */
            if (response.Contains("version"))
            {
                Program.transmissionVersion = 1.41;
            }
            else if (headers.Get("Server") != null)
            {
                Program.transmissionVersion = 1.40;
            }
            else
            {
                Program.transmissionVersion = 1.39;
            }
            Program.sessionData = response;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            if (!Program.Connected)
            {

                Program.Connected = true;
                if (!Program.form.refreshWorker.IsBusy)
                {
                    Program.form.refreshWorker.RunWorkerAsync(true);
                }
                if (Program.uploadArgs != null)
                {
                    Program.form.CreateUploadWorker().RunWorkerAsync(Program.uploadArgs);
                    Program.uploadArgs = null;
                }
            }
        }
    }
}
