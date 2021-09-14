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
        Stopwatch _delay = new Stopwatch();

        private static void Check(object x)
        {
            var p = (Protocol)x;
            while (true)
            {
                Thread.Sleep(200);
                if (p._delay.ElapsedMilliseconds > AbuseTime)
                {
                    p._delay.Reset();
                    p._status = Statuses.notConnected;
                }
            }
        }
    }
    

}
