﻿using System.Numerics;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Channels;

namespace task05
{
    // You have MyThreads class in the answer window below.Please, investigate it: there is some problem with this class.
    //Fix the problem.
    //    The test starts both threads with the code:
    //            MyThreads.Thread1.start();
    //            MyThreads.Thread2.start();
    //    The goal of each thread is to make some evaluations, update m and n fields and not switch between threads while loop is executed.
    //    You need to get an output like this:
    //    Thread1 n = 0
    //    Thread1 n = 1
    //    Thread1 n = 2
    //    Thread1 n = 3
    //    Thread1 n = 4
    //    Thread2 m = 0
    //    Thread2 m = 1
    //    Thread2 m = 2
    //    Thread2 m = 3
    //    Thread2 m = 4
    //    Thread2 n = 5
    //    Thread2 n = 6
    //    Thread2 n = 7
    //    Thread2 n = 8
    //    Thread2 n = 9
    //    Thread2 success!
    //    Thread1 m = 5
    //    Thread1 m = 6
    //    Thread1 m = 7
    //    Thread1 m = 8
    //    Thread1 m = 9
    //    Thread1 success!
    //    Please, don't change actions that change variables or print output within run() methods. Use only thread synchronization assets.

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var myThreads = new MyThreads();
            myThreads.Thread1.Start();
            myThreads.Thread2.Start();

            Console.ReadKey();
        }
    }

    class MyThreads
    {
        public static readonly object Den = new object();
        public static int n;
        public static int m;
        private static ManualResetEvent mrs = new ManualResetEvent(false);
        public Thread Thread1 => new Thread(() =>                                
                                            {
                                                lock (Den)
                                                {
                                                    mrs.Set();
                                                    for (int i = 0; i < 5; i++, n++)
                                                    {
                                                        Console.WriteLine("Thread1 n = " + n);
                                                        ThreadsDemo.ExtraEvaluation(i);
                                                    }
                                                }
                                                Thread.Yield();
                                                //Thread.Sleep(100);// ???
                                                lock (Den)
                                                {
                                                    for (int i = 0; i < 5; i++, m++)
                                                        Console.WriteLine("Thread1 m = " + m);
                                                    Console.WriteLine("Thread1 success!");
                                                }
                                            }
                                            );
        public Thread Thread2 => new Thread(() =>
                                           {
                                               mrs.WaitOne();
                                               lock (Den)
                                               {
                                                   mrs.Dispose();
                                                   for (int i = 0; i < 5; i++, m++)
                                                       Console.WriteLine("Thread2 m = " + m);
                                                   for (int i = 0; i < 5; i++, n++)
                                                       Console.WriteLine("Thread2 n = " + n);
                                                   Console.WriteLine("Thread2 success!");
                                               }
                                           }
                                           );
    }

    internal class ThreadsDemo
    {
        internal static void ExtraEvaluation(int i)
        {
            return;
        }
    }
}