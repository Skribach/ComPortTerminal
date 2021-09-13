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
        public byte[] CreateConnectionRequest(int num)
        {
            return CreateRequest(Packet.Types.connRequest, BitConverter.GetBytes(num).Take(1).ToArray(), num);
        }

        public byte[] CreateAngleRequest(BladeAngles angles, int num)
        {
            return CreateRequest(Packet.Types.angleRequest, new byte[] {
                Convert.ToByte(angles.A),
                Convert.ToByte(angles.B),
                Convert.ToByte(angles.C),
                Convert.ToByte(angles.D)
                }, num);
        }

        private byte[] CreateRequest(Packet.Types type, byte[] data, int num)
        {
            int count =
                ByteDelimiters[Delimiters.start].Length +
                1 +             //Length
                1 +             //Packet Number !!!
                1 +             //Type command
                data.Length +
                1;             //CRC

            byte[] load = new byte[count];

            //Header
            for (int i = 0; i < ByteDelimiters[Delimiters.start].Length; i++)
                load[i] = ByteDelimiters[Delimiters.start][i];

            //Length
            load[ByteDelimiters[Delimiters.start].Length] = BitConverter.GetBytes(count)[0];

            //Packet number
            load[ByteDelimiters[Delimiters.start].Length + 1] = (byte)num;

            //Command
            load[ByteDelimiters[Delimiters.start].Length + 2] = ByteTypes[type];

            //Data
            for (int i = 0; i < data.Length; i++)
                load[ByteDelimiters[Delimiters.start].Length + 3 + i] = data[i];

            //CRC
            var crc = _hash.ComputeChecksumBytes(load.Take(load.Length - 1).ToArray());
            load[ByteDelimiters[Delimiters.start].Length + 3 + data.Length] = crc;

            return load;
        }
    }    
}