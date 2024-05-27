using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression; // رو فشرده کنیم Xml برای اینکه 

namespace WorkingWithStreams
{
    public class Program
    {
        // یک ارایه از نشانه های تماس خلبان
        // وایپر تعریف میکند
        static string[] callsigns = new string[]
        {
            "Husker" , "Starbuck" , "Apollo" , "Boomer",
            "Bulldog" , "Athena" , "Helo" , "Racetrack"
        };

        /// <summary>
        /// به صورت جریان رشته callsigns این تابع برای کار روی آرایه 
        /// تعریف شده
        /// </summary>
        static void WorkWithText()
        {
            // یک فایل برای نوشتن تعریف میکند
            string textFile = Combine(CurrentDirectory , "streams.txt");

            // برمیگرداند helper writer یک فایل متنی تولید میکند و یک 
            StreamWriter text = File.CreateText(textFile);

            // میکنه و هر کدام را enumerate رشته ها رو 
            // در یک خط جدا مینویسد
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); // منابع رو آزاد میکند

            // محتوای فایل را خارج میکند
            WriteLine("{0} Havie {1:N0} byte hasta mibasha.",
                    arg0: textFile, arg1: new FileInfo(textFile).Length);
            
            WriteLine(File.ReadAllText(textFile));
        
        } // WorkWithText() پایان متد 


        /// <summary>
        /// به صورت callsigns این تابع بر روی ارایه 
        /// کار میکند Xml
        /// </summary>
        static void WorkWithXml()
        {   

            // میخواد کار با آزاد کردن منابع رو یاد بده
            FileStream? xmlFileStream = null;
            XmlWriter? xml = null;

            try
            {
            // یک فایل برای نوشتن درونش تعریف میکند
            string xmlFile = Combine(CurrentDirectory , "streams.xml");

            // یک فایل جریان میسازد
            //FileStream 
            xmlFileStream = File.Create(xmlFile);

            // میپیچه Xml writer helper حالا جریان فایل رو داخل 
            // و به صورت خوذکار المنت های داخلش را ردیف میکنه
            //XmlWriter 
            xml = XmlWriter.Create(xmlFileStream,
                new XmlWriterSettings {Indent = true} );

            // را مینویسد Xml متن ابتدای 
            xml.WriteStartDocument();

            // المنت ریشه را مینویسد
            xml.WriteStartElement("callsigns");

            // رشته ها را توی جریان مینویسد
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign" , item);
            }

            // المنت بستن ریشه را مینویسد
            xml.WriteEndElement();

            // کمکگر و جریان را میبندد
            xml.Close();
            xmlFileStream.Close();

            // محتوای فایل رو خارج میکنه
            WriteLine("{0} daraye {1:N0} byte hasta." , arg0 : xmlFile ,
                arg1 : new FileInfo(xmlFile).Length );

            WriteLine(File.ReadAllText(xmlFile));
            
            } // پایان تلاش

            // از اینجا برای آزاد کردن منابع هست
            catch(Exception ex)
            {
                // اگر مسیر موجود نبود اینجا به کار میفته
                WriteLine($"{ex.GetType()} voigolanzj {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("manabeye modiriat nashodeye Xml Azad shod.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("manabeye modiriat nashodeye jaryane file Azad shod.");
                }
            } // finally پایان 

            /// <summary>
            /// رو برای راحت تر کردن using  اینجا استفاده از
            /// آزاد سازی منابع نشون میده
            /// </summary>
            /// <param name="file2"></param>
            /// <returns></returns>
            // مشکل داره path تو 

            /*using (FileStream file2 = File.OpenWrite(
                Path.Combine(path ,"file2.txt")
            ))
            {   
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Khosh Omad , .NET Core!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} vogoye {ex.Message}");
                    }
                } // خودکار آزاد سازی رو صدا میزنه اگه شی عدم نباشه
            }//  // خودکار آزاد سازی رو صدا میزنه اگه شی عدم نباشه
        */
        } // WorkWithXml() پایان تابع 

        /// <summary>
        /// میباشه XML این مای تابه برای فشرده کردن فایل
        /// از بروتلی هم استف میشه
        /// </summary>
        /// <param name="useBrotli"></param>
        static void WorkWithCompression(bool useBrotli = true)
        {   
            // کد رو تغییر داد تا با بروتلی هم کار کنیم
            string fileExt = useBrotli ? "brotli" : "gzip";
            // رو فشرده میکنه XML خروجی
            // اول یه مسیر تعریف میکنه
            string filePath = Combine(CurrentDirectory , 
            "streams.{fileExt}");

            // تو اون مسیر یه فایل میسازه
           // FileStream gzipFile = File.Create(gzipFilePath);
            FileStream file = File.Create(filePath);

            // حالا یه فشرده کننده میسازه
            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file , CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file , CompressionMode.Compress);
            }
            using (compressor)
            {   
                // میسازه XML اینجا یه فایل 
                using (XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");

                    // حالا فایل رو پر میکنه
                    foreach (string item in callsigns)
                    {
                        xml.WriteElementString("callsign" , item);
                    }
                    // writeendElement نیاز نیست به
                    // آزاد میشود xmlwriter چون زمانی که 
                    // خودش تمام المنت ها با هر طولی را میبندد
                }
            } // جریان را هم میبندد

            // محتوای فایل فشرده را خارج میکند
            WriteLine("{0} daraye {1:N0} byte haste." ,
                    filePath , new FileInfo(filePath).Length);

            WriteLine($"Mohtavaye Feshorde Shode :");
            WriteLine(File.ReadAllText(filePath));

            // خواندن فایل فشرده
            WriteLine("Khandane file Xml Feshordeh:");
            // فایل فشرده رو باز میکینیه
            file = File.Open(filePath , FileMode.Open);

            // حالا یک معکوس فشرده ساز تعریف میکنه
            Stream decompressor;

            if (useBrotli)
            {
                decompressor = new BrotliStream(file , 
                CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file ,
                 CompressionMode.Decompress);
            }
            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read()) //را میخواند XML گره بعدی
                    {
                        // هستیم callsign بررسی میکینه که ما رو گرهی به نام
                        if ((reader.NodeType == XmlNodeType.Element)
                            && (reader.Name == "callsign"))
                        {
                            reader.Read(); // به سمت المنت داخلی بعدی میره
                            WriteLine($"{reader.Value}"); // مقدارش را میخواند
                        }
                    }
                }    
            }
        }  //WorkWithCompression() پایان تابع


        static void Main(string[] args)
        {
           // WorkWithText();
          // WorkWithXml(); // حجم 320 بایت
           WorkWithCompression(); // حجم 150 بایت
           // دوبار تابع بالا رو صدا میزنه
           WorkWithCompression(useBrotli: false); // حالا بروتلی بازی میکینیم
        }
    }
}