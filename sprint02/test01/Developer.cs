using System;

//Class Developer should contain private string field programmingLanguage.
//Class Developer should contain the constructor that accepts three arguments: name, hiringDate and programmingLanguage.
//Class Developer should contain public void method ShowInfo() that prints the such string:
//"<name> has <Experience> years of experience
//< name > is < programmingLanguage > programmer".
//Please, pay attention that the first line as the same as for appropriate Employee’s method.

namespace test01
{
    public class Developer : Employee
    {
        string programmingLanguage;
        public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"{name} has {Experience()} years of experience");
        }
    }
}
