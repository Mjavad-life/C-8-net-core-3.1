using System;
using static System.Console;
using System.Xml.Linq;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;

/// <summary>
/// درآوردیم Nuget package رو به عنوان یک shared library بعد از اینکه
/// اضافه کردم CLI و اون رو رو سایت مربوط قرار دادیم ، حالا اون رو به پروژه با کد 
/// را وارد میکنم namespace و اکنون آن
/// را به صورت Dialectsoftware.collections.matrix پس از آن یک بسته قدیمی به نام 
///کردم restore دستی اضافه کردم و 
/// </summary>
using Packt.Shared;

namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            var doc = new XDocument();

            string s1 = "HELLO";
            string s2 = "hello";

            // استفاده میکینیم shared library در اینجا از متدهای نوشته شده در 
            Write(" Enter a color value in hex:");
            string hex = ReadLine();

            WriteLine("is {0} a valid color value? {1}" , arg0: hex , arg1: hex.IsValidHex());

            Write("Enter yek tage XML:");
            string xmlTag = ReadLine();

            WriteLine(" is {0} yek tage XML sahih? {1}", arg0 : xmlTag , arg1: xmlTag.IsValidXmlTag());

            Write(" yek ramz bazeity:");
            string password = ReadLine();

            WriteLine(" is {0} ye ramz dorost?{1}", arg0:password , arg1:password.IsValidPassword());

            var x = new Axis("x" , 0 , 10 , 1);
            var y = new Axis("y" , 0 , 4 , 1);

            var matrix = new Matrix<long>(new[] { x , y });
            for (int i = 0; i < matrix.Axes[0].Points.Length; i++)
            {
                matrix.Axes[0].Points[i].Label = "x" + i.ToString();
            }

            for (int i = 0; i < matrix.Axes[1].Points.Length; i++)
            {
                matrix.Axes[1].Points[i].Label = "y" + i.ToString();
            }

            foreach (long[] c in matrix)
            {
                matrix[c] = c[0] + c[1];
            }

            foreach (long[] c in matrix)
            {
                WriteLine("{0},{1} ({2},{3}) = {4}", 
                        matrix.Axes[0].Points[c[0]].Label , 
                        matrix.Axes[1].Points[c[1]].Label,
                        c[0] , c[1] , matrix[c]);
            }

            
        }
    }
}
