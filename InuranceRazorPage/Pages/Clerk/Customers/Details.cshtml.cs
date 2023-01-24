using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public DetailsModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerDto CustomerDto { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }

        public List<Subcity> Subcities { get; set; } = default!;
        public List<Package> Packages { get; set; } = default!;
        public string[] GenderOptions = new[] { "Male", "Female" };
        public string[] RelationOptions = new[] { "HouseHold", "Spouse", "Son", "Daughter", " Other " };


        public async Task<IActionResult> OnGetAsync(int? id)

        {
            if (_context.Subcities != null)
            {
                Subcities = await _context.Subcities.ToListAsync();
            }
            else
            {
                Subcities = new List<Subcity>();
            }
            if (_context.Packages != null)
            {
                Packages = await _context.Packages.ToListAsync();
            }
            else
            {
                Packages = new List<Package>();
            }

            Customer = await _context.Customers.Include(c => c.Address).Include(c => c.Address.Subcity).Include(c => c.Cbhi).FirstOrDefaultAsync(c => c.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            CustomerDto = new CustomerDto();
            CustomerDto.Firstname = Customer.Firstname;
            CustomerDto.Fathername = Customer.Fathername;
            CustomerDto.Lastname = Customer.Lastname;
            CustomerDto.Phone = Customer.Phone;
            CustomerDto.Gender = Customer.Gender;
            CustomerDto.Dob = Customer.Dob;
            CustomerDto.SubcityId = Customer.Address == null ? 0 : Customer.Address.SubcityId;
            CustomerDto.Woreda = Customer.Address == null ? 0 : Customer.Address.Woreda;
            CustomerDto.HouseNumber = Customer.Address == null ? 0 : Customer.Address.HouseNumber;
            CustomerDto.PackageId = Customer.Cbhi.PackageId;
            CustomerDto.Relation = Customer.Relation;
            Customer.Address = Customer.Address;

            return Page();
        }
    }
}
