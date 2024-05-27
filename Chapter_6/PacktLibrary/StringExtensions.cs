using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/// <summary>
/// اینجا میخواد از متد استاتیک استفاده کنه
/// تا بهره برداری دوباره داشته باشه
/// </summary>
namespace Packt.Shared
{   
    // پیش از تعریف کلاس عبارت استاتیک میزاره و
    // this , string قبل از 
    public static class StringExtensions
    {   
         // string type برای instance میشه یکی از متدهای  isValidEmail اینجی متد
         // یعنی هر رشته که تعریف کنیم به این متد دسترسی دارنه
        public static bool IsValidEmail(this string input)
        {
            //استفاده میکنه تا بررسی کنه regular از عبارات 
            // رشته ورودی یک ایمیل معتبر است
            // برمیگردونه true or false در آخر 
            return Regex.IsMatch(input , @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}