using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

//Please, make refactoring of the code:
//We know that adult  doesn't have childIDNumber, child doesn't have passportNumber.
//Create a public constructor in each class to initialize all their fields (make the first parameter of type int
//and the second one for name initialization).
// Accessibility of the fields should be the least possible, but the same in all assemblies.
// Add ToString() method to Child and Adult classes that will return a string in the format: "name document_number"

namespace task05
{
    class Person
    {
        protected int yearOfBirth;
        protected string name;
        protected string healthInfo;
        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }
        public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }

    class Child : Person
    {
        private string childIDNumber;

        public Child(int yearOfBirth, string name, string healthInfo, string childIDNumber) : base(yearOfBirth, name, healthInfo)
        {
            this.childIDNumber = childIDNumber;
        }
        public override string ToString()
        {
            return string.Format($"{name} {childIDNumber}");
        }
    }

    class Adult : Person
    {
        private string passportNumber;

        public Adult(int yearOfBirth, string name, string healthInfo, string passportNumber) : base(yearOfBirth, name, healthInfo)
        {
            this.passportNumber = passportNumber;
        }
        public override string ToString()
        {
            return string.Format($"{name} {passportNumber}");
        }
    }
}
