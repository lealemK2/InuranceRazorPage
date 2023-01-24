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
                Customer = await _context.Customers.Include(c=>c.Address).Include(c => c.Cbhi).FirstOrDefaultAsync(a => a.Id == id);

                if (Customer != null)
                {
                    var cbhi = await _context.Cbhis.FirstOrDefaultAsync(c => c.Id == Customer.CbhiId);
                    if (cbhi != null)
                    {
                        cbhi.NthTracker--;
                        cbhi.PayableMembers--;

                    }

                    if (Customer.Cbhi.TotalMembers == 1)
                    {
                        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == Customer.AddressId);
                        _context.Addresses.Remove(address);
                    }
                    _context.Customers.Remove(Customer);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./ManageCustomers");
        }
    }
}
