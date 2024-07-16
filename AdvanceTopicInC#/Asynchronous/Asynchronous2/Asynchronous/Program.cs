using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Thread th = new Thread(() => Desplay("From Thread ?"));
            th.Start();
            th.Join();
            Task.Run(() => Desplay("From Task ?")).Wait();
            Task<DateTime> task = Task.Run(() => DateTime.Now);
            Console.WriteLine(task.Result);

            /////////runLongtasks
            var task1 = Task.Factory.StartNew(() => RunLongtasks(),
                TaskCreationOptions.LongRunning);

           
            Console.ReadKey();
        }

        private static void RunLongtasks()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Run Long Tasks...! ");
            ThreadInfo();
        }
        public static void ThreadInfo()
        {
            Console.WriteLine($"Is Background : {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"Is Thread Pool Thread : {Thread.CurrentThread.IsThreadPoolThread}");
        }

        public static void Desplay(string args)
        {
            Console.WriteLine(args);
            ThreadInfo();
        }
    }
}