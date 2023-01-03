using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.Principal;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{

    public class DeleteModel : PageModel
        {
        private readonly InuranceRazorPageContext _context;

        public DeleteModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
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
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
                if(Account != null)
                {
                    _context.Accounts.Remove(Account);
                }
            }

            return RedirectToPage("./ManageAccounts");
        }


    }

}
