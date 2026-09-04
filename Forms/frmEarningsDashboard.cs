using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Classes;

namespace SkillBazaar.Forms
{
    public partial class frmEarningsDashboard : Form
    {
        private InstructorManager instructorManager;
        private PayoutManager payoutManager;

        public frmEarningsDashboard(InstructorManager manager)
        {
            InitializeComponent();
            instructorManager = manager;
            payoutManager = new PayoutManager(manager.InstructorID);

            SetupDataGridViews();
            LoadEarningsDashboard();

            // Wire up event handlers
            this.btnRequestPayout.Click += new EventHandler(this.btnRequestPayout_Click);
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.txtPayoutAmount.TextChanged += new EventHandler(this.txtPayoutAmount_TextChanged);
        }

        private void SetupDataGridViews()
        {
            // Configure Course Earnings Grid
            dgvCourseEarnings.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCourseEarnings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCourseEarnings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvCourseEarnings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCourseEarnings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvCourseEarnings.RowTemplate.Height = 35;
            dgvCourseEarnings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvCourseEarnings.DefaultCellStyle.SelectionForeColor = Color.White;

            // Configure Payout History Grid
            dgvPayoutHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvPayoutHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPayoutHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvPayoutHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayoutHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvPayoutHistory.RowTemplate.Height = 35;
            dgvPayoutHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvPayoutHistory.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadEarningsDashboard()
        {
            try
            {
                lblStatus.Text = "⏳ Loading earnings data...";

                // Load earnings summary
                DataTable dtEarnings = payoutManager.GetEarningsSummary();
                if (dtEarnings != null && dtEarnings.Rows.Count > 0)
                {
                    DataRow row = dtEarnings.Rows[0];
                    decimal totalEarnings = Convert.ToDecimal(row["TotalEarnings"]);
                    decimal availableBalance = Convert.ToDecimal(row["AvailableBalance"]);
                    decimal platformFee = Convert.ToDecimal(row["PlatformFee"]);

                    lblTotalEarningsValue.Text = "৳ " + totalEarnings.ToString("N0");
                    lblAvailableBalanceValue.Text = "৳ " + availableBalance.ToString("N0");
                    lblPlatformFeeValue.Text = "৳ " + platformFee.ToString("N0");
                }
                else
                {
                    lblTotalEarningsValue.Text = "৳ 0";
                    lblAvailableBalanceValue.Text = "৳ 0";
                    lblPlatformFeeValue.Text = "৳ 0";
                }

                // Load course earnings
                DataTable dtCourseEarnings = payoutManager.GetCourseEarnings();
                if (dtCourseEarnings != null && dtCourseEarnings.Rows.Count > 0)
                {
                    dgvCourseEarnings.DataSource = dtCourseEarnings;

                    if (dgvCourseEarnings.Columns["CourseName"] != null)
                        dgvCourseEarnings.Columns["CourseName"].HeaderText = "📚 Course";
                    if (dgvCourseEarnings.Columns["Enrollments"] != null)
                        dgvCourseEarnings.Columns["Enrollments"].HeaderText = "👨‍🎓 Students";
                    if (dgvCourseEarnings.Columns["TotalEarnings"] != null)
                        dgvCourseEarnings.Columns["TotalEarnings"].HeaderText = "💰 Total (৳)";
                    if (dgvCourseEarnings.Columns["InstructorEarnings"] != null)
                        dgvCourseEarnings.Columns["InstructorEarnings"].HeaderText = "👨‍🏫 Instructor (৳)";
                    if (dgvCourseEarnings.Columns["PlatformFee"] != null)
                        dgvCourseEarnings.Columns["PlatformFee"].HeaderText = "📊 Fee (৳)";
                }

                // Load payout history
                DataTable dtPayouts = payoutManager.GetPayoutHistory();
                if (dtPayouts != null && dtPayouts.Rows.Count > 0)
                {
                    dgvPayoutHistory.DataSource = dtPayouts;

                    if (dgvPayoutHistory.Columns["PayoutID"] != null)
                        dgvPayoutHistory.Columns["PayoutID"].Visible = false;
                    if (dgvPayoutHistory.Columns["Amount"] != null)
                        dgvPayoutHistory.Columns["Amount"].HeaderText = "💰 Amount (৳)";
                    if (dgvPayoutHistory.Columns["PayoutDate"] != null)
                        dgvPayoutHistory.Columns["PayoutDate"].HeaderText = "📅 Date";
                    if (dgvPayoutHistory.Columns["Status"] != null)
                    {
                        dgvPayoutHistory.Columns["Status"].HeaderText = "📊 Status";
                        dgvPayoutHistory.CellFormatting += (sender, e) =>
                        {
                            if (e.ColumnIndex == dgvPayoutHistory.Columns["Status"].Index && e.RowIndex >= 0)
                            {
                                string status = dgvPayoutHistory.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                                if (status == "Pending")
                                {
                                    e.CellStyle.ForeColor = Color.Orange;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                                }
                                else if (status == "Completed")
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.BackColor = Color.FromArgb(232, 245, 233);
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                }
                            }
                        };
                    }
                }

                // Update max amount label
                UpdateMaxAmountLabel();
                lblStatus.Text = "✅ Data loaded successfully.";
                lblLastUpdate.Text = $"🔄 Last updated: {DateTime.Now:hh:mm tt}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Error loading data: " + ex.Message;
                MessageBox.Show("Error loading earnings data:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMaxAmountLabel()
        {
            try
            {
                decimal availableBalance = payoutManager.GetAvailableBalance();
                lblMaxAmount.Text = $"Max: ৳ {availableBalance:N0}";
            }
            catch
            {
                lblMaxAmount.Text = "Max: ৳ 0";
            }
        }

        private void btnRequestPayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPayoutAmount.Text))
                {
                    MessageBox.Show("Please enter an amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPayoutAmount.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPayoutAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid amount (greater than 0).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPayoutAmount.Focus();
                    return;
                }

                decimal availableBalance = payoutManager.GetAvailableBalance();
                if (amount > availableBalance)
                {
                    MessageBox.Show($"Amount cannot exceed available balance of ৳{availableBalance:N0}.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPayoutAmount.Focus();
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure you want to request a payout of ৳{amount:N0}?",
                    "Confirm Payout Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (payoutManager.RequestPayout(amount))
                    {
                        MessageBox.Show("Payout request submitted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPayoutAmount.Clear();
                        LoadEarningsDashboard();
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit payout request. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error requesting payout: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPayoutAmount_TextChanged(object sender, EventArgs e)
        {
            // Optional: Validate amount as user types
            // This method is intentionally left for future validation logic
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reload the dashboard data
            LoadEarningsDashboard();

            // Update button text to show refresh confirmation
            btnRefresh.Text = "✅ Refreshed!";
            btnRefresh.BackColor = Color.FromArgb(46, 204, 113);

            // Create timer to reset button text after 2 seconds
            Timer timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            timer.Tick += (s, ev) =>
            {
                btnRefresh.Text = "🔄 Refresh Data";
                btnRefresh.BackColor = Color.FromArgb(52, 73, 94);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
