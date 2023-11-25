using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace task05
{
    //Within the class ReflectFullClass define a static method WriteAllInClass(). The method will take one parameter of Type type
    //(f.e. class). 
    //The method outputs a greeting with the class and allows it to iterate through the class and output the names of all custom
    //members of the class (fields, properties, methods), interfaces, and the total quantity of every member and interface.
    //The probable result of invoking:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class ReflectFullClass
    {
        public enum MemberTypesEnum
        {
            fields, properties, methods, constructors, interfaces, classes, structures, UNKNOWN_type
        }
        //This property determines which class members are output and their order.
        public static List<MemberTypesEnum> MemberTypeDictionary { get; } = new List<MemberTypesEnum>
                                                                            {
                                                                                MemberTypesEnum.fields,
                                                                                MemberTypesEnum.properties,
                                                                                MemberTypesEnum.methods,
                                                                                MemberTypesEnum.interfaces
                                                                            };
        static MemberTypesEnum GetMemberType(MemberInfo memberInfo) => memberInfo switch
        {
            FieldInfo => MemberTypesEnum.fields,
            PropertyInfo => MemberTypesEnum.properties,
            MethodInfo => MemberTypesEnum.methods,
            ConstructorInfo => MemberTypesEnum.constructors,
            Type type => type.IsInterface ? MemberTypesEnum.interfaces
                         : type.IsClass ? MemberTypesEnum.classes
                         : type.IsClass ? MemberTypesEnum.structures
                         : MemberTypesEnum.UNKNOWN_type,
            _ => throw new ArgumentException("Unknown MemberInfo type")
        };
        public static void WriteAllInClass(Type type)
        {
            Console.WriteLine($"Hello, {type.Name}!");
            // Get all the class members we need grouped by MemberType and put them in a dictionary
            BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            var dictionary = MemberTypeDictionary.GroupJoin(type.GetMembers(bindingFlags),
                                                             mtd => mtd,
                                                             GetMemberType,
                                                             (mtd, mb) => new { MemberType = mtd, Members = mb })
                                                             .ToDictionary(mt => mt.MemberType, mt => mt.Members.ToList());
            // Remove all methods with a special name from the dictionary
            dictionary[MemberTypesEnum.methods].RemoveAll(mi => mi is MethodInfo method ? method.IsSpecialName : false);
            // Output to console
            foreach (var item in dictionary)
            {
                Console.WriteLine("There are {0} {1} in {2}:", item.Value.Count, item.Key, type.Name);
                foreach (MemberInfo mi in item.Value)
                {
                    Console.Write($"{mi.Name}, ");
                }
                Console.WriteLine();
            }
        }
    }
}