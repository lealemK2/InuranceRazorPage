using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages
{
    public class RegisterUserModel : PageModel
    {
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string role { get; set; } = null!;
        public string cbhiId { get; set; } = null!;
        public void OnGet()
        {
            
        }
    }
}
