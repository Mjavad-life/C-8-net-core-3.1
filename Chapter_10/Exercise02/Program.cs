
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using static System.Xml.XmlReader;
using static System.Convert;
using System.Security.Principal;
using static System.Console;
using Packt.Shared;
using System.IO; // شامل تایپ هایی برای مدیریت فایل سیستم
using static System.IO.Directory;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;
using static System.Convert;


/// <summary>
/// این برنامه موشکول دارنه دوباره میام سراغش
/// </summary>
namespace RamzBazi
{
    public class Program
    {   
        
        static void Main(string[] args)
        {   
            string masir = Combine(GetCurrentDirectory()) ;
            string xmlfile = Combine(masir,"BobXML.xml");

            string EncryText = Protector.Encrypt(File.ReadAllText(xmlfile) , "Pa$$w0rd");
           // string SHRamz = Protector.SaltAndHashPassword("Pa$$word" , "BANANA7");
           // WriteLine(SHRamz);
            //WriteLine(EncryText);
            WriteLine(File.ReadAllText(xmlfile));

            FileStream xmlFileStream = File.Create(xmlfile);
            RSA rsa = RSA.Create();
            var xmlshode = Protector.ToXmlStringExt(rsa , true);
            WriteLine(xmlshode);
            
        }

/*
        private static string SaltAndHashPassword(
            string password , string salt)
            {
                var sha = SHA256.Create();
                var saltedPassword = password + salt;
                return Convert.ToBase64String(
                    sha.ComputeHash(Encoding.Unicode.GetBytes(
                        saltedPassword)));
            
            }
            */
    }
}