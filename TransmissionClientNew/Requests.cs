using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;
using System.IO;

namespace TransmissionClientNew
{
    public class Requests
    {
        public static JsonObject SessionGet()
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, "session-get");
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

        public static JsonObject Files(JsonArray ids)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTGET);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.UpdateFiles);
            JsonObject arguments = new JsonObject();
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            JsonArray fields = new JsonArray();
            fields.Put(ProtocolConstants.FIELD_FILES);
            fields.Put(ProtocolConstants.FIELD_ID);
            arguments.Put(ProtocolConstants.KEY_FIELDS, fields);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }
        
        public static JsonObject Priorities(int id)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTGET);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.UpdatePriorities);
            JsonObject arguments = new JsonObject();
            JsonArray ids = new JsonArray();
            ids.Put(id);
            arguments.Put(ProtocolConstants.KEY_IDS, ids);
            JsonArray fields = new JsonArray();
            fields.Put(ProtocolConstants.FIELD_FILES);
            fields.Put(ProtocolConstants.FIELD_ID);
            fields.Put(ProtocolConstants.FIELD_PRIORITIES);
            fields.Put(ProtocolConstants.FIELD_WANTED);
            fields.Put(ProtocolConstants.FIELD_DOWNLOADLIMIT);
            fields.Put(ProtocolConstants.FIELD_DOWNLOADLIMITMODE);
            fields.Put(ProtocolConstants.FIELD_UPLOADLIMIT);
            fields.Put(ProtocolConstants.FIELD_UPLOADLIMITMODE);
            arguments.Put(ProtocolConstants.KEY_FIELDS, fields);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }

        public static JsonObject TorrentGet(Boolean beginLoop)
        {
            JsonObject request = new JsonObject();
            request.Put(ProtocolConstants.KEY_METHOD, ProtocolConstants.METHOD_TORRENTGET);
            request.Put(ProtocolConstants.KEY_TAG, beginLoop ? (int)ResponseTag.TorrentGetLoop : (int)ResponseTag.TorrentGet);
            JsonObject arguments = new JsonObject();
            JsonArray fields = new JsonArray(new string[]{
                ProtocolConstants.FIELD_ID,
                ProtocolConstants.FIELD_ADDEDDATE,
                ProtocolConstants.FIELD_HAVEVALID,
                ProtocolConstants.FIELD_ETA,
                ProtocolConstants.FIELD_HAVEVALID,
                ProtocolConstants.FIELD_ID,
                ProtocolConstants.FIELD_LEECHERS,
                ProtocolConstants.FIELD_RATEDOWNLOAD,
                ProtocolConstants.FIELD_RATEUPLOAD,
                ProtocolConstants.FIELD_SEEDERS,
                ProtocolConstants.FIELD_TOTALSIZE,
                ProtocolConstants.FIELD_UPLOADEDEVER,
                ProtocolConstants.FIELD_STATUS,
                ProtocolConstants.FIELD_LEFTUNTILDONE,
                ProtocolConstants.FIELD_ANNOUNCEURL,
                "sizeWhenDone","swarmSpeed",
                "isPrivate","comment","creator","dateCreated",
                "hashString","haveUnchecked","peers",
                "error","errorString","name",
                "peersGettingFromUs","peersKnown","peersSendingToUs"});
            arguments.Put(ProtocolConstants.KEY_FIELDS, fields);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            return request;
        }
    }
}
