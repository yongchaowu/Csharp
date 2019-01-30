using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        static void TaskMehtod()
        {
            Console.WriteLine("runnint in a task");
            Console.WriteLine("Task id: {0}",Task.CurrentId);
        }
        static void TaskMehtod2(Task t)
        {
            Console.WriteLine("task {0} finished",t.Id);
            Console.WriteLine("Task id: {0}", Task.CurrentId);
        }
        static void Main(string[] args)
        {
            //using task factory
            TaskFactory tf = new TaskFactory();
            Task tl = tf.StartNew(TaskMehtod);

            //using the task factory via a task
            Task t2 = Task.Factory.StartNew(TaskMehtod);

            // using Task constructor
            Task t3 = new Task(TaskMehtod);
            t3.Start();
            //TaskCreationOptions
            Task t4 = new Task(TaskMehtod, TaskCreationOptions.PreferFairness);
            t4.Start();
            // ContinueWith  连续任务
            Task t5 = t4.ContinueWith(TaskMehtod2);
            // TaskContinuationOptions 指定连续任务启动条件 
            Task t6 = t5.ContinueWith(TaskMehtod2, TaskContinuationOptions.OnlyOnRanToCompletion);
            ;


            // 层次结构  在Task中 new一个Task

            // 任务的结果 泛型类Task<TResult>   Task实例的Result属性
            /*
             任务结束时,它可以把一些有用的状态信息写到共享对象中。这个共享对象必须是线程安全的。
             另一个选项是使用返回某个结果的任务。使用Task类的泛型版本,就可以定义返回某个结果的任务的返回类型
             */

            while (true)
            {
                ;
            }
        }
    }
}
