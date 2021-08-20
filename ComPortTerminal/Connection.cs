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
            ports = SerialPort.GetPortNames();
            portNum = null;
        }

        public string[] ports;
        public int? portNum;
        public SerialPort port;

        public void Open()
        {
            if (port.IsOpen)
                port.Close();

            port.PortName = ports[(int)portNum];
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.Parity = System.IO.Ports.Parity.Odd;
            port.StopBits = System.IO.Ports.StopBits.One;
            port.Handshake = System.IO.Ports.Handshake.None;
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            port.Open();
        }

        public void Write(string message)
        {
            port.Write(message);
        }
    }
}
