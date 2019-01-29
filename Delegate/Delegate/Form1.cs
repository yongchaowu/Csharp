using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Delegate
{
    public partial class Form1 : Form
    {
        //public Form1()
        //{
        //    InitializeComponent();
        //    int temp = 0;
        //    temp = TakesAwhile(1, 5000);
        //    ;
        //}
        //static int TakesAwhile(int data, int ms)
        //{
        //    Console.WriteLine("TakesAWhile started");
        //    Thread.Sleep(ms);
        //    Console.WriteLine("TakesAWhile Completed");
        //    return ++data;
        //}


        //----------------------------------------------------------------

        //public delegate int TakesAwhileDelegate(int data, int ms);

        //static int TakesAwhile(int data, int ms)
        //{
        //    Console.WriteLine("TakesAWhile started");
        //    Thread.Sleep(ms);
        //    Console.WriteLine("TakesAWhile Completed");
        //    return ++data;
        //}

        //public Form1()
        //{
        //    InitializeComponent();

        //    //  投票 [1/29/2019 yongchao] // asynchronous by using a delegate
        //    TakesAwhileDelegate dl = TakesAwhile;
        //    IAsyncResult ar = dl.BeginInvoke(1, 5000, null, null);
        //    while (!ar.IsCompleted)
        //    {
        //        Console.Write(".");
        //        Thread.Sleep(100);
        //    }
        //    int result = dl.EndInvoke(ar);
        //    Console.WriteLine("result: {0}", result);
        //    ;
        //}
        //------------------------------------------------------------------------------------

        //public delegate int TakesAwhileDelegate(int data, int ms);

        //static int TakesAwhile(int data, int ms)
        //{
        //    Console.WriteLine("TakesAWhile started");
        //    Thread.Sleep(ms);
        //    Console.WriteLine("TakesAWhile Completed");
        //    return ++data;
        //}

        //public Form1()
        //{
        //    InitializeComponent();

        //    //  等待句柄 [1/29/2019 yongchao] 
        //    TakesAwhileDelegate dl = TakesAwhile;
        //    IAsyncResult ar = dl.BeginInvoke(1, 5000, null, null);
        //    while (true)
        //    {
        //        Console.Write(".");
        //        if (ar.AsyncWaitHandle.WaitOne(100, false)) ;
        //        {
        //            Console.WriteLine("Can get the result now");
        //            break;
        //        }
        //    }
        //    int result = dl.EndInvoke(ar);
        //    Console.WriteLine("result: {0}", result);
        //    ;
        //}

        //------------------------------------------------------------------------------------

        //public delegate int TakesAwhileDelegate(int data, int ms);

        //static int TakesAwhile(int data, int ms)
        //{
        //    Console.WriteLine("TakesAWhile started");
        //    Thread.Sleep(ms);
        //    Console.WriteLine("TakesAWhile Completed");
        //    return ++data;
        //}
        //static void TakesAwhileCompleted(IAsyncResult ar)
        //{
        //    if (ar == null) throw new ArgumentNullException("ar");

        //    TakesAwhileDelegate dl = ar.AsyncState as TakesAwhileDelegate;
        //    Trace.Assert(dl != null, "Invoke object type");

        //    int result = dl.EndInvoke(ar);
        //    Console.WriteLine("result: {0}", result);
        //}

        //public Form1()
        //{
        //    InitializeComponent();

        //    //  异步委托 [1/29/2019 yongchao] 
        //    TakesAwhileDelegate dl = TakesAwhile;
        //    dl.BeginInvoke(1, 5000, TakesAwhileCompleted, dl);
        //    for (int i = 0; i < 100; i++ )
        //    {
        //        Console.Write("*");
        //        Thread.Sleep(200);
        //    }
        //    ;
        //}

        //------------------------------------------------------------------------------------

        public delegate int TakesAwhileDelegate(int data, int ms);

        static int TakesAwhile(int data, int ms)
        {
            Console.WriteLine("TakesAWhile started");
            Thread.Sleep(ms);
            Console.WriteLine("TakesAWhile Completed");
            return ++data;
        }
        static void TakesAwhileCompleted(IAsyncResult ar)
        {
            if (ar == null) throw new ArgumentNullException("ar");

            TakesAwhileDelegate dl = ar.AsyncState as TakesAwhileDelegate;
            Trace.Assert(dl != null, "Invoke object type");

            int result = dl.EndInvoke(ar);
            Console.WriteLine("result: {0}", result);
        }

        public Form1()
        {
            InitializeComponent();

            //  异步委托2 Lambda [1/29/2019 yongchao] 
            TakesAwhileDelegate dl = TakesAwhile;
            dl.BeginInvoke(1, 5000,
                ar =>
                {
                    int result = dl.EndInvoke(ar);
                    Console.WriteLine("result: {0}", result);
                },
                null);
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
                Thread.Sleep(200);
            }
            ;
        }

       
    }
}
