using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        private int _pointer = 0;
        private byte[] _crcData;
        private byte _crcPack;
        private Types _tempType;
        private byte[] _tempData;

        const int AngleRange = 1000;


        /// <summary>
        /// Parses byte-sequence. If packet is found, return true and rewrite itself Type, Data vars
        /// </summary>
        /// <param name="input">input byte</param>
        /// <returns></returns>
        public bool TryParse(byte input)
        {
            //Start delimiter Checking, read length
            switch (_pointer)
            {
                case (0):
                    if (input == ByteDelimiters[Delimiters.start][0])
                    {
                        _pointer++;
                        return false;
                    }
                    break;
                case (1):
                    if (input == ByteDelimiters[Delimiters.start][1])
                    {
                        _pointer++;
                        return false;
                    }
                    else
                    {
                        _pointer = 0;
                        return false;
                    }
                case (2):
                    {
                        _length = (int)input;
                        _crcData = new byte[_length - 1];
                        _crcData[0] = ByteDelimiters[Delimiters.start][0];
                        _crcData[1] = ByteDelimiters[Delimiters.start][1];
                        _crcData[2] = input;
                        _pointer++;
                        return false;
                    }
                case (3):
                    {
                        Number = (int)input;
                        _crcData[3] = input;
                        _pointer++;
                        return false;
                    }
            }

            //Type checking
            if (_pointer == 4)
            {
                _tempType = Types.unknown;

                foreach (KeyValuePair<Types, Byte> keyValue in ByteTypes)
                {
                    if (keyValue.Value == input)
                    {
                        _tempType = keyValue.Key;
                        _crcData[_pointer] = input;
                        _pointer++;
                        break;
                    }
                }
                if (_tempType == Types.unknown)
                {
                    _pointer = 0;
                }
                return false;
            }

            //Data reading
            else if ((_pointer >= 5) && (_pointer <= _length - 2))
            {
                if (_pointer == 5)
                    _tempData = new byte[_length - 6];

                _tempData[_pointer - 5] = input;
                _crcData[_pointer] = input;
                _pointer++;
                return false;
            }

            //CRC checking            
            else if (_pointer == _length - 1)
            {
                _crcPack = input;
                _pointer++;

                var _crcCalc = _hash.ComputeChecksumBytes(_crcData);

                if (_crcCalc == _crcPack)
                {
                    //Reset pointer
                    _pointer = 0;

                    //Write data from new packet
                    Type = _tempType;
                    Data = _tempData;

                    return true;

                }
                else
                {
                    _pointer++;
                    return false;
                }
            }
            return false;
        }

        public Parameters ParseParams()
        {
            return new Parameters
            {
                angles = new BladeAngles
                {
                    A = Convert.ToInt32(Data[0]),
                    B = Convert.ToInt32(Data[1]),
                    C = Convert.ToInt32(Data[2]),
                    D = Convert.ToInt32(Data[3]),
                },
                rpm = (int)BitConverter.ToInt16(Data, 4),
                gyro = new Gyro
                {
                    x = (float)BitConverter.ToInt16(Data, 6),
                    y = (float)BitConverter.ToInt16(Data, 8),
                    z = (float)BitConverter.ToInt16(Data, 10)
                }
            };
        }
    }
}