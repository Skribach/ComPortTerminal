
namespace QuadcopterConfigurator
{
    public static class Global
    {
        public class Response
        {
            public string Message { get; set; }
            public bool isError { get; set; }
            public bool isCanceled { get; set; }
        }

        public class ConnResponse : Response
        {
            public string ConnectionName { get; set; }
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
            public BladeAngles Angles { get; set; }
            public int Id { get; set; }
            public Gyro Gyro = new Gyro();
            public int Rpm { get; set; }
        }

        /// <summary>
        /// Time in ms between two requests
        /// </summary>
        public const int ReplyTimeRequest = 100;
        /// <summary>
        /// Number of connection requests to quadcopter
        /// Can be in range 1...255
        /// </summary>
        public const int NumOfReply = 8;
        /// <summary>
        /// Numbers of replying 
        /// </summary>
        public const int NumOfAutoConnReply = 2;
        /// <summary>
        /// Maximum time in ms between packeges to be connected.
        /// </summary>
        public const int AbuseTime = 2000;
    }
}
