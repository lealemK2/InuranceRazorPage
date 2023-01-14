namespace InuranceRazorPage.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int SubcityId { get; set; }
        public Subcity Subcity { get; set; }
        public int woreda { get; set; }
    }
}
