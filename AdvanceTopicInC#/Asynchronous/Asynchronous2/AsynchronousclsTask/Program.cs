using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace AsynchronousclsTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ThreadInfo(14);
            CallSynchronous();
            ThreadInfo(16);
            CallASynchronous();

            ThreadInfo(17);

            //var cntent = await ReadcontenAsync("");
            /////////////////
            CancellationToken cancellationToken = new CancellationToken();

            Action<int> Cl = (p)=> { Console.Clear(); Console.WriteLine($"{p}%"); };
            await Copy(Cl);


            //Componations
            Console.WriteLine("Using whenAny \n_______________________");
            var task1 = Task.Run(() => Has1000Sub());
            var task2 = Task.Run(() => Has4000ViewHoure());
            var any = await Task.WhenAny(task1, task2);
            Console.WriteLine(any.Result);
            Console.WriteLine("Using whenAll \n_______________________");
            var All = await Task.WhenAll(task1, task2);
            foreach (var item in All)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }


        private static void CallSynchronous()
        {
            Thread.Sleep(4000);
            ThreadInfo(26);
            Task.Run(() => { Console.WriteLine($"\n*************** Synchronous **************"); });
        }

        private static void CallASynchronous()
        {
            ThreadInfo(32);
            Task.Delay(400).GetAwaiter().OnCompleted(() => ThreadInfo(33));
                Console.WriteLine($"\n*************** ASynchronous **************");
        }


        public static void ThreadInfo(int Line)
        {
            Console.Write($" Line:{Line} , Is Background : {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"Is Thread Pool Thread : {Thread.CurrentThread.IsThreadPoolThread}");
        
        }

        static async Task<string> ReadcontenAsync(string url)
        {
            var client = new HttpClient();
            var task =  client.GetStringAsync(url);
            DoSomeThing();

            var Content = await task;  
            
            return Content;
        }

        private static void DoSomeThing()
        {
            Console.WriteLine("Working ...");
        }


        private static Task Copy(Action<int> opChange)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Delay(50).Wait();
                    if (i % 10 == 0)
                    {
                        opChange(i);
                    }
                }
            });
        }

        private static Task<string> Has1000Sub()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("Congratulation !! You Have 1000 Sub ");
        }

        private static Task<string> Has4000ViewHoure()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("Congratulation !! You Have 4000 View Houre ");
        }

    }
}