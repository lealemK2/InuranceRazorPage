using System.Security.Principal;

namespace InuranceRazorPage.Data.Models
{
    public class AccountRole
    {
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public int AccountId { get; set; }
        public Account Account { get; set; }= null!;
    }
}
