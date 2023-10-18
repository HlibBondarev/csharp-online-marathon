using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task01
{
    public class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        internal protected string IdNumber;

        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.personalInfo = personalInfo;
            this.IdNumber = idNumber;
        }

        // int property Age which returns the difference between the current year and birthYear and can be accessed
        // everywhere, but only for reading
        public int Age => birthYear - DateTime.Now.Year;

        // common for all instances of the class byte field averageMiddleAge with default value 50
        // общее для всех экземпляров байтовое поле класса averageMiddleAge со значением по умолчанию 50
        /*public*/ static byte averageMiddleAge = 50;

        // string property Name accessible anywhere in the current assembly
        internal string Name { get; set; }

        // string property NickName that can be read anywhere in the program and set only in the current assembly
        public string NickName { get; internal set; }

        // method HasLivedHalfOfLife available only for descendants of the class in other assemblies and for all in the current.
        /*bool*/internal protected void HasLivedHalfOfLife() { }


        // overload operator ==. The operator returns true if name, age, and personalInfo  of objects are equal



    }
}
