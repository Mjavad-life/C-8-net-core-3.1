using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

/// <summary>
/// های تو درتو TASK این پپررووژژهه واسه اینه که 
/// و والد و فرزند رو بهمون نشون وده
/// </summary>
namespace NACTask
{
    public class Program
    {   
        /// <summary>
        /// میسازه تا یک تابع به نام TASK در این تابع یک 
        /// رو اجرا کنه innerMethod
        /// </summary>
        static void OuterMethod()
        {
            WriteLine("Outer shoro mishavad...");
            var inner = Task.Factory.StartNew(InnerMethod,
                // کد زیر رو نوشت تا تابع داخلی هم فرصت شروع و پایان داشته بیشه
                TaskCreationOptions.AttachedToParent);
            WriteLine("Outer tamam shod");
        }


        /// <summary>
        /// تابع زیر کارش این که دو ثانیه بگیره بخوابه
        /// </summary>
        static void InnerMethod()
        {
            WriteLine("Inner aghaz mishavad...");
            Thread.Sleep(2000);
            WriteLine("Inner tashol mod.");
        }

        static void Main(string[] args)
        {   
            // اینجا یه نخ تعرف کرد تا تابع خارجی رو اجرا وکنه
            var outer = Task.Factory.StartNew(OuterMethod);
            outer.Wait();
            WriteLine("Barnameye Console motevaghef shod.");
            // خروجیش میشه تابه خارجی شروع میشه ، تموم میشه
            // برنامه کنسول هم متوقف میشه بعدش تابه داخلی شروع میشه
        }
    }
}