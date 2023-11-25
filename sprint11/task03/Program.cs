using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System;
using System.Reflection;

namespace task03
{
    //Within the class ReflectProperties you have to:
    //1) create public class TestProperties with four properties:
    //- public string FirstName;
    //- internal string LastName;
    //- protected int Age;
    //- private string PhoneNumber.
    //2) define a static method WriteProperties() that contains logic:
    //- form the collection of the properties of TestProperties class;
    //- iterate through the collection;
    //- provide the console output of the name, type, read/write ability, and accessibility level of every property.
    //The invoke of WriteProperties() method will cause the result:

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ReflectProperties.WriteProperties();

            Console.ReadKey();
        }
    }

    class ReflectProperties
    {
        public static void WriteProperties()
        {
            foreach (PropertyInfo property in typeof(TestProperties).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"Property name: {property.Name}");
                Console.WriteLine($"Property type: {property.PropertyType}");
                Console.WriteLine($"Read-Write:    {property.CanRead && property.CanWrite}");
                Console.WriteLine("Accessibility: {0}", property.GetMethod != null
                                                      ? property.GetMethod.Accessibility()
                                                      : property.SetMethod.Accessibility());
                Console.WriteLine();
            }
        }
        public class TestProperties
        {
            public string FirstName { get; set; }
            internal string LastName { get; set; }
            protected int Age { get; set; }
            private string PhoneNumber { get; set; }
        }
    }
    public static class MethodInfoExtesions
    {
        public static string Accessibility(this MethodInfo accessor)
        {
            if (accessor.IsPublic)
                return "Public";
            else if (accessor.IsPrivate)
                return "Private";
            else if (accessor.IsFamily)
                return "Protected";
            else if (accessor.IsAssembly)
                return "Internal";
            else
                return "Protected Internal";
        }
    }
}