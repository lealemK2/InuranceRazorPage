using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Principal;

namespace InuranceRazorPage.Pages.Clerk.Customers
{
    [Authorize(Roles = "Clerk")]
    public class CreateOtherModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public CreateOtherModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty, Required]
        public CustomerDto CustomerDto { get; set; }

        //public Customer prevCustomer { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female" };
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            CustomerDto = new CustomerDto();
            CustomerDto.Dob = DateTime.Now.AddYears(-18);

            var prevCustomer = await _context.Customers.Include(a => a.Cbhi).Include(a => a.Cbhi.Package).FirstOrDefaultAsync(a => a.Id == id);
            if (prevCustomer == null)
            {
                return NotFound();
            }
            CustomerDto.PackageId = prevCustomer.Cbhi.PackageId;
            CustomerDto.SubcityId = prevCustomer.Address == null ? 0 : prevCustomer.Address.SubcityId;
            CustomerDto.Woreda = prevCustomer.Address == null ? 0 : prevCustomer.Address.Woreda;
            CustomerDto.HouseNumber = prevCustomer.Address == null ? 0 : prevCustomer.Address.HouseNumber;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (CustomerDto.Gender == null)
            {
                ModelState.AddModelError("CustomerDto.Gender", "The Gender field is required");
            }
            if (CustomerDto.Relation == null)
            {
                ModelState.AddModelError("CustomerDto.Relation", "The Relation field is required");
            }
            if (PhoneExists(CustomerDto.Phone))
            {
                ModelState.AddModelError("CustomerDto.Phone", "This Phone is already taken!");
            }
            if (CustomerDto.IsDisabled == null)
            {
                ModelState.AddModelError("CustomerDto.IsDisabled", "Please select this field");
            }
            if (CustomerDto.Relation == null)
            {
                ModelState.AddModelError("CustomerDto.IsDisabled", "Please select this field");
            }
            var prevCustomer = await _context.Customers.Include(a => a.Cbhi).Include(a => a.Address).Include(a => a.Cbhi.Package).FirstOrDefaultAsync(a => a.Id == id);
            if (CustomerDto.Relation.Equals("HouseHold"))
            {
                if (HouseHoldExists(prevCustomer.CbhiId))
                {
                    ModelState.AddModelError("CustomerDto.Relation", "No two HouseHold is allowed");
                }
            }


            //Address address = new Address()
            //{
            //    SubcityId = prevCustomer.Address.SubcityId,
            //    Woreda = prevCustomer.Address.Woreda,
            //    HouseNumber = prevCustomer.Address.SubcityId,
            //};

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!CustomerDto.IsDisabled)
            {
                if (CustomerDto.Dob.Year > 18)
                {
                   prevCustomer.Cbhi.PayableMembers += 1;
                }
            }            

            prevCustomer.Cbhi.TotalMembers+=1;
            prevCustomer.Cbhi.NthTracker +=1;
            var customer = new Customer
            {
                Firstname = CustomerDto.Firstname,
                Fathername = CustomerDto.Fathername,
                Lastname = CustomerDto.Lastname,
                Phone = CustomerDto.Phone,
                Gender = CustomerDto.Gender,
                Dob = CustomerDto.Dob.Date,
                Relation = CustomerDto.Relation,
                AddressId = prevCustomer.AddressId,
                CbhiId = prevCustomer.CbhiId,
                Createdon = DateTime.Now,
                
            };
            customer.LoginCbhi = String.Concat(prevCustomer.Cbhi.BaseCbhi, "-", prevCustomer.Cbhi.NthTracker);
            customer.IsDisabled = CustomerDto.IsDisabled;
            if (!CustomerDto.IsDisabled || (CustomerDto.Dob.Year > 18))
            {
                if (prevCustomer.Cbhi.PayableMembers > prevCustomer.Cbhi.Package.MaxNumberOfAdult)
                {
                    prevCustomer.Cbhi.AdditionalMembers += 1;
                }
            }

            _context.Cbhis.Update(prevCustomer.Cbhi);
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
        public bool HouseHoldExists(int cbhiId)
        {
            if (_context.Customers.Any(x => x.CbhiId == cbhiId && x.Relation.Equals("HouseHold")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string generateBaseCbhi()
        {
            string Logincbhi;
            Logincbhi = String.Concat(CustomerDto.SubcityId.ToString(), "-",
                    CustomerDto.Woreda.ToString(), "-",
                    CustomerDto.Woreda.ToString(), "-",
                    CustomerDto.PackageId.ToString(), "-",
                    DateTime.Now.Year.ToString(),
                    DateTime.Now.Month.ToString(),
                    DateTime.Now.Day.ToString(),
                    DateTime.Now.Hour.ToString(),
                    DateTime.Now.Second.ToString());
            return Logincbhi;
        }




    }

}
