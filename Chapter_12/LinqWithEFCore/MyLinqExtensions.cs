using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
///(Extension) این کلاس برای این طراحی شدیه که توابع اکستنشن
/// بسازیم و از اونها استفاده کینیم LINQ برای 
/// </summary>
namespace LinqWithEFCore // System.Linq تو کتاب اینجا رو نوشته
{
    public static class MyLinqExtensions
    {   
        /// <summary>
        /// IEnumerable<T> از اینترفیس
        /// استفاده میشیه
        /// </summary>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ProcessSequence<T>(
            this IEnumerable<T> sequence)
            {
                return sequence;
            }


        /// <summary>
        /// تمام توابعی که در زیر نوشته شده برای
        ///  محاسبه میانگین به روشهای گونایگون میباشیه
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int? Median(this IEnumerable<int?> sequence)
        {   
            /// <summary>
            /// این تابع عددی که در وسط سری قرار دارنه رو تحویل میده
            /// </summary>
            /// <returns></returns>
            var ordered = sequence.OrderBy(item => item);
            int middlePosition = ordered.Count() / 2;
            return ordered.ElementAt(middlePosition);
        }


        public static int? Median<T>(
            this IEnumerable<T> sequence, Func<T, int?> selector)
            {
                return sequence.Select(selector).Median();
            }


        public static decimal? Median(
            this IEnumerable<decimal?> sequence)
            {   
                /// <summary>
                /// این تابع عددی اعشاری که وسط سری هست رو برمیگردونه
                /// </summary>
                /// <returns></returns>
                var ordered = sequence.OrderBy(item => item);
                int middlePosition = ordered.Count() / 2;
                return ordered.ElementAt(middlePosition);
            }


        public static decimal? Median<T>(
            this IEnumerable<T> sequence, Func<T, decimal?> selector)
            {
                return sequence.Select(selector).Median();
            }


        public static int? Mode(this IEnumerable<int?> sequence)
            {   
                /// <summary>
                /// این تابع بر حسب فراوانی یک عدد مشخص 
                /// اون رو به عنوان میانگین تحویل میده
                /// </summary>
                /// <returns></returns>
                var grouped = sequence.GroupBy(item => item);
                var orderedGroups = grouped
                    .OrderBy(group => group.Count());
                return orderedGroups.FirstOrDefault().Key;
            }


        public static int? Mode<T>(this IEnumerable<T> sequence,
            Func<T, int?> selector)
            {
                return sequence.Select(selector).Mode();
            }


        public static decimal? Mode(this IEnumerable<decimal?> sequence)
        {   
            /// <summary>
            /// این تابع عدد اعشاری که بیشتر از همه
            /// تکرار شده رو به عنوان میانگین در نظر میگیره
            /// </summary>
            /// <returns></returns>
            var grouped = sequence.GroupBy(item => item);
            var orderedGroups = grouped.OrderBy(group => group.Count());
            return orderedGroups.FirstOrDefault().Key;
        }


        public static decimal? Mode<T>(this IEnumerable<T> sequence,
            Func<T, decimal?> selector)
            {
                return sequence.Select(selector).Mode();
            }
    }
}