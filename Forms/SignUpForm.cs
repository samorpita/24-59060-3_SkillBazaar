using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SkillBazaar.Database;

namespace SkillBazaar.Forms
{
    public class SignUpForm : Form
    {
        private readonly DatabaseConnection db = new DatabaseConnection();
        private RadioButton studentRadio, instructorRadio;
        private TextBox nameBox, emailBox, passwordBox, confirmBox, phoneBox, addressBox, instituteBox, categoryBox;
        private Label instituteLabel, categoryLabel;

        public SignUpForm()
        {
            Text = "SkillBazaar - Create Account";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(560, 650);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Ui.Page;
            BuildInterface();
        }

        private void BuildInterface()
        {
            Controls.Add(new Label { Text = "Create your SkillBazaar account", Location = new Point(45, 24), Size = new Size(470, 42), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = Ui.PrimaryDark });
            studentRadio = new RadioButton { Text = "Student / Customer", Location = new Point(95, 78), AutoSize = true, Checked = true };
            instructorRadio = new RadioButton { Text = "Instructor / Provider", Location = new Point(300, 78), AutoSize = true };
            studentRadio.CheckedChanged += (s, e) => ToggleInstructorFields();
            instructorRadio.CheckedChanged += (s, e) => ToggleInstructorFields();
            Controls.AddRange(new Control[] { studentRadio, instructorRadio });

            nameBox = AddField("Full name *", 112, false);
            emailBox = AddField("Email *", 172, false);
            passwordBox = AddField("Password *", 232, true);
            confirmBox = AddField("Confirm password *", 292, true);
            phoneBox = AddField("Phone", 352, false);
            addressBox = AddField("Address", 412, false);

            instituteLabel = Ui.FieldLabel("Institute name *", 45, 472);
            instituteBox = Ui.TextBox(45, 494, 290);
            categoryLabel = Ui.FieldLabel("Institute category *", 350, 472);
            categoryBox = Ui.TextBox(350, 494, 165);
            Controls.AddRange(new Control[] { instituteLabel, instituteBox, categoryLabel, categoryBox });

            Button create = Ui.Button("Create Account", 45, 548, 470, Ui.Success);
            create.Click += CreateAccount;
            Button cancel = Ui.Button("Back to Login", 185, 597, 190, Ui.Primary);
            cancel.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { create, cancel });
            AcceptButton = create;
            ToggleInstructorFields();
        }

        private TextBox AddField(string label, int y, bool password)
        {
            Controls.Add(Ui.FieldLabel(label, 45, y));
            TextBox box = Ui.TextBox(45, y + 22, 470);
            box.UseSystemPasswordChar = password;
            Controls.Add(box);
            return box;
        }

        private void ToggleInstructorFields()
        {
            bool visible = instructorRadio.Checked;
            instituteLabel.Visible = instituteBox.Visible = categoryLabel.Visible = categoryBox.Visible = visible;
        }

        private void CreateAccount(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim();
            string email = emailBox.Text.Trim().ToLowerInvariant();
            string password = passwordBox.Text;
            string phone = phoneBox.Text.Trim();
            string address = addressBox.Text.Trim();

            if (name.Length < 3 || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { MessageBox.Show("Enter a valid full name and email address.", "Validation"); return; }
            if (password.Length < 6 || password != confirmBox.Text)
            { MessageBox.Show("Passwords must match and contain at least 6 characters.", "Validation"); return; }
            if (instructorRadio.Checked && (string.IsNullOrWhiteSpace(instituteBox.Text) || string.IsNullOrWhiteSpace(categoryBox.Text)))
            { MessageBox.Show("Instructor registration requires an institute name and category.", "Validation"); return; }

            try
            {
                if (Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Email=@email", new[] { new SqlParameter("@email", email) })) > 0)
                { MessageBox.Show("An account with this email already exists.", "Duplicate Email"); return; }

                using (SqlConnection connection = db.GetConnection())
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int userId;
                            string userType = instructorRadio.Checked ? "Admin" : "Customer";
                            string status = instructorRadio.Checked ? "Pending" : "Approved";
                            using (SqlCommand command = new SqlCommand(@"INSERT Users(FullName,Email,Password,Phone,Address,UserType,Status)
                                VALUES(@name,@email,@password,@phone,@address,@type,@status); SELECT CAST(SCOPE_IDENTITY() AS INT);", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@email", email);
                                command.Parameters.AddWithValue("@password", LoginForm.HashPassword(password));
                                command.Parameters.AddWithValue("@phone", phone);
                                command.Parameters.AddWithValue("@address", address);
                                command.Parameters.AddWithValue("@type", userType);
                                command.Parameters.AddWithValue("@status", status);
                                userId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            if (instructorRadio.Checked)
                            {
                                using (SqlCommand command = new SqlCommand(@"INSERT Institutes(OwnerId,InstituteName,Category,Address,ContactPhone,Status)
                                    VALUES(@owner,@institute,@category,@address,@phone,'Pending')", connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@owner", userId);
                                    command.Parameters.AddWithValue("@institute", instituteBox.Text.Trim());
                                    command.Parameters.AddWithValue("@category", categoryBox.Text.Trim());
                                    command.Parameters.AddWithValue("@address", address);
                                    command.Parameters.AddWithValue("@phone", phone);
                                    command.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                        }
                        catch { transaction.Rollback(); throw; }
                    }
                }

                MessageBox.Show(instructorRadio.Checked
                    ? "Registration submitted. A Super Admin must approve the institute before login."
                    : "Account created successfully. You can now log in.", "Registration Complete");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Account creation failed.\n\n" + ex.Message, "SkillBazaar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
