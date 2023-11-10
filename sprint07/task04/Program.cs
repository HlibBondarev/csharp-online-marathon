namespace task04
{
    // Please, create a static method GetWord takes 2 string parameters: 
    // first - initial string with a sequence of words separated by space
    // second - a word for comparison.
    // The method should find the longest word in the first parameter, that is longer than the second parameter if there is one, 
    // otherwise, the second parameter should be the result of the search.
    // The method should return the part of the found word, starting from the first 'a' char. 
    // If there isn't 'a' char in the found word, the method should return an empty string.
    // (You don't need to verify on null parameter values. Assume that parameters will always be not null)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World4!");
            string word = GetWord("The method should return the part of the found word, starting from the first 'a' char.", "Hello!");
            Console.WriteLine(word);

            Console.ReadKey();
        }

        public static string GetWord(string input, string seed = "")
        {
            IEnumerable<char> result = input.Split(' ').Prepend(seed).MaxBy(x => x.Length).SkipWhile(ch => ch != 'a');
            return result.Any() ? new string(result.ToArray()) : string.Empty;

            //string t = input.Split(' ').MaxBy(x => x.Length);
            //string word = t.Length <= seed.Length ? seed : t;
            //var result = word.SkipWhile(ch => ch != 'a');
            //return !result.Any() ? string.Empty : new string(result.ToArray());
        }
    }
}