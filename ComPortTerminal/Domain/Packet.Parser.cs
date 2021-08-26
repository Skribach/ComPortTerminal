using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public partial class Packet
    {
        /// <summary>
        /// Parses array of byte. If packet is found, return true and rewrite itself Type, Data vars
        /// </summary>
        /// <param name="input">input byte[]</param>
        /// <returns></returns>
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
    }
}