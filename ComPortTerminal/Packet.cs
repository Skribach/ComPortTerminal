using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public partial class Packet
    {
        public Types Type { get; private set; }
        public byte[] Data { get; private set; }

        private int _length;
        private Crc16 _hash = new Crc16();
        private byte[] _crc;

        public enum Types
        {
            connRequest, connResponse,
            angleRequest, angleResponse,
            rpm, unknown
        }
        public bool Parser(byte[] input)
        {
            Console.WriteLine("\n********RUN PACKET PARSER*********\n");
            //ONLY FOR TEST
            Console.WriteLine("\tInput Packet:");
            foreach (byte e in input)
                Console.Write("0x{0:X} ", e);
            Console.WriteLine();

            //Check on ST and ED Delimeters existence in right order
            int enIndex = Find2Bytes(ByteDelimiters[Delimiters.end], input, 0);
            if (enIndex == -1)
                return false;
            int stIndex = Find2Bytes(ByteDelimiters[Delimiters.start], input, 0);
            if (stIndex == -1)
                return false;
            if (stIndex > enIndex)
                return false;

            //Finding last starting Delimeter            
            int a = stIndex;
            while (a != -1)
            {
                a = Find2Bytes(ByteDelimiters[Delimiters.start], input, a + 1);
                if (a != -1)
                    stIndex = a;
            }

            //Length check
            int length = 2 + enIndex - stIndex;
            if (length == input[stIndex + 2])
            {
                Console.WriteLine("\nOK...Length matches: " + length);
            }
            else
            {
                Console.WriteLine("\nBAD...Length differences");
                return false;
            }

            //CRC checking
            byte[] crcData = new byte[length - 6];
            for (int i = 0; i < (length - 6); i++)
                crcData[i] = input[stIndex + i + 2];

            Console.Write("\n\tCutted packet for CRC: ");
            foreach (byte b in crcData)
                Console.Write("0X{0:X} ", b);
            Console.WriteLine();

            var crcCalc = _hash.ComputeChecksumBytes(crcData);
            Console.WriteLine("\n\tComputed CRC: {1:X} {0:X}", crcCalc[0], crcCalc[1]);
            var crcPack = new byte[] { input[length + 1], input[length] };
            Console.WriteLine("\n\tPacket CRC: {1:X} {0:X}", crcPack[0], crcPack[1]);

            if ((crcCalc[0] == crcPack[0]) && (crcCalc[1] == crcPack[1]))
            {
                Console.WriteLine("\nOK...CRC matches");
            }
            else
            {
                Console.WriteLine("\nBAD...CRC doesn't match");
                return false;
            }

            //Type checking
            Types tempType = Types.unknown;
            foreach (KeyValuePair<Types, Byte> keyValue in ByteTypes)
            {
                if (keyValue.Value == input[3 + stIndex])
                {
                    tempType = keyValue.Key;
                    Console.WriteLine("\nOK...Packet command: " + Enum.GetName(typeof(Types), tempType));
                }
            }
            if (tempType == Types.unknown)
            {
                Console.WriteLine("\nBAD...Command in packet doesn't match with command in enums");
                return false;
            }


            _crc = crcData;
            _length = length;

            Data = new byte[length - 8];
            for (int i = 0; i < (length - 8); i++)
                Data[i] = input[(stIndex + i + 4)];

            Console.Write("\n\tRecieved Data: ");
            foreach (byte b in Data)
                Console.Write("0X{0:X} ", b);

            Console.WriteLine("\n\n\n----------PARSING SUCCESSFULL----------\n");
            return false;
        }

        /// <summary>
        /// Finds 2-byte sequence WHAT in WHERE from index FROM 
        /// </summary>
        /// <param name="what">What you need to find</param>
        /// <param name="where">Where you need to find</param>
        /// <param name="from">Index from what you need to find</param>
        /// <returns></returns>
        private int Find2Bytes(byte[] what, byte[] where, int from)
        {
            for (int i = from; i < where.Length - 1; i++)
            {
                if ((int)where[i] == what[0])
                {
                    if (where[i + 1] == what[1])
                    {
                        Console.WriteLine("\n\tFind " + Encoding.ASCII.GetString(what) + " at position " + i);
                        return i;
                    }
                }
            }
            Console.WriteLine("\n\tST was not find");
            return -1;
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
            var crc = _hash.ComputeChecksumBytes(load.Skip(2).Take(2 + data.Length).ToArray());
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
            [Types.rpm] = (byte)'e',
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