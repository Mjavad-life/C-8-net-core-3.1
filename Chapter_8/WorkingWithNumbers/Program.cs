using System;
using System.Numerics; // اینو وارد کردم که با اعداد درشت کار کینیم
using static System.Console;
/// <summary>
/// اینجا میخواهیم با اعداد کار کنیم
/// حالا بیا ، وای وای
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            var largest = ulong.MaxValue;

            WriteLine($"{largest,40:N0}");

            var atomsInUniverse = BigInteger.Parse("12345678909876543211234567890");

            WriteLine($"{atomsInUniverse,40:N0}");

            // complex numbers کار با اعداد پیچیده
            var c1 = new Complex(4 , 2);
            var c2 = new Complex(3 , 7);
            var c3 = c1 + c2 ;
            WriteLine($"{c1} be alaveye {c2} meshey {c3}");
            

        }
    }
}