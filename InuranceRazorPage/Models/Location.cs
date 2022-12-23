namespace InuranceRazorPage.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int SubcityId { get; set; }
        public string Subcity { get; set; }
        public int woreda { get; set; }
        public int kebele { get; set; }
    }
}
