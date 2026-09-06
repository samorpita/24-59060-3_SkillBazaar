using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CourseCatalogform
{
    public partial class CartForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";
        int currentStudentId = 4; 

        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void LoadCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.CartId, co.Title, co.Price, c.Quantity, (co.Price * c.Quantity) AS Subtotal 
                                 FROM Cart c 
                                 INNER JOIN Courses co ON c.CourseId = co.CourseId 
                                 WHERE c.StudentId = @StudentId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    
                    adapter.Fill(dt);
                    dgvCart.DataSource = dt;
                    
                    decimal totalAmount = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalAmount += Convert.ToDecimal(row["Subtotal"]);
                    }
                    lblTotal.Text = "Cart Total: ৳" + totalAmount.ToString("0.00");
                }
            }
        }
        int newOrderId = 0;
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int currentStudentId = 4; 
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Integrated Security=True;";
            int generatedOrderId = 0;
            decimal totalAmount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string totalQuery = "SELECT ISNULL(SUM(c.Price), 0) FROM Cart ca JOIN Courses c ON ca.CourseId = c.CourseId WHERE ca.StudentId = @StudentId";
                using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    totalAmount = (decimal)cmd.ExecuteScalar();
                }

                if (totalAmount <= 0)
                {
                    MessageBox.Show("Your cart is empty!");
                    return;
                }

                string orderQuery = "INSERT INTO Orders (StudentId, OrderDate, TotalAmount, PaymentMethod) VALUES (@StudentId, GETDATE(), @Total, 'bKash'); SELECT CAST(SCOPE_IDENTITY() AS INT);"; using (SqlCommand cmd = new SqlCommand(orderQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    cmd.Parameters.AddWithValue("@Total", totalAmount);
                    generatedOrderId = (int)cmd.ExecuteScalar();
                }

                string moveQuery = @"INSERT INTO OrderItems (OrderId, CourseId, Quantity, UnitPrice, Subtotal) 
                             SELECT @OrderId, ca.CourseId, 1, c.Price, c.Price 
                             FROM Cart ca 
                             JOIN Courses c ON ca.CourseId = c.CourseId 
                             WHERE ca.StudentId = @StudentId";
                using (SqlCommand cmd = new SqlCommand(moveQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", generatedOrderId);
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    cmd.ExecuteNonQuery();
                }

                string clearQuery = "DELETE FROM Cart WHERE StudentId = @StudentId";
                using (SqlCommand cmd = new SqlCommand(clearQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                    cmd.ExecuteNonQuery();
                }
            }

            InvoiceForm invoiceForm = new InvoiceForm(generatedOrderId);
            invoiceForm.ShowDialog();
            this.Close();
        }


    }


    
    
    
}