namespace task111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo(new Pet[]
                                        {
                                            new Parrot() { Name = "Leya" },
                                            new Bird() { Name = "Sparry" },
                                            new Duck() { Name = "McDuck" },
                                            new Cat() { Name = "Tom" }
                                        });
            zoo.GetReport();

            Console.ReadKey();
        }
    }

    // IFlyable, IEating, IMoving, IBasking, IKryaking
    // Bird, Cat, Parrot, Duck
    // Fly, Eat, Move, Bask, Krya

    // To make easier managing all pets, I added two classes:
    // Pet and Zoo.
    class Pet
    {
        public string Name { get; set; }
        // Template method
        public void GetPetInfo()
        {
            (this as IFlyable)?.Fly();
            (this as IEating)?.Eat();
            (this as IBasking)?.Bask();
            (this as IKryaking)?.Krya();
            (this as IMoving)?.Move();
            Console.WriteLine();
        }
    }
    class Zoo
    {
        Pet[] pets;
        public Zoo(params Pet[] pets)
        {
            this.pets = pets;
        }
        public void GetReport()
        {
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"{pet.GetType().Name} {pet.Name}:");
                pet.GetPetInfo();
            }
        }
    }
    //------------------------------------------------
    // In client program:
    //Zoo zoo = new Zoo(new Pet[]
    //{
    //    new Parrot() { Name = "Leya" },
    //    new Bird() { Name = "Sparry" },
    //    new Duck() { Name = "McDuck" },
    //    new Cat() { Name = "Tom" }
    //});
    //zoo.GetReport();
    // --------------------------------------------------

    interface IFlyable
    {
        void Fly() => Console.WriteLine("I believe, I can fly");
    }
    interface IEating
    {
        void Eat();
    }
    interface IMoving
    {
        void Move();
    }
    interface IBasking
    {
        void Bask();
    }
    interface IKryaking
    {
        void Krya() => Console.WriteLine("Krya-Krya!");
    }

    class Bird : Pet, IFlyable, IEating, IMoving
    {
        public virtual void Eat() => Console.WriteLine("Oh! My corn!");
        // only for passing tests
        //public void Fly() => Console.WriteLine("I believe, I can fly");
        public virtual void Move() => Console.WriteLine("I can jump!");
    }

    class Cat : Pet, IEating, IMoving, IBasking
    {
        public virtual void Eat() => Console.WriteLine("Oh! My milk!");
        public void Bask() => Console.WriteLine("Mrrr-Mrrr-Mrrr...");
        public void Move() => Console.WriteLine("I can jump!");
    }

    class Parrot : Bird, IBasking, IKryaking
    {
        public override void Eat() => Console.WriteLine("Oh! My seeds and fruits!");
        public void Bask() => Console.WriteLine("Chuh-Chuh-Chuh...");
        public void Krya() => Console.WriteLine("Krya-Krya-Krya...");
    }

    class Duck : Bird, IKryaking
    {
        // only for passing tests
        //public void Krya() => Console.WriteLine("Krya-Krya!");
        public override void Move() => Console.WriteLine("I can swimm!");
    }
}