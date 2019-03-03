using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCTest
{
    class Class1// This is True,work Good
    {

        /// <summary>
        /// CRC码计算,返回数组中,0为低位,1为高位
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] CRC16(byte[] data)
        {
            byte CRC16Lo = 0;
            byte CRC16Hi = 0;
            byte CL = 0;
            byte CH = 0;
            byte SaveHi = 0;
            byte SaveLo = 0;
            byte[] ReturnData = new byte[2];// CRC寄存器
            // 多项式码&HA001
            CRC16Lo = (byte)0xFF;
            CRC16Hi = (byte)0xFF;
            CL = (byte)0x1;
            CH = (byte)0xA0;

            for (int i = 0; i < data.Length; i++)
            {
                CRC16Lo = Convert.ToByte(CRC16Lo ^ data[i]);// 每一个数据与CRC寄存器进行异或
                for (int j = 0; j < 8;j++ )
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = Convert.ToByte(CRC16Hi >>1);// 高位右移一位
                    CRC16Lo = Convert.ToByte(CRC16Lo >>1);// 低位右移一位
                    if ((SaveHi & 0x1) == 0x1)
                    {
                        // 如果高位字节最后一位为1
                        CRC16Lo = Convert.ToByte(CRC16Lo | 0x80);
                        // 则低位字节右移后前面补1
                    }
                    // 否则自动补0
                    if ((SaveLo & 0x1) == 0x1)
                    {
                        // 如果LSB为1，则与多项式码进行异或
                        CRC16Hi = Convert.ToByte(CRC16Hi ^ CH);
                        CRC16Lo = Convert.ToByte(CRC16Lo ^ CL);
                    }
                }
            }
            ReturnData[0] = CRC16Lo;// CRC低位
            ReturnData[1] = CRC16Hi;// CRC高位
            return ReturnData;
        }

        public static bool CheckCRC(int ByteLength, byte[] imbuffer)
        {
            int i, j, k = 0;
            byte hi, lo, c1, c2;
            hi = 0xff;
            lo = 0xff;
            if (ByteLength < 4)
            {
                return false;
            }
            for (i = 0; i < (ByteLength - 2); i++)
            {
                lo = (byte)(lo ^ imbuffer[k]);
                for (j = 0; j < 8; j++)
                {
                    c1 = lo;
                    c2 = hi;
                    lo = (byte)(lo >> 1);
                    hi = (byte)(hi >> 1);
                    if ((c2 & 0x01) != 0)
                    {
                        lo = (byte)(lo | 0x80);
                    }
                    if ((c1 & 0x01) != 0)
                    {
                        hi = (byte)(hi ^ 0xa0);
                        lo = (byte)(lo ^ 0x01);
                    }
                }
                k++;
            }
            c1 = imbuffer[k];
            k++;
            c2 = imbuffer[k];

            if ((c1 == lo) && (c2 == hi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
