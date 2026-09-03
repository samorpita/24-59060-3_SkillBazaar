namespace SkillBazaar.Models
{
    public class Instructor : User
    {
        public int InstituteId { get; set; }
        public string InstituteName { get; set; }

        public Instructor() { }

        public Instructor(int userId, string fullName, string email, string status)
            : base(userId, fullName, email, "Admin", status)
        {
        }

        public override string GetDashboardFormName()
        {
            return "InstructorDashboardForm";
        }
    }
}
