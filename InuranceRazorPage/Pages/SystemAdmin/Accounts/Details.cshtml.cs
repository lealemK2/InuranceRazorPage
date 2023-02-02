using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    [Authorize(Roles = "SystemAdmin,Manager,Clerk")]
    public class DetailModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DetailModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;
        [BindProperty]
        public string UrlParam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id,string urlP)
        {
            if (_context.Accounts != null)
            {
                Account=await _context.Accounts.Include(a => a.role).Include(a => a.Address).Include(a => a.Address.Subcity).FirstOrDefaultAsync(a => a.Id == id);
            }
            UrlParam = urlP ?? string.Empty;
            return Page();
        }
    }
}


