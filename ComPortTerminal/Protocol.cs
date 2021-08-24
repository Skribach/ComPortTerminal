using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComPortTerminal
{
    public class Protocol
    {
        public Packet LastPacket { get; private set; }
        private string _buffer;
        public Protocol()
        {
            _buffer = "";
        }

        public byte[] CreateConnectionRequest(int number)
        {
            return CreateRequest(Global.Message.Type.conn_request, BitConverter.GetBytes(number).Take(1).ToArray());
        }

        public void Parser(string input)
        {
            _buffer += input;
            Console.WriteLine("Input: " + _buffer);
        }

        private byte[] CreateRequest(byte type, byte[] data)
        {
            int count =
                Global.Message.start.Length +
                1 +             //Length
                1 +             //Type command
                data.Length +
                2 +             //CRC
                Global.Message.end.Length;

            byte[] load = new byte[count];

            //header
            for (int i = 0; i < Global.Message.start.Length; i++)
                load[i] = Global.Message.start[i];

            //length
            load[Global.Message.start.Length] = BitConverter.GetBytes(count)[0];

            //command
            load[Global.Message.start.Length + 1] = type;

            //data
            for (int i = 0; i < data.Length; i++)
                load[Global.Message.start.Length + 2 + i] = data[i];

            //CRC
            var crc16 = new Crc16();
            var crc = crc16.ComputeChecksumBytes(load.Skip(2).Take(2 + data.Length).ToArray());
            load[Global.Message.start.Length + 2 + data.Length] = crc[1];
            load[Global.Message.start.Length + 3 + data.Length] = crc[0];

            //footer
            for (int i = Global.Message.start.Length + 4 + data.Length;
                i < Global.Message.end.Length + Global.Message.start.Length + 4 + data.Length;
                i++)
                load[i] = Global.Message.end[i - (Global.Message.start.Length + 4 + data.Length)];

            return load;
        }
    }

    public class Packet
    {
        public byte Type { get; set; }
        int Length { get; set; }
        byte[] Data { get; set; }
        ushort CRC { get; set; }
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