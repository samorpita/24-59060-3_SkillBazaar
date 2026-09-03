using System;

namespace SkillBazaar.Models
{
    // Base class for every account type in the system.
    // Student, Instructor, and SuperAdmin all inherit from this.
    public abstract class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }   // "SuperAdmin" / "Admin" / "Customer"
        public string Status { get; set; }     // "Pending" / "Approved" / "Suspended"

        protected User() { }

        protected User(int userId, string fullName, string email, string userType, string status)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            UserType = userType;
            Status = status;
        }

        // Every subclass must say which dashboard form to open after login.
        // This is the polymorphism hook: each role overrides this differently.
        public abstract string GetDashboardFormName();
    }
}
