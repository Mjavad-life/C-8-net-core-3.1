using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Exercise03
{
    public class RunCode
    {
       static void Main(string[] args)
       {
            try
            {
             WriteLine( " Yek Shomare bezan Ta be harf Tabdil Beshe.");

             string number = ReadLine();
            // NumberToWords NTW = new NumberToWords();
            // اونو میگیره Type استاتیک هست پس فقط  ConvertToWords متد 
             number = NumberToWords.ConvertAmount(double.Parse(number));
              
             WriteLine(" Shomareh be sorate kalameh hast \n{0}" , number);
             ReadKey(true);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
       } 
    }
}