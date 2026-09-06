using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CourseCatalogform
{
    public partial class Form4 : Form
    {

        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";

        public Form4()
        {
            InitializeComponent();
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }


        private void LoadCourses(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = "SELECT CourseId, Title, Category, Price, SeatsAvailable FROM Courses WHERE SeatsAvailable > 0";

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND Title LIKE @Search";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + keyword + "%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);


                    dgvCourses.DataSource = dt;
                }
            }
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            LoadCourses(keyword);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + txtSearch.Text.Trim() + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCourses.DataSource = dt;
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null) return;
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = selectedCategory == "All"
                    ? "SELECT * FROM Courses"
                    : "SELECT * FROM Courses WHERE Category = @Category AND SeatsAvailable > 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (selectedCategory != "All")
                    {
                        cmd.Parameters.AddWithValue("@Category", selectedCategory);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCourses.DataSource = dt;
                }
            }
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvCourses.Columns[e.ColumnIndex].Name == "btnAddToCart")
            {

                int courseId = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["CourseId"].Value);


                int studentId = 4;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query = "INSERT INTO Cart (StudentId, CourseId, Quantity) VALUES (@StudentId, @CourseId, 1)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        cmd.Parameters.AddWithValue("@CourseId", courseId);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Course added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void dgvCourses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedCourseId = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["CourseId"].Value);

                CourseDetailsForm detailsForm = new CourseDetailsForm(selectedCourseId);
                detailsForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CartForm cart = new CartForm();
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyLearningForm learning = new MyLearningForm();
            learning.Show();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + txtSearch.Text.Trim() + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCourses.DataSource = dt;
                }
            }
        }
    }

}
    
