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
        public Response TryConnect(string connection)
        {
            //Connection to COM-port
            if (_status == Statuses.disconnected)
            {
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
                //When 1-byte recieved, RecieveHandler runs
                _conn.SetRecieveHandler(RecieveHandler);

                return new Response
                {
                    Message = resp.Message,
                    isError = false,
                    isCanceled = false
                };
            }
            else
                return new Response
                {
                    Message = "",
                    isError = false,
                    isCanceled = true
                };
        }
    }
}