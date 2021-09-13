using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public static class Global
    {
        public class Response
        {
            public string Message { get; set; }
            public bool isError { get; set; }
            public bool isCanceled { get; set; }
        }

        public class BladeAngles
        {
            public int A = 90;
            public int B = 90;
            public int C = 90;
            public int D = 90;
        }

        public class Gyro
        {
            public float x = 0;
            public float y = 0;
            public float z = 0;
        }

        public class Parameters
        {
            public int num;
            public Gyro gyro = new Gyro();
            public int rpm = 0;            
        }

        /// <summary>
        /// Time in ms between two requests
        /// </summary>
        public const int ReplyTimeRequest = 500;   //To Debug
        //public const int ReplyTimeRequest = 300;  //To Prod
        /// <summary>
        /// Number of connection requests to quadcopter
        /// Can be in range 1...255
        /// </summary>
        public const int NumOfReply = 200;          //To Debug
        //public const int NumOfReply = 8;          //To Prod
        /// <summary>
        /// Maximum time in ms between packeges to be connected.
        /// </summary>
        public const int AbuseTime = 1000;
    }
}
