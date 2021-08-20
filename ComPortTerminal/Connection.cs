using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    class Connection
    {
        public Connection()
        {
            port = new SerialPort();
            AvailableConnections = SerialPort.GetPortNames();
        }

        public string[] AvailableConnections { get; private set; }   
        public string Name { get; private set; }
        public bool IsConnected { get; private set; }

        private SerialPort port;

        public void Connect(string Port)
        {
            if (port.IsOpen)
                port.Close();

            port.PortName = Port;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.Parity = System.IO.Ports.Parity.Odd;
            port.StopBits = System.IO.Ports.StopBits.One;
            port.Handshake = System.IO.Ports.Handshake.None;
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            port.Open();

            Name = Port;
            IsConnected = port.IsOpen;
        }

        public void Disconnect() => port.Close();

        public void UpdateAvailableConnections()
        {
            AvailableConnections = SerialPort.GetPortNames();
        }        

        public void Write(string message)
        {
            port.Write(message);
        }
    }
}
