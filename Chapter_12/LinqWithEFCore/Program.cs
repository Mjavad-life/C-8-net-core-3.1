using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Xml.Linq; // کنه XML برای این آوردمش که میخواد جدول محصولات رو 


/// <summary>
/// را آموزش دهد EFCore در این پروزه میخواهد کار با لینک در 
/// قبلا در فصل 11 مقدمه ای در مورد آن گفته بود حالا کامل ترش میکنه
/// </summary>
/// 
namespace LinqWithEFCore
{
    public class Program
    {   
        /// <summary>
        /// در این تابع محصولات موجود در پایگاه داده را دسته بندی و حذف میکند
        /// </summary>
        static void FilterAndSort()
        {   
            
            using (var db = new Northwind())
            {   
                // اینجا محصولاتی که بهاشان از 10 دلار کمتر است را
                // بر اساس قیمت آنها دسته بندی نزولی میکند
                // کد زیر معادل انتخاب همه ی ستون های جدول محصولات است
                var query = db.Products
            .ProcessSequence() // هست که نوشتم Extention این یکی از توابع 
                    .Where(product => product.UnitPrice < 10)
                    //IQueryable<Product>
                    .OrderByDescending(product => product.UnitPrice)
                    // IOrderedQueryable<Product>
                    // در کد زیر از انتخاب استفاده میکند و نوع را مشخص نمیکند
                    // و تنها از سه خصوصیت استفاده میکند
                    .Select(product => new // نوع نامعلوم
                        {product.ProductID,
                        product.ProductName,
                        product.UnitPrice});

                // با کد زیر آن محصولات را در خروجی نشون میده
                WriteLine("Malsohati ke kamtar az 10 dolar miarze:");
                foreach (var item in query)
                {
                    WriteLine("{0}: {1} bahayash {2:$#,##0.00} haste miboshe",
                        item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }
        }

        /// <summary>
        /// تابع زیر برای پیوستن محصولات و دسته بندی ها به هم
        /// تعریف شده است
        /// </summary>

        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // همه محصولات را به دسته بندیشان پیوند میدهد
                // تا 77 جفت برگرداند
                // استفاده میکند join از تابع 
                var queryJoin = db.Categories.Join(
                    // این تابع 4 پارامتر دارنه
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c , p) =>
                        new {c.CategoryName , p.ProductName ,
                             p.ProductID})
                        .OrderBy(cp => cp.ProductID);
                
                // اینجا حاصل الحاق شدن در بالا را می نمایانیه
                // تمام محصولات و اینکه هر کدام در چه دسته بندی هستند
                foreach (var item in queryJoin)
                {
                    WriteLine("{0}: {1} dar ({2}) mibashieh.",
                        arg0: item.ProductID,
                        arg1: item.ProductName,
                        arg2: item.CategoryName);
                }
            }
        }

        /// <summary>
        /// تابع زیر برای این هسته که هر محصول و دسته بندیش رو گروه گروه
        /// کنه و به هم متصل کینه
        /// </summary>
        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // همه محصولات را با دسته بندیشان جمع میکند
                // تا 8 جفت تحویل دهد
                // رو ننویسیم دوشواری میشه AsEnumerable اگر اینجی
                var queryGroup = db.Categories.AsEnumerable()
                    .GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) => new {
                        c.CategoryName,
                        Products = matchingProducts.
                        OrderBy(p => p.ProductName)
                    });

                // کد زیر مینویسه هر دسته چند محصول داره
                // و خط به خط محصولاتش رو نمایش میده
                foreach (var item in queryGroup)
                {
                    WriteLine("{0} darneh {1} mahsolat.",
                        arg0: item.CategoryName,
                        arg1: item.Products.Count());

                    foreach (var product in item.Products)
                    {
                        WriteLine($"   {product.ProductName}");
                    }
                }
            }
        }

        /// <summary>
        /// (aggregation) در این تابع میخواهد برای جمع آوری
        /// استفاده در کنه Average و sum از دو تابع 
        /// </summary>
        static void AggregateProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-25}  {1,10}",
                    arg0: "Product count:",
                    arg1: db.Products.Count());

                WriteLine("{0,-25}  {1,10:$#,##0.00}",
                    arg0: "Highest product price:",
                    arg1: db.Products.Max(p => p.UnitPrice));

                WriteLine("{0,-25}  {1,10:N0}",
                    arg0: "Jame vahedha dar anbar:",
                    arg1: db.Products.Sum(p => p.UnitsInStock));

                WriteLine("{0,-25}  {1,10:N0}",
                    arg0: "Jame vahedha be tartib:",
                    arg1: db.Products.Sum(p => p.UnitsOnOrder));

                WriteLine("{0,-25}  {1,10:$#,##0.00}",
                    arg0: "Miangine bahaye vahed:",
                    arg1: db.Products.Average(p => p.UnitPrice));

                WriteLine("{0,-25}  {1,10:$#,##0.00}",
                    arg0: "Arzesh vahedha dar anbar:",
                    arg1: db.Products.AsEnumerable()
                        .Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }

        /// <summary>
        /// Extention این تابع به منظور خروجی گرفتن از توابع
        /// نوشته شدیه طراحی شده میباشیه MyLinqExtention که در کلاس
        /// </summary>
        static void CustomExtensionMethods()
        {
            using (var db = new Northwind())
            {
                WriteLine("Vahed haie Mean dar anbar: {0:N0}",
                    db.Products.Average(p => p.UnitsInStock));

                WriteLine("Bahaye vahed Mean: {0:$#,##0.00}",
                    db.Products.Average(p => p.UnitPrice));

                WriteLine("Vahedhaye Median dar anbar: {0:N0}",
                    db.Products.Median(p => p.UnitsInStock));

                WriteLine("Bahaye vahede Median: {0:$#,##0.00}",
                    db.Products.Median(p => p.UnitPrice));

                WriteLine("Vahede Mode dar anbar: {0:N0}",
                    db.Products.Mode(p => p.UnitsInStock));

                WriteLine("Bahaye vahede Mode: {0:$#,##0.00}",
                    db.Products.Mode(p => p.UnitPrice));
            }
        }

        /// <summary>
        /// کار این تابع تبدیل جدول محصولات به شکل
        /// است XML
        /// </summary>

        static void OutputProductsAsXml()
        {
            using (var db = new  Northwind())
            {   
                // جدول محصولات رو به آرایه تبدیل کرد
                var productsForXml = db.Products.ToArray();

                // هست وبالای همه میاد products اولین المنت
                var xml = new XElement("products",
                    from p in productsForXml
                    // خصیصه های زیر به ازای هر محصول تکرار میشن
                    select new XElement("product",
                        new XAttribute("id", p.ProductID),
                        new XAttribute("price", p.UnitPrice),
                        // نام خودش یک المنت هست
                        new XElement("name", p.ProductName)));

                WriteLine(xml.ToString());
            }
        }


        static void ProcessSettings()
        {
            XDocument doc = XDocument.Load("settings.xml");

            var appSettings = doc.Descendants("appSettings")
                .Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value
                }).ToArray();

            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key}:  {item.Value}");
            }
        }

        static void Main(string[] args)
        {   
            
            //FilterAndSort();
            //JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //AggregateProducts();
            //CustomExtensionMethods();
            //OutputProductsAsXml();
            ProcessSettings();
        }
    }
}