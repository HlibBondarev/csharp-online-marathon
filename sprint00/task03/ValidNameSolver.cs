using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task03
{
    public class ValidNameSolver
    {
        //H.Wells
        //H.G.Wells
        //Herbert G. Wells
        //Herbert George Wells
        //The following names are invalid:

        //Herbert or Wells (single names not allowed)
        //H Wells or H.G Wells (initials must end with dot)
        //h.Wells or H.wells or h.g.Wells(incorrect capitalization)
        //H.George Wells (middle name expanded, while first still left as initial)
        //H.G.W. (last name is not a word)
        //Herb.G.Wells(dot only allowed after initial, not word)
        public static void Main(string[] args)
        {
            Console.WriteLine(IsValidName("H. Wells"));
            Console.WriteLine(IsValidName("H. G. Wells"));
            Console.WriteLine(IsValidName("Herbert G. Wells"));
            Console.WriteLine(IsValidName("Herbert George Wells"));
            Console.WriteLine(IsValidName("Herbert"));
            Console.WriteLine(IsValidName("H Wells"));
            Console.WriteLine(IsValidName("H. G Wells"));
            Console.WriteLine(IsValidName("h. Wells"));
            Console.WriteLine(IsValidName("H. wells"));
            Console.WriteLine(IsValidName("h. g. Wells"));
            Console.WriteLine(IsValidName("H. George Wells"));
            Console.WriteLine(IsValidName("H. G. W."));
            Console.WriteLine(IsValidName("Herb. G. Wells"));
        }

        public static bool IsValidName(string name)
        {
            string[] properTemplates =
            {
                "InitialWord",
                "InitialInitialWord",
                "WordInitialWord",
                "WordWordWord"
            };
            string template = string.Empty;
            IEnumerable<Term> sequence = TermSequence(name);
            foreach (var item in sequence)
            {
                template += item.ToString();
            }
            return properTemplates.Contains(template);
        }

        public static IEnumerable<Term> TermSequence(string name)
        {
            string initialPattern = "^[A-Z]{1}.$";
            string wordPattern = "^[A-Z][a-z]+$";

            foreach (string item in name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (new Regex(initialPattern).IsMatch(item))
                {
                    yield return Term.Initial;
                }
                else if (new Regex(wordPattern).IsMatch(item))
                {
                    yield return Term.Word;
                }
                else
                {
                    yield return Term.None;
                }
            }
        }

        public enum Term
        {
            Initial,
            Word,
            None
        }
    }
}
