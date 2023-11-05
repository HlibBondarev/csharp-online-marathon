// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var myTest = new Test();
myTest.Hellow();

Console.ReadKey();

interface A
{
    void Hellow();
}

interface B
{
    void Hellow();
}

class Test: A,B
{
    public void Hellow()
    {
        Console.WriteLine("Hellow to all!");
    }
}

abstract class Test1 : A, B
{
    public abstract void Hellow();
}

public class Generic<T>
{
    public T Field;
    public void TestSub()
    {
        //return T i = Field + 1;   Operator '+' cannot be applied to operands of type 'T' and 'int'
    }
}