using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemoteDotnet
{
    public class ProtocolConstants
    {
        public const short
            STATUS_WAITING_TO_CHECK = 1,
            STATUS_CHECKING = 2,
            STATUS_DOWNLOADING = 4,
            STATUS_SEEDING = 8,
            STATUS_STOPPED = 16;

        public const string
            KEY_TAG = "tag",
            KEY_METHOD = "method",
            KEY_IDS = "ids",
            KEY_ARGUMENTS = "arguments",
            KEY_FIELDS = "fields",
            KEY_TORRENTS = "torrents",
            METHOD_TORRENTGET = "torrent-get",
            METHOD_TORRENTSTART = "torrent-start",
            METHOD_TORRENTSTOP = "torrent-stop",
            METHOD_SESSIONGET = "session-get",
            METHOD_TORRENTREMOVE = "torrent-remove",
            METHOD_TORRENTVERIFY = "torrent-verify",
            FIELD_CLIENTNAME = "clientName",
            FIELD_HAVEUNCHECKED = "haveUnchecked",
            FIELD_LEFTUNTILDONE = "leftUntilDone",
            FIELD_COMMENT = "comment",
            FIELD_NAME = "name",
            FIELD_RATETOCLIENT = "rateToClient",
            FIELD_RATETOPEER = "rateToPeer",
            FIELD_ERRORSTRING = "errorString",
            FIELD_PROGRESS = "progress",
            FIELD_ANNOUNCEURL = "announceURL",
            FIELD_ETA = "eta",
            FIELD_STATUS = "status",
            FIELD_RATEDOWNLOAD = "rateDownload",
            FIELD_RATEUPLOAD = "rateUpload",
            FIELD_TOTALSIZE = "totalSize",
            FIELD_HAVEVALID = "haveValid",
            FIELD_UPLOADEDEVER = "uploadedEver",
            FIELD_LEECHERS = "leechers",
            FIELD_SEEDERS = "seeders",
            FIELD_ADDEDDATE = "addedDate",
            FIELD_ID = "id",
            FIELD_FILES = "files",
            FIELD_PRIORITIES = "priorities",
            FIELD_WANTED = "wanted",
            FIELD_DOWNLOADLIMIT = "downloadLimit",
            FIELD_DOWNLOADLIMITMODE = "downloadLimitMode",
            FIELD_UPLOADLIMIT = "uploadLimit",
            FIELD_UPLOADLIMITMODE = "uploadLimitMode",
            FIELD_TRACKERS = "trackers",
            FIELD_PEERS = "peers",
            FIELD_LENGTH = "length",
            FIELD_BYTESCOMPLETED = "bytesCompleted",
            FIELD_DELETELOCALDATA = "delete-local-data",
            FIELD_RECHECKPROGRESS = "recheckProgress";
    }
}
