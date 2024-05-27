using System.Linq;
using System.Reflection;
using  static System.Console;

namespace Numbers{

    public class Program{
        static void Main(string[] args)
        {  
            // unsigned integer means positive whole number
            // including 0 
            uint naturalNumber = 23;

            // integer means negative or positive whole number
            // including 0
            int integerNumber = -23;

            // float means single-precision floating point
            // F suffix makes it a float literal
            float realNumber = 2.234F;

            //double means double-precision floating point
            double anotherRealNumber = 2.3065; // double literal 

            // three variables that store the number 2 million
            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;  

           /* WriteLine(double.NegativeInfinity);     
            WriteLine(binaryNotation);
            WriteLine(hexadecimalNotation);
            */
           /* Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");

            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0}\n to \n {double.MaxValue:N0}.");

            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");
            */

            Console.WriteLine("Using decimals:");
            decimal c = 0.1m; // M or m suffix means a decimal literal value
            decimal d = 0.2m;
            if (c + d == 0.3m)
            {
            Console.WriteLine($"{c} + {d} equals 0.3");
            }
            else
            {
            Console.WriteLine($"{c} + {d} does NOT equal 0.3");
            }
        }
    }
}