using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        /// <summary>
        /// Realize Crc16-ARC
        /// </summary>
        public class Crc16Arc
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

            public Crc16Arc()
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

        /// 
        /// Class for calculating CRC8 checksums...
        /// 
        public class Crc8
        {
            ///
            /// This enum is used to indicate what kind of checksum you will be calculating.
            /// 
            private enum CRC8_POLY
            {
                CRC8 = 0xd5,
                CRC8_CCITT = 0x07,
                CRC8_DALLAS_MAXIM = 0x31,
                CRC8_SAE_J1850 = 0x1D,
                CRC_8_WCDMA = 0x9b,
            };

            private CRC8_POLY _poly = CRC8_POLY.CRC8_CCITT;

            private byte[] table = new byte[256];

            public Crc8()
            {
                this.table = this.GenerateTable();
            }

            public byte ComputeChecksumBytes(params byte[] val)
            {
                if (val == null)
                    throw new ArgumentNullException("val");

                byte c = 0;

                foreach (byte b in val)
                {
                    c = table[c ^ b];
                }

                return c;
            }

            public byte[] GenerateTable()
            {
                byte[] csTable = new byte[256];

                for (int i = 0; i < 256; ++i)
                {
                    int curr = i;

                    for (int j = 0; j < 8; ++j)
                    {
                        if ((curr & 0x80) != 0)
                        {
                            curr = (curr << 1) ^ (int)_poly;
                        }
                        else
                        {
                            curr <<= 1;
                        }
                    }

                    csTable[i] = (byte)curr;
                }

                return csTable;
            }

            
        }
    }    
}