using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages
{
    public class LogoutCustomerModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            Response.Cookies.Delete("loginCbhi");
            return RedirectToPage("./Index");
        }
    }
}
