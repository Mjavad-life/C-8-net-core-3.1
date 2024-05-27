using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace Debugging
{
    public class Program
    {
        static double Add(double a, double b)
        {
            return a + b; // deliberate bug
        }

        static void Main(string[] args)
        {
                double a = 4.5;
                var b =2.5;
                double javab = Add(a,b);
                // amdan khata dorost kard
                WriteLine($"{a}+{b} = {javab}");
                ReadLine();
        }
    }
}