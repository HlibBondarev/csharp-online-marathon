using System;
using System.Collections.Generic;

//Define a static method ListWithPositive that receives the List of negative and positive elements as a parameter. 
//The method  ListWithPositive uses the FindAll method on the List type. The argument to FindAll will use the anonymous
//method syntax. The predicate in FindAll will use an evaluated boolean expression, causing the anonymous function
//to return true if the argument is positive and less than or equal to 10.
//The method  ListWithPositive returns the list of positive elements.

namespace task03
{
    public class ListProgram
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { -10, 10, 45, 14, -6, 7, 10, 0, 2 };
            foreach (var item in ListWithPositive(list))
            {
                Console.WriteLine(item);
            }
        }

        public static List<int> ListWithPositive(List<int> list)
        {
            return list.FindAll(delegate (int x) { return x > 0 && x <= 10; });
        }
    }
}
