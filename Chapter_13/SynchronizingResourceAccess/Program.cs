using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

/// <summary>
/// این پروژه بدین دلیل ایجاد وشده که نشون وده 
/// چطور از یک منبع مشترک مثل فایل یا رشته
/// بکارگیری درکنیم
/// </summary>
namespace SyncResoAccess
{
    public class Program
    {   
        // کونچ رو نوشته تا از قفل کردن استفاده کنه
        // تا دو تابع یکی پس از پایان اون یکی از منبع مشترک استوفاده وکنن
        static object conch = new object();
        static Random r = new Random();
        static string Message; // منبع مشترک
        static int Counter; // یک منبع مشترک دیگر


        /// <summary>
        /// رو به رشته مشترک اضاف میکنه A این تابع پنج بار حرف
        /// </summary>
        static void MethodA()
        {   
            // قفل زیر رو گذاشت تا هر تابع منحصرا از منبع مشترک تا
            // آخر کارش استوفاده کنه
            //lock (conch)

            // پیش نیاد از deadlock واس اینکه 
            // و یک زمان مشخص برای اوستوفاده monitor کلاس
            // از منبع مشترک اوستوفاده کرد
            try
            {
            Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(r.Next(2000));
                Message += "A";

                // در زیر عمل افزایش رو اتمی وکنه
                Interlocked.Increment(ref Counter);

                // قبل از اینکه رشته نشون داده بشه پنج بار نقطه میزاره
                Write(".");
            
            }// for پایان حلقه
            
            } // پایان تلاش
            finally
            {
                Monitor.Exit(conch);
            }
        
        } // MethodA پایان تابع


        /// <summary>
        ///  رو به رشته اضافه میکنه B این تابع هم پنج بار حرف
        /// </summary>
        static void MethodB()
        {     
            // همون قفل بالا رو اینجی هم تعریف وکرده
             //lock(conch)
            try 
            {
            Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(r.Next(2000));
                Message += "B";

                // اینجا هم افزایش رو اتمی کرد
                Interlocked.Increment(ref Counter);

                Write(".");
            }
            }
            finally
            {
                Monitor.Exit(conch);
            }

        }

        static void Main(string[] args)
        {
            WriteLine("Lotfan sabr dar va konid ta vazayef kamel vashe");
           
            Stopwatch watch = Stopwatch.StartNew();

            // اینجا دو تا تسک تعریف وکنه یعنی دوتا نخ
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);

            // این زیر هر دو تابع همزمان ولی به ترتیب عشقی اجرا وشن
            Task.WaitAll(new Task[] { a, b});

            WriteLine();
            // اینجا رشته که همون منبع مشترک هست رو مینشون وده
            WriteLine($"Natayej: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} ms toolid.");
            
            // در زیر تعداد دفعاتی که توابع بالا اجرا شدن رو داریم
            // که به صورت اتمی بود
            WriteLine($"{Counter} string modification");
        }
    }
}