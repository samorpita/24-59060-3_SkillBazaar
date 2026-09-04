namespace SkillBazaar.Forms
{
    partial class frmEarningsDashboard
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlTotalEarnings = new System.Windows.Forms.Panel();
            this.lblTotalEarningsValue = new System.Windows.Forms.Label();
            this.lblTotalEarningsLabel = new System.Windows.Forms.Label();
            this.pnlAvailableBalance = new System.Windows.Forms.Panel();
            this.lblAvailableBalanceValue = new System.Windows.Forms.Label();
            this.lblAvailableBalanceLabel = new System.Windows.Forms.Label();
            this.pnlPlatformFee = new System.Windows.Forms.Panel();
            this.lblPlatformFeeValue = new System.Windows.Forms.Label();
            this.lblPlatformFeeLabel = new System.Windows.Forms.Label();
            this.pnlTotalStudents = new System.Windows.Forms.Panel();
            this.lblTotalStudentsValue = new System.Windows.Forms.Label();
            this.lblTotalStudentsLabel = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlCourseEarnings = new System.Windows.Forms.Panel();
            this.lblCourseEarningsTitle = new System.Windows.Forms.Label();
            this.dgvCourseEarnings = new System.Windows.Forms.DataGridView();
            this.pnlPayoutHistory = new System.Windows.Forms.Panel();
            this.lblPayoutHistoryTitle = new System.Windows.Forms.Label();
            this.dgvPayoutHistory = new System.Windows.Forms.DataGridView();
            this.pnlPayoutRequest = new System.Windows.Forms.Panel();
            this.lblPayoutRequestTitle = new System.Windows.Forms.Label();
            this.lblPayoutAmount = new System.Windows.Forms.Label();
            this.txtPayoutAmount = new System.Windows.Forms.TextBox();
            this.btnRequestPayout = new System.Windows.Forms.Button();
            this.lblMaxAmount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlTotalEarnings.SuspendLayout();
            this.pnlAvailableBalance.SuspendLayout();
            this.pnlPlatformFee.SuspendLayout();
            this.pnlTotalStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlCourseEarnings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseEarnings)).BeginInit();
            this.pnlPayoutHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayoutHistory)).BeginInit();
            this.pnlPayoutRequest.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1650, 1077);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.lblDateRange);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(45, 31, 45, 31);
            this.pnlHeader.Size = new System.Drawing.Size(1650, 123);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(94, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(405, 54);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "💰 Earnings & Payout";
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubHeader.Location = new System.Drawing.Point(98, 118);
            this.lblSubHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(368, 28);
            this.lblSubHeader.TabIndex = 1;
            this.lblSubHeader.Text = "Track your earnings and manage payouts";
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblDateRange.Location = new System.Drawing.Point(1245, 118);
            this.lblDateRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(0, 28);
            this.lblDateRange.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlStats);
            this.pnlContent.Controls.Add(this.splitContainer);
            this.pnlContent.Controls.Add(this.pnlPayoutRequest);
            this.pnlContent.Controls.Add(this.btnRefresh);
            this.pnlContent.Controls.Add(this.statusStrip);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(45, 46, 45, 46);
            this.pnlContent.Size = new System.Drawing.Size(1650, 1077);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlTotalEarnings);
            this.pnlStats.Controls.Add(this.pnlAvailableBalance);
            this.pnlStats.Controls.Add(this.pnlPlatformFee);
            this.pnlStats.Controls.Add(this.pnlTotalStudents);
            this.pnlStats.Location = new System.Drawing.Point(45, 0);
            this.pnlStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1560, 154);
            this.pnlStats.TabIndex = 0;
            // 
            // pnlTotalEarnings
            // 
            this.pnlTotalEarnings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlTotalEarnings.Controls.Add(this.lblTotalEarningsValue);
            this.pnlTotalEarnings.Controls.Add(this.lblTotalEarningsLabel);
            this.pnlTotalEarnings.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalEarnings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTotalEarnings.Name = "pnlTotalEarnings";
            this.pnlTotalEarnings.Size = new System.Drawing.Size(368, 154);
            this.pnlTotalEarnings.TabIndex = 0;
            // 
            // lblTotalEarningsValue
            // 
            this.lblTotalEarningsValue.AutoSize = true;
            this.lblTotalEarningsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalEarningsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalEarningsValue.Location = new System.Drawing.Point(45, 38);
            this.lblTotalEarningsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEarningsValue.Name = "lblTotalEarningsValue";
            this.lblTotalEarningsValue.Size = new System.Drawing.Size(98, 60);
            this.lblTotalEarningsValue.TabIndex = 0;
            this.lblTotalEarningsValue.Text = "৳ 0";
            // 
            // lblTotalEarningsLabel
            // 
            this.lblTotalEarningsLabel.AutoSize = true;
            this.lblTotalEarningsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalEarningsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.lblTotalEarningsLabel.Location = new System.Drawing.Point(45, 108);
            this.lblTotalEarningsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEarningsLabel.Name = "lblTotalEarningsLabel";
            this.lblTotalEarningsLabel.Size = new System.Drawing.Size(133, 28);
            this.lblTotalEarningsLabel.TabIndex = 1;
            this.lblTotalEarningsLabel.Text = "Total Earnings";
            // 
            // pnlAvailableBalance
            // 
            this.pnlAvailableBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlAvailableBalance.Controls.Add(this.lblAvailableBalanceValue);
            this.pnlAvailableBalance.Controls.Add(this.lblAvailableBalanceLabel);
            this.pnlAvailableBalance.Location = new System.Drawing.Point(398, 0);
            this.pnlAvailableBalance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAvailableBalance.Name = "pnlAvailableBalance";
            this.pnlAvailableBalance.Size = new System.Drawing.Size(368, 154);
            this.pnlAvailableBalance.TabIndex = 1;
            // 
            // lblAvailableBalanceValue
            // 
            this.lblAvailableBalanceValue.AutoSize = true;
            this.lblAvailableBalanceValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAvailableBalanceValue.ForeColor = System.Drawing.Color.White;
            this.lblAvailableBalanceValue.Location = new System.Drawing.Point(45, 38);
            this.lblAvailableBalanceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvailableBalanceValue.Name = "lblAvailableBalanceValue";
            this.lblAvailableBalanceValue.Size = new System.Drawing.Size(98, 60);
            this.lblAvailableBalanceValue.TabIndex = 0;
            this.lblAvailableBalanceValue.Text = "৳ 0";
            // 
            // lblAvailableBalanceLabel
            // 
            this.lblAvailableBalanceLabel.AutoSize = true;
            this.lblAvailableBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailableBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.lblAvailableBalanceLabel.Location = new System.Drawing.Point(45, 108);
            this.lblAvailableBalanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvailableBalanceLabel.Name = "lblAvailableBalanceLabel";
            this.lblAvailableBalanceLabel.Size = new System.Drawing.Size(267, 25);
            this.lblAvailableBalanceLabel.TabIndex = 1;
            this.lblAvailableBalanceLabel.Text = "Available Balance (after 20% fee)";
            // 
            // pnlPlatformFee
            // 
            this.pnlPlatformFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.pnlPlatformFee.Controls.Add(this.lblPlatformFeeValue);
            this.pnlPlatformFee.Controls.Add(this.lblPlatformFeeLabel);
            this.pnlPlatformFee.Location = new System.Drawing.Point(795, 0);
            this.pnlPlatformFee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlPlatformFee.Name = "pnlPlatformFee";
            this.pnlPlatformFee.Size = new System.Drawing.Size(368, 154);
            this.pnlPlatformFee.TabIndex = 2;
            // 
            // lblPlatformFeeValue
            // 
            this.lblPlatformFeeValue.AutoSize = true;
            this.lblPlatformFeeValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPlatformFeeValue.ForeColor = System.Drawing.Color.White;
            this.lblPlatformFeeValue.Location = new System.Drawing.Point(45, 38);
            this.lblPlatformFeeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlatformFeeValue.Name = "lblPlatformFeeValue";
            this.lblPlatformFeeValue.Size = new System.Drawing.Size(98, 60);
            this.lblPlatformFeeValue.TabIndex = 0;
            this.lblPlatformFeeValue.Text = "৳ 0";
            // 
            // lblPlatformFeeLabel
            // 
            this.lblPlatformFeeLabel.AutoSize = true;
            this.lblPlatformFeeLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlatformFeeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.lblPlatformFeeLabel.Location = new System.Drawing.Point(45, 108);
            this.lblPlatformFeeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlatformFeeLabel.Name = "lblPlatformFeeLabel";
            this.lblPlatformFeeLabel.Size = new System.Drawing.Size(177, 28);
            this.lblPlatformFeeLabel.TabIndex = 1;
            this.lblPlatformFeeLabel.Text = "Platform Fee (20%)";
            // 
            // pnlTotalStudents
            // 
            this.pnlTotalStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlTotalStudents.Controls.Add(this.lblTotalStudentsValue);
            this.pnlTotalStudents.Controls.Add(this.lblTotalStudentsLabel);
            this.pnlTotalStudents.Location = new System.Drawing.Point(1192, 0);
            this.pnlTotalStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTotalStudents.Name = "pnlTotalStudents";
            this.pnlTotalStudents.Size = new System.Drawing.Size(368, 154);
            this.pnlTotalStudents.TabIndex = 3;
            // 
            // lblTotalStudentsValue
            // 
            this.lblTotalStudentsValue.AutoSize = true;
            this.lblTotalStudentsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudentsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalStudentsValue.Location = new System.Drawing.Point(45, 38);
            this.lblTotalStudentsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalStudentsValue.Name = "lblTotalStudentsValue";
            this.lblTotalStudentsValue.Size = new System.Drawing.Size(50, 60);
            this.lblTotalStudentsValue.TabIndex = 0;
            this.lblTotalStudentsValue.Text = "0";
            // 
            // lblTotalStudentsLabel
            // 
            this.lblTotalStudentsLabel.AutoSize = true;
            this.lblTotalStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalStudentsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblTotalStudentsLabel.Location = new System.Drawing.Point(45, 108);
            this.lblTotalStudentsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalStudentsLabel.Name = "lblTotalStudentsLabel";
            this.lblTotalStudentsLabel.Size = new System.Drawing.Size(135, 28);
            this.lblTotalStudentsLabel.TabIndex = 1;
            this.lblTotalStudentsLabel.Text = "Total Students";
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(45, 177);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlCourseEarnings);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlPayoutHistory);
            this.splitContainer.Size = new System.Drawing.Size(1560, 431);
            this.splitContainer.SplitterDistance = 750;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 1;
            // 
            // pnlCourseEarnings
            // 
            this.pnlCourseEarnings.Controls.Add(this.lblCourseEarningsTitle);
            this.pnlCourseEarnings.Controls.Add(this.dgvCourseEarnings);
            this.pnlCourseEarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCourseEarnings.Location = new System.Drawing.Point(0, 0);
            this.pnlCourseEarnings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlCourseEarnings.Name = "pnlCourseEarnings";
            this.pnlCourseEarnings.Size = new System.Drawing.Size(750, 431);
            this.pnlCourseEarnings.TabIndex = 0;
            // 
            // lblCourseEarningsTitle
            // 
            this.lblCourseEarningsTitle.AutoSize = true;
            this.lblCourseEarningsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCourseEarningsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCourseEarningsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseEarningsTitle.Name = "lblCourseEarningsTitle";
            this.lblCourseEarningsTitle.Size = new System.Drawing.Size(375, 32);
            this.lblCourseEarningsTitle.TabIndex = 0;
            this.lblCourseEarningsTitle.Text = "📊 Course Earnings Breakdown";
            // 
            // dgvCourseEarnings
            // 
            this.dgvCourseEarnings.AllowUserToAddRows = false;
            this.dgvCourseEarnings.AllowUserToDeleteRows = false;
            this.dgvCourseEarnings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourseEarnings.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourseEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourseEarnings.ColumnHeadersHeight = 34;
            this.dgvCourseEarnings.Location = new System.Drawing.Point(15, 62);
            this.dgvCourseEarnings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCourseEarnings.Name = "dgvCourseEarnings";
            this.dgvCourseEarnings.ReadOnly = true;
            this.dgvCourseEarnings.RowHeadersVisible = false;
            this.dgvCourseEarnings.RowHeadersWidth = 62;
            this.dgvCourseEarnings.Size = new System.Drawing.Size(720, 354);
            this.dgvCourseEarnings.TabIndex = 1;
            // 
            // pnlPayoutHistory
            // 
            this.pnlPayoutHistory.Controls.Add(this.lblPayoutHistoryTitle);
            this.pnlPayoutHistory.Controls.Add(this.dgvPayoutHistory);
            this.pnlPayoutHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPayoutHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlPayoutHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlPayoutHistory.Name = "pnlPayoutHistory";
            this.pnlPayoutHistory.Size = new System.Drawing.Size(804, 431);
            this.pnlPayoutHistory.TabIndex = 1;
            // 
            // lblPayoutHistoryTitle
            // 
            this.lblPayoutHistoryTitle.AutoSize = true;
            this.lblPayoutHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPayoutHistoryTitle.Location = new System.Drawing.Point(15, 15);
            this.lblPayoutHistoryTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayoutHistoryTitle.Name = "lblPayoutHistoryTitle";
            this.lblPayoutHistoryTitle.Size = new System.Drawing.Size(225, 32);
            this.lblPayoutHistoryTitle.TabIndex = 0;
            this.lblPayoutHistoryTitle.Text = "📜 Payout History";
            // 
            // dgvPayoutHistory
            // 
            this.dgvPayoutHistory.AllowUserToAddRows = false;
            this.dgvPayoutHistory.AllowUserToDeleteRows = false;
            this.dgvPayoutHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayoutHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayoutHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayoutHistory.ColumnHeadersHeight = 34;
            this.dgvPayoutHistory.Location = new System.Drawing.Point(15, 62);
            this.dgvPayoutHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPayoutHistory.Name = "dgvPayoutHistory";
            this.dgvPayoutHistory.ReadOnly = true;
            this.dgvPayoutHistory.RowHeadersVisible = false;
            this.dgvPayoutHistory.RowHeadersWidth = 62;
            this.dgvPayoutHistory.Size = new System.Drawing.Size(774, 354);
            this.dgvPayoutHistory.TabIndex = 1;
            // 
            // pnlPayoutRequest
            // 
            this.pnlPayoutRequest.BackColor = System.Drawing.Color.White;
            this.pnlPayoutRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPayoutRequest.Controls.Add(this.lblPayoutRequestTitle);
            this.pnlPayoutRequest.Controls.Add(this.lblPayoutAmount);
            this.pnlPayoutRequest.Controls.Add(this.txtPayoutAmount);
            this.pnlPayoutRequest.Controls.Add(this.btnRequestPayout);
            this.pnlPayoutRequest.Controls.Add(this.lblMaxAmount);
            this.pnlPayoutRequest.Location = new System.Drawing.Point(45, 638);
            this.pnlPayoutRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlPayoutRequest.Name = "pnlPayoutRequest";
            this.pnlPayoutRequest.Size = new System.Drawing.Size(1559, 184);
            this.pnlPayoutRequest.TabIndex = 2;
            // 
            // lblPayoutRequestTitle
            // 
            this.lblPayoutRequestTitle.AutoSize = true;
            this.lblPayoutRequestTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPayoutRequestTitle.Location = new System.Drawing.Point(30, 23);
            this.lblPayoutRequestTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayoutRequestTitle.Name = "lblPayoutRequestTitle";
            this.lblPayoutRequestTitle.Size = new System.Drawing.Size(232, 32);
            this.lblPayoutRequestTitle.TabIndex = 0;
            this.lblPayoutRequestTitle.Text = "💰 Request Payout";
            // 
            // lblPayoutAmount
            // 
            this.lblPayoutAmount.AutoSize = true;
            this.lblPayoutAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPayoutAmount.Location = new System.Drawing.Point(30, 85);
            this.lblPayoutAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayoutAmount.Name = "lblPayoutAmount";
            this.lblPayoutAmount.Size = new System.Drawing.Size(124, 28);
            this.lblPayoutAmount.TabIndex = 1;
            this.lblPayoutAmount.Text = "Amount (৳):";
            // 
            // txtPayoutAmount
            // 
            this.txtPayoutAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPayoutAmount.Location = new System.Drawing.Point(195, 77);
            this.txtPayoutAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPayoutAmount.Name = "txtPayoutAmount";
            this.txtPayoutAmount.Size = new System.Drawing.Size(298, 39);
            this.txtPayoutAmount.TabIndex = 2;
            this.txtPayoutAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRequestPayout
            // 
            this.btnRequestPayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnRequestPayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestPayout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequestPayout.ForeColor = System.Drawing.Color.White;
            this.btnRequestPayout.Location = new System.Drawing.Point(525, 74);
            this.btnRequestPayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRequestPayout.Name = "btnRequestPayout";
            this.btnRequestPayout.Size = new System.Drawing.Size(240, 54);
            this.btnRequestPayout.TabIndex = 3;
            this.btnRequestPayout.Text = "💳 Request Payout";
            this.btnRequestPayout.UseVisualStyleBackColor = false;
            // 
            // lblMaxAmount
            // 
            this.lblMaxAmount.AutoSize = true;
            this.lblMaxAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblMaxAmount.Location = new System.Drawing.Point(195, 131);
            this.lblMaxAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(107, 25);
            this.lblMaxAmount.TabIndex = 4;
            this.lblMaxAmount.Text = "Max: ৳ 0.00";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1410, 638);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(195, 46);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblRecordCount,
            this.lblLastUpdate});
            this.statusStrip.Location = new System.Drawing.Point(45, 999);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1560, 32);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(240, 25);
            this.lblStatus.Text = "✅ Data loaded successfully.";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(94, 25);
            this.lblRecordCount.Text = "Records: 0";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(193, 25);
            this.lblLastUpdate.Text = "Last updated: Just now";
            // 
            // frmEarningsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1650, 1077);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmEarningsDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Earnings & Payout Dashboard";
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlTotalEarnings.ResumeLayout(false);
            this.pnlTotalEarnings.PerformLayout();
            this.pnlAvailableBalance.ResumeLayout(false);
            this.pnlAvailableBalance.PerformLayout();
            this.pnlPlatformFee.ResumeLayout(false);
            this.pnlPlatformFee.PerformLayout();
            this.pnlTotalStudents.ResumeLayout(false);
            this.pnlTotalStudents.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlCourseEarnings.ResumeLayout(false);
            this.pnlCourseEarnings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseEarnings)).EndInit();
            this.pnlPayoutHistory.ResumeLayout(false);
            this.pnlPayoutHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayoutHistory)).EndInit();
            this.pnlPayoutRequest.ResumeLayout(false);
            this.pnlPayoutRequest.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Control declarations
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlTotalEarnings;
        private System.Windows.Forms.Panel pnlAvailableBalance;
        private System.Windows.Forms.Panel pnlPlatformFee;
        private System.Windows.Forms.Panel pnlTotalStudents;
        private System.Windows.Forms.Panel pnlCourseEarnings;
        private System.Windows.Forms.Panel pnlPayoutHistory;
        private System.Windows.Forms.Panel pnlPayoutRequest;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblTotalEarningsValue;
        private System.Windows.Forms.Label lblTotalEarningsLabel;
        private System.Windows.Forms.Label lblAvailableBalanceValue;
        private System.Windows.Forms.Label lblAvailableBalanceLabel;
        private System.Windows.Forms.Label lblPlatformFeeValue;
        private System.Windows.Forms.Label lblPlatformFeeLabel;
        private System.Windows.Forms.Label lblTotalStudentsValue;
        private System.Windows.Forms.Label lblTotalStudentsLabel;
        private System.Windows.Forms.Label lblCourseEarningsTitle;
        private System.Windows.Forms.Label lblPayoutHistoryTitle;
        private System.Windows.Forms.Label lblPayoutAmount;
        private System.Windows.Forms.Label lblPayoutRequestTitle;
        private System.Windows.Forms.Label lblMaxAmount;

        private System.Windows.Forms.TextBox txtPayoutAmount;
        private System.Windows.Forms.Button btnRequestPayout;
        private System.Windows.Forms.DataGridView dgvCourseEarnings;
        private System.Windows.Forms.DataGridView dgvPayoutHistory;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
    }
}