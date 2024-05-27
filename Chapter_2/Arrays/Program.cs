using System.Linq;
using System.Reflection;
using  static System.Console;

namespace Arrays{

    public class Program{
        static void Main(string[] args)
        { 
            string[] names; // can reference any array of strings

            // allocating memory for 4 string in an array
            names = new string[4];
            names[0] = "sosan";
            names[1] = "ladan";
            names[2] = "golnar";
            names[3] = "hosna";

            // looping throgh the names
            for (int i = 0; i < names.Length; i++)
            {
                // output the items at index position i
                WriteLine($"{names[i]} nazeh.");
            }
        }
    }
}