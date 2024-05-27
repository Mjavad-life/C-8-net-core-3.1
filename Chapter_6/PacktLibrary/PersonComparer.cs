using System.Collections.Generic;
/// <summary>
/// کلاس زیر را ساخت تا کار با 
/// رو نشون بده Icomparer 
/// </summary>
namespace Packt.Shared
{   
    public class PersonComparer : IComparer<Person>
    {    
        public int Compare(Person? x, Person? y)
        {
           // throw new NotImplementedException();
           // اندازه اسم ها رو قیاس میکنه
           int result = x.Name.Length.CompareTo(y.Name.Length);

           // اگر مساوی بودند
           if (result == 0)
           {
                // سپس با اسم مقایسه میکنه
                return x.Name.CompareTo(y.Name);
           }
           else
           {
                // .. nashod ba result ghias kone
                return result;
           }

        } // Compareto پایان متد 
    } // end of class personcomparer
} // end of namespace