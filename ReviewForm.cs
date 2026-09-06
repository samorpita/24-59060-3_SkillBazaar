using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CourseCatalogform
{

    public partial class ReviewForm : Form
    {
        private int courseId;
        private int studentId;

        public ReviewForm(int cId, int sId)
        {
            InitializeComponent();
            courseId = cId;
            studentId = sId;
        }
        public ReviewForm()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Verify that the student has actually purchased/enrolled in this course
                string checkQuery = @"SELECT COUNT(*) FROM OrderItems oi 
                              JOIN Orders o ON oi.OrderId = o.OrderId 
                              WHERE o.StudentId = @StudentId AND oi.CourseId = @CourseId";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@StudentId", studentId);
                    checkCmd.Parameters.AddWithValue("@CourseId", courseId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("You can only review courses you have enrolled in!");
                        return;
                    }
                }

                // 2. Insert the review into the database if validation passes
                string insertQuery = "INSERT INTO Reviews (StudentId, CourseId, Rating, Comment, ReviewDate) VALUES (@StudentId, @CourseId, @Rating, @Comment, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    cmd.Parameters.AddWithValue("@Rating", Convert.ToInt32(cmbRating.SelectedItem));
                    cmd.Parameters.AddWithValue("@Comment", txtComment.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Review submitted successfully!");
            this.Close();
        }

      
    }

}
