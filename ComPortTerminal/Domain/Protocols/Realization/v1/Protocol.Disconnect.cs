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
        private Thread _connectionChecking = new Thread(new ParameterizedThreadStart(Check));
        

        private static void Check(object x)
        {
            var _protocol = (Protocol)x;
            Stopwatch lastPacket = new Stopwatch();
            lastPacket.Start();
            while (true)
            {
                Thread.Sleep(200);
                if (lastPacket.ElapsedMilliseconds > AbuseTime)
                {
                    _protocol._status = Statuses.notConnected;
                    
                    break;
                }
                else
                {
                    Console.WriteLine(lastPacket.ElapsedMilliseconds);
                    //lastPacket.Restart();                    
                }                
            }
        }
    }
    

}
