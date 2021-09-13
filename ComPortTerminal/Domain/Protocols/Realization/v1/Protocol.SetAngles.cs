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
        private BladeAngles _angles = new BladeAngles();

        public async Task<Response> SetAnglesAsync(int a, int b, int c, int d)
        {
            _angles.A = a;
            _angles.B = b;
            _angles.C = c;
            _angles.D = d;

            //If button was pushed more than one time
            if (Status == Statuses.waitingSetAngleResponse)
                return new Response
                {
                    Message = "Setting angle in progress...",
                    isError = false,
                    isCanceled = true
                };

            //If no established connection
            else if (Status != Statuses.connected)
                return new Response
                {
                    Message = "ERROR: No established connection. Please connect to link",
                    isError = true,
                    isCanceled = false
                };

            Status = Statuses.waitingSetAngleResponse;
            for (int i = 0; i < NumOfReply; i++)
            {
                if (Status == Statuses.connected)
                {
                    _connectionNum = 0;
                    return new Response
                    {
                        Message = "Angles successfully installed",
                        isError = false,
                        isCanceled = false
                    };
                }
                _conn.Write(_packet.CreateAngleRequest(_angles, 1));
                await Task.Run(() => Thread.Sleep(ReplyTimeRequest));
            }
            _connectionNum = 0;
            Status = Statuses.notConnected;
            return new Response
            {
                Message = "ERROR: Connection fail",
                isError = true
            };
        }
    }
}