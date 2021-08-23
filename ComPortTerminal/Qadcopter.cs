using ComPortTerminal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    
    public class Qadcopter
    {
        public Qadcopter(int leftTop, int rightTop, int leftBot, int rightBot,  int minValue, int maxValue, Connection conn)
        {
            LeftTop = leftTop;
            RightTop = rightTop;
            LeftBot = leftBot;
            RightBot = rightBot;

            MinValue = minValue;
            MaxValue = maxValue;
            _conn = conn;
        }
        public int LeftTop { get; private set; }
        public int RightTop { get; private set; }
        public int LeftBot { get; private set; }
        public int RightBot { get; private set; }

        public int MinValue { get; }
        public int MaxValue { get; }
        public int Step { get; }

        private Connection _conn;

        public Connect.Response Connect()
        {            
            if (_conn.Name == null)
            {
                return new Connect.Response
                {
                    Message = "COM-port need to be selected;",
                    isError = true
                };
            }
            try
            {
                _conn.Connect();
                _conn.Write("Hello world");
            }
            catch (Exception ex)
            {
                return new Connect.Response
                {
                    Message = "ERROR: Another instance connected to " + _conn.Name,
                    isError = true
                };
            }
            return new Connect.Response
            {
                Message = "Connection test successfull to " + _conn.Name,
                isError = false
            };
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
        #endregion
    }
}
