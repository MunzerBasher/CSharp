using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Attribute
{
    public class clsMyClass
    {
        [Conditional("DEBUG")]
        public static void InDebug()
        {
            Console.WriteLine("Hello in Debug Mode ");
        }

        [Conditional("D")]
        public static void NewConditional()
        {
            Console.WriteLine("Hello in New Conditional Mode ");
        }

        public static void InNormal()
        {
            Console.WriteLine("Hello in Normal Mode ");
        }
        [Obsolete("This Method is mark Obsolete")]
        public static void ObMethod()
        {
            Console.WriteLine("Hello in Obsolete Mode ");
        }

    }

    [Serializable]
    public class Person
    {
        public string name {  get; set; }
        public int age { get; set; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person { name = "Ola", age = 21 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (TextWriter writer = new StreamWriter("person.xml"))
            {
                serializer.Serialize(writer, person);
            }
            //DeSerialize
            using (TextReader reader = new StreamReader("person.xml"))
            {
                Person DePerson = (Person)serializer.Deserialize(reader);
                Console.WriteLine($"Name {DePerson.name}");
                Console.WriteLine($"Age  {DePerson.age}");
            }

            clsMyClass.InDebug();
            clsMyClass.InNormal();
            clsMyClass.ObMethod();
            clsMyClass.NewConditional();

            Console.ReadKey();

        }
    
    
    }
}