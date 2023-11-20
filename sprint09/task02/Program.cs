using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace task02
{
    // Suppose we have a class named Calc which has a method Seq
    // generating n-th member of a certain number sequence(starting from 1).
    // Define a class named CalcAsync.In this class:
    // Write an asynchronous static method TaskPrintSeqAsync taking integer parameter n,
    // that prints out the following:
    // "Seq[X] = Y", where X is the value of input parameter n, Y is n-th member of the sequence.
    // Use Task as return type

    // Implement an extention method named PrintStatusIfChanged
    // which takes, as parameters, a task along with its previous status,
    // prints out the status if it was changed, and updates the old one(given by the parameter).
    // Implement an extention method named TrackStatus which takes, as a parameter, a task,
    // and continuously checks a status of the task, and prints out its status if changed.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    static class CalcAsync
    {
        static TaskStatus currentStatus = TaskStatus.Created;
        public static async Task TaskPrintSeqAsync(int n) => await Task.Run(() => Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
        public static void PrintStatusIfChanged(this Task task, ref TaskStatus previousStatus)
        {
            if (task.Status != previousStatus)
            {
                Console.WriteLine(task.Status);
                previousStatus = task.Status;
            }
        }
        public static void TrackStatus(this Task task)
        {
            while (!task.IsCompleted)
            {
                task.PrintStatusIfChanged(ref currentStatus);
            }
            task.PrintStatusIfChanged(ref currentStatus);
        }
    }

    class Calc
    {
        public static int Seq(int n) => n * n;
    }
}