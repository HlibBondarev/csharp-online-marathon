namespace task02
{
    //We have the next collection:  
    //Dictionary<string, string> persons = new Dictionary<string, string>();
    //            {
    //                persons.Add("id11111", "Admin");
    //                persons.Add("id12345", "User1");
    //                persons.Add("id98765", "User2");
    //                persons.Add("id56743", "User3");
    //                persons.Add("id73920", "User4");
    //            }
    //1) In class MyProgram please create a method that should take a collection of arguments SearchKeys(Dictionary<string, string> persons)
    //   in which print all keys from this collection
    //2) method that should take a collection of arguments SearchValues(Dictionary<string, string> persons) in which print all values from
    //   this collection
    //3) and method that should take a collection of arguments SearchAdmin(Dictionary<string, string> persons) in which search value "Admin"
    //   and print information in format Key + " " + Value 
    internal class MyProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Dictionary<string, string> persons = new Dictionary<string, string>();
            {
                persons.Add("id11111", "Admin");
                persons.Add("id12345", "User1");
                persons.Add("id98765", "User2");
                persons.Add("id56743", "User3");
                persons.Add("id73920", "User4");
            }
            SearchKeys(persons);
            SearchValues(persons);
            SearchAdmin(persons);

            Console.ReadKey();
        }

        public static void SearchKeys(Dictionary<string, string> persons)
        {
            Print(persons.Keys.ToList<string>());
        }
        public static void SearchValues(Dictionary<string, string> persons)
        {
            Print(persons.Values.ToList<string>());
        }
        public static void SearchAdmin(Dictionary<string, string> persons)
        {
            string val = "Admin";
            var collection= from p in persons
                            where p.Value == val
                            select string.Format($"{p.Key} {p.Value}");
            Print(collection);
        }
        static void Print(IEnumerable<string> numbers)
        {
            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }
        }
    }
}