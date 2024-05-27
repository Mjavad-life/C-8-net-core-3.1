using System;                       // DateTime
using System.Collections.Generic;   // list<T> , hashset<T>
using System.Xml.Serialization;  // Xml serializer
using System.IO;                    // File Stream
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.Threading.Tasks; // نوین کار کنه Json Api میخواد با 

/// <summary>
/// get , set اینجا باید روی ارث و سازنده و 
/// بیشتر کار کنم
/// </summary>


namespace SerializationXML
{
    /// <summary>
    /// در این تمرین با دایره و مستظیل مشکل دارم که
    /// قبلا هم داشتم یعنی با ارث بری و کانستراکتورها
    /// با سایر موارد مشکلی نیست
    /// </summary>


    public class Run
    {
        static void Main(string[] args)
        {
            // برای تعریف نمونه از کلاس های دایره و مستطیل
            // اگر از پرانتز استفاده نمیکردم
            // مساحت رو محاسبه نمیکرد
            // یعنی استفاده از آکولاد همراه تعریف مساحت
            // به صورت دستی هسته 
            //var cir = new Circle { Color ="tred" , Radius = 2.6 Area = 12.89};
            
            var cir1 = new Circle  ("Red" , 2.5 );
            var cir2 = new Circle ("Green", 8.0 );
            var cir3 = new Circle ("Purple", 12.3 );
            var rec2 = new Rectangle ("Blue", 45.0, 18.0 );
            var rec1 = new Rectangle ("Blue", 20.0, 10.0 );

            // یک لیست از اشکال مبسازد برای سریال کردن
            var listOfShapes = new List<Shape>
            {   
                cir1 , cir2 , cir3 , rec1 , rec2
            };

            WriteLine(listOfShapes);

           var xs =new XmlSerializer(typeof(List<Shape>));

            string masir = Combine(CurrentDirectory , "Shapes.xml");
            
            using (FileStream xmlstream = File.Create(masir))
            {   
                // اینجا ایراد میگیره
                // رو به دایره تغییر میدم listofshape وقتی نوع 
                // مشکل حل میشه
                // اینجا در ارث بری مشکل وجود داره
                xs.Serialize(xmlstream,listOfShapes);
            }

            WriteLine(File.ReadAllText(masir));
            
            /*
            using (FileStream xmlLoad = File.Open(masir , FileMode.Open))
            {
                List<Shape> loadedShapes =  xs.Deserialize(xmlLoad) as List<Shape>;

                foreach (var item in loadedShapes)
                {
                    WriteLine("{0} in rang ro dare {1} va masahate.",
                            item.GetType().Name , item.Color); // inja Area ro nemigireh
                }
            }*/
            
        }        
    }
}