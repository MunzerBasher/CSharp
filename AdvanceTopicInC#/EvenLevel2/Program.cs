using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Print = System.Math;

public delegate void DGPrint(string message);
namespace EvenLevel2
{
   
    internal class Program
    {
        Nullable<int> n = null;
        int? m = null;
        static Func <int,int > Squ = Math;
        static Func<int, int> Squ1 = x => x* x;
        public static int Math(int x)
        {
            return x * x;
        }
        
        public static void method1(string message)
        {
            Console.WriteLine("Method 1 "  + message);
        }

        public static void method3(string message)
        {
            Console.WriteLine("___________________" + message);
        }

        public static void method2(string message)
        {
            Console.WriteLine("Method 2 " + message);
        }

        public static void New_method(string message)
        {
            Console.WriteLine("New_Method  " + message);
        }

        static Action action = () => { Console.WriteLine("None Para !"); };
        static Action<int, string> action2 = (num, str) =>
        {
            Console.WriteLine($"Tow Par int {num}, string {str}");
        };
        delegate int Opr(int x, int y);

        static int Add(int x , int y)
        {
            return (int)(x + y);
        }
        static int Mutt(int x, int y)
        {
            return (int)(x + y);
        }

        static void PrintResult(int x, int y, Opr ope)
        {
            int U = ope(x, y);
            Console.WriteLine($"Your result is {U}");
        }

        static bool Try1(int x)
        {
            Console.WriteLine("Hi From Try1");
            return true;
        }


        static bool Try2(int x)
        {
            Console.WriteLine("Hi From Try2 ");
            return true;
        }

        static Func<int,int,int> FAdd =(x,y) =>x + y;

        static void Main(string[] args)
        {
            Predicate<int> IsEven = x => x % 2 == 0;
            //Logger method = new Logger(method2);
            //method.Log("Hello to Me from Single Delegate?");

            //IsEven += Try1;
            //IsEven += Try2;
            bool Even = IsEven(2);
            Console.WriteLine(Even);

            //int? m = 7;
            //int Resualt = m ?? 1000000000;
            //Console.WriteLine(Resualt);
            //Console.WriteLine(m?.ToString());
            DGPrint print = method1;
            print += method2;

            print += method3;
            print("Hi ");
            print -= method3;
            print("no ");

            Console.WriteLine();
            Console.ReadKey();

        }
    }
}