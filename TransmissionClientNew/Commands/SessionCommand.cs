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

        private void ParseVersionAndRevisionResponse(string str, TransmissionDaemonDescriptor descriptor)
        {
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if ((str[i] < (int)'0' || str[i] > (int)'9') && str[i] != (int)'.')
                    {
                        descriptor.Version = Double.Parse(str.Substring(0, i));
                        break;
                    }
                }
            }
            catch { }
            try
            {
                int spaceIndex = str.IndexOf(' ');
                descriptor.Revision = Int32.Parse(str.Substring(spaceIndex + 2, str.Length - spaceIndex - 3));
            }
            catch { }
        }

        public SessionCommand(JsonObject response, WebHeaderCollection headers)
        {
            /* I'm not exactly sure if the version numbers here are correct
             * but for the purposes of what it's used for these heuristics
             * work fine at the moment. */
            TransmissionDaemonDescriptor descriptor = new TransmissionDaemonDescriptor();
            JsonObject arguments = (JsonObject)response["arguments"];
            if (arguments.Contains("version"))
            {
                ParseVersionAndRevisionResponse((string)arguments["version"], descriptor);
            }
            else if (headers.Get("Server") != null)
            {
                descriptor.Version = 1.40;
            }
            else
            {
                descriptor.Version = 1.39;
            }
            if (arguments.Contains("rpc-version"))
                descriptor.RpcVersion = ((JsonNumber)arguments["rpc-version"]).ToInt32();
            if (arguments.Contains("rpc-version-minimum"))
                descriptor.RpcVersionMin = ((JsonNumber)arguments["rpc-version"]).ToInt32();
            descriptor.SessionData = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            Program.DaemonDescriptor = descriptor;
        }

        public void Execute()
        {
            if (!Program.Connected)
            {
                TransmissionDaemonDescriptor descriptor = Program.DaemonDescriptor;
                Program.Log("(Info) Connected to version", String.Format("Version={0}, Revision={1}, TransmissionRpcVersion={2}, TransmissionRpcVersionMinimum={3}", descriptor.Version, descriptor.Revision, descriptor.RpcVersion, descriptor.RpcVersionMin));
                Program.Connected = true;
                Program.Form.RefreshIfNotRefreshing();
                if (Program.UploadArgs != null)
                {
                    Program.Form.CreateUploadWorker().RunWorkerAsync(Program.UploadArgs);
                    Program.UploadArgs = null;
                }
            }
        }
    }
}
