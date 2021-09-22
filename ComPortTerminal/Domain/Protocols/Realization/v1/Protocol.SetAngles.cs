using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuadcopterConfigurator.Domain.Connections.Realization.Com;
using QuadcopterConfigurator.Domain.Packets.Realization.v1;
using static QuadcopterConfigurator.Global;

namespace QuadcopterConfigurator.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {     
        public async Task<Response> SlowSetAnglesAsync()
        {
            bool y = true;
            int x = 0;
            while (true)
            {
                if(x >= 180)
                {
                    y = false;
                }
                if (x <= 0)
                {
                    y = true;
                }
                if(y == true)
                {
                    x+=20;
                }
                else
                {
                    x-=20;
                }
                var resp = await SetAnglesAsync(new BladeAngles { A = x, B = x, C = x, D = x });
                Thread.Sleep(200);
            }
            return new Response();
        }
    }
}