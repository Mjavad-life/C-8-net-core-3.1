using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinqWithEFCore
{
    // این بخش ارتباط با پایگاه داده را مودورویت میکینه
    public class Northwind : DbContext
    {
        
            // این خصوصیات به جدول پایگاه داده نگاشت میشود 
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }

           // public DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "northwind.db");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
            
    }
}
