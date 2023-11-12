﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace task05
{
    // Please, create Department class with public string property Name, int Id and Worker Manager.
    // Create constructor with string, int and Manager parameters for initializing the properties.
    // Create Worker class with public int property Id, string Name, decimal Salary and Department Department.
    // Create constructor with string, decimal, Department parameters to initialize the properties.
    // Implement public Serialize method that returns string that contains serialized Worker object in json format.
    // Worker that is created like this
    // Worker w = new Worker("Anna", 700, new Department("Mechanics", 1, new Worker("Tom", 600, null)));     *

    // should be serialized into the next string:     
    // {
    //  "Full name": "Anna",
    //  "Salary": 700,
    //  "Department": {
    //    "Name": "Mechanics",
    //    "Id": 1,
    //    "Manager": {
    //      "Full name": "Tom",
    //      "Salary": 600
    //    }
    //  }
    //}

    // note that Id property should not be serialized and Name property should be represented as Full name.
    // Also, implement public static method Deserialize that takes a string as a parameter and returns a deserialized
    // Worker object from it.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World5!");
            Worker? w = new("Anna", 700, new Department("Mechanics", 1, new Worker("Tom", 600, null)));
            string str = w.Serialize();

            Console.WriteLine(str);

            w = Worker.Deserialize(str);
            Console.WriteLine(w?.Name);

            Console.ReadKey();
        }
    }
    public class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Worker Manager { get; set; }
        public Department(string name, int id, Worker manager)
        {
            Name = name;
            Id = id;
            Manager = manager;
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonSerializable(typeof(Worker))]
    internal partial class WorkerGenerationContext : JsonSerializerContext
    {
    }

    public class Worker
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Full name")]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Department? Department { get; set; } = null;

        public Worker(string name, decimal salary, Department department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
        public string Serialize() => JsonSerializer.Serialize(
                                                                this,
                                                                WorkerGenerationContext.Default.Worker
                                                             );
        public static Worker? Deserialize(string jsonString) => JsonSerializer.Deserialize<Worker>(jsonString, WorkerGenerationContext.Default.Worker);
    }

    //public class Worker
    //{
    //    [JsonIgnore]
    //    public int Id { get; set; }
    //    [JsonPropertyName("Full name")]
    //    public string Name { get; set; }
    //    public decimal Salary { get; set; }
    //    public Department? Department { get; set; } = null;

    //    public Worker(string name, decimal salary, Department department)
    //    {
    //        Name = name;
    //        Salary = salary;
    //        Department = department;
    //    }
    //    public string Serialize() => JsonSerializer.Serialize<Worker>(this),
    //                                 options: new JsonSerializerOptions
    //                                 {
    //                                     WriteIndented = true,
    //                                     DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    //                                 });
    //    public static Worker? Deserialize(string jsonString) => JsonSerializer.Deserialize<Worker>(jsonString);
    //}
}