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

﻿using System;
using System.Collections.Generic;
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
            METHOD_TORRENTSET = "torrent-set",
            METHOD_SESSIONGET = "session-get",
            METHOD_SESSIONSET = "session-set",
            METHOD_TORRENTREMOVE = "torrent-remove",
            METHOD_TORRENTVERIFY = "torrent-verify",
            METHOD_TORRENTADD = "torrent-add",
            METHOD_TORRENTREANNOUNCE = "torrent-reannounce",
            METHOD_SESSIONSTATS = "session-stats",
            METHOD_BLOCKLISTUPDATE = "blocklist-update",
            METHOD_PORT_TEST = "port-test",
            FIELD_PIECES = "pieces",
            FIELD_PIECECOUNT = "pieceCount",
            FIELD_PEERSSENDINGTOUS = "peersSendingToUs",
            FIELD_PEERSGETTINGFROMUS = "peersGettingFromUs",
            FIELD_FLAGSTR = "flagStr",
            FIELD_HONORSSESSIONLIMITS = "honorsSessionLimits",
            FIELD_METAINFO = "metainfo",
            FIELD_CLIENTNAME = "clientName",
            FIELD_HAVEUNCHECKED = "haveUnchecked",
            FIELD_LEFTUNTILDONE = "leftUntilDone",
            FIELD_COMMENT = "comment",
            FIELD_NAME = "name",
            FIELD_RATETOCLIENT = "rateToClient",
            FIELD_RATETOPEER = "rateToPeer",
            FIELD_ERRORSTRING = "errorString",
            FIELD_PROGRESS = "progress",
            FIELD_FILENAME = "filename",
            FIELD_PAUSED = "paused",
            FIELD_ANNOUNCEURL = "announceURL",
            FIELD_ETA = "eta",
            FIELD_STATUS = "status",
            FIELD_BANDWIDTHPRIORITY = "bandwidthPriority",
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
            FIELD_TRACKERS = "trackers",
            FIELD_PEERS = "peers",
            FIELD_PEERLIMIT = "peer-limit",
            FIELD_LENGTH = "length",
            FIELD_BYTESCOMPLETED = "bytesCompleted",
            FIELD_DELETELOCALDATA = "delete-local-data",
            FIELD_MAXCONNECTEDPEERS = "maxConnectedPeers",
            FIELD_CREATOR = "creator",
            FIELD_SWARMSPEED = "swarmSpeed",
            FIELD_DATECREATED = "dateCreated",
            FIELD_HASHSTRING = "hashString",
            FIELD_DOWNLOADDIR = "downloadDir",
            FIELD_RECHECKPROGRESS = "recheckProgress",
            FIELD_SEEDRATIOLIMIT = "seedRatioLimit",
            FIELD_SEEDRATIOMODE = "seedRatioMode",
            FIELD_SEEDRATIOLIMITED = "seedRatioLimited", // session-set/get
            VALUE_RECENTLY_ACTIVE = "recently-active",
            /* BEGIN CONFUSION */
            FIELD_DOWNLOADLIMITMODE = "downloadLimitMode", // DEPRECATED
            FIELD_UPLOADLIMITMODE = "uploadLimitMode", // DEPRECATED
            FIELD_SPEEDLIMITDOWNENABLED = "speed-limit-down-enabled", // ALSO DEPRECATED
            FIELD_SPEEDLIMITUPENABLED = "speed-limit-up-enabled", // ALSO DEPRECATED
            FIELD_SPEEDLIMITDOWN = "speed-limit-down", // ALSO DEPRECATED
            FIELD_SPEEDLIMITUP = "speed-limit-up", // ALSO DEPRECATED
            FIELD_UPLOADLIMITED = "uploadLimited",
            FIELD_DOWNLOADLIMITED = "downloadLimited",
            FIELD_UPLOADLIMIT = "uploadLimit",
            FIELD_DOWNLOADLIMIT = "downloadLimit",
            FIELD_PORT_IS_OPEN = "port-is-open";
    }
}
