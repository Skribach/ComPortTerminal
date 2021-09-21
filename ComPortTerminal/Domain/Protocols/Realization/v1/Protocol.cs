using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuadcopterConfigurator.Domain.Connections.Realization.Com;
using QuadcopterConfigurator.Domain.Packets.Realization.v1;
using System.Diagnostics;
using static QuadcopterConfigurator.Global;

namespace QuadcopterConfigurator.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        //Class for work with packets
        private Packet _packet;
        //Class to work with connection
        private Connection _conn; 

        //ID for parameters from GUI
        private byte _id;

        private Statuses _status;

        public Statuses GetStatus()
        {
            return _status;
        }        

        public Protocol(Connection conn)
        {
            //Initial
            _packet = new Packet();
            _conn = conn;
            //When 1-byte recieved, RecieveHandler runs
            _conn.SetRecieveHandler(RecieveHandler);

            _id = 0;
            _status = Statuses.disconnected;
            //Thread to check delay between packets
            _connectionChecking.IsBackground = true;
            _connectionChecking.Start(this);

            _prevAngles = new BladeAngles{ A = 90, B = 90, C = 90, D = 90};
            _currentAngles = new BladeAngles { A = 90, B = 90, C = 90, D = 90 };
        }

        public enum Statuses
        {
            //parameters from GUI matches with quadcopter params
            connected,
            //parameters from GUI doesn't match with quadcopter params
            updating,
            //quadcopter doesn't found
            disconnected
        };
    }
}