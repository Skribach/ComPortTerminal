using System;
using static QuadcopterConfigurator.Domain.Packets.Realization.v1.Packet;

namespace crc_check
{
    class Program
    {
        static void Main(string[] args)
        {
            var _crc = new Crc8();

            byte b = 0;
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(_crc.ComputeChecksumBytes(new byte[] { b }));
                b++;
            }

            Console.ReadLine();
        }
    }
}
