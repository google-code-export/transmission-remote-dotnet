/* This factory class is responsible for dispatching JSON requests and
 * torrent uploads, and also creating an object using the command design
 * pattern which contains the logic for updating the UI. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.IO;
using TransmissionClientNew.Commmands;

namespace TransmissionClientNew
{
    public class CommandFactory
    {
        public static TransmissionCommand UploadFile(string file)
        {
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
            if (!Program.Connected || file == null || !file.EndsWith(".torrent", StringComparison.CurrentCultureIgnoreCase) || !File.Exists(file))
            {
                return null;
            }
            try
            {
                using (TransmissionWebClient wc = new TransmissionWebClient())
                {
                    wc.UploadFile(settings.URL + "upload?paused=" + (settings.startPaused ? "true" : "false"), file);
                }
                if (!Program.form.RefreshWorker.IsBusy)
                {
                    Program.form.RefreshWorker.RunWorkerAsync(false);
                }
            }
            catch (Exception ex)
            {
                return new ErrorCommand(ex);
            }
            return null;
        }

        public static TransmissionCommand Request(JsonObject data)
        {
            string str_response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LocalSettingsSingleton.Instance.URL + "rpc");
                TransmissionWebClient.SetupWebRequest(request);
                request.Method = "POST";
                request.ContentType = "application/json";
                string json = data.ToString();
                request.ContentLength = json.Length;
                StreamWriter stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(json);
                stOut.Close();
                WebResponse webResponse = request.GetResponse();
                StreamReader stIn = new StreamReader(webResponse.GetResponseStream());
                str_response = stIn.ReadToEnd();
                stIn.Close();
                JsonObject jsonResponse = (JsonObject)JsonConvert.Import(str_response);
                if (jsonResponse["result"].ToString() != "success")
                {
                    return new ErrorCommand("Unsuccessful request", str_response);
                }
                switch (((JsonNumber)jsonResponse[ProtocolConstants.KEY_TAG]).ToInt16())
                {
                    case (short)ResponseTag.SessionGet:
                        return new SessionCommand(jsonResponse, webResponse.Headers);
                    case (short)ResponseTag.TorrentGet:
                        return new TorrentGetCommand(jsonResponse, false);
                    case (short)ResponseTag.TorrentGetLoop:
                        return new TorrentGetCommand(jsonResponse, true);
                    case (short)ResponseTag.UpdateFiles:
                        return new UpdateFilesCommand(jsonResponse);
                    case (short)ResponseTag.UpdatePriorities:
                        return new UpdatePrioritiesCommand(jsonResponse);
                    case (short)ResponseTag.DoNothing:
                        return new NoCommand();
                }
            }
            catch (InvalidCastException)
            {
                return new ErrorCommand("Unable to parse the following response", str_response != null ? str_response : "Null");
            }
            catch (Exception ex)
            {
                return new ErrorCommand(ex);
            }
            return new ErrorCommand("Unknown response tag", str_response);
        }
    }
}