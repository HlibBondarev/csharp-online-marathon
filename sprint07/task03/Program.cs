namespace task03
{
    // Please, create a method ProductWithCondition that takes a list of integers as a parameter and returns a product of elements
    // that satisfy a condition that is passed as a second parameter.
    // The second parameter should be a Func that takes an integer as a parameter and returns bool.
    // If the first parameter or result of filtering contains 0 elements the method must return 1.
    // (You don't need to verify on null parameter values. Assume that parameters will always be not null)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World3!");
            double sum = ProductWithCondition(new List<int> { 4, 1, 6, 9, 5, 3, 10 }, (x) => x % 2 == 1);
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public static int ProductWithCondition(List<int> list, Func<int, bool> condition)
        {
            return list.Aggregate(1, (x, y) => condition(y) ? x * y : x);
            //IEnumerable<int> query = list.Where(condition);
            //return query.Any() ? query.Aggregate((x, y) => x * y) : 1;
        }
    }
}