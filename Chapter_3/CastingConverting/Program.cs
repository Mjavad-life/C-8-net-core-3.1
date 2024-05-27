using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace CastingConverting
{
    public class Program
    {
        static void Main(string[] args)
        {
        /*
            int a = 10;
            double b = a; // an int can be safely cast into a double
            WriteLine(b);

            double c = 9.8;
            int d = (int)c; // compiler gives an error for this line
            // vaghti poshte c (int) ezaf kardam radif shod d=9 shod
            WriteLine(d);

            long e = 10;
            int f = (int)e; // inja e = f mishe chon e kochike
            WriteLine($"e is {e:N0} and f is {f:N0}");

            e = 5_000_000_000;
            f = (int)e; // inja long be int tabdil mishe va koli az meghdaresh kam mishe
            WriteLine($"e is {e:N0} and f is {f:N0}");

            double g = 9.8;
            int h = ToInt32(g); // h be bala gerd mishe va = 10 mishe
            WriteLine($"g is {g} and h is {h}.");

            // gerd kardan dar C#
            double[] doubles = new[]
                {9.49 , 9.5 , 9.51 , 10.49 , 10.5 , 10.51};

            foreach (double n in doubles)
            {       // double --> int va gerd kardan malom mishe
                WriteLine($"ToInt32({n}) is {ToInt32(n)}");
            }
            
            // to string kardan type haye mokhtalef
            int number = 12;
            WriteLine(number.ToString());

            bool boolean = true ;
            WriteLine(boolean.ToString());

            DateTime now = DateTime.Now;
            // fargh nadare inja tostring bezani ya na
            WriteLine(now.ToString());

            object me = new object();
            // javabesh system.object hast
            WriteLine(me.ToString());
*/
            // use of tobase64string baraye tabdil bite be string 
            // masalan vaghti mikhaim video ro to network befrestim

          /*  // allocate array of 128 bytes
            byte[] binaryObject = new byte[128];
            // populate array with random bytes
            (new Random()).NextBytes(binaryObject);

            WriteLine("Binary Object as bytes:");
            for(int index = 0; index < binaryObject.Length; index++)
            {
            Write($"{binaryObject[index]:X} ");
            }
            WriteLine();

            // convert to base64 string and output as text
            string encoded = Convert.ToBase64String(binaryObject);
            WriteLine($" binary object as base64 string: {encoded}");
*/
            // kar ba parse ke akse tostring hast
            int age = int.Parse("897"); // meghade dakhele parse() bayad be adad bashe
            DateTime birthday = DateTime.Parse("4 july 1980");

            WriteLine($" i was born {age} years ago.");
            WriteLine($" my birthday is {birthday}.");
            WriteLine($" my birthday is {birthday:D}.");


            // kar ba try parse ke baes mishe exception nade
            // use of out keyword
            WriteLine("chan ta yomorta hast?");
            int count;
            string? input = Console.ReadLine();
            if (int.TryParse(input , out count))
            {
                WriteLine($"{count} ta yomota hast.");
            }
            else
            {
                WriteLine("nemitonam the input ro parse konam");
            }
        }// end of method Main
    }
}
