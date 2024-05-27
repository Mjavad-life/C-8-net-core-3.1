using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;


/// <summary>
/// synchronously در این پروژه اجرا کردن چند تابع به ترتیب
/// را نشان میدهد
/// </summary>
namespace WorkWithTask
{
    public class Program
    {   
        /// <summary>
        /// این تابع طراحی شده تا مثلا به یه وب سرور وصل وشه
        /// تا نشون بده چطوری یک تابع منتظر یکی دیگه میمونه
        /// </summary>
        /// <returns></returns>
        static decimal CallWebService()
        {
            WriteLine("Aghaze seda zadane web service...");

            // به صورت تصادفی یک زمان رو متوقف میمونیه
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Payane farakhanie web service.");
            // اینم مثلا خروجیشه
            return 89.99m;
        }

        /// <summary>
        /// این تابع از تابع بالا ورودی میگیره
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> یه عددی داخل یه رشته رو تحویل میده</returns>
        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Shoroe seda vazadane revale zakhire shode....");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Payane seda vazadane ravande zakhire shode");
            return $"12 mahsol bishtar az {amount:C} miarzeh.";
        }

        /// <summary>
        /// این تابع اول است که زمان اجراش سه ثانیه طول وکشه
        /// </summary>
        static void MethodA()
        {
            WriteLine("Aghaze Method A...");
            Thread.Sleep(3000); // سه ثانیه کار را شبیه سازی میکند
            WriteLine("Payane Tabee A.");
        }

        /// <summary>
        /// این یکی تابع دومه که دو ثانیه کار و دارنه
        /// </summary>
        static void MethodB()
        {
            WriteLine("Aghaze tabee B...");
            Thread.Sleep(2000); // دو ثانیه کار را شبیه سازی میکند
            WriteLine("Entehaye tabee B.");
        }

        /// <summary>
        /// این تابع سیمی هم فقط یک ثانیه طول در میکنه
        /// </summary>
        static void MethodC()
        {
            WriteLine("Shoroe Tabee C...");
            Thread.Sleep(1000); // یک ثانیه کار را شبیه سازی میکینیه
            WriteLine("Payane method C.");
        }

        static void Main(string[] args)
        {   
            // زمان سنج زیر برای محاسبه مدت زمان اجرای کدها نوشته وشده
            var timer = Stopwatch.StartNew();

            //WriteLine("Ejraye tavabe be tartib dar yek nakh.");

            // اینجی توابع رو پشت سر هم به ترتیب اجرا در میکنه
           /* MethodA();
            MethodB();
            MethodC();

            */

           /* WriteLine("Ejraye tavabe asynch dar chand nakh");

            // مرتبط در کردیم(tread)هر تابع رو به یک نخ Task اینجا بوسیله کلاس
            // به سه روش متفاوت
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            // اینجا برای اینکه همه ی توابع اجرا بشن اول اونها رو تو یه
            // اوستوفاده وکرد تا همه شون اجرا شن WaitAll آرایه وگذاشته بعدش از
            // البته ترتیب اجراشون اونجوری که تو ارایه هستن نیستش
            Task[] tasks = { taskA, taskB, taskC};
            Task.WaitAll(tasks);
            */
            WriteLine("ٍErsal natije yek Task be shekl vorodi be digari");

            // در کد زیر یک نخ ساخت و خروجی تابع سرویس
            // تحویل داد callstoreprocedure رو به عنوان ورودی به تابع
            var taskCallWebServiceAndThenStoredProcedure =
                Task.Factory.StartNew(CallWebService)
                    .ContinueWith(previousTask =>
                        CallStoredProcedure(previousTask.Result));
            
            // نتیجه رو نشون میده
            WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");
            // زمان سپری شده رو تو خروجی چاپ میکنه
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms separshod");
        }
    }
}