using ComPortTerminal.Domain.Packets.Realization.v1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public void RecieveHandler(byte input)
        {
            //If packet arrived
            if (_packet.TryParse(input))
            {
                switch (_packet.Type)
                {
                    case (Packet.Types.connResponse):
                        if (_status == Statuses.waitingConnectionResponse)
                        {
                            if (_packet.Number == _number)
                            {
                                _status = Statuses.connected;
                                _delay.Start();
                            }
                        }
                        Console.WriteLine("Connection response arrived");
                        break;

                    case (Packet.Types.angleResponse):
                        //return to connected state;
                        _status = Statuses.connected;                        
                        Console.WriteLine("Angle response arrived");
                        break;

                    case (Packet.Types.parameters):
                        Console.WriteLine("Parameters arrived");
                        Parameters param = _packet.ParseParams();
                        _delay.Restart();
                        _recievedParametersHandler(param);
                        break;
                }
            }
        }

        public delegate void RecievedParametersHandler(Parameters p);
        private RecievedParametersHandler _recievedParametersHandler;
        public void SetRecievedParametersHandler(RecievedParametersHandler handler)
        {
            _recievedParametersHandler += handler;
        }
    }
}