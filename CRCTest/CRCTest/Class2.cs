using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCTest
{
    class Class2// This may be wrong
    {
        public static  UInt16  Cal_crc16(byte[] data, int size)
        {
 
            UInt32 i = 0;
            UInt16 crc = 0;
            for (i = 0; i < size; i++)
            {
                crc = UpdateCRC16(crc, data[i]);
            }
            crc = UpdateCRC16(crc, 0);
            crc = UpdateCRC16(crc, 0);
 
            return (UInt16)(crc);
        }
        public static UInt16  UpdateCRC16(UInt16  crcIn, byte  bytee)
        {
            UInt32  crc = crcIn;
            UInt32  ins =(UInt32)bytee | 0x100;
 
            do
            {
                crc <<= 1;
		       ins <<= 1;
                if ((ins & 0x100)==0x100 )
		       {
                    ++crc;
                }
                if ((crc & 0x10000)==0x10000)
                {
                    crc ^= 0x1021;
                }
            }
            while (!((ins&0x10000)==0x10000) );
            return (UInt16 )crc;
        }     
    }
}
