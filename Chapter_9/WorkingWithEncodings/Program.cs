using System;
using static System.Console;
using System.Text;

namespace WorkingWithEncodings
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Encodings");
            WriteLine("[1] ASCII");
            WriteLine("[2] UTF-7");
            WriteLine("[3] UTF-8");
            WriteLine("[4] UTF-16 (Unicode)");
            WriteLine("[5] UTF-32");
            WriteLine("[any other key] Default");

            // انتخاب نوع کدگذاری
            Write("yek shomareh bezan ta encoding entekhab beshe:");

            // از کنسول یک کلید رو میگیره
            ConsoleKey number = ReadKey(intercept: false).Key;
            WriteLine();
            WriteLine();

            Encoding encoder = number switch 
            {   
                // بر اساس کلید زده شده نوع کدگذاری مشخص میشه
                ConsoleKey.D1 => Encoding.ASCII,
                ConsoleKey.D2 => Encoding.UTF7,
                ConsoleKey.D3 => Encoding.UTF8,
                ConsoleKey.D4 => Encoding.Unicode,
                ConsoleKey.D5 => Encoding.UTF32,
                _             => Encoding.Default
                
            };

            // یک رشته برای کدشدن تعرف میشود
            string payam = "Agar$ Rozi Beresam Be Dor Gardon.";

            // رشته رو به صورت آرایه ی بایت درمیاره
            byte[] encoded = encoder.GetBytes(payam);

            // بررسی کن چند بایت برای کدگذاری لازمه
            WriteLine("{0} , {1:N0} byte masraf mikoneh.",
                    encoder.GetType() , encoded.Length);

            // میکینه Enumerate  هر بایت رو 
            WriteLine($"BYTE  HEX  CHAR");
            foreach (byte b in encoded)
            {
                WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
            }

            // آرایه بایت ها رو دوباره به رشته برمیگردونه
            string decoded = encoder.GetString(encoded);
            WriteLine(decoded);
        }
    }
}