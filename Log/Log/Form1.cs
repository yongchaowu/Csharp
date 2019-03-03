using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Log
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Logfile logT = new Logfile("./");
            //int i = 0;
            //while (true)
            //{
            //    i++;
            //    logT.Log("ttttttt", "GO");
            //    if (i > 5000)
            //    {
            //        break;
            //    }
            //}

            LogfileExport logTT = new LogfileExport();
            int i = 0;
            while (true)
            {
                i++;
                logTT.Log(i.ToString());
                if (i > 100000)
                {
                    break;
                }
            }
           
        }
    }
}
