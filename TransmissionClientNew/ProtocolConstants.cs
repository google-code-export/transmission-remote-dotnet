using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionClientNew
{
    public class ProtocolConstants
    {
        public static readonly string KEY_TAG = "tag";
        public static readonly string KEY_METHOD = "method";
        public static readonly string KEY_IDS = "ids";
        public static readonly string KEY_ARGUMENTS = "arguments";
        public static readonly string KEY_FIELDS = "fields";
        public static readonly string METHOD_TORRENTGET = "torrent-get";
        public static readonly string FIELD_ETA = "eta";
        public static readonly string FIELD_RATEDOWNLOAD = "rateDownload";
        public static readonly string FIELD_RATEUPLOAD = "rateUpload";
        public static readonly string FIELD_TOTALSIZE = "totalSize";
        public static readonly string FIELD_HAVEVALID = "haveValid";
        public static readonly string FIELD_UPLOADEDEVER = "uploadedEver";
        public static readonly string FIELD_LEECHERS = "leechers";
        public static readonly string FIELD_SEEDERS = "seeders";
        public static readonly string FIELD_ADDEDDATE = "addedDate";
        public static readonly string FIELD_ID = "id";
        public static readonly string FIELD_FILES = "files";
        public static readonly string FIELD_PRIORITIES = "priorities";
        public static readonly string FIELD_WANTED = "wanted";
        public static readonly string FIELD_DOWNLOADLIMIT = "downloadLimit";
        public static readonly string FIELD_DOWNLOADLIMITMODE = "downloadLimitMode";
        public static readonly string FIELD_UPLOADLIMIT = "uploadLimit";
        public static readonly string FIELD_UPLOADLIMITMODE = "uploadLimitMode";
    }
}
