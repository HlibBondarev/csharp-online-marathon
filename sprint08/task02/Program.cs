using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace task02
{
    //We have the class MainThreadProgram. Please create three methods: Calculator, Product, and Sum.
    //Method Sum() should ask the user to enter 5 numbers in the form “Enter the 1st number:”, “Enter the 2nd number:”
    //etc.and calculate their sum. After that, it should output the message “Sum is: <sum>”. 
    //Method Product() should generate a List of 10 consequent integer numbers from 1 to 10 and calculate their product.
    //Then it should wait for 10 seconds.After that, it should output the message “Product is: <product>”. 
    //The Calculator() method should create two threads: productThread and sumThread, and call the Product and Sum methods
    //in appropriate threads. This method should return a tuple of two threads: (sumThread, productThread).


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //MainThreadProgram.Sum();
            //new MainThreadProgram().Product();

            var tt = MainThreadProgram.Calculator();

            Console.WriteLine("Main thread");
            Console.ReadKey();
        }
    }
    class MainThreadProgram
    {
        static Thread productThread = new Thread ((Product));
        static Thread sumThread = new(Sum);

        public static (Thread, Thread) Calculator()
        {
            sumThread.Start();
            productThread.Start();
            return (sumThread, productThread);
        }

        public static void Sum()
        {
            int sum = 0;
            if (Input("Enter the {0} number:", new string[] { "st", "nd", "rd", "th", "th" }) is List<int> list)
            {
                list.ForEach(e => sum += e);
            }
            Console.WriteLine($"Sum is: {sum}");
        }

        public static void Product()
        {
            int product = 1;
            new List<int>(Enumerable.Range(1, 10)).ForEach(e => product *= e);
            Thread.Sleep(10000);
            if (sumThread.ThreadState != ThreadState.Unstarted)
                sumThread.Join();
            Console.WriteLine($"Product is: {product}");
        }

        static List<int>? Input(string question, string[] endings)
        {
            var list = new List<int>();
            for (int i = 0; i < endings.Length; i++)
            {
                Console.WriteLine(question, (i + 1).ToString() + endings[i]);
                var result = int.TryParse(Console.ReadLine(), out int number);
                if (result)
                {
                    list.Add(number);
                }
                else
                {
                    Console.Write("You can only enter int parameter.\nType 'Q' to exit or any key to continue entering data. ");
                    if (Console.ReadKey().KeyChar == 'q') return null;
                    --i;
                    Console.WriteLine();
                }
            }
            return list;
        }
    }
}