using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComPortTerminal
{
    public class Packet
    {     
        public Packet()
        {
            
        }

        public byte[] ConnectionRequest(int number)
        {
            return CreateRequest(Global.Message.Type.conn_request, BitConverter.GetBytes(number).Take(1).ToArray());
        }

        private byte[] CreateRequest(byte type, byte[] data)
        {
            int count =
                Global.Message.start.Length +
                1 +             //Type command
                data.Length +
                2 +             //CRC
                Global.Message.end.Length;

            byte[] load = new byte[count];

            //header
            for (int i = 0; i < Global.Message.start.Length; i++)
                load[i] = Global.Message.start[i];

            //command
            load[Global.Message.start.Length] = type;

            //data
            for (int i = 0; i < data.Length; i++)
                load[Global.Message.start.Length + 1 + i] = data[i];

            //CRC
            var crco = new Crc16();
            var crc = crco.ComputeChecksumBytes(load.Skip(2).Take(2).ToArray());
            load[Global.Message.start.Length + 1 + data.Length] = crc[1];
            load[Global.Message.start.Length + 2 + data.Length] = crc[0];

            //footer
            for (int i = Global.Message.start.Length + 3 + data.Length;
                i < Global.Message.end.Length + Global.Message.start.Length + 3 + data.Length;
                i++)
                load[i] = Global.Message.end[i - (Global.Message.start.Length + 3 + data.Length)];

            return load;
        }
    }
    //CRC16-ARC
    public class Crc16
    {
        const ushort polynomial = 0xA001;
        ushort[] table = new ushort[256];

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }
}

