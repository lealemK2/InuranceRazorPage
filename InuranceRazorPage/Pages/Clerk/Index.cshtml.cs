using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.Clerk
{
    [Authorize(Roles = "Clerk")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
