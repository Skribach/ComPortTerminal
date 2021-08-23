using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Contracts
{
    public static class Connect
    {
        public class Response
        {
            public string Message { get; set; }
            public bool isError { get; set; }
        }
    }
}
