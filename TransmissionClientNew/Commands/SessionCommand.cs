using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;
using System.Net;

namespace TransmissionClientNew.Commmands
{
    class SessionCommand : TransmissionCommand
    {
        public SessionCommand(JsonObject response, WebHeaderCollection headers)
        {
            /* The absence of a server header suggests a version < 1.40, so
             * remember that preauthenticating is necessary. */
            Program.oldTransmissionVersion = (headers.Get("Server") == null);
            Program.sessionData = response;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            if (!Program.Connected)
            {
                Program.Connected = true;
                Program.form.RefreshWorker.RunWorkerAsync(true);
                if (Program.uploadArgs != null)
                {
                    Program.form.CreateUploadWorker().RunWorkerAsync(Program.uploadArgs);
                    Program.uploadArgs = null;
                }
            }
        }
    }
}
