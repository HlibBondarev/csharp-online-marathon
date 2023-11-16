using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;

namespace task04
{
    //Please create a class MyProgram.
    //Create a method Counter that takes one parameter of int type.
    //This method should start two threads.
    //One of them calculates the factorial of Counter's argument (n! = 1 * 2 * ... * (n - 1) * n).
    //The second thread calculates the appropriate number of Fibonaci sequence (fibo(0) = 0, fibo(1) = 1, ... fibo(n) = fibo(n-1) + fibo(n-2)).
    //Please implement the additional methods.
    //Method Counter should display two messages:
    //"Factorial is: <factorial>"
    //"Fibbonaci number is: <fibo>".
    //The sequence of outputs matters.
    //Example:
    //Input: MyProgram.Counter(4);
    //Output:  
    //Factorial is: 24
    //Fibbonaci number is: 3
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyProgram.Counter(16);

            Console.ReadKey();
        }
    }

    class MyProgram
    {
        public static void Counter(int n)
        {
            int factorial = 0;
            int fibbonaci = 0;
            Task<int>[] tasks =
            {
                new Task<int>(()=>factorial = Enumerable.Range(1, n).Aggregate(1, (f, i) => f * i)),
                new Task<int>(()=>fibbonaci = Enumerable.Range(0, n)
                                                        .Aggregate(new { Current = 0, Prev = 0 },
                                                        (x, index) => 
                                                        new { Current = index == 0 ? 1 : x.Prev + x.Current, Prev = x.Current })
                                                        .Current)
            };
            tasks.ToList<Task<int>>().ForEach(t => t.Start());
            Task<int>.WaitAll(tasks);
            Console.WriteLine($"Factorial is: {factorial}");
            Console.WriteLine($"Fibbonaci number is: {fibbonaci}");
        }
    }
}