using System;
using static System.Console;

namespace Exercise03
{
    public static class NumberToWords
    {
    private static   string[] Yekan = {"Sefr" , "Yek" , "Dou" , "Se" , "Chahar" ,
    "Panj" , "Shesh" , "Haft" ,"Hasht" , "Noh" , "Dah" , "Yazdah" , "Davazdah" , "Sizdah",
    "Chahardah" , "Panzdah" , "Shanzdah" , "Hefdah" , "Hejdah" , "Nozdah" };

    private static string[] Dahgan = {"" , "" , "Bist " , "C " , "Chehel " , "Panjah " ,
    "Shast " , "Haftad " , "Hashtad " , "Navad "};

    public static String ConvertAmount(this double amount)
    {
        try
        {
            Int32 amount_int = (Int32)amount;
            Int32 amount_dec = (Int32)Math.Round((amount - (double)(amount_int)) * 100);

            if (amount_dec == 0)
            {
                return(amount_int.ToString()) + "Only.";
            }
            else
            {
                return (amount_int.ToString()) + "Point" + (amount_dec.ToString()) + "Only.";

            }
        }
        catch (Exception e)
        {
            
            // Handle Exception
        }
        return "";
    }

    public static String Convertinj(this int i)
    {
        if (i < 20)
        {
            return Yekan[i];
        }
        if (i < 100)
        {
            return Dahgan[i / 10] + ((i % 10 > 0) ? "" + Convertinj(i % 10) :"");
        }
        if (i < 1000)
        {
            return Dahgan[i / 100] + " Sad " + ((i % 100 > 0) ? " Va " + Convertinj(i % 100) : "");
        }
        if (i < 100000)
        {
            return Convertinj (i / 1000) + " Hezar " + ((i % 1000 > 0) ? "" + Convertinj(i % 1000) : "");
        }
        if (i < 10000000)
        {
            return Convertinj(i / 100000) + " Milion " + ((i % 100000 > 0) ? "" + Convertinj(i % 100000) : "");
        }
        if (i < 1000000000)
        {
            return Convertinj(i / 10000000) + " Miliard " +((i % 10000000 > 0) ? "" + Convertinj(i % 10000000) : "");
        }
        return Convertinj(i / 1000000000) + " Arab " + ((i % 1000000000 > 0) ? "" + Convertinj(i % 1000000000) : "");
    }
    }    
}

