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

        private double ParseVersionString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] < (int)'0' || str[i] > (int)'9') && str[i] != (int)'.')
                {
                    return Double.Parse(str.Substring(0, i));
                }
            }
            throw new FormatException("Unable to parse: " + str);
        }

        public SessionCommand(JsonObject response, WebHeaderCollection headers)
        {
            /* I'm not exactly sure if the version numbers here are correct
             * but for the purposes of what it's used for these heuristics
             * work fine at the moment. */
            JsonObject arguments = (JsonObject)response["arguments"];
            if (arguments.Contains("version"))
            {
                try
                {
                    Program.transmissionVersion = ParseVersionString((string)arguments["version"]);
                }
                catch
                {
                    Program.transmissionVersion = DEFAULT_T_VERSION;
                }
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
