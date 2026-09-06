using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CourseCatalogform
{
    public partial class MyLearningForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";
        int currentStudentId = 4; // Hardcoded student ID for testing

        public MyLearningForm()
        {
            InitializeComponent();
        }

        private void MyLearningForm_Load(object sender, EventArgs e)
        {
            LoadEnrolledCourses();
        }

        private void LoadEnrolledCourses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT co.CourseId, o.OrderId, co.Title, co.Category, co.Price, o.OrderDate 
                 FROM OrderItems oi 
                 INNER JOIN Orders o ON oi.OrderId = o.OrderId 
                 INNER JOIN Courses co ON oi.CourseId = co.CourseId 
                 WHERE o.StudentId = @StudentId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    dgvMyCourses.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMyCourses.SelectedRows.Count > 0)
            {
                int courseId = Convert.ToInt32(dgvMyCourses.SelectedRows[0].Cells["CourseId"].Value);
                int studentId = 4; // Logged-in student ID
                ReviewForm reviewForm = new ReviewForm(courseId, studentId);
                reviewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an enrolled course to review.");
            }

        }
    }
}