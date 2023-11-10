using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;

namespace task06
{
    //    Suppose, you have classes Student and Group:
    /*class Student
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string GroupName { get; set; }
    }
    class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Popularity { get; set; }
    }*/

    // Please, implement the CreateGroups method that takes a list of students as a first parameter and a list of groups as a second.
    // The method should return a string that contains for all groups the next information:
    // group name, average rating and the list of students in the group in the following format
    //     [
    //      {
    //        "group": "group_name",
    //    "description": "group_description",
    //    "rating": average_rating,
    //    "students": [
    //      {
    //            "FullName": "Name_of_student",
    //        "AvgMark": students_rating
    //      },
    //      {
    //            "FullName": "Ivan",
    //        "AvgMark": 68.34
    //      },
    //      {
    //            "FullName": "Oleh",
    //        "AvgMark": 98.34
    //      },
    //      {
    //            "FullName": "Katya",
    //        "AvgMark": 88.34
    //      }
    //    ]
    //  },
    //  ...
    //]
    // Tip: you can use GroupJoin to join collection with grouping.

    // Use JSON serialization to generate output in the specified format.
    // (You don't need to verify on null parameter values. Assume that parameters will always be not null)

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Student> students = new List<Student>()
            {
                new Student() { Name = "Name1", Rating = 80.00, GroupName = "group_name" },
                new Student() { Name = "Ivan1", Rating = 68.34, GroupName = "group_name" },
                new Student() { Name = "Oleh1", Rating = 98.34, GroupName = "group_name" },
                new Student() { Name = "Katya", Rating = 88.34, GroupName = "group_name" },
                new Student() { Name = "Vasia", Rating = 90.00, GroupName = "group_name" },
                new Student() { Name = "Peter", Rating = 90.00, GroupName = "group_name" }
            };

            List<Group> groups = new List<Group> { new Group() { Name = "group_name", Description = "group_description" } };


            string result = CreateGroups(students, groups);
            Console.WriteLine(result);

            Console.ReadKey();
        }
        public static string CreateGroups(List<Student> students, List<Group> groups)
        {
            var query = groups.GroupJoin(students,
                         group => group.Name,
                         student => student.GroupName,
                         (group, studentCollection) =>
                             new
                             {
                                 group = group.Name,
                                 description = group.Description,
                                 rating = studentCollection.Average(st => st.Rating),
                                 students = studentCollection.Select(st => new { FullName = st.Name, AvgMark = st.Rating })
                             });
            return JsonSerializer.Serialize(query, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    class Student
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string GroupName { get; set; }
    }
    class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Popularity { get; set; }
    }
}