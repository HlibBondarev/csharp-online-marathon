using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var r1 = new Room<Rectangle>() { Height = 25, Floor = new Rectangle { Length = 5, Width = 6 } };
var r2 = r1.Clone();    // deep copy
//var r2 = r1;          // reference copy, not shallow
r1.Floor.Width = 333;
r1.Floor.Length = 333;
r1.Height = 250;
Console.ReadKey();

//Define an Interface IShape with declared method Area() returning 0 by default (double type)
//Define a class named Rectangle implementing the IShape interface.
//In this class, define Length and Width properties(double type)
//Implement the Area() method to calculate a rectangle area
//Define a class named Trapezoid implementing the IShape interface.
//In this class, define Length1, Length2 and Width properties(double type)
//Implement the Area() method to calculate a trapezoid area
//Define a generic class named Room<> depending on a shape of it's floor.
//Impose a constraint for type argument of the Room generic class so that it should implement the IShape interface
//In this class, define a Height property(double type) and the Floor property(type argument)
//Implement the Volume() method to calculate a volume of the room.

//Add an implementation of ICloneable interface for the Room<> class
//Implement deep cloning
//Add an implementation of IComparable interface for the Room<> class.
//Implement a comparison by area of the floor.

//Define a generic class RoomComparerByVolume<> implementing IComparer interface.
//Impose a constraint on the type argument so that it should implement the IShape interface.
//This comparer should perform comparison of rooms by room volume.

interface IShape : ICloneable
{
    double Area() => 0;
}

class Rectangle : IShape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Area()
    {
        return Length * Width;
    }
    public object Clone()
    {
        return MemberwiseClone();
    }
}

class Trapezoid : IShape
{
    public double Length1 { get; set; }
    public double Length2 { get; set; }
    public double Width { get; set; }
    public double Area()
    {
        return (Length1 + Length2) / 2 * Width;
    }
    public object Clone()
    {
        return MemberwiseClone();
    }
}

class Room<T> : ICloneable, IComparable where T : IShape
{
    public double Height { get; set; }
    public /*required*/ T Floor { get; set; }
    public double Volume() => Floor.Area() * Height;
    public object Clone()
    {
        if (MemberwiseClone() is Room<T> clone)
        {
            clone.Floor = (T)Floor.Clone();
            return clone;
        }
        throw new InvalidOperationException();
    }

    // a comparison by area of the floor
    public int CompareTo(object? obj)
    {
        if (obj is Room<T> room)
        {
            return Floor.Area().CompareTo(room.Floor.Area());
        }
        else
        {
            throw new ArgumentException("Unable to compare: argument is not  Room<T>");
        }
    }
}

//Define a generic class RoomComparerByVolume<> implementing IComparer interface.
//Impose a constraint on the type argument so that it should implement the IShape interface.
//This comparer should perform comparison of rooms by room volume.
class RoomComparerByVolume<T> : IComparer<Room<T>> where T : IShape
{
    public int Compare(Room<T>? x, Room<T>? y)
    {
        return x.Volume().CompareTo(y.Volume());
    }
}

//class RoomComparerByVolume<T> : IComparer where T : IShape
//{

//    public int Compare(object? left, object? right)
//    {
//        if (left is not Room<T> x || right is not Room<T> y)
//        {
//            throw new ArgumentException("Argument is not Room<T>");
//        }
//        else if (x.Volume() > y.Volume())
//        {
//            return 1;
//        }
//        else if (x.Volume() < y.Volume())
//        {
//            return -1;
//        }
//        else
//        {
//            return 0;
//        }
//    }
//}