using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    class SessionStatsCommand : TransmissionCommand
    {
        private JsonObject stats;

        public SessionStatsCommand(JsonObject response)
        {
            this.stats = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            Program.DaemonDescriptor.ResetFailCount();
        }

        public void Execute()
        {
            StatsDialog.StaticUpdateStats(this.stats);
            //there is a bug: http://trac.transmissionbt.com/ticket/1655
        }
    }
}