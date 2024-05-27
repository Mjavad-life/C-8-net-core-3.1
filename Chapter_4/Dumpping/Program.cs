using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim
using SharpPad;
using System.Threading.Tasks;
// sharppad va thread ro ezafe kardim

namespace Dumpping
{
    public class Program
    {
        // az void be async task tagheer kard
        static async Task Main(string[] args)
        {
            var complexObject = new
            {
                firstname = "petr kabir" ,
                birthday = new DateTime(year: 1972 , month : 12 , day:25),
                friends = new[]{ "amir" , "soraya" , "sali"}
            };
            // code zir ro dar terminal neshon mideh
            WriteLine($" dumping {nameof(complexObject)} to SharpPad.");

            // baraye async , await mizare
            await complexObject.Dump();

        }
    }
}