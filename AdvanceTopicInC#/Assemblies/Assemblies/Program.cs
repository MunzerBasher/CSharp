using System;
using DemoLib;
using System.IO;
using System.Reflection;

namespace Assemblies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assemblies");

            var type = typeof(clsEmploye);
            Console.WriteLine(type);
            
            var Assemb = Assembly.GetExecutingAssembly();
            Console.WriteLine(Assemb.FullName);
            var assemp = Assemb.GetName();

            Demo.Trace();
            var assembly = type.Assembly;
            var stream = assembly.GetManifestResourceStream(type, "");

            var data = new BinaryReader(stream).ReadBytes((int)stream.Length);
            for (int i = 0; i < data.Length; i++) 
            {
                Console.Write((char)data[i]);
                System.Threading.Thread.Sleep(1000);
            }
            stream.Close();
            Console.ReadKey();


        }
    }
}