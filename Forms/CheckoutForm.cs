using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SkillBazaar.Database;
using SkillBazaar.Models;

namespace SkillBazaar.Forms
{
    public class CheckoutForm : Form
    {
        private readonly Student student;
        private readonly DatabaseConnection db = new DatabaseConnection();
        private DataGridView itemGrid;
        private ComboBox paymentMethod;
        private TextBox paymentReference;
        private Label totalLabel;
        private decimal total;
        public bool PaymentCompleted { get; private set; }
        public int OrderId { get; private set; }

        public CheckoutForm(Student currentStudent)
        {
            student = currentStudent;
            Text = "SkillBazaar - Checkout";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(930, 610);
            BackColor = Ui.Page;
            BuildInterface();
            LoadSummary();
        }

        private void BuildInterface()
        {
            Controls.Add(Ui.Heading("Checkout and Invoice Preview", 24, 20));
            itemGrid = Ui.Grid(24, 65, 880, 320); Controls.Add(itemGrid);
            Controls.Add(Ui.FieldLabel("Payment method", 24, 420));
            paymentMethod = new ComboBox { Location = new Point(24, 443), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            paymentMethod.Items.AddRange(new object[] { "bKash", "Nagad", "Card", "Cash" }); paymentMethod.SelectedIndex = 0;
            paymentMethod.SelectedIndexChanged += (s, e) => paymentReference.Enabled = paymentMethod.Text != "Cash";
            Controls.Add(Ui.FieldLabel("Transaction / reference number", 225, 420));
            paymentReference = Ui.TextBox(225, 443, 280); Controls.Add(paymentReference);
            totalLabel = new Label { Location = new Point(585, 420), Size = new Size(320, 48), TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Ui.Success };
            Button pay = Ui.Button("Confirm Payment", 670, 495, 235, Ui.Success); pay.Click += CompletePayment;
            Button cancel = Ui.Button("Cancel", 535, 495, 120, Ui.Primary); cancel.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { paymentMethod, totalLabel, pay, cancel });
            AcceptButton = pay;
        }

        private void LoadSummary()
        {
            try
            {
                DataTable data = db.ExecuteQuery(@"SELECT c.Title,ca.Quantity,c.Price AS RegularPrice,ISNULL(a.DiscountPercent,0) DiscountPercent,
                    CAST(c.Price*(1-ISNULL(a.DiscountPercent,0)/100.0) AS DECIMAL(10,2)) FinalUnitPrice,
                    CAST(c.Price*(1-ISNULL(a.DiscountPercent,0)/100.0)*ca.Quantity AS DECIMAL(10,2)) Subtotal
                    FROM Cart ca JOIN Courses c ON ca.CourseId=c.CourseId
                    OUTER APPLY(SELECT MAX(DiscountPercent) DiscountPercent FROM Offers WHERE CourseId=c.CourseId AND CAST(GETDATE() AS DATE) BETWEEN StartDate AND EndDate)a
                    WHERE ca.StudentId=@student", new[] { new SqlParameter("@student", student.UserId) });
                itemGrid.DataSource = data; total = 0;
                foreach (DataRow row in data.Rows) total += Convert.ToDecimal(row["Subtotal"]);
                totalLabel.Text = "Total: " + Ui.Money(total);
                if (data.Rows.Count == 0) { MessageBox.Show("Your cart is empty."); Close(); }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void CompletePayment(object sender, EventArgs e)
        {
            string reference = paymentReference.Text.Trim();
            if (paymentMethod.Text != "Cash" && reference.Length < 4)
            { MessageBox.Show("Enter a valid transaction or payment reference number."); return; }
            if (paymentMethod.Text == "Cash" && reference.Length == 0) reference = "CASH-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                DataTable items = new DataTable();
                decimal finalTotal = 0;
                using (SqlConnection connection = db.GetConnection())
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            using (SqlCommand read = new SqlCommand(@"SELECT c.CourseId,c.Title,ca.Quantity,c.Price,c.SeatsAvailable,
                                ISNULL(a.DiscountPercent,0) DiscountPercent,CAST(c.Price*(1-ISNULL(a.DiscountPercent,0)/100.0) AS DECIMAL(10,2)) FinalUnitPrice
                                FROM Cart ca JOIN Courses c WITH(UPDLOCK,HOLDLOCK) ON ca.CourseId=c.CourseId
                                JOIN Institutes i ON c.InstituteId=i.InstituteId
                                OUTER APPLY(SELECT MAX(DiscountPercent) DiscountPercent FROM Offers WHERE CourseId=c.CourseId AND CAST(GETDATE() AS DATE) BETWEEN StartDate AND EndDate)a
                                WHERE ca.StudentId=@student AND c.Status='Active' AND i.Status='Approved'", connection, transaction))
                            {
                                read.Parameters.AddWithValue("@student", student.UserId);
                                using (SqlDataAdapter adapter = new SqlDataAdapter(read)) adapter.Fill(items);
                            }
                            if (items.Rows.Count == 0) throw new InvalidOperationException("There are no purchasable items in the cart.");

                            foreach (DataRow row in items.Rows)
                            {
                                int quantity = Convert.ToInt32(row["Quantity"]);
                                if (quantity > Convert.ToInt32(row["SeatsAvailable"])) throw new InvalidOperationException(row["Title"] + " does not have enough available seats.");
                                using (SqlCommand owned = new SqlCommand(@"SELECT COUNT(*) FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId WHERE o.StudentId=@student AND oi.CourseId=@course AND o.Status='Paid'", connection, transaction))
                                { owned.Parameters.AddWithValue("@student", student.UserId); owned.Parameters.AddWithValue("@course", row["CourseId"]); if (Convert.ToInt32(owned.ExecuteScalar()) > 0) throw new InvalidOperationException("You already own " + row["Title"] + "."); }
                                finalTotal += Convert.ToDecimal(row["FinalUnitPrice"]) * quantity;
                            }

                            using (SqlCommand order = new SqlCommand(@"INSERT Orders(StudentId,TotalAmount,PaymentMethod,PaymentReference,Status)
                                VALUES(@student,@total,@method,@reference,'Paid'); SELECT CAST(SCOPE_IDENTITY() AS INT);", connection, transaction))
                            {
                                order.Parameters.AddWithValue("@student", student.UserId); order.Parameters.AddWithValue("@total", finalTotal); order.Parameters.AddWithValue("@method", paymentMethod.Text); order.Parameters.AddWithValue("@reference", reference);
                                OrderId = Convert.ToInt32(order.ExecuteScalar());
                            }

                            foreach (DataRow row in items.Rows)
                            {
                                int quantity = Convert.ToInt32(row["Quantity"]); decimal unit = Convert.ToDecimal(row["Price"]); decimal discount = Convert.ToDecimal(row["DiscountPercent"]); decimal subtotal = Convert.ToDecimal(row["FinalUnitPrice"]) * quantity;
                                using (SqlCommand item = new SqlCommand(@"INSERT OrderItems(OrderId,CourseId,Quantity,UnitPrice,DiscountPercent,Subtotal) VALUES(@order,@course,@quantity,@price,@discount,@subtotal);
                                    UPDATE Courses SET SeatsAvailable=SeatsAvailable-@quantity WHERE CourseId=@course AND SeatsAvailable>=@quantity;", connection, transaction))
                                {
                                    item.Parameters.AddWithValue("@order", OrderId); item.Parameters.AddWithValue("@course", row["CourseId"]); item.Parameters.AddWithValue("@quantity", quantity); item.Parameters.AddWithValue("@price", unit); item.Parameters.AddWithValue("@discount", discount); item.Parameters.AddWithValue("@subtotal", subtotal);
                                    if (item.ExecuteNonQuery() < 2) throw new InvalidOperationException("Seat availability changed during checkout. Please try again.");
                                }
                            }
                            using (SqlCommand clear = new SqlCommand("DELETE Cart WHERE StudentId=@student", connection, transaction)) { clear.Parameters.AddWithValue("@student", student.UserId); clear.ExecuteNonQuery(); }
                            transaction.Commit();
                        }
                        catch { transaction.Rollback(); throw; }
                    }
                }

                PaymentCompleted = true;
                StringBuilder invoice = new StringBuilder();
                invoice.AppendLine("Payment successful"); invoice.AppendLine(); invoice.AppendLine("Invoice / Order: #" + OrderId); invoice.AppendLine("Customer: " + student.FullName); invoice.AppendLine("Method: " + paymentMethod.Text); invoice.AppendLine("Reference: " + reference); invoice.AppendLine("Date: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt")); invoice.AppendLine();
                foreach (DataRow row in items.Rows) invoice.AppendLine(row["Title"] + " x" + row["Quantity"] + " = " + Ui.Money(Convert.ToDecimal(row["FinalUnitPrice"]) * Convert.ToInt32(row["Quantity"])));
                invoice.AppendLine(); invoice.AppendLine("TOTAL: " + Ui.Money(finalTotal));
                MessageBox.Show(invoice.ToString(), "SkillBazaar Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void ShowError(Exception ex) { MessageBox.Show("Checkout could not be completed. No payment was recorded.\n\n" + ex.Message, "SkillBazaar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
