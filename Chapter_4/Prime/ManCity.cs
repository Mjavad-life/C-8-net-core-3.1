using System;
using static System.Console;
using System.IO;
using static System.Convert;

namespace PrimaryLeague  
{
    public class ManCity
    {   // yek adad migire va ajzaye onro (prime_factors)
        // ro neshon mideh
        public bool tekrar = true;                    

        /// <summary>
        ///   حساب میکند عدد ورودی حاصلضرب کدام اعداد زیر 10 است
        /// 50 = 5 * 5 * 2 مثلا
        /// </summary>
        /// <param name="adad"></param>
        /// <returns> یک آرایه که مجموعه مضرب ها در آن است</returns>
        public List<string> Prime_Factors(int adad)
        {   
            List<string> javabha = new List<string>();

            if (adad % 2 == 0 || adad % 3 == 0 || adad % 5 == 0 || adad % 7 == 0)
            {   // agar adad aval nabod mesle 9 , 8 , 52 , ...
              int hasel_Taghsim = 0 ;              
              while (tekrar)
              { 
                if (adad % 2 == 0)
                {
                    hasel_Taghsim = adad / 2;
                    javabha.Append("2");
                    adad = hasel_Taghsim ;
                }
                else if (adad % 3 == 0)
                {
                    hasel_Taghsim = adad / 3;
                    javabha.Append("3");
                    adad = hasel_Taghsim ;                    
                }
                else if (adad % 5 == 0)
                {
                    hasel_Taghsim = adad / 5;
                    javabha.Append("5");
                    adad = hasel_Taghsim ;
                }
                else if( adad % 7 == 0)
                {
                    hasel_Taghsim = adad / 7;
                    javabha.Append("7");
                    adad = hasel_Taghsim ;                    
                }
                if (hasel_Taghsim == 1)
                {
                    tekrar = false;
                }

              }// payane while tekrar taghsim

            } // end of if adad aval nabodan

            // agar adad , aval bod mesle 11 , 13 , 17 ...
            else
            {   
                // hamono be javabha ezafe mikone
                javabha.Append(adad.ToString());             
            }

            // dar akhar javabha ro bar migar doneh
            return javabha;

        } // tahe  method prime_factors
 
    } // end of class man_city

}// end of namespace Primaryleague