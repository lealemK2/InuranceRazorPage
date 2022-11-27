﻿namespace InuranceRazorPage.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; }=null!;
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string Phone { get; set; } = null!;        
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public string Gender { get; set; }=null!;        
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public DateTime Createdon { get; set; } 
        public bool IsActive { get; set; }
        public int LocationId { get; set; }
        public Location Position { get; set; }=null !;
    }
}
