using Packt.Shared; // این نام فضا رو وارد کردم تا از کلاسهای اون استف کنم
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;  // Xml serializer
using System.Linq;
using System;                       // DateTime
using Microsoft.EntityFrameworkCore.Storage; // برای استفاده از اینترفیس ترنزاکشن
using System.Collections.Generic; //  برای حذف کردن موارد از جدول پایگاه داده
using Microsoft.EntityFrameworkCore.Infrastructure; // این سه تای زیر برای
using Microsoft.Extensions.DependencyInjection;     // کار با لاگر وارد شدن
using Microsoft.Extensions.Logging;
using System.Threading.Tasks; // نوین کار کنه Json Api میخواد با 
using NuJson = System.Text.Json.JsonSerializer; // تغییر نام برای پرهیز از اشتباه
using static System.Environment;
using static System.IO.Path;

/// <summary>
/// ها و جداول محصولات و دسته بندی transaction اینجا تمرینی هسته برای کار با 
/// products , categories
/// </summary>

namespace EFcoreexercise
{
    public class Program
    {
        static void QueringCategory()
        {   
            using (var db = new Northwind())
            {   
                // میباشیه transaction خط زیر برای شروع 
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    // استه serialize رو نشون میده که  transaction اینجا نوع 
                    // میمونه دو مدل دیگه از ترنزاکشن که پیاده کنم
                    WriteLine("Transaction isolation Level: {0}",
                            t.GetDbTransaction().IsolationLevel );

                    WriteLine("Categori ha va tedad mahsolati ke darand:");

                    // یک پرس و جو برای دستیابی به همه ی دسته بندی ها و 
                    // محصولات مرتبطشان
                    // کاربرد در کرده LINQ اینجا از 
                    IQueryable<Category> cats = db.Categories.Include(c => c.Products);
                    
                    // وجود نداره categories table اینجا ایراد میگرفت که 
                    // رو تو فایل و دایرکتوری مربوط کپی کردم ردیف شد northwind پایگاه داده
                    foreach (Category item in cats)
                    {   
                        WriteLine($"{item.CategoryName} darne {item.Products.Count} mahsolat.");
                    }
                    // میباشیه transaction این هم مربوط به
                    t.Commit();
                }
            }

            var xs = new XmlSerializer(typeof(cats));

            string path = Combine(CurrentDirectory , "cat-pro.xml");

            using (FileStream stream = File.Create(path))
            {
                xs.serialize(stream , cat-pro);
            }

                    WriteLine("Neveshtan {0:N0} byte az XML be {1}",
            arg0: new FileInfo(path).Length , arg1:path);

            WriteLine();

            // نمایش شی گراف سریال شده
            WriteLine(File.ReadAllText(path));
        }


        static void Main(string[] args)
        {
            QueringCategory();            
        }
    }
}
