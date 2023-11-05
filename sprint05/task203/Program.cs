using System.Collections.Generic;
using System;
namespace task203
{
//Implement the ReverseNotebook() method that creates a new dictionary with name as key and list of phones as value.The method receives
//a dictionary with phone as key and name as value.
//For example, for a given dictionary {0967654321=Petro, 0677654321=Petro, 0501234567=Ivan, 0970011223=Stepan, 0631234567=Ivan}
//you should get {Ivan=[0501234567, 0631234567], Petro = [0967654321, 0677654321], Stepan = [0970011223]}.

//The method should work with entry notebook containing empty or null names without throwing exceptions. Use empty string as a key for null names.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Dictionary<string, string> dic = new Dictionary<string, string> {
                { "0967654321", "Petro" },
                { "0677654321", "Petro" },
                { "0501234567", "Ivan"  },
                { "0970011223", "Stepan"},
                { "0631234567", "Ivan"  } ,
                { "XXXXXXXXXX", null}
            };

            var temp = ReverseNotebook(dic);

            Console.ReadKey();
        }

        public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames)
        {
            return CreateNotebook(phonesToNames).ToDictionary(x => x.Key, x => x.ToList());
        }

        public static Lookup<string, string> CreateNotebook(Dictionary<string, string> phonesToNames)
        {
            return (Lookup<string, string>)phonesToNames.ToLookup(p => p.Value == null ? string.Empty : p.Value, p => p.Key);
        }
    }
}