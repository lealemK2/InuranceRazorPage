using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
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
        public Account Account { get; set; } = default!;

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
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            Account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            AccountDto = new AccountDto();
            AccountDto.Firstname = Account.Firstname;
            AccountDto.Fathername = Account.Fathername;
            AccountDto.Lastname = Account.Lastname;
            AccountDto.Username = Account.Username;
            AccountDto.Phone = Account.Phone;
            AccountDto.Gender = Account.Gender;
            AccountDto.Dob = Account.Dob;
            AccountDto.RoleId=Account.RoleId;
            //AccountDto.Address.Subcity = account.Address.Subcity;
            AccountDto.RoleId = 2;
            if (Account == null)
            {
                return NotFound();
            }
            //AccountDto.
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id )
        {
            if (AccountDto.Gender == "")
            {
                ModelState.AddModelError("AccountDto.Gender", "Gender field is required");
            }

            ModelState.Remove("AccountDto.Password");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //
            var Account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            Account.Firstname = AccountDto.Firstname;
            Account.Fathername = AccountDto.Fathername;
            Account.Lastname = AccountDto.Lastname;
            Account.Username = AccountDto.Username;
            Account.Phone = AccountDto.Phone;
            Account.Gender = AccountDto.Gender;
            Account.Dob = AccountDto.Dob.Date;
            Account.RoleId = AccountDto.RoleId;
            if (!String.IsNullOrEmpty( AccountDto.Password))
            {
                CreatePasswordHash(AccountDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                Account.PasswordHash= passwordHash;
                Account.PasswordSalt= passwordSalt;
            }

            _context.Accounts.Update(Account);
            //_context.Attach(Account).State = EntityState.Modified;
            //_context.Entry(Account).Property(x => x.PasswordHash).IsModified = true;
            //_context.Entry(Account).Property(x => x.PasswordSalt).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.Id))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../ManageAccounts");
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
