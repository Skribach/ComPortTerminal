using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Packets.Realization.v1;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public async Task<Response> ConnectAsync(string connection)
        {
            //Connection to COM-port
            var resp = _conn.Connect(connection);
            if (resp.isError)
            {
                return new Response
                {
                    Message = resp.Message,
                    isError = true
                };
            }

            //When 1-byte recieved, RecieveHandler runs
            _conn.SetRecieveHandler(RecieveHandler);

            _status = Statuses.waitingConnectionResponse;
            //Sending request to connect
            return await CreateConnectionRequests();
        }
        /// <summary>
        /// Send connection request 8 times or while don't recieve connection response
        /// </summary>
        /// <returns></returns>
        private async Task<Response> CreateConnectionRequests()
        {
            for (int i = 0; i < 8; i++)
            {
                if (_status == Statuses.connected)
                {
                    _connectionNum = 0;
                    return new Response
                    {
                        Message = "Quadcopter connection successfull",
                        isError = false
                    };
                }
                _connectionNum = i;
                _conn.Write(_packet.CreateConnectionRequest(_connectionNum));
                await Task.Run(() => Thread.Sleep(300));
            }
            _connectionNum = 0;
            _status = Statuses.notConnected;
            return new Response
            {
                Message = "ERROR: Qadcopter connection fail",
                isError = true
            };
        }
    }
}