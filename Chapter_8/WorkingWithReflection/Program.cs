using System;
using System.Reflection; //وارد شد meta data برای 
using static System.Console;
using System.Linq; // OrderByDescending برای استفاده در

/// <summary>
/// اسمبلی را توضیح دهد meta data اینجا میخواهد خواندن 
/// </summary>
 
namespace WorkingWithReflection
{
    public class Program
    {       
        // ....نوشتم تا ببینیم Coder اینجا چند 
           [Coder("Javad Porsedhgar" , "22 June 2023")]
           [Coder("Jonie monie" , "13 september 2019")]
           public static void DoStuff()
           {

           }
        static void Main(string[] args)
        {
            WriteLine(" meta data Assembly:");
           Assembly? assembly = Assembly.GetEntryAssembly();
           WriteLine($" Full name: {assembly.FullName}"); // WorkingWithReflection جواب اینجا میشه 
           WriteLine($"  Mahal: {assembly.Location}"); // D:\Code\Chapter_8\..... :جواب

           var attributes = assembly.GetCustomAttributes();
           WriteLine($"  Attributes:");
           foreach (Attribute a in attributes)
           {
            WriteLine($"  {a.GetType()}");
           }

           // حالا بیشتر با اسمبلی کار میکنه
           var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

           WriteLine($"  version: {version.InformationalVersion}");

           var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

           WriteLine($"  Company: {company.Company}");
           // را تغییر داد Company و version دو مقدار  csproj به صورت دستی در 

           //  هایی که نوشته استفاده میکنهCoder اینجا از 
           WriteLine();
           WriteLine($"* Types:");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {   //رو اضافه کرد تا if اینجا 
                // رو حذف کنه Compiler GenerAted Attribute

                if (type.FullName == "WorkingWithReflection.Program+<>c")
                {
                    break;
                }
                else{
             WriteLine();
             WriteLine($"Type: {type.FullName}");
             MemberInfo[] members = type.GetMembers();
             foreach (MemberInfo member in members)
             {
                WriteLine("{0}: {1} ({2})",
                arg0: member.MemberType,
                arg1: member.Name,
                arg2: member.DeclaringType.Name);

                var coders = member.GetCustomAttributes<CoderAttribute>()
                .OrderByDescending(c => c.LastModified);

                foreach (CoderAttribute coder in coders)
                {   
                    // میاد jonie monie و javad porseshgar جواب با 
                    // نوشتم Dostuff() که بالای متد 
                    WriteLine("-> Modified by {0} on {1}",
                    coder.Coder , coder.LastModified.ToShortDateString());
                }
             }
             }   
            }
           
        } // Main آخر متد 


    }
}