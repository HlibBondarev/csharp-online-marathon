using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(-1, -1);
            Point p2 = new Point(-4, 3);
            double l = (double)p2;

            Console.WriteLine(p1.Distance(p2));
            Console.WriteLine(l);
        }
    }
}
