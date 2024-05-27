using static System.Console;
using System;
using System.Text.RegularExpressions;
using static System.Convert;

/// <summary>
/// رو تمرین میکنه regular Expression اینجا کار با 
/// </summary>
namespace Name
{   
    public class Program
    {   
        static void Main(string[] args)
        {   

            bool Edameh = true;
            while(Edameh)
            {
            WriteLine(" Yek Regular Expression dar vakon  ya ENTER bezan vase pish farz:");
            string Rex = ReadLine();
            var RexAsRegex = new Regex(Rex);
            if (string.IsNullOrWhiteSpace(Rex))
            {
                RexAsRegex = new Regex(@"^[a-z]+$");
            }

            WriteLine(" Yek Jomleh ya Vorodi dar Kon:");
            string Vared = ReadLine();

            if (RexAsRegex.IsMatch(Vared))
            {
                WriteLine("{0} Mikhone ba {1}",
                arg0:Vared , arg1: RexAsRegex);
                
            }
            else
            {
                WriteLine("{0} Namishovad ba {1}...",
                arg0: Vared , arg1: RexAsRegex);
            }
            WriteLine("Dokmeh ESC ro befeshar vase payan ya har kelid dige baray edame.");
            //var kelid = ReadLine();
            //ConsoleKey Majic = ConsoleKey.Escape;
            //ConsoleKey Esc =Convert.ChangeType(kelid) ;
            // رو مینویسه ولی باید دکمه شو فشار بده Escape اینجا مشکل اینه که 
           
            // در کنسول به روش زیر حل شد Escape مشکل وارد کردن دکمه
            // استفاده میکنیم ReadKey(true) از ReadLine() به جای 

            var Vared_Kon = ReadKey(true); 
            var Escape = ConsoleKey.Escape;
            // آن بهره میبریم Key است از Escape برای اینکه مشخص بشه دکمه وارد شده همان 
            if (Vared_Kon.Key == Escape)
            {

                Edameh = false;
            }
            else
            {
                Edameh = true;
            }

            } // End of While


        }
    }
}