using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionClientNew.Commmands
{
    class NoCommand : TransmissionCommand
    {
        public NoCommand()
        {
            Program.ResetFailCount();
        }

        public void Execute()
        {
        }
    }
}
