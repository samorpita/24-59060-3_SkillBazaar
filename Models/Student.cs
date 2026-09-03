namespace SkillBazaar.Models
{
    public class Student : User
    {
        public Student() { }

        public Student(int userId, string fullName, string email, string status)
            : base(userId, fullName, email, "Customer", status)
        {
        }

        public override string GetDashboardFormName()
        {
            return "CourseCatalogForm";
        }
    }
}
