using System.Globalization; // برای کار با فرهنگ های گوناگون اینو آورد
using System;
using static System.Console;


/// <summary>
/// اینجا میخواهد کار با زبان ها و فرهنگ های مختلف را معرفی کند
/// </summary>
namespace Internationalization
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo Jahan = CultureInfo.CurrentCulture;
            CultureInfo Mantagheh = CultureInfo.CurrentUICulture;

            WriteLine(" Farhange Jahani konini {0} : {1} hast",
                Jahan.Name , Jahan.DisplayName);

            WriteLine(" Farhang Mantagheye Inja {0}: {1} mibasha" ,
                Mantagheh.Name , Mantagheh.DisplayName);

            WriteLine();
            // هر کدوم از این ها رو وارد کنه متناسب با همون
            // فرهنگ و زبان خروجی میده
            WriteLine("en-US: English (United States)");
            WriteLine("da-DK: Danish (Denmark)");
            WriteLine("fr-CA: French (Canada)");
            Write("Bir Dana ISO culture code vazen:");

            string newCulture = ReadLine();
            if (!string.IsNullOrEmpty(newCulture))
            {
                var ci = new CultureInfo(newCulture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            WriteLine();

            Write(" ESme khojeleto bego:");
            string name = ReadLine();
            Write(" Key pa be in jahan gozashti:");
            string tet = ReadLine(); // کوتاه شده ی تاریخ تولد
            Write(" Poli ke dar miary ro cheghadr dost dary:");
            string salary = ReadLine();

            DateTime tarikh = DateTime.Parse(tet);
            int daghayegh = (int)DateTime.Today.Subtract(tarikh).TotalMinutes;
            decimal dastmozd = decimal.Parse(salary);

            WriteLine(
                "{0} dar tarikh {1:dddd} chesh be doonya goshod , {2:N0} deyghe seneshe , {3:C} DArmiareh",
                name , tarikh , daghayegh , dastmozd
            );             
            
        } // Main متد End
    }
}