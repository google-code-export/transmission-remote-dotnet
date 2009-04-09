using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    class PortTestCommand : ICommand
    {
        private bool port_is_open;

        public PortTestCommand(JsonObject response)
        {
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            this.port_is_open = Toolbox.ToBool(arguments[ProtocolConstants.FIELD_PORT_IS_OPEN]);
        }

        public void Execute()
        {
            MessageBox.Show(port_is_open ? OtherStrings.PortIsOpen : OtherStrings.PortIsClosed, OtherStrings.PortTestResult, MessageBoxButtons.OK, port_is_open ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
