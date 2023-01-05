using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Principal;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    [Authorize(Roles = "Clerk")]
    public class EditModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public EditModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty, Required]
        public CustomerDto CustomerDto { get; set; }

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

            Customer customer = await _context.Customers.Include(c => c.Address).Include(c => c.Cbhi).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerDto = new CustomerDto();
            CustomerDto.Firstname = customer.Firstname;
            CustomerDto.Fathername = customer.Fathername;
            CustomerDto.Lastname = customer.Lastname;
            CustomerDto.Phone = customer.Phone;
            CustomerDto.Gender = customer.Gender;
            CustomerDto.Dob = customer.Dob;
            CustomerDto.SubcityId = customer.Address == null ? 0 : customer.Address.SubcityId;
            CustomerDto.Woreda = customer.Address == null ? 0 : customer.Address.Woreda;
            CustomerDto.HouseNumber = customer.Address == null ? 0 : customer.Address.HouseNumber;
            CustomerDto.PackageId = customer.Cbhi.PackageId;
            CustomerDto.Relation = customer.Relation;
            customer.Address = customer.Address;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Customer customer = await _context.Customers.Include(e => e.Address).Include(e => e.Cbhi).FirstOrDefaultAsync(a => a.Id == id);

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
            if (CustomerDto.Gender == null)
            {
                ModelState.AddModelError("CustomerDto.Gender", "The Gender field is required");
            }
            if (CustomerDto.PackageId == 0)
            {
                ModelState.AddModelError("CustomerDto.PackageId", "Please select a Package");
            }
            if (CustomerDto.Relation == null)
            {
                ModelState.AddModelError("CustomerDto.Relation", "The Relation field is required");
            }
            if (CustomerDto.IsDisabled == null)
            {
                ModelState.AddModelError("CustomerDto.IsDisabled", "Please select this field");
            }
            if (CustomerDto.SubcityId == 0)
            {
                ModelState.AddModelError("CustomerDto.SubcityId", "Please select a Subcity");
            }
            if (PhoneExists(CustomerDto.Phone))
            {
                ModelState.AddModelError("CustomerDto.Phone", "This Phone is already taken!");
                if (CustomerDto.Phone.Equals(customer.Phone))
                {
                    ModelState.Remove("CustomerDto.Phone");
                }
            }

            Address address = new Address()
            {
                Id=customer.AddressId,
                SubcityId = CustomerDto.SubcityId,
                Woreda = CustomerDto.Woreda,
                HouseNumber = CustomerDto.HouseNumber
            };
            if (AddressExists(address))
            {
                ModelState.AddModelError("CustomerDto.HouseNumber", "This Address is already taken!");
                if(CustomerDto.SubcityId==customer.Address.SubcityId&&
                    CustomerDto.Woreda == customer.Address.Woreda &&
                    CustomerDto.HouseNumber == customer.Address.HouseNumber)
                {
                    ModelState.Remove("CustomerDto.HouseNumber");
                }
            }
            ModelState.Remove("CustomerDto.PackageId");
            ModelState.Remove("CustomerDto.IsDisabled");

            if (!ModelState.IsValid)
            {
                return Page();
            }
             
            customer.Firstname = CustomerDto.Firstname; 
            customer.Fathername = CustomerDto.Fathername;
            customer.Lastname = CustomerDto.Lastname;
            customer.Phone = CustomerDto.Phone;
            customer.Dob = CustomerDto.Dob;
            customer.Gender = CustomerDto.Gender;
            customer.Relation = CustomerDto.Relation;

            var address4 = await _context.Addresses.FirstOrDefaultAsync(c => c.Id == customer.AddressId);
            address4.SubcityId = CustomerDto.SubcityId;
            address4.Woreda = CustomerDto.Woreda;
            address4.HouseNumber = CustomerDto.HouseNumber;


            _context.Addresses.Update(address4);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageCustomers");
        }



        public bool PhoneExists(string Phone)
        {
            if (_context.Customers.Any(x => x.Phone.Trim().ToUpper().Equals(Phone.Trim().ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddressExists(Address address)
        {
            if (_context.Customers.Include(a => a.Address).Any(x =>
                x.Address.SubcityId == address.SubcityId &&
                x.Address.Woreda == address.Woreda &&
                x.Address.HouseNumber == address.HouseNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string generateCbhi()
        {
            string cbhi;
            cbhi = String.Concat(CustomerDto.SubcityId.ToString(), "-",
                    CustomerDto.Woreda.ToString(), "-",
                    CustomerDto.HouseNumber.ToString(), "-",
                    DateTime.Now.Year.ToString(), "-",
                    DateTime.Now.Month.ToString(), "-",
                    DateTime.Now.Day.ToString());
            return cbhi;
        }
    }
}
