using static System.Console;
using Packt.Shared;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;

/// <summary>
/// این برنامه ساخته شده تا با دو موضوع اعتبار سنجی
/// نوشتیم کار کنیم protector و اختیار دادن که در کلاس
/// </summary>
namespace Secure
{
    public class Program
    {
        static void Main(string[] args)
        {   

            // سه کاربر اضافه میکنه و بهشون نقش میده
            Protector.Register("Alice" , "Pa$$w0rd" ,
                new[] { "Admins" });
            Protector.Register("Bob", "Pa$$w0rd" ,
                new[] { "Sales", "Teamleads" });
            Protector.Register("Eve", "Pa$$w0rd");

            Write($" Name Karbarie Khodeto Vazeity: ");
            string username = ReadLine();
            Write($"Ramze Khodeto bezan mocholo: ");
            string Ramz = ReadLine();

            // تابع ورود رو صدا میزنه
            Protector.LogIn(username , Ramz);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine(" Vorod retete....");
                return;
            }

            var p = Thread.CurrentPrincipal;
            // اینجا مشخصات کاربر رو نمایش میده
            WriteLine($" Motabar Hast: {p.Identity.IsAuthenticated}");
            WriteLine($"Noe Etebar sanji : {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

            if (p is ClaimsPrincipal)
            {   
                // اینجا نشون میده چه اختیاراتی داره
                WriteLine(
                    $"{p.Identity.Name} Daraye okhtiariate zir hasta mibasha:");

                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }
        
            try
            {
                SecureFeature();
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }

        }  // Main() انتهای تابع

        static void SecureFeature()
        {
            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException(
                    " Yek karbar bahsti vorod darva kone ta bedin vijegi dastesh varese.");
            }

            if (! Thread.CurrentPrincipal.IsInRole("Admins"))
            {
                throw new SecurityException(
                    "Karbar mibahasti ozve Sarparastan basha ta dastesh resideh besha.");   
            }

            WriteLine(" Shoma be in vijigoliane be tore eival residi.");
        }
    }
}