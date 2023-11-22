using System.Buffers.Text;
using System.Data;
using System.Threading.Tasks;

namespace task14
{
    // Based on specifications, we need to create an interface ILead and a TeamLead class to implement it.
    //public interface ILead
    //{
    //    void CreateSubTask();
    //    void AssignTask();
    //    void WorkOnTask();
    //}
    //public class TeamLead : ILead
    //{
    //    public void AssignTask()
    //    {
    //        // code to assign a tsk;
    //    }
    //    public void CreateSubTask()
    //    {
    //        // code to create a sub task
    //    }
    //    public void WorkOnTask()
    //    {
    //        // code to implement perform assigned task
    //    }
    //}
    //// Later another role like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced
    //// into the system. We tried to implement an ILead interface in the Manager class directly.
    //public class Manager : ILead
    //{
    //    public void AssignTask()
    //    {
    //        // code to assign a tsk;
    //    }
    //    public void CreateSubTask()
    //    {
    //        // code to create a sub task
    //    }
    //    public void WorkOnTask()
    //    {
    //        throw new Exception("Manager can't work on task");
    //    }
    //}
    // Here we are forcing the Manager class to implement a WorkOnTask() method without a purpose. This is wrong. The
    // design violates ISP. 
    // But later one more role appears: Programmer that can only work on tasks.We need to divide the responsibilities
    // by segregating the ILead interface. Your task is to refactor the solution.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public interface IProgrammer
    {
        void WorkOnTask();
    }
    public interface ILead
    {
        void CreateSubTask();
        void AssignTask();
    }
    public class TeamLead : ILead, IProgrammer
    {
        public void AssignTask()
        {
            // code to assign a tsk;
        }
        public void CreateSubTask()
        {
            // code to create a sub task
        }
        public void WorkOnTask()
        {
            // code to implement perform assigned task
        }
    }
    public class Manager : ILead
    {
        public void AssignTask()
        {
            // code to assign a tsk;
        }
        public void CreateSubTask()
        {
            // code to create a sub task
        }
    }
    public class Programmer : IProgrammer
    {
        public void WorkOnTask()
        {
            // code to implement perform assigned task
        }
    }
}