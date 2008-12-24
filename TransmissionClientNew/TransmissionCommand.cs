using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemoteDotnet
{
    public enum ResponseTag
    {
        SessionGet, TorrentGet, DoNothing, UpdateFiles
    }

    public interface TransmissionCommand
    {
        void Execute();
    }
}
