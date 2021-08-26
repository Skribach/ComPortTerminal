using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public Response Connect()
        {
            if (!port.IsOpen)
            {
                if (Name == null)
                {
                    return new Response
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
                    port.ReceivedBytesThreshold = 1;
                    port.Open();

                    IsConnected = port.IsOpen;
                    Write("Connection complete" + (char)13);

                }
                catch (Exception ex)
                {
                    return new Response
                    {
                        Message = "ERROR: Another instance connected to " + Name,
                        isError = true
                    };
                }
                return new Response
                {
                    Message = "Connection successfull to " + Name,
                    isError = false
                };
            }
            return new Response
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
    }
}