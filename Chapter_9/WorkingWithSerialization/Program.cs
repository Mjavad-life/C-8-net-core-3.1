using System;                       // DateTime
using System.Collections.Generic;   // list<T> , hashset<T>
using System.Xml.Serialization;  // Xml serializer
using System.IO;                    // File Stream
using Packt.Shared;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.Threading.Tasks; // نوین کار کنه Json Api میخواد با 
using NuJson = System.Text.Json.JsonSerializer; // تغییر نام برای پرهیز از اشتباه

/// <summary>
/// رو یاد میده XML در اینجا سریال کردن به 
/// </summary>
namespace WorkingWithSerialization
{
    public class Program
    {
        // میزاره async Task , void اینجا به جای 
        static async Task Main(string[] args)
        {
        //  یک شی گراف میسازد
        // در این کلاس به پراپرتی دستمزد دسترسی ندارنیم و نوموتونیم اینجا مقدار بهش بدیم
        var people = new List<Person>
        {
            new Person(30000m)  {FirstName = "Alo",
            LastName = "Smothi" , DateofBirth = new DateTime(1987, 3 , 12) },

            new Person(40000m)  {FirstName = "Babo" , LastName = "Joje" ,
            DateofBirth = new DateTime(1969 , 11 , 23)},

            new Person(20000m)  {FirstName = "Chone" , LastName = "Coco",
            DateofBirth = new DateTime(1984, 5, 4),
            Children = new HashSet<Person>
            {new Person(0m) {FirstName = "Salad" , LastName = "Coco" ,
            DateofBirth = new DateTime(2000, 7, 12)}}}
        };
        //درمیاره XML شی میسازد که یک لیست از افراد رو به صورت 
        var xs = new XmlSerializer(typeof(List<Person>));

        // یک فایل میسازه که توش بنویسیم
        string path = Combine(CurrentDirectory, "people.xml");

        using (FileStream stream = File.Create(path))
        {
            // شی گراف رو به جریان سریال میکنه
            xs.Serialize(stream,people);
        }
        
        WriteLine("Neveshtan {0:N0} byte az XML be {1}",
            arg0: new FileInfo(path).Length , arg1:path);

        WriteLine();

        // نمایش شی گراف سریال شده
        WriteLine(File.ReadAllText(path));

        // حالا فایل رو از سریال برمیگردونیم به حالت اول
        using (FileStream xmlLoad = File.Open(path , FileMode.Open))
        {
            // دی سریالایز میکنه و شی رو به لیست افراد برمیگردونه
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);

            foreach (var item in loadedPeople)
            {
                WriteLine("{0} , {1} bechey darneh.",
                    item.LastName , item.Children.Count);
            }
        }

        // کار میکنه json اینجی با 
        // فایلی میسازه که توش بنویسه
        string jsonPath = Combine(CurrentDirectory, "people.json");

        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
            // درمیایه json شی میسازد که به شکل

            var jss = new Newtonsoft.Json.JsonSerializer();
            
            // شی گراف رو به یک رشته سریال میکنه
            jss.Serialize(jsonStream, people);
        }

        WriteLine();
        WriteLine("{0:N0} byte az JSON ro be {1} Minegarad",
                arg0: new FileInfo(jsonPath).Length,
                arg1: jsonPath);

        // شی گراف سریال شده را نمایش میدهد
        WriteLine(File.ReadAllText(jsonPath));

        /// <summary>
        /// کار میکنه Json اینجا به شکل حرفه ای تر با
        /// await× با
        /// </summary>
        /// <param name="jsonLoad"></param>
        /// <returns></returns>
        using (FileStream jsonLoad = File.Open(jsonPath , FileMode.Open))
        {
            // شی گراف رو به یک لیست افراد دی سریال میکنه
            var loadedPeople = (List<Person>)
                await NuJson.DeserializeAsync(
                    utf8Json: jsonLoad,
                    returnType: typeof(List<Person>));

            foreach (var item in loadedPeople)
            {
                WriteLine("{0} , {1} farzand darad.",
                    item.LastName , item.Children?.Count);
            }
        }


        }//Main() پایان تابع 
    }
}