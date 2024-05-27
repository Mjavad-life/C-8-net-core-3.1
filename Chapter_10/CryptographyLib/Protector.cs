using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using static System.Convert;
using System.Security.Principal;
using System.Collections.Generic;

/// <summary>
/// در این کلاس دو تابع برای رمزگذاری و شکستن ان میسازیم
/// کردن Hash و توابع دیگر برای 
/// همچنین برای امضا و این چیزا
/// </summary>
namespace Packt.Shared
{
    public static class Protector
    {
        // باید دستکم 8 بایت باشد ما 16 بایت به کار میبریم Salt سایز 
        private static readonly byte[] salt = 
            Encoding.Unicode.GetBytes("7BANANAS");

        // باید حذاقل 1000 باشد ما 2000 استفاده میکنیم iteration
        private static readonly int iteration = 2000;

        // کلید عمومی در توابع بعدی بسیار به کار رفته
        public static string PublicKey;


        /// <summary>
        /// اینجا رمز گذاری رو یاد میده
        /// </summary>
        /// <param name="PlainText"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(
            string PlainText , string password)
            {
                byte[] encryptedBytes;

                // متن خام رو به صورت آرایه ی بایت ها درمیاره
                byte[] plainbytes = Encoding.Unicode
                            .GetBytes(PlainText);
                
                // یک الگوریتم رمزگذاری تعریف کرد
                var aes = Aes.Create();
                var pbkdf2 = new Rfc2898DeriveBytes(
                    password , salt , iteration);

                aes.Key = pbkdf2.GetBytes(32); // یک کلید 256 بیت ساخت

                aes.IV = pbkdf2.GetBytes(16); // با 128 بیت Iv ساخت یک 

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(
                        ms , aes.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(plainbytes , 0 , plainbytes.Length);
                    }

                    // آرایه ی بایت های رمزگذاری شده رو پر کرد
                    encryptedBytes = ms.ToArray();
                }

                // چیزی که تحویل میده متن رمزگذاری شده است
                return Convert.ToBase64String(encryptedBytes);
            } // پایان تابع رمزگذاری


        public static string Decrypt(
            string cryptoText , string password)
            {
                byte[] plainBytes;
                byte[] cryptoBytes = Convert.FromBase64String(
                    cryptoText);
                var aes = Aes.Create();
                var pbkdf2 = new Rfc2898DeriveBytes(
                    password , salt , iteration);

                aes.Key = pbkdf2.GetBytes(32);
                aes.IV = pbkdf2.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(
                        ms , aes.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(cryptoBytes , 0 , cryptoBytes.Length);
                        
                    }
                    plainBytes = ms.ToArray();
                    
                }

                return Encoding.Unicode.GetString(plainBytes);
            
            } // Decrypt() پایان تابع

        //اینجا یک دیکشنری میسازد تا کاربران را ذخیره کند
        private static Dictionary<string , User> Users =
            new Dictionary<string, User>();


        /// <summary>
        /// استفاده میکند Salt و Hash یک تابع نوشته تا کاربران را ثبت نام کند و از
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Register( //     اختیاری است  roles پارامتر 
            string username , string password , string[] roles = null)
            {
                // رندوم میسازد Salt یک 
                var rng = RandomNumberGenerator.Create();

                // یک آرایه از نوع بایت میسازد
                var saltBytes = new byte[16];

                // آرایه بالا را پر میکند
                rng.GetBytes(saltBytes);

                // آرایه بالا را به شکل متن در می آورد
                var saltText = Convert.ToBase64String(saltBytes);

                // شده را تولید میکند Salt اینجا رمز هش شده و 
                // را پایین تعریف کرده SaltAndHashPassword() تابع 
                var saltedhashedPassword = SaltAndHashPassword(
                    password , saltText);

                // یک کاربر تازه تعریف میکند
                var user = new User
                {
                    Name = username , Salt = saltText,
                    SaltedHashedPassword = saltedhashedPassword ,
                    Roles = roles // این رو اضافه کرد تا با اعتبار سنجی و این
                    // چیز میزا کارکنه و بگه این کاربر چه نقش هایی داره
                };
                
                //کاربر جدید را به مجموعه کاربران اضافه میکند
                Users.Add(user.Name , user);

                return user;

            }   // Register() آخر تابع 

            /// <summary>
            /// تابع زیر برای این ساخته شده تا با 
            /// Authentication , Authorization
            /// کار کنیم و به هر کاربر اجازه دسترسی خاص بدهیم
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            public static void LogIn(string username , string password)
            {
                    // ابتدا نگا میکنه که نام و رمز درس باشه
                if (CheckPassword(username , password))
                {   
                    // استفاده میکنه Interface اینجا از یک
                    var identity = new GenericIdentity(
                        username , "PacktAuth");

                    // لازم به کار گیری میشودیه interface اینجا از دومین 
                    var principal = new GenericPrincipal(
                        identity , Users[username].Roles);
                    System.Threading.Thread.CurrentPrincipal = principal;
                }
            }


        /// <summary>
        /// بررسی میکند آیا رمز وارد شده صحیح است یا نه
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckPassword(
            string username , string password)
            {
                if (!Users.ContainsKey(username))
                {
                    return false;
                }
                var user = Users[username];

                // شده را باز تولید میکند salt رمز هش و 
                var saltedhashedPassword = SaltAndHashPassword(
                    password , user.Salt);

                return (saltedhashedPassword == user.SaltedHashedPassword);
            
            }   // CheckPassword() انتهای تابع 

        /// <summary>
        /// اینجا از الگوریتم امن قوی از نظر نویسنده کتاب
        /// کردن Hash استفاده میکنیم برای 
        /// این تابع توسط دو تابع تعریف شده در بالا فراخوانده میشود
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static string SaltAndHashPassword(
            string password , string salt)
            {
                var sha = SHA256.Create();
                var saltedPassword = password + salt;
                return Convert.ToBase64String(
                    sha.ComputeHash(Encoding.Unicode.GetBytes(
                        saltedPassword)));
            
            }  // SaltAndHashPassword() پایان تابع  


        // رو یاد بده Signning از اینجا میخواد کار با امضا

        /// <summary>
        /// است (Extension)تابع زیر یک متد الصاقی
        /// رو نمیاره ToXmlString تابع  mac چون در 
        /// اینجا به صورت زیر نوشتش پس تو ویندوز مشکلی نبود
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="includePrivateParameters"></param>
        /// <returns> رو به رشته حروف xml فایل </returns>
        public static string ToXmlStringExt(
            this RSA rsa , bool includePrivateParameters)
        {
           // var rsa = new RSA();
            var p = rsa.ExportParameters(includePrivateParameters);
            XElement xml;
            if (includePrivateParameters)
            {
                xml = new XElement("RSAKeyValue",
                    new XElement("Modules", ToBase64String(p.Modulus)),
                    new XElement("Exponent" , ToBase64String(p.Exponent)),
                    new XElement("P" , ToBase64String(p.P)),
                    new XElement("Q" , ToBase64String(p.Q)),
                    new XElement("DP" , ToBase64String(p.DP)),
                    new XElement("DQ" , ToBase64String(p.DQ)),
                    new XElement("InverseQ" , ToBase64String(p.InverseQ)));
            }
            else
            {
                xml = new XElement("RSAKeyValue",
                    new XElement("Modules" , ToBase64String(p.Modulus)),
                    new XElement("Exponent" , ToBase64String(p.Exponent)));
            }

            return xml?.ToString();
        }

        /// <summary>
        /// نبوده اینجا mac این تابع هم مانند بالایی چون در 
        /// نوشته شده Extension به صورت 
        /// استفاده شده LINQ و در اون از 
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="parametersAsXml"></param>
        public static void FromXmlStringExt(
            this RSA rsa , string parametersAsXml)
        {
            var xml = XDocument.Parse(parametersAsXml);
                var root = xml.Element("RSAKeyValue");
                var p = new RSAParameters
                {
                    Modulus = FromBase64String(
                        root.Element("Modules").Value) ,
                    Exponent = FromBase64String(
                        root.Element("Exponent").Value)
                        
                };

                if (root.Element("P") != null)
                {
                    p.P = FromBase64String(root.Element("P").Value);
                    p.Q = FromBase64String(root.Element("Q").Value);
                    p.DP = FromBase64String(root.Element("DP").Value);
                    p.DQ = FromBase64String(root.Element("DQ").Value);
                    p.InverseQ = FromBase64String(
                        root.Element("InverseQ").Value);
                }
                rsa.ImportParameters(p);
        }

        /// <summary>
        /// در اینجا امضا رو تولید میکنه با متنی که
        /// Hash بهش میدیم و الگوریتم های رمزگذاری و 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>امضا به فرم رشته حروف</returns>
        public static string GenerateSignature(string data)
        {   
            // متنی که از کنسول میگیره رو به بایت بدل میکنه
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);

            // میکنه Hash بایت ها رو 
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            // میسازه RSA کلید عمومی رو برمبنای الگوریتم
            var rsa = RSA.Create();
            PublicKey = rsa.ToXmlStringExt(false); // کلید خصوصی را اخراج کرد

            //امضا رو به شکل رشته حروف برمیگردونه
            return ToBase64String(rsa.SignHash(hashedData ,
                HashAlgorithmName.SHA256 , RSASignaturePadding.Pkcs1));
        }

        /// <summary>
        /// در این تابع امضا را اعتبار سنجی میکند
        /// </summary>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns> درست یا غلط</returns>
        public static bool ValidateSignature(
            string data , string signature)
            {   
                // ابتدا متن امضا را به صورت بایت درمیاره
                byte[] dataBytes = Encoding.Unicode.GetBytes(data);

                // درمیاره Hash متن امضای بایت شده رو به صورت
                var sha = SHA256.Create();
                var hashedData = sha.ComputeHash(dataBytes);

                // امضا رو به بایت تبدیل میکنه
                byte[] signatureBytes = FromBase64String(signature);
                var rsa = RSA.Create();

                // کلید عمومی رو رمز گذاری میکنه
                rsa.FromXmlStringExt(PublicKey);

                return rsa.VerifyHash(hashedData , signatureBytes ,
                    HashAlgorithmName.SHA256 , RSASignaturePadding.Pkcs1);
            
            }  // ValidateSignature() پایان تابع


            public static byte[] GetRandomKeyOrIV(int size)
            {
                var r = RandomNumberGenerator.Create();
                var data = new byte[size];
                r.GetNonZeroBytes(data);

                // اکنون یک آرایه است که با بایت های تصادفی قوی data
                // رمز  گذاری شده پر شده است
                return data;
            }



    }
}