using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Xml.Linq;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    [Authorize(Roles = "SystemAdmin")]
    public class EditModel : PageModel
    {
        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public EditModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountDto AccountDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female" };
        public IList<Role> Roles { get; set; } = default!;
        public IList<Subcity> Subcities { get; set; } = default!;
        public Account account { get; set; } = default!;
        public IEnumerable<SelectListItem> Genders;
        //public IEnumerable<SelectListItem> Roles2;


        public async Task<IActionResult> OnGetAsync(int? id)
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
            AccountDto.Kebele = account.Address == null ? 0 : account.Address.Kebele;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id )
        {
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
            if (AccountDto.Woreda == 0)
            {
                ModelState.AddModelError("AccountDto.Woreda", "Please select a Woreda");
            }
            //if (AccountDto.Woreda == 0)
            //{
            //    ModelState.AddModelError("AccountDto.Woreda", "Please select a Woreda");
            //}
            //if (AccountDto.Kebele == 0)
            //{
            //    ModelState.AddModelError("AccountDto.Woreda", "Please select a Kebele");
            //}

            if (string.IsNullOrEmpty(AccountDto.Password))//not the same
            {
                ModelState.Remove("AccountDto.Password");
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
            address.Kebele = AccountDto.Kebele;


            if (!string.IsNullOrEmpty(AccountDto.Password))//not the same
            {
                
                CreatePasswordHash(AccountDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
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
