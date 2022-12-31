using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    public class CreateModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        
        [BindProperty,Required]
        public CustomerDto CustomerDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female" };


        [BindProperty]
        public List<Subcity> Subcities { get; set; } = default!;
        [BindProperty]
        public List<Package> Packages { get; set; } = default!;
        public async Task OnGetAsync()
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
            CustomerDto = new CustomerDto();
            //DateTime myDate = DateTime.Now;
            //CustomerDto.Dob = myDate.AddYears(-18);
            CustomerDto.Dob = DateTime.Now.AddYears(-18);

        }

        public async Task<IActionResult> OnPostAsync()
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
            if (CustomerDto.Gender == null)
            {
                ModelState.AddModelError("CustomerDto.Gender", "The Gender field is required");
            }
            if (CustomerDto.PackageId == 0)
            {
                ModelState.AddModelError("CustomerDto.PackageId", "Please select a Package");
            }
            if (CustomerDto.SubcityId == 0)
            {
                ModelState.AddModelError("CustomerDto.Subcity", "Please select a Subcity");
            }
            if (PhoneExists(CustomerDto.Phone))
            {
                ModelState.AddModelError("CustomerDto.Phone", "This Phone is already taken!");
            }

            Address address = new Address()
            {
                SubcityId = CustomerDto.SubcityId,
                Woreda = CustomerDto.Woreda,
                HouseNumber = CustomerDto.HouseNumber,
            };
            if (AddressExists(address))
            {
                ModelState.AddModelError("CustomerDto.HouseNumber", "This Address is already taken!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = new Customer
            {
                Firstname = CustomerDto.Firstname,
                Fathername = CustomerDto.Fathername,
                Lastname = CustomerDto.Lastname,
                Phone = CustomerDto.Phone,
                Gender = CustomerDto.Gender,
                Dob = CustomerDto.Dob.Date,
                Address = address,
                Createdon = DateTime.Now
            };
            _context.Customers.Add(customer);
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


    }
}
