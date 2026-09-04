namespace SkillBazaar.Models
{
    /// <summary>Shared base class for all authenticated SkillBazaar roles.</summary>
    public abstract class User
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

        /// <summary>Returns the role-specific dashboard name for polymorphic routing.</summary>
        public abstract string GetDashboardFormName();
    }
}
