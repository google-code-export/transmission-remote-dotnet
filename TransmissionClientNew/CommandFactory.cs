// transmission-remote-dotnet
// http://code.google.com/p/transmission-remote-dotnet/
// Copyright (C) 2009 Alan F
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

﻿/* This factory class is responsible for dispatching JSON requests and
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
        public static ICommand Request(JsonObject data)
        {
            return Request(data, true);
        }

        public static ICommand Request(JsonObject data, bool allowRecursion)
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
                    case (short)ResponseTag.PortTest:
                        return new PortTestCommand(jsonResponse);
                    case (short)ResponseTag.UpdateBlocklist:
                        return new UpdateBlocklistCommand(jsonResponse);
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
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Conflict && allowRecursion)
                {
                    Stream stream = ex.Response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    string errorStr = reader.ReadToEnd();
                    reader.Close();
                    TransmissionWebClient.X_transmission_session_id = errorStr.Substring(errorStr.IndexOf("X-Transmission-Session-Id") + 27, 48);
                    return Request(data, false);
                }
                else
                {
                    return new ErrorCommand(ex, false);
                }
            }
            catch (Exception ex)
            {
                return new ErrorCommand(ex, false);
            }
            return new ErrorCommand("Unknown response tag", str_response, false);
        }
    }
}