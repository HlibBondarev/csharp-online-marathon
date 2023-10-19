using System;

namespace task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person1 person1 = new Person1(1, "A");
            Person1 person2 = person1;
            person2.Name = "B";
            Console.WriteLine($"{person1}:{person1.GetHashCode()}:{person1.Name.GetHashCode()} - {person2}:{person2.GetHashCode()}:{person2.Name.GetHashCode()}");
            person1.Name = "B";
            Console.WriteLine($"{person1}:{person1.GetHashCode()}:{person1.Name.GetHashCode()} - {person2}:{person2.GetHashCode()}:{person2.Name.GetHashCode()}");


            Person2 person21 = new Person2(1, "A");
            Person2 person22 = person21;
            person22.Name = "B";
            Console.WriteLine($"{person21}:{person21.GetHashCode()}:{person21.Name.GetHashCode()} - {person22}:{person22.GetHashCode()}:{person22.Name.GetHashCode()}");
        }
    }

    struct Person1
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Person1(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public override string ToString() { return string.Format("{0}) {1}", Id, Name); }
    }

    class Person2
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Person2(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public override string ToString() { return string.Format("{0}) {1}", Id, Name); }
    }
}
