using System;
using static System.Console;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using static System.Convert;
using Packt.Shared;

namespace Random
{
    public class Program
    {
        static void Main(string[] args)
        {
            Write(" Mikhay kelid cheghadr bozorg bashe (in bytes):");
            string Andazeh = ReadLine();

            byte[] Kelid = Protector.GetRandomKeyOrIV(int.Parse(Andazeh));

            WriteLine($" Kelid be onvane arayeie byte:");
            for (int b = 0; b < Kelid.Length; b++)
            {
                Write($"{Kelid[b] :x2} ");

                // هر 16 جفت دوتایی که نوشت میره خط بعد
                if (((b + 1) % 16) == 0) WriteLine();
            }
            WriteLine();
        }
    }
}