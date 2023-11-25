using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace task02
{
    // Within the class ReflectMethod you have to:
    // 1) define the public static class Methods with three public static methods: Hello(), Welcome() and Bye(). Each of them
    // takes a string parameter and provides the console output of formatted string according to its name:
    // ("Hello:parameter={0}", parameter)
    // ("Welcome:parameter={0}", parameter)
    // ("Bye:parameter={0}", parameter)
    // 2) define the public static method InvokeMethod() which takes the string array as parameter.
    // The logic of the method involves:
    // - to form a collection of methods from the class Methods, 
    // - to iterate over this collection by the method name,
    // - to invoke the method and pass it parameters from the array one by one.
    // The call of InvokeMethod() provides the output as follows:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ReflectMethod.InvokeMethod("Jhon", "Elly");

            Console.ReadKey();
        }
    }

    public class ReflectMethod
    {
        public static class Methods
        {
            public static void Hello(string parameter) => Console.WriteLine($"Hello:parameter={parameter}");
            public static void Welcome(string parameter) => Console.WriteLine($"Welcome:parameter={parameter}");
            public static void Bye(string parameter) => Console.WriteLine($"Bye:parameter={parameter}");
        }
        public static void InvokeMethod(params string[] strings)
        {
            foreach (MethodInfo method in typeof(Methods).GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                foreach (string str in strings)
                {
                    method.Invoke(null, new object[] { str });
                }
            }
        }
    }
}