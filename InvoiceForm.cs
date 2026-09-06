using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseCatalogform
{
    public partial class InvoiceForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";

        public InvoiceForm(int orderId)
        {
            InitializeComponent();
            LoadInvoiceData(orderId);
        }

        private void LoadInvoiceData(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string orderQuery = "SELECT TotalAmount, OrderDate FROM Orders WHERE OrderId = @OrderId";
                using (SqlCommand cmd = new SqlCommand(orderQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = "Order ID: #" + orderId;
                            label2.Text = "Total: ৳" + reader["TotalAmount"].ToString();
                        }
                    }
                }

                string itemQuery = @"SELECT c.Title, oi.Quantity, oi.UnitPrice, oi.Subtotal 
                                     FROM OrderItems oi 
                                     INNER JOIN Courses c ON oi.CourseId = c.CourseId 
                                     WHERE oi.OrderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(itemQuery, itemQuery == null ? null : conn)) 
                {
                }

                using (SqlCommand cmd = new SqlCommand(itemQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}