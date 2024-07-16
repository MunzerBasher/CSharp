using System;


namespace GUID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i=1;i<10;i++) 
            {
                Guid guid = Guid.NewGuid();
                Console.WriteLine(guid);
            }
            Console.ReadKey();
        }
    }
}
