using InuranceRazorPage.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InuranceRazorPage.Pages
{
    public class UserModel : PageModel
    {
        public List<User> Users { get; set; }
        public void OnGet()
        {
            Users = new List<User>()
            {
                new User() {
                    Id=1, Firstname = "Lealem",  Fathername="kifle", Lastname="Bedlu", Username="lalusr",
                    
                },
                new User() {
                    Id=2, Firstname = "Cozy",  Fathername="kifle", Lastname="Bedlu", Username="cozusr",
                    
                }
            };
        }
    }
}
