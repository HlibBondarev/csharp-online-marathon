// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Define an interface IAnimal with property Name, methods Voice() and Feed()
//Define two classes Cat and Dog, which implement this interface.
//For the class Dog,
//the Voice() method should print "Woof" on the Console,
//the Feed() method should print "I eat meat" on the Console.
//For the class Cat,
//the Voice() method should print "Mew" on the Console,
//the Feed() method should print "I eat mice" on the Console

public interface IAnimal
{
    string Name { get; set; }
    void Voice();
    void Feed();
}

class Cat : IAnimal
{
    public string Name { get; set; }

    public void Feed()
    {
        Console.WriteLine("I eat mice");
    }

    public void Voice()
    {
        Console.WriteLine("Mew");
    }
}

class Dog : IAnimal
{
    public string Name { get; set; }

    public void Feed()
    {
        Console.WriteLine("I eat meat");
    }

    public void Voice()
    {
        Console.WriteLine("Woof");
    }
}