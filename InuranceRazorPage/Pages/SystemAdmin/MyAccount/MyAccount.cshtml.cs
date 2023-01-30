using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.SystemAdmin.MyAccount
{
    public class MyAccountModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public MyAccountModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        public Account Account { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = _context.Accounts.FirstOrDefault(a => a.Username.Equals(User.Identity.Name));
            }
        }
    }
}
