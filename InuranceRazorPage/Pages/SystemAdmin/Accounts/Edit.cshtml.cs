using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Security.Principal;
using System.Xml.Linq;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    [Authorize(Roles = "SystemAdmin")]
    public class EditModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public EditModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountDto AccountDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female" };
        public IList<Role> Roles { get; set; } = default!;
        public IList<Subcity> Subcities { get; set; } = default!;
        public string UrlParam { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, string urlP)
        {
            
            if (_context.Roles != null)
            {
                Roles = await _context.Roles.ToListAsync();
            }
            if (_context.Subcities != null)
            {
                Subcities = await _context.Subcities.ToListAsync();
            }
            if (id == null || _context.Accounts == null){         
                return NotFound();
            }

            Account account = await _context.Accounts.Include(e => e.Address).FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            AccountDto = new AccountDto();
            AccountDto.Firstname = account.Firstname;
            AccountDto.Fathername = account.Fathername;
            AccountDto.Lastname = account.Lastname;
            AccountDto.Username = account.Username;
            AccountDto.Phone = account.Phone;
            AccountDto.Gender = account.Gender;
            AccountDto.Dob = account.Dob;
            AccountDto.RoleId=account.RoleId;
            AccountDto.SubcityId = account.Address == null ? 0: account.Address.SubcityId;
            AccountDto.Woreda= account.Address == null ? 0 : account.Address.Woreda;
            AccountDto.HouseNumber= account.Address == null ? 0 : account.Address.HouseNumber;

            UrlParam = urlP ?? string.Empty;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string urlP)
        {
            UrlParam = urlP ?? string.Empty;

            if (_context.Roles != null)
            {
                Roles = await _context.Roles.ToListAsync();
            }
            else
            {
                Roles = new List<Role>();
            }
            if (_context.Subcities != null)
            {
                Subcities = await _context.Subcities.ToListAsync();
            }
            else
            {
                Subcities = new List<Subcity>();
            }

            if (AccountDto.Gender==null)
            {
                ModelState.AddModelError("AccountDto.Gender", "The Gender field is required");
            }
            if (AccountDto.RoleId == 0)
            {
                ModelState.AddModelError("AccountDto.RoleId", "Please select a Role");
            }
            if (AccountDto.SubcityId == 0)
            {
                ModelState.AddModelError("AccountDto.SubcityId", "Please select a Subcity");
            }
            DateTime today = DateTime.Today;
            int age = today.Year - AccountDto.Dob.Year;
            if (AccountDto.Dob > today.AddYears(-age))
                age--;
            if (age < 18)
            {
                ModelState.AddModelError("AccountDto.Dob", "Age must be above 18");
            }
            if (AccountDto.Woreda == 0)
            {
                ModelState.AddModelError("AccountDto.Woreda", "Please select a Woreda");
            }

            if (string.IsNullOrEmpty(AccountDto.Password))//not the same
            {
                ModelState.Remove("AccountDto.Password");
            }
            ModelState.Remove("urlP");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var location = await _context.Locations.Include(l => l.Subcity).FirstOrDefaultAsync(l => AccountDto.SubcityId == l.SubcityId && l.woreda < AccountDto.Woreda);
            if (location != null)
            {
                ModelState.AddModelError("AccountDto.Woreda", location.Subcity.Name + " subcity has woreda range from 1 upto " + location.woreda);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var account = new Account();
            account=await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            account.Firstname = AccountDto.Firstname;
            account.Fathername = AccountDto.Fathername;
            account.Lastname = AccountDto.Lastname;
            account.Username = AccountDto.Username;
            account.Phone = AccountDto.Phone;            
            account.Dob = AccountDto.Dob.Date;
            account.Gender = AccountDto.Gender;
            account.RoleId = AccountDto.RoleId;

            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == account.AddressId);
            address.SubcityId = AccountDto.SubcityId;
            address.Woreda = AccountDto.Woreda;
            address.HouseNumber = AccountDto.HouseNumber;


            if (!string.IsNullOrEmpty(AccountDto.Password))
            {
                
                CreatePasswordHash(AccountDto.Password, out byte[] passwordHash, 
                                            out byte[] passwordSalt);
                account.PasswordHash= passwordHash;
                account.PasswordSalt= passwordSalt;
            }
            _context.Addresses.Update(address);
            _context.Accounts.Update(account);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(account.Id))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (UrlParam.Equals("MyAccountSystemAdmin"))
            {
                return RedirectToPage("/SystemAdmin/MyAccount/MyAccount");
            }
            return RedirectToPage("./ManageAccounts");
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool UsernameExists(string Username)
        {
            if (_context.Accounts.Any(x => x.Username.Trim().ToUpper().Equals(Username.Trim().ToUpper())))
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
