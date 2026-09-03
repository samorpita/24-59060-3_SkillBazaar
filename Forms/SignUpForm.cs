using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SkillBazaar.Database;

namespace SkillBazaar.Forms
{
    public partial class SignUpForm : Form
    {
        private readonly DatabaseConnection db = new DatabaseConnection();

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (!ValidateInput(fullName, email, password))
                return;

            string userType = radioInstructor.Checked ? "Admin" : "Customer";
            // Instructors need Super Admin approval before they can log in;
            // Students are approved immediately.
            string status = userType == "Admin" ? "Pending" : "Approved";

            try
            {
                // Check for duplicate email first
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email=@email";
                object count = db.ExecuteScalar(checkQuery, new[] { new SqlParameter("@email", email) });

                if (Convert.ToInt32(count) > 0)
                {
                    MessageBox.Show("An account with this email already exists.", "Duplicate Email",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertQuery = "INSERT INTO Users (FullName, Email, Password, Phone, Address, UserType, Status) " +
                                      "VALUES (@fullName, @email, @pwd, @phone, @address, @userType, @status)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@fullName", fullName),
                    new SqlParameter("@email", email),
                    new SqlParameter("@pwd", LoginForm.HashPassword(password)),
                    new SqlParameter("@phone", phone),
                    new SqlParameter("@address", address),
                    new SqlParameter("@userType", userType),
                    new SqlParameter("@status", status)
                };

                db.ExecuteNonQuery(insertQuery, parameters);

                string message = userType == "Admin"
                    ? "Account created! Please wait for Super Admin approval before logging in."
                    : "Account created successfully! You can now log in.";

                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                new LoginForm().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(string fullName, string email, string password)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
