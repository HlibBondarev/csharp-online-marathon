using System;

//Define an event  Show of EventHandler type.

//Define four static methods: Dog(), Cat(), Mouse(), Elephant().Each method outputs the corresponding inscription of an animal:
//"Dog", "Cat", "Mouse" or "Elephant".

//Define the class EventProgram and constructor with these four method instances added to the invocation list of Show event.
//Invoke event out of the constructor. 


namespace task05
{
    public class EventProgram
    {
        static void Main(string[] args)
        {
            new EventProgram();
        }
        public event EventHandler Show;

        public EventProgram()
        {
            Show += Dog;
            Show += Cat;
            Show += Mouse;
            Show += Elephant;
            Show?.Invoke(this, EventArgs.Empty);
        }

        public static void Dog(object sender, EventArgs e) { Console.WriteLine("Dog"); }
        public static void Cat(object sender, EventArgs e) { Console.WriteLine("Cat"); }
        public static void Mouse(object sender, EventArgs e) { Console.WriteLine("Mouse"); }
        public static void Elephant(object sender, EventArgs e) { Console.WriteLine("Elephant"); }
    }
}
