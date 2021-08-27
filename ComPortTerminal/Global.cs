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
        }
    }
}
