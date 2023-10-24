using System;
using System.Collections.Generic;


namespace task01
{
    public class MyAccessModifiers
    {
        // int field birthYear is unavailable anywhere except this class
        private int birthYear;

        //string field personalInfo that is accessible within descendants of this class
        protected string personalInfo;

        //string field IdNumber that is accessible only within descendants in the current assembly
        private protected string IdNumber;

        // constructor should be available from everywhere in the program and accept int for birth year,
        // string for idNumber, string for personalInfo parameters to initialize three fields mentioned above.
        // (Note, that the order of parameters must be exact as described)

        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.personalInfo = personalInfo;
            this.IdNumber = idNumber;
        }

        // int property Age which returns the difference between the current year and birthYear and can be accessed
        // everywhere, but only for reading
        public int Age => DateTime.Now.Year - birthYear;

        // common for all instances of the class byte field averageMiddleAge with default value 50
        // общее для всех экземпляров байтовое поле класса averageMiddleAge со значением по умолчанию 50
        /*public*/
        static byte averageMiddleAge = 50;

        // string property Name accessible anywhere in the current assembly
        internal string Name { get; set; }

        // string property NickName that can be read anywhere in the program and set only in the current assembly
        public string NickName { get; internal set; }

        // method HasLivedHalfOfLife available only for descendants of the class in other assemblies and for all in the current.
        /*bool*/
        internal protected void HasLivedHalfOfLife() { }

        // DRY - don't repeat your code
        // changed using an upper code
        public override bool Equals(object obj)
        {
            return obj is MyAccessModifiers modifiers && this == modifiers;
            //return obj is MyAccessModifiers modifiers &&
            //       personalInfo == modifiers.personalInfo &&
            //       Age == modifiers.Age &&
            //       Name == modifiers.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 455190543;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(personalInfo);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }


        // overload operator ==. The operator returns true if name, age, and personalInfo  of objects are equal
        public static bool operator ==(MyAccessModifiers left, MyAccessModifiers right)
        {
            return left.Name == right.Name && left.Age == right.Age && left.personalInfo == right.personalInfo;
        }
        public static bool operator !=(MyAccessModifiers left, MyAccessModifiers right)
        {
            return !(left == right);
        }
    }
}