namespace InuranceRazorPage.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Subcity { get; set; } = null!;
        public string Kebele { get; set; } = null!;
        public int Woreda { get; set; }
        public int HouseNumber { get; set; }
        //navigation
        public Account Account { get; set; }

    }
}
