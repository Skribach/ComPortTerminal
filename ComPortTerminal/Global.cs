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
            public int LTAngle;
            public int RTAngle;
            public int LBAngle;
            public int RBAngle;
        }

        public class Parameters
        {
            public int rpm = 0;
            public double x = 0;
            public double y = 0;
            public double z = 0;
        }
    }
}
