using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    public class Protocol
    {
        public Packet Packet { get;  private set; }
        private byte[] _buffer;
        private int _pointer;
        private int _bufferLength = 256;
        public Protocol()
        {
            Packet = new Packet();
            _buffer = new byte[_bufferLength];
            _pointer = _bufferLength/2;
        }

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

            }

            Console.WriteLine("Begin");            
            foreach(byte b in _buffer)
                Console.Write(b + " ");
            Console.WriteLine("\nEnd");
        }
    }
}