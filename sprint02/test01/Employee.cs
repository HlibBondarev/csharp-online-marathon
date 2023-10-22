using System;

//Class Employee should contain internal string field name and private DateTime field hiringDate.
//Class Employee should contain public constructor that accepts two arguments (name and hiringDate).
//Class Employee should contain public int method Experience() that calculates the count off full years
//of experience. This method should be the same for the derived classes.
//Class Employee should contain public void method ShowInfo() that prints the such string:
//"<name> has <Experience> years of experience".


namespace test01
{
    public class Employee
    {
        internal string name;
        DateTime hiringDate;

        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }

        public int Experience()
        {
            return (int)(DateTime.Now - this.hiringDate).TotalDays/365;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{name} has {Experience()} years of experience");
        }
    }
}
