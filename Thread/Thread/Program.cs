using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var t1 = new Thread(ThreadMain);
        //    t1.Start();
        //    Console.WriteLine("This is the main thread.");
        //    int time = 10;
        //    while (time-- != 0)
        //    {
        //        Console.WriteLine("*");
        //    }
        //}

        //static void ThreadMain()
        //{
        //    Console.WriteLine("Running in a thread");
        //    int time = 10;
        //    while (time-- != 0)
        //    {
        //        Console.WriteLine(".");
        //    }
        //}

        //----------------------------------------------------------------
        //static void Main(string[] args)
        //{
        //    var t1 = new Thread(()=> {
        //        Console.WriteLine("running in a thread, id:{0}", Thread.CurrentThread.ManagedThreadId);
        //        int time = 10;
        //        while (time-- != 0)
        //        {
        //            Console.WriteLine(".");
        //        }
        //    });
        //    t1.Start();
        //    Console.WriteLine("This is the main thread. id :{0}",Thread.CurrentThread.ManagedThreadId);
        //    int time2 = 10;
        //    while (time2-- != 0)
        //    {
        //        Console.WriteLine("*");
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------
        // ThreadPool [1/30/2019 yongchao]
        static void Main(string[] args)
        {
            int nWorkerThreads;
            int nCompletionPortThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Max worker threads: {0}," +
                "I/O completion threads: {1}",
                nWorkerThreads, nCompletionPortThreads);

            for (int i = 0; i < 5;i++ )
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);
            }
            Thread.Sleep(3000);
        }

        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3;i++ )
            {
                Console.WriteLine("loop {0},running inside pooled thread {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }



    }
}
