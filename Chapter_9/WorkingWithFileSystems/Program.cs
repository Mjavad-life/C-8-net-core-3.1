//using System;
using System.IO; // شامل تایپ هایی برای مدیریت فایل سیستم
using static System.Console;
using static System.IO.Directory;
using static System.Environment;
using static System.IO.Path;

/// <summary>
/// قراره اینجا کار با مسیرها رو یاد بده
/// چون تو سیستم عامل ها مختلف فرق داره
/// اول واسه ویندوز رو میگه
/// </summary>
namespace WorkingWithFileSystems
{
    public class Program
    {   
        /// <summary>
        /// این تابع برای خروجی گرفتن از فایل ها و مسیرهای مشخص شده در
        /// کد ها هست
        /// </summary>
        static void OutputFileSystemInfo()
        {   
            //  "" که داخل Path.PathSeparator اون 
            // هست یک جمله هست همچنین تمامی عباراتی که در "" هستند

            WriteLine("{0,-33} {1}" , "Path.PathSeparator" , PathSeparator); 
            WriteLine("{0,-33} {1}" , "Path.DirectorySeparatorChar" , DirectorySeparatorChar);
            WriteLine("{0,-33} {1}" , "Directory.GetCurrentDirectory" , GetCurrentDirectory());
            WriteLine("{0,-33} {1}" , "Environment.CurrentDirectory" , CurrentDirectory);
            WriteLine("{0,-33} {1}" , "Environment.SystemDirectory" , SystemDirectory);
            WriteLine("{0,-33} {1}" , "Path.GetTempPath()" , GetTempPath()); 

            WriteLine("GetFolderPath(SpecialFolder)");
            WriteLine("{0,-33} {1}" , "(SpecialFolder.System)" , GetFolderPath(SpecialFolder.System)); 
            WriteLine("{0,-33} {1}" , "(SpecialFolder.ApplicationData)" , GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}" , "(SpecialFolder.MyDocuments)" , GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}" , "(SpecialFolder.Personal)" , GetFolderPath(SpecialFolder.Personal));
        
        } // OutputFileSystemInfo() پایان تابع 

        /// <summary>
        /// این تابع برای کار با درایور ها ساخته شده
        /// </summary>
        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
                "NAME" , "TYPE" , "FORMAT" , "SIZE (BYTES)" , "FREE SPACE");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                        drive.Name , drive.DriveType , drive.DriveFormat,
                        drive.TotalSize , drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        } // WorkWithDrives() انتهای تابع

        /// <summary>
        /// یک مسیر دایرکتوری برای پوشه جدید میسازد که از پوشه کاربر 
        /// آغاز میشود
        /// </summary>
        static void WorkingWithDirectories()
        {
            // میشه D:\Users\javad\Document\Code\Chapter_9\NewFolder مسیر پوشه زیر 
         var newFolder = Combine(GetFolderPath(SpecialFolder.Personal) ,
                        "Code", "Chapter_9" , "NewFolder");

         WriteLine($"Kar Ba : {newFolder}");

         // بررسی وجود یا عدم
         WriteLine($"Aya Vijod Darad?  {Exists(newFolder)}");

         // دایرکتوری را میسازد
         WriteLine(" Dare Misazadesh....");
         CreateDirectory(newFolder);
         WriteLine($"Aya Vijod Darad?  {Exists(newFolder)}");

         Write(" Taeed Kon Directory Hast , Sepas ENTER ro Bezan:");
         ReadLine();

         // پاک کردن دایرکتوری
         WriteLine(" Dare Pak mikone....");
         Delete(newFolder , recursive: true);
         WriteLine($"Aya Hast?  {Exists(newFolder)}");
        
        } // WorkingWithDirectories() پایان تابع

        /// <summary>
        /// یک فایل از نوع متن و یک فایل پشتیبان ساخت
        /// و داخل آنها چرت و پرت نوشتم
        /// </summary>
        static void WorkWithFiles()
        {
            // یک مسیر دایرکتوری تعریف میکند تا فایل ها را دستکاری کند
            // که از پوشه کاربر آغاز میشود

            var dir = Combine(GetFolderPath(SpecialFolder.Personal),
                        "Code" , "Chapter_9" , "OutputFiles");

            CreateDirectory(dir);

            // تعریف مسیرهای فایل
             string textFile = Combine(dir , "Dummy.txt");
             string backupFile = Combine(dir , "Dummy.bak");

             WriteLine($"Var Raftan Ba: {textFile}");

             // بررسی وجود یک فایل
             WriteLine($"Aya Mojodah? {File.Exists(textFile)}");

             // ساخت یک فایل متنی و نوشتن یک خط در آن
             StreamWriter textWriter = File.CreateText(textFile);
             textWriter.WriteLine(" To Mahshari , Az Hame Sari , Dostie Sadeye Ma...");
             textWriter.Close(); // فایل رو میبنده و منابع رو آزاد میکنه

             WriteLine($"Aya Mojodi?  {File.Exists(textFile)}");

             // فایل رو کپی میکنه و اگر الان هست دوباره نویسی میکنه
             File.Copy(sourceFileName: textFile , destFileName: backupFile ,
                        overwrite: true);

            WriteLine($"Aya {backupFile} Hasta?  {File.Exists(backupFile)}");

            Write("Sehate Vojod file ro Taeed kon Sepas ENter ro bezan:");
            ReadLine();

            // پاکسازی
            File.Delete(textFile);

            WriteLine($"Aya hasta mibasha?  {File.Exists(textFile)}");

            // خوانش از فایل متنی پشتیبان
            WriteLine($"Khandane mohtavaye {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close() ;

            

            // مدیریت مسیرها ، مثلا جدا کزذن پسوند فایل
            //... مثلکا یعنی
            WriteLine($"Esme Folder: {GetDirectoryName(textFile)}") ;
            WriteLine($"Esme File : {GetFileName(textFile)}");
            WriteLine("Esme File Bedon Pasvand : {0}" ,
                        GetFileNameWithoutExtension(textFile));

            WriteLine($"Pasvande File : {GetExtension(textFile)}");
            WriteLine($"Esme Random File : {GetRandomFileName()}");
            WriteLine($"Esme file Movaghat : {GetTempFileName()}");

            // حالا میخواد بیشتر با فایل ور بره واسه همین
            // رو میکشه وسط FileInfo
            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"Daraye {info.Length} byte mihasta");
            WriteLine($"Akharin Dastresi : {info.LastAccessTime}");
            WriteLine($"readonly shode be {info.IsReadOnly}");

        
        } //WorkWithFiles() پایان تابع
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
           // WorkWithDrives();
           //WorkingWithDirectories();
           WorkWithFiles();
        }
    }
}