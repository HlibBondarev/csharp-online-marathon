using System;

//Create class Fraction with private int fields numerator and denominator that can only be initialized on creation or
//in constructor
//Create a constructor to initialize these values
//Define operators unary and binary + and - (example: Fraction(-167, 100) - Fraction(3, 2) should result in "-317 / 100")
//Define the ! operator that will return reversed fraction - with numerator as denominator and denominator as numerator
//(For example, Fraction(-3, 100) results to "-100 / 3")
//Define binary  * and / operations.
//All operations should return simplified fractions.
//Define ToString() method which will return string representing Fraction in the format numerator / denominator. 
//Value should be simplified: numerator and denominator divided by the greatest common divisor. 
//if  numerator and denominator are both negative, the fraction should become positive. 
//If only denominator is negative the sign should be outputted before numerator without space.
//Define Equals method and operators == and !=. Fractions are equal if their simplified versions are equal. 
//(for example, 20/25 is equal to 4/5)
//Define GetHashCode() method with the implementation of your choice.
//int a = numerator;
//int b = denominator;
//while (b != 0)
//{
//    var t = b;
//    b = a % b;
//    a = t;
//}

namespace task03
{
    public class Fraction
    {
        readonly int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }
            int k = GCD(denominator, numerator);
            if (numerator * denominator >= 0)
            {
                this.numerator = Math.Abs(numerator / k);
            }
            else
            {
                this.numerator = -Math.Abs(numerator / k);
            }
            this.denominator = Math.Abs(denominator / k);
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);
        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
        public static Fraction operator !(Fraction a)
        {
            return new Fraction(a.denominator, a.numerator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public override string ToString() => $"{numerator} / {denominator}";

        public override bool Equals(object obj)
        {
            // DRY - don't repeat your code
            // change using an upper code 
            return obj is Fraction fraction && this == fraction;
            //return obj is Fraction fraction &&
            //numerator == fraction.numerator &&
            //denominator == fraction.denominator;
        }

        public override int GetHashCode()
        {
            int hashCode = -671859081;
            hashCode = hashCode * -1521134295 + numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + denominator.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.numerator == right.numerator && left.denominator == right.denominator;
        }
        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }
    }
}
