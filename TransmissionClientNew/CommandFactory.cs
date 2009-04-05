/* This factory class is responsible for dispatching JSON requests and
 * torrent uploads, and also creating an object using the command design
 * pattern which contains the logic for updating the UI. */

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.IO;
using TransmissionRemoteDotnet.Commmands;

namespace TransmissionRemoteDotnet
{
    public class CommandFactory
    {
        public static TransmissionCommand Request(JsonObject data)
        {
            string str_response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LocalSettingsSingleton.Instance.RpcUrl);
                TransmissionWebClient.SetupWebRequest(request, true);
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
                if ((string)jsonResponse["result"] != "success")
                {
                    return new ErrorCommand(OtherStrings.UnsuccessfulRequest, (string)jsonResponse["result"], true);
                }
                switch (Toolbox.ToShort(jsonResponse[ProtocolConstants.KEY_TAG]))
                {
                    case (short)ResponseTag.TorrentGet:
                        return new TorrentGetCommand(jsonResponse);
                    case (short)ResponseTag.SessionGet:
                        return new SessionCommand(jsonResponse, webResponse.Headers);
                    case (short)ResponseTag.SessionStats:
                        return new SessionStatsCommand(jsonResponse);
                    case (short)ResponseTag.UpdateFiles:
                        return new UpdateFilesCommand(jsonResponse);
                    case (short)ResponseTag.DoNothing:
                        return new NoCommand();
                }
            }
            catch (InvalidCastException)
            {
                return new ErrorCommand(OtherStrings.UnableToParse, str_response != null ? str_response : "Null", false);
            }
            catch (JsonException ex)
            {
                return new ErrorCommand(String.Format("{0} ({1})", OtherStrings.UnableToParse, ex.GetType()), str_response, false);
            }
            catch (Exception ex)
            {
                return new ErrorCommand(ex, false);
            }
            return new ErrorCommand("Unknown response tag", str_response, false);
        }
    }
}