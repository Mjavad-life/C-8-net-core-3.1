using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim

namespace WritingFunctions
{
    public class Program
    {
       // method az noe voide pas chizi bar nemigardone
                            // inja byte bod , int goashtam , javab dad
        static void TimesTable(int number)
        {
            WriteLine($" this is the {number} times table:");
            for (int row = 0; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        } // payane method times table

        static void RunTimesTable()
        {  
            // in method , times table ra call mikonad
            bool isNumber;
            do
            {
                Write(" ye adad beyne 0 ta 255 vared kon:");
                // inja az karbar mikhad ye adade dorost bezane
                // byte neveshte bod man int zadam , hamon javabo dad
                isNumber = int.TryParse(ReadLine() , 
                                out int number);

                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine(" in adad madadaro vas ma dar var nakon.");
                }
            } while (isNumber);
        } // payane methode run times table

        // methodi ke return dare va az noe decimal barmigardone
        static decimal CalculateTax(decimal amount ,
                         string twoLetterRegionCode)
            {   
                decimal rate = 0.0m;
                // bar asase esme keshvar va eyalat rate taeen mikone
                switch (twoLetterRegionCode)
                {
                    case "CH": //swiss
                        rate = 0.08m;
                        break;
                    case "DK": // danmark
                    case "NO": //norwej
                        rate = 0.25m;
                        break;
                    case "GB": // englis
                    case "FR": // france
                        rate = 0.2m;
                        break;
                    case "HU": // hungary
                        rate = 0.27m;
                        break;
                    case "OR": // oregon
                    case "AK": // alaska
                    case "MT": // montana
                        rate = 0.0m; break;
                    case "ND": // north dakota
                    case "WI": // wisconsin
                    case "ME": // maryland
                    case "VA": // virginia
                        rate = 0.05m;
                        break;
                    case "CA": // california
                        rate = 0.0825m;
                        break;
                    default: // bishtare us states
                        rate = 0.06m;
                        break;
                } // payane switch

                return amount * rate ;

            }// payane method calculate tax


        // methode calculate tax ro ejra mikone
        static void RunCalculateTax()
            {
                Write(" ye meghdar vared kon:");
                string amountInText = ReadLine();

                Write(" ye code do harfi az manteghe/keshvar bezan:");
                string region = ReadLine().ToUpper();
                
                // try parse ye meghdar na mafhome .
                // amount in text ro = amount karde bedone exception
                if (decimal.TryParse(amountInText , out decimal amount))
                {
                    decimal taxToPay = CalculateTax(amount , region);
                    WriteLine($" shoma bayad {taxToPay} in sales tax bepardazid.");
                }
                else
                {
                    WriteLine(" meghdare sahih vared nakardi.");
                }
            } // payane methode run calculate tax


        // methodi ke adade kardinal ro ordinal mikone
        /// <summary>
        ///  یه عدد از نوع اینت مینویسی و اون رو به صورت اوردینال در میاره
        /// </summary>
        /// <param name="number"> نامبر عددی مثل 1.2.3.4.و غیره هست</param>
        /// <returns> ordinal number like 1st , 2th , 3rd ,..</returns>
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    string numberAsText = number.ToString();
                    char LastDigit = numberAsText.Last();
                    string suffix = string.Empty;

                    switch (LastDigit)
                    {
                        case '1':
                            suffix = "st";
                            break;
                        case '2':
                            suffix = "nd";
                            break;
                        case '3':
                            suffix = "rd";
                            break;
                        default:
                            suffix = "th";
                            break;
                    } // payane switch dovom

            // age return to switch aval nabashe az default biron nemiad
            // in return male defaulte
            return $"{number}{suffix}";

            } // ende switch aval
        }// payane methode cardinal to ordinal


        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                //int number = ToInt32(ReadLine());
                Write($"{CardinalToOrdinal(number)} ");
                
            }
            WriteLine();
        } // end of run cardinal to ordinal


        // estefade az recursion baraye inke method khodesho
        // call kone
        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number -1);
            }
        } // payane method factorial


        // hala factorial ro ejra mikone
        static void RunFactorial()
        {   
            
            bool isNumber;
            do
            {
                Write(" ye adad bezan binim:");
                // try parse neveshte ke exception nade
                isNumber = int.TryParse(
                    ReadLine() , out int number);

                if (isNumber)
                {
                    WriteLine($"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    WriteLine(" ye adade mashti bezan.");
                }

            } // tahe do
            while(isNumber);
            
        } // akhare  run factorial


        static void Main(string[] args)
        {
                //RunTimesTable();
               // RunCalculateTax();
               RunCardinalToOrdinal();
              // RunFactorial();

        } // payane methode Main
    }
}