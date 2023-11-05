using System.Linq;
using System.Collections.Generic;

namespace task201
{
    //Create a ListDictionaryCompare() method of the MyUtils class to compare the contents of a List of strings and
    //the values of a Dictionary.These collections must be passed as parameters of the method.

    //For example, for a given list[aa, bb, aa, cc] and dictionary { 1 = cc, 2 = bb, 3 = cc, 4 = aa, 5 = cc}
    //you should get true.

    //For a given list[aa, bb, aa, cc, ddd] and dictionary  {1=cc, 2=bb, 3=cc, 4=aa, 5=cc} 
    //you should get false

    //For a given list[aa, bb, aa, cc] and dictionary {1=cc, 2=bb, 3=cc, 4=aa, 5=cc, 6=ddd }
    //you should get false
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<string> list = new List<string> { "aa", "bb", "aa", "cc" };
            Dictionary<string, string> dic = new Dictionary<string, string> { { "1", "cc" }, { "2", "bb" }, { "3", "cc" }, { "4", "aa" }, { "5", "cc" } };
            Console.WriteLine(MyUtils.ListDictionaryCompare(list, dic));

            list = new List<string> { "aa", "bb", "aa", "cc", "ddd" };
            dic = new Dictionary<string, string> { { "1", "cc" }, { "2", "bb" }, { "3", "cc" }, { "4", "aa" }, { "5", "cc" } };
            Console.WriteLine(MyUtils.ListDictionaryCompare(list, dic));

            list = new List<string> { "aa", "bb", "aa", "cc" };
            dic = new Dictionary<string, string> { { "1", "cc" }, { "2", "bb" }, { "3", "cc" }, { "4", "aa" }, { "5", "cc" }, { "6", "ddd" } };
            Console.WriteLine(MyUtils.ListDictionaryCompare(list, dic));

            Console.ReadKey();
        }
    }

    class MyUtils
    {
        public static bool ListDictionaryCompare(List<string> strings, Dictionary<string, string> dic)
        {
            var distinctStrings = strings.Distinct().OrderBy(x => x);
            var distinctValues = dic.Values.Distinct().OrderBy(x => x);
            return distinctStrings.SequenceEqual(distinctValues);
        }
    }
}