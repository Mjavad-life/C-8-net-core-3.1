using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace CheckingForOverflow
{
    public class Program
    {
        static void Main(string[] args)
        {
            // kar ba overflow exception
            int x = int.MaxValue - 1;
            WriteLine($" meghdare avalieh: {x}.");
            x++;
            WriteLine($"after ezafe shadan: {x}.");

            // az inja be bad overflow mishe va adad manfi neshon mideh
            x++;
            WriteLine($"after ezafe shadan: {x}.");
            x++;
            WriteLine($"after ezafe shadan: {x}.");

            // hala az checked use mikonim ta compiler overflow ro bege
           /* checked
            {
                int y = int.MaxValue - 1;
                WriteLine($" meghdare avalieh: {y}.");
                y++;
                WriteLine($"after ezafe shadan: {y}.");

                // az inja be bad overflow mishe 
                y++;
                WriteLine($"after ezafe shadan: {y}.");
                y++;
                WriteLine($"after ezafe shadan: {y}.");
                
            }*/

            // hala az try catch use mikonim ta tamiztar beshe
            try
            {   // check ro miarim to try
               /* checked
                {
                int y = int.MaxValue - 1;
                WriteLine($" meghdare avalieh: {y}.");
                y++;
                WriteLine($"after ezafe shadan: {y}.");

                // az inja be bad overflow mishe 
                y++;
                WriteLine($"after ezafe shadan: {y}.");
                y++;
                WriteLine($"after ezafe shadan: {y}.");
                */
                // code zir dar halat check mood compile error mide
                // vase hamin mibarim to halate uncheck
                unchecked
                {
                 int p = int.MaxValue + 1;
                 WriteLine($" meghdare avalie : {p}.");
                 p--;
                 WriteLine($" badaz kam shodan: {p}.");
                 p--;
                 WriteLine($" badaz kam shodan: {p}.");
                 // aval be sorate manfi mishe badesh dorost mishe
                }

               // }// payane check

            }// payane try

            catch (OverflowException)
            {
                WriteLine(" meghdar zad bala va bishtar az in nemishe.");
            }

        } // payane Main
    }
}