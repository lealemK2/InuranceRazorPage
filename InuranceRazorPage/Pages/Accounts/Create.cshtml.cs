using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using InuranceRazorPage.Dto;

namespace InuranceRazorPage.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public Account Account { get; set; }

        [BindProperty]
        public LoginDto LoginDto { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                int x = 10;
                return Page();
            }
            int z = 20;

            //_context.Account.Add(Account);
            await _context.SaveChangesAsync();

            int y = 20;

            return RedirectToPage("./Index");
        }
    }
}
