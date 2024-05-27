using System;
using static System.Console;

/// <summary>
///رو به تصویر بکشد index, Ranges اینجا میخواهد کار با 
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = "Sosan Salisilat";
            // مکان جدا شدن اسم رو می یابد
            // استفاده کرده Index اینجا از 
            int indexOfSpace = name.IndexOf(' ');

            string esm_Aval = name.Substring(startIndex: 0 , length:
                            indexOfSpace);

            string esm_Famil = name.Substring
            (
                startIndex : name.Length - (name.Length - indexOfSpace -1),
                length: name.Length - indexOfSpace -1
            );
            // اسم رو دو بخش میکند و آنرا مینویسد
            WriteLine($" Esme Nokhost: {esm_Aval} , esm_Famil : {esm_Famil}");

            //  استفاده میکند  Span حالا از
            ReadOnlySpan<char> nameAsSpan = name.AsSpan();

            var esm_Aval_Span = nameAsSpan[0..indexOfSpace];

            var esm_Famil_Span = nameAsSpan[indexOfSpace..];

            // شده را مینویسد Span اسم 
            WriteLine("esm_Nokhost : {0} , esm_Khanevade : {1}",
                    arg0: esm_Aval_Span.ToString(),
                    arg1: esm_Famil_Span.ToString());

        }
    }
}