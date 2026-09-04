namespace SkillBazaar.Forms
{
    partial class frmInstructorDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ============================================================
            // MAIN CONTAINERS
            // ============================================================
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContentArea = new System.Windows.Forms.Panel();
            
            // ============================================================
            // HEADER CONTROLS
            // ============================================================
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblInstructorName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            
            // ============================================================
            // SIDEBAR CONTROLS
            // ============================================================
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnMyCourses = new System.Windows.Forms.Button();
            this.btnSeatAvailability = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnEarnings = new System.Windows.Forms.Button();
            this.btnReviews = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            // ============================================================
            // DASHBOARD PANEL (Default View)
            // ============================================================
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlCourseCount = new System.Windows.Forms.Panel();
            this.lblCourseCount = new System.Windows.Forms.Label();
            this.lblCourseLabel = new System.Windows.Forms.Label();
            this.pnlEnrollmentCount = new System.Windows.Forms.Panel();
            this.lblEnrollmentCount = new System.Windows.Forms.Label();
            this.lblEnrollmentLabel = new System.Windows.Forms.Label();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBalanceLabel = new System.Windows.Forms.Label();
            this.pnlAvgRating = new System.Windows.Forms.Panel();
            this.lblAvgRating = new System.Windows.Forms.Label();
            this.lblRatingLabel = new System.Windows.Forms.Label();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnRequestPayout = new System.Windows.Forms.Button();
            this.btnViewAllCourses = new System.Windows.Forms.Button();
            this.dgvDashboardCourses = new System.Windows.Forms.DataGridView();

            // ============================================================
            // MY COURSES PANEL (INLINE)
            // ============================================================
            this.pnlMyCourses = new System.Windows.Forms.Panel();
            this.lblMyCoursesTitle = new System.Windows.Forms.Label();
            this.lblMyCoursesSubTitle = new System.Windows.Forms.Label();
            this.pnlMyCoursesSearch = new System.Windows.Forms.Panel();
            this.lblMyCoursesSearch = new System.Windows.Forms.Label();
            this.txtMyCoursesSearch = new System.Windows.Forms.TextBox();
            this.btnMyCoursesSearch = new System.Windows.Forms.Button();
            this.lblMyCoursesFilter = new System.Windows.Forms.Label();
            this.cmbMyCoursesCategory = new System.Windows.Forms.ComboBox();
            this.btnMyCoursesAdd = new System.Windows.Forms.Button();
            this.btnMyCoursesRefresh = new System.Windows.Forms.Button();
            this.dgvMyCourses = new System.Windows.Forms.DataGridView();
            this.pnlMyCoursesForm = new System.Windows.Forms.Panel();
            this.lblMyCoursesFormTitle = new System.Windows.Forms.Label();
            this.lblMyCoursesCourseTitle = new System.Windows.Forms.Label();
            this.txtMyCoursesTitle = new System.Windows.Forms.TextBox();
            this.lblMyCoursesPrice = new System.Windows.Forms.Label();
            this.txtMyCoursesPrice = new System.Windows.Forms.TextBox();
            this.lblMyCoursesSeats = new System.Windows.Forms.Label();
            this.txtMyCoursesSeats = new System.Windows.Forms.TextBox();
            this.lblMyCoursesCategory = new System.Windows.Forms.Label();
            this.cmbMyCoursesCategoryForm = new System.Windows.Forms.ComboBox();
            this.lblMyCoursesDescription = new System.Windows.Forms.Label();
            this.txtMyCoursesDescription = new System.Windows.Forms.TextBox();
            this.btnMyCoursesSave = new System.Windows.Forms.Button();
            this.btnMyCoursesCancel = new System.Windows.Forms.Button();

            // ============================================================
            // SEAT AVAILABILITY PANEL (INLINE)
            // ============================================================
            this.pnlSeatAvailability = new System.Windows.Forms.Panel();
            this.lblSeatTitle = new System.Windows.Forms.Label();
            this.lblSeatSubTitle = new System.Windows.Forms.Label();
            this.pnlSeatWarning = new System.Windows.Forms.Panel();
            this.lblSeatWarningIcon = new System.Windows.Forms.Label();
            this.lblSeatWarning = new System.Windows.Forms.Label();
            this.pnlSeatStats = new System.Windows.Forms.Panel();
            this.pnlSeatTotalCourses = new System.Windows.Forms.Panel();
            this.lblSeatTotalCoursesValue = new System.Windows.Forms.Label();
            this.lblSeatTotalCoursesLabel = new System.Windows.Forms.Label();
            this.pnlSeatLow = new System.Windows.Forms.Panel();
            this.lblSeatLowValue = new System.Windows.Forms.Label();
            this.lblSeatLowLabel = new System.Windows.Forms.Label();
            this.pnlSeatCritical = new System.Windows.Forms.Panel();
            this.lblSeatCriticalValue = new System.Windows.Forms.Label();
            this.lblSeatCriticalLabel = new System.Windows.Forms.Label();
            this.pnlSeatAvailable = new System.Windows.Forms.Panel();
            this.lblSeatAvailableValue = new System.Windows.Forms.Label();
            this.lblSeatAvailableLabel = new System.Windows.Forms.Label();
            this.btnSeatRefresh = new System.Windows.Forms.Button();
            this.dgvSeatAvailability = new System.Windows.Forms.DataGridView();

            // ============================================================
            // EARNINGS PANEL (INLINE)
            // ============================================================
            this.pnlEarnings = new System.Windows.Forms.Panel();
            this.lblEarningsTitle = new System.Windows.Forms.Label();
            this.lblEarningsSubTitle = new System.Windows.Forms.Label();
            this.pnlEarningsStats = new System.Windows.Forms.Panel();
            this.pnlEarningsTotal = new System.Windows.Forms.Panel();
            this.lblEarningsTotalValue = new System.Windows.Forms.Label();
            this.lblEarningsTotalLabel = new System.Windows.Forms.Label();
            this.pnlEarningsBalance = new System.Windows.Forms.Panel();
            this.lblEarningsBalanceValue = new System.Windows.Forms.Label();
            this.lblEarningsBalanceLabel = new System.Windows.Forms.Label();
            this.pnlEarningsFee = new System.Windows.Forms.Panel();
            this.lblEarningsFeeValue = new System.Windows.Forms.Label();
            this.lblEarningsFeeLabel = new System.Windows.Forms.Label();
            this.pnlEarningsStudents = new System.Windows.Forms.Panel();
            this.lblEarningsStudentsValue = new System.Windows.Forms.Label();
            this.lblEarningsStudentsLabel = new System.Windows.Forms.Label();
            this.splitEarnings = new System.Windows.Forms.SplitContainer();
            this.pnlEarningsCourse = new System.Windows.Forms.Panel();
            this.lblEarningsCourseTitle = new System.Windows.Forms.Label();
            this.dgvEarningsCourse = new System.Windows.Forms.DataGridView();
            this.pnlEarningsHistory = new System.Windows.Forms.Panel();
            this.lblEarningsHistoryTitle = new System.Windows.Forms.Label();
            this.dgvEarningsHistory = new System.Windows.Forms.DataGridView();
            this.pnlEarningsPayout = new System.Windows.Forms.Panel();
            this.lblEarningsPayoutTitle = new System.Windows.Forms.Label();
            this.lblEarningsPayoutAmount = new System.Windows.Forms.Label();
            this.txtEarningsPayoutAmount = new System.Windows.Forms.TextBox();
            this.btnEarningsPayoutRequest = new System.Windows.Forms.Button();
            this.lblEarningsMaxAmount = new System.Windows.Forms.Label();
            this.btnEarningsRefresh = new System.Windows.Forms.Button();

            // ============================================================
            // STUDENTS PANEL (INLINE)
            // ============================================================
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.lblStudentsTitle = new System.Windows.Forms.Label();
            this.lblStudentsSubTitle = new System.Windows.Forms.Label();
            this.pnlStudentStats = new System.Windows.Forms.Panel();
            this.pnlTotalStudents = new System.Windows.Forms.Panel();
            this.lblTotalStudentsValue = new System.Windows.Forms.Label();
            this.lblTotalStudentsLabel = new System.Windows.Forms.Label();
            this.pnlActiveStudents = new System.Windows.Forms.Panel();
            this.lblActiveStudentsValue = new System.Windows.Forms.Label();
            this.lblActiveStudentsLabel = new System.Windows.Forms.Label();
            this.pnlNewStudents = new System.Windows.Forms.Panel();
            this.lblNewStudentsValue = new System.Windows.Forms.Label();
            this.lblNewStudentsLabel = new System.Windows.Forms.Label();
            this.txtStudentSearch = new System.Windows.Forms.TextBox();
            this.btnStudentSearch = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();

            // ============================================================
            // REVIEWS PANEL (INLINE)
            // ============================================================
            this.pnlReviews = new System.Windows.Forms.Panel();
            this.lblReviewsTitle = new System.Windows.Forms.Label();
            this.lblReviewsSubTitle = new System.Windows.Forms.Label();
            this.pnlReviewStats = new System.Windows.Forms.Panel();
            this.pnlTotalReviews = new System.Windows.Forms.Panel();
            this.lblTotalReviewsValue = new System.Windows.Forms.Label();
            this.lblTotalReviewsLabel = new System.Windows.Forms.Label();
            this.pnlAverageRating = new System.Windows.Forms.Panel();
            this.lblAverageRatingValue = new System.Windows.Forms.Label();
            this.lblAverageRatingLabel = new System.Windows.Forms.Label();
            this.pnlFiveStar = new System.Windows.Forms.Panel();
            this.lblFiveStarValue = new System.Windows.Forms.Label();
            this.lblFiveStarLabel = new System.Windows.Forms.Label();
            this.dgvReviews = new System.Windows.Forms.DataGridView();

            // ============================================================
            // STATUS STRIP
            // ============================================================
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();

            // ============================================================
            // CONFIGURE SIDEBAR
            // ============================================================
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnMyCourses);
            this.pnlSidebar.Controls.Add(this.btnSeatAvailability);
            this.pnlSidebar.Controls.Add(this.btnStudents);
            this.pnlSidebar.Controls.Add(this.btnEarnings);
            this.pnlSidebar.Controls.Add(this.btnReviews);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 700);
            this.pnlSidebar.TabIndex = 0;

            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(220, 65);
            this.pnlLogo.TabIndex = 0;

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(20, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(179, 21);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "📚 SkillBazaar";

            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 65);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(220, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;

            // 
            // btnMyCourses
            // 
            this.btnMyCourses.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnMyCourses.FlatAppearance.BorderSize = 0;
            this.btnMyCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCourses.ForeColor = System.Drawing.Color.White;
            this.btnMyCourses.Location = new System.Drawing.Point(0, 110);
            this.btnMyCourses.Name = "btnMyCourses";
            this.btnMyCourses.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMyCourses.Size = new System.Drawing.Size(220, 45);
            this.btnMyCourses.TabIndex = 1;
            this.btnMyCourses.Text = "📚 My Courses";
            this.btnMyCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyCourses.UseVisualStyleBackColor = false;

            // 
            // btnSeatAvailability
            // 
            this.btnSeatAvailability.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnSeatAvailability.FlatAppearance.BorderSize = 0;
            this.btnSeatAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatAvailability.ForeColor = System.Drawing.Color.White;
            this.btnSeatAvailability.Location = new System.Drawing.Point(0, 155);
            this.btnSeatAvailability.Name = "btnSeatAvailability";
            this.btnSeatAvailability.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSeatAvailability.Size = new System.Drawing.Size(220, 45);
            this.btnSeatAvailability.TabIndex = 2;
            this.btnSeatAvailability.Text = "💺 Seat Availability";
            this.btnSeatAvailability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeatAvailability.UseVisualStyleBackColor = false;

            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(0, 200);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(220, 45);
            this.btnStudents.TabIndex = 3;
            this.btnStudents.Text = "👨‍🎓 Students";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.UseVisualStyleBackColor = false;

            // 
            // btnEarnings
            // 
            this.btnEarnings.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnEarnings.FlatAppearance.BorderSize = 0;
            this.btnEarnings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEarnings.ForeColor = System.Drawing.Color.White;
            this.btnEarnings.Location = new System.Drawing.Point(0, 245);
            this.btnEarnings.Name = "btnEarnings";
            this.btnEarnings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEarnings.Size = new System.Drawing.Size(220, 45);
            this.btnEarnings.TabIndex = 4;
            this.btnEarnings.Text = "💰 Earnings & Payout";
            this.btnEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEarnings.UseVisualStyleBackColor = false;

            // 
            // btnReviews
            // 
            this.btnReviews.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnReviews.FlatAppearance.BorderSize = 0;
            this.btnReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviews.ForeColor = System.Drawing.Color.White;
            this.btnReviews.Location = new System.Drawing.Point(0, 290);
            this.btnReviews.Name = "btnReviews";
            this.btnReviews.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnReviews.Size = new System.Drawing.Size(220, 45);
            this.btnReviews.TabIndex = 5;
            this.btnReviews.Text = "⭐ Reviews";
            this.btnReviews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReviews.UseVisualStyleBackColor = false;

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 640);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;

            // ============================================================
            // CONFIGURE HEADER
            // ============================================================
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblInstructorName);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 70);
            this.pnlHeader.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏫 Coders BD Academy";

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblWelcome.Location = new System.Drawing.Point(25, 42);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(86, 19);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome back,";

            // 
            // lblInstructorName
            // 
            this.lblInstructorName.AutoSize = true;
            this.lblInstructorName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInstructorName.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblInstructorName.Location = new System.Drawing.Point(132, 42);
            this.lblInstructorName.Name = "lblInstructorName";
            this.lblInstructorName.Size = new System.Drawing.Size(50, 21);
            this.lblInstructorName.TabIndex = 2;
            this.lblInstructorName.Text = "Rafiq";

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblDate.Location = new System.Drawing.Point(720, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 19);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "📅 Sep 04, 2026";

            // ============================================================
            // CONFIGURE CONTENT AREA
            // ============================================================
            // 
            // pnlContentArea
            // 
            this.pnlContentArea.Controls.Add(this.pnlDashboard);
            this.pnlContentArea.Controls.Add(this.pnlMyCourses);
            this.pnlContentArea.Controls.Add(this.pnlSeatAvailability);
            this.pnlContentArea.Controls.Add(this.pnlEarnings);
            this.pnlContentArea.Controls.Add(this.pnlStudents);
            this.pnlContentArea.Controls.Add(this.pnlReviews);
            this.pnlContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentArea.Location = new System.Drawing.Point(220, 70);
            this.pnlContentArea.Name = "pnlContentArea";
            this.pnlContentArea.Size = new System.Drawing.Size(880, 630);
            this.pnlContentArea.TabIndex = 2;

            // ============================================================
            // CONFIGURE DASHBOARD PANEL
            // ============================================================
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.pnlStats);
            this.pnlDashboard.Controls.Add(this.btnAddCourse);
            this.pnlDashboard.Controls.Add(this.btnRequestPayout);
            this.pnlDashboard.Controls.Add(this.btnViewAllCourses);
            this.pnlDashboard.Controls.Add(this.dgvDashboardCourses);
            this.pnlDashboard.Controls.Add(this.statusStrip);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Padding = new System.Windows.Forms.Padding(25);
            this.pnlDashboard.Size = new System.Drawing.Size(880, 630);
            this.pnlDashboard.TabIndex = 0;

            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlCourseCount);
            this.pnlStats.Controls.Add(this.pnlEnrollmentCount);
            this.pnlStats.Controls.Add(this.pnlBalance);
            this.pnlStats.Controls.Add(this.pnlAvgRating);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(25, 25);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(830, 110);
            this.pnlStats.TabIndex = 0;

            // 
            // pnlCourseCount
            // 
            this.pnlCourseCount.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlCourseCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCourseCount.Controls.Add(this.lblCourseCount);
            this.pnlCourseCount.Controls.Add(this.lblCourseLabel);
            this.pnlCourseCount.Location = new System.Drawing.Point(0, 0);
            this.pnlCourseCount.Name = "pnlCourseCount";
            this.pnlCourseCount.Size = new System.Drawing.Size(195, 100);
            this.pnlCourseCount.TabIndex = 0;

            // 
            // lblCourseCount
            // 
            this.lblCourseCount.AutoSize = true;
            this.lblCourseCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCourseCount.ForeColor = System.Drawing.Color.White;
            this.lblCourseCount.Location = new System.Drawing.Point(75, 20);
            this.lblCourseCount.Name = "lblCourseCount";
            this.lblCourseCount.Size = new System.Drawing.Size(38, 45);
            this.lblCourseCount.TabIndex = 0;
            this.lblCourseCount.Text = "0";

            // 
            // lblCourseLabel
            // 
            this.lblCourseLabel.AutoSize = true;
            this.lblCourseLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCourseLabel.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblCourseLabel.Location = new System.Drawing.Point(55, 70);
            this.lblCourseLabel.Name = "lblCourseLabel";
            this.lblCourseLabel.Size = new System.Drawing.Size(84, 19);
            this.lblCourseLabel.TabIndex = 1;
            this.lblCourseLabel.Text = "My Courses";

            // 
            // pnlEnrollmentCount
            // 
            this.pnlEnrollmentCount.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlEnrollmentCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEnrollmentCount.Controls.Add(this.lblEnrollmentCount);
            this.pnlEnrollmentCount.Controls.Add(this.lblEnrollmentLabel);
            this.pnlEnrollmentCount.Location = new System.Drawing.Point(210, 0);
            this.pnlEnrollmentCount.Name = "pnlEnrollmentCount";
            this.pnlEnrollmentCount.Size = new System.Drawing.Size(195, 100);
            this.pnlEnrollmentCount.TabIndex = 1;

            // 
            // lblEnrollmentCount
            // 
            this.lblEnrollmentCount.AutoSize = true;
            this.lblEnrollmentCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblEnrollmentCount.ForeColor = System.Drawing.Color.White;
            this.lblEnrollmentCount.Location = new System.Drawing.Point(75, 20);
            this.lblEnrollmentCount.Name = "lblEnrollmentCount";
            this.lblEnrollmentCount.Size = new System.Drawing.Size(38, 45);
            this.lblEnrollmentCount.TabIndex = 0;
            this.lblEnrollmentCount.Text = "0";

            // 
            // lblEnrollmentLabel
            // 
            this.lblEnrollmentLabel.AutoSize = true;
            this.lblEnrollmentLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEnrollmentLabel.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblEnrollmentLabel.Location = new System.Drawing.Point(45, 70);
            this.lblEnrollmentLabel.Name = "lblEnrollmentLabel";
            this.lblEnrollmentLabel.Size = new System.Drawing.Size(115, 19);
            this.lblEnrollmentLabel.TabIndex = 1;
            this.lblEnrollmentLabel.Text = "Total Enrollments";

            // 
            // pnlBalance
            // 
            this.pnlBalance.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBalance.Controls.Add(this.lblBalance);
            this.pnlBalance.Controls.Add(this.lblBalanceLabel);
            this.pnlBalance.Location = new System.Drawing.Point(420, 0);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Size = new System.Drawing.Size(195, 100);
            this.pnlBalance.TabIndex = 2;

            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(30, 15);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(82, 37);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "৳ 0";

            // 
            // lblBalanceLabel
            // 
            this.lblBalanceLabel.AutoSize = true;
            this.lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 150);
            this.lblBalanceLabel.Location = new System.Drawing.Point(10, 60);
            this.lblBalanceLabel.Name = "lblBalanceLabel";
            this.lblBalanceLabel.Size = new System.Drawing.Size(173, 13);
            this.lblBalanceLabel.TabIndex = 1;
            this.lblBalanceLabel.Text = "Available Balance (after 20% fee)";

            // 
            // pnlAvgRating
            // 
            this.pnlAvgRating.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.pnlAvgRating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAvgRating.Controls.Add(this.lblAvgRating);
            this.pnlAvgRating.Controls.Add(this.lblRatingLabel);
            this.pnlAvgRating.Location = new System.Drawing.Point(630, 0);
            this.pnlAvgRating.Name = "pnlAvgRating";
            this.pnlAvgRating.Size = new System.Drawing.Size(195, 100);
            this.pnlAvgRating.TabIndex = 3;

            // 
            // lblAvgRating
            // 
            this.lblAvgRating.AutoSize = true;
            this.lblAvgRating.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAvgRating.ForeColor = System.Drawing.Color.White;
            this.lblAvgRating.Location = new System.Drawing.Point(60, 20);
            this.lblAvgRating.Name = "lblAvgRating";
            this.lblAvgRating.Size = new System.Drawing.Size(58, 45);
            this.lblAvgRating.TabIndex = 0;
            this.lblAvgRating.Text = "0.0";

            // 
            // lblRatingLabel
            // 
            this.lblRatingLabel.AutoSize = true;
            this.lblRatingLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRatingLabel.ForeColor = System.Drawing.Color.FromArgb(210, 200, 230);
            this.lblRatingLabel.Location = new System.Drawing.Point(55, 70);
            this.lblRatingLabel.Name = "lblRatingLabel";
            this.lblRatingLabel.Size = new System.Drawing.Size(84, 19);
            this.lblRatingLabel.TabIndex = 1;
            this.lblRatingLabel.Text = "Avg. Rating";

            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Location = new System.Drawing.Point(25, 145);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(160, 35);
            this.btnAddCourse.TabIndex = 1;
            this.btnAddCourse.Text = "➕ Add New Course";
            this.btnAddCourse.UseVisualStyleBackColor = false;

            // 
            // btnRequestPayout
            // 
            this.btnRequestPayout.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnRequestPayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestPayout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequestPayout.ForeColor = System.Drawing.Color.White;
            this.btnRequestPayout.Location = new System.Drawing.Point(200, 145);
            this.btnRequestPayout.Name = "btnRequestPayout";
            this.btnRequestPayout.Size = new System.Drawing.Size(160, 35);
            this.btnRequestPayout.TabIndex = 2;
            this.btnRequestPayout.Text = "💳 Request Payout";
            this.btnRequestPayout.UseVisualStyleBackColor = false;

            // 
            // btnViewAllCourses
            // 
            this.btnViewAllCourses.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnViewAllCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllCourses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewAllCourses.ForeColor = System.Drawing.Color.White;
            this.btnViewAllCourses.Location = new System.Drawing.Point(700, 145);
            this.btnViewAllCourses.Name = "btnViewAllCourses";
            this.btnViewAllCourses.Size = new System.Drawing.Size(155, 35);
            this.btnViewAllCourses.TabIndex = 3;
            this.btnViewAllCourses.Text = "📋 View All Courses";
            this.btnViewAllCourses.UseVisualStyleBackColor = false;

            // 
            // dgvDashboardCourses
            // 
            this.dgvDashboardCourses.AllowUserToAddRows = false;
            this.dgvDashboardCourses.AllowUserToDeleteRows = false;
            this.dgvDashboardCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDashboardCourses.BackgroundColor = System.Drawing.Color.White;
            this.dgvDashboardCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDashboardCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDashboardCourses.Location = new System.Drawing.Point(25, 195);
            this.dgvDashboardCourses.Name = "dgvDashboardCourses";
            this.dgvDashboardCourses.ReadOnly = true;
            this.dgvDashboardCourses.RowHeadersVisible = false;
            this.dgvDashboardCourses.Size = new System.Drawing.Size(830, 370);
            this.dgvDashboardCourses.TabIndex = 4;
            this.dgvDashboardCourses.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDashboardCourses.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvDashboardCourses.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvDashboardCourses.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDashboardCourses.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvDashboardCourses.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.dgvDashboardCourses.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDashboardCourses.RowTemplate.Height = 40;

            // ============================================================
            // CONFIGURE MY COURSES PANEL (INLINE)
            // ============================================================
            // 
            // pnlMyCourses
            // 
            this.pnlMyCourses.Controls.Add(this.lblMyCoursesTitle);
            this.pnlMyCourses.Controls.Add(this.lblMyCoursesSubTitle);
            this.pnlMyCourses.Controls.Add(this.pnlMyCoursesSearch);
            this.pnlMyCourses.Controls.Add(this.dgvMyCourses);
            this.pnlMyCourses.Controls.Add(this.pnlMyCoursesForm);
            this.pnlMyCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMyCourses.Location = new System.Drawing.Point(0, 0);
            this.pnlMyCourses.Name = "pnlMyCourses";
            this.pnlMyCourses.Padding = new System.Windows.Forms.Padding(25);
            this.pnlMyCourses.Size = new System.Drawing.Size(880, 630);
            this.pnlMyCourses.TabIndex = 3;
            this.pnlMyCourses.Visible = false;

            // 
            // lblMyCoursesTitle
            // 
            this.lblMyCoursesTitle.AutoSize = true;
            this.lblMyCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMyCoursesTitle.Location = new System.Drawing.Point(25, 25);
            this.lblMyCoursesTitle.Name = "lblMyCoursesTitle";
            this.lblMyCoursesTitle.Size = new System.Drawing.Size(247, 32);
            this.lblMyCoursesTitle.TabIndex = 0;
            this.lblMyCoursesTitle.Text = "📚 My Courses";

            // 
            // lblMyCoursesSubTitle
            // 
            this.lblMyCoursesSubTitle.AutoSize = true;
            this.lblMyCoursesSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblMyCoursesSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblMyCoursesSubTitle.Name = "lblMyCoursesSubTitle";
            this.lblMyCoursesSubTitle.Size = new System.Drawing.Size(238, 19);
            this.lblMyCoursesSubTitle.TabIndex = 1;
            this.lblMyCoursesSubTitle.Text = "Manage your courses and their details";

            // 
            // pnlMyCoursesSearch
            // 
            this.pnlMyCoursesSearch.Controls.Add(this.lblMyCoursesSearch);
            this.pnlMyCoursesSearch.Controls.Add(this.txtMyCoursesSearch);
            this.pnlMyCoursesSearch.Controls.Add(this.btnMyCoursesSearch);
            this.pnlMyCoursesSearch.Controls.Add(this.lblMyCoursesFilter);
            this.pnlMyCoursesSearch.Controls.Add(this.cmbMyCoursesCategory);
            this.pnlMyCoursesSearch.Controls.Add(this.btnMyCoursesAdd);
            this.pnlMyCoursesSearch.Controls.Add(this.btnMyCoursesRefresh);
            this.pnlMyCoursesSearch.Location = new System.Drawing.Point(25, 85);
            this.pnlMyCoursesSearch.Name = "pnlMyCoursesSearch";
            this.pnlMyCoursesSearch.Size = new System.Drawing.Size(830, 50);
            this.pnlMyCoursesSearch.TabIndex = 2;

            // 
            // lblMyCoursesSearch
            // 
            this.lblMyCoursesSearch.AutoSize = true;
            this.lblMyCoursesSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesSearch.Location = new System.Drawing.Point(0, 15);
            this.lblMyCoursesSearch.Name = "lblMyCoursesSearch";
            this.lblMyCoursesSearch.Size = new System.Drawing.Size(55, 19);
            this.lblMyCoursesSearch.TabIndex = 0;
            this.lblMyCoursesSearch.Text = "Search:";

            // 
            // txtMyCoursesSearch
            // 
            this.txtMyCoursesSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMyCoursesSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtMyCoursesSearch.Location = new System.Drawing.Point(60, 12);
            this.txtMyCoursesSearch.Name = "txtMyCoursesSearch";
            this.txtMyCoursesSearch.Size = new System.Drawing.Size(220, 25);
            this.txtMyCoursesSearch.TabIndex = 1;
            this.txtMyCoursesSearch.Text = "Search courses...";

            // 
            // btnMyCoursesSearch
            // 
            this.btnMyCoursesSearch.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnMyCoursesSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCoursesSearch.ForeColor = System.Drawing.Color.White;
            this.btnMyCoursesSearch.Location = new System.Drawing.Point(285, 10);
            this.btnMyCoursesSearch.Name = "btnMyCoursesSearch";
            this.btnMyCoursesSearch.Size = new System.Drawing.Size(80, 28);
            this.btnMyCoursesSearch.TabIndex = 2;
            this.btnMyCoursesSearch.Text = "🔍 Search";
            this.btnMyCoursesSearch.UseVisualStyleBackColor = false;

            // 
            // lblMyCoursesFilter
            // 
            this.lblMyCoursesFilter.AutoSize = true;
            this.lblMyCoursesFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesFilter.Location = new System.Drawing.Point(380, 15);
            this.lblMyCoursesFilter.Name = "lblMyCoursesFilter";
            this.lblMyCoursesFilter.Size = new System.Drawing.Size(49, 19);
            this.lblMyCoursesFilter.TabIndex = 3;
            this.lblMyCoursesFilter.Text = "Filter:";

            // 
            // cmbMyCoursesCategory
            // 
            this.cmbMyCoursesCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMyCoursesCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMyCoursesCategory.Location = new System.Drawing.Point(435, 12);
            this.cmbMyCoursesCategory.Name = "cmbMyCoursesCategory";
            this.cmbMyCoursesCategory.Size = new System.Drawing.Size(180, 25);
            this.cmbMyCoursesCategory.TabIndex = 4;

            // 
            // btnMyCoursesAdd
            // 
            this.btnMyCoursesAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnMyCoursesAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCoursesAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyCoursesAdd.ForeColor = System.Drawing.Color.White;
            this.btnMyCoursesAdd.Location = new System.Drawing.Point(660, 8);
            this.btnMyCoursesAdd.Name = "btnMyCoursesAdd";
            this.btnMyCoursesAdd.Size = new System.Drawing.Size(160, 32);
            this.btnMyCoursesAdd.TabIndex = 5;
            this.btnMyCoursesAdd.Text = "➕ Add New Course";
            this.btnMyCoursesAdd.UseVisualStyleBackColor = false;

            // 
            // btnMyCoursesRefresh
            // 
            this.btnMyCoursesRefresh.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnMyCoursesRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCoursesRefresh.ForeColor = System.Drawing.Color.White;
            this.btnMyCoursesRefresh.Location = new System.Drawing.Point(830, 8);
            this.btnMyCoursesRefresh.Name = "btnMyCoursesRefresh";
            this.btnMyCoursesRefresh.Size = new System.Drawing.Size(0, 32);
            this.btnMyCoursesRefresh.TabIndex = 6;
            this.btnMyCoursesRefresh.Text = "🔄 Refresh";
            this.btnMyCoursesRefresh.UseVisualStyleBackColor = false;

            // 
            // dgvMyCourses
            // 
            this.dgvMyCourses.AllowUserToAddRows = false;
            this.dgvMyCourses.AllowUserToDeleteRows = false;
            this.dgvMyCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyCourses.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyCourses.Location = new System.Drawing.Point(25, 145);
            this.dgvMyCourses.Name = "dgvMyCourses";
            this.dgvMyCourses.ReadOnly = true;
            this.dgvMyCourses.RowHeadersVisible = false;
            this.dgvMyCourses.Size = new System.Drawing.Size(830, 250);
            this.dgvMyCourses.TabIndex = 3;
            this.dgvMyCourses.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMyCourses.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMyCourses.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvMyCourses.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMyCourses.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvMyCourses.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.dgvMyCourses.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMyCourses.RowTemplate.Height = 35;

            // 
            // pnlMyCoursesForm
            // 
            this.pnlMyCoursesForm.BackColor = System.Drawing.Color.White;
            this.pnlMyCoursesForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesFormTitle);
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesCourseTitle);
            this.pnlMyCoursesForm.Controls.Add(this.txtMyCoursesTitle);
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesPrice);
            this.pnlMyCoursesForm.Controls.Add(this.txtMyCoursesPrice);
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesSeats);
            this.pnlMyCoursesForm.Controls.Add(this.txtMyCoursesSeats);
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesCategory);
            this.pnlMyCoursesForm.Controls.Add(this.cmbMyCoursesCategoryForm);
            this.pnlMyCoursesForm.Controls.Add(this.lblMyCoursesDescription);
            this.pnlMyCoursesForm.Controls.Add(this.txtMyCoursesDescription);
            this.pnlMyCoursesForm.Controls.Add(this.btnMyCoursesSave);
            this.pnlMyCoursesForm.Controls.Add(this.btnMyCoursesCancel);
            this.pnlMyCoursesForm.Location = new System.Drawing.Point(25, 410);
            this.pnlMyCoursesForm.Name = "pnlMyCoursesForm";
            this.pnlMyCoursesForm.Size = new System.Drawing.Size(830, 200);
            this.pnlMyCoursesForm.TabIndex = 4;
            this.pnlMyCoursesForm.Visible = false;

            // 
            // lblMyCoursesFormTitle
            // 
            this.lblMyCoursesFormTitle.AutoSize = true;
            this.lblMyCoursesFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMyCoursesFormTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMyCoursesFormTitle.Name = "lblMyCoursesFormTitle";
            this.lblMyCoursesFormTitle.Size = new System.Drawing.Size(162, 25);
            this.lblMyCoursesFormTitle.TabIndex = 0;
            this.lblMyCoursesFormTitle.Text = "📝 Add New Course";

            // 
            // lblMyCoursesCourseTitle
            // 
            this.lblMyCoursesCourseTitle.AutoSize = true;
            this.lblMyCoursesCourseTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesCourseTitle.Location = new System.Drawing.Point(20, 55);
            this.lblMyCoursesCourseTitle.Name = "lblMyCoursesCourseTitle";
            this.lblMyCoursesCourseTitle.Size = new System.Drawing.Size(86, 19);
            this.lblMyCoursesCourseTitle.TabIndex = 1;
            this.lblMyCoursesCourseTitle.Text = "Course Title:";

            // 
            // txtMyCoursesTitle
            // 
            this.txtMyCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMyCoursesTitle.Location = new System.Drawing.Point(20, 78);
            this.txtMyCoursesTitle.Name = "txtMyCoursesTitle";
            this.txtMyCoursesTitle.Size = new System.Drawing.Size(300, 25);
            this.txtMyCoursesTitle.TabIndex = 2;

            // 
            // lblMyCoursesPrice
            // 
            this.lblMyCoursesPrice.AutoSize = true;
            this.lblMyCoursesPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesPrice.Location = new System.Drawing.Point(340, 55);
            this.lblMyCoursesPrice.Name = "lblMyCoursesPrice";
            this.lblMyCoursesPrice.Size = new System.Drawing.Size(68, 19);
            this.lblMyCoursesPrice.TabIndex = 3;
            this.lblMyCoursesPrice.Text = "Price (৳):";

            // 
            // txtMyCoursesPrice
            // 
            this.txtMyCoursesPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMyCoursesPrice.Location = new System.Drawing.Point(340, 78);
            this.txtMyCoursesPrice.Name = "txtMyCoursesPrice";
            this.txtMyCoursesPrice.Size = new System.Drawing.Size(150, 25);
            this.txtMyCoursesPrice.TabIndex = 4;
            this.txtMyCoursesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblMyCoursesSeats
            // 
            this.lblMyCoursesSeats.AutoSize = true;
            this.lblMyCoursesSeats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesSeats.Location = new System.Drawing.Point(510, 55);
            this.lblMyCoursesSeats.Name = "lblMyCoursesSeats";
            this.lblMyCoursesSeats.Size = new System.Drawing.Size(95, 19);
            this.lblMyCoursesSeats.TabIndex = 5;
            this.lblMyCoursesSeats.Text = "Seats Available:";

            // 
            // txtMyCoursesSeats
            // 
            this.txtMyCoursesSeats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMyCoursesSeats.Location = new System.Drawing.Point(510, 78);
            this.txtMyCoursesSeats.Name = "txtMyCoursesSeats";
            this.txtMyCoursesSeats.Size = new System.Drawing.Size(130, 25);
            this.txtMyCoursesSeats.TabIndex = 6;
            this.txtMyCoursesSeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblMyCoursesCategory
            // 
            this.lblMyCoursesCategory.AutoSize = true;
            this.lblMyCoursesCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesCategory.Location = new System.Drawing.Point(660, 55);
            this.lblMyCoursesCategory.Name = "lblMyCoursesCategory";
            this.lblMyCoursesCategory.Size = new System.Drawing.Size(67, 19);
            this.lblMyCoursesCategory.TabIndex = 7;
            this.lblMyCoursesCategory.Text = "Category:";

            // 
            // cmbMyCoursesCategoryForm
            // 
            this.cmbMyCoursesCategoryForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMyCoursesCategoryForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMyCoursesCategoryForm.Location = new System.Drawing.Point(660, 78);
            this.cmbMyCoursesCategoryForm.Name = "cmbMyCoursesCategoryForm";
            this.cmbMyCoursesCategoryForm.Size = new System.Drawing.Size(150, 25);
            this.cmbMyCoursesCategoryForm.TabIndex = 8;

            // 
            // lblMyCoursesDescription
            // 
            this.lblMyCoursesDescription.AutoSize = true;
            this.lblMyCoursesDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMyCoursesDescription.Location = new System.Drawing.Point(20, 115);
            this.lblMyCoursesDescription.Name = "lblMyCoursesDescription";
            this.lblMyCoursesDescription.Size = new System.Drawing.Size(82, 19);
            this.lblMyCoursesDescription.TabIndex = 9;
            this.lblMyCoursesDescription.Text = "Description:";

            // 
            // txtMyCoursesDescription
            // 
            this.txtMyCoursesDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMyCoursesDescription.Location = new System.Drawing.Point(20, 138);
            this.txtMyCoursesDescription.Multiline = true;
            this.txtMyCoursesDescription.Name = "txtMyCoursesDescription";
            this.txtMyCoursesDescription.Size = new System.Drawing.Size(790, 40);
            this.txtMyCoursesDescription.TabIndex = 10;

            // 
            // btnMyCoursesSave
            // 
            this.btnMyCoursesSave.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnMyCoursesSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCoursesSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyCoursesSave.ForeColor = System.Drawing.Color.White;
            this.btnMyCoursesSave.Location = new System.Drawing.Point(20, 190);
            this.btnMyCoursesSave.Name = "btnMyCoursesSave";
            this.btnMyCoursesSave.Size = new System.Drawing.Size(130, 35);
            this.btnMyCoursesSave.TabIndex = 11;
            this.btnMyCoursesSave.Text = "💾 Save Course";
            this.btnMyCoursesSave.UseVisualStyleBackColor = false;

            // 
            // btnMyCoursesCancel
            // 
            this.btnMyCoursesCancel.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnMyCoursesCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCoursesCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyCoursesCancel.ForeColor = System.Drawing.Color.White;
            this.btnMyCoursesCancel.Location = new System.Drawing.Point(160, 190);
            this.btnMyCoursesCancel.Name = "btnMyCoursesCancel";
            this.btnMyCoursesCancel.Size = new System.Drawing.Size(130, 35);
            this.btnMyCoursesCancel.TabIndex = 12;
            this.btnMyCoursesCancel.Text = "❌ Cancel";
            this.btnMyCoursesCancel.UseVisualStyleBackColor = false;

            // ============================================================
            // CONFIGURE SEAT AVAILABILITY PANEL (INLINE)
            // ============================================================
            // 
            // pnlSeatAvailability
            // 
            this.pnlSeatAvailability.Controls.Add(this.lblSeatTitle);
            this.pnlSeatAvailability.Controls.Add(this.lblSeatSubTitle);
            this.pnlSeatAvailability.Controls.Add(this.pnlSeatWarning);
            this.pnlSeatAvailability.Controls.Add(this.pnlSeatStats);
            this.pnlSeatAvailability.Controls.Add(this.btnSeatRefresh);
            this.pnlSeatAvailability.Controls.Add(this.dgvSeatAvailability);
            this.pnlSeatAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeatAvailability.Location = new System.Drawing.Point(0, 0);
            this.pnlSeatAvailability.Name = "pnlSeatAvailability";
            this.pnlSeatAvailability.Padding = new System.Windows.Forms.Padding(25);
            this.pnlSeatAvailability.Size = new System.Drawing.Size(880, 630);
            this.pnlSeatAvailability.TabIndex = 4;
            this.pnlSeatAvailability.Visible = false;

            // 
            // lblSeatTitle
            // 
            this.lblSeatTitle.AutoSize = true;
            this.lblSeatTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSeatTitle.Location = new System.Drawing.Point(25, 25);
            this.lblSeatTitle.Name = "lblSeatTitle";
            this.lblSeatTitle.Size = new System.Drawing.Size(211, 32);
            this.lblSeatTitle.TabIndex = 0;
            this.lblSeatTitle.Text = "💺 Seat Availability";

            // 
            // lblSeatSubTitle
            // 
            this.lblSeatSubTitle.AutoSize = true;
            this.lblSeatSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSeatSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSeatSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblSeatSubTitle.Name = "lblSeatSubTitle";
            this.lblSeatSubTitle.Size = new System.Drawing.Size(240, 19);
            this.lblSeatSubTitle.TabIndex = 1;
            this.lblSeatSubTitle.Text = "Monitor your course seat availability";

            // 
            // pnlSeatWarning
            // 
            this.pnlSeatWarning.BackColor = System.Drawing.Color.FromArgb(255, 243, 224);
            this.pnlSeatWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeatWarning.Controls.Add(this.lblSeatWarningIcon);
            this.pnlSeatWarning.Controls.Add(this.lblSeatWarning);
            this.pnlSeatWarning.Location = new System.Drawing.Point(25, 85);
            this.pnlSeatWarning.Name = "pnlSeatWarning";
            this.pnlSeatWarning.Size = new System.Drawing.Size(830, 40);
            this.pnlSeatWarning.TabIndex = 2;
            this.pnlSeatWarning.Visible = false;

            // 
            // lblSeatWarningIcon
            // 
            this.lblSeatWarningIcon.AutoSize = true;
            this.lblSeatWarningIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSeatWarningIcon.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblSeatWarningIcon.Location = new System.Drawing.Point(15, 8);
            this.lblSeatWarningIcon.Name = "lblSeatWarningIcon";
            this.lblSeatWarningIcon.Size = new System.Drawing.Size(31, 21);
            this.lblSeatWarningIcon.TabIndex = 0;
            this.lblSeatWarningIcon.Text = "⚠️";

            // 
            // lblSeatWarning
            // 
            this.lblSeatWarning.AutoSize = true;
            this.lblSeatWarning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeatWarning.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblSeatWarning.Location = new System.Drawing.Point(52, 10);
            this.lblSeatWarning.Name = "lblSeatWarning";
            this.lblSeatWarning.Size = new System.Drawing.Size(410, 19);
            this.lblSeatWarning.TabIndex = 1;
            this.lblSeatWarning.Text = "1 course is below its minimum seat threshold. Consider increasing capacity.";

            // 
            // pnlSeatStats
            // 
            this.pnlSeatStats.Controls.Add(this.pnlSeatTotalCourses);
            this.pnlSeatStats.Controls.Add(this.pnlSeatLow);
            this.pnlSeatStats.Controls.Add(this.pnlSeatCritical);
            this.pnlSeatStats.Controls.Add(this.pnlSeatAvailable);
            this.pnlSeatStats.Location = new System.Drawing.Point(25, 135);
            this.pnlSeatStats.Name = "pnlSeatStats";
            this.pnlSeatStats.Size = new System.Drawing.Size(830, 80);
            this.pnlSeatStats.TabIndex = 3;

            // 
            // pnlSeatTotalCourses
            // 
            this.pnlSeatTotalCourses.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlSeatTotalCourses.Controls.Add(this.lblSeatTotalCoursesValue);
            this.pnlSeatTotalCourses.Controls.Add(this.lblSeatTotalCoursesLabel);
            this.pnlSeatTotalCourses.Location = new System.Drawing.Point(0, 0);
            this.pnlSeatTotalCourses.Name = "pnlSeatTotalCourses";
            this.pnlSeatTotalCourses.Size = new System.Drawing.Size(200, 80);
            this.pnlSeatTotalCourses.TabIndex = 0;

            // 
            // lblSeatTotalCoursesValue
            // 
            this.lblSeatTotalCoursesValue.AutoSize = true;
            this.lblSeatTotalCoursesValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSeatTotalCoursesValue.ForeColor = System.Drawing.Color.White;
            this.lblSeatTotalCoursesValue.Location = new System.Drawing.Point(75, 15);
            this.lblSeatTotalCoursesValue.Name = "lblSeatTotalCoursesValue";
            this.lblSeatTotalCoursesValue.Size = new System.Drawing.Size(32, 37);
            this.lblSeatTotalCoursesValue.TabIndex = 0;
            this.lblSeatTotalCoursesValue.Text = "0";

            // 
            // lblSeatTotalCoursesLabel
            // 
            this.lblSeatTotalCoursesLabel.AutoSize = true;
            this.lblSeatTotalCoursesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeatTotalCoursesLabel.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblSeatTotalCoursesLabel.Location = new System.Drawing.Point(55, 55);
            this.lblSeatTotalCoursesLabel.Name = "lblSeatTotalCoursesLabel";
            this.lblSeatTotalCoursesLabel.Size = new System.Drawing.Size(86, 15);
            this.lblSeatTotalCoursesLabel.TabIndex = 1;
            this.lblSeatTotalCoursesLabel.Text = "Total Courses";

            // 
            // pnlSeatLow
            // 
            this.pnlSeatLow.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlSeatLow.Controls.Add(this.lblSeatLowValue);
            this.pnlSeatLow.Controls.Add(this.lblSeatLowLabel);
            this.pnlSeatLow.Location = new System.Drawing.Point(210, 0);
            this.pnlSeatLow.Name = "pnlSeatLow";
            this.pnlSeatLow.Size = new System.Drawing.Size(200, 80);
            this.pnlSeatLow.TabIndex = 1;

            // 
            // lblSeatLowValue
            // 
            this.lblSeatLowValue.AutoSize = true;
            this.lblSeatLowValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSeatLowValue.ForeColor = System.Drawing.Color.White;
            this.lblSeatLowValue.Location = new System.Drawing.Point(75, 15);
            this.lblSeatLowValue.Name = "lblSeatLowValue";
            this.lblSeatLowValue.Size = new System.Drawing.Size(32, 37);
            this.lblSeatLowValue.TabIndex = 0;
            this.lblSeatLowValue.Text = "0";

            // 
            // lblSeatLowLabel
            // 
            this.lblSeatLowLabel.AutoSize = true;
            this.lblSeatLowLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeatLowLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 150);
            this.lblSeatLowLabel.Location = new System.Drawing.Point(45, 55);
            this.lblSeatLowLabel.Name = "lblSeatLowLabel";
            this.lblSeatLowLabel.Size = new System.Drawing.Size(103, 15);
            this.lblSeatLowLabel.TabIndex = 1;
            this.lblSeatLowLabel.Text = "Low Seat Courses";

            // 
            // pnlSeatCritical
            // 
            this.pnlSeatCritical.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.pnlSeatCritical.Controls.Add(this.lblSeatCriticalValue);
            this.pnlSeatCritical.Controls.Add(this.lblSeatCriticalLabel);
            this.pnlSeatCritical.Location = new System.Drawing.Point(420, 0);
            this.pnlSeatCritical.Name = "pnlSeatCritical";
            this.pnlSeatCritical.Size = new System.Drawing.Size(200, 80);
            this.pnlSeatCritical.TabIndex = 2;

            // 
            // lblSeatCriticalValue
            // 
            this.lblSeatCriticalValue.AutoSize = true;
            this.lblSeatCriticalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSeatCriticalValue.ForeColor = System.Drawing.Color.White;
            this.lblSeatCriticalValue.Location = new System.Drawing.Point(75, 15);
            this.lblSeatCriticalValue.Name = "lblSeatCriticalValue";
            this.lblSeatCriticalValue.Size = new System.Drawing.Size(32, 37);
            this.lblSeatCriticalValue.TabIndex = 0;
            this.lblSeatCriticalValue.Text = "0";

            // 
            // lblSeatCriticalLabel
            // 
            this.lblSeatCriticalLabel.AutoSize = true;
            this.lblSeatCriticalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeatCriticalLabel.ForeColor = System.Drawing.Color.FromArgb(220, 200, 200);
            this.lblSeatCriticalLabel.Location = new System.Drawing.Point(35, 55);
            this.lblSeatCriticalLabel.Name = "lblSeatCriticalLabel";
            this.lblSeatCriticalLabel.Size = new System.Drawing.Size(120, 15);
            this.lblSeatCriticalLabel.TabIndex = 1;
            this.lblSeatCriticalLabel.Text = "Critical Seat Courses";

            // 
            // pnlSeatAvailable
            // 
            this.pnlSeatAvailable.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlSeatAvailable.Controls.Add(this.lblSeatAvailableValue);
            this.pnlSeatAvailable.Controls.Add(this.lblSeatAvailableLabel);
            this.pnlSeatAvailable.Location = new System.Drawing.Point(630, 0);
            this.pnlSeatAvailable.Name = "pnlSeatAvailable";
            this.pnlSeatAvailable.Size = new System.Drawing.Size(200, 80);
            this.pnlSeatAvailable.TabIndex = 3;

            // 
            // lblSeatAvailableValue
            // 
            this.lblSeatAvailableValue.AutoSize = true;
            this.lblSeatAvailableValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSeatAvailableValue.ForeColor = System.Drawing.Color.White;
            this.lblSeatAvailableValue.Location = new System.Drawing.Point(75, 15);
            this.lblSeatAvailableValue.Name = "lblSeatAvailableValue";
            this.lblSeatAvailableValue.Size = new System.Drawing.Size(32, 37);
            this.lblSeatAvailableValue.TabIndex = 0;
            this.lblSeatAvailableValue.Text = "0";

            // 
            // lblSeatAvailableLabel
            // 
            this.lblSeatAvailableLabel.AutoSize = true;
            this.lblSeatAvailableLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeatAvailableLabel.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblSeatAvailableLabel.Location = new System.Drawing.Point(35, 55);
            this.lblSeatAvailableLabel.Name = "lblSeatAvailableLabel";
            this.lblSeatAvailableLabel.Size = new System.Drawing.Size(131, 15);
            this.lblSeatAvailableLabel.TabIndex = 1;
            this.lblSeatAvailableLabel.Text = "Total Available Seats";

            // 
            // btnSeatRefresh
            // 
            this.btnSeatRefresh.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnSeatRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatRefresh.ForeColor = System.Drawing.Color.White;
            this.btnSeatRefresh.Location = new System.Drawing.Point(730, 225);
            this.btnSeatRefresh.Name = "btnSeatRefresh";
            this.btnSeatRefresh.Size = new System.Drawing.Size(125, 30);
            this.btnSeatRefresh.TabIndex = 4;
            this.btnSeatRefresh.Text = "🔄 Refresh Data";
            this.btnSeatRefresh.UseVisualStyleBackColor = false;

            // 
            // dgvSeatAvailability
            // 
            this.dgvSeatAvailability.AllowUserToAddRows = false;
            this.dgvSeatAvailability.AllowUserToDeleteRows = false;
            this.dgvSeatAvailability.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeatAvailability.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeatAvailability.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSeatAvailability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeatAvailability.Location = new System.Drawing.Point(25, 225);
            this.dgvSeatAvailability.Name = "dgvSeatAvailability";
            this.dgvSeatAvailability.ReadOnly = true;
            this.dgvSeatAvailability.RowHeadersVisible = false;
            this.dgvSeatAvailability.Size = new System.Drawing.Size(700, 365);
            this.dgvSeatAvailability.TabIndex = 5;
            this.dgvSeatAvailability.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSeatAvailability.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvSeatAvailability.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvSeatAvailability.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSeatAvailability.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvSeatAvailability.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.dgvSeatAvailability.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSeatAvailability.RowTemplate.Height = 35;

            // ============================================================
            // CONFIGURE EARNINGS PANEL (INLINE)
            // ============================================================
            // 
            // pnlEarnings
            // 
            this.pnlEarnings.Controls.Add(this.lblEarningsTitle);
            this.pnlEarnings.Controls.Add(this.lblEarningsSubTitle);
            this.pnlEarnings.Controls.Add(this.pnlEarningsStats);
            this.pnlEarnings.Controls.Add(this.splitEarnings);
            this.pnlEarnings.Controls.Add(this.pnlEarningsPayout);
            this.pnlEarnings.Controls.Add(this.btnEarningsRefresh);
            this.pnlEarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEarnings.Location = new System.Drawing.Point(0, 0);
            this.pnlEarnings.Name = "pnlEarnings";
            this.pnlEarnings.Padding = new System.Windows.Forms.Padding(25);
            this.pnlEarnings.Size = new System.Drawing.Size(880, 630);
            this.pnlEarnings.TabIndex = 5;
            this.pnlEarnings.Visible = false;

            // 
            // lblEarningsTitle
            // 
            this.lblEarningsTitle.AutoSize = true;
            this.lblEarningsTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblEarningsTitle.Location = new System.Drawing.Point(25, 25);
            this.lblEarningsTitle.Name = "lblEarningsTitle";
            this.lblEarningsTitle.Size = new System.Drawing.Size(267, 32);
            this.lblEarningsTitle.TabIndex = 0;
            this.lblEarningsTitle.Text = "💰 Earnings & Payout";

            // 
            // lblEarningsSubTitle
            // 
            this.lblEarningsSubTitle.AutoSize = true;
            this.lblEarningsSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEarningsSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblEarningsSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblEarningsSubTitle.Name = "lblEarningsSubTitle";
            this.lblEarningsSubTitle.Size = new System.Drawing.Size(253, 19);
            this.lblEarningsSubTitle.TabIndex = 1;
            this.lblEarningsSubTitle.Text = "Track your earnings and manage payouts";

            // 
            // pnlEarningsStats
            // 
            this.pnlEarningsStats.Controls.Add(this.pnlEarningsTotal);
            this.pnlEarningsStats.Controls.Add(this.pnlEarningsBalance);
            this.pnlEarningsStats.Controls.Add(this.pnlEarningsFee);
            this.pnlEarningsStats.Controls.Add(this.pnlEarningsStudents);
            this.pnlEarningsStats.Location = new System.Drawing.Point(25, 85);
            this.pnlEarningsStats.Name = "pnlEarningsStats";
            this.pnlEarningsStats.Size = new System.Drawing.Size(830, 80);
            this.pnlEarningsStats.TabIndex = 2;

            // 
            // pnlEarningsTotal
            // 
            this.pnlEarningsTotal.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlEarningsTotal.Controls.Add(this.lblEarningsTotalValue);
            this.pnlEarningsTotal.Controls.Add(this.lblEarningsTotalLabel);
            this.pnlEarningsTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlEarningsTotal.Name = "pnlEarningsTotal";
            this.pnlEarningsTotal.Size = new System.Drawing.Size(200, 80);
            this.pnlEarningsTotal.TabIndex = 0;

            // 
            // lblEarningsTotalValue
            // 
            this.lblEarningsTotalValue.AutoSize = true;
            this.lblEarningsTotalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEarningsTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblEarningsTotalValue.Location = new System.Drawing.Point(30, 15);
            this.lblEarningsTotalValue.Name = "lblEarningsTotalValue";
            this.lblEarningsTotalValue.Size = new System.Drawing.Size(87, 37);
            this.lblEarningsTotalValue.TabIndex = 0;
            this.lblEarningsTotalValue.Text = "৳ 0";

            // 
            // lblEarningsTotalLabel
            // 
            this.lblEarningsTotalLabel.AutoSize = true;
            this.lblEarningsTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEarningsTotalLabel.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblEarningsTotalLabel.Location = new System.Drawing.Point(45, 55);
            this.lblEarningsTotalLabel.Name = "lblEarningsTotalLabel";
            this.lblEarningsTotalLabel.Size = new System.Drawing.Size(90, 15);
            this.lblEarningsTotalLabel.TabIndex = 1;
            this.lblEarningsTotalLabel.Text = "Total Earnings";

            // 
            // pnlEarningsBalance
            // 
            this.pnlEarningsBalance.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlEarningsBalance.Controls.Add(this.lblEarningsBalanceValue);
            this.pnlEarningsBalance.Controls.Add(this.lblEarningsBalanceLabel);
            this.pnlEarningsBalance.Location = new System.Drawing.Point(210, 0);
            this.pnlEarningsBalance.Name = "pnlEarningsBalance";
            this.pnlEarningsBalance.Size = new System.Drawing.Size(200, 80);
            this.pnlEarningsBalance.TabIndex = 1;

            // 
            // lblEarningsBalanceValue
            // 
            this.lblEarningsBalanceValue.AutoSize = true;
            this.lblEarningsBalanceValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEarningsBalanceValue.ForeColor = System.Drawing.Color.White;
            this.lblEarningsBalanceValue.Location = new System.Drawing.Point(30, 15);
            this.lblEarningsBalanceValue.Name = "lblEarningsBalanceValue";
            this.lblEarningsBalanceValue.Size = new System.Drawing.Size(87, 37);
            this.lblEarningsBalanceValue.TabIndex = 0;
            this.lblEarningsBalanceValue.Text = "৳ 0";

            // 
            // lblEarningsBalanceLabel
            // 
            this.lblEarningsBalanceLabel.AutoSize = true;
            this.lblEarningsBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEarningsBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblEarningsBalanceLabel.Location = new System.Drawing.Point(10, 60);
            this.lblEarningsBalanceLabel.Name = "lblEarningsBalanceLabel";
            this.lblEarningsBalanceLabel.Size = new System.Drawing.Size(173, 13);
            this.lblEarningsBalanceLabel.TabIndex = 1;
            this.lblEarningsBalanceLabel.Text = "Available Balance (after 20% fee)";

            // 
            // pnlEarningsFee
            // 
            this.pnlEarningsFee.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlEarningsFee.Controls.Add(this.lblEarningsFeeValue);
            this.pnlEarningsFee.Controls.Add(this.lblEarningsFeeLabel);
            this.pnlEarningsFee.Location = new System.Drawing.Point(420, 0);
            this.pnlEarningsFee.Name = "pnlEarningsFee";
            this.pnlEarningsFee.Size = new System.Drawing.Size(200, 80);
            this.pnlEarningsFee.TabIndex = 2;

            // 
            // lblEarningsFeeValue
            // 
            this.lblEarningsFeeValue.AutoSize = true;
            this.lblEarningsFeeValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEarningsFeeValue.ForeColor = System.Drawing.Color.White;
            this.lblEarningsFeeValue.Location = new System.Drawing.Point(30, 15);
            this.lblEarningsFeeValue.Name = "lblEarningsFeeValue";
            this.lblEarningsFeeValue.Size = new System.Drawing.Size(87, 37);
            this.lblEarningsFeeValue.TabIndex = 0;
            this.lblEarningsFeeValue.Text = "৳ 0";

            // 
            // lblEarningsFeeLabel
            // 
            this.lblEarningsFeeLabel.AutoSize = true;
            this.lblEarningsFeeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEarningsFeeLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 150);
            this.lblEarningsFeeLabel.Location = new System.Drawing.Point(45, 55);
            this.lblEarningsFeeLabel.Name = "lblEarningsFeeLabel";
            this.lblEarningsFeeLabel.Size = new System.Drawing.Size(102, 15);
            this.lblEarningsFeeLabel.TabIndex = 1;
            this.lblEarningsFeeLabel.Text = "Platform Fee (20%)";

            // 
            // pnlEarningsStudents
            // 
            this.pnlEarningsStudents.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.pnlEarningsStudents.Controls.Add(this.lblEarningsStudentsValue);
            this.pnlEarningsStudents.Controls.Add(this.lblEarningsStudentsLabel);
            this.pnlEarningsStudents.Location = new System.Drawing.Point(630, 0);
            this.pnlEarningsStudents.Name = "pnlEarningsStudents";
            this.pnlEarningsStudents.Size = new System.Drawing.Size(200, 80);
            this.pnlEarningsStudents.TabIndex = 3;

            // 
            // lblEarningsStudentsValue
            // 
            this.lblEarningsStudentsValue.AutoSize = true;
            this.lblEarningsStudentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEarningsStudentsValue.ForeColor = System.Drawing.Color.White;
            this.lblEarningsStudentsValue.Location = new System.Drawing.Point(75, 15);
            this.lblEarningsStudentsValue.Name = "lblEarningsStudentsValue";
            this.lblEarningsStudentsValue.Size = new System.Drawing.Size(32, 37);
            this.lblEarningsStudentsValue.TabIndex = 0;
            this.lblEarningsStudentsValue.Text = "0";

            // 
            // lblEarningsStudentsLabel
            // 
            this.lblEarningsStudentsLabel.AutoSize = true;
            this.lblEarningsStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEarningsStudentsLabel.ForeColor = System.Drawing.Color.FromArgb(210, 200, 230);
            this.lblEarningsStudentsLabel.Location = new System.Drawing.Point(45, 55);
            this.lblEarningsStudentsLabel.Name = "lblEarningsStudentsLabel";
            this.lblEarningsStudentsLabel.Size = new System.Drawing.Size(95, 15);
            this.lblEarningsStudentsLabel.TabIndex = 1;
            this.lblEarningsStudentsLabel.Text = "Total Students";

            // 
            // splitEarnings
            // 
            this.splitEarnings.Location = new System.Drawing.Point(25, 180);
            this.splitEarnings.Name = "splitEarnings";
            this.splitEarnings.Size = new System.Drawing.Size(830, 230);
            this.splitEarnings.SplitterDistance = 400;
            this.splitEarnings.TabIndex = 3;

            // 
            // pnlEarningsCourse
            // 
            this.pnlEarningsCourse.Controls.Add(this.lblEarningsCourseTitle);
            this.pnlEarningsCourse.Controls.Add(this.dgvEarningsCourse);
            this.pnlEarningsCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEarningsCourse.Location = new System.Drawing.Point(0, 0);
            this.pnlEarningsCourse.Name = "pnlEarningsCourse";
            this.pnlEarningsCourse.Size = new System.Drawing.Size(400, 230);
            this.pnlEarningsCourse.TabIndex = 0;

            // 
            // lblEarningsCourseTitle
            // 
            this.lblEarningsCourseTitle.AutoSize = true;
            this.lblEarningsCourseTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEarningsCourseTitle.Location = new System.Drawing.Point(10, 10);
            this.lblEarningsCourseTitle.Name = "lblEarningsCourseTitle";
            this.lblEarningsCourseTitle.Size = new System.Drawing.Size(200, 19);
            this.lblEarningsCourseTitle.TabIndex = 0;
            this.lblEarningsCourseTitle.Text = "📊 Course Earnings Breakdown";

            // 
            // dgvEarningsCourse
            // 
            this.dgvEarningsCourse.AllowUserToAddRows = false;
            this.dgvEarningsCourse.AllowUserToDeleteRows = false;
            this.dgvEarningsCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEarningsCourse.BackgroundColor = System.Drawing.Color.White;
            this.dgvEarningsCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEarningsCourse.Location = new System.Drawing.Point(10, 35);
            this.dgvEarningsCourse.Name = "dgvEarningsCourse";
            this.dgvEarningsCourse.ReadOnly = true;
            this.dgvEarningsCourse.RowHeadersVisible = false;
            this.dgvEarningsCourse.Size = new System.Drawing.Size(380, 185);
            this.dgvEarningsCourse.TabIndex = 1;
            this.dgvEarningsCourse.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvEarningsCourse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvEarningsCourse.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvEarningsCourse.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEarningsCourse.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvEarningsCourse.RowTemplate.Height = 30;

            // 
            // pnlEarningsHistory
            // 
            this.pnlEarningsHistory.Controls.Add(this.lblEarningsHistoryTitle);
            this.pnlEarningsHistory.Controls.Add(this.dgvEarningsHistory);
            this.pnlEarningsHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEarningsHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlEarningsHistory.Name = "pnlEarningsHistory";
            this.pnlEarningsHistory.Size = new System.Drawing.Size(426, 230);
            this.pnlEarningsHistory.TabIndex = 1;

            // 
            // lblEarningsHistoryTitle
            // 
            this.lblEarningsHistoryTitle.AutoSize = true;
            this.lblEarningsHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEarningsHistoryTitle.Location = new System.Drawing.Point(10, 10);
            this.lblEarningsHistoryTitle.Name = "lblEarningsHistoryTitle";
            this.lblEarningsHistoryTitle.Size = new System.Drawing.Size(150, 19);
            this.lblEarningsHistoryTitle.TabIndex = 0;
            this.lblEarningsHistoryTitle.Text = "📜 Payout History";

            // 
            // dgvEarningsHistory
            // 
            this.dgvEarningsHistory.AllowUserToAddRows = false;
            this.dgvEarningsHistory.AllowUserToDeleteRows = false;
            this.dgvEarningsHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEarningsHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvEarningsHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEarningsHistory.Location = new System.Drawing.Point(10, 35);
            this.dgvEarningsHistory.Name = "dgvEarningsHistory";
            this.dgvEarningsHistory.ReadOnly = true;
            this.dgvEarningsHistory.RowHeadersVisible = false;
            this.dgvEarningsHistory.Size = new System.Drawing.Size(406, 185);
            this.dgvEarningsHistory.TabIndex = 1;
            this.dgvEarningsHistory.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvEarningsHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvEarningsHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvEarningsHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEarningsHistory.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvEarningsHistory.RowTemplate.Height = 30;

            // 
            // pnlEarningsPayout
            // 
            this.pnlEarningsPayout.BackColor = System.Drawing.Color.White;
            this.pnlEarningsPayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEarningsPayout.Controls.Add(this.lblEarningsPayoutTitle);
            this.pnlEarningsPayout.Controls.Add(this.lblEarningsPayoutAmount);
            this.pnlEarningsPayout.Controls.Add(this.txtEarningsPayoutAmount);
            this.pnlEarningsPayout.Controls.Add(this.btnEarningsPayoutRequest);
            this.pnlEarningsPayout.Controls.Add(this.lblEarningsMaxAmount);
            this.pnlEarningsPayout.Location = new System.Drawing.Point(25, 430);
            this.pnlEarningsPayout.Name = "pnlEarningsPayout";
            this.pnlEarningsPayout.Size = new System.Drawing.Size(830, 85);
            this.pnlEarningsPayout.TabIndex = 4;

            // 
            // lblEarningsPayoutTitle
            // 
            this.lblEarningsPayoutTitle.AutoSize = true;
            this.lblEarningsPayoutTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEarningsPayoutTitle.Location = new System.Drawing.Point(20, 10);
            this.lblEarningsPayoutTitle.Name = "lblEarningsPayoutTitle";
            this.lblEarningsPayoutTitle.Size = new System.Drawing.Size(155, 19);
            this.lblEarningsPayoutTitle.TabIndex = 0;
            this.lblEarningsPayoutTitle.Text = "💰 Request Payout";

            // 
            // lblEarningsPayoutAmount
            // 
            this.lblEarningsPayoutAmount.AutoSize = true;
            this.lblEarningsPayoutAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEarningsPayoutAmount.Location = new System.Drawing.Point(20, 40);
            this.lblEarningsPayoutAmount.Name = "lblEarningsPayoutAmount";
            this.lblEarningsPayoutAmount.Size = new System.Drawing.Size(88, 19);
            this.lblEarningsPayoutAmount.TabIndex = 1;
            this.lblEarningsPayoutAmount.Text = "Amount (৳):";

            // 
            // txtEarningsPayoutAmount
            // 
            this.txtEarningsPayoutAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEarningsPayoutAmount.Location = new System.Drawing.Point(115, 37);
            this.txtEarningsPayoutAmount.Name = "txtEarningsPayoutAmount";
            this.txtEarningsPayoutAmount.Size = new System.Drawing.Size(150, 25);
            this.txtEarningsPayoutAmount.TabIndex = 2;
            this.txtEarningsPayoutAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // btnEarningsPayoutRequest
            // 
            this.btnEarningsPayoutRequest.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnEarningsPayoutRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEarningsPayoutRequest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEarningsPayoutRequest.ForeColor = System.Drawing.Color.White;
            this.btnEarningsPayoutRequest.Location = new System.Drawing.Point(285, 35);
            this.btnEarningsPayoutRequest.Name = "btnEarningsPayoutRequest";
            this.btnEarningsPayoutRequest.Size = new System.Drawing.Size(140, 30);
            this.btnEarningsPayoutRequest.TabIndex = 3;
            this.btnEarningsPayoutRequest.Text = "💳 Request Payout";
            this.btnEarningsPayoutRequest.UseVisualStyleBackColor = false;

            // 
            // lblEarningsMaxAmount
            // 
            this.lblEarningsMaxAmount.AutoSize = true;
            this.lblEarningsMaxAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEarningsMaxAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblEarningsMaxAmount.Location = new System.Drawing.Point(115, 65);
            this.lblEarningsMaxAmount.Name = "lblEarningsMaxAmount";
            this.lblEarningsMaxAmount.Size = new System.Drawing.Size(100, 15);
            this.lblEarningsMaxAmount.TabIndex = 4;
            this.lblEarningsMaxAmount.Text = "Max: ৳ 0.00";

            // 
            // btnEarningsRefresh
            // 
            this.btnEarningsRefresh.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnEarningsRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEarningsRefresh.ForeColor = System.Drawing.Color.White;
            this.btnEarningsRefresh.Location = new System.Drawing.Point(730, 430);
            this.btnEarningsRefresh.Name = "btnEarningsRefresh";
            this.btnEarningsRefresh.Size = new System.Drawing.Size(125, 30);
            this.btnEarningsRefresh.TabIndex = 5;
            this.btnEarningsRefresh.Text = "🔄 Refresh";
            this.btnEarningsRefresh.UseVisualStyleBackColor = false;

            // ============================================================
            // CONFIGURE STUDENTS PANEL (INLINE)
            // ============================================================
            // 
            // pnlStudents
            // 
            this.pnlStudents.Controls.Add(this.lblStudentsTitle);
            this.pnlStudents.Controls.Add(this.lblStudentsSubTitle);
            this.pnlStudents.Controls.Add(this.pnlStudentStats);
            this.pnlStudents.Controls.Add(this.txtStudentSearch);
            this.pnlStudents.Controls.Add(this.btnStudentSearch);
            this.pnlStudents.Controls.Add(this.dgvStudents);
            this.pnlStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudents.Location = new System.Drawing.Point(0, 0);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.Padding = new System.Windows.Forms.Padding(25);
            this.pnlStudents.Size = new System.Drawing.Size(880, 630);
            this.pnlStudents.TabIndex = 1;
            this.pnlStudents.Visible = false;

            // 
            // lblStudentsTitle
            // 
            this.lblStudentsTitle.AutoSize = true;
            this.lblStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStudentsTitle.Location = new System.Drawing.Point(25, 25);
            this.lblStudentsTitle.Name = "lblStudentsTitle";
            this.lblStudentsTitle.Size = new System.Drawing.Size(247, 32);
            this.lblStudentsTitle.TabIndex = 0;
            this.lblStudentsTitle.Text = "👨‍🎓 Student Management";

            // 
            // lblStudentsSubTitle
            // 
            this.lblStudentsSubTitle.AutoSize = true;
            this.lblStudentsSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStudentsSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblStudentsSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblStudentsSubTitle.Name = "lblStudentsSubTitle";
            this.lblStudentsSubTitle.Size = new System.Drawing.Size(193, 19);
            this.lblStudentsSubTitle.TabIndex = 1;
            this.lblStudentsSubTitle.Text = "Manage your enrolled students";

            // 
            // pnlStudentStats
            // 
            this.pnlStudentStats.Controls.Add(this.pnlTotalStudents);
            this.pnlStudentStats.Controls.Add(this.pnlActiveStudents);
            this.pnlStudentStats.Controls.Add(this.pnlNewStudents);
            this.pnlStudentStats.Location = new System.Drawing.Point(25, 85);
            this.pnlStudentStats.Name = "pnlStudentStats";
            this.pnlStudentStats.Size = new System.Drawing.Size(830, 80);
            this.pnlStudentStats.TabIndex = 2;

            // 
            // pnlTotalStudents
            // 
            this.pnlTotalStudents.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlTotalStudents.Controls.Add(this.lblTotalStudentsValue);
            this.pnlTotalStudents.Controls.Add(this.lblTotalStudentsLabel);
            this.pnlTotalStudents.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalStudents.Name = "pnlTotalStudents";
            this.pnlTotalStudents.Size = new System.Drawing.Size(270, 80);
            this.pnlTotalStudents.TabIndex = 0;

            // 
            // lblTotalStudentsValue
            // 
            this.lblTotalStudentsValue.AutoSize = true;
            this.lblTotalStudentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudentsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalStudentsValue.Location = new System.Drawing.Point(110, 15);
            this.lblTotalStudentsValue.Name = "lblTotalStudentsValue";
            this.lblTotalStudentsValue.Size = new System.Drawing.Size(32, 37);
            this.lblTotalStudentsValue.TabIndex = 0;
            this.lblTotalStudentsValue.Text = "0";

            // 
            // lblTotalStudentsLabel
            // 
            this.lblTotalStudentsLabel.AutoSize = true;
            this.lblTotalStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalStudentsLabel.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblTotalStudentsLabel.Location = new System.Drawing.Point(100, 55);
            this.lblTotalStudentsLabel.Name = "lblTotalStudentsLabel";
            this.lblTotalStudentsLabel.Size = new System.Drawing.Size(98, 19);
            this.lblTotalStudentsLabel.TabIndex = 1;
            this.lblTotalStudentsLabel.Text = "Total Students";

            // 
            // pnlActiveStudents
            // 
            this.pnlActiveStudents.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlActiveStudents.Controls.Add(this.lblActiveStudentsValue);
            this.pnlActiveStudents.Controls.Add(this.lblActiveStudentsLabel);
            this.pnlActiveStudents.Location = new System.Drawing.Point(280, 0);
            this.pnlActiveStudents.Name = "pnlActiveStudents";
            this.pnlActiveStudents.Size = new System.Drawing.Size(270, 80);
            this.pnlActiveStudents.TabIndex = 1;

            // 
            // lblActiveStudentsValue
            // 
            this.lblActiveStudentsValue.AutoSize = true;
            this.lblActiveStudentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblActiveStudentsValue.ForeColor = System.Drawing.Color.White;
            this.lblActiveStudentsValue.Location = new System.Drawing.Point(110, 15);
            this.lblActiveStudentsValue.Name = "lblActiveStudentsValue";
            this.lblActiveStudentsValue.Size = new System.Drawing.Size(32, 37);
            this.lblActiveStudentsValue.TabIndex = 0;
            this.lblActiveStudentsValue.Text = "0";

            // 
            // lblActiveStudentsLabel
            // 
            this.lblActiveStudentsLabel.AutoSize = true;
            this.lblActiveStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveStudentsLabel.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblActiveStudentsLabel.Location = new System.Drawing.Point(105, 55);
            this.lblActiveStudentsLabel.Name = "lblActiveStudentsLabel";
            this.lblActiveStudentsLabel.Size = new System.Drawing.Size(49, 19);
            this.lblActiveStudentsLabel.TabIndex = 1;
            this.lblActiveStudentsLabel.Text = "Active";

            // 
            // pnlNewStudents
            // 
            this.pnlNewStudents.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlNewStudents.Controls.Add(this.lblNewStudentsValue);
            this.pnlNewStudents.Controls.Add(this.lblNewStudentsLabel);
            this.pnlNewStudents.Location = new System.Drawing.Point(560, 0);
            this.pnlNewStudents.Name = "pnlNewStudents";
            this.pnlNewStudents.Size = new System.Drawing.Size(270, 80);
            this.pnlNewStudents.TabIndex = 2;

            // 
            // lblNewStudentsValue
            // 
            this.lblNewStudentsValue.AutoSize = true;
            this.lblNewStudentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNewStudentsValue.ForeColor = System.Drawing.Color.White;
            this.lblNewStudentsValue.Location = new System.Drawing.Point(110, 15);
            this.lblNewStudentsValue.Name = "lblNewStudentsValue";
            this.lblNewStudentsValue.Size = new System.Drawing.Size(32, 37);
            this.lblNewStudentsValue.TabIndex = 0;
            this.lblNewStudentsValue.Text = "0";

            // 
            // lblNewStudentsLabel
            // 
            this.lblNewStudentsLabel.AutoSize = true;
            this.lblNewStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewStudentsLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 150);
            this.lblNewStudentsLabel.Location = new System.Drawing.Point(100, 55);
            this.lblNewStudentsLabel.Name = "lblNewStudentsLabel";
            this.lblNewStudentsLabel.Size = new System.Drawing.Size(66, 19);
            this.lblNewStudentsLabel.TabIndex = 1;
            this.lblNewStudentsLabel.Text = "New (30d)";

            // 
            // txtStudentSearch
            // 
            this.txtStudentSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStudentSearch.Location = new System.Drawing.Point(25, 180);
            this.txtStudentSearch.Name = "txtStudentSearch";
            this.txtStudentSearch.Size = new System.Drawing.Size(250, 25);
            this.txtStudentSearch.TabIndex = 3;
            this.txtStudentSearch.Text = "Search students...";

            // 
            // btnStudentSearch
            // 
            this.btnStudentSearch.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnStudentSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentSearch.ForeColor = System.Drawing.Color.White;
            this.btnStudentSearch.Location = new System.Drawing.Point(280, 178);
            this.btnStudentSearch.Name = "btnStudentSearch";
            this.btnStudentSearch.Size = new System.Drawing.Size(100, 28);
            this.btnStudentSearch.TabIndex = 4;
            this.btnStudentSearch.Text = "🔍 Search";
            this.btnStudentSearch.UseVisualStyleBackColor = false;

            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(25, 220);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.Size = new System.Drawing.Size(830, 370);
            this.dgvStudents.TabIndex = 5;
            this.dgvStudents.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvStudents.RowTemplate.Height = 35;

            // ============================================================
            // CONFIGURE REVIEWS PANEL (INLINE)
            // ============================================================
            // 
            // pnlReviews
            // 
            this.pnlReviews.Controls.Add(this.lblReviewsTitle);
            this.pnlReviews.Controls.Add(this.lblReviewsSubTitle);
            this.pnlReviews.Controls.Add(this.pnlReviewStats);
            this.pnlReviews.Controls.Add(this.dgvReviews);
            this.pnlReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReviews.Location = new System.Drawing.Point(0, 0);
            this.pnlReviews.Name = "pnlReviews";
            this.pnlReviews.Padding = new System.Windows.Forms.Padding(25);
            this.pnlReviews.Size = new System.Drawing.Size(880, 630);
            this.pnlReviews.TabIndex = 2;
            this.pnlReviews.Visible = false;

            // 
            // lblReviewsTitle
            // 
            this.lblReviewsTitle.AutoSize = true;
            this.lblReviewsTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblReviewsTitle.Location = new System.Drawing.Point(25, 25);
            this.lblReviewsTitle.Name = "lblReviewsTitle";
            this.lblReviewsTitle.Size = new System.Drawing.Size(251, 32);
            this.lblReviewsTitle.TabIndex = 0;
            this.lblReviewsTitle.Text = "⭐ Course Reviews & Ratings";

            // 
            // lblReviewsSubTitle
            // 
            this.lblReviewsSubTitle.AutoSize = true;
            this.lblReviewsSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReviewsSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblReviewsSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblReviewsSubTitle.Name = "lblReviewsSubTitle";
            this.lblReviewsSubTitle.Size = new System.Drawing.Size(195, 19);
            this.lblReviewsSubTitle.TabIndex = 1;
            this.lblReviewsSubTitle.Text = "Monitor student feedback and ratings";

            // 
            // pnlReviewStats
            // 
            this.pnlReviewStats.Controls.Add(this.pnlTotalReviews);
            this.pnlReviewStats.Controls.Add(this.pnlAverageRating);
            this.pnlReviewStats.Controls.Add(this.pnlFiveStar);
            this.pnlReviewStats.Location = new System.Drawing.Point(25, 85);
            this.pnlReviewStats.Name = "pnlReviewStats";
            this.pnlReviewStats.Size = new System.Drawing.Size(830, 80);
            this.pnlReviewStats.TabIndex = 2;

            // 
            // pnlTotalReviews
            // 
            this.pnlTotalReviews.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlTotalReviews.Controls.Add(this.lblTotalReviewsValue);
            this.pnlTotalReviews.Controls.Add(this.lblTotalReviewsLabel);
            this.pnlTotalReviews.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalReviews.Name = "pnlTotalReviews";
            this.pnlTotalReviews.Size = new System.Drawing.Size(270, 80);
            this.pnlTotalReviews.TabIndex = 0;

            // 
            // lblTotalReviewsValue
            // 
            this.lblTotalReviewsValue.AutoSize = true;
            this.lblTotalReviewsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalReviewsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalReviewsValue.Location = new System.Drawing.Point(110, 15);
            this.lblTotalReviewsValue.Name = "lblTotalReviewsValue";
            this.lblTotalReviewsValue.Size = new System.Drawing.Size(32, 37);
            this.lblTotalReviewsValue.TabIndex = 0;
            this.lblTotalReviewsValue.Text = "0";

            // 
            // lblTotalReviewsLabel
            // 
            this.lblTotalReviewsLabel.AutoSize = true;
            this.lblTotalReviewsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalReviewsLabel.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblTotalReviewsLabel.Location = new System.Drawing.Point(95, 55);
            this.lblTotalReviewsLabel.Name = "lblTotalReviewsLabel";
            this.lblTotalReviewsLabel.Size = new System.Drawing.Size(96, 19);
            this.lblTotalReviewsLabel.TabIndex = 1;
            this.lblTotalReviewsLabel.Text = "Total Reviews";

            // 
            // pnlAverageRating
            // 
            this.pnlAverageRating.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.pnlAverageRating.Controls.Add(this.lblAverageRatingValue);
            this.pnlAverageRating.Controls.Add(this.lblAverageRatingLabel);
            this.pnlAverageRating.Location = new System.Drawing.Point(280, 0);
            this.pnlAverageRating.Name = "pnlAverageRating";
            this.pnlAverageRating.Size = new System.Drawing.Size(270, 80);
            this.pnlAverageRating.TabIndex = 1;

            // 
            // lblAverageRatingValue
            // 
            this.lblAverageRatingValue.AutoSize = true;
            this.lblAverageRatingValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAverageRatingValue.ForeColor = System.Drawing.Color.White;
            this.lblAverageRatingValue.Location = new System.Drawing.Point(100, 15);
            this.lblAverageRatingValue.Name = "lblAverageRatingValue";
            this.lblAverageRatingValue.Size = new System.Drawing.Size(58, 37);
            this.lblAverageRatingValue.TabIndex = 0;
            this.lblAverageRatingValue.Text = "0.0";

            // 
            // lblAverageRatingLabel
            // 
            this.lblAverageRatingLabel.AutoSize = true;
            this.lblAverageRatingLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAverageRatingLabel.ForeColor = System.Drawing.Color.FromArgb(210, 200, 230);
            this.lblAverageRatingLabel.Location = new System.Drawing.Point(95, 55);
            this.lblAverageRatingLabel.Name = "lblAverageRatingLabel";
            this.lblAverageRatingLabel.Size = new System.Drawing.Size(106, 19);
            this.lblAverageRatingLabel.TabIndex = 1;
            this.lblAverageRatingLabel.Text = "Average Rating";

            // 
            // pnlFiveStar
            // 
            this.pnlFiveStar.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlFiveStar.Controls.Add(this.lblFiveStarValue);
            this.pnlFiveStar.Controls.Add(this.lblFiveStarLabel);
            this.pnlFiveStar.Location = new System.Drawing.Point(560, 0);
            this.pnlFiveStar.Name = "pnlFiveStar";
            this.pnlFiveStar.Size = new System.Drawing.Size(270, 80);
            this.pnlFiveStar.TabIndex = 2;

            // 
            // lblFiveStarValue
            // 
            this.lblFiveStarValue.AutoSize = true;
            this.lblFiveStarValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblFiveStarValue.ForeColor = System.Drawing.Color.White;
            this.lblFiveStarValue.Location = new System.Drawing.Point(110, 15);
            this.lblFiveStarValue.Name = "lblFiveStarValue";
            this.lblFiveStarValue.Size = new System.Drawing.Size(32, 37);
            this.lblFiveStarValue.TabIndex = 0;
            this.lblFiveStarValue.Text = "0";

            // 
            // lblFiveStarLabel
            // 
            this.lblFiveStarLabel.AutoSize = true;
            this.lblFiveStarLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiveStarLabel.ForeColor = System.Drawing.Color.FromArgb(200, 200, 150);
            this.lblFiveStarLabel.Location = new System.Drawing.Point(105, 55);
            this.lblFiveStarLabel.Name = "lblFiveStarLabel";
            this.lblFiveStarLabel.Size = new System.Drawing.Size(67, 19);
            this.lblFiveStarLabel.TabIndex = 1;
            this.lblFiveStarLabel.Text = "⭐ 5-Star";

            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.BackgroundColor = System.Drawing.Color.White;
            this.dgvReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Location = new System.Drawing.Point(25, 180);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.RowHeadersVisible = false;
            this.dgvReviews.Size = new System.Drawing.Size(830, 410);
            this.dgvReviews.TabIndex = 3;
            this.dgvReviews.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvReviews.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReviews.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvReviews.RowTemplate.Height = 35;

            // ============================================================
            // CONFIGURE STATUS STRIP
            // ============================================================
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus,
                this.lblRecordCount,
                this.lblLastUpdate});
            this.statusStrip.Location = new System.Drawing.Point(25, 570);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(830, 25);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";

            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 20);
            this.lblStatus.Text = "✅ Dashboard loaded";

            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(102, 20);
            this.lblRecordCount.Text = "Courses: 0";

            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(139, 20);
            this.lblLastUpdate.Text = "Last updated: Just now";

            // ============================================================
            // CONFIGURE FORM
            // ============================================================
            // 
            // frmInstructorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlContentArea);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInstructorDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkillBazaar - Instructor Dashboard";
        }

        #endregion

        // ============================================================
        // CONTROL DECLARATIONS
        // ============================================================

        // Main containers
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContentArea;
        private System.Windows.Forms.Panel pnlLogo;

        // Header
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInstructorName;
        private System.Windows.Forms.Label lblDate;

        // Sidebar buttons
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMyCourses;
        private System.Windows.Forms.Button btnSeatAvailability;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnEarnings;
        private System.Windows.Forms.Button btnReviews;
        private System.Windows.Forms.Button btnLogout;

        // Dashboard Panel
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCourseCount;
        private System.Windows.Forms.Panel pnlEnrollmentCount;
        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.Panel pnlAvgRating;
        private System.Windows.Forms.Label lblCourseCount;
        private System.Windows.Forms.Label lblCourseLabel;
        private System.Windows.Forms.Label lblEnrollmentCount;
        private System.Windows.Forms.Label lblEnrollmentLabel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBalanceLabel;
        private System.Windows.Forms.Label lblAvgRating;
        private System.Windows.Forms.Label lblRatingLabel;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnRequestPayout;
        private System.Windows.Forms.Button btnViewAllCourses;
        private System.Windows.Forms.DataGridView dgvDashboardCourses;

        // My Courses Panel
        private System.Windows.Forms.Panel pnlMyCourses;
        private System.Windows.Forms.Label lblMyCoursesTitle;
        private System.Windows.Forms.Label lblMyCoursesSubTitle;
        private System.Windows.Forms.Panel pnlMyCoursesSearch;
        private System.Windows.Forms.Label lblMyCoursesSearch;
        private System.Windows.Forms.TextBox txtMyCoursesSearch;
        private System.Windows.Forms.Button btnMyCoursesSearch;
        private System.Windows.Forms.Label lblMyCoursesFilter;
        private System.Windows.Forms.ComboBox cmbMyCoursesCategory;
        private System.Windows.Forms.Button btnMyCoursesAdd;
        private System.Windows.Forms.Button btnMyCoursesRefresh;
        private System.Windows.Forms.DataGridView dgvMyCourses;
        private System.Windows.Forms.Panel pnlMyCoursesForm;
        private System.Windows.Forms.Label lblMyCoursesFormTitle;
        private System.Windows.Forms.Label lblMyCoursesCourseTitle;
        private System.Windows.Forms.TextBox txtMyCoursesTitle;
        private System.Windows.Forms.Label lblMyCoursesPrice;
        private System.Windows.Forms.TextBox txtMyCoursesPrice;
        private System.Windows.Forms.Label lblMyCoursesSeats;
        private System.Windows.Forms.TextBox txtMyCoursesSeats;
        private System.Windows.Forms.Label lblMyCoursesCategory;
        private System.Windows.Forms.ComboBox cmbMyCoursesCategoryForm;
        private System.Windows.Forms.Label lblMyCoursesDescription;
        private System.Windows.Forms.TextBox txtMyCoursesDescription;
        private System.Windows.Forms.Button btnMyCoursesSave;
        private System.Windows.Forms.Button btnMyCoursesCancel;

        // Seat Availability Panel
        private System.Windows.Forms.Panel pnlSeatAvailability;
        private System.Windows.Forms.Label lblSeatTitle;
        private System.Windows.Forms.Label lblSeatSubTitle;
        private System.Windows.Forms.Panel pnlSeatWarning;
        private System.Windows.Forms.Label lblSeatWarningIcon;
        private System.Windows.Forms.Label lblSeatWarning;
        private System.Windows.Forms.Panel pnlSeatStats;
        private System.Windows.Forms.Panel pnlSeatTotalCourses;
        private System.Windows.Forms.Label lblSeatTotalCoursesValue;
        private System.Windows.Forms.Label lblSeatTotalCoursesLabel;
        private System.Windows.Forms.Panel pnlSeatLow;
        private System.Windows.Forms.Label lblSeatLowValue;
        private System.Windows.Forms.Label lblSeatLowLabel;
        private System.Windows.Forms.Panel pnlSeatCritical;
        private System.Windows.Forms.Label lblSeatCriticalValue;
        private System.Windows.Forms.Label lblSeatCriticalLabel;
        private System.Windows.Forms.Panel pnlSeatAvailable;
        private System.Windows.Forms.Label lblSeatAvailableValue;
        private System.Windows.Forms.Label lblSeatAvailableLabel;
        private System.Windows.Forms.Button btnSeatRefresh;
        private System.Windows.Forms.DataGridView dgvSeatAvailability;

        // Earnings Panel
        private System.Windows.Forms.Panel pnlEarnings;
        private System.Windows.Forms.Label lblEarningsTitle;
        private System.Windows.Forms.Label lblEarningsSubTitle;
        private System.Windows.Forms.Panel pnlEarningsStats;
        private System.Windows.Forms.Panel pnlEarningsTotal;
        private System.Windows.Forms.Label lblEarningsTotalValue;
        private System.Windows.Forms.Label lblEarningsTotalLabel;
        private System.Windows.Forms.Panel pnlEarningsBalance;
        private System.Windows.Forms.Label lblEarningsBalanceValue;
        private System.Windows.Forms.Label lblEarningsBalanceLabel;
        private System.Windows.Forms.Panel pnlEarningsFee;
        private System.Windows.Forms.Label lblEarningsFeeValue;
        private System.Windows.Forms.Label lblEarningsFeeLabel;
        private System.Windows.Forms.Panel pnlEarningsStudents;
        private System.Windows.Forms.Label lblEarningsStudentsValue;
        private System.Windows.Forms.Label lblEarningsStudentsLabel;
        private System.Windows.Forms.SplitContainer splitEarnings;
        private System.Windows.Forms.Panel pnlEarningsCourse;
        private System.Windows.Forms.Label lblEarningsCourseTitle;
        private System.Windows.Forms.DataGridView dgvEarningsCourse;
        private System.Windows.Forms.Panel pnlEarningsHistory;
        private System.Windows.Forms.Label lblEarningsHistoryTitle;
        private System.Windows.Forms.DataGridView dgvEarningsHistory;
        private System.Windows.Forms.Panel pnlEarningsPayout;
        private System.Windows.Forms.Label lblEarningsPayoutTitle;
        private System.Windows.Forms.Label lblEarningsPayoutAmount;
        private System.Windows.Forms.TextBox txtEarningsPayoutAmount;
        private System.Windows.Forms.Button btnEarningsPayoutRequest;
        private System.Windows.Forms.Label lblEarningsMaxAmount;
        private System.Windows.Forms.Button btnEarningsRefresh;

        // Students Panel
        private System.Windows.Forms.Panel pnlStudents;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Label lblStudentsSubTitle;
        private System.Windows.Forms.Panel pnlStudentStats;
        private System.Windows.Forms.Panel pnlTotalStudents;
        private System.Windows.Forms.Label lblTotalStudentsValue;
        private System.Windows.Forms.Label lblTotalStudentsLabel;
        private System.Windows.Forms.Panel pnlActiveStudents;
        private System.Windows.Forms.Label lblActiveStudentsValue;
        private System.Windows.Forms.Label lblActiveStudentsLabel;
        private System.Windows.Forms.Panel pnlNewStudents;
        private System.Windows.Forms.Label lblNewStudentsValue;
        private System.Windows.Forms.Label lblNewStudentsLabel;
        private System.Windows.Forms.TextBox txtStudentSearch;
        private System.Windows.Forms.Button btnStudentSearch;
        private System.Windows.Forms.DataGridView dgvStudents;

        // Reviews Panel
        private System.Windows.Forms.Panel pnlReviews;
        private System.Windows.Forms.Label lblReviewsTitle;
        private System.Windows.Forms.Label lblReviewsSubTitle;
        private System.Windows.Forms.Panel pnlReviewStats;
        private System.Windows.Forms.Panel pnlTotalReviews;
        private System.Windows.Forms.Label lblTotalReviewsValue;
        private System.Windows.Forms.Label lblTotalReviewsLabel;
        private System.Windows.Forms.Panel pnlAverageRating;
        private System.Windows.Forms.Label lblAverageRatingValue;
        private System.Windows.Forms.Label lblAverageRatingLabel;
        private System.Windows.Forms.Panel pnlFiveStar;
        private System.Windows.Forms.Label lblFiveStarValue;
        private System.Windows.Forms.Label lblFiveStarLabel;
        private System.Windows.Forms.DataGridView dgvReviews;

        // Status Strip
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
    }
}  