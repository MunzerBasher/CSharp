using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyAndparallelim
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var Thing = new List<DailyOuty>
            {
                new DailyOuty("jjkkk"),
                new DailyOuty("jjkkk"),
                new DailyOuty("jjkkk"),
                new DailyOuty("jjkkk")
            };
            //Console.WriteLine("Using Parallel Process");
            //var task = Task.Run(() => ParallelProcess(Thing));
            //await task;
            Console.WriteLine("Using Concurrent Process");
            var task1 = Task.Run(() => ConcurrentProcess(Thing));
            Console.ReadKey();
        }
        private static Task ParallelProcess(IEnumerable<DailyOuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process("Parallel"));

            return Task.CompletedTask;
        }


        private static Task ConcurrentProcess(IEnumerable<DailyOuty> things)
        {
            foreach (var thing in things) 
            {
                thing.Process("Concurrent");
            }

            return Task.CompletedTask;
        }
    }

    public class DailyOuty
    {
        public string Arg;
        public DailyOuty(string arg)
        {
            this.Arg = arg;
        }

        public void Process(string stata)
        {
            Console.Write($"{stata} Theard :{Thread.CurrentThread.ManagedThreadId}\t\t");
            Console.WriteLine($"Arg -> {Arg}");
            Task.Delay(2000);
        }
    }
}