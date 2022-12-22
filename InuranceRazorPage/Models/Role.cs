namespace InuranceRazorPage.Models
{
    public class Role
    {
        //clerk,syadmin, manag
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public List<AccountRole> AccountRoles { get; set; }


    }
}
