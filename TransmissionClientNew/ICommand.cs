using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionRemoteDotnet
{
    public enum ResponseTag
    {
        SessionGet, SessionStats, TorrentGet, DoNothing, UpdateFiles, PortTest
    }

    public interface ICommand
    {
        void Execute();
    }
}
