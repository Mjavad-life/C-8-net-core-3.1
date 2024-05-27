using System;
using static System.Console;
using System.Text.RegularExpressions;

/// <summary>
/// رو نشون میده Regular Expression اینجا کار با 
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            Write("senet cheghadreh:");
            string vorodi = ReadLine();
                    // بود بعد تغییرش داد \d اولش اینجا
                    //که اون رو هم عوض کرد ^\d$ شد 
                    // حالافقط اعداد 0 یا مثبت کامل رو میگیره
            var baresiehSen = new Regex(@"^\d+$");
            if (baresiehSen.IsMatch(vorodi))
            {
                WriteLine(" Damet jiiiiiiz");
            }
            else
            {
                WriteLine(" Ma ro sare kar gozashti?");
            }

            //جدا شده اند comma (,) کار با رشته های پیچیده که با 
            string filmha = "\"Hayaholha, Inc.\",\"Man, Tonaya\",\"Shans , Saham va 2 boshke Tanbako\"";

            string[] filmhaDumb = filmha.Split(',');

            WriteLine("  talash Dumb for jodasazi:");
            foreach (var film in filmhaDumb)
            {
                WriteLine(film);
            }
            // یه عبارت خفن می نویسیم تا اسم فیلم ها رو regular expression اکنون با 
            // جدا کنه
            var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");

            MatchCollection filmBahosh = csv.Matches(filmha);
            WriteLine(" kare hoshmandane dar joda sazi:");

            foreach (Match film in filmBahosh)
            {
                WriteLine(film.Groups[2].Value);
            }
            

        }
    }
}