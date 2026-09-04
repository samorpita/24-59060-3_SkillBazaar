using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Classes;

namespace SkillBazaar.Forms
{
    public partial class frmInstructorDashboard : Form
    {
        private InstructorManager instructorManager;
        private CourseManager courseManager;

        public frmInstructorDashboard()
        {
            InitializeComponent();
            instructorManager = new InstructorManager(1, "Rafiq");
            courseManager = new CourseManager(instructorManager.InstructorID);

            lblInstructorName.Text = instructorManager.Username;
            lblDate.Text = $"📅 {DateTime.Now:MMM dd, yyyy}";

            LoadDashboard();
            HighlightButton(btnDashboard);
            ShowDashboardPanel();

            // Wire up events for Dashboard
            btnDashboard.Click += new EventHandler(btnDashboard_Click);
            btnMyCourses.Click += new EventHandler(btnMyCourses_Click);
            btnSeatAvailability.Click += new EventHandler(btnSeatAvailability_Click);
            btnStudents.Click += new EventHandler(btnStudents_Click);
            btnEarnings.Click += new EventHandler(btnEarnings_Click);
            btnReviews.Click += new EventHandler(btnReviews_Click);
            btnAddCourse.Click += new EventHandler(btnAddCourse_Click);
            btnRequestPayout.Click += new EventHandler(btnRequestPayout_Click);
            btnViewAllCourses.Click += new EventHandler(btnViewAllCourses_Click);
            btnLogout.Click += new EventHandler(btnLogout_Click);

            // Wire up events for My Courses Panel
            btnMyCoursesSearch.Click += new EventHandler(btnMyCoursesSearch_Click);
            btnMyCoursesAdd.Click += new EventHandler(btnMyCoursesAdd_Click);
            btnMyCoursesRefresh.Click += new EventHandler(btnMyCoursesRefresh_Click);
            btnMyCoursesSave.Click += new EventHandler(btnMyCoursesSave_Click);
            btnMyCoursesCancel.Click += new EventHandler(btnMyCoursesCancel_Click);
            txtMyCoursesSearch.TextChanged += new EventHandler(txtMyCoursesSearch_TextChanged);
            cmbMyCoursesCategory.SelectedIndexChanged += new EventHandler(cmbMyCoursesCategory_SelectedIndexChanged);
            dgvMyCourses.CellClick += new DataGridViewCellEventHandler(dgvMyCourses_CellClick);

            // Wire up events for Seat Availability Panel
            btnSeatRefresh.Click += new EventHandler(btnSeatRefresh_Click);

            // Wire up events for Earnings Panel
            btnEarningsRefresh.Click += new EventHandler(btnEarningsRefresh_Click);
            btnEarningsPayoutRequest.Click += new EventHandler(btnEarningsPayoutRequest_Click);
        }

        // ============================================================
        // PANEL VISIBILITY METHODS
        // ============================================================

        private void ShowDashboardPanel()
        {
            pnlDashboard.Visible = true;
            pnlMyCourses.Visible = false;
            pnlSeatAvailability.Visible = false;
            pnlEarnings.Visible = false;
            pnlStudents.Visible = false;
            pnlReviews.Visible = false;
            pnlDashboard.BringToFront();
            lblStatus.Text = "✅ Dashboard loaded successfully";
        }

        private void ShowMyCoursesPanel()
        {
            pnlDashboard.Visible = false;
            pnlMyCourses.Visible = true;
            pnlSeatAvailability.Visible = false;
            pnlEarnings.Visible = false;
            pnlStudents.Visible = false;
            pnlReviews.Visible = false;
            pnlMyCourses.BringToFront();
            LoadMyCourses();
            lblStatus.Text = "📚 My Courses loaded";
        }

        private void ShowSeatAvailabilityPanel()
        {
            pnlDashboard.Visible = false;
            pnlMyCourses.Visible = false;
            pnlSeatAvailability.Visible = true;
            pnlEarnings.Visible = false;
            pnlStudents.Visible = false;
            pnlReviews.Visible = false;
            pnlSeatAvailability.BringToFront();
            LoadSeatAvailability();
            lblStatus.Text = "💺 Seat Availability loaded";
        }

        private void ShowEarningsPanel()
        {
            pnlDashboard.Visible = false;
            pnlMyCourses.Visible = false;
            pnlSeatAvailability.Visible = false;
            pnlEarnings.Visible = true;
            pnlStudents.Visible = false;
            pnlReviews.Visible = false;
            pnlEarnings.BringToFront();
            LoadEarningsData();
            lblStatus.Text = "💰 Earnings & Payout loaded";
        }

        private void ShowStudentsPanel()
        {
            pnlDashboard.Visible = false;
            pnlMyCourses.Visible = false;
            pnlSeatAvailability.Visible = false;
            pnlEarnings.Visible = false;
            pnlStudents.Visible = true;
            pnlReviews.Visible = false;
            pnlStudents.BringToFront();
            LoadStudentsData();
            lblStatus.Text = "👨‍🎓 Student management loaded";
        }

        private void ShowReviewsPanel()
        {
            pnlDashboard.Visible = false;
            pnlMyCourses.Visible = false;
            pnlSeatAvailability.Visible = false;
            pnlEarnings.Visible = false;
            pnlStudents.Visible = false;
            pnlReviews.Visible = true;
            pnlReviews.BringToFront();
            LoadReviewsData();
            lblStatus.Text = "⭐ Reviews and ratings loaded";
        }

        // ============================================================
        // DASHBOARD LOAD METHODS
        // ============================================================

        private void LoadDashboard()
        {
            try
            {
                lblStatus.Text = "⏳ Loading dashboard data...";

                DataSet ds = instructorManager.GetDashboardData();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        lblCourseCount.Text = ds.Tables[0].Rows[0][0].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                        lblEnrollmentCount.Text = ds.Tables[1].Rows[0][0].ToString();

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        decimal availableBalance = Convert.ToDecimal(ds.Tables[2].Rows[0][1]);
                        lblBalance.Text = "৳ " + availableBalance.ToString("N0");
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        decimal avgRating = Convert.ToDecimal(ds.Tables[3].Rows[0][0]);
                        lblAvgRating.Text = avgRating.ToString("0.0");
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[4];
                        dgvDashboardCourses.DataSource = dt;

                        if (dgvDashboardCourses.Columns["CourseID"] != null)
                            dgvDashboardCourses.Columns["CourseID"].Visible = false;

                        if (dgvDashboardCourses.Columns["Title"] != null)
                        {
                            dgvDashboardCourses.Columns["Title"].HeaderText = "📚 Course";
                            dgvDashboardCourses.Columns["Title"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }

                        if (dgvDashboardCourses.Columns["Price"] != null)
                        {
                            dgvDashboardCourses.Columns["Price"].HeaderText = "💰 Price (৳)";
                            dgvDashboardCourses.Columns["Price"].DefaultCellStyle.Format = "N0";
                            dgvDashboardCourses.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }

                        if (dgvDashboardCourses.Columns["TotalSeats"] != null)
                            dgvDashboardCourses.Columns["TotalSeats"].HeaderText = "🎯 Total Seats";

                        if (dgvDashboardCourses.Columns["SeatsLeft"] != null)
                            dgvDashboardCourses.Columns["SeatsLeft"].HeaderText = "🪑 Seats Left";

                        if (dgvDashboardCourses.Columns["Enrolled"] != null)
                            dgvDashboardCourses.Columns["Enrolled"].HeaderText = "👨‍🎓 Enrolled";

                        if (dgvDashboardCourses.Columns["SeatStatus"] != null)
                        {
                            dgvDashboardCourses.Columns["SeatStatus"].HeaderText = "📊 Status";
                            dgvDashboardCourses.CellFormatting += (sender, e) =>
                            {
                                if (e.ColumnIndex == dgvDashboardCourses.Columns["SeatStatus"].Index && e.RowIndex >= 0)
                                {
                                    string status = dgvDashboardCourses.Rows[e.RowIndex].Cells["SeatStatus"].Value?.ToString();
                                    if (status == "LOW SEATS")
                                    {
                                        e.CellStyle.ForeColor = Color.Orange;
                                        e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                                    }
                                    else if (status == "CRITICAL")
                                    {
                                        e.CellStyle.ForeColor = Color.Red;
                                        e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                    }
                                    else
                                    {
                                        e.CellStyle.ForeColor = Color.Green;
                                        e.CellStyle.BackColor = Color.FromArgb(232, 245, 233);
                                    }
                                }
                            };
                        }

                        lblRecordCount.Text = $"📚 Courses: {dt.Rows.Count}";
                    }
                }

                lblStatus.Text = "✅ Dashboard loaded successfully";
                lblLastUpdate.Text = $"🔄 Last updated: {DateTime.Now:hh:mm tt}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Error loading dashboard: " + ex.Message;
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MY COURSES LOAD METHODS
        // ============================================================

        private void LoadMyCourses(string search = null, int? categoryID = null)
        {
            try
            {
                DataTable dt = courseManager.GetCourses(search, categoryID);
                dgvMyCourses.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dgvMyCourses.Columns["CourseID"] != null)
                        dgvMyCourses.Columns["CourseID"].Visible = false;
                    if (dgvMyCourses.Columns["Title"] != null)
                    {
                        dgvMyCourses.Columns["Title"].HeaderText = "📚 Course Title";
                        dgvMyCourses.Columns["Title"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    if (dgvMyCourses.Columns["CategoryName"] != null)
                        dgvMyCourses.Columns["CategoryName"].HeaderText = "📂 Category";
                    if (dgvMyCourses.Columns["Price"] != null)
                    {
                        dgvMyCourses.Columns["Price"].HeaderText = "💰 Price (৳)";
                        dgvMyCourses.Columns["Price"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvMyCourses.Columns["TotalSeats"] != null)
                        dgvMyCourses.Columns["TotalSeats"].HeaderText = "🎯 Total Seats";
                    if (dgvMyCourses.Columns["EnrolledSeats"] != null)
                        dgvMyCourses.Columns["EnrolledSeats"].HeaderText = "👨‍🎓 Enrolled";
                    if (dgvMyCourses.Columns["AvailableSeats"] != null)
                        dgvMyCourses.Columns["AvailableSeats"].HeaderText = "🪑 Available";

                    // Add action buttons
                    if (!dgvMyCourses.Columns.Contains("Edit"))
                    {
                        DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
                        editCol.Name = "Edit";
                        editCol.HeaderText = "Actions";
                        editCol.Text = "✏️ Edit";
                        editCol.UseColumnTextForButtonValue = true;
                        editCol.Width = 80;
                        dgvMyCourses.Columns.Add(editCol);

                        DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
                        deleteCol.Name = "Delete";
                        deleteCol.HeaderText = "";
                        deleteCol.Text = "🗑️ Delete";
                        deleteCol.UseColumnTextForButtonValue = true;
                        deleteCol.Width = 80;
                        dgvMyCourses.Columns.Add(deleteCol);
                    }

                    // Load categories for filter
                    LoadMyCoursesCategories();
                }
                else
                {
                    dgvMyCourses.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyCoursesCategories()
        {
            try
            {
                DataTable categories = courseManager.GetCategories();
                DataTable filterCategories = categories.Copy();
                DataRow row = filterCategories.NewRow();
                row["CategoryID"] = 0;
                row["CategoryName"] = "All Categories";
                filterCategories.Rows.InsertAt(row, 0);

                cmbMyCoursesCategory.DataSource = filterCategories;
                cmbMyCoursesCategory.DisplayMember = "CategoryName";
                cmbMyCoursesCategory.ValueMember = "CategoryID";

                cmbMyCoursesCategoryForm.DataSource = categories.Copy();
                cmbMyCoursesCategoryForm.DisplayMember = "CategoryName";
                cmbMyCoursesCategoryForm.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }

        // ============================================================
        // SEAT AVAILABILITY LOAD METHODS
        // ============================================================

        private void LoadSeatAvailability()
        {
            try
            {
                DataTable dt = courseManager.GetSeatAvailability();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvSeatAvailability.DataSource = dt;

                    if (dgvSeatAvailability.Columns["CourseID"] != null)
                        dgvSeatAvailability.Columns["CourseID"].Visible = false;
                    if (dgvSeatAvailability.Columns["Title"] != null)
                    {
                        dgvSeatAvailability.Columns["Title"].HeaderText = "📚 Course Name";
                        dgvSeatAvailability.Columns["Title"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    if (dgvSeatAvailability.Columns["TotalSeats"] != null)
                        dgvSeatAvailability.Columns["TotalSeats"].HeaderText = "🎯 Total Seats";
                    if (dgvSeatAvailability.Columns["AvailableSeats"] != null)
                        dgvSeatAvailability.Columns["AvailableSeats"].HeaderText = "🪑 Available";
                    if (dgvSeatAvailability.Columns["MinThreshold"] != null)
                        dgvSeatAvailability.Columns["MinThreshold"].HeaderText = "⚠️ Min Threshold";
                    if (dgvSeatAvailability.Columns["Status"] != null)
                    {
                        dgvSeatAvailability.Columns["Status"].HeaderText = "📊 Status";
                        dgvSeatAvailability.CellFormatting += (sender, e) =>
                        {
                            if (e.ColumnIndex == dgvSeatAvailability.Columns["Status"].Index && e.RowIndex >= 0)
                            {
                                string status = dgvSeatAvailability.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                                if (status == "LOW SEATS")
                                {
                                    e.CellStyle.ForeColor = Color.Orange;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                                }
                                else if (status == "CRITICAL")
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.BackColor = Color.FromArgb(232, 245, 233);
                                }
                            }
                        };
                    }

                    // Update statistics
                    UpdateSeatStatistics(dt);
                }
                else
                {
                    dgvSeatAvailability.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seat availability: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSeatStatistics(DataTable dt)
        {
            try
            {
                int totalCourses = dt.Rows.Count;
                int lowSeatCount = 0;
                int criticalCount = 0;
                int totalAvailable = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"].ToString();
                    if (status == "LOW SEATS") lowSeatCount++;
                    if (status == "CRITICAL") criticalCount++;
                    totalAvailable += Convert.ToInt32(row["AvailableSeats"]);
                }

                lblSeatTotalCoursesValue.Text = totalCourses.ToString();
                lblSeatLowValue.Text = lowSeatCount.ToString();
                lblSeatCriticalValue.Text = criticalCount.ToString();
                lblSeatAvailableValue.Text = totalAvailable.ToString();

                if (lowSeatCount > 0 || criticalCount > 0)
                {
                    int totalWarning = lowSeatCount + criticalCount;
                    lblSeatWarning.Text = $"⚠️ {totalWarning} course{(totalWarning > 1 ? "s are" : " is")} below its minimum seat threshold. Consider increasing capacity.";
                    pnlSeatWarning.Visible = true;
                }
                else
                {
                    pnlSeatWarning.Visible = false;
                }
            }
            catch
            {
                // Silent fail
            }
        }

        // ============================================================
        // EARNINGS LOAD METHODS
        // ============================================================

        private void LoadEarningsData()
        {
            try
            {
                // This would connect to your earnings manager
                // For now, showing sample data
                lblEarningsTotalValue.Text = "৳ 13,500";
                lblEarningsBalanceValue.Text = "৳ 10,600";
                lblEarningsFeeValue.Text = "৳ 900";
                lblEarningsStudentsValue.Text = "3";
                lblEarningsMaxAmount.Text = "Max: ৳ 7,600";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading earnings: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // STUDENTS LOAD METHODS
        // ============================================================

        private void LoadStudentsData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("StudentID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Course", typeof(string));
                dt.Columns.Add("EnrolledDate", typeof(string));
                dt.Columns.Add("Status", typeof(string));

                dt.Rows.Add(1, "Samorpita Islam", "samu23@gmail.com", "C# OOP Fundamentals", "2026-08-15", "Active");
                dt.Rows.Add(2, "Lamia Azad", "lamuuu@gmail.com", "Full Stack Web Dev", "2026-08-20", "Active");
                dt.Rows.Add(3, "Jahidul Risan", "risan420@gmail.com", "Data Structures in C#", "2026-08-25", "Active");

                lblTotalStudentsValue.Text = dt.Rows.Count.ToString();
                lblActiveStudentsValue.Text = "3";
                lblNewStudentsValue.Text = "0";

                dgvStudents.DataSource = dt;

                if (dgvStudents.Columns["StudentID"] != null)
                    dgvStudents.Columns["StudentID"].Visible = false;
                if (dgvStudents.Columns["Name"] != null)
                    dgvStudents.Columns["Name"].HeaderText = "👤 Student Name";
                if (dgvStudents.Columns["Email"] != null)
                    dgvStudents.Columns["Email"].HeaderText = "📧 Email";
                if (dgvStudents.Columns["Course"] != null)
                    dgvStudents.Columns["Course"].HeaderText = "📚 Course";
                if (dgvStudents.Columns["EnrolledDate"] != null)
                    dgvStudents.Columns["EnrolledDate"].HeaderText = "📅 Enrolled Date";
                if (dgvStudents.Columns["Status"] != null)
                    dgvStudents.Columns["Status"].HeaderText = "📊 Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REVIEWS LOAD METHODS
        // ============================================================

        private void LoadReviewsData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ReviewID", typeof(int));
                dt.Columns.Add("Course", typeof(string));
                dt.Columns.Add("Student", typeof(string));
                dt.Columns.Add("Rating", typeof(string));
                dt.Columns.Add("Comment", typeof(string));
                dt.Columns.Add("Date", typeof(string));

                dt.Rows.Add(1, "C# OOP Fundamentals", "Samorpita Islam", "⭐⭐⭐⭐⭐", "Excellent course!", "2026-08-28");
                dt.Rows.Add(2, "Full Stack Web Dev", "Lamia Azad", "⭐⭐⭐⭐", "Very informative", "2026-08-27");

                lblTotalReviewsValue.Text = dt.Rows.Count.ToString();
                lblAverageRatingValue.Text = "4.5";
                lblFiveStarValue.Text = "1";

                dgvReviews.DataSource = dt;

                if (dgvReviews.Columns["ReviewID"] != null)
                    dgvReviews.Columns["ReviewID"].Visible = false;
                if (dgvReviews.Columns["Course"] != null)
                    dgvReviews.Columns["Course"].HeaderText = "📚 Course";
                if (dgvReviews.Columns["Student"] != null)
                    dgvReviews.Columns["Student"].HeaderText = "👤 Student";
                if (dgvReviews.Columns["Rating"] != null)
                    dgvReviews.Columns["Rating"].HeaderText = "⭐ Rating";
                if (dgvReviews.Columns["Comment"] != null)
                    dgvReviews.Columns["Comment"].HeaderText = "💬 Comment";
                if (dgvReviews.Columns["Date"] != null)
                    dgvReviews.Columns["Date"].HeaderText = "📅 Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NAVIGATION METHODS
        // ============================================================

        private void HighlightButton(Button activeButton)
        {
            Button[] buttons = { btnDashboard, btnMyCourses, btnSeatAvailability, btnStudents, btnEarnings, btnReviews };
            foreach (Button btn in buttons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
                    btn.Font = new Font("Segoe UI", 10F);
                }
            }
        }

        // ============================================================
        // EVENT HANDLERS - SIDEBAR NAVIGATION
        // ============================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboardPanel();
            HighlightButton(btnDashboard);
            LoadDashboard();
        }

        private void btnMyCourses_Click(object sender, EventArgs e)
        {
            ShowMyCoursesPanel();
            HighlightButton(btnMyCourses);
        }

        private void btnSeatAvailability_Click(object sender, EventArgs e)
        {
            ShowSeatAvailabilityPanel();
            HighlightButton(btnSeatAvailability);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
            HighlightButton(btnStudents);
        }

        private void btnEarnings_Click(object sender, EventArgs e)
        {
            ShowEarningsPanel();
            HighlightButton(btnEarnings);
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            ShowReviewsPanel();
            HighlightButton(btnReviews);
        }

        // ============================================================
        // EVENT HANDLERS - DASHBOARD BUTTONS
        // ============================================================

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            ShowMyCoursesPanel();
            HighlightButton(btnMyCourses);
            // Focus on add form
            pnlMyCoursesForm.Visible = true;
            lblMyCoursesFormTitle.Text = "📝 Add New Course";
            btnMyCoursesSave.Text = "💾 Add Course";
            txtMyCoursesTitle.Focus();
        }

        private void btnRequestPayout_Click(object sender, EventArgs e)
        {
            ShowEarningsPanel();
            HighlightButton(btnEarnings);
        }

        private void btnViewAllCourses_Click(object sender, EventArgs e)
        {
            ShowMyCoursesPanel();
            HighlightButton(btnMyCourses);
        }

        // ============================================================
        // EVENT HANDLERS - MY COURSES PANEL
        // ============================================================

        private void btnMyCoursesSearch_Click(object sender, EventArgs e)
        {
            string search = txtMyCoursesSearch.Text.Trim();
            if (search == "Search courses...") search = "";
            int? categoryID = Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) > 0 ?
                Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) : (int?)null;
            LoadMyCourses(search, categoryID);
        }

        private void txtMyCoursesSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtMyCoursesSearch.Text != "Search courses..." && txtMyCoursesSearch.Text.Length >= 2)
            {
                string search = txtMyCoursesSearch.Text.Trim();
                int? categoryID = Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) > 0 ?
                    Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) : (int?)null;
                LoadMyCourses(search, categoryID);
            }
        }

        private void cmbMyCoursesCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMyCoursesCategory.SelectedValue != null)
            {
                string search = txtMyCoursesSearch.Text.Trim();
                if (search == "Search courses...") search = "";
                int? categoryID = Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) > 0 ?
                    Convert.ToInt32(cmbMyCoursesCategory.SelectedValue) : (int?)null;
                LoadMyCourses(search, categoryID);
            }
        }

        private void btnMyCoursesAdd_Click(object sender, EventArgs e)
        {
            pnlMyCoursesForm.Visible = true;
            lblMyCoursesFormTitle.Text = "📝 Add New Course";
            btnMyCoursesSave.Text = "💾 Add Course";
            txtMyCoursesTitle.Clear();
            txtMyCoursesPrice.Clear();
            txtMyCoursesSeats.Clear();
            txtMyCoursesDescription.Clear();
            if (cmbMyCoursesCategoryForm.Items.Count > 0)
                cmbMyCoursesCategoryForm.SelectedIndex = 0;
            txtMyCoursesTitle.Focus();
        }

        private void btnMyCoursesRefresh_Click(object sender, EventArgs e)
        {
            txtMyCoursesSearch.Text = "Search courses...";
            cmbMyCoursesCategory.SelectedValue = 0;
            LoadMyCourses();
        }

        private void dgvMyCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMyCourses.Rows.Count)
            {
                if (e.ColumnIndex == dgvMyCourses.Columns["Edit"].Index)
                {
                    // Load course for editing
                    pnlMyCoursesForm.Visible = true;
                    lblMyCoursesFormTitle.Text = "✏️ Edit Course";
                    btnMyCoursesSave.Text = "💾 Update Course";
                    // Load data from selected row
                    txtMyCoursesTitle.Text = dgvMyCourses.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    txtMyCoursesPrice.Text = dgvMyCourses.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                    txtMyCoursesSeats.Text = dgvMyCourses.Rows[e.RowIndex].Cells["TotalSeats"].Value.ToString();
                }
                else if (e.ColumnIndex == dgvMyCourses.Columns["Delete"].Index)
                {
                    string courseName = dgvMyCourses.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete:\n\n\"{courseName}\"?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Delete logic here
                        MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMyCourses();
                    }
                }
            }
        }

        private void btnMyCoursesSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMyCoursesTitle.Text))
            {
                MessageBox.Show("Please enter a course title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMyCoursesTitle.Focus();
                return;
            }

            MessageBox.Show("Course saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pnlMyCoursesForm.Visible = false;
            LoadMyCourses();
        }

        private void btnMyCoursesCancel_Click(object sender, EventArgs e)
        {
            pnlMyCoursesForm.Visible = false;
        }

        // ============================================================
        // EVENT HANDLERS - SEAT AVAILABILITY PANEL
        // ============================================================

        private void btnSeatRefresh_Click(object sender, EventArgs e)
        {
            LoadSeatAvailability();
            btnSeatRefresh.Text = "✅ Refreshed!";
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, ev) => { btnSeatRefresh.Text = "🔄 Refresh Data"; timer.Stop(); };
            timer.Start();
        }

        // ============================================================
        // EVENT HANDLERS - EARNINGS PANEL
        // ============================================================

        private void btnEarningsRefresh_Click(object sender, EventArgs e)
        {
            LoadEarningsData();
            btnEarningsRefresh.Text = "✅ Refreshed!";
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, ev) => { btnEarningsRefresh.Text = "🔄 Refresh"; timer.Stop(); };
            timer.Start();
        }

        private void btnEarningsPayoutRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEarningsPayoutAmount.Text))
            {
                MessageBox.Show("Please enter an amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEarningsPayoutAmount.Focus();
                return;
            }

            MessageBox.Show("Payout request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEarningsPayoutAmount.Clear();
        }

        // ============================================================
        // EVENT HANDLERS - LOGOUT
        // ============================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblInstructorName_Click(object sender, EventArgs e)
        {

        }
    }
}