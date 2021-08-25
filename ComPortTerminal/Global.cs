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
            //Commands/Data types            
            public static Dictionary<MessageTypes, byte> Types = new Dictionary<MessageTypes, byte>()
            {
                [MessageTypes.connRequest] = (byte)'a',
                [MessageTypes.connResponse] = (byte)'b',
                [MessageTypes.angleRequest] = (byte)'c',
                [MessageTypes.angleResponse] = (byte)'d',
                [MessageTypes.rpm] = (byte)'e',
            };

            //Start bytes
            public static Dictionary<MessageDelimiters, byte[]> Delimiters = new Dictionary<MessageDelimiters, byte[]>()
            {
                [MessageDelimiters.start] = new byte[]{ 0x53, 0x54 },
                [MessageDelimiters.end] = new byte[] { 0x45, 0x44 }
            };
        }

        public enum MessageTypes
        {
            connRequest, connResponse,
            angleRequest, angleResponse,
            rpm
        }
        public enum MessageDelimiters
        {
            start, end
        }
    }
}
