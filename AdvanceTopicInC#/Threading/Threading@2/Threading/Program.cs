using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Process ID : {Process.GetCurrentProcess().Id}");
            Console.WriteLine($"Thread ID  : {Thread.CurrentThread.ManagedThreadId}");
           // Console.WriteLine($"Processor ID : {0}");

         

            var wallet = new Wallet( 50, "Munzer");
            Thread t1 = new Thread(() => wallet.Debit(20));
            Thread t2 = new Thread(() => wallet.Debit(40));
            t2.Start();
            t1.Start();

            Console.WriteLine(wallet.ToString());
            Console.WriteLine("----------------------------------------");
            object p = new object();    
            WaitCallback waitCallback = new WaitCallback(p);
            ThreadPool.QueueUserWorkItem(waitCallback);

            Task.Run(Print);
            
            Console.ReadKey();

        }
        public static void Print()
        {
            Console.WriteLine("print !");
        }

    }

    public class Wallet
    {
      
        public Wallet(int bitcoins, string name)
        {
            this.Bitcoins = bitcoins;
            this.name = name;
        }

        public int Bitcoins { get; set; }
        public string name { get; set; }
        private object LockObject = new object();
        public void Debit(int amount)
        {
            lock (LockObject)
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);
                    Bitcoins -= amount;
                }
            }
        }

        public void Credit(int amount)
        {
            Bitcoins += amount;
        }
        public void RunRandomTransactions()
        {
            int[] amounts = { 10, 20, -30, 40, 10, -10, 20, -40, 50 };
            foreach(var s in amounts) 
            {
                if(s < 0)
                    Debit(s);
                else
                    Credit(s);
                Console.WriteLine(this.ToString());
            }
        }

        public override string ToString()
        {
            return $"{name} -> {Bitcoins} Bitcoins";
        }

    }



}
