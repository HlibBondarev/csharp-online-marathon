namespace task04
{
    // Within the class, ShowPowerRange create a static method PowerRanger() that takes in integer degree, start, finish. 
    // The method returns all the numbers from the range[start, finish] (inclusive and finish > 0 and start > 0) that are equal
    // to the degree-th power of any positive integer.
    // In the case start > finish, or start < 0, or finish < 0 the method returns 0.
    // The method involves yielding the intermediate result on each iteration.
    // For example, when calling the method PowerRanger(3, 1, 200):
    // 1
    // 8
    // 27
    // 64
    // 125

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            foreach (int i in ShowPowerRange.PowerRanger(3, 100, 1000)) { Console.WriteLine(i); }

            // Delay
            Console.ReadKey();
        }
    }

    public class ShowPowerRange
    {
        public static IEnumerable<int> PowerRanger(int degree, int start, int finish)
        {
            if (finish <= 0 || start < 0 || start > finish)
            {
                yield return 0;
            }
            else if (degree == 0)
            {
                yield return 1;
            }
            else if (degree < 0)
            {
                yield break;
            }
            else
            {
                for (int i = 1; true; i++)
                {
                    int result = 1;
                    for (int j = 0; j < degree; j++)
                    {
                        result *= i;
                    }
                    if (result >=start && result <= finish)
                    {
                        yield return result;
                    }
                    else if (result > finish)
                    {
                        yield break;
                    }
                }
            }
        }
    }    
}