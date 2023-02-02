using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InuranceRazorPage.Pages.InsuredPerson
{
    public class IndexModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public IndexModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        public int Age { get; set; }
        public string Package { get; set; }
        public String EndDateStr { get; set; }
        public TimeSpan LeftToExprire { get; set; }
        public double DaysLeft { get; set; }




        public async Task OnGetAsync()
        {
            var loginCbhi = Request.Cookies["loginCbhi"];
            if(loginCbhi == null || _context.Customers==null)
            {
                Response.Redirect("./LoginCustomer");
                Customer = new Customer();
                Customer.Address = new Address();
                Customer.Address.Subcity = new Subcity();
                Customer.Cbhi = new Cbhi();
            }
            if (_context.Customers!=null && loginCbhi != null)
            {
                Customer=_context.Customers.Include(c=>c.Cbhi).Include(c => c.Address).Include(c => c.Address.Subcity).FirstOrDefault(c=>c.LoginCbhi.Equals(loginCbhi));
                Age = DateTime.Today.Year - Customer.Dob.Year;
                Package = (Customer.Cbhi.PackageId == 2) ? "Family" : "Basic";
                var EndD = Customer.Cbhi.EndDate;
                EndDateStr = String.Concat(EndD.Day,"/",EndD.Month,"/",EndD.Year);
                LeftToExprire = EndD.Subtract(DateTime.Now);
                LeftToExprire = LeftToExprire;
                DaysLeft=LeftToExprire.TotalDays;
                DaysLeft = (int)DaysLeft;

            }

        }

        


    }
}
