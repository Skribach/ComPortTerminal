using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComPortTerminal.Domain.Packets.Realization.v1;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public  Packet Packet { get; private set; }
        
        public Protocol()
        {
            Packet = new Packet();           
        }        
    }
}