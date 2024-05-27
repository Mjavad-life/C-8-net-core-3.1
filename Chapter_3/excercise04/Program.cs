using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace excercise04
{
    public class Program
    {
        static void Main(string[] args)
        {
            // inja handle exception kardam ba try catch
            try
            {   
                Write(" ye adad benevis :");
                //string? input1 = ReadLine();
                double avali = ToDouble(ReadLine());

                WriteLine(" ye adad dige benevis:");
               // string? input2 = ReadLine();
                double dovomi = ToDouble(ReadLine());

                double javab ;
                javab = avali / dovomi;
                WriteLine($" javab mishe {javab}");

            } // payane try

            catch (FormatException)
            {
            WriteLine(" oskol in chie vared kardi!!!!");
            }

        }  // payane Main
    }
} 