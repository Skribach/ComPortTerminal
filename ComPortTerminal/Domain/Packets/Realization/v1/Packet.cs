using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        public Types Type { get; private set; }
        public byte[] Data { get; private set; }

        private int _length;
        private Crc16 _hash = new Crc16();
        private byte[] _crc;

        //Command of Packet
        public enum Types
        {
            connRequest, connResponse,
            angleRequest, angleResponse,
            parameters, unknown
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
            [Types.connRequest] = (byte)'a',
            [Types.connResponse] = (byte)'b',
            [Types.angleRequest] = (byte)'c',
            [Types.angleResponse] = (byte)'d',
            [Types.parameters] = (byte)'e',
        };
    }    
}