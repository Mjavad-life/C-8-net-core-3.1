using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

/// <summary>
/// اینجا ارث بری را نشان میدهد
/// ارث میبرد Person از Employee کلاس 
/// </summary>
namespace Packt.Shared
{
    public class Employee : Person
    {
        // اکنون به طور ویژه برای این کلاس عضو تعریف میکنیم
        public string EmployeeCode { get; set;}
        public DateTime HireDate { get; set;}

        // اینجا میگه که متد زیر داره متد همنامش در کلاس
        // میکنه hide رو  Person
        //موشکول حل شد new با گذاشتن 
        public new void WriteToConsole()
        {
            WriteLine(format:
            "{0} dar tarikh {1:dd/MM/yy} donya omad va roze {2:dd/MM/yy} estekh shod" ,
            arg0: Name , arg1: DateOfBirth , arg2: HireDate);           
        }

        // کنه Override رو Tostring میخواد اینجا هم 
        public override string ToString()
        {
            return $"{Name} 's code {EmployeeCode} hast.";
        }

    }
}