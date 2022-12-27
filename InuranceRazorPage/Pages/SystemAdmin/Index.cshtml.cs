using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.SystemAdmin
{
    [Authorize(Roles ="SystemAdmin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
