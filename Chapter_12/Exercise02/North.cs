using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2
{
    public class North : DbContext
    {
            // این خصوصیات به جدول پایگاه داده نگاشت میشود 
          //  public DbSet<Category> Categories { get; set; }
            //public DbSet<Product> Products { get; set; }

            public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "northwind.db");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
            
    }
}
