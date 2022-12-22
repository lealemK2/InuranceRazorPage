using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Location.Subcity), IsUnique = true)]
    public class Location
    {
        public int Id { get; set; }
        public string Subcity { get; set; } = null!;
        public string Kebele { get; set; } = null!;
        //navigation
        public Account Account { get; set; }
    }
}
