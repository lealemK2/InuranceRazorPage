namespace InuranceRazorPage.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int SubcityId { get; set; }
        public Subcity Subcity { get; set; }
        public int? Woreda { get; set; }
        public int? Kebele { get; set; }
        public int? HouseNumber { get; set; }
        //navigations
        public Account Account { get; set; }

    }
}
