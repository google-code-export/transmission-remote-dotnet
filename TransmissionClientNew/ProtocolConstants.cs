using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemoteDotnet
{
    public class ProtocolConstants
    {
        public static readonly short
            STATUS_WAITING_TO_CHECK = 1,
            STATUS_CHECKING = 2,
            STATUS_DOWNLOADING = 4,
            STATUS_SEEDING = 8,
            STATUS_STOPPED = 16;

        public static readonly string
            KEY_TAG = "tag",
            KEY_METHOD = "method",
            KEY_IDS = "ids",
            KEY_ARGUMENTS = "arguments",
            KEY_FIELDS = "fields",
            KEY_TORRENTS = "torrents",
            METHOD_TORRENTGET = "torrent-get",
            METHOD_TORRENTSTART = "torrent-start",
            METHOD_TORRENTSTOP = "torrent-stop",
            FIELD_LEFTUNTILDONE = "leftUntilDone",
            FIELD_COMMENT = "comment",
            FIELD_NAME = "name",
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
            FIELD_PEERS = "peers";
    }
}
