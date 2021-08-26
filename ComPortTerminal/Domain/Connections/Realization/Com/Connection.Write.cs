using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public void Write(string data)
        {
            port.Write(data);
        }
        public void Write(byte[] data)
        {
            port.Write(data, 0, data.Length);
        }
    }
}