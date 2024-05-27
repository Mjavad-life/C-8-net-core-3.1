using System.Linq;
using System.Reflection;
using  static System.Console;

namespace Variables{

    public class Program{
        static void Main(string[] args)
        { 
            object height = 1.88; // storing a double in an object
            object name = "sodeh"; // storing string in an object

           // Console.WriteLine($"{name} is {height} metres tall.");

            //int lenght1 = name.lenght;
            int lenght2 = ((string)name).Length;// tell compiler it is a string

            //Console.WriteLine($"{name} has {lenght2} characters.");

            // storing a string in a dynamic object
            dynamic anotherName = "Sara";
            //this compiles but would throw an exception at run-time
            // if you later store a data type that does not have a
            // property named lenght
            int lenght = anotherName.Length;
            //WriteLine(lenght);

            var population = 66_000_000; // 66 milion in uk
            var weight = 1.88; // in kilograms
            var price = 4.99m; // in pounds sterling
            var fruit = "Apple"; // string uses double-qutes
            var letter = 'z'; // chars use single-quotes
            var happy = true; // booleans have value of true or false
        }
    }
}