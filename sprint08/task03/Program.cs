using System.Numerics;
using System.Threading.Channels;

namespace task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyTask.Tasks();

            Console.ReadKey();
        }
    }
    class MyTask
    {
        public static void Tasks()
        {
            int[] secuence_array = new int[10];
            object obj = new();
            Task[] task1 = new Task[3]
            {
                new Task(()=>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        secuence_array[i] = i*i;
                    }
                    Console.WriteLine("Calculated!");
                }),
                new Task(()=>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("Bye!");
                }),
                new Task(()=>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(secuence_array[i]);
                    }
                    Console.WriteLine("Bye!");
                })
            };
            for (int i = 0; i < 3; i++)
            {
                task1[i].Start();
                task1[i].Wait();
            }
            Console.WriteLine("Main done!");
        }
    }
}





























