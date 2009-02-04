using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    class TransmissionDaemonDescriptor
    {
        private double version = 1.41;

        public double Version
        {
            get { return version; }
            set { version = value; }
        }
        private int revision = -1;

        public int Revision
        {
            get { return revision; }
            set { revision = value; }
        }
        private int rpcVersion = -1;

        public int RpcVersion
        {
            get { return rpcVersion; }
            set { rpcVersion = value; }
        }
        private int rpcVersionMin = -1;

        public int RpcVersionMin
        {
            get { return rpcVersionMin; }
            set { rpcVersionMin = value; }
        }
        private JsonObject sessionData;

        public JsonObject SessionData
        {
            get { return sessionData; }
            set { sessionData = value; }
        }
        private long updateSerial = 0;

        public long UpdateSerial
        {
            get { return updateSerial; }
            set { updateSerial = value; }
        }
        private int failCount = 0;

        public int FailCount
        {
            get { return failCount; }
            set { failCount = value; }
        }

        public void ResetFailCount()
        {
            failCount = 0;
        }
    }
}
