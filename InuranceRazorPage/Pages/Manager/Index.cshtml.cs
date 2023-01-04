using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.Managers
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
