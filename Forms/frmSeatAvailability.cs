using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Classes;
using System.Linq;

namespace SkillBazaar.Forms
{
    public partial class frmSeatAvailability : Form
    {
        private InstructorManager instructorManager;
        private CourseManager courseManager;
        private DataTable seatData;

        public frmSeatAvailability(InstructorManager manager)
        {
            InitializeComponent();
            instructorManager = manager;
            courseManager = new CourseManager(manager.InstructorID);
            LoadSeatAvailability();
            SetupDataGridView();
        }

        private void frmSeatAvailability_Load(object sender, EventArgs e)
        {
            // Additional load logic if needed
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView appearance
            dgvSeats.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvSeats.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSeats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvSeats.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSeats.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvSeats.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvSeats.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSeats.RowTemplate.Height = 35;
        }

        private void LoadSeatAvailability()
        {
            try
            {
                // Clear existing data
                dgvSeats.DataSource = null;

                // Get seat availability data
                DataTable dt = courseManager.GetSeatAvailability();

                if (dt != null && dt.Rows.Count > 0)
                {
                    seatData = dt;
                    dgvSeats.DataSource = dt;

                    // Rename and format columns
                    if (dgvSeats.Columns["CourseID"] != null)
                        dgvSeats.Columns["CourseID"].Visible = false;

                    if (dgvSeats.Columns["Title"] != null)
                    {
                        dgvSeats.Columns["Title"].HeaderText = "Course Name";
                        dgvSeats.Columns["Title"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }

                    if (dgvSeats.Columns["TotalSeats"] != null)
                        dgvSeats.Columns["TotalSeats"].HeaderText = "Total Seats";

                    if (dgvSeats.Columns["AvailableSeats"] != null)
                        dgvSeats.Columns["AvailableSeats"].HeaderText = "Available";

                    if (dgvSeats.Columns["MinThreshold"] != null)
                        dgvSeats.Columns["MinThreshold"].HeaderText = "Min Threshold";

                    if (dgvSeats.Columns["Status"] != null)
                    {
                        dgvSeats.Columns["Status"].HeaderText = "Status";
                        // Add color coding for status
                        dgvSeats.CellFormatting += (sender, e) =>
                        {
                            if (e.ColumnIndex == dgvSeats.Columns["Status"].Index && e.RowIndex >= 0)
                            {
                                string status = dgvSeats.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                                if (status == "LOW SEATS")
                                {
                                    e.CellStyle.ForeColor = Color.Orange;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                                else if (status == "CRITICAL")
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.BackColor = Color.FromArgb(232, 245, 233);
                                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                            }
                        };
                    }

                    // Update statistics
                    UpdateStatistics(dt);
                    ShowWarningIfNeeded(dt);
                }
                else
                {
                    // No data found - show empty state
                    ShowEmptyState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading seat availability:\n\n{ex.Message}\n\nPlease check your database connection.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(DataTable dt)
        {
            try
            {
                // Total courses
                lblTotalCoursesValue.Text = dt.Rows.Count.ToString();

                // Count low seat courses
                int lowSeatCount = dt.AsEnumerable()
                    .Count(row => row["Status"].ToString() == "LOW SEATS");
                lblLowSeatsValue.Text = lowSeatCount.ToString();

                // Count critical seat courses
                int criticalCount = dt.AsEnumerable()
                    .Count(row => row["Status"].ToString() == "CRITICAL");
                lblCriticalSeatsValue.Text = criticalCount.ToString();

                // Total available seats
                int totalAvailable = dt.AsEnumerable()
                    .Sum(row => Convert.ToInt32(row["AvailableSeats"]));
                lblAvailableSeatsValue.Text = totalAvailable.ToString();
            }
            catch (Exception ex)
            {
                // If statistics calculation fails, just show zeros
                lblTotalCoursesValue.Text = "0";
                lblLowSeatsValue.Text = "0";
                lblCriticalSeatsValue.Text = "0";
                lblAvailableSeatsValue.Text = "0";
            }
        }

        private void ShowWarningIfNeeded(DataTable dt)
        {
            try
            {
                int lowSeatCount = dt.AsEnumerable()
                    .Count(row => row["Status"].ToString() == "LOW SEATS" || row["Status"].ToString() == "CRITICAL");

                if (lowSeatCount > 0)
                {
                    lblWarning.Text = $"{lowSeatCount} course{(lowSeatCount > 1 ? "s are" : " is")} below its minimum seat threshold. Consider increasing capacity.";
                    pnlWarning.Visible = true;
                    pnlWarning.BringToFront();
                }
                else
                {
                    pnlWarning.Visible = false;
                }
            }
            catch
            {
                pnlWarning.Visible = false;
            }
        }

        private void ShowEmptyState()
        {
            // Clear the grid
            dgvSeats.DataSource = null;

            // Show empty state message
            Label lblNoData = new Label();
            lblNoData.Text = "📚 No courses found.\n\nAdd your first course to start tracking seat availability.";
            lblNoData.Font = new Font("Segoe UI", 12F);
            lblNoData.ForeColor = Color.Gray;
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Location = new Point(30, 300);
            lblNoData.Size = new Size(880, 100);
            lblNoData.Name = "lblNoData";

            // Check if label already exists before adding
            if (!pnlContent.Controls.ContainsKey("lblNoData"))
            {
                pnlContent.Controls.Add(lblNoData);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Remove empty state label if it exists
            if (pnlContent.Controls.ContainsKey("lblNoData"))
            {
                pnlContent.Controls.RemoveByKey("lblNoData");
            }

            // Reload data
            LoadSeatAvailability();

            // Show refresh confirmation
            btnRefresh.Text = "✅ Refreshed!";
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, ev) =>
            {
                btnRefresh.Text = "🔄 Refresh Data";
                timer.Stop();
            };
            timer.Start();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSeats.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a summary message
                string summary = "SEAT AVAILABILITY REPORT\n";
                summary += "================================\n\n";
                summary += $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n";
                summary += $"Total Courses: {lblTotalCoursesValue.Text}\n";
                summary += $"Low Seat Courses: {lblLowSeatsValue.Text}\n";
                summary += $"Critical Seat Courses: {lblCriticalSeatsValue.Text}\n";
                summary += $"Total Available Seats: {lblAvailableSeatsValue.Text}\n\n";
                summary += "================================\n\n";

                // Add course details
                summary += "COURSE DETAILS:\n";
                summary += "--------------------------------\n";

                foreach (DataRow row in seatData.Rows)
                {
                    summary += $"Course: {row["Title"]}\n";
                    summary += $"Total Seats: {row["TotalSeats"]}\n";
                    summary += $"Available: {row["AvailableSeats"]}\n";
                    summary += $"Min Threshold: {row["MinThreshold"]}\n";
                    summary += $"Status: {row["Status"]}\n";
                    summary += "--------------------------------\n";
                }

                // Show export options
                DialogResult result = MessageBox.Show(
                    "Do you want to copy the report to clipboard?\n\nClick 'Yes' to copy.\nClick 'No' to view in a message box.",
                    "Export Options",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(summary);
                    MessageBox.Show("Report copied to clipboard successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show(summary, "Seat Availability Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSeats_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvSeats.Rows.Count)
                {
                    string courseName = dgvSeats.Rows[e.RowIndex].Cells["Title"].Value?.ToString() ?? "Course";
                    MessageBox.Show($"Course: {courseName}\n\nDouble-click to view details.\n(Feature coming soon)",
                        "Course Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Silent fail on double-click
            }
        }
    }
}