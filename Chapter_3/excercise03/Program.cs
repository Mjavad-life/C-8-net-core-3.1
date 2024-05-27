using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace excercise03
{
    public class Program
    {
        static void Main(string[] args)
        {   
            int count = 1;
            while (count < 101)
            {   // baraye inke dorost kar kone aval 3 va 5 ro bayad bezarim 
                // va az else if estefade konim ta 3 , 5 , 15 ro ba ham chap nakone

                // inja 3 va 5 ro ba ham mibine
                if (count % 3 == 0 && count % 5 == 0)
                {
                    WriteLine("fuzz buzz");
                }
                // inja 3 ro check mikone
                else if (count % 3 == 0)
                {
                    WriteLine("fuzz");
                }
                // inja 5 ro baresi mikone
               else if (count % 5 == 0)
                {
                    WriteLine("buzz");
                }
                // hichkodom nabod inja
                else
                {
                    WriteLine($"{count}");
                }
                count++;

            } // payane While
        }
    }
}