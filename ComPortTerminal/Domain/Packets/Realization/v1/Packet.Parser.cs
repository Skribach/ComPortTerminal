using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Packets.Realization.v1
{
    public partial class Packet
    {
        private int _pointer = 0;
        private byte[] _crcData;
        private byte[] _crcPack = new byte[2];
        private Types _tempType;
        private byte[] _tempData;


        /// <summary>
        /// Parses byte-sequence. If packet is found, return true and rewrite itself Type, Data vars
        /// </summary>
        /// <param name="input">input byte</param>
        /// <returns></returns>
        public bool Parser(byte input)
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
                    _length = (int)input;
                    _pointer++;
                    return false;
            }
            
            //Type checking
            if (_pointer == 3)
            {
                _tempType = Types.unknown;
                _crcData = new byte[_length - 6];
                foreach (KeyValuePair<Types, Byte> keyValue in ByteTypes)
                {
                    if (keyValue.Value == input)
                    {
                        _tempType = keyValue.Key;

                        _crcData[_pointer - 3] = (byte)_length;
                        _crcData[_pointer - 2] = input;
                        _pointer++;
                        break;
                    }
                }
                if (_tempType == Types.unknown)
                {
                    _pointer = 0;
                    return false;
                }
                return false;
            }

            //Data reading
            else if ((_pointer >= 4) && (_pointer < _length - 4))
            {
                if (_pointer == 4)
                    _tempData = new byte[_length - 8];

                _tempData[_pointer - 4] = input;
                _crcData[_pointer - 2] = input;
                _pointer++;
                return false;
            }

            //CRC checking            
            else if (_pointer == _length - 4)
            {
                _crcPack[0] = input;
                _pointer++;
                return false;
            }
            else if (_pointer == _length - 3)
            {
                _crcPack[1] = input;

                var _crcCalc = _hash.ComputeChecksumBytes(_crcData);

                if ((_crcCalc[0] == _crcPack[0]) && (_crcCalc[1] == _crcPack[1]))
                {
                    _pointer++;
                    return false;
                }
                else
                {
                    _pointer = 0;
                    return false;
                }
            }
            //End delimiters validations
            else if (_pointer == _length - 2)
            {
                if (input == ByteDelimiters[Delimiters.end][0])
                {
                    _pointer++;
                    return false;
                }
                _pointer = 0;
                return false;
            }
            else if (_pointer == _length - 1)
            {
                if (input == ByteDelimiters[Delimiters.end][1])
                {
                    //Reset pointer
                    _pointer = 0;

                    //Write data from new packet
                    Type = _tempType;
                    Data = _tempData;

                    return true;
                }
                _pointer = 0;
                return false;
            }
            _pointer = 0;
            return false;
        }
    }
}