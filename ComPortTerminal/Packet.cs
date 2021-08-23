using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComPortTerminal
{
    public class Packet
    {        
        private Qadcopter qadcopter;
        public Packet(Qadcopter qadcopt)
        {
            qadcopter = qadcopt;
        }

        public string SetAngle()
        {
            throw new NotImplementedException();
        }

        //CRC16-MODBUS
        public UInt16 GenerateCRC16(byte[] buf)
        {
            int len = buf.Length;
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];

                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }
            return crc;
        }

        //Converts int to 2-byte
        public byte[] To2Byte(int num) => new byte[] { (byte)(num % 256), (byte)(num / 256) };

        public byte[] To2Byte(string line) => new byte[] { (byte)(line[0]), (byte)(line[1]) };
        
    }
}
