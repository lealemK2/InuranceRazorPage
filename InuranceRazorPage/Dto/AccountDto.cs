using InuranceRazorPage.Models;
using System.ComponentModel.DataAnnotations;

namespace InuranceRazorPage.Dto
{
    public class AccountDto
    {
        [StringLength(25, MinimumLength = 3)]
        public string Firstname { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Fathername { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Lastname { get; set; } = null!;

        [StringLength(25, MinimumLength = 6)]//ErrorMessage = "Username lengtth should be"
        public string Username { get; set; } = null!;

        [StringLength(25, MinimumLength = 6)]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).+", ErrorMessage = "Password must contain atleast 1 lower case, 1 upper case, 1 digit and 1 symbol")]
        public string Password { get; set; } = null!;
        [RegularExpression("(^[0-9]{4}[0-9]{6})", ErrorMessage = "Use Ethiopian phone format 09********")]//"[0-9]{4}[0-9]{6}"
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int RoleId { get; set; }
        public int SubcityId { get; set; }
        [Range(1,30, ErrorMessage="Woreda must be in range from 1 to 30")]
        public int? Woreda { get; set; }
        [Range(1,50, ErrorMessage="Kebele must be in range from 1 to 50")]
        public int? Kebele { get; set; }

    }
}
