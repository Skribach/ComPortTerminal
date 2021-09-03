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

        public class Angles
        {
            public int A = 90;
            public int B = 90;
            public int C = 90;
            public int D = 90;
        }

        public class Gyro
        {
            public double x = 0;
            public double y = 0;
            public double z = 0;
        }

        public class Parameters
        {
            public Angles angles = new Angles();
            public Gyro gyro = new Gyro();
            public int rpm = 0;            
        }
    }
}
