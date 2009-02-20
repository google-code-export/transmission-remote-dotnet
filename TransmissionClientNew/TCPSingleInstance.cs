#if MONO || DOTNET2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace TransmissionRemoteDotnet
{
    class TCPSingleInstance : ISingleInstance
    {
        private int port;
        private TcpListener listener;
        private bool isFirstInstance;

        public TCPSingleInstance(int port)
        {
            try
            {
                this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                this.isFirstInstance = true;
            }
            catch
            {
                this.port = port;
                this.isFirstInstance = false;
            }
        }

        #region ISingleInstance Members

        public event EventHandler<ArgumentsReceivedEventArgs> ArgumentsReceived;

        public bool IsFirstInstance
        {
            get
            {
                return this.isFirstInstance;
            }
        }

        public void ListenForArgumentsFromSuccessiveInstances()
        {
            if (!isFirstInstance)
                throw new InvalidOperationException("This is not the first instance.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ListenForArguments));
        }

        private void ListenForArguments(Object state)
        {
            StreamWriter writer = null;
            StreamReader reader = null;
            try
            {
                Stream clientStream = listener.AcceptTcpClient().GetStream();
                reader = new StreamReader(clientStream);
                List<string> arguments = new List<string>();
                foreach (string arg in (JsonArray)JsonConvert.Import(reader.ReadLine()))
                {
                    if (arg != null && arg.Length > 0)
                        arguments.Add(arg);
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(CallOnArgumentsReceived), arguments.ToArray());
            }
            catch
            { }
            finally
            {
                if (writer != null)
                    writer.Close();
                if (reader != null)
                    reader.Close();
                ListenForArguments(null);
            }
        }

        private void CallOnArgumentsReceived(Object state)
        {
            if (ArgumentsReceived != null)
                ArgumentsReceived(this, new ArgumentsReceivedEventArgs() { Args = (string[])state });
        }

        public bool PassArgumentsToFirstInstance(string[] arguments)
        {
            if (isFirstInstance)
                throw new InvalidOperationException("This is the first instance.");
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", this.port);
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.WriteLine((new JsonArray(arguments)).ToString());
            writer.Close();
            return true;
        }

        #endregion

        #region IDisposable
        private Boolean disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                this.listener.Stop();
                disposed = true;
            }
        }

        ~TCPSingleInstance()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
#endif