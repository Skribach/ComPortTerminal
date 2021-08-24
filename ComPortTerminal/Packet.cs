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
            byte[] load = new byte[8];

            //header
            for(int i = 0; i < Global.Message.start.Length; i++)
            {
                load[i] = Global.Message.start[i];
            }
            //command
            load[2] = Global.Message.Type.conn_request;
            //number of request
            load[3] = byte.Parse(number.ToString());
            
            //CRC
            var crc = GenerateCRC16(load.Skip(2).Take(2).ToArray());
            byte[] crcb = BitConverter.GetBytes(crc);
            load[4] = crcb[0];
            load[5] = crcb[1];
            
            //footer
            for (int i = 6; i < Global.Message.end.Length + 6; i++)
            {
                load[i] = Global.Message.end[i-6];
            }

            return load;
        }

        //CRC16-MODBUS
        //NOT WORK
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
        
        public byte[] ToByte(string line)
        {
            byte[] output = new byte[line.Length];
            for (int i = 0; i < line.Length; i++)
                output[i] = (byte)(line[i]);
            return output;
        }
        
    }
}
