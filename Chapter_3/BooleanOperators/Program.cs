using static System.Console;

namespace BooleanOperators
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            bool b = false;

            WriteLine($"And  | a     | b    ");
            WriteLine($"a    | {a&a,-5} | {a&b,-5} ");
            WriteLine($"b    | {b&a,-5} | {b&b,-5} ");
            WriteLine();
            WriteLine($"OR   | a     | b    ");
            WriteLine($"a    | {a | a,-5} | {a | b,-5}");
            WriteLine($"b    | {b | a,-5} | {b | b,-5}");
            WriteLine();
            WriteLine($"XOR  | a     | b    ");
            WriteLine($"a    | {a ^ a ,-5} | {a ^ b,-5}");
            WriteLine($"b    | {b ^ a,-5}  | {b ^ b,-5}");

            // vaghti az && be jaye & use mikonim bar dovom
            // dostuff ro call nemikone chon b false pas javab
            // hatman false
            WriteLine($"a & DoStuff() = {a && DoStuff()}");
            WriteLine($"b & DoStuff() = {b && DoStuff()}");
            

        }// ENDE  meth MAIN

        private static bool DoStuff()
        {
            WriteLine(" i am doing some stuff.");
            return true ;
        }
    }
}