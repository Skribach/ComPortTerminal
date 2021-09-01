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
        private Packet _packet;
        private Connection _conn;
        public Statuses Status { get; private set; }

        //Angles
        private int _a = 90;
        private int _b = 90;
        private int _c = 90;
        private int _d = 90;

        public bool IsConnected { get; private set; }
        private int _connectionNum;

        public Protocol(Connection conn)
        {
            _packet = new Packet();
            _conn = conn;
            Status = Statuses.notConnected;
            _connectionNum = 0;
        }

        public enum Statuses
        {
            connected,
            notConnected,
            waitingConnectionResponse,
            waitingSetAngleResponse
        }
    }
}