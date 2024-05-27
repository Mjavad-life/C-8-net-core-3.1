using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Generic در یک کلاس غیر  Generic استفاده از یک متد
/// </summary>
namespace Packt.Shared
{   
    public class Squarer
    {   
        public static double Square<T>(T input)
            where T : IConvertible
            {   
                // convert ba estefade az culture feli
                // تبدیل میکنه double رو به  input
                double d = input.ToDouble(
                    Thread.CurrentThread.CurrentCulture
                );

                return d * d ;
            }   
    }
}