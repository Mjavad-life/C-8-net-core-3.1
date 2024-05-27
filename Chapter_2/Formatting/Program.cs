    
using System.Linq;
using System.Reflection;
using  static System.Console;


namespace Formatting{

    public class Program{

        static void Main(string[] args)
        {
            int numberofApples = 12 ;
            decimal priceofApple = 0.35m;
            // vaghti bayad be chand khat shekaste beshe in khobe
            WriteLine(format:"{0} apple costs {1:C}",
                    arg0: numberofApples ,
                    arg1 : priceofApple * numberofApples);

            string formatted =  string.Format(
                format: "{0} apples costs {1:c}",
                    arg0: numberofApples ,
                    arg1 : numberofApples * priceofApple
            );
            // baraye code haya kotah khobe
            WriteLine($"{numberofApples} apples costs {priceofApple * numberofApples:C}");

            //writetofile(formatted) // writes the string into a file

            string applesText = "Apples";
            int applesCount = 1234;
            string bananaText = "Banana";
            int bananaCount = 56789;

            WriteLine(format: "{0,-8} {1,6:N0}" ,
                    arg0 : "Name" , arg1:"Count");

            WriteLine(format: "{0,-8} {1,6:N0}",
                    arg0: applesText , arg1: applesCount);

            WriteLine(format: "{0,-8} {1,6:N0}",
                    arg0: bananaText , arg1: bananaCount);
            // az karbar vorodi migirad
            Write(" type ur fname and press enter:");
            string? fname = ReadLine();

            Write("type ur age and press enter:");
            string? age = ReadLine();

            WriteLine($"hello {fname} , you look good for {age}.");
            // az karbar key migirad
            Write("press any key combination:");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            WriteLine("key: {0}, char: {1}, modifiers: {2}",
                    arg0: key.Key, arg1: key.KeyChar , arg2: key.Modifiers);
        }
    }
}