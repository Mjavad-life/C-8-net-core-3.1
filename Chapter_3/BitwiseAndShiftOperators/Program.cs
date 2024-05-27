using static System.Console;

namespace BitwiseAndShiftOperators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 10; // 1010
            int b = 6;  // 0110

            WriteLine($"a = {a}");
            WriteLine($"b = {b}");
            WriteLine($"a & b = {a & b}");// javab=2 // 2-bit colum only
            WriteLine($"a | b = {a | b}");// javab=12 // 8, 4 , and 2-bit colums
            WriteLine($"a ^ b = {a ^ b}");//javab=14 // 8 and 4-bit columns

            // 0101 0000 left-shift a by three bit columns
            WriteLine($"a << 3 = {a<<3}");//javab=80

            // multiply a by 8
            WriteLine($"a * 8 = {a * 8}");//javab=80

            // 0000 0011 right-shift b by one bit column
            WriteLine($"b >> 1 = {b >> 1}");//javab=3

        }
    }
}