using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCTest
{
    class DataCheck
    { 
        public static byte[] GetCRC16(byte[] data)
        {
            long lCrcValue = 0xFFFF;
            long polynomial = 0xA001;
            byte[] ReturnData = new byte[data.Length+2];// CRC寄存器
            for (int i = 0; i < data.Length; i++)
            {
                ReturnData[i] = data[i];
                lCrcValue ^= data[i];// 每一个数据与CRC寄存器进行异或
                for (int j = 0; j < 8; j++)
                {

                    if ((lCrcValue & 0x1) != 0)
                    {
                        lCrcValue = (lCrcValue >> 1) ^ polynomial;
                    }
                    else
                    {
                        lCrcValue >>= 1;
                    }
                }
            }

            ReturnData[data.Length] = Convert.ToByte(lCrcValue & 0xFF);
            ReturnData[data.Length + 1] = Convert.ToByte((lCrcValue>>8) & 0xFF);
            return ReturnData;
        }

        public static bool CheckCRC16Value(int ByteLength, byte[] imbuffer)
        {
            long lCrcValue = 0xFFFF;
            long polynomial = 0xA001;

            if (ByteLength < 4)
            {
                return false;
            }
            for (int i = 0; i < (ByteLength - 2); i++)
            {
                lCrcValue ^= imbuffer[i];// 每一个数据与CRC寄存器进行异或
                for (int j = 0; j < 8; j++)
                {

                    if ((lCrcValue & 0x1) != 0)
                    {
                        lCrcValue = (lCrcValue >> 1) ^ polynomial;
                    }
                    else
                    {
                        lCrcValue >>= 1;
                    }
                }
            }

            if ((imbuffer[ByteLength - 2] == Convert.ToByte(lCrcValue & 0xFF))
                && (imbuffer[ByteLength - 1] == Convert.ToByte((lCrcValue >> 8) & 0xFF)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////////////////////////
        public enum CheckMode
        {
            CRC4    = 0x03,
            CRC8    = 0x31,
            CRC12   = 0x080D,
            CRC16   = 0x8005,
            CRC_ITU = 0x1021,
            CRC_CCITT =CRC_ITU,
            CRC32   = 0x04C11DB7,
        }
                
        /****************************************************************************
        *   Name
	            LRC_Check
        *	Type
	            public
        *	Function
	            Sum up data in buffer by byte, then inverse the result and add 1 to it
        *	Return Value
	            one-byte data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
         public static byte LRC_Check(ref byte[] buf, int nLen)
        {     	
            if (buf == null)
            {
	            return 0;
            }

            byte checknum=0;
            for (int i=0;i<nLen;i++)
            {
	            checknum+=buf[i];
            }
            checknum=Convert.ToByte(~checknum);  //c++ : checknum=~checknum;
            checknum+=1;
            checknum&=0xff;
            return checknum;
        }

        /****************************************************************************
        *   Name
	            Sum_Check
        *	Type
	            public
        *	Function
	            Sum up data in buffer by byte and get a low 8-bit value of the result
        *	Return Value
	            one-byte data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
        public static byte Sum_Check(ref byte[] buf, int nLen)
        {
        	
            if (buf == null)
            {
	            return 0;
            }

            byte checkSum = 0;
            for (int i=0; i<nLen; i++)
            {
	            checkSum += buf[i];
            }
            return checkSum;
        }

        /****************************************************************************
        *   Name
	            Xor_Check
        *	Type
	            public
        *	Function
	            XOR(exclusive or) data in buffer by byte and get a low 8-bit value of the result
        *	Return Value
	            one-byte data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
        public static byte Xor_Check(ref byte[] buf, int nLen)
        {	
            if (buf == null)
            {
	            return 0;
            }

            byte checkSum = buf[0];
            for(int i=1; i<nLen; i++)
            {
	            checkSum ^= buf[i]; 
            }
            return checkSum;
        }

        //2^bitWidth - 1. e.g. widthMask(16) = 0xFFFF.
        static long widthMask(int bitWidth)
        {
            return (((1L << (bitWidth - 1)) - 1L) << 1) | 1L;
        }

        //inverse the low  itnumbit, For example,  reflect(0x3e23,3) = 0x3e26
        static long reflect(long value, int numBits) 
        {
            long temp = value;

            for (int i = 0; i < numBits; i++) {
	            long bitMask = 1L << ((numBits - 1) - i);

	            if ((temp & 1L) != 0) {
		            value |= bitMask;
	            }
	            else {
		            value &= ~bitMask;
	            }		
	            temp >>= 1;
            }

            return value;
        }

        /****************************************************************************
        *   Name
	            CRC_Check
        *	Type
	            public
        *	Function
	            Cyclic Redundancy Check
        *	Return Value
	            a long integer data
        *	Parameters
	            buf 
		            [in]   data buffer
	            iLen 
		            [in]   buffer size
	            bitWidth 
		            [in]   the bit width, =8,16,32,64
	            polynomial 
		            [in]   CRCPolynomial
	            reflectPolynomial 
		            [in]   inverse or not
	            initialCrcValueValue 
		            [in]   crc Initial value
	            reflectInput 
		            [in]   reflect Input byte
	            reflectOupt 
		            [in]   reflect Ouput byte
	            xorOutputValue 
		            [in]   the last CRC mask
        *	Remarks:
	            calculate Method:   
		            CRC4=X4+X1+1           //0x03,0011
		            CRC8=X8+X5+X4+1        //0x31,00110001
		            CRC12=X12+X11+X3+X2+1  //0x080D,00001000 00001101
		            CRC-CCITT=X16+X12+X5+1 //0x1021,00010000 00100001
		            CRC16=X16+X15+X2+1     //0x8005,10000000 00000101    
		            CRC32=X32+X26+X23+X22+X16+X12+X11+X10+X8+X7+X5+X4+X2+X1+1 //0x04C11DB7,00000100 11000001 00011101 10110111
        *****************************************************************************/
        public static long CRC_Check(ref byte[] buf,
		               int iLen,
		               int bitWidth, 
		               long polynomial,
		               bool reflectPolynomial,
		               long initiallCrcValueValue/* = 0*/, 
		               bool reflectInput/* = 0*/,
		               bool reflectOutput/* = 0*/,
		               long xorOutputValue/* = 0*/)
        {
            //initial
            long lCrcValue = initiallCrcValueValue;

            if (!reflectPolynomial)
            {
	            long topBit = 1L << (bitWidth - 1);
	            for (int ix = 0; ix < iLen; ix++)
	            {
		            //CRC main Process 
		            if (reflectInput) {
			            buf[ix] =  Convert.ToByte(reflect(buf[ix], 8) ); //c++ :  static_cast<BYTE>(reflect(buf[ix], 8));
		            }
        			
		            lCrcValue ^= (buf[ix] << (bitWidth - 8));

		            for (int i = 0; i < 8; i++) {
			            if ((lCrcValue & topBit) != 0) {
				            lCrcValue = (lCrcValue << 1) ^ polynomial;
			            }
			            else {
				            lCrcValue <<= 1;
			            }
			            //
			            lCrcValue &= widthMask(bitWidth);
		            }		
	            }
            }
            else
            {
	            long topBit = 1L;
	            polynomial = reflect(polynomial, bitWidth);
	            for (int ix = 0; ix < iLen; ix++)
	            {
		            //CRC main Process 			
		            if (reflectInput) {
			            buf[ix] = Convert.ToByte(reflect(buf[ix], 8) ); //c++ :  static_cast<BYTE>(reflect(buf[ix], 8));
		            }

		            lCrcValue ^= buf[ix] ;

		            for (int i = 0; i < 8; i++) {
			            if ((lCrcValue & topBit) != 0) {
				            lCrcValue = (lCrcValue >> 1) ^ polynomial;
			            }
			            else {
				            lCrcValue >>= 1;
			            }
			            lCrcValue &= widthMask(bitWidth);
		            }		
	            }
            }
        	
            lCrcValue = xorOutputValue ^ lCrcValue;

            if (reflectOutput) {
	            lCrcValue = xorOutputValue ^ reflect(lCrcValue, bitWidth);
            }
            return lCrcValue;
        }

        /****************************************************************************
        *   Name
	            CRC16_CHECK_REVERSE
        *	Type
	            public
        *	Function
	            16-bits Cyclic Redundancy Check (reverse every bit)
        *	Return Value
	            a long integer data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
        public static UInt16 CRC16_CHECK_REVERSE(ref byte[] buf, int nLen)
        {
            return Convert.ToUInt16(CRC_Check(ref buf, nLen, 16, (long)CheckMode.CRC16, true, 0xFFFF, false, false, 0));//(WORD)CRC_Check(buf, nLen, 16, CRC16, true, 0xFFFF);
        	
        }

        /****************************************************************************
        *   Name
	            CRC16_CHECK
        *	Type
	            public
        *	Function
	            16-bits Cyclic Redundancy Check 
        *	Return Value
	            a long integer data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
        public static UInt16 CRC16_CHECK(ref byte[] buf, int nLen)
        {
            return Convert.ToUInt16(CRC_Check(ref buf, nLen, 16, (long)CheckMode.CRC16, false, 0, false, false, 0));//(WORD)CRC_Check(buf, nLen, 16, CRC16, 0);
        	
        }

        /****************************************************************************
        *   Name
	            MODBUS_CRC_CHECK
        *	Type
	            public
        *	Function
	            Mobus protocol Cyclic Redundancy Check 
        *	Return Value
	            a long integer data.
        *	Parameters
	            buf 
		            [in]  data buffer
	            nLen
		            [in]  the length of data 
        *****************************************************************************/
        public static UInt16 MODBUS_CRC_CHECK(ref byte[] buf, int nLen)
        {
            return CRC16_CHECK_REVERSE(ref buf, nLen);
        }


    }
}
