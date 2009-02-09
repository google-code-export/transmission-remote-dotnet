using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemoteDotnet
{
    public class ArgumentsReceivedEventArgs : EventArgs
    {
        public String[] Args { get; set; }
    }
}
