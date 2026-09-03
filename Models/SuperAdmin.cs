namespace SkillBazaar.Models
{
    public class SuperAdmin : User
    {
        public SuperAdmin() { }

        public SuperAdmin(int userId, string fullName, string email, string status)
            : base(userId, fullName, email, "SuperAdmin", status)
        {
        }

        public override string GetDashboardFormName()
        {
            return "SuperAdminDashboardForm";
        }
    }
}
