using System.Net;
using System;
using static System.Console;
using System.Net.NetworkInformation; // برای پینگ کردن اینو وارد کردم
/// <summary>
/// رو معرفی میکنه URLs,DNS,IP address اینجا کار با 
/// </summary>
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            Write(" yek adress web dorost benevis: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "https://world.episerver.com/cms/?q=pagetype";
            }

            var uri = new Uri(url);

            WriteLine($"URL: {url}");
            WriteLine($"scheme: {uri.Scheme}");
            WriteLine($"port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            // اینجا لازم علی الاتصال لاینترنت 
            // اهلا بکم
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} adres IP zir ra darad:");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }

            // اینجا میخواد پینگ کردن رو به کار بگیره
            try
            {
                var ping = new Ping();
                WriteLine("Dar hale ping kardan , Lotfan shakiba bashid:");
                PingReply reply = ping.Send(uri.Host);

                WriteLine($"{uri.Host} ping shod va pasokh dad: {reply.Status}");

                if (reply.Status == IPStatus.Success)
                {
                    WriteLine("pasokh az {0} , {1:N0} ms tool keshid." ,
                                reply.Address , reply.RoundtripTime);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().ToString()} migeh {ex.Message}");
            }
        }
    }
}