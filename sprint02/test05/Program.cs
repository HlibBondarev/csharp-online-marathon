using System;

//For finish, let’s talk about the cats. The big cats.
//Please, create class Acinonychini. This class has two sub-classes, that live now: Acinonyx and Puma.
//Create these sub-classes too. It’s known that Puma has sub-classed and they may be created later. Acinonyx has no sub-classed,
//so it’s sub-classes can’t be created anywhen.
//Create For all the classes those fields, properties and methods that you think they need.

namespace test05
{
    public class Acinonychini
    {
        private int age;
        public string Name { get; }
        public int Weight { get; }

        public Acinonychini(int age, string name, int weight)
        {
            this.age = age;
            this.Name = name;
            this.Weight = weight;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"{Name}: weight={Weight}, age={age}");
        }
    }

    public class Puma : Acinonychini
    {
        public Puma(int age, string name, int weight) : base(age, name, weight)
        {
        }
        public override void GetInfo()
        {
            Console.WriteLine("Puma");
            base.GetInfo();
        }
    }

    public sealed class Acinonyx : Acinonychini
    {
        public Acinonyx(int age, string name, int weight) : base(age, name, weight)
        {
        }
        public override void GetInfo()
        {
            Console.WriteLine("Acinonyx");
            base.GetInfo();
        }
    }
}
