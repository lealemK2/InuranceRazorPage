using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Manager.Locations
{
    public class ManageLocationsModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public ManageLocationsModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        public IList<Location> Locations { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Locations = await _context.Locations.ToListAsync();
            }
            else
            {
                Locations = new List<Location>();
            }
        }
    }
}
