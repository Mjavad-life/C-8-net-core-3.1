using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace HandlingExceptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine(" ghabl az parse");
            Write("chand salete?");
            string? input = Console.ReadLine();

            /// <summary>
            ///  use of try catch to handle exceptions
            /// </summary>
            
            try
            {
                int age = int.Parse(input);
                WriteLine($"you are {age} sale.");
            }

            // hala az ye catch dige baraye overflow exception
            // use mikone
            catch(OverflowException)
            {
                WriteLine(" che khabare in hame adad zadi?");
            }

            // hala az yek model exception baraye format use mikone
            // catch dovom az kar oftad
            catch(FormatException)
            {
                WriteLine(" seni ke vared kardi be dard amat mikhore.");
            }

            // mishe system.exception gozasht ke type khata ro moshakhas 
            // mikone
            // mishe az exception ham use kard 
            catch (Exception we )
            {
                // mitone khali bashe
                // inja type exception va payame on moshakhas mishe
                WriteLine($"{we.GetType()} mige {we.Message}");
            }
            WriteLine("after parsing.");



        }   ////// payane Main
    }
}