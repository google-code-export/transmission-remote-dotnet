using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionRemoteDotnet.Commmands
{
    public class NoCommand : ICommand
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
