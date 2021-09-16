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
        public Response Connect(string connection)
        {
            _delay.Restart();
            //Connection to COM-port
            var resp = _conn.Connect(connection);
            if (resp.isError)
            {
                return new Response
                {
                    Message = resp.Message,
                    isError = true,
                    isCanceled = false
                };
            }
            return new Response
            {
                Message = resp.Message,
                isError = false,
                isCanceled = false
            };
        }
                
        public async Task<ConnResponse> AutoConnectAsync()
        {            
            for(int i = 0; i < _conn.AvailableConnections.Length; i++ )
            {
                if(!Connect(_conn.AvailableConnections[i]).isError)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (_status == Statuses.connected)
                        {                            
                            return new ConnResponse
                            {
                                Message = ("Connection successfull to" + _conn.AvailableConnections[i]),
                                ConnectionName = _conn.AvailableConnections[i],
                                isError = false,
                                isCanceled = false
                            };
                        }
                        await Task.Run(() => Thread.Sleep(ReplyTimeRequest));
                    }                    
                }
            }
            return new ConnResponse
            {
                Message = ("Can't establish connection with quadcopter"),
                isError = true,
                isCanceled = false
            };
        }
    }
}