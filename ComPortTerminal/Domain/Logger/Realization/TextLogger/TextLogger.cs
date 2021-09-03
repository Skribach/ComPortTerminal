using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Logger.Realization.TextLogger
{
    public class TextLogger
    {
        private DateTime _start;
        private Stopwatch _stopwatch;
        private List<Data> _data;

        public TextLogger()
        {
            _start = new DateTime();
            _stopwatch = new Stopwatch();
        }

        public Response Start()
        {
            if (_stopwatch.IsRunning)
            {
                throw new Exception("Trying start logger: Logger already runs");
            }
            _data = new List<Data>();
            _start = DateTime.Now;
            _stopwatch.Start();
            return new Response
            {
                Message = "Logger Successfully started",
                isError = false,
                isCanceled = false
            };
        }

        public void Log(Data data)
        {
            if (_stopwatch.IsRunning)
            {
                throw new Exception("Logger doesn't run");
            }
            data.time = _stopwatch.Elapsed;
            _data.Add(data);
        }

        public void Stop(string path)
        {
            if (!_stopwatch.IsRunning)
            {
                throw new Exception("Logger doesn't run");
            }
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_data);
                writer.Flush();
            }
            _stopwatch.Reset();
        }
    }
    public class Data
    {
        public Data()
        {

        }
        public TimeSpan time { get; set; }
        public int angleA { get; set; }
        public int angleB { get; set; }
        public int angleC { get; set; }
        public int angleD { get; set; }


        public double RPM { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        
    }
}