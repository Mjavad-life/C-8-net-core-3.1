using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies; // برای کار با لودینگ تنبل

namespace Packt.Shared
{
    // اینجا اتصال به پایگاه نداده ها مودورویت میشن
    public class Northwind : DbContext
    {
        // این خواص به جداول پایگاه داده نگاشت در میشن
        public DbSet<Category> Categories { get; set; }            
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(
                System.Environment.CurrentDirectory , "northwind.db");
            
            //optionsBuilder.UseSqlite($"Filename={path}");
            // این کد برای کار با لود تنبل خان هستندی
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // به جای Fluent API نمونه ای از کاربرد 
            // به 15 Category خصوصیات برای محدود کردن اندازه اسم 
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() // تهی نیست
                .HasMaxLength(15);

            // یک فیلتر کلی برای حذف محصولات ادامه ندار
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
}
