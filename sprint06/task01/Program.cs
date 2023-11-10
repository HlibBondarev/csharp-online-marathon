using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace task01
{
    // There are children that stand in a circle.They use a counter to get them one by one out of the circle.Counter characteristic
    // is a number of syllables. Children count themselves with the counter and the child on whom the counter ends, leaves the circle.
    // You need to create class CircleOfChildren, add a constructor with IEnumerable<string> parameter that will represent children
    // in the circle.
    // Add named iterator  GetChildrenInOrder that takes two int parameters: first for syllables count and second for a count of
    // children that should leave the circle.
    // If syllables count is equal to or less than 0 than NO children leave the circle.
    // We should be able to call GetChildrenInOrder with only one parameter.In this case, all children leave the circle.
    // If the second parameter is bigger than the total amount of children in a circle than all children should leave the circle.
    // The same with 0 or less value.
    // For example, we have a circle with nicknames: Halya1, Olya2, Ira3, Andriy4, Josh5 and suppose, all children should leave the
    // circle. The counter has 3 syllables.
    // Then exit order should be: Ira3, Halya1, Josh5, Olya2, Andriy4
    // Also create OutputUtils class with static ExitOutput method that takes 3 parameters: CircleOfChildren, syllables count and
    // count of children that should leave the circle
    // The last parameter - optional.
    // The method should print to console the names of children in the order of their living the circle.Print space after every name.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var children = new CircleOfChildren(new string[] { "Halya1", "Olya2", "Ira3", "Andriy4", "Josh5" });
            OutputUtils.ExitOutput(children, 3, 18);

            Console.ReadKey();
        }
    }

    public class CircleOfChildren
    {
        private readonly IEnumerable<string> names;
        public CircleOfChildren(IEnumerable<string> names)
        {
            this.names = names;
        }

        // Named enumerator using Queue<string>
        public IEnumerable GetChildrenInOrder(int syllables, int numberOff = 0)
        {
            Queue<string> queue = new(names);
            int numberOfChildren = queue.Count;
            if (syllables <= 0 || numberOfChildren == 0)
            {
                yield break;
            }
            if (numberOff > numberOfChildren || numberOff <= 0)
            {
                numberOff = numberOfChildren;
            }
            while (numberOff > 0)
            {
                int k = syllables % numberOfChildren == 0 ? numberOfChildren - 1 : syllables % numberOfChildren - 1;
                --numberOfChildren;
                --numberOff;
                Queue<string> temp = new();
                while (true)
                {
                    if (k > 0)
                    {
                        temp.Enqueue(queue.Dequeue());
                    }
                    else if (k == 0)
                    {
                        yield return queue.Dequeue();
                    }
                    else
                    {
                        if (temp.Count == 0)
                        {
                            break;
                        }
                        queue.Enqueue(temp.Dequeue());
                    }
                    --k;
                }
            }
        }

        public IEnumerable GetChildrenInOrder1(int syllables, int numberOff = 0)
        {
            string[] children = names.ToArray();
            int numberOfChildren = children.Length;
            if (syllables <= 0 || numberOfChildren == 0)
            {
                yield break;
            }
            if (numberOff > numberOfChildren || numberOff <= 0)
            {
                numberOff = numberOfChildren;
            }
            while (numberOff > 0)
            {
                int k = syllables % numberOfChildren == 0 ? numberOfChildren - 1 : syllables % numberOfChildren - 1;
                string name = children[k];
                --numberOfChildren;
                --numberOff;
                string[] temp = new string[numberOfChildren];
                Array.Copy(children, k + 1, temp, 0, numberOfChildren - k);
                Array.Copy(children, 0, temp, numberOfChildren - k, k);
                children = temp/*.ToArray()*/;
                yield return name;
            }
        }
    }

    public class OutputUtils
    {
        public static void ExitOutput(CircleOfChildren children, int syllables, int numberOfChildren = 0)
        {
            foreach (var child in children.GetChildrenInOrder(syllables, numberOfChildren))
            {
                Console.Write($"{child} ");
            }
        }
    }
}