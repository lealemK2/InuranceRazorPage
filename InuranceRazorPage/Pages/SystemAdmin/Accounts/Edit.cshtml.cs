using InuranceRazorPage.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    public class EditModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public EditModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public AccountDto AccountDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            //AccountDto.
            return Page();
        }
    }
}
