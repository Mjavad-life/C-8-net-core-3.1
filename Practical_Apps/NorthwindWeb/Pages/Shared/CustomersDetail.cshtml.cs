using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;


namespace NorthwindWeb.Pages
{
    public class CustomersDetailModel : PageModel
    {
        [BindProperty]
        public Customer? CustomerDetail { get; set; }

        [BindProperty]
        public Order? OrderID {get; set; }


        private NorthWind db;

        public CustomersDetailModel(NorthWind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<string> CustomerDetail { get; set; }
        public IEnumerable<string> OrderDetail { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - CustomerDetail";

            CustomerDetail = db.Customers.SelectAll(s => s);
            OrderDetail =db.Order.Select(s => s.OrderID);

        }
    }
    }
}