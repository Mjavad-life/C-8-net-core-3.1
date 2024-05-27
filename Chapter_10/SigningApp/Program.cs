using System;
using static System.Console;
using Packt.Shared;


/// <summary>
/// اینجا از توابع نوشته شده در کلاس
/// استفاده میکنیم و امضا میسازیم ،  protector
/// </summary>
namespace Sign
{
    public class Program
    {
        static void Main(string[] args)
        {   
            // اینجا یه جمله مینویسه به عنوان متن امضا
            Write("Chand jomle benevis vase Emza: ");
            string data = ReadLine();

            // اینجا جمله رو به امضا تبدیل میکنه
            var signature = Protector.GenerateSignature(data);

            // امضا رو نمایش میده
            WriteLine($"Emza: {signature}");

            // کلید عمومی رو چاپ میکنه
            WriteLine("Kelid Omomi barey varesie emzi:");
            WriteLine(Protector.PublicKey);

            // اگر متن و امضا معتبر بود
            // صدا زد protector تابع زیر را از کلاس 
            if (Protector.ValidateSignature(data , signature))
            {
                WriteLine("Sahihi , Emziton Eshgholi hasta.");
            }
            else
            {
                WriteLine("Che Emzaye Zayeiei.....");
            }

            // X شبیه سازی امضای تقلبی با عوض کردن اولین حرف با 
            var fakeSignature = signature.Replace(signature[0] , 'X');

            if (Protector.ValidateSignature(data , fakeSignature))
            {
                WriteLine("Eival be Valet.");
            }
            else
            {
                WriteLine($"Khak to saret: {fakeSignature}");
            }
        }
    }
}