using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        
        [BindProperty]
        public Customer? Customer { get; set; }


        private NorthWind db;

        public CustomersModel(NorthWind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<string> Customers { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Customers";

            Customers = db.Customers.Select(s => s.CompanyName).
                        GroupBy(s => s.CountryName);

        }
    }
}