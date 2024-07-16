using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OprOverloed
{

    public class Point
    {
        public int x
        {
            get; set;
        }
        public int y
        { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(2, 3);
            Point p = p1 + p2; 
            Point m = p1 - p2;
            Console.WriteLine($"x {m.x}  y {m.y}");
            Console.WriteLine($"x {p.x}  y {p.y}");
            Console.ReadKey();
        }
    }
}
