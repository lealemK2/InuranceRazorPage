using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Manager.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DetailsModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Location Location { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Location = await _context.Locations.Include(l=>l.Subcity).FirstOrDefaultAsync(a => a.Id == id);
            }
            return Page();
        }
    }
}
