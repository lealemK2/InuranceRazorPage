using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.SystemAdmin
{
    public class ManageUsersModel : PageModel
    {
        //public void OnGet()
        //{
        //}
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public ManageUsersModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        public IList<Account> Accounts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Accounts = await _context.Accounts.ToListAsync();
            }
        }
    }
}
