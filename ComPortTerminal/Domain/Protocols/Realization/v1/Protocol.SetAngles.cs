using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Packets.Realization.v1;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {       
        //Parameters from user GUI
        private BladeAngles _currentAngles { get; set; }        

        //Previous installed parameters
        private BladeAngles _prevAngles { get; set; }

        private int _i = 0;
        private bool _isSetting = false;

        public async Task<Response> SetAnglesAsync(BladeAngles angles)
        {            
            //Reset reciever counter
            if (_status == Statuses.updating)
            {                
                _currentAngles = angles;
                _i = 0;
            }
            else if (_status == Statuses.connected)
            {
                _prevAngles = _currentAngles;
                _currentAngles = angles;
            }
            //If no established connection
            if (_status == Statuses.disconnected)
            {
                _isSetting = false;
                return new Response
                {
                    Message = "ERROR: No established connection. Please connect to link",
                    isError = true,
                    isCanceled = false
                };
            }
            //If angles already pushes
            if((_status == Statuses.updating)&&(_isSetting))
                return new Response
                {
                    Message = "Angles installation already",
                    isError = false,
                    isCanceled = true
                };

            _id++;
            _status = Statuses.updating;
            _isSetting = true;
            for (; _i < NumOfReply; _i++)
            {
                if (_status == Statuses.connected)
                {
                    _isSetting = false;
                    return new Response
                    {
                        Message = "Angles successfully installed",
                        isError = false,
                        isCanceled = false
                    };
                }
                else if(_status == Statuses.disconnected)
                {
                    _isSetting = false;
                    return new Response
                    {
                        Message = "Connection is lost",
                        isError = true,
                        isCanceled = false
                    };
                }
                _conn.Write(_packet.SetAngle(_currentAngles, _id));     
                await Task.Run(() => Thread.Sleep(ReplyTimeRequest));
            }
            _status = Statuses.disconnected;
            return new Response
            {
                Message = "ERROR: Connection fail",
                isError = true
            };
        }
    }
}