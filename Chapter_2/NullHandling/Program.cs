using System.Linq;
using System.Reflection;
using  static System.Console;
#nullable enable

namespace NullHandling{

    class Address
    {
        public string? Building ;
        public string Street = string.Empty ;
        public string City = string.Empty ;
        public string Region = string.Empty ;

    }

    public class Program{

        static void Main(string[] args)
        {
         int thiscannotbeNull = 4;
         //thiscannotbeNull = null; // compile error
         
         int? thiscouldbeNull = null;
         WriteLine(thiscouldbeNull);
         WriteLine(thiscouldbeNull.GetValueOrDefault())   ;

         thiscouldbeNull = 7;
         WriteLine(thiscouldbeNull);
         WriteLine(thiscouldbeNull.GetValueOrDefault());
            
            // az class address yek object sakhtam , be field hash meghdare null dadam
            var address = new Address();
            address.Building = null ;
            address.Street = null ;
            address.City = " Tehran" ;
            address.Region = null ;

            string aName = null ;
            // poshte x va jeloye aname ? gozashtam
            int? x = aName?.Length;
            // khali chap kard
            WriteLine(x);

        } 
    }
}