using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    public class DetailModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DetailModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Account=await _context.Accounts.Include(a => a.role).FirstOrDefaultAsync(a => a.Id == id);
            }
            return Page();
        }
    }
}
