using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CourseCatalogform
{
    public partial class CourseDetailsForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";

        private int currentCourseId;
        private int currentStudentId = 4;

        public CourseDetailsForm(int courseId)
        {
            InitializeComponent();
            currentCourseId = courseId;
        }

        private void CourseDetailsForm_Load(object sender, EventArgs e)
        {
            LoadCourseDetails();
            LoadReviews();
        }

        private void LoadCourseDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Title, Price, Description FROM Courses WHERE CourseId = @CourseId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", currentCourseId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTitle.Text = reader["Title"].ToString();
                            lblPrice.Text = "৳" + reader["Price"].ToString();
                            lblDescription.Text = reader["Description"].ToString();
                        }
                    }
                }
            }
        }

        private void LoadReviews()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT u.FullName, r.Rating, r.Comment, r.ReviewDate 
                                 FROM Reviews r 
                                 INNER JOIN Users u ON r.StudentId = u.UserId 
                                 WHERE r.CourseId = @CourseId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", currentCourseId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    dgvReviews.DataSource = dt;
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cart (StudentId, CourseId, Quantity) VALUES (@StudentId, @CourseId, 1)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    cmd.Parameters.AddWithValue("@CourseId", currentCourseId);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Cart (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    cmd.Parameters.AddWithValue("@CourseId", currentCourseId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Course added to cart successfully!");
            this.Close();
        }
    }
}