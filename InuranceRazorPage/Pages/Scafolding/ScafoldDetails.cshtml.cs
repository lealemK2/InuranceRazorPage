using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InuranceRazorPage.Data;
using InuranceRazorPage.Models;

namespace InuranceRazorPage.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DetailsModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

      public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
