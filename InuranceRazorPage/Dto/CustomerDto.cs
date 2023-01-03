using InuranceRazorPage.Models;
using System.ComponentModel.DataAnnotations;

namespace InuranceRazorPage.Dto
{
    public class CustomerDto
    {
        [StringLength(25, MinimumLength = 3)]
        public string Firstname { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Fathername { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Lastname { get; set; } = null!;
        [RegularExpression("(^[0-9]{4}[0-9]{6})", ErrorMessage = "Use Ethiopian phone format 09********")]//"[0-9]{4}[0-9]{6}"
        public string Phone { get; set; } = null!;
        //public string ImagePath { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Relation { get; set; }=null!;
        public int SubcityId { get; set; }
        [Range(1, 30, ErrorMessage = "Woreda must be in range from 1 to 30")]
        public int? Woreda { get; set; }
        public int? HouseNumber { get; set; }
        public int PackageId { get; set; }
        public bool IsDisabled { get; set; }

    }
}
