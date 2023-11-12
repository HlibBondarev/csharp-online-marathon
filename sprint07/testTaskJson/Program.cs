namespace testTaskJson
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    //using System.Xml.Serialization;
    internal class Program
    {
        // Please, write a LINQ expression that selects users who have less than 18 years and speak Ukrainian.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<User> users = new List<User>
            {
                new User {Name="Ann", Age=20, Languages = new List<string> {"English", "Ukrainian" , "French"}},
                new User {Name="Jim", Age=25, Languages = new List<string> {"Greek", "Spanish" }},
                new User {Name="Eva", Age=29, Languages = new List<string> {"Ukrainian", "English" }},
                new User {Name="Tomс", Age=54, Languages = new List<string> {"Polish", "German" }}
            };

            var selectedUsers = users.Where(user => user.Age > 18 && user.Languages.Exists(lang => lang == "Ukrainian"));
            Console.WriteLine(selectedUsers.Count());

            var tom1 = new User { Name = "Tomс", Age = 54, Languages = new List<string> { "Polish", "German" } };
            tom1.Print();
            myEnam en = new myEnam();

            en.Pr();

            Реrsоn tom = new Реrsоn() { Name = "Tоm", Age = 35, Hobby = "knitting" };
            tom.SetSurname("Petrenko");
            string json = JsonSerializer.Serialize<Реrsоn>(tom);
            Реrsоn restordPerson = JsonSerializer.Deserialize<Реrsоn>(json);

            Console.WriteLine($"Nаmе: {restordPerson.Name}, Surnаmе:{restordPerson.GetSurname()},  Аgе: {restordPerson.Age}, Ноbby: {restordPerson.Hobby}");




            Console.ReadKey();
        }
    }

    public class Реrsоn
    {
        private string Surname { get; set; } = "Zelensky";
        [JsonPropertyName("firstnаmе")]
        public string Name { get; set; }
        [JsonIgnore]
        public int Age { get; set; }
        public string Hobby;
        public string GetSurname() { return Surname; }
        public void SetSurname(string surname) { Surname = surname; }

    }

    enum myEnam
    {
        one, two, three, four, five, six, seven
    }
    struct User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
    }

    static class StructExtention
    {
        public static void Print(this User user)
        {
            Console.WriteLine(user.Age);
        }

        public static void Pr(this myEnam myEnam)
        {
            Console.WriteLine(myEnam.five);
        }
    }
}