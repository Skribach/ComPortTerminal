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
        /// <summary>
        /// Creates angle request from angles and number of packet
        /// </summary>
        /// <param name="angles"></param>
        /// <param name="num"></param>
        /// <returns>bytes to transmitt by means connection</returns>
        public byte[] SetAngle(BladeAngles angles, int num)
        {
            return CreateRequest(Packet.Types.setParameters, new byte[] {                
                Convert.ToByte((int)angles.A*1.417),
                Convert.ToByte((int)angles.B*1.417),
                Convert.ToByte((int)angles.C*1.417),
                Convert.ToByte((int)angles.D*1.417),
                Convert.ToByte(num)
                });
        }

        /// <summary>
        /// Adds CRC and translate type to byte
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] CreateRequest(Packet.Types type, byte[] data)
        {
            int count =
                ByteDelimiters[Delimiters.start].Length +
                1 +             //Length
                1 +             //Type command
                data.Length +
                1;             //CRC

            byte[] load = new byte[count];

            //Header
            for (int i = 0; i < ByteDelimiters[Delimiters.start].Length; i++)
                load[i] = ByteDelimiters[Delimiters.start][i];

            //Length
            load[ByteDelimiters[Delimiters.start].Length] = BitConverter.GetBytes(count)[0];


            //Command
            load[ByteDelimiters[Delimiters.start].Length + 1] = ByteTypes[type];

            //Data
            for (int i = 0; i < data.Length; i++)
                load[ByteDelimiters[Delimiters.start].Length + 2 + i] = data[i];

            //CRC
            var crc = _hash.ComputeChecksumBytes(load.Take(load.Length - 1).ToArray());
            load[ByteDelimiters[Delimiters.start].Length + 2 + data.Length] = crc;

            return load;
        }
    }
}