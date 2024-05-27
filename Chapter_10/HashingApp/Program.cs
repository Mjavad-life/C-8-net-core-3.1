using System;
using static System.Console;
using Packt.Shared;

/// <summary>
/// کردن استفاده میکنیم Hash در این پروژه از
/// </summary>
namespace Hash
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Sabte Alice ba Pa$$w0rd.");

            // یک کاربر به نام آلیش میسازیم با نام و پسورد
            var alice = Protector.Register("Alice","Pa$$w0rd");
            WriteLine($"Name:  {alice.Name}");
            WriteLine($"Salt:  {alice.Salt}");
            WriteLine("Ramz (salted and hashed) :  {0}",
                    arg0: alice.SaltedHashedPassword);
            WriteLine();

            ///اینجا یک کاربر نو میسازه و براش رمز و این چیزا میزاره
            Write("Yek Karbare Tazeh baraye sabte nam bezan:");
            string username = ReadLine();
            Write($"Yek Ramz baraye {username} vared kon.");
            string Ramz = ReadLine();

            // تابع ثبت نام رو صدا میزنه
            var user = Protector.Register(username,Ramz);
            WriteLine($"Name:  {user.Name}");
            WriteLine($"Salt :  {user.Salt}");
            WriteLine("Ramz  (salted and hashed):  {0}",
                arg0: user.SaltedHashedPassword);
            WriteLine();

            /// <summary>
            /// اینجا بررسی میکنیم که رمز عبور و نام کاربری درست باشد
            /// </summary>
            bool correctPassword = false;
            while (!correctPassword)
            {
                Write(" Yek Name Karbari bezan ta vared shi:");
                string loginUsername = ReadLine();
                Write("Yek ramz bezan ta vared shi: ");
                string loginPassword = ReadLine();

                // اینجا تابع بررسی رمز را فراخوانی میکنیم
                correctPassword = Protector.CheckPassword(
                    loginUsername , loginPassword);

                // اگه رمز درست بود
                if (correctPassword)
                {
                 WriteLine($"Sahih!  {loginUsername} vared shod.");
                }
                //....نبود
                else
                {
                    WriteLine("Ramz ya Name karbari nadorost hasta. dooobare vazeity.");
                }
            }
        }
    }
}