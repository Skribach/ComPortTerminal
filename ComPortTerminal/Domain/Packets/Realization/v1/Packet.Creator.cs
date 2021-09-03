using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        public byte[] CreateConnectionRequest(int number)
        {
            return CreateRequest(Packet.Types.connRequest, BitConverter.GetBytes(number).Take(1).ToArray());
        }

        public byte[] CreateAngleRequest(BladeAngles angles)
        {
            return CreateRequest(Packet.Types.angleRequest, new byte[] {
                Convert.ToByte(angles.A),
                Convert.ToByte(angles.B),
                Convert.ToByte(angles.C),
                Convert.ToByte(angles.D)
                });
        }

        private byte[] CreateRequest(Packet.Types type, byte[] data)
        {
            int count =
                ByteDelimiters[Delimiters.end].Length +
                1 +             //Length
                1 +             //Type command
                data.Length +
                2 +             //CRC
                ByteDelimiters[Delimiters.start].Length;

            byte[] load = new byte[count];

            //header
            for (int i = 0; i < ByteDelimiters[Delimiters.start].Length; i++)
                load[i] = ByteDelimiters[Delimiters.start][i];

            //length
            load[ByteDelimiters[Delimiters.end].Length] = BitConverter.GetBytes(count)[0];

            //command
            load[ByteDelimiters[Delimiters.end].Length + 1] = ByteTypes[type];

            //data
            for (int i = 0; i < data.Length; i++)
                load[ByteDelimiters[Delimiters.end].Length + 2 + i] = data[i];

            //CRC
            var crc = _hash.ComputeChecksumBytes(load.Skip(2).Take(2 + data.Length).ToArray());
            load[ByteDelimiters[Delimiters.end].Length + 2 + data.Length] = crc[1];
            load[ByteDelimiters[Delimiters.end].Length + 3 + data.Length] = crc[0];

            //footer
            for (int i = ByteDelimiters[Delimiters.end].Length + 4 + data.Length;
                i < ByteDelimiters[Delimiters.start].Length + ByteDelimiters[Delimiters.end].Length + 4 + data.Length;
                i++)
                load[i] = ByteDelimiters[Delimiters.end][i - (ByteDelimiters[Delimiters.end].Length + 4 + data.Length)];

            return load;
        }        
    }    
}