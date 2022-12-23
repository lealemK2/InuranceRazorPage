using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(SubcityRange.SubcityId), IsUnique = true)]
    public class SubcityRange
    {
        public int Id { get; set; }
        public int SubcityId { get; set; }
        public Subcity Subcity { get; set; }
        public int WoredaRange { get; set; }
    }
}
