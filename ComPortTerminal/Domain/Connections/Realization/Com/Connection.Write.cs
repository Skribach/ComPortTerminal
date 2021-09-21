﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuadcopterConfigurator.Global;

namespace QuadcopterConfigurator.Domain.Connections.Realization.Com
{
    public partial class Connection
    {
        public void Write(string data)
        {
            port.Write(data);
        }
        public Response Write(byte[] data)
        {
            if (port.IsOpen)
            {
                port.Write(data, 0, data.Length);
                return new Response
                {
                    Message = "Connect request was transmitt",
                    isError = false,
                    isCanceled = false
                };
            }
            else
                return new Response
                {
                    Message = "No connected link",
                    isError = true,
                    isCanceled = false
                };
        }
    }
}