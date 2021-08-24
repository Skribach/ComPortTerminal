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
            public static class Type
            {                
                public static byte conn_request = (byte)'a';
                public static byte conn_response = (byte)'b';
                public static byte angle_request = (byte)'c';
                public static byte angle_response = (byte)'d';
                public static byte rpm = (byte)'e';
            }
        }
    }
}
