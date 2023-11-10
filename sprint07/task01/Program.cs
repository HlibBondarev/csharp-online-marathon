namespace task01
{
    // Please, implement the SumOfElementsOddPositions method that returns sum of elements with odd indexes in the array of doubles
    // (You don't need to verify on null parameter value. Assume that parameter will always be not null)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World1!");

            double sum = EvaluateSumOfElementsOddPositions(new double[] { 4.5, 1, 6, 9.4, 5 });
            Console.WriteLine(sum);
            Console.ReadKey();
        }
        public static double EvaluateSumOfElementsOddPositions(double[] inputData)
        {
            return inputData.Where((x, index) => index % 2 == 1).Sum();
        }
    }
}