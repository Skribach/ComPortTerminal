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

        public bool isRunning { private set; get; }

        public TextLogger()
        {
            _start = new DateTime();
            _stopwatch = new Stopwatch();
            isRunning = false;
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
            isRunning = true;
            return new Response
            {
                Message = "Logger Successfully started",
                isError = false,
                isCanceled = false
            };
        }

        public void Log(Parameters param)
        {
            if (!_stopwatch.IsRunning)
            {
                throw new Exception("Logger doesn't run");
            }
            _data.Add(new Data
            {
                time = _stopwatch.Elapsed,

                Angle1 = param.Angles.A,
                Angle2 = param.Angles.B,
                Angle3 = param.Angles.C,
                Angle4 = param.Angles.D,

                X = param.Gyro.x,
                Y = param.Gyro.z,
                Z = param.Gyro.z,

                RPM = param.Rpm,
            });
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
            isRunning = false;
        }
    }
    public class Data
    {
        public Data()
        {

        }
        public TimeSpan time { get; set; }

        public int Angle1 { get; set; }
        public int Angle2 { get; set; }
        public int Angle3 { get; set; }
        public int Angle4 { get; set; }

        public float RPM { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }


    }
}