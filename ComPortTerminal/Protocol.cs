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

        public void PacketParser(string input)
        {
            _buffer += input;
            Console.WriteLine("Input: " + _buffer);
            //If buffer contains start and end delimeters
            if (_buffer.Contains(StringDelimiters[Delimiters.start])
                && _buffer.Contains(StringDelimiters[Delimiters.end]))
            {
                int startInd = _buffer.IndexOf(StringDelimiters[Delimiters.start]);
                int endInd = _buffer.IndexOf(StringDelimiters[Delimiters.end]);
                //if start combination earlier than end
                if (startInd < endInd)
                {
                    string packet = _buffer.Substring(StringDelimiters[Delimiters.start].Length + startInd, endInd-StringDelimiters[Delimiters.start].Length + startInd);
                    _buffer = "";
                    Console.WriteLine(" Packet Parsed: " + packet);
                }
            }
        }

        public byte[] CreateConnectionRequest(int number)
        {
            return CreateRequest(Packet.Types.connRequest, BitConverter.GetBytes(number).Take(1).ToArray());
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
            for (int i = 0; i < ByteDelimiters[Delimiters.end].Length; i++)
                load[i] = ByteDelimiters[Delimiters.end][i];

            //length
            load[ByteDelimiters[Delimiters.end].Length] = BitConverter.GetBytes(count)[0];

            //command
            load[ByteDelimiters[Delimiters.end].Length + 1] = ByteTypes[type];

            //data
            for (int i = 0; i < data.Length; i++)
                load[ByteDelimiters[Delimiters.end].Length + 2 + i] = data[i];

            //CRC
            var crc16 = new Crc16();
            var crc = crc16.ComputeChecksumBytes(load.Skip(2).Take(2 + data.Length).ToArray());
            load[ByteDelimiters[Delimiters.end].Length + 2 + data.Length] = crc[1];
            load[ByteDelimiters[Delimiters.end].Length + 3 + data.Length] = crc[0];

            //footer
            for (int i = ByteDelimiters[Delimiters.end].Length + 4 + data.Length;
                i < ByteDelimiters[Delimiters.start].Length + ByteDelimiters[Delimiters.end].Length + 4 + data.Length;
                i++)
                load[i] = ByteDelimiters[Delimiters.start][i - (ByteDelimiters[Delimiters.end].Length + 4 + data.Length)];

            return load;
        }


        //Start/stop types
        public enum Delimiters
        {
            start, end
        }

        //Start/stop string
        public static Dictionary<Delimiters, string> StringDelimiters = new Dictionary<Delimiters, string>()
        {
            [Delimiters.start] = "st",
            [Delimiters.end] = "ed"
        };

        //Start/stop bytes
        public Dictionary<Delimiters, byte[]> ByteDelimiters = new Dictionary<Delimiters, byte[]>()
        {
            [Delimiters.start] = Encoding.ASCII.GetBytes(StringDelimiters[Delimiters.start]),
            [Delimiters.end] = Encoding.ASCII.GetBytes("ed")
        };

        //Commands/Data types            
        public static Dictionary<Packet.Types, byte> ByteTypes = new Dictionary<Packet.Types, byte>()
        {
            [Packet.Types.connRequest] = (byte)'a',
            [Packet.Types.connResponse] = (byte)'b',
            [Packet.Types.angleRequest] = (byte)'c',
            [Packet.Types.angleResponse] = (byte)'d',
            [Packet.Types.rpm] = (byte)'e',
        };
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