using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace excercise02
{
    public class Program
    {
        static void Main(string[] args)
        {
            int max = 500;

            // dar inja halghe be to daemi edame miyabad
            // chon byte max = 255
            // pas to check mizarim ke error ro bege
            checked
            {
            for (byte i = 0; i < max; i++)
            {
                WriteLine(i);
            }
            }
        }
    }
}