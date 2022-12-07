using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AccountDto AccountDto { get; set; }

        //public Account Account { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
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
                Username=AccountDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
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
