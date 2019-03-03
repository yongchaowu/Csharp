using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRCTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // string msg = "01 2C 00 00 00 00 00 00 0A 4F 4F 05 93 00 07 06 15 00 00 00 23 3D F5 7C 45 71 20 00 45 71 20 00 00 00 00 00 40 DF 70 E3 00 00 00 00 BF 8F D6 63 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3D F9 00 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 8E 47 99 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3D FC 84 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 8A FD 76 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 00 08 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 92 C7 B9 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 03 8C 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 8A A4 FD 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 07 10 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 8D EE CC 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 0A 94 45 71 20 00 45 71 20 00 00 00 00 00 00 00 00 00 00 00 00 00 BF 88 38 B0 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 0E 18 45 71 40 00 45 71 50 00 00 00 00 00 41 1F D4 4B 00 00 00 00 BF 7C 04 97 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 11 9C 45 71 70 00 45 71 70 00 00 00 00 00 41 15 7B 74 00 00 00 00 BF 8E A0 12 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00 23 3E 15 20 45 71 90 00 45 71 90 00 00 00 00 00 40 E1 D9 FE 00 00 00 00 BF 8C E5 0D 00 00 00 00 00 00 00 00 10 20 00 00 41 30 00 00";
            string msg = "01 02 03 01 02 03";
            var a = CRC.ToCRC16(msg, true);          //结果为：
            var b = CRC.ToCRC16(msg, false);           //结果为：
            var c = CRC.ToModbusCRC16(msg, true);      //结果为：
            var e = CRC.ToModbusCRC16(msg, false);
            var d = CRC.ToCRC16("你好，我们测试一下CRC16算法", true);   //结果为：

            byte[] bT = Encoding.ASCII.GetBytes(msg);
            var tt = CRC.CRC16(bT);

            //byte[] bTT = Class1.CRC16(bT);

            byte[] array = new byte[] { 0x30, 0x31, 0x30, 0x32, 0x30, 0x33, 0x30, 0x31, 0x30, 0x32, 0x30, 0x33 };
            byte[] bTT = Class1.CRC16(array);
            byte[] Temp = new byte[] { 0x30, 0x31, 0x30, 0x32, 0x30, 0x33, 0x30, 0x31, 0x30, 0x32, 0x30, 0x33,0x10,0xD9};
            bool g = Class1.CheckCRC(Temp.Length, Temp);

            byte[] dataCrc = DataCheck.GetCRC16(array);

            UInt16 uTemp = DataCheck.MODBUS_CRC_CHECK(ref array, array.Length);
            byte[] CRCbyte = new byte[2];
            CRCbyte[0] = Convert.ToByte(uTemp & 0xFF);
            CRCbyte[1] = Convert.ToByte((uTemp >> 8) & 0xFF);

            UInt16 crc = Class2.Cal_crc16(array, array.Length);
            var a1 = CRC.ToCRC16(array.ToString(), true);          //结果为：
            var b1 = CRC.ToCRC16(array.ToString(), false);           //结果为：
            //var c1 = CRC.ToModbusCRC16(array.ToString(), true);      //结果为：
            //var e1 = CRC.ToModbusCRC16(array.ToString(), false);

            var f = Class3.CRC16(array, array.Length);
        }
    }
}
