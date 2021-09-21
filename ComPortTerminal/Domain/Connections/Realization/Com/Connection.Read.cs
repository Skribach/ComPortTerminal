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
        //Delegates to be used as handler for read 
        public delegate void ReadString(string indata);
        public delegate void ReadBytes(byte[] indata);
        public delegate void ReadByte(byte indata);

        private ReadByte _recieverHandler;
        public void SetRecieveHandler(ReadByte handler)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(InternalReciever);
            _recieverHandler += handler;
        }
        void InternalReciever(object sender, SerialDataReceivedEventArgs e)
        {            
            SerialPort sp = (SerialPort)sender;
            while (sp.BytesToRead != 0)
            {
                Console.WriteLine(sp.BytesToRead);
                _recieverHandler((byte)sp.ReadByte());
            }
        }
    }
}