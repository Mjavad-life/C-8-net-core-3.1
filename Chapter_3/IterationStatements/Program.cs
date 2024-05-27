using static System.Console;
using System.IO;

namespace SelectionStatements
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            // kar ba while
/*            while (x < 10)
            {
                WriteLine(x);
                x++;
            }
            // kar ba do while
            string password = string.Empty;
            int count = 0;
            do
            {
                Write("enter your password:");
                password = ReadLine();
                count++;
            } while (password != "Pa$$word" && count <11);

            WriteLine("Corresct!");

            // kar ba for 
            for (int y = 0; y <= 10; y++)
            {
                WriteLine(y);
            }
*/
            // kar ba foreach
            string[] names = { "adam" , "sosie" , "mimot"};

            foreach (var name in names)
            {
                
                WriteLine($"{name} has {name.Length} charactersd.");
            }


        }// end of Main method
    }
}