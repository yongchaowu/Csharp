using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string devid = "00FFAACCSS";
            string value = "SV";
            byte[] byteDevID = Encoding.Default.GetBytes(devid);
            byte[] byteValue = Encoding.Default.GetBytes(value);


            //byte byteDevID1 = Convert.ToByte(devid, 16);//0x0001 ok ; 0x0201 error
            //UInt16 uDevID = Convert.ToUInt16(devid, 16);

            //byte t1 = Convert.ToByte(devid, 16);


            int length = byteDevID.Length;
            byte[] eqIDLen = BitConverter.GetBytes(length);
            byte len = (byte)byteDevID.Length;

            string devid1 = devid.Substring(0, 2);
            string devid2 = devid.Substring(2, 2);
            string devid3 = devid.Substring(8, 2);
            byte byteDevID1 = Convert.ToByte(devid1, 16);
            byte byteDevID2 = Convert.ToByte(devid2, 16);
            //byte byteDevID3 = Convert.ToByte(devid3, 16); // 非16进制不支持。

            string eqpID = "0123";
            byte[] eqpIDByte = BitConverter.GetBytes(Convert.ToUInt16(eqpID, 16));

            string strIP = "172.30.20.31";
            byte lenIP = (byte)strIP.Length;
            byte[] bIP = Encoding.Default.GetBytes(strIP);




            Console.ReadKey();
        }

        //public static byte[] GetBytes(string hexString, outint discarded)

        //{            

        //discarded = 0;

        //string newString = "";

        //char c;// remove all none A-F, 0-9, characters
        
        //for (int i=0; i<hexString.Length; i++)

        //{              

        //  c = hexString[i];
        //if (IsHexDigit(c))                    

        //    newString += c;

        //else                    

        //    discarded++;            

        //}// if odd number of characters, discard last character
        //if (newString.Length % 2 != 0){                
        //    discarded++;                

        //newString = newString.Substring(0, newString.Length-1);            
        //}

        //int byteLength = newString.Length / 2;
        //    byte[] bytes = new byte[byteLength];
        //    string hex;int j = 0;
        //    for (int i=0; i<bytes.Length; i++)
        //    {               

        // hex = new String(new Char[] {newString[j], newString[j+1]});               

        // bytes[i] = HexToByte(hex);  
        //  j = j+2;           

        // }

        //return bytes;       

        // }
    }
}
