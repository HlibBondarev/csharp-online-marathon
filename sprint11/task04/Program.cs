using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace task04
{
    //Within the class ReflectorAssembly you have to:
    //1) define three classes LargeBox, Box, and SmallBox.Each of them contains two static methods with string parameter size:
    //-  UnPackingBox() outputs in console("I am unpacking {0} box.", size);
    //- InBox() - ("I am in {0} box.", size);
    //2) define two interfaces: 
    //- ILookingForBox with static method LookForBox() takes string parameter;
    //- IPackingBox with static method PackBox() takes a string parameter.
    //3) define the static method WriteAssemblies() which contains the following logic:
    //- get calling assembly;
    //- get all types within the assembly;
    //- iterating through the collection of types;
    //- providing the output is it class, method, and name of the type;
    //- all methods of the class have to be invoked with the parameter according to the name of the class.
    //Note.You have to exclude classes Task and Reflector(with their methods) from the output.
    //The result of the method WriteAssemblies() invoking:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ReflectorAssembly.WriteAssemblies();

            Console.ReadKey();
        }
    }

    public class ReflectorAssembly
    {
        public static void WriteAssemblies()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.Name == "Task" || type.Name == "Reflector" || type.Name == "TypeExtensions") continue;
                Console.WriteLine("{0}: {1}", type.IsInterface ? "Interface" : type.IsClass? "Class": type.IsValueType? "structure": "UNKNOWN TYPE", type.Name);
                MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"Method: {method.Name}");
                    if (method.IsAbstract|| method.Name == "WriteAssemblies") continue;
                    method.Invoke(null, new object[] { type.GetSize() });
                }
            }
        }
        public class LargeBox
        {
            public static void UnPackingBox(string size) => Console.WriteLine("I am unpacking {0} box.", size);
            public static void InBox(string size) => Console.WriteLine("I am in {0} box.", size);
        }
        public class Box
        {
            public static void UnPackingBox(string size) => Console.WriteLine("I am unpacking {0} box.", size);
            public static void InBox(string size) => Console.WriteLine("I am in {0} box.", size);
        }
        public class SmallBox
        {
            public static void UnPackingBox(string size) => Console.WriteLine("I am unpacking {0} box.", size);
            public static void InBox(string size) => Console.WriteLine("I am in {0} box.", size);
        }
        public interface ILookingForBox
        {
            void LookForBox(string parameter);
        }
        public interface IPackingBox
        {
            void PackBox(string parameter);
        }
    }
    public static class TypeExtensions
    {
        static Dictionary<Type, string> BoxTypes = new Dictionary<Type, string>()
            {
                { typeof(ReflectorAssembly.LargeBox), "large" },
                { typeof(ReflectorAssembly.Box), "middle" },
                { typeof(ReflectorAssembly.SmallBox), "small" }
        };
        public static string GetSize(this Type type)
        {
            return BoxTypes.ContainsKey(type) ? BoxTypes[type] : string.Empty;
        }
    }
}