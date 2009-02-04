using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;
using System.IO;

namespace TransmissionRemoteDotnet
{
    public class Requests
    {
        public static JsonObject SessionGet()
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_SESSIONGET);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.SessionGet);
            return request;
        }

        public static JsonObject Generic(string method, JsonArray ids)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, method);
            JsonObject arguments = new JsonObject();
            if (ids != null)
            {
                arguments.Put(ProtocolConstants.KEY_IDS, ids);
            }
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            return request;
        }

        public static JsonObject RemoveTorrent(JsonArray ids, bool delete)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTREMOVE);
            JsonObject arguments = new JsonObject();
            if (delete && Program.DaemonDescriptor.Revision >= 7331)
            {
                arguments.Put(ProtocolConstants.FIELD_DELETELOCALDATA, true);
            }
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            return request;
        }

        public static JsonObject Files(int id)
        {
            return Files(id, false);
        }

        private static JsonObject Files(int id, bool includePriorities)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTGET);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.UpdateFiles);
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            ids.Push(id);
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            JsonArray fields = new JsonArray();
            fields.Put(ProtocolConstants.FIELD_FILES);
            fields.Put(ProtocolConstants.FIELD_ID);
            if (includePriorities)
            {
                fields.Put(ProtocolConstants.FIELD_PRIORITIES);
                fields.Put(ProtocolConstants.FIELD_WANTED);
            }
            arguments.Put(ProtocolConstants.KEY_FIELDS, fields);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }

        public static JsonObject FilesAndPriorities(int id)
        {
            return Files(id, true);
        }

        public static JsonObject TorrentAddByFile(string file, bool deleteAfter)
        {
            FileStream inFile = new FileStream(file,
                    FileMode.Open,
                    FileAccess.Read);
            byte[] binaryData = new Byte[inFile.Length];
            long bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
            inFile.Close();
            JsonObject request = new JsonObject();
            JsonObject arguments = new JsonObject();
            arguments.Put(ProtocolConstants.FIELD_METAINFO, Convert.ToBase64String(binaryData, 0, binaryData.Length));
            arguments.Put(ProtocolConstants.FIELD_PAUSED, LocalSettingsSingleton.Instance.startPaused);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTADD);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            if (deleteAfter && File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
            return request;
        }

        public static JsonObject TorrentAddByUrl(string url)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTADD);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            JsonObject arguments = new JsonObject();
            arguments.Put(ProtocolConstants.FIELD_FILENAME, url);
            arguments.Put(ProtocolConstants.FIELD_PAUSED, LocalSettingsSingleton.Instance.startPaused);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }
        
        public static JsonObject SessionStats()
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_SESSIONSTATS);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.SessionStats);
            return request;
        }

        public static JsonObject TorrentGet()
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTGET);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.TorrentGet);
            JsonObject arguments = new JsonObject();
            JsonArray fields = new JsonArray(new string[]{
                ProtocolConstants.FIELD_ID,
                ProtocolConstants.FIELD_ADDEDDATE,
                ProtocolConstants.FIELD_HAVEVALID,
                ProtocolConstants.FIELD_HAVEUNCHECKED,
                ProtocolConstants.FIELD_ETA,
                ProtocolConstants.FIELD_RECHECKPROGRESS,
                ProtocolConstants.FIELD_LEECHERS,
                ProtocolConstants.FIELD_RATEDOWNLOAD,
                ProtocolConstants.FIELD_RATEUPLOAD,
                ProtocolConstants.FIELD_SEEDERS,
                ProtocolConstants.FIELD_TOTALSIZE,
                ProtocolConstants.FIELD_UPLOADEDEVER,
                ProtocolConstants.FIELD_STATUS,
                ProtocolConstants.FIELD_LEFTUNTILDONE,
                ProtocolConstants.FIELD_ANNOUNCEURL,
                ProtocolConstants.FIELD_DOWNLOADLIMIT,
                ProtocolConstants.FIELD_DOWNLOADLIMITMODE,
                ProtocolConstants.FIELD_UPLOADLIMIT,
                ProtocolConstants.FIELD_UPLOADLIMITMODE,
                ProtocolConstants.FIELD_NAME,
                ProtocolConstants.FIELD_ERRORSTRING,
                ProtocolConstants.FIELD_PEERS,
                ProtocolConstants.FIELD_PEERSGETTINGFROMUS,
                ProtocolConstants.FIELD_PEERSSENDINGTOUS,
                "sizeWhenDone","swarmSpeed", "isPrivate",
                "comment","creator","dateCreated",
                "hashString", "error","trackers",
                "peersKnown"});
            arguments.Put(ProtocolConstants.KEY_FIELDS, fields);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }
    }
}
