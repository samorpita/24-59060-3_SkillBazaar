using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SkillBazaar.Database;
using SkillBazaar.Models;

namespace SkillBazaar.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseConnection db = new DatabaseConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT UserId, FullName, Email, UserType, Status " +
                                "FROM Users WHERE Email=@email AND Password=@pwd";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@email", email),
                    new SqlParameter("@pwd", HashPassword(password))
                };

                DataTable result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = result.Rows[0];
                string status = row["Status"].ToString();

                if (status == "Pending")
                {
                    MessageBox.Show("Your account is still awaiting Super Admin approval.",
                        "Account Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (status == "Suspended")
                {
                    MessageBox.Show("Your account has been suspended. Contact support.",
                        "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = Convert.ToInt32(row["UserId"]);
                string fullName = row["FullName"].ToString();
                string userType = row["UserType"].ToString();

                User loggedInUser = CreateUserFromType(
                    userType, userId, fullName, email, status);

                OpenDashboard(loggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Factory method: builds the correct subclass based on UserType.
        // This is where inheritance/polymorphism gets used at runtime.
        private User CreateUserFromType(
            string userType,
            int userId,
            string fullName,
            string email,
            string status)
        {
            switch (userType)
            {
                case "SuperAdmin":
                    return new SuperAdmin(userId, fullName, email, status);

                case "Admin":
                    return new Instructor(userId, fullName, email, status);

                case "Customer":
                default:
                    return new Student(userId, fullName, email, status);
            }
        }

        // Opens the correct dashboard depending on which subclass logged in.
        private void OpenDashboard(User user)
        {
            this.Hide();

            switch (user.GetDashboardFormName())
            {
                case "SuperAdminDashboardForm":
                    // new SuperAdminDashboardForm((SuperAdmin)user).Show();
                    MessageBox.Show("Welcome Super Admin: " + user.FullName);
                    break;

                case "InstructorDashboardForm":
                    // new InstructorDashboardForm((Instructor)user).Show();
                    MessageBox.Show("Welcome Instructor: " + user.FullName);
                    break;

                case "CourseCatalogForm":
                default:
                    // new CourseCatalogForm((Student)user).Show();
                    MessageBox.Show("Welcome Student: " + user.FullName);
                    break;
            }
        }

        private void lnkSignUp_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }

        // SHA-256 hashing, same approach used in Lab 1.
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(
                    System.Text.Encoding.UTF8.GetBytes(password));

                var sb = new System.Text.StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
