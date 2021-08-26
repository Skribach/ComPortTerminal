using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Connection;

namespace ComPortTerminal
{
    public class Qadcopter
    {
        private Protocol _protocol;

        private Connection _conn;
        public Qadcopter(int leftTop, int rightTop, int leftBot, int rightBot, int minValue, int maxValue, Connection conn)
        {
            LeftTop = leftTop;
            RightTop = rightTop;
            LeftBot = leftBot;
            RightBot = rightBot;

            MinValue = minValue;
            MaxValue = maxValue;
            _conn = conn;
            _protocol = new Protocol();
        }
        public int LeftTop { get; private set; }
        public int RightTop { get; private set; }
        public int LeftBot { get; private set; }
        public int RightBot { get; private set; }

        public int MinValue { get; }
        public int MaxValue { get; }
        public int Step { get; }

        public ConnectResponse Connect()
        {
            var conn_resp = _conn.Connect();
            _conn.SetRecieveHandler(Reciever);
            var request = _protocol.Packet.CreateConnectionRequest(65);//

            //For Test
            Console.WriteLine("Output packet:");
            foreach (byte b in request)
                Console.Write(String.Format(" 0x{0:X}", b));
            Console.WriteLine();

            _conn.Write(request);

            return conn_resp;
        }

        void Reciever(byte input)
        {
            _protocol.RecieveHandler(input);
        }

        #region Set methods
        public int SetLeftTop(string str) => SetXY(str, LeftTop);
        public int SetLeftTop(int val) => SetXY(val, LeftTop);
        public int SetRightTop(string str) => SetXY(str, RightTop);
        public int SetRightTop(int val) => SetXY(val, RightTop);
        public int SetLeftBot(string str) => SetXY(str, LeftBot);
        public int SetLeftBot(int val) => SetXY(val, LeftBot);
        public int SetRightBot(string str) => SetXY(str, RightBot);
        public int SetRightBot(int val) => SetXY(val, RightBot);
        #endregion

        #region Support functions
        //Sets angle for xy blade
        public int SetXY(string str, int xy)
        {
            int num;
            bool isParsible = int.TryParse(str, out num);
            if (!isParsible)
            {
                xy = MaxValue;
                return MaxValue;
            }
            else if (num < MinValue)
            {
                xy = MinValue;
                return MinValue;
            }
            else if (num > MaxValue)
            {
                xy = MaxValue;
                return MaxValue;
            }
            else
            {
                xy = num;
                return num;
            }
        }
        public int SetXY(int val, int xy)
        {
            if (val < MinValue)
            {
                xy = MinValue;
                return MinValue;
            }
            else if (val > MaxValue)
            {
                xy = MaxValue;
                return MaxValue;
            }
            else
            {
                xy = val;
                return val;
            }
        }

        private byte[] ToByte(string line)
        {
            byte[] output = new byte[line.Length];
            for (int i = 0; i < line.Length; i++)
                output[i] = (byte)(line[i]);
            return output;
        }
        #endregion
    }
}