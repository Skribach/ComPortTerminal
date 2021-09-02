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
            Random r = new Random();
            //If packet arrived
            if (_packet.TryParse(input))
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
                        Status = Statuses.connected;
                        Console.WriteLine("Angle response arrived");
                        break;
                    case (Packet.Types.parameters):
                        Console.WriteLine("Parameters arrived");
                        _recievedParametersHandler.Invoke(r.Next(), r.NextDouble(), r.NextDouble(), r.NextDouble());
                        break;
                }
            }
        }

        public delegate void RecievedParametersHandler(int rpm, double x, double y, double z);
        private RecievedParametersHandler _recievedParametersHandler;
        public void SetRecievedParametersHandler(RecievedParametersHandler handler)
        {
            _recievedParametersHandler += handler;
        }
        



    }
}