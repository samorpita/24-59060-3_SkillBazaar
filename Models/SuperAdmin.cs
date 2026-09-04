using SkillBazaar.SuperAdminModule.Forms;

namespace SkillBazaar.SuperAdminModule.Models
{
    /// <summary>
    /// SuperAdmin role. OpenDashboard() is what the shared Login form should
    /// call after authenticating a user whose UserType = 'SuperAdmin'.
    /// </summary>
    public class SuperAdmin : User
    {
        public SuperAdmin(int userId, string fullName, string email, string status)
            : base(userId, fullName, email, "SuperAdmin", status)
        {
        }

        public override void OpenDashboard()
        {
            SuperAdminDashboardForm dashboard = new SuperAdminDashboardForm();
            dashboard.Show();
        }
    }
}
