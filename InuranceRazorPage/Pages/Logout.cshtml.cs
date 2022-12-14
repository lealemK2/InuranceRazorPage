using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages
{
    public class LogoutModel : PageModel
    {

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            //if (!string.IsNullOrEmpty(ErrorMessage))
            //{
            //    ModelState.AddModelError(string.Empty, ErrorMessage);
            //}

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            //ReturnUrl = returnUrl;
            returnUrl ??= Url.Content("~/");
            return LocalRedirect(returnUrl);
        }

    }
}
