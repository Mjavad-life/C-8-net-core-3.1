using static System.Console;

namespace Operators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
                a++;
            int b = a;
            WriteLine($"a is {a} , b is {b}");

            int e = 11;
            int f = 3;
            WriteLine($"e is {e}, f is {f}");
            WriteLine($"e + f = {e + f}");
            WriteLine($"e - f = {e - f}");
            WriteLine($"e * f = {e * f}");
            WriteLine($"e / f = {e / f}");
            WriteLine($"e % f = {e % f}");

            double g = 11.0; // inja fargh int va double va decimal maliom mishe
            WriteLine($"g is {g:N1}, f is {f}");
            WriteLine($"g / f = {g / f}");
        }
    }
}