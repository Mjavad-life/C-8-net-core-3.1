using System;
using Packt.Shared;
using static System.Console;

namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            // اینجا متذ پروکریت رو استفاده میکنه
            // یعنی استفاده از متدهای اینستنس و 
            // استاتیک
            var harry = new Person{ Name = "Harry"};
            var mary = new Person{ Name = "Mary"};
            var jill = new Person{ Name = "Jill"};

            // call instance method
            // this inja mary hast
            var baby1 = mary.ProcreateWith(harry);

            // cal static method
            // inja person , procreate ro seda mokole
            // baby2 returne methode procreate
            var baby2 = Person.Procreate(harry , jill);

            // اینجا از عملگر * استفاده میکند
            var baby3 = harry * mary; 

            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children."); 

            WriteLine(format: "{0}'s first child is named \"{1}\"." ,
                    arg0: harry.Name , arg1: harry.Children[0].Name);

            WriteLine($"{harry.Children[0].Name} , {harry.Children[1].Name } , {harry.Children[2].Name}");

            // اینجا از متد فاکتوریال که یک متد داخلی داره بهره برداری موکوله
            // faghat Person mitone Factorial ro seda kone chon static e
            WriteLine($"5! is {Person.Factorial(5)}");

            // یکم کار میبره   event  و delegate  این مبحث 
            //قرار میده harry.shout رو صدا میزنه و مساوی  Harry_shout اینجا 
            //داد میزنه harry یعنی 
            //   + تعریف کردیم علامت  event رو از نوع  shout وقتی که 
            // میزاریم
            harry.Shout += Harry_Shout;

            //رو صدا میزنه poke حالا چهار بار 
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            // رو نشون میده interface icomparable کار با 
            // میسازه Person یک آرایه از نوع 
            Person[] people =
            {
                new Person { Name = "Sosan"},
                new Person { Name = "Jonijonom"},
                new Person { Name = "Abasgholi"},
                new Person { Name = "Richi"}
            };

            WriteLine(" liste avalie people :");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            // استفاده میکنه interface Icomparable حالا از 
            WriteLine(" az Icomparable estefade mishavad hala");
            // اولش اینجا ایراد میگیره
            // عبارتی مینویسم Person برای رفع اون جلوی تعریف کلاس
            
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            //بهره میگیره Icompare حالا از 
            WriteLine(" estefade az personComparer's Icomparer implementation baraye moratab kardan.");
            //رو صدا میزنه PersonComparer اینجا زمان مرتب کردن 
            // فرق میکنه Icomparable جوابش با 
            // متفاوت مرتب میکنه
            Array.Sort(people , new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            // رو به کار بگیره Generics اینجا میخواهد 
            // میسازه Thing یک نمونه از کلاس
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($" Thing ba ye integer: {t1.Process(42)}"); // اینجا میگه 
            // یکسان نیستد درحالی که هر دو 42 هستند  input و DAta

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($" Thing ba 1 reshte: {t2.Process("apple")}");


            // رو میگه GenericThing حالا اینجا کار با کلاس
            // رو حل کنه Thing تا دوشواری کلاس 
            var gt1 = new GenericThing<int>();
            gt1.Data = 42 ;
            WriteLine($"GenericThing ba 1 adad: {gt1.Process(42)}"); // اینجا مشکل رو
            // یکسانند input و data و میگوید  Generic حل میکنه بوسیله 

            var gt2 = new GenericThing<string>();
            gt2.Data = "Golabi";
            WriteLine($"GenericThing ba 1 reshte: {gt2.Process("Golabi")}");

            // رو نشون میده Generic کار با یک متد 
            // است Square که در کلاس 

            string number1 = "4";
            
            // یه بار ورودی از نوع رشته است
            WriteLine("{0} be tavan 2 meshe {1}" ,
                    arg0: number1 , 
                    arg1 : Squarer.Square<string>(number1));

            byte number2 = 3;

            // بار دیگر ورودی تابع از نوع بایت هسته
            WriteLine("{0} dar khodesh zarb is {1}:" ,
                    arg0: number2 ,
                    arg1: Squarer.Square(number2));


            // structs کار با 
            var dv1 = new DisplacementVector(3 , 5);
            var dv2 = new DisplacementVector(-2 , 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.x}, {dv1.y}) + ({dv2.x} , {dv2.y}) = ({dv3.x} , {dv3.y}) ");


            // حالا مشئله ارش بری
            // دسترسی داره Person به تمام اعضای کلاس john
            Employee john = new Employee
            {
                Name = "Jone Kocholo",
                DateOfBirth = new DateTime(1990 , 7 , 28)
            };
            john.WriteToConsole(); 

            // میکنیم set چیز میز  john اینجا برای            
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014 , 11 , 23);
            WriteLine($"{john.Name} dar tarikh {john.HireDate:dd/MM/yy} estekh shode");


            // بازی شروع میشود override
            WriteLine(john.ToString()); // Packt.Shared.Emploee جوابش میشه
            // شد جواب شد override پس از اینکه
            // jone kocholo is a Packt.shared.Emploee

            // تعریف کرد رو به کار میگیره Employee که در  overridi متد
            Employee aliceInEmployee = new Employee
            {Name = "Alice" , EmployeeCode = "AA123"};

            // استفاده کرده Implicit casting اینجا از 
            Person aliceInPerson = aliceInEmployee;

            //نشده override جواب دو متد زیر با هم فرق داره چون
            // هست Emploee نه وه فه مه که شی ما از نوع compiler
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();

            // هستن override جواب دوتای زیر یکیه و 
            // هست aliceInEmployee از نوع aliceInPerson کامپایلر میفهمه که 
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            // رو نشون بده Explicit casting حالا میخواد
            // هش موشکولی دیگه نیست (Emploee) اولش ایراد میگیره ولی با اضافه کردن
           // Employee explicitAlice = (Employee)aliceInPerson;

            // رو بگیره exception جلوی  is میخواد بوسیله
            // کنه explicit casting وقتی که میخواد
            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} yek Emploee hast");

                Employee explicitAlice = (Employee)aliceInPerson;
            }

            // هم میشه استفاده کرد as از کلمه ی
            Employee? aliceAsEmployee = aliceInPerson as Employee;

            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Emploee");
                // do something with aliceAsEmployee
            }

            //رو امتحان میکنه TimeTravel متد
            try
            {
             john.TimeTravel(new DateTime(1999 , 12 , 31));
             john.TimeTravel(new DateTime(1950 , 12 , 25));
            }
            //که تعریف کردیم استفاده میکنه  PersonException  اینجا از کلاس
            // هست PersonException از نوع ex
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            // استفاده میکنه و دو ایمیل میسازه StringExtension از کلاس
            string email1 = "pamela@test.com";
            string email2 = "ian$test.com";
            

            WriteLine("{0} yek email sahih hast: {1}",
                arg0:email1 ,
                arg1: StringExtensions.IsValidEmail( email1));

            WriteLine("{0} yek email sahih hast: {1}",
                arg0:email2 ,
                arg1: StringExtensions.IsValidEmail( email2));

            // تعریف کرده stringExtension که در کلاس extension از متد
            // استفاده میکند
            // کد نویسی ساده تر شد نسبت به عبارت بالا
            WriteLine("{0} 1 email dorost ast :{1}", arg0:email1 ,
                    arg1: email1.IsValidEmail());

            WriteLine("{0} 1 email dorost ast :{1}", arg0:email2 ,
                    arg1: email2.IsValidEmail());


        } // پایان متد اصلی 

            // استفاده کنه delegate اینجا میخواد از 
            //میاد  private نوشته که اینجا  Main خارج از متد 
            private static void Harry_Shout(object sender , EventArgs e)
            {
                Person p = (Person) sender;
                WriteLine($"{p.Name} Inghadr asabanie : {p.AngerLevel}");
            }

    } // Program پایان کلاس 
}