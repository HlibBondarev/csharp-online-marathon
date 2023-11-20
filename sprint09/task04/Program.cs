using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace task04
{
// Suppose we have a class named Calc which has a method Seq
// generating n-th member of a certain number sequence(starting from 1).
// Define a class named CalcAsync.In this class:
// Write an asynchronous stream called SeqStreamAsync taking integer parameter n,
// that returns a collection of n tuples
// consisting of a number i (from 1 to n) and i-th member of the sequence.
// Write an asynchronous static method PrintStream
// taking an asynchronous stream of tuples consisting of 2 integer numbers,
// which prints the collection as follows:
// "Seq[X] = Y", where X is the first item of a tuple, Y is the second one.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            CalcAsync.PrintStream(CalcAsync.SeqStreamAsync(4));
            CalcAsync.PrintStream(CalcAsync.SeqStreamAsync(5));

            Console.ReadKey();
        }
    }

    static class CalcAsync
    {
        public static async IAsyncEnumerable<(int, int)> SeqStreamAsync(int quant)
        {
            var numbers = Enumerable.Range(1, quant);
            foreach (int number in numbers)
            {
                yield return (number, await Task.Run(() => Calc.Seq(number)));
            }
        }
        public static async void PrintStream(IAsyncEnumerable<(int, int)> tuples)
        {
            await foreach ((int, int) t in tuples)
            {
                Console.WriteLine($"Seq[{t.Item1}] = {t.Item2}");
            }
        }
    }

    class Calc
    {
        public static int Seq(int n) => n * n;
    }
}