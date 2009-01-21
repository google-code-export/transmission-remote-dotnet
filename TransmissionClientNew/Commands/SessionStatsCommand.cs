using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    class SessionStatsCommand : TransmissionCommand
    {
        public SessionStatsCommand(JsonObject response)
        {
            Program.sessionStats = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            Program.ResetFailCount();
        }

        public void Execute()
        {
            /*
             * there is a bug: http://trac.transmissionbt.com/ticket/1655 */
            //JsonObject stats = (JsonObject)arguments[ProtocolConstants.METHOD_SESSIONSTATS];
        }
    }
}