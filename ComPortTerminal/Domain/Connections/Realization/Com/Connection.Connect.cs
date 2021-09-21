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
                    reset();
                    return tryConnect(connection);
                }
            }
            else
            {
                reset();
                return tryConnect(connection);
            }

        }
        private Response tryConnect(string connection)
        {
            try
            {
                port.PortName = connection;
                port.BaudRate = 19200;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.Handshake = System.IO.Ports.Handshake.None;
                port.ReadTimeout = 100;
                port.WriteTimeout = 100;
                port.ReceivedBytesThreshold = 16;
                port.Open();

                IsConnected = port.IsOpen;
                Name = connection;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "ERROR: Can't connect to " + connection,
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