using System.Collections.Generic;
using static System.Console;

/// <summary>
///  روش کار با دیکشنری رو نشون میده
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int" , "32-bit integer data type");
            keywords.Add("long","64-bit integer data type");
            keywords.Add("float","single precision floating point number");

            WriteLine("kelid vazheha va maani anha:");
            foreach (KeyValuePair<string,string> item in keywords)
            {
                WriteLine($"  {item.Key}: {item.Value}");
            }
            WriteLine($" maenie long {keywords["long"]} hast.");
        }
    }
}