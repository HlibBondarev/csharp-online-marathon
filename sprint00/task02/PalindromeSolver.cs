using System;
using System.Collections.Generic;
using System.Linq;

namespace task02
{
    public class PalindromeSolver
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindromeHeritor(10101010));
            Console.WriteLine(IsPalindromeHeritor(11211203));
            Console.WriteLine(IsPalindromeHeritor(31001120));
            Console.WriteLine(IsPalindromeHeritor(8677));
            Console.WriteLine(IsPalindromeHeritor(97358817));//
            Console.WriteLine(IsPalindromeHeritor(332233));
            Console.WriteLine(IsPalindromeHeritor(89));
            Console.WriteLine(IsPalindromeHeritor(989));
            Console.WriteLine(IsPalindromeHeritor(17371));
            Console.WriteLine(IsPalindromeHeritor(183372));
            Console.WriteLine(IsPalindromeHeritor(123321));
            Console.WriteLine(IsPalindrome(new char[] { '1', '2', '3', '3', '2', '1' }));

        }

        public static bool IsPalindromeHeritor(long number)
        {
            string numbers = number.ToString();
            if (IsPalindrome(numbers))
            {
                return true;
            }
            do
            {
                numbers = GetHeritor(numbers);
                if (IsPalindrome(numbers))
                {
                    return true;
                }
            }
            while (numbers.Count() > 3);
            return false;
        }

        public static bool IsPalindrome(IEnumerable<char> chars)
        {
            string word1;
            string word2;
            string word = new string(chars.ToArray<char>());
            int k = word.Length / 2;

            if (word.Length % 2 == 0)
            {
                word1 = word.Remove(k, k);
                word2 = word.Remove(0, k);
            }
            else
            {
                word1 = word.Remove(k, k + 1);
                word2 = word.Remove(0, k + 1);
            }
            char[] arr = word2.ToCharArray();
            Array.Reverse(arr);
            word2 = new string(arr);
            return word1 == word2;
        }

        public static string GetHeritor(IEnumerable<char> chars)
        {
            string numbers = string.Empty;
            int k = 0;
            Stack<int> stack = new Stack<int>();
            foreach (char ch in chars)
            {
                if (++k % 2 == 1)
                {
                    stack.Push(int.Parse(ch.ToString()));
                }
                else
                {
                    numbers += (stack.Pop() + int.Parse(ch.ToString())).ToString();
                }
            }
            return numbers;
        }
    }
}
