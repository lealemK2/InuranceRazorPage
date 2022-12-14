namespace InuranceRazorPage.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string CbhiIdUsername { get; set; } = null!;
        public int CbhiId { get; set; }
        public Cbhi Cbhi { get; set; } = null!;
        public int nthMember { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int AddressId { get; set; }
        //public Address Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public DateTime Createdon { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        //public Role Role { get; set; }
    }
}
