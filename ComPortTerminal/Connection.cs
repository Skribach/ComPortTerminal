using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public class Connection
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

        public ConnectResponse Connect()
        {
            if (!port.IsOpen)
            {
                if (Name == null)
                {
                    return new ConnectResponse
                    {
                        Message = "COM-port need to be selected;",
                        isError = true
                    };
                }
                try
                {
                    port.PortName = Name;
                    port.BaudRate = 9600;
                    port.DataBits = 8;
                    port.Parity = System.IO.Ports.Parity.Odd;
                    port.StopBits = System.IO.Ports.StopBits.One;
                    port.Handshake = System.IO.Ports.Handshake.None;
                    port.ReadTimeout = 1000;
                    port.WriteTimeout = 1000;
                    port.Open();

                    IsConnected = port.IsOpen;
                    Write("Connection complete" + (char)13);
                }
                catch (Exception ex)
                {
                    return new ConnectResponse
                    {
                        Message = "ERROR: Another instance connected to " + Name,
                        isError = true
                    };
                }
                return new ConnectResponse
                {
                    Message = "Connection test successfull to " + Name,
                    isError = false
                };
            }
            return new ConnectResponse
            {
                Message = "Connection is already established to " + Name,
                isError = false
            };
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

        public void Write(byte[] message)
        {
            port.Write(message, 0, message.Length);
        }

        public delegate void RecieverHandler(object sender, SerialDataReceivedEventArgs e);
        public void SetRecieveHandler(RecieverHandler recieverHandler)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(recieverHandler);
        }
        public class ConnectResponse
        {
            public string Message { get; set; }
            public bool isError { get; set; }
        }
    }
}