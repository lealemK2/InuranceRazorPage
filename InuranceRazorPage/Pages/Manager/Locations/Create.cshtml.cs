using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InuranceRazorPage.Pages.Manager.Locations
{
    public class CreateModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPageContext context)
        {
            _context = context;
        }


        [BindProperty, Required]
        public Location Location { get; set; }

        public async Task OnGetAsync()
        {
           
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Locations.Add(Location);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageLocations");
        }
    }
}
