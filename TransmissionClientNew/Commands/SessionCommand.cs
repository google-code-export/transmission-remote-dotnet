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
        public const double DEFAULT_T_VERSION = 1.41;

        private void ParseVersionAndRevisionResponse(string str)
        {
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if ((str[i] < (int)'0' || str[i] > (int)'9') && str[i] != (int)'.')
                    {
                        Program.transmissionVersion = Double.Parse(str.Substring(0, i));
                        break;
                    }
                }
            }
            catch
            {
                Program.transmissionVersion = DEFAULT_T_VERSION;
            }
            try
            {
                int spaceIndex = str.IndexOf(' ');
                Program.transmissionRevision = Int32.Parse(str.Substring(spaceIndex + 2, str.Length - spaceIndex - 3));
            }
            catch
            {
                Program.transmissionRevision = -1;
            }
        }

        public SessionCommand(JsonObject response, WebHeaderCollection headers)
        {
            /* I'm not exactly sure if the version numbers here are correct
             * but for the purposes of what it's used for these heuristics
             * work fine at the moment. */
            JsonObject arguments = (JsonObject)response["arguments"];
            if (arguments.Contains("version"))
            {
                ParseVersionAndRevisionResponse((string)arguments["version"]);
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
                Program.form.RefreshIfNotRefreshing();
                if (Program.uploadArgs != null)
                {
                    Program.form.CreateUploadWorker().RunWorkerAsync(Program.uploadArgs);
                    Program.uploadArgs = null;
                }
            }
        }
    }
}
