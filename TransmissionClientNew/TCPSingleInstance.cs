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
            try
            {
                StreamReader reader = new StreamReader(listener.AcceptTcpClient().GetStream());
                List<string> arguments = new List<string>();
                string response = reader.ReadLine();
                reader.Close();
                foreach (string arg in (JsonArray)JsonConvert.Import(response))
                {
                    if (arg != null && arg.Length > 0)
                    {
                        arguments.Add(arg);
                    }
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(CallOnArgumentsReceived), arguments.ToArray());
            }
            catch
            {
            }
            finally
            {
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
                throw new InvalidOperationException("This is not the first instance.");
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", this.port);
                NetworkStream stream = client.GetStream();
                byte[] data = (new ASCIIEncoding()).GetBytes((new JsonArray(arguments)).ToString());
                stream.Write(data, 0, data.Length);
                client.Close();
                return true;
            }
            catch
            {
                return false;
            }
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