using System;
namespace TransmissionRemoteDotnet
{
    interface ISingleInstance : IDisposable
    {
        event EventHandler<ArgumentsReceivedEventArgs> ArgumentsReceived;
        bool IsFirstInstance { get; }
        void ListenForArgumentsFromSuccessiveInstances();
        bool PassArgumentsToFirstInstance(string[] arguments);
    }
}
