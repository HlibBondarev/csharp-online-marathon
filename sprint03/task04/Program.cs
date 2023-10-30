using System;
using System.Collections.Generic;
using System.Text;

//Define a class IListExtensions with an extension method IncreaseWith(…) that takes an instance of a class, that implements
//the interface list of integers(IList<int>). Method IncreaseWith(…) increases the value of each item by a certain number. 
//Define a class IEnumerableExtensions with an extension method ToString(). ToString() loops through a collection and converts
//a sequence of elements (list of integers) to a meaningful string (items separated with ', ' and surrounded with '[' and ']').
//Use IncreaseWith() and ToString() extention methods in such a way:
//
//      IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
//      Console.WriteLine(numbers.ToString<int>());
//      numbers.IncreaseWith(5);
//      Console.WriteLine(numbers.ToString<int>());

namespace task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.ToString<int>());
        }
    }
    public static class IListExtensions
    {
        public static IList<int> IncreaseWith(this IList<int> list, int number)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += number;
            }
            return list;
        }
    }

    public static class IEnumerableExtensions
    {
        public static string ToString<T> (this IEnumerable<int> list)
        {
            StringBuilder sb = new StringBuilder("[");
            foreach (var n in list) 
            { 
                sb.Append(n.ToString());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");
            return sb.ToString();
        }

        //public static string ToString<T>(this IList<String> list)
        //{
        //    return string.Join(", ", list.ToArray());
        //}
    }
}
