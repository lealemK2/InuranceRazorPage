using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.Clerk.MyAccount
{
    public class MyAccountModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public MyAccountModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Account Account { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = _context.Accounts.FirstOrDefault(a => a.Username.Equals(User.Identity.Name));
            }
            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
