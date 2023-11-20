using System.ComponentModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task05
{
    // Suppose we have a class named Calc which has a method Seq generating n-th member of a certain number sequence(starting from 1).
    // Define a class named CalcAsync.In this class:
    // Write an asynchronous static method PrintSpecificSeqElementsAsync
    // taking an array of integers as a patameter,
    // which performs a calculation of apropriate sequence member
    // according to each number in the input array
    // and prints out the result as follows:
    // "Seq[X] = Y", where X is a number from input array, Y is the corresponding sequence member.
    // Each calculation should be performed in a separate task.
    // After last calculation is performed, the list of found exceptions should be printed.
    // (The method Seq generates appropriate exception for non-positive input parameter.)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CalcAsync.PrintSpecificSeqElementsAsync(new int[] { -1, 7, -8 });

            Console.ReadKey();
        }
    }

    static class CalcAsync
    {
        public static async void PrintSpecificSeqElementsAsync(int[] numbers)
        {
            int count = numbers.Length;
            Task? allTasks = null;
            Task[] tasks = new Task[count];
            try
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int index = i;
                    tasks[index] = Task.Run(async ()
                        => await Task.Run(() => Console.WriteLine($"Seq[{numbers[index]}] = {Calc.Seq(numbers[index])}")));
                }
                allTasks = Task.WhenAll(tasks);
                await allTasks;
            }
            // SOLUTION with foreach()
            //List<Task> tasks = new(); // for foreach() solution
            //try
            //{
            //    foreach (var number in numbers)
            //    {
            //        tasks.Add(Task.Run(async () => await Task.Run(() => Console.WriteLine($"Seq[{number}] = {Calc.Seq(number)}"))));
            //    }
            //    allTasks = Task.WhenAll(tasks);
            //    await allTasks;
            //}
            catch (Exception)
            {
                if (allTasks?.Exception?.InnerExceptions != null)
                {
                    foreach (var inx in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine("Inner exception: " + inx.Message);
                    }
                }
            }
        }
    }

    class Calc
    {
        public static int Seq(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Argument exception");
            }
            return n * n;
        }
    }
}