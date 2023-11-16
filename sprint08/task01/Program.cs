namespace task01
{
    using System.Threading;
    using System;
    using System.Collections.Generic;

    // Implement ParallelUtils class that will be able to execute an operation in a parallel thread.
    // The constructor of ParallelUtils takes 3 parameters: 
    // 1) The Func<T, T, TR> to define an operation that will be executed,
    // 2) The operand1 of type T 
    // 3) Tperand2 of type T.
    // The ParallelUtils class should have public Result property of type TR where the result of the operation must be written when
    // it's executed.
    // Implement method StartEvaluation that will start the evaluation(of the function passed into constructor) in a parallel thread
    // Implement method Evaluate that will start the evaluation(of the function passed into constructor) in a parallel thread and
    // wait until it's executed

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var pu = new ParallelUtils<int, int>((x, y) => x + y, 3, 2);
            pu.Evaluate();
            Console.WriteLine(pu.Result);

            Console.ReadKey();
        }
    }

    class ParallelUtils<T, TR>
    {
        readonly Thread thread;
        public TR? Result { get; private set; }
        public ParallelUtils(Func<T, T, TR> func, T operand1, T operand2) 
               => thread = new Thread(() => Result = func(operand1, operand2));
        public void StartEvaluation() => thread.Start();
        public void Evaluate()
        {
            StartEvaluation();
            thread.Join();
        }
    }
}