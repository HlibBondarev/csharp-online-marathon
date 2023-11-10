namespace task02
{
    // Please, implement EvaluateAggregate method that takes
    // an array of doubles as the first parameter,
    // a delegate that defines an aggregate behavior as the second,
    // a delegate that defines a condition for the index as the third parameter.
    // The method should return a result of an aggregate operation for the elements with indexes that satisfy the condition set
    // by the third parameter

    //(You don't need to verify on null parameter values. Assume that parameters will always be not null)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World2!");

            double sum = EvaluateAggregate(new double[] { 4.5, 1, 6, 9.4, 5 }, (x, y) => x + y, (x, index) => index % 2 == 1);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
        public static double EvaluateAggregate(double[] inputData, Func<double, double, double> aggregate, Func<double, int, bool> predicate)
        {
            return inputData.Where(predicate).Aggregate(aggregate);
        }
    }
}