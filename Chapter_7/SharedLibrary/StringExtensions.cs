using System.Text.RegularExpressions;
using 

namespace  Packt.Shared
{
    /// <summary>
    /// یک کتابخانه کلاس نوین است
    /// A New ClassLib
    /// </summary>
    public static class StringExtensions
    {
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input ,
                @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }

        public static bool IsValidPassword(this string input)
        {
            // حداقل 8 کاراکتر معتبر
            return Regex.IsMatch(input , "^[a-zA-Z0-9_-]{8,}$");
        }

        public static bool IsValidHex(this string input)
        {
            // سه یا شش عدد هگز درست
            return Regex.IsMatch(input , 
                "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }

}