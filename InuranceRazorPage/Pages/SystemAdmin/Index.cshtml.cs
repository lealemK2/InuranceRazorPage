using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.SystemAdmin
{
    [Authorize(Roles ="Admin")]
    //[Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
