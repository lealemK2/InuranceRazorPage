using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Subcity.Name), IsUnique = true)]
    public class Subcity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
