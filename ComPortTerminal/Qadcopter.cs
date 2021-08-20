using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal
{
    
    public class Qadcopter<T>
    {
        public Qadcopter(T minValue, T maxValue, T step)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Step = step;
        }

        public T MinValue { get; }
        public T MaxValue { get; }
        public T Step { get; }

        public T leftTop;
        public T righTop;
        public T leftBot;
        public T rightBot;
    }
}
