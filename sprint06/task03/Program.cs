using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Reflection.Metadata;
namespace task03
{
    // Inside a class ShowPower define a static method SuperPower(). SuperPower() has two integer input parameters: number and degree.
    // The method will calculate the power of a given number according to degree parameter.
    // Note: Don't use Pow().

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            foreach (float i in ShowPower.SuperPower(3, -4)) { Console.WriteLine(i); }

            Console.ReadKey();
        }
    }

    class ShowPower
    {
        public static IEnumerable<float> SuperPower(int number, int degree)
        {
            if (number == 0)
            {
                yield return 0f;
            }
            else if (degree == 0)
            {
                yield return 1f;
            }
            else
            {
                float result = degree > 0 ? number : 1f / number;
                float floatNumber = degree > 0 ? number : 1f / number;
                yield return result;
                degree = Math.Abs(degree);
                for (int i = 1; i < degree; i++)
                {
                    yield return result *= floatNumber;
                }
            }
        }
    }
}