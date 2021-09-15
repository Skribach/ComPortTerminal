using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public Response Connect(string connection)
        {
            if (IsConnected)
            {
                if (connection == Name)
                {
                    return new Response
                    {
                        Message = "Connection already established to " + Name + " port",
                        isError = false,
                        isCanceled = true
                    };
                }
                else
                {
                    Disconnect();
                    return tryConnect(connection);
                }
            }
            else
            {
                return tryConnect(connection);
            }

        }
        private Response tryConnect(string connection)
        {
            try
            {
                port.PortName = connection;
                port.BaudRate = 2400;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.Odd;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.Handshake = System.IO.Ports.Handshake.None;
                port.ReadTimeout = 1000;
                port.WriteTimeout = 1000;
                port.ReceivedBytesThreshold = 1;
                port.Open();

                IsConnected = port.IsOpen;
                Name = connection;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "ERROR: Can't connect to " + Name,
                    isError = true,
                    isCanceled = false
                };
            }
            return new Response
            {
                Message = "Connection successfull to " + Name,
                isError = false,
                isCanceled = false
            };
        }

        public void Disconnect() => port.Close();

        public void UpdateAvailableConnections()
        {
            //TODO i want to return response with isError
            AvailableConnections = SerialPort.GetPortNames();
        }
    }
}