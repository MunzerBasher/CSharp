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
        private static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Method1 : " + i);
            }
        }

        private static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Method2 : " + i);
            }
        }

        static void Main(string[] args)
        {

            Wallet wallet1 = new Wallet(1, 30);
           

            Thread t1 = new Thread(() => wallet1.Mineas(22));
            Thread t2 = new Thread(() => wallet1.Mineas(20));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            

            Console.ReadKey();

        }
    }

    public class Wallet
    {
        public Wallet(int id, int monay)
        {
            this.id = id;
            this.Monay = monay;
        }

        public int id { get; set; }
        public int Monay { get; set; }
        private object Lock = new object();

        public void Mineas(int monay)
        {
            lock (Lock)
            {
                if (Monay > monay)
                {
                    Thread.Sleep(1000);
                    Monay -= monay;
                }
                Console.WriteLine(this.ToString());
            } 
        }

        public override string ToString()
        {
            return $"Monay is -> {Monay}";
        }



    }

    

}