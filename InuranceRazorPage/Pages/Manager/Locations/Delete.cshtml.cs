using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Manager.Locations
{
    public class DeleteModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public DeleteModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Location Location { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Location = await _context.Locations.Include(l => l.Subcity).FirstOrDefaultAsync(a => a.Id == id);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (_context.Accounts != null)
            {
                Location = await _context.Locations.Include(l=>l.Subcity).FirstOrDefaultAsync(a => a.Id == id);
                if (Location != null)
                {
                    var address = await _context.Addresses.FirstOrDefaultAsync(a => a.SubcityId == Location.SubcityId);
                    if (address != null)
                    {
                        ModelState.AddModelError("Location.Subcity.Name", "Can't delete location when is currently used by someone");
                    }
                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }
                    _context.Subcities.Remove(Location.Subcity);
                    _context.Locations.Remove(Location);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./ManageLocations");
        }
    }
}
