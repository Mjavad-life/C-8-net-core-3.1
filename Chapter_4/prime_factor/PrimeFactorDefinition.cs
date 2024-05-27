using System;

namespace prime_factor
{
    public PrimeFactorDefinition
    {
        static list<int> factors(int number)
        {
           List<int> javab = new List<int>();
           Write(" ye adad bezan :");
           string? number = ReadLine();
           int adad = int.Parse(number);

           if (adad % 2 == 0 || adad % 3 == 0 || adad % 5 == 0 || adad % 7 == 0)
            {   // agar adad aval nabod mesle 9 , 8 , 52 , ...
                int hasel_Taghsim = 0 ;  
                bool tekrar = true;            
              while (tekrar)
              { 
                if (adad % 2 == 0)
                {
                    hasel_Taghsim = adad / 2;
                    javab.Append(2);
                    adad = hasel_Taghsim ;
                }
                else if (adad % 3 == 0)
                {
                    hasel_Taghsim = adad / 3;
                    javab.Append(3);
                    adad = hasel_Taghsim ;                    
                }
                else if (adad % 5 == 0)
                {
                    hasel_Taghsim = adad / 5;
                    javab.Append(5);
                    adad = hasel_Taghsim ;
                }
                else if( adad % 7 == 0)
                {
                    hasel_Taghsim = adad / 7;
                    javab.Append(7);
                    adad = hasel_Taghsim ;                    
                }
                if (hasel_Taghsim == 1)
                {
                    tekrar = false;
                }

              } // payane while tekrar taghsim

            } // end of if adad aval nabodan

            // agar adad , aval bod mesle 11 , 13 , 17 ...
            else
            {   
                // hamono be javabha ezafe mikone
                javab.Append(adad);             
            }
        }
    }
}
