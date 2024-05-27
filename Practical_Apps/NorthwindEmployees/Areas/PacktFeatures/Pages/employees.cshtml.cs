using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace PacktFeatures.Pages
{
    public class EmployeesPageModel : PageModel
    {
        private NorthWind db;
        public EmployeesPageModel(NorthWind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }
    }
}