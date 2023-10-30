﻿using System;

//Define a class StringExtensions with an extension method WordCount(…) for class String that counts the number of words
//in a given string. 

//Notes. 
// 1. The 'word' means the sequence of letters, digits, and service symbols, which are limited by a space or punctuation symbol.
// 2. Try to use string.Split() method and pass array of delimiters (' ', '.', '?', '!', '-', ';', ':', ',') as the first parameter. 

namespace task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "gazfxgcx hfj hdjsrj hdjsk sjktul, ";
            Console.WriteLine(str.WordCount());
        }

    }

    public static class StringExtensions
    {
        public static int WordCount(this string s)
        {
            return s.Split(new char[] { ' ', '.', '?', '!', '-', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
