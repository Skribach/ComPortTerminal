using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Packets.Realization.v1;
using System.Diagnostics;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        //Class for work with packets
        private Packet _packet;
        //Class to work with connection
        private Connection _conn;
        private Statuses _status;

        public Statuses GetStatus()
        {
            return _status;
        }


        private int _connectionNum;

        //Maximum delay in H,M,S between parameter packets. If Delay > maxDelay, Status will be not connected.
        private TimeSpan maxDelay = new TimeSpan(0, 0, 1);

        public Protocol(Connection conn)
        {
            //Initial
            _packet = new Packet();
            _conn = conn;
            _connectionNum = 0;
            _status = Statuses.notConnected;
        }

        public enum Statuses
        {
            connected,
            notConnected,
            waitingConnectionResponse,
            waitingSetAngleResponse
        };
    }
}