using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Role.RoleName), IsUnique = true)]
    public class Role
    {
        //clerk,syadmin, manag
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

    }
}
