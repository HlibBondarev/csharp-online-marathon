using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace task11
{
    // Little boy Jimmy likes his pets and is fond of programming.
    // Jimmy has a cat Tom, a duck McDuck, a sparrow Sparry and a parrot Leya.Jimmy decided to write a program to have a little
    // report about pets' habits. 
    // But Leya is a very clever parrot.She knows about SOLID principles and LSP she loves most of all.She didn't like Jimmy's code.
    // So she mixed all the classes, methods, and interfaces.
    // At least Jimmy has only identifiers: Bird, Cat, Parrot, Duck, IFlyable, IEating, IMoving, Fly, Eat, Move, IBasking, IKryaking,
    // Bask, Krya.And he remembers that every method has to output one habit of one pet.
    // Please, define all the types and their members to help Jimmy to see the result as follows:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // IFlyable, IEating, IMoving, IBasking, IKryaking
    // Bird, Cat, Parrot, Duck
    // Fly, Eat, Move, Bask, Krya
    interface IFlyable
    {
        void Fly();
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
        void Krya();
    }
    class Bird : IFlyable, IEating, IMoving
    {
        public virtual void Eat() => Console.WriteLine("Oh! My corn!");

        public void Fly() => Console.WriteLine("I believe, I can fly");

        public virtual void Move() => Console.WriteLine("I can jump!");
    }
    class Cat : IEating, IMoving, IBasking
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
        public void Krya() => Console.WriteLine("Krya-Krya!");

        public override void Move() => Console.WriteLine("I can swimm!");
    }
}