using System;

namespace task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Fraction.GCD(48,27));
            var res = new Fraction(-167, 100) - new Fraction(3, 2);
            res = !new Fraction(-3, 100);
            res = new Fraction(-167, 100) * new Fraction(3, 2);
            res = new Fraction(-167, 100) / new Fraction(3, 2);

            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4

            a = new Fraction(20, 25);
            b = new Fraction(4, 5);
            Console.WriteLine(a==b);
            Console.WriteLine(a.Equals(b));
        }
    }
}
