using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;
/// <summary>
/// اینجا اتصال به نت میخواد
/// await و async و نشون میده چطور از
/// در تابع اصلی استوفاده در کونیم
/// </summary>
namespace AsyncBazi
{
    public class Program
    {   
        // کرد Type اضافه کرد و نوع بازگشتیش رو async به این تابع
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // اینجا سایت اپل رو صدا میزنه
            HttpResponseMessage response = 
                await client.GetAsync("http://www.apple.com/");

            // نشون میده چند تا بایت دارنه
            WriteLine("Safheye Apple {0:N0} bytes darneh.",
                response.Content.Headers.ContentLength);
        }
    }
}