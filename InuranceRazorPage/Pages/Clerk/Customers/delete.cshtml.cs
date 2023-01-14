using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public DeleteModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Customer = await _context.Customers.FirstOrDefaultAsync(a => a.Id == id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Customer = await _context.Customers.FirstOrDefaultAsync(a => a.Id == id);
                if (Customer != null)
                {
                    _context.Customers.Remove(Customer);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./ManageCustomers");
        }
    }
}
