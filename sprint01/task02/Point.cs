using System;
using System.Security.Cryptography.X509Certificates;

//Create a Point class which models a 2D point with x and y coordinates should contain:
//Two instance variables x and y  of int type, that will be available only in this class.
//A constructor that constructs a point with the given x and y coordinates.
//A method GetXYPair() which returns the x and y in a 2-element int array. This method should be available everywhere
//in the current assembly
//A method called Distance(int x, int y) that returns the distance (double) from this point to another point at the given (x, y)
//coordinates.
//An overloaded Distance(Point point) method that returns the distance from this point to the given Point instance.
//The distance methods should be available everywhere in the current assembly and in descendant classes in other assemblies;
//Create explicit cast to double operator that returns the distance (double) from this point to the origin (0, 0).

namespace task02
{
    public class Point
    {
        readonly int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair()
        {
            return new int[] { x, y };
        }

        internal protected double Distance(int x, int y)
        {
            return Point.Distance(this.x, this.y, x, y);
        }
        // DRY - don't repeat your code
        // Changed using an upper code 
        internal protected double Distance(Point point)
        {
            return Distance(point.x, point.y);
        }
        // DRY - don't repeat your code,
        // Changed using an upper code 
        public static explicit operator double(Point point)
        {
            return Point.Distance(0, 0, point.x, point.y);
            //return new Point(0, 0).Distance(point);
        }

        private static double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
        }
    }
}
