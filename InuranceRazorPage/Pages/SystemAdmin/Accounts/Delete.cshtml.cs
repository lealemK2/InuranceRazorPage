using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    public class DeleteModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DeleteModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts.Include(a => a.role).FirstOrDefaultAsync(a => a.Id == id);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);

            if (account != null)
            {
                Account = account;
                _context.Accounts.Remove(Account);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
