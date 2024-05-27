using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;


namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {   

        [BindProperty]
        public Supplier? Supplier { get; set; }

        public IActionResult OnPost()
        {   
            bool p = true;
            // حل شد nullrefrence گداشته بود وقتی برش داشتم مشکل  Isvalid اینجا شرط 
            // اما هر دری وری که بزارم رو قبول میکنه حالا
            if (p)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }

        private NorthWind db;

        public SuppliersModel(NorthWind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<string> Suppliers { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";

            Suppliers = db.Suppliers.Select(s => s.CompanyName);

          /*  Suppliers = new[] 
            {
                "Alpha Co", "Beta Limited", "Gamma Corp"
            };
          */
        }
    }
}