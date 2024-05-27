using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage; // برای استفاده از اینترفیس ترنزاکشن
using System.Collections.Generic; //  برای حذف کردن موارد از جدول پایگاه داده
using Microsoft.EntityFrameworkCore.Infrastructure; // این سه تای زیر برای
using Microsoft.Extensions.DependencyInjection;     // کار با لاگر وارد شدن
using Microsoft.Extensions.Logging;
using System;

/// <summary>
/// northwind اینجا از پایگاه داده
/// کارایی در میکینیم و اوطولاعات ازش استخراج میکینیمیدون
/// </summary>
namespace  EFCore
{
    public class Program
    {

        static void QueryingCategories()
        {   
            using (var db = new Northwind())
            {   
                // دوخط زیر برای گرفتن لاگر فکتوری و ثبت کنسول لاگر دلخواه هست
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categori ha va tedad mahsolati ke darand:");

                // یک پرس و جو برای دستیابی به همه ی دسته بندی ها و 
                // محصولات مرتبطشان
                // کاربرد در کرده LINQ اینجا از 
                IQueryable<Category> cats; //= db.Categories; // اینو کنار زد تا کاربر نوع لودینگ رو انتخاب کنه
                    //.Include(c => c.Products); این قسمت رو کنار زد برا ایگر لودینگ

                db.ChangeTracker.LazyLoadingEnabled = false;

                // میگه موخوای ایگر لودینگ در وشه؟
                Write("rah andazie Eager loading? (are/na): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();

                // اگه ایگر لودینگ
                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    // Explicit Loading نه پس 
                    cats = db.Categories;
                    Write("explicit loading aya vakilam? (bale/fekr nakonam): ");
                    explicitloading = (ReadKey().Key == ConsoleKey.Y);
                    WriteLine();
                }
                foreach (Category c in cats)
                {   
                    if (explicitloading)
                    {
                        Write($"Explicitly mahsolat ro baraye {c.CategoryName} bar vagireh? (are/nehi nehi):");
                        //ConsoleKeyInfo key1 = ReadKey(false).Key;
                        // این کلید ها دوشواری داره قبلا هم بهش برخورده بودم
                        ConsoleKeyInfo key = 
                            new ConsoleKeyInfo('Y', ConsoleKey.Y, false, false, false);
                        WriteLine();
                        // اگر کاربر بله داد
                        if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded) products.Load();
                            
                        }
                    }
                    WriteLine($"{c.CategoryName} darne {c.Products.Count} mahsolat.");
                }
            }
        }
        
        /// <summary>
        /// در ابن تابع با جدول محصولات کار میکینیم
        /// و اطلاعاتی رو ازش در میکونیم
        /// </summary>
        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {   
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Mahsolati ke az yek gheimat balatarand , dar sadr.");
                string? input;
                // بود decimal تو کتاب 
                // ولی با نیگاهی به جدول موروده اوستوفاده
                // price پشت نوشتم int
                int price;
                do
                {
                Write("Enter a product price: ");
                input = ReadLine();
                //  گذاشتم int اینجا هم به همون علت بالا
                // TryParse پشت 
                } while(!int.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                    // از تابع تگ استف میکنه تا متنی به لاگ اضافه کنه در واقع یه توضیحه
                    .TagWith("mahsolati ke ba baha palayesh shode va sort shodandi.")
                    // پشتیبانی نمیکنه decimal از sqlite اینجا ایراد میگرفت که 
                    // int واسه همین هم در پایگاه داده هم در کلاس محصول نوعش رو به
                    // تغییر دادم و ایراد برطرف شد
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);

                foreach (Product item in prods)
                {
                    WriteLine("{0} : {1} {2:$#,##0.00} miarze va {3} ta dar anbar darad.",item.ProductID, item.ProductName , item.Cost , item.Stock);
                }
            }
        }

        /// <summary>
        /// در تابع زیر از کار با الگوها استف میکینه
        /// و مثلا یه قسمت از اسمو میگیره و اونو پیدا میکنه
        /// </summary>
        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write(" ye bakhsh az esme yek masholo varedat kon:");
                string input = ReadLine();

                // خط زیر تمام محصولاتی که با اسم وارد شده میخونه رو در میارنه
                IQueryable<Product> prods = db.Products
                    .Where(p => EF.Functions.Like(p.ProductName , $"%{input}%"));

                // اینجا اون محصولات و چیز میزاشو نشون میده
                foreach (Product item in prods)
                {
                    WriteLine("{0} , {1} mored dar anbar darneh.Discontinued? {2}",
                        item.ProductName , item.Stock , item.Discontinued);
                }
            }
        }

        // این تابع سطر به جدول اضاف میکینه
        static bool AddProduct(int categoryID, string productName,
            // decimal price تو کتاب نوشته 
            int price)
            {
                using (var db = new Northwind())
                {   
                    //یه محصول تازه تعریف میکنه
                    var newProduct = new Product
                    {
                        CategoryID = categoryID,
                        ProductName = productName,
                        Cost = price
                    };

                    // اونو به جدول محصولات می اضافونه
                    db.Products.Add(newProduct);

                    // تغییرات رو ذخیره میکنه
                    int affected = db.SaveChanges();
                    return (affected == 1);
                }
            }

        // این تابع مشخصات محصولات رو دسته بندی شده نشان میده
        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
                    "ID", "Product Name", "Cost", "Stock", "Disc.");

                // بر اساس گرانترین دسته بندی میشندی
                foreach (var item in db.Products.OrderByDescending(
                    p => p.Cost))
                {   
                    //اینجی هم چاپ میشن
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        item.ProductID, item.ProductName, item.Cost,
                        item.Stock, item.Discontinued);  
                }
            }
        }

        /// <summary>
        /// این تابع برای تغییر دادن موجودی یک سطر در جدول است
        /// قیمت یک محصول رو بر مبنای اسمش عوض کرد
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        static bool IncreaseProductPrice(string name , int amount)
            {
                using (var db = new Northwind())
                {   
                    // آغاز در میشه رو میگیره name اولین محصولی که اسمش با 
                    Product updateProduct = db.Products.First(
                        p => p.ProductName.StartsWith(name));

                    // قیمت محصول را می افزایندوندی
                    updateProduct.Cost += amount;

                    // تغییرات رو دخیره میکینه
                    int affected = db.SaveChanges();
                    return (affected == 1);
                }
            }

            /// <summary>
            /// در تابع زیر محصولات رو از جدول پاک میکونیم
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            static int DeleteProducts(string name)
            {
                using (var db = new Northwind())
                {   
                    // استفی کرده transaction اینجا از 
                    using (IDbContextTransaction t = db.Database.
                        BeginTransaction())
                    {   
                        // استه serialize رو نشون میده که  transaction اینجا نوع 
                        WriteLine("Transaction isolation Level: {0}",
                            t.GetDbTransaction().IsolationLevel);
                    
                    IEnumerable<Product> products = db.Products.Where(
                        p => p.ProductName.StartsWith(name));
                    
                    db.Products.RemoveRange(products);

                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                    }
                }
            }




        static void Main(string[] args)
        {
            //QueryingCategories();
            //QueryingProducts();
            //QueryingWithLike();

            for(int i=0 ; i<3 ; i++)
            {
            if (AddProduct(i+6, "bob's Burgers", 500))
            {
                WriteLine("Masholat be halate damet garm ezafe shod.");
            }
            }
            // بود که با تغییر درست شد bob نوشته بود ولی تو پایگاه داده Bob اینجا 
           /* if (IncreaseProductPrice("bob", 20))
            {
                WriteLine("Tagheer gheymat eival bood");
            }*/

            //for (int i = 0; i < 3; i++)
            //{
                int deleted = DeleteProducts("bob");
                WriteLine($" mahsole {deleted} retete...");
           // }
            ListProducts();
        }
    }
}