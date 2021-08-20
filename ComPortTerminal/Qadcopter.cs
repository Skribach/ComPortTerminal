using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    
    public class Qadcopter<T>
    {
        public Qadcopter(T leftTop, T rightTop, T leftBot, T rightBot,  T minValue, T maxValue)
        {
            LeftBot = leftBot;
            RightTop = rightTop;
            LeftBot = leftBot;
            RightBot = rightBot;

            MinValue = minValue;
            MaxValue = maxValue;
        }

        public T MinValue { get; }
        public T MaxValue { get; }
        public T Step { get; }

        public T LeftTop;
        public T RightTop;
        public T LeftBot;
        public T RightBot;
    }
}
