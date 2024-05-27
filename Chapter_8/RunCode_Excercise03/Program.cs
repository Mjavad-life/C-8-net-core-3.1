using System;
using static System.Console;
using Exercise03;
using static System.Convert;

namespace RunCode_Excercise03
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
             //ReadKey();
            
             Write(" Yek shomare dige bezan:");
             string Shomareh = ReadLine();
             string Javab = NumberToWords.Convertinj(ToInt32(Shomareh));
             WriteLine(Javab);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}
