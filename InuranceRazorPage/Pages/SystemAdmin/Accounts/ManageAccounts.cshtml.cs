using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    [Authorize(Roles = "SystemAdmin")]
    public class ManageAccountsModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public ManageAccountsModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        public IList<Account> Accounts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Accounts = await _context.Accounts.Include(a => a.role).ToListAsync();
            }
            else
            {
                Accounts = new List<Account>();
            }
        }
    }
}
