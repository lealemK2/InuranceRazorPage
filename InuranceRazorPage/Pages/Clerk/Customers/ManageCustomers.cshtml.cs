using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    public class ManageCustomersModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public ManageCustomersModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customers = await _context.Customers.Include(a => a.Cbhi).Include(a => a.Cbhi.Package).ToListAsync();
            }
            else
            {
                Customers = new List<Customer>();
            }
        }
    }
}
