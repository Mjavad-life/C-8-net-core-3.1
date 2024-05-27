using System.Security.Cryptography;
using Packt.Shared;
using static System.Console;

/// <summary>
/// در این برنامه با رمزگذاری و شکستن رمز کار میکنیم
/// </summary>
namespace Encrypt
{
    public class Program
    {
        static void Main(string[] args)
        {   
            // اینجا پیامی برای رمزگذاری میگیره
            Write(" Yek Payam Benevis ke Mikhay Ramz Gozary beshe:");
            string payam = ReadLine();

            // هنا رمز رو میخواد
            Write(" Yek Ramz Bezan:");
            string Ramz = ReadLine();

            // اینجا پیامی که به صورت رمز دراومده رو داریم
            string cryptoText = Protector.Encrypt(payam , Ramz);

            // اینجا چاپش میکنیم که یه متن اجق وجق میشه
            WriteLine($" Matn Ramz Gozari shode : {cryptoText}");

            // اینجا میخوایم رمز درست رو بزنه
            Write(" Ramz ra Bezan:");
            string Ramz2 = ReadLine();

            try
            {   
                // هنا متن رمزگذاری شده رو میشکنه
                string clearText = Protector.Decrypt(cryptoText , Ramz2);

                // اینجا چاپش میکنه
                WriteLine($" Matne Ramz shekaste: {clearText}");
            }

            // اگه رمز صحیح نبود
            catch (CryptographicException ex)
            {
                WriteLine("{0}\nMore details: {1}",
                arg0 : " Shoma Ramz Nadorost Zadid" ,
                arg1 : ex.Message);
                
            }
            catch(Exception ex)
            {
                WriteLine(" Exception Gheir Cryptographic : {0} , {1}",
                arg0 : ex.GetType().Name , 
                arg1: ex.Message);
            }

        }
    }
}