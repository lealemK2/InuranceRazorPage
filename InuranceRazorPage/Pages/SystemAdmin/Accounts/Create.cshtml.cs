using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    public class CreateModel : PageModel
    {
       



        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty,Required]
        public AccountDto AccountDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female"};



        public async Task<IActionResult> OnPostAsync()
        {
            if (AccountDto.Gender == "") {
                ModelState.AddModelError("AccountDto.Gender", "Gender field is required");
            }
            if (AccountDto.RoleId==0)
            {
                ModelState.AddModelError("AccountDto.RoleId", "Plese select a role");
            }

            if (UsernameExists(AccountDto.Username))
            {
                ModelState.AddModelError("AccountDto.Username", "Username is already taken!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            CreatePasswordHash(AccountDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var Account = new Account
            {
                Firstname = AccountDto.Firstname,
                Fathername = AccountDto.Fathername,
                Lastname = AccountDto.Lastname,
                Username = AccountDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = AccountDto.Phone,
                Gender = AccountDto.Gender,
                Dob = AccountDto.Dob.Date,
                RoleId=AccountDto.RoleId,
                Createdon = DateTime.Now
            };
            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("../ManageAccounts");
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
