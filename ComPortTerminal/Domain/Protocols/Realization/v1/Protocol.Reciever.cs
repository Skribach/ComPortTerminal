using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {        
        public void RecieveHandler(byte input)
        {
            if (_pointer == _bufferLength)
            {
                for(int i = 0; i < _bufferLength/2; i++)
                {
                    _buffer[i] = _buffer[_bufferLength / 2 + i];
                    _buffer[_bufferLength / 2 + i] = 0;
                }
                _pointer = _bufferLength/2;
            }

            _buffer[_pointer++] = input;
            
            if(Packet.Parser(_buffer))
            {
                _pointer = _bufferLength / 2;
                for (int i = 0; i < _buffer.Length; i++)
                    _buffer[i] = 0;
            }

            Console.WriteLine("Begin");            
            foreach(byte b in _buffer)
                Console.Write(b + " ");
            Console.WriteLine("\nEnd");
        }
    }
}