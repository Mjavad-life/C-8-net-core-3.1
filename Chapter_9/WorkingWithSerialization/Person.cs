using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization; //رو جمع و جورتر کنه XML میخواهد 

namespace Packt.Shared
{
    public class Person
    {
        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }

        public Person() // یک سازنده بدون پارامتر اگه این نباشه موقع اجرا ایراد میگیره
        {}
        [XmlAttribute("fname")] //میاد fnameاینو که میزاره موقع خروجی  
        public string FirstName { get; set;}

        [XmlAttribute("lname")]
        public string LastName  { get; set;}

        [XmlAttribute("dob")]
        public DateTime DateofBirth {get; set;}
        public HashSet<Person> Children {get; set;}
        protected decimal Salary {get ; set;}
        
    }
}