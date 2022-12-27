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

        //[RegularExpression("^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).+", ErrorMessage = "Passwor must contain atleast 1 lower case, 1 upper case, 1 digit and 1 symbol")]
        public string Password { get; set; } = null!;
        [RegularExpression("(^[0-9]{4}[0-9]{6})", ErrorMessage = "Use Ethiopian phone format 09********")]//"[0-9]{4}[0-9]{6}"
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int RoleId { get; set; }
        //public Address Address { get; set; } = null!;
        public String Subcity { get; set; } = null!;
        //public Location Location { get; set; } = null!;
    }
}
