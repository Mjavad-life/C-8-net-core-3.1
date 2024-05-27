using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;


/// <summary>
/// رو به Porseman در این تابع برای اینکه شهرها تکراری نباشند اول 
/// تبدیل کردم و بعدش اونو در خروجی نشون دادندمی Sortedlist
/// </summary>
namespace Exercise_2
{
    public class Program
    {   
        static void City()
        {
            
            using (var db = new North())
            {   
                // اینجا هم یه کلک سووار کردم و گفتم اسم هرچی شهره که بیشتر از 1
                // کلمه هست رو رد کن بیاد
                var Porseman = db.Customers.Where
                        (shohor => shohor.City.Length > 1)
                        .OrderBy(cit => cit.CustomerID);

                SortedSet<string> sorto = new SortedSet<string>();

                foreach (var item in Porseman)
                {   
                    sorto.Add(item.City);
                }
                foreach (var item in sorto)
                {
                    Write($"{item}, ");
                } 

                WriteLine();
                
                // London اسم شهرو از کاربر میگیریه مثلا 
                WriteLine(" Esme ye shahro vazeity: ");
                string name = ReadLine();

                // اینجا مشتری هایی که در شهری هستند که 
                // اسمشو زدم رو درمیاره
                var query = db.Customers.Where
                        (customer => customer.City == name );

                // اینجا هم اسم مشتری هایی که اونجا هستن رو نشون میده
                WriteLine($" Tedad {query.Count()} moshtari dar {name} hasta. ");
                foreach (var item in query)
                {   
                    WriteLine(item.CompanyName);
                }
            }
            
        }
        static void Main(string[] args)
        {
            City();
        }
    }
}