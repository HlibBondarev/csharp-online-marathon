namespace task301
{
    //Note! this is additional task that requires understanding of HashSet, so please, read the article: HashSet before implementing the task.
    //Implement class Student : add the constructor (with field initializations) and necessary methods into it.
    //Add public static GetCommonStudents() method to Student class that returns a HashSet of common elements of two student lists.
    //For example, for a given list1[Student[Id = 1, Name = Ivan], Student[Id = 2, Name = Petro], Student[Id = 3, Name = Stepan]]
    //and list2[Student[Id = 1, Name = Ivan], Student[Id = 3, Name = Stepan], Student[Id = 4, Name = Andriy]] you should
    //get [Student [Id=3, name=Stepan], Student[Id = 1, Name = Ivan]].


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Student> list1 = new()
            {
                { new Student(1,"Ivan") },
                { new Student(2, "Petro") },
                { new Student(3, "Stepan") },
                { new Student(3, "Stepan") },
                { new Student(3, null) }
            };

            List<Student> list2 = new()
            {
                { new Student(1,"Ivan") },
                { new Student(3, "Stepan") },
                //{ new Student(3, null) },
                { new Student(4, "Andriy") },
                { new Student(4, "Andriy") }
            };
            var commonList = Student.GetCommonStudents(list1, list2);
            foreach (var students in commonList)
            {
                Console.WriteLine(students.Id + " " + students.Name);
            }
            Console.ReadKey();
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student(int id, string name)
        {
            Id = id;
            Name = name == null ? string.Empty : name;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is not Student student)
                return false;
            return Id == student.Id && Name == student.Name;
        }
        public override int GetHashCode() => Id ^ Name.GetHashCode();
        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
        {
            HashSet<Student> hSet1 = new(list1);
            HashSet<Student> hSet2 = new(list2);
            return hSet1.Intersect(hSet2).ToHashSet();
        }
    }
}