using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemoteDotnet.Commmands
{
    public class NoCommand : TransmissionCommand
    {
        public NoCommand()
        {
            Program.DaemonDescriptor.ResetFailCount();
        }

        public void Execute()
        {
        }
    }
}
