﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public Connection()
        {
            port = new SerialPort();
            AvailableConnections = SerialPort.GetPortNames();
        }

        public string[] AvailableConnections { get; private set; }
        public string Name { get; set; }
        public bool IsConnected { get; private set; }

        private SerialPort port;
                
        public class Response
        {
            public string Message { get; set; }
            public bool isError { get; set; }
        }
    }
}