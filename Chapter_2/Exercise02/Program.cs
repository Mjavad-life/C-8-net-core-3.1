using System;   
using System.Linq;
using System.Reflection;
using  static System.Console;


namespace Exercise02{

    public class Program{

        static void Main(string[] args)
        { 
            WriteLine(format:"{0:8}       {1:16}                       {2:16} ",
                arg0:" Type" , arg1: "Byte's of memory" ,
                arg2: "Min" );
        
            WriteLine(format:"{0:8}       {1:N0}      {2:N0} ",
                arg0:typeof(float) , arg1:sizeof(float) ,
                arg2: float.MinValue );
    }
}
}