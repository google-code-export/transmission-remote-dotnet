using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    class SessionStatsCommand : ICommand
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
        }
    }
}