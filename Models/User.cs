namespace SkillBazaar.SuperAdminModule.Models
{
    /// <summary>
    /// Placeholder base class for the three account roles, matching the Users
    /// table (UserId, FullName, Email, UserType, Status). This mirrors what
    /// Samorpita's Core/Shared "User base class + role routing logic" is meant
    /// to provide — kept minimal here so SuperAdmin.cs has something to inherit
    /// from while this module lives on its own branch. Replace with the team's
    /// real User.cs on merge.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }

        public User() { }

        public User(int userId, string fullName, string email, string userType, string status)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            UserType = userType;
            Status = status;
        }

        /// <summary>
        /// Overridden per role so Login can call user.OpenDashboard() and land
        /// on the correct screen without an if/else on UserType (polymorphism,
        /// per Chapter 8 of the report).
        /// </summary>
        public virtual void OpenDashboard()
        {
            System.Windows.Forms.MessageBox.Show("No dashboard defined for this role yet.");
        }
    }
}
