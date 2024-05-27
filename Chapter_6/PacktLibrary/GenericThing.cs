using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// رو اضافه میکنه GenericThing اینجا 
/// رو برطرف کنه Thing تا مشکل کلاس
/// </summary>
namespace Packt.Shared
{
    // هست Generic اینجا یک پارامتر از نوع T
    //میزارن T طبق رسوم مزخرف اینا ، اگه فقط یک پارامتر بود اونو 
    public class GenericThing<T> where T : IComparable
    {
        public T? Data = default(T);

        /// <summary>
        /// میگیره Generic یک ورودی از نوع 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>  یک رشته تحویل میده</returns>
        public string Process(T input)
        {       
            if (Data.CompareTo(input) == 0)
            {
                return " Data va input motashabeh hastandi.";
            }
            else
            {
                return "Data and input 1 sun nami bashand.";
            }

        } // process پایان متد 
    }// GenericThing اینجا آخر خطه 
}