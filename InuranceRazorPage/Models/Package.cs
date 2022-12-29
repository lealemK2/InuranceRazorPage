using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Package.Name), IsUnique = true)]
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int MaxNumberOfAdult { get; set; }
        public decimal AdditionalFeePerAdult { get; set; }
    }
}
