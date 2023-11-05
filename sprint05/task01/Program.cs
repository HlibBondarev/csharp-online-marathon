// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Hello, World!");
//MyProgram.Position(new List<int> { 2, 3, 4, 5, -1, 3, 4, 2, 3, 4, 5, -1, 3, 5, 4 });
//MyProgram.Remove(new List<int> { 2, 3, 4, 5, -1, 3, 4, 2, 3, 4, 5, -1, 3, 5, 4 });
//MyProgram.Insert(new List<int> { 2, 3, 4, 5, -1, 3, 4, 2, 3, 4, 5, -1, 3, 5, 4 });
MyProgram.Sort(new List<int> { 2, 3, 4, 5, -1, 3, 4, 2, 3, 4, 5, -1, 3, 5, 4 });
Console.ReadKey();


//In class MyProgram :
//  1) Create a method that should take a collection of arguments Position(List<int> numbers) in which find and Console.WriteLine
//  all positions of element 5 in this collection

//  2) Create a method that should take a collection of arguments Remove(List<int> numbers) in which remove from collection all
//  elements, which are greater than 20. and print collection

//  3) Create a method that should take a collection of arguments Insert(List<int> numbers)  in which insert elements -5,-6,-7
//  in positions 3, 6, 8 and print collection

// 4) Create a method that should take a collection of arguments Sort(List<int> numbers) in which sorting collection and print collection

public class MyProgram
{
    public static void Position(List<int> numbers)
    {
        int i = 0;
        int number = 5;
        while (true)
        {
            i = numbers.FindIndex(i, x => x == number);
            if (i == -1)
            {
                break;
            }
            Console.WriteLine(++i);
        }
    }
    public static void Remove(List<int> numbers)
    {
        int number = 20;
        numbers.RemoveAll(x => x > number);
        Print(numbers);
    }
    public static void Insert(List<int> numbers)
    {
        int[] insertElements = { -5, -6, -7 };
        int[] positions = { 3, 6, 8 };
        int count = insertElements.Length > positions.Length ? positions.Length : insertElements.Length;
        for (int i = 0; i < count; i++)
        {
            numbers.Insert(positions[i], insertElements[i] - 1);
        }
        Print(numbers);
    }

    public static void Sort(List<int> numbers)
    {
        numbers.Sort();
        Print(numbers);
    }

    static void Print(IEnumerable<int> numbers)
    {
        foreach (var i in numbers)
        {
            Console.WriteLine(i);
        }
    }
}


