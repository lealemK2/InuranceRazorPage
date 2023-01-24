using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;

namespace InuranceRazorPage.Pages.Manager.Locations
{
    public class EditModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public EditModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty,Required]
        public Location Location { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                return NotFound();
            }
            Location = await _context.Locations.Include(c=>c.Subcity).FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            ModelState.Remove("Location.Subcity");
            var address = await _context.Addresses.Include(l=>l.Subcity).FirstOrDefaultAsync(a => a.Subcity.Name.Equals(Location.Subcity.Name) && a.Woreda > Location.woreda);
            if (address != null)
            {
                ModelState.AddModelError("Location.Woreda", "Can't edit location when there is an address entry with a larger woreda number");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var location = await _context.Locations.Include(l=>l.Subcity).FirstOrDefaultAsync(a => a.Id == id);
            if (!location.Subcity.Name.Equals(Location.Subcity.Name))
            {
                location.Subcity.Name = Location.Subcity.Name;
            }
            location.woreda = Location.woreda;
            location.woreda = Location.woreda;

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageLocations");

        }
    }
}
