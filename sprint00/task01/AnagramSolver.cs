using System;
using System.Collections.Generic;
using System.Linq;

namespace task01
{
    public class AnagramSolver
    {
        public static void Main(string[] args)
        {
            string word1 = "car";
            string word2 = "race";
            Console.WriteLine("Is word '{0}' an anagram of '{1}': {2}", word1, word2, IsAnagram(word1, word2));
        }
        public static bool IsAnagram(string substr, string str)
        {
            var temp = Permutations(substr);
            foreach (var item in temp)
            {
                if (str.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<string> Permutations(IEnumerable<char> source)
        {
            if (source.Count() == 1) return new List<string> { source.ToString() };
            var permutations = from c in source
                               from p in Permutations(new String(source.Where(x => x != c).ToArray()))
                               select c + p;
            return permutations;
        }
    }
}
