using ComPortTerminal.Domain.Packets.Realization.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public void RecieveHandler(byte input)
        {
            //If packet arrived
            if (_packet.Parser(input))
            {
                switch (_packet.Type)
                {
                    case (Packet.Types.connResponse):
                        if(Status == Statuses.waitingConnectionResponse)
                        {
                            if(_packet.Data[0] == (byte)_connectionNum)
                            Status = Statuses.connected;
                        }
                        Console.WriteLine("Connection response arrived");
                        break;
                    case (Packet.Types.angleResponse):
                        Console.WriteLine("Angle response arrived");
                        break;
                    case (Packet.Types.parameters):
                        Console.WriteLine("Parameters arrived");
                        break;
                }
            }
        }

    }
}