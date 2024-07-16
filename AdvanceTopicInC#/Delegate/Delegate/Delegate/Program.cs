using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock("amazun",20);
            stock.OnPriceChanged += Stock_OnPriceChanged;

            stock.ChangeStockPriceBy(001);

            Console.ReadKey();
        }

        private static void Stock_OnPriceChanged(Stock stock, decimal price)
        {
            if(price < stock.price)
                Console.ForegroundColor = ConsoleColor.Red;
            else if(price > stock.price) 
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Stock: {stock.name} -> Price {stock.price} ");
        }
    }

    public delegate void StockHandelr(Stock stock,decimal price);

    public class Stock
    {
        public string name;
        public decimal price
        {  get; set; }
        private decimal CurrentPrice;
        public event StockHandelr OnPriceChanged;

        public Stock(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public void ChangeStockPriceBy(decimal prt)
        {
            CurrentPrice = this.price;
            this.price += Math.Round(this.price * prt, 2);
            if (OnPriceChanged != null)
            {
                if (CurrentPrice != price)
                {
                    OnPriceChanged(this, price);
                }
            }
        }
    }

}