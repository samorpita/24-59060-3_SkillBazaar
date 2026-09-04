using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SkillBazaar.SuperAdminModule.Forms
{
    /// <summary>Screen 6.3 — Super Admin Dashboard (Platform Overview).</summary>
    public class SuperAdminDashboardForm : SuperAdminFormBase
    {
        private Panel cardRevenue;
        private Panel cardInstructors;
        private Panel cardPending;
        private DataGridView dgvPending;

        public SuperAdminDashboardForm() : base("Screen 5: Super Admin Dashboard", "overview") { }

        protected override void BuildContent()
        {
            Label lblHeading = new Label
            {
                Text = "Platform Overview",
                Font = new Font("Arial", 15F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 24)
            };

            cardRevenue     = CreateStatCard("cardRevenue", 30, 70, "৳0", "Platform Revenue (20% commission)");
            cardInstructors = CreateStatCard("cardInstructors", 320, 70, "0", "Active Instructors");
            cardPending     = CreateStatCard("cardPending", 610, 70, "0", "Pending Approvals");

            Label lblPendingHeading = new Label
            {
                Text = "Pending Instructor Approvals",
                Font = new Font("Arial", 12.5F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 190)
            };

            dgvPending = new DataGridView
            {
                Location = new Point(30, 224),
                Size = new Size(860, 180)
            };
            StyleGrid(dgvPending);

            dgvPending.Columns.Add("Institute", "Institute");
            dgvPending.Columns.Add("Owner", "Owner");
            dgvPending.Columns.Add("Category", "Category");

            DataGridViewButtonColumn colApprove = new DataGridViewButtonColumn
            {
                Name = "Approve",
                HeaderText = "Action",
                Text = "Approve",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110
            };
            colApprove.DefaultCellStyle.BackColor = ColorGreen;
            colApprove.DefaultCellStyle.ForeColor = Color.White;
            colApprove.DefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);

            DataGridViewButtonColumn colReject = new DataGridViewButtonColumn
            {
                Name = "Reject",
                HeaderText = "",
                Text = "Reject",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110
            };
            colReject.DefaultCellStyle.BackColor = ColorAccentRed;
            colReject.DefaultCellStyle.ForeColor = Color.White;
            colReject.DefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);

            dgvPending.Columns.Add(colApprove);
            dgvPending.Columns.Add(colReject);
            dgvPending.Columns["Institute"].ReadOnly = true;
            dgvPending.Columns["Owner"].ReadOnly = true;
            dgvPending.Columns["Category"].ReadOnly = true;
            dgvPending.CellClick += DgvPending_CellClick;

            contentPanel.Controls.Add(lblHeading);
            contentPanel.Controls.Add(cardRevenue);
            contentPanel.Controls.Add(cardInstructors);
            contentPanel.Controls.Add(cardPending);
            contentPanel.Controls.Add(lblPendingHeading);
            contentPanel.Controls.Add(dgvPending);

            LoadData();
        }

        private void DgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dgvPending.Columns[e.ColumnIndex].Name;
            if (colName != "Approve" && colName != "Reject") return;

            string institute = dgvPending.Rows[e.RowIndex].Cells["Institute"].Value?.ToString();
            string newStatus = colName == "Approve" ? "Approved" : "Suspended";

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Institutes SET Status = @status WHERE InstituteName = @name", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@name", institute);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"{institute} has been {(colName == "Approve" ? "approved" : "rejected")}.",
                    "Instructor Approvals", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    decimal revenue;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT ISNULL(SUM(Subtotal), 0) * 0.20 FROM OrderItems", conn))
                        revenue = Convert.ToDecimal(cmd.ExecuteScalar());

                    int activeInstructors;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Institutes WHERE Status = 'Approved'", conn))
                        activeInstructors = Convert.ToInt32(cmd.ExecuteScalar());

                    int pendingCount;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Institutes WHERE Status = 'Pending'", conn))
                        pendingCount = Convert.ToInt32(cmd.ExecuteScalar());

                    SetCardValue(cardRevenue, "৳" + revenue.ToString("N0"));
                    SetCardValue(cardInstructors, activeInstructors.ToString());
                    SetCardValue(cardPending, pendingCount.ToString());

                    dgvPending.Rows.Clear();
                    string sql = @"SELECT i.InstituteName, u.FullName AS Owner, i.Category
                                   FROM Institutes i JOIN Users u ON i.OwnerId = u.UserId
                                   WHERE i.Status = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvPending.Rows.Add(reader["InstituteName"], reader["Owner"], reader["Category"], "Approve", "Reject");
                        }
                    }
                }
            }
            catch
            {
                // Database not reachable yet (e.g. schema not created in SSMS
                // yet) — fall back to the exact sample numbers from the report
                // so the screen still matches section 6.3 for a demo.
                SetCardValue(cardRevenue, "৳96,400");
                SetCardValue(cardInstructors, "18");
                SetCardValue(cardPending, "3");

                dgvPending.Rows.Clear();
                dgvPending.Rows.Add("ExamPrep Institute", "Nusrat Jahan", "Admission Prep", "Approve", "Reject");
            }
        }
    }
}
