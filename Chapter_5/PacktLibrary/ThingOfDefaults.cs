using System;
using System.Collections.Generic;

/// <summary>
/// yek kelas digar add kard ta default type ra
/// neshan dahad
/// </summary>
/// 
namespace Packt.Shared
{
    public class ThingOfDefaults
    {
         public int Population;
         public DateTime when;
         public string Name;
         public List<Person> People;

        /// <summary>
        /// barash constro sakhtam va hama ro default dar nazar gereftam
        /// </summary>
         public ThingOfDefaults()
         {  
            // dar marhaleye dovom ebarat bade default ro pak mikonim
            // chon compiler khodesh mifahme
            Population = default;//(int);
            when = default;// (DateTime);
            Name = default;//(string);
            People = default;//(List<Person>);
         }   
    }
}