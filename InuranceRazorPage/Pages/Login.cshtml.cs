using InuranceRazorPage.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using InuranceRazorPage.Models;

namespace InuranceRazorPage.Pages
{
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public LoginDto LoginDto { get; set; }

        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public LoginModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var error=ModelState.ToString();
            ModelState.Remove("returnUrl");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = await _context.Accounts.Include(a=>a.role).
                FirstOrDefaultAsync(a => a.Username.ToLower() == LoginDto.Username.ToLower());
            if (account == null)
            {
                ModelState.AddModelError("LoginDto.Username", "Username Does not exist!");
                return Page();
            }

            if (!VerifyPasswordHash(LoginDto.Password, account.PasswordHash, account.PasswordSalt))
            {
                ModelState.AddModelError("LoginDto.Password", "Incorrect Password!");             

                return Page();
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LoginDto.Username),
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim(ClaimTypes.Role, account.role.RoleName)
                };

            var identity = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties{     };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);

            return LocalRedirect(returnUrl);
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash,
            byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
