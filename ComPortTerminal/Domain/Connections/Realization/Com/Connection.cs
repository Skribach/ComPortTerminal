using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadcopterConfigurator.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public Connection()
        {
            port = new SerialPort();
        }

        public string Name { get; set; }
        public bool IsConnected { get; private set; }

        private SerialPort port;
        
        private void reset()
        {
            Name = "";
            IsConnected = false;
        }

        public string[] GetAvailableConnections()
        {
            return SerialPort.GetPortNames();
        }

    }
}