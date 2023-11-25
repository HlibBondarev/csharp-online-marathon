//using System.Reflection;

using System.Reflection;
using System.Collections.Generic;

namespace task01
{
    // Create a class ReflectFields with public static string field Name and three public static int fields: MeasureX, MeasureY, and
    // MeasureZ.
    // Within this class define a public static method OutputFields() which contains the loop through fields of the class ReflectFields
    // and display(in console) their names and values as the formatted string ("{0} (<type>) = {1}", name, value). <type> means
    // the string representation of int or string type of field.
    // Note.System.Reflection provides a way to enumerate fields and properties. We get the FieldInfo objects for those fields and
    // then display them.
    // After the values are set and the method has invoked the output:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ReflectFields.MeasureX = 100;
            ReflectFields.MeasureY = 50;
            ReflectFields.MeasureZ = 300;
            ReflectFields.Name = "Programming";
            ReflectFields.OutputFields();

            Console.ReadKey();

        }
    }

    class ReflectFields
    {
        public static string Name;
        public static int MeasureX, MeasureY, MeasureZ;
        public static void OutputFields()
        {
            typeof(ReflectFields).GetFields().ToList().ForEach
                (x => Console.WriteLine($"{x.Name} ({x.FieldType.Alias()}) = {x.GetValue(x)}"));
        }
    }

    static class TypeExtensions
    {
        static Dictionary<Type, string> Aliases = new Dictionary<Type, string>()
            {
                { typeof(byte), "byte" },
                { typeof(sbyte), "sbyte" },
                { typeof(short), "short" },
                { typeof(ushort), "ushort" },
                { typeof(int), "int" },
                { typeof(uint), "uint" },
                { typeof(long), "long" },
                { typeof(ulong), "ulong" },
                { typeof(float), "float" },
                { typeof(double), "double" },
                { typeof(decimal), "decimal" },
                { typeof(object), "object" },
                { typeof(bool), "bool" },
                { typeof(char), "char" },
                { typeof(string), "string" },
                { typeof(void), "void" },
                { typeof(byte?), "byte?" },
                { typeof(sbyte?), "sbyte?" },
                { typeof(short?), "short?" },
                { typeof(ushort?), "ushort?" },
                { typeof(int?), "int?" },
                { typeof(uint?), "uint?" },
                { typeof(long?), "long?" },
                { typeof(ulong?), "ulong?" },
                { typeof(float?), "float?" },
                { typeof(double?), "double?" },
                { typeof(decimal?), "decimal?" },
                { typeof(bool?), "bool?" },
                { typeof(char?), "char?" }
            };
        public static string Alias(this Type type)
        {
            return Aliases.ContainsKey(type) ? Aliases[type] : string.Empty;
        }
    }
}