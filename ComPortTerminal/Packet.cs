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
            return CreateRequest(Global.Message.Type.conn_request, new byte[] { 49, 50, 51 });
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
            var crc = GenerateCRC16(load.Skip(2).Take(2).ToArray());
            load[Global.Message.start.Length + 1 + data.Length] = crc[0];
            load[Global.Message.start.Length + 2 + data.Length] = crc[1];

            //footer
            for (int i = Global.Message.start.Length + 3 + data.Length;
                i < Global.Message.end.Length + Global.Message.start.Length + 3 + data.Length;
                i++)
                load[i] = Global.Message.end[i - (Global.Message.start.Length + 3 + data.Length)];

            return load;
        }

        //CRC16-MODBUS
        //NOT WORK
        public byte[] GenerateCRC16(byte[] buf)
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
            return BitConverter.GetBytes(crc);
        }
    }
}