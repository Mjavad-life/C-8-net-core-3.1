using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// رو نشون بده Generics می خواهد کار با 
/// </summary>
namespace Packt.Shared
{   
    public class Thing
    {
        public object? Data = default(object);

        // بررسی نمیشه object مشکل اینجا اینه که نوع 
        public string Process(object input)
        {
            if (Data == input)
            {
                return "Data and input 1 sun miboshandie.";
            }
            else
            {
                return "Data va input 1 son namibashandi";
            }
        }
    }
}