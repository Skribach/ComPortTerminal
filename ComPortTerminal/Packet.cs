using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public class Packet
    {
        public Types Type { get; set; }
        int Length { get; set; }
        byte[] Data { get; set; }
        ushort CRC { get; set; }

        public enum Types
        {
            connRequest, connResponse,
            angleRequest, angleResponse,
            rpm
        }        
    }
}
