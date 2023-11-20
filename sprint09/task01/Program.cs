using System.ComponentModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Threading;


namespace task01
{
    // Suppose we have a class named Calc which has a method Seq
    // generating n-th member of a certain number sequence(starting from 1).
    // Define a class named CalcAsync. In this class:
    // Write an asynchronous static method PrintSeqAsync taking integer parameter n,
    // that prints out the following:
    // "Seq[X] = Y", where X is the value of input parameter n, Y is n-th member of the sequence.
    // Use Task as return type.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            _ = CalcAsync.PrintSeqAsync(4);
        }
    }
    class CalcAsync
    {
        public static async Task PrintSeqAsync(int n) => await Task.Run(() => Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
        // OR:
        //public static async Task PrintSeqAsync(int n) => await Task.Run(() => Console.Out.WriteLineAsync($"Seq[{n}] = {Calc.Seq(n)}"));
    }
    class Calc
    {
        public static int Seq(int n) => n * n;
    }
}