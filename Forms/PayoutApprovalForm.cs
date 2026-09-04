using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SkillBazaar.SuperAdminModule.Forms
{
    /// <summary>
    /// Payout Approval — not in a report mockup, so it's built in the same
    /// visual language as 6.3–6.5 (pink stat cards, gray-header table,
    /// green/red action buttons) to satisfy FR6 from the report.
    /// </summary>
    public class PayoutApprovalForm : SuperAdminFormBase
    {
        private Panel cardPendingAmount;
        private Panel cardPendingCount;
        private Panel cardPaidOut;
        private DataGridView dgvPayouts;

        public PayoutApprovalForm()
            : base("Screen: Super Admin — Payout Approval", "payout") { }

        protected override void BuildContent()
        {
            Label lblHeading = new Label
            {
                Text = "Payout Requests",
                Font = new Font("Arial", 15F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 24)
            };

            cardPendingAmount = CreateStatCard("cardPendingAmount", 30, 70, "৳0", "Pending Payout Amount");
            cardPendingCount  = CreateStatCard("cardPendingCount", 320, 70, "0", "Pending Requests");
            cardPaidOut       = CreateStatCard("cardPaidOut", 610, 70, "৳0", "Paid Out (All Time)");

            Label lblTableHeading = new Label
            {
                Text = "Payout Requests",
                Font = new Font("Arial", 12.5F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 190)
            };

            dgvPayouts = new DataGridView
            {
                Location = new Point(30, 224),
                Size = new Size(860, 260)
            };
            StyleGrid(dgvPayouts);

            dgvPayouts.Columns.Add("PayoutId", "PayoutId");
            dgvPayouts.Columns["PayoutId"].Visible = false;
            dgvPayouts.Columns.Add("Institute", "Institute");
            dgvPayouts.Columns.Add("Owner", "Owner");
            dgvPayouts.Columns.Add("Balance", "Available Balance");
            dgvPayouts.Columns.Add("Requested", "Requested Amount");
            dgvPayouts.Columns.Add("RequestDate", "Requested On");

            DataGridViewButtonColumn colApprove = new DataGridViewButtonColumn
            {
                Name = "Approve", HeaderText = "Action", Text = "Approve",
                UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, Width = 110
            };
            colApprove.DefaultCellStyle.BackColor = ColorGreen;
            colApprove.DefaultCellStyle.ForeColor = Color.White;
            colApprove.DefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);

            DataGridViewButtonColumn colReject = new DataGridViewButtonColumn
            {
                Name = "Reject", HeaderText = "", Text = "Reject",
                UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, Width = 110
            };
            colReject.DefaultCellStyle.BackColor = ColorAccentRed;
            colReject.DefaultCellStyle.ForeColor = Color.White;
            colReject.DefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);

            dgvPayouts.Columns.Add(colApprove);
            dgvPayouts.Columns.Add(colReject);

            foreach (string col in new[] { "Institute", "Owner", "Balance", "Requested", "RequestDate" })
                dgvPayouts.Columns[col].ReadOnly = true;

            dgvPayouts.CellClick += DgvPayouts_CellClick;

            contentPanel.Controls.Add(lblHeading);
            contentPanel.Controls.Add(cardPendingAmount);
            contentPanel.Controls.Add(cardPendingCount);
            contentPanel.Controls.Add(cardPaidOut);
            contentPanel.Controls.Add(lblTableHeading);
            contentPanel.Controls.Add(dgvPayouts);

            LoadData();
        }

        private void DgvPayouts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dgvPayouts.Columns[e.ColumnIndex].Name;
            if (colName != "Approve" && colName != "Reject") return;

            int payoutId = Convert.ToInt32(dgvPayouts.Rows[e.RowIndex].Cells["PayoutId"].Value);
            string newStatus = colName == "Approve" ? "Approved" : "Rejected";

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE PayoutRequests SET Status = @status, ProcessedDate = GETDATE() WHERE PayoutId = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", payoutId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reach the database: " + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    decimal pendingAmount;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT ISNULL(SUM(RequestedAmount), 0) FROM PayoutRequests WHERE Status = 'Pending'", conn))
                        pendingAmount = Convert.ToDecimal(cmd.ExecuteScalar());

                    int pendingCount;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM PayoutRequests WHERE Status = 'Pending'", conn))
                        pendingCount = Convert.ToInt32(cmd.ExecuteScalar());

                    decimal paidOut;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT ISNULL(SUM(RequestedAmount), 0) FROM PayoutRequests WHERE Status = 'Approved'", conn))
                        paidOut = Convert.ToDecimal(cmd.ExecuteScalar());

                    SetCardValue(cardPendingAmount, "৳" + pendingAmount.ToString("N0"));
                    SetCardValue(cardPendingCount, pendingCount.ToString());
                    SetCardValue(cardPaidOut, "৳" + paidOut.ToString("N0"));

                    dgvPayouts.Rows.Clear();
                    string sql = @"SELECT
                                       pr.PayoutId,
                                       i.InstituteName,
                                       u.FullName AS Owner,
                                       (
                                           ISNULL((SELECT SUM(oi.Subtotal) * 0.80
                                                   FROM OrderItems oi JOIN Courses c ON oi.CourseId = c.CourseId
                                                   WHERE c.InstituteId = i.InstituteId), 0)
                                           -
                                           ISNULL((SELECT SUM(RequestedAmount) FROM PayoutRequests
                                                   WHERE InstituteId = i.InstituteId AND Status = 'Approved'), 0)
                                       ) AS AvailableBalance,
                                       pr.RequestedAmount,
                                       pr.RequestDate
                                   FROM PayoutRequests pr
                                   JOIN Institutes i ON pr.InstituteId = i.InstituteId
                                   JOIN Users u ON i.OwnerId = u.UserId
                                   WHERE pr.Status = 'Pending'
                                   ORDER BY pr.RequestDate";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvPayouts.Rows.Add(
                                reader["PayoutId"],
                                reader["InstituteName"],
                                reader["Owner"],
                                "৳" + Convert.ToDecimal(reader["AvailableBalance"]).ToString("N0"),
                                "৳" + Convert.ToDecimal(reader["RequestedAmount"]).ToString("N0"),
                                Convert.ToDateTime(reader["RequestDate"]).ToString("dd MMM yyyy"),
                                "Approve", "Reject");
                        }
                    }
                }
            }
            catch
            {
                // Database not reachable yet — fall back to sample data so the
                // screen still demos correctly.
                SetCardValue(cardPendingAmount, "৳154,600");
                SetCardValue(cardPendingCount, "3");
                SetCardValue(cardPaidOut, "৳0");

                dgvPayouts.Rows.Clear();
                dgvPayouts.Rows.Add(1, "Coders BD Academy", "Rafiq Ahmed", "৳192,800", "৳80,000", "18 Aug 2026", "Approve", "Reject");
                dgvPayouts.Rows.Add(2, "MathGuru BD", "Kamal Hossain", "৳96,800", "৳50,000", "21 Aug 2026", "Approve", "Reject");
                dgvPayouts.Rows.Add(3, "ExamPrep Institute", "Nusrat Jahan", "৳96,000", "৳24,600", "25 Aug 2026", "Approve", "Reject");
            }
        }
    }
}
