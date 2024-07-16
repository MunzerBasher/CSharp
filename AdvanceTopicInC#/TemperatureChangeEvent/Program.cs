using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureChangeEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostats thermostats = new Thermostats();
            Display display = new Display();
            display.Subscribe(thermostats);
            thermostats.SetTemperature(20);
            thermostats.SetTemperature(20);
            thermostats.SetTemperature(25);

            ////////////////////////////////////////////////////////////////////

            //Order order = new Order();
            //Client client = new Client();
            //SMS sms = new SMS();
            //EMAIL eMAIL = new EMAIL();
            //client.Subscribe(order);
            //sms.Subscribe(order);
            //eMAIL.Subscribe(order);
            //order.CreateOrder("Phone A21s", "Good Phone", DateTime.Now.ToString());



            Console.ReadKey();
        }
    }
}