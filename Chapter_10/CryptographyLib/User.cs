using System;


/// <summary>
/// اینجا یک کلاس برای کاربران ساخت که هرکدام
/// با سه ویژگی مشخص میشوند
/// </summary>

namespace Packt.Shared
{
    public class User
    {
        public string Name { get; set;}

        // نمک نیست یه مقدار تصادفیه که به رمز اضافه میشه  SALT
        public string Salt { get; set;}

        // شده HASH بهش اضافه شده هم SALT اینم رمزی هست که هم 
        public string SaltedHashedPassword { get; set;}

        // آرایه ای از نقش ها تعریف کرد که برای اعتبار سنجی
        // و دادن اختیارات ازش استفاده کنه
        public string[] Roles { get; set;}
    }
}