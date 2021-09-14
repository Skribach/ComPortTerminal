using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        public Packet()
        {

        }

        public Types Type { get; private set; }
        public byte[] Data { get; private set; }

        private int _length;
        private Crc8 _hash = new Crc8();

        //Command of Packet
        public enum Types
        {
            getParameters,
            setParameters,
            unknown
        }

        //Start/stop types
        public enum Delimiters
        {
            start, end
        }

        //Start/stop string
        //Length of string must be 2
        public static Dictionary<Delimiters, string> StringDelimiters = new Dictionary<Delimiters, string>()
        {
            [Delimiters.start] = "ST",
            [Delimiters.end] = "ED"
        };

        //Start/stop bytes        
        public Dictionary<Delimiters, byte[]> ByteDelimiters = new Dictionary<Delimiters, byte[]>()
        {
            [Delimiters.start] = Encoding.ASCII.GetBytes(StringDelimiters[Delimiters.start]),
            [Delimiters.end] = Encoding.ASCII.GetBytes(StringDelimiters[Delimiters.end])
        };

        //Commands/Data types            
        public static Dictionary<Types, byte> ByteTypes = new Dictionary<Packet.Types, byte>()
        {
            [Types.getParameters] = 0x22,
            [Types.setParameters] = 0x20
        };
    }
}