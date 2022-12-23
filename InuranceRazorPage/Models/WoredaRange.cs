namespace InuranceRazorPage.Models
{
    public class WoredaRange
    {
        public int Id { get; set; }
        public  int SubcityId { get; set; }
        public  Subcity Subcity { get; set; }
        public int Woreda { get; set; }
        public int KebeleRange { get; set; }
    }
}
