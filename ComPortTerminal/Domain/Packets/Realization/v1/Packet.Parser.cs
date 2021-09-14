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

        /// <summary>
        /// Parses byte-sequence. If packet is found, return true and rewrite itself Type, Data vars
        /// </summary>
        /// <param name="input">input byte</param>
        /// <returns></returns>
        public bool TryParse(byte input)
        {
            try
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
                }

                //Type checking
                if (_pointer == 3)
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
                else if ((_pointer >= 4) && (_pointer <= _length - 2))
                {
                    if (_pointer == 4)
                        _tempData = new byte[_length - 5];

                    _tempData[_pointer - 4] = input;
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
                _pointer = 0;
                return false;

            }
            catch
            {
                _pointer = 0;
                return false;
            }
        }

        public Parameters GetParams()
        {
            return new Parameters
            {
                id = (int)Data[0],
                rpm = (int)BitConverter.ToUInt16(Data, 1),
                gyro = new Gyro
                {
                    x = BitConverter.ToSingle(Data, 3),
                    y = BitConverter.ToSingle(Data, 5),
                    z = BitConverter.ToSingle(Data, 7)
                }
            };
        }
    }
}