using System;

//Class Tester should contain private bool field isAuthomation.
//Class Tester should contain the constructor that accepts three arguments: name, hiringDate and isAuthomation.
//Class Tester should contain public void method ShowInfo() that prints the such string
//“<name> is authomated tester and has <Experience> year(s) of experience”
//If isAuthomated field is true
//Or
//“<name> is manual tester and has <Experience> year(s) of experience”
//If isAuthomated field is false.

namespace test01
{
    public class Tester : Employee
    {
        bool isAuthomation;
        public Tester(string name, DateTime hiringDate, bool isAuthomation) : base(name, hiringDate)
        {
            this.isAuthomation = isAuthomation;
        }

        public override void ShowInfo()
        {
            if (isAuthomation)
            {
                Console.WriteLine($"{name} is authomated tester and has {Experience()} year(s) of experience");
            }
            else
            {
                Console.WriteLine($"{name} is manual tester and has {Experience()} year(s) of experience");
            }
        }
    }
}
