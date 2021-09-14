﻿using System;
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

        //Parameters that recieved from quadcopter
        private Parameters _quadcopterParams;

        //Parameters from user
        public BladeAngles Parameters { get; set; }

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
            _id = 0;
            _status = Statuses.disconnected;
            //Thread to check delay between packets
            _connectionChecking.Start(this);
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