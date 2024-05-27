using System;
using static System.Console;

/// <summary>
/// اینجی میخواد با رشته حروف کار کینه
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            string city = "London";
            // رو حساب میکنه London طول کلمه 
            WriteLine($"{city} tole horofesh inghadre : {city.Length}");

            // به حرف اول و سوم کلمه اشاره میکینه
            WriteLine($" aval harf {city[0]} hasta va sevomish {city[2]}.");

            // یک رشته با کلمات متعدد رو جدا میکنه
            string shahrha = "Paris,Zanjan,Zahedan,Koalalampor";

            string[] araye_shahrha = shahrha.Split(',');

            foreach (var shahr in araye_shahrha)
            {
                WriteLine(shahr);
            }

            // یک اسم دو بخشی مینویسه و اونو جدا میکنه و 
            // روش عملیات انجام میده
            string fullname = "Alan Jones";

            // رو پیدا میکنه space ' ' جای 
            int indexOfTheSpace = fullname.IndexOf(' ');

            string firstname = fullname.Substring(
                startIndex: 0, length: indexOfTheSpace
            );

            string lastname = fullname.Substring(
                startIndex: indexOfTheSpace + 1
            );

            WriteLine($"{lastname},{firstname}");

            // بررسی میکنه ایا رشته حرف مورد نظر ما رو داره یا نه
            string sherkat = "Microsoft";
            bool startWithM = sherkat.StartsWith("M");
            bool containsN = sherkat.Contains("N");
            // جواب رو با آره یا نه میده
            WriteLine($" ba M shoro mishe : {startWithM} , yek N darad : {containsN} ");

            // با چند تا از متد های رشته کار میکند
            string recombine = string.Join(" => " , araye_shahrha);
            WriteLine(recombine);

            string miveh = "Golabi";
            decimal gheymat = 0.34m;
            DateTime zaman = DateTime.Today;

            // به دو صورت نمایش میدهد
            WriteLine($"{miveh} mishe {gheymat:C} be tarikh {zaman:dddd}");

            WriteLine(string.Format("{0} mishavad {1:C} on {2:dddd}.", miveh
                        , gheymat , zaman));

            

            
        }
    }
}