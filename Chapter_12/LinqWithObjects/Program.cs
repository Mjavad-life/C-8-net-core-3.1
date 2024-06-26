﻿using System.Linq;
using System;
using static System.Console;


namespace LinqWithObjects
{
    public class Program
    {
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] {"Michael","Sosan","Joboli","Davod",
            "Anghozeh","Keivon","Totia","Cream"};

         //   var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            //var query = names.Where(NameLongerThanFour);
            var query = names.Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);
            foreach (string item in query)
            {
                WriteLine(item);                
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };

            var numberErrors = errors.OfType<ArithmeticException>();

            foreach (var error in numberErrors)
            {
                WriteLine(error);
            }
        }

        static void Main(string[] args)
        {
            //LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }
    }
}