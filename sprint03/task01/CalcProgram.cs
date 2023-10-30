using System;

//Create a program that can be used for calculation of 4 arithmetic operations (+, -, *, /) according to tasks:
//1) declare a delegate CalcDelegate referring to a function Calc with three parameters (two numbers and one - operation sign)
//   and a numerical result;
//2) define a class CalcProgram and within this class:
//2.1) define a static function Calc for computation with the same signature as the delegate. Note: in case of denominator = 0,
//     the function returns 0.
//2.2) create a public object funcCalc of delegate type and pass the function Calc as an argument.

namespace task01
{
    public delegate double CalcDelegate(double a, double b, char sign);
    public class CalcProgram
    {
        static void Main(string[] args)
        {
            double a = 15.67, b = 0;
            char[] signs = { '+', '-', '*', '/' };
            Console.WriteLine("{0} {1} {2} = {3}", a, signs[0], b, Calc(a, b, signs[0]));
            Console.WriteLine("{0} {1} {2} = {3}", a, signs[1], b, Calc(a, b, signs[1]));
            Console.WriteLine("{0} {1} {2} = {3}", a, signs[2], b, Calc(a, b, signs[2]));
            Console.WriteLine("{0} {1} {2} = {3}", a, signs[3], b, Calc(a, b, signs[3]));
        }
        public CalcDelegate funcCalc = Calc;

        public static double Calc(double a, double b, char sign)
        {
            switch (sign)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        return 0;
                    }
                    return a / b;
                default:
                    throw new ArgumentException("'sign' argument  can be = '+, -, * or /'");
            }
        }
    }
}
