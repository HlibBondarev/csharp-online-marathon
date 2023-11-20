using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;

namespace task03
{
    // Suppose we have a class named Calc which has a method Seq
    // generating n-th member of a certain number sequence(starting from 1).
    // Define a class named CalcAsync.In this class:
    // Write an asynchronous static method SeqAsync taking integer parameter n,
    // that returns n-th member of the sequence.
    // Use Task<> as a return type.
    // Write an asynchronous static method PrintSeqElementsConsequentlyAsync
    // taking integer parameter quant,
    // which calls SeqAsync method for each integer number i from 1 to quant
    // and prints the result as follows:
    // "Seq[X] = Y", where X is i, Y is the i-th sequence member.

    // Write an asynchronous static method PrintSeqElementscaInParallelAsync
    // taking integer parameter quant,
    // which does the same as previous one, except of the way of calling SeqAsync method.
    // Each call of this method should be performed so that
    // it would run in parallel, not waiting for previous one.

    // After the last member is received, the results should be printed as described before.
    // Write the auxiliary method GetSeqAsyncTasks that will be used in the previous one.
    // This method should take integer parameter n and return an array of Task<> objects.
    // Each of those tasks should be responsible for geting one sequence member.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            CalcAsync.PrintSeqElementsConsequentlyAsync(1);
            CalcAsync.PrintSeqElementsConsequentlyAsync(4);
            
            CalcAsync.PrintSeqElementsInParallelAsync(4);


            Console.ReadKey();
        }
    }

    static class CalcAsync
    {
        public static async Task<int> SeqAsync(int n) => await Task.Run(() => Calc.Seq(n));
        public static async void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for (int i = 1; i <= quant; i++)
            {
                int index = i;
                Console.WriteLine($"Seq[{index}] = {await SeqAsync(index)}");
            }
        }
        public static Task<int>[] GetSeqAsyncTasks(int quant)
        {
            var taskArray = new Task<int>[quant];
            for (int i = 0; i < quant; i++)
            {
                int index = i;
                taskArray[index] = Task.Run(() => SeqAsync(index + 1));
            }
            return taskArray;
        }
        public static async void PrintSeqElementsInParallelAsync(int quant)
        {
            var task =Task.WhenAll(GetSeqAsyncTasks(quant));
            for (int i = 1; i <= quant; i++)
            {
                try
                {
                    Console.WriteLine($"Seq[{i}] = {(await task)[i-1]}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // SOLUTION with  IAsyncEnumerable<Task<int>>

        //public static async IAsyncEnumerable<Task<int>> GetSeqAsyncTasks1(int quant)
        //{
        //    List<Task<int>> taskList = new();
        //    var numbers = Enumerable.Range(1, quant);
        //    foreach (int number in numbers)
        //    {
        //        taskList.Add(Task.Run(() => SeqAsync(number)));
        //    }
        //    while (taskList.Any())
        //    {
        //        var task = await Task.WhenAny(taskList);
        //        taskList.Remove(task);
        //        yield return task;
        //    }
        //}

        //public static async void PrintSeqElementsInParallelAsync1(int quant)
        //{
        //    int i = 0;
        //    await foreach (var task in GetSeqAsyncTasks1(quant))
        //    {
        //        try
        //        {
        //            Console.WriteLine($"Seq[{i++}] = {/*await*/ task}");
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}
    }

    class Calc
    {
        public static int Seq(int n) => n * n;
    }
}