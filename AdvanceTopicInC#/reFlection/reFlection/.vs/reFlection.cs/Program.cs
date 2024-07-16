using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reFlection.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(int);
            Type type1 = typeof(clsMyClass);
            clsTypes.GetTypeInfo(type);
            Assembly assembly = type.Assembly;
            clsTypes.GetAssemblyInfo(assembly, "System.String");
            clsTypes.CreateInst(type1);
            Console.ReadKey();

        }
    }
}
