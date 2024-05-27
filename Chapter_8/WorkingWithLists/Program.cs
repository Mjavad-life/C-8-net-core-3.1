using System.Collections.Generic;
using System;
using static System.Console;
using System.Collections.Immutable; // در گام بعد میخواهد کاری کند که اعضای
// مجموعه تغییر نکنند

/// <summary>
/// اینجا کار با مجموعه ها مثل لیست و دیکشنری... رو نشون میده
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {   ///
            /// رو نشون میده add , insert , remove کار روی متد های گوناگون مثل 
            var shahrha = new List<string>();
            shahrha.Add("London");
            shahrha.Add("Mashhad");
            shahrha.Add("Masoleh");

            WriteLine(" list Avalieh");
            foreach (string shahr in shahrha)
            {
                WriteLine($"  {shahr}");
            }
            WriteLine($" Avalin shahr hast {shahrha[0]}.");
            WriteLine($" Akharin shahr {shahrha[shahrha.Count -1]} mibashad");

            shahrha.Insert(0 , "Qom");
            WriteLine(" Pas az vared kardane Qom dar makane 0");
            foreach (string shahr in shahrha)
            {
                WriteLine($"   {shahr}");
            }

            shahrha.RemoveAt(1);
            shahrha.Remove("Masoleh");
            WriteLine(" Pas az hazfe do shahr");
            foreach (string shahr in shahrha)
            {
                WriteLine($"   {shahr}");
            }

            var Immutable_Shahrha = shahrha.ToImmutableList();
            // شد list_Novin اضافه نشد ولی به  immutable_shahrha بصره به 
            var list_Novin = Immutable_Shahrha.Add("Basreh");
            Write(" immutable liste shahrha:");
            foreach (string shahr in Immutable_Shahrha)
            {
                Write($"  {shahr}");
            }
            WriteLine();

            Write(" liste jadideh shahrha:");
            foreach (string shahr in list_Novin)
            {
                Write($"  {shahr}");
            }
            WriteLine();
        }
    }
}