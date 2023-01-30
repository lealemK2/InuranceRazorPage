using InuranceRazorPage.Data;
using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace InuranceRazorPage.Pages.SystemAdmin.MyAccount
{
    public class ChangePasswordModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public ChangePasswordModel(InuranceRazorPageContext context)
        {
            _context = context;
        }

        public byte[] pwdHash { get; set; }
        public byte[] pwdSalt { get; set; }
        [BindProperty]
        public string OldPassword { get; set; }
        [BindProperty]
        [StringLength(25, MinimumLength = 6)]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).+", ErrorMessage = "Password must contain atleast 1 lower case, 1 upper case, 1 digit and 1 symbol")]
        public string NewPassword { get; set; }
        [BindProperty]
        public string ConfirmNewPassword { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!VerifyPasswordHash(OldPassword, account.PasswordHash, account.PasswordSalt))
            {
                ModelState.AddModelError("OldPassword", "Incorrect old Password!");

                return Page();
            }

            if (!String.IsNullOrEmpty(NewPassword)&& !String.IsNullOrEmpty(NewPassword)&&!NewPassword.Equals(ConfirmNewPassword))
            {
                ModelState.AddModelError("ConfirmNewPassword", "Your confirmed Password is not similliar ");
                return Page();
            }

            CreatePasswordHash(NewPassword , out byte[] passwordHash, out byte[] passwordSalt);
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;
        
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Manager"))
            {
                return RedirectToPage("/Manager/MyAccount/MyAccount");
            }
            if (User.IsInRole("Clerk"))
            {
                return RedirectToPage("/Clerk/MyAccount/MyAccount");
            }
            return RedirectToPage("./MyAccount");
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash,
            byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
