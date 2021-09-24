﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuadcopterConfigurator.Domain.Connections.Realization.Com;
using QuadcopterConfigurator.Domain.Packets.Realization.v1;
using static QuadcopterConfigurator.Global;

namespace QuadcopterConfigurator.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public Response Connect(string connection)
        {
            _delay.Restart();
            //Connection to COM-port
            var resp = _conn.Connect(connection);
            if (resp.isError)
            {
                return new Response
                {
                    Message = resp.Message,
                    isError = true,
                    isCanceled = false
                };
            }
            return new Response
            {
                Message = resp.Message,
                isError = false,
                isCanceled = false
            };
        }
                
        public async Task<ConnResponse> AutoConnectAsync()
        {
            if((_status == Statuses.connected) || (_status == Statuses.updating))
            {
                return new ConnResponse
                {
                    Message = ("Connection allready established to " + _conn.Name),
                    ConnectionName = _conn.Name,
                    isError = false,
                    isCanceled = true
                };
            }
            var availableConn = _conn.GetAvailableConnections();
            for(int i = 0; i < availableConn.Length; i++ )
            {
                if(!Connect(availableConn[i]).isError)
                {
                    for (int j = 0; j < NumOfAutoConnReply; j++)
                    {
                        if ((_status == Statuses.connected)||(_status == Statuses.updating))
                        {                            
                            return new ConnResponse
                            {
                                Message = ("Connection successfull to " + availableConn[i]),
                                ConnectionName = availableConn[i],
                                isError = false,
                                isCanceled = false
                            };
                        }
                        await Task.Run(() => Thread.Sleep(ReplyTimeRequest));
                    }                    
                }
            }
            return new ConnResponse
            {
                Message = ("Can't establish connection with quadcopter"),
                isError = true,
                isCanceled = false
            };
        }
    }
}