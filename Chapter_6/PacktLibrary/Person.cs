using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        // fild ha
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // method ha
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}"); 
        }

        // متدهای استاتیک و ایبستنس رو معرفی میکند
        // static method to "multiply"
        // نوع بازگشتی یک فرد است
        public static Person Procreate(Person p1 , Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        // instance method to "multiply"
        public Person ProcreateWith(Person spouse)
        {
            return Procreate(this , spouse);
        }

        //اختصاص میده procreate اینجا عملگر * رو به 
        public static Person operator * (Person p1 , Person p2)
        {
            return Person.Procreate(p1 , p2);
        }

        // اینجا از متدی توی متد دیگه استفاده میکنه
        public static int Factorial (int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                    $"{nameof(number)} cannot be less than 0"
                );
            }
            return localFactorial(number);

            // این متد توی متد فاکتوریال نوشته شده
            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1)
                {
                    return 1;
                }
                return localNumber * localFactorial(localNumber - 1);

            } // پایان متد داخلی
        } // آخر متد فاکتوریال

        // رو نشون بده delegate اینجا میخواد کار با  

        // 1 field event az noe delegate
        // dar game 2 hala event ro ezafe mikone 
        public event EventHandler? Shout;

        // 1 field dade
        public int AngerLevel;

        // method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // اگر چیزی شنیده میشه
                if (Shout != null)
                {
                    // رو صدا موکوله delegete 
                    Shout(this , EventArgs.Empty);
                }
            }
        } // poke پایان متد  
        
        // کردم اومد icomparable implement این متد وقتی که 
        public int CompareTo(Person? other)
        {
           // throw new NotImplementedException();
           // به جای کد بالا زیر رو میزنم
           return Name.CompareTo(other.Name);
        }

        // over ride method to string
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                // استفاده کرد PersonException اینجا از کلاس 
                throw new PersonException (" age be zamane ghabl az tavalodet bargardi zamin monfajer mishe");
            }
            else
            {
                WriteLine($" welcome to {when:yyyy}");
            }
        }
    } // payane kelase Person
}