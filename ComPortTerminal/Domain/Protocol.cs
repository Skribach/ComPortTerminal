﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public partial class Protocol
    {
        public Packet Packet { get; private set; }
        private byte[] _buffer;
        private int _pointer;
        //Max Message Length = _bufferLength/2
        private int _bufferLength = 64;
        public Protocol()
        {
            Packet = new Packet();
            _buffer = new byte[_bufferLength];
            _pointer = _bufferLength/2;
        }        
    }
}