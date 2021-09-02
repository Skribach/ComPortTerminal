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
        private string _folderPath;
        private DateTime _start;
        private Stopwatch _stopwatch;
        private List<Data> _data;

        public TextLogger(string folderPath)
        {
            _data = new List<Data>();
            _folderPath = folderPath;

            _start = new DateTime();
            _stopwatch = new Stopwatch();
        }

        public Response Start()
        {
            if (_stopwatch.IsRunning)
            {
                return new Response
                {
                    Message = "Textlogger is Already runing",
                    isError = false,
                    isCanceled = true
                };
            }

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

        public void Stop()
        {
            if (!_stopwatch.IsRunning)
            {
                throw new Exception("Logger doesn't run");
            }
            string filePath = _folderPath + @"\" + _start.ToString().Replace(":", "-") + ".csv";
            using (var writer = new StreamWriter(filePath))
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

        public double angleX { get; set; }
        public double angleY { get; set; }
        public double angleZ { get; set; }

        public double rpm { get; set; }
    }
}