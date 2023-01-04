using InuranceRazorPage.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using InuranceRazorPage.Models;
using InuranceRazorPage.Data;

namespace InuranceRazorPage.Pages
{
    public class LoginCustomerModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public LoginCustomerModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string CBHI { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync( )
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer customer = await _context.Customers.FirstOrDefaultAsync(a => a.LoginCbhi.Equals(CBHI));
            if (customer == null)
            {
                ModelState.AddModelError("CBHI", "CBHI ID does not exist");
                return Page();
            }
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(30);
            cookieOptions.Path = "/InsuredPerson";
            Response.Cookies.Append("loginCbhi", CBHI, cookieOptions);

            return RedirectToPage("./InsuredPerson/Index");
        }

    }
}
