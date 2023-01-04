using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages.Manager.Enrollment
{
    [Authorize(Roles = "Manager")]
    public class ManageEnrollmentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
