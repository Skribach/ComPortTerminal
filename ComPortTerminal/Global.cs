using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public static class Global
    {

        public static class Message
        {
            //Start bytes
            public static byte[] start = { 0x53, 0x54 };
            public static byte[] end = { 0x45, 0x44 };

            //Commands/Data types
            
            public static Dictionary<MessageTypes, byte> Types = new Dictionary<MessageTypes, byte>()
            {
                [MessageTypes.conn_request] = (byte)'a',
                [MessageTypes.conn_response] = (byte)'b',
                [MessageTypes.angle_request] = (byte)'c',
                [MessageTypes.angle_response] = (byte)'d',
                [MessageTypes.rpm] = (byte)'e',
            };

            public static Dictionary<MessageDelimiters, byte[]> Delimiters = new Dictionary<MessageDelimiters, byte[]>()
            {
                [MessageDelimiters.start] = new byte[]{ 0x53, 0x54 },
                [MessageDelimiters.end] = new byte[] { 0x45, 0x44 }
            };
        }

        public enum MessageTypes
        {
            conn_request, conn_response,
            angle_request, angle_response,
            rpm
        }
        public enum MessageDelimiters
        {
            start, end
        }
    }
}
