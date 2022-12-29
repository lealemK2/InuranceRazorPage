using InuranceRazorPage.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages
{
    public class LoginCustomerModel : PageModel
    {
        [BindProperty]
        public string cbhiUsername { get; set; }
        public void OnGet()
        {
        }
    }
}
