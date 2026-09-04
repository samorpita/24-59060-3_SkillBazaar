namespace SkillBazaar.Forms
{
    partial class frmSeatAvailability
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Main Panel
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();

            // Header Controls
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarningIcon = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();

            // Stats Panel
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlTotalCourses = new System.Windows.Forms.Panel();
            this.lblTotalCoursesValue = new System.Windows.Forms.Label();
            this.lblTotalCoursesLabel = new System.Windows.Forms.Label();
            this.pnlLowSeats = new System.Windows.Forms.Panel();
            this.lblLowSeatsValue = new System.Windows.Forms.Label();
            this.lblLowSeatsLabel = new System.Windows.Forms.Label();
            this.pnlCriticalSeats = new System.Windows.Forms.Panel();
            this.lblCriticalSeatsValue = new System.Windows.Forms.Label();
            this.lblCriticalSeatsLabel = new System.Windows.Forms.Label();
            this.pnlAvailableSeats = new System.Windows.Forms.Panel();
            this.lblAvailableSeatsValue = new System.Windows.Forms.Label();
            this.lblAvailableSeatsLabel = new System.Windows.Forms.Label();

            // DataGridView
            this.dgvSeats = new System.Windows.Forms.DataGridView();

            // Buttons
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1100, 600);
            this.pnlMain.TabIndex = 0;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new System.Drawing.Size(1100, 80);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(211, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Seat Availability";

            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblSubHeader.Location = new System.Drawing.Point(35, 57);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(240, 19);
            this.lblSubHeader.TabIndex = 1;
            this.lblSubHeader.Text = "Monitor your course seat availability";

            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(255, 243, 224);
            this.pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarning.Location = new System.Drawing.Point(30, 100);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(1040, 40);
            this.pnlWarning.TabIndex = 0;
            this.pnlWarning.Visible = false;

            // 
            // lblWarningIcon
            // 
            this.lblWarningIcon.AutoSize = true;
            this.lblWarningIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWarningIcon.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblWarningIcon.Location = new System.Drawing.Point(15, 8);
            this.lblWarningIcon.Name = "lblWarningIcon";
            this.lblWarningIcon.Size = new System.Drawing.Size(31, 21);
            this.lblWarningIcon.TabIndex = 0;
            this.lblWarningIcon.Text = "⚠️";

            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblWarning.Location = new System.Drawing.Point(52, 10);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(410, 19);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "1 course is below its minimum seat threshold. Consider increasing capacity.";

            this.pnlWarning.Controls.Add(this.lblWarningIcon);
            this.pnlWarning.Controls.Add(this.lblWarning);

            // 
            // pnlStats
            // 
            this.pnlStats.Location = new System.Drawing.Point(30, 155);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1040, 80);
            this.pnlStats.TabIndex = 0;

            // 
            // pnlTotalCourses
            // 
            this.pnlTotalCourses.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlTotalCourses.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalCourses.Name = "pnlTotalCourses";
            this.pnlTotalCourses.Size = new System.Drawing.Size(240, 80);
            this.pnlTotalCourses.TabIndex = 0;

            // 
            // lblTotalCoursesValue
            // 
            this.lblTotalCoursesValue.AutoSize = true;
            this.lblTotalCoursesValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalCoursesValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalCoursesValue.Location = new System.Drawing.Point(85, 15);
            this.lblTotalCoursesValue.Name = "lblTotalCoursesValue";
            this.lblTotalCoursesValue.Size = new System.Drawing.Size(32, 37);
            this.lblTotalCoursesValue.TabIndex = 0;
            this.lblTotalCoursesValue.Text = "0";

            // 
            // lblTotalCoursesLabel
            // 
            this.lblTotalCoursesLabel.AutoSize = true;
            this.lblTotalCoursesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalCoursesLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalCoursesLabel.Location = new System.Drawing.Point(75, 52);
            this.lblTotalCoursesLabel.Name = "lblTotalCoursesLabel";
            this.lblTotalCoursesLabel.Size = new System.Drawing.Size(86, 15);
            this.lblTotalCoursesLabel.TabIndex = 1;
            this.lblTotalCoursesLabel.Text = "Total Courses";

            this.pnlTotalCourses.Controls.Add(this.lblTotalCoursesValue);
            this.pnlTotalCourses.Controls.Add(this.lblTotalCoursesLabel);

            // 
            // pnlLowSeats
            // 
            this.pnlLowSeats.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.pnlLowSeats.Location = new System.Drawing.Point(260, 0);
            this.pnlLowSeats.Name = "pnlLowSeats";
            this.pnlLowSeats.Size = new System.Drawing.Size(240, 80);
            this.pnlLowSeats.TabIndex = 1;

            // 
            // lblLowSeatsValue
            // 
            this.lblLowSeatsValue.AutoSize = true;
            this.lblLowSeatsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLowSeatsValue.ForeColor = System.Drawing.Color.White;
            this.lblLowSeatsValue.Location = new System.Drawing.Point(85, 15);
            this.lblLowSeatsValue.Name = "lblLowSeatsValue";
            this.lblLowSeatsValue.Size = new System.Drawing.Size(32, 37);
            this.lblLowSeatsValue.TabIndex = 0;
            this.lblLowSeatsValue.Text = "0";

            // 
            // lblLowSeatsLabel
            // 
            this.lblLowSeatsLabel.AutoSize = true;
            this.lblLowSeatsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLowSeatsLabel.ForeColor = System.Drawing.Color.White;
            this.lblLowSeatsLabel.Location = new System.Drawing.Point(65, 52);
            this.lblLowSeatsLabel.Name = "lblLowSeatsLabel";
            this.lblLowSeatsLabel.Size = new System.Drawing.Size(103, 15);
            this.lblLowSeatsLabel.TabIndex = 1;
            this.lblLowSeatsLabel.Text = "Low Seat Courses";

            this.pnlLowSeats.Controls.Add(this.lblLowSeatsValue);
            this.pnlLowSeats.Controls.Add(this.lblLowSeatsLabel);

            // 
            // pnlCriticalSeats
            // 
            this.pnlCriticalSeats.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.pnlCriticalSeats.Location = new System.Drawing.Point(520, 0);
            this.pnlCriticalSeats.Name = "pnlCriticalSeats";
            this.pnlCriticalSeats.Size = new System.Drawing.Size(240, 80);
            this.pnlCriticalSeats.TabIndex = 2;

            // 
            // lblCriticalSeatsValue
            // 
            this.lblCriticalSeatsValue.AutoSize = true;
            this.lblCriticalSeatsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCriticalSeatsValue.ForeColor = System.Drawing.Color.White;
            this.lblCriticalSeatsValue.Location = new System.Drawing.Point(85, 15);
            this.lblCriticalSeatsValue.Name = "lblCriticalSeatsValue";
            this.lblCriticalSeatsValue.Size = new System.Drawing.Size(32, 37);
            this.lblCriticalSeatsValue.TabIndex = 0;
            this.lblCriticalSeatsValue.Text = "0";

            // 
            // lblCriticalSeatsLabel
            // 
            this.lblCriticalSeatsLabel.AutoSize = true;
            this.lblCriticalSeatsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCriticalSeatsLabel.ForeColor = System.Drawing.Color.White;
            this.lblCriticalSeatsLabel.Location = new System.Drawing.Point(55, 52);
            this.lblCriticalSeatsLabel.Name = "lblCriticalSeatsLabel";
            this.lblCriticalSeatsLabel.Size = new System.Drawing.Size(120, 15);
            this.lblCriticalSeatsLabel.TabIndex = 1;
            this.lblCriticalSeatsLabel.Text = "Critical Seat Courses";

            this.pnlCriticalSeats.Controls.Add(this.lblCriticalSeatsValue);
            this.pnlCriticalSeats.Controls.Add(this.lblCriticalSeatsLabel);

            // 
            // pnlAvailableSeats
            // 
            this.pnlAvailableSeats.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlAvailableSeats.Location = new System.Drawing.Point(780, 0);
            this.pnlAvailableSeats.Name = "pnlAvailableSeats";
            this.pnlAvailableSeats.Size = new System.Drawing.Size(240, 80);
            this.pnlAvailableSeats.TabIndex = 3;

            // 
            // lblAvailableSeatsValue
            // 
            this.lblAvailableSeatsValue.AutoSize = true;
            this.lblAvailableSeatsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAvailableSeatsValue.ForeColor = System.Drawing.Color.White;
            this.lblAvailableSeatsValue.Location = new System.Drawing.Point(85, 15);
            this.lblAvailableSeatsValue.Name = "lblAvailableSeatsValue";
            this.lblAvailableSeatsValue.Size = new System.Drawing.Size(32, 37);
            this.lblAvailableSeatsValue.TabIndex = 0;
            this.lblAvailableSeatsValue.Text = "0";

            // 
            // lblAvailableSeatsLabel
            // 
            this.lblAvailableSeatsLabel.AutoSize = true;
            this.lblAvailableSeatsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailableSeatsLabel.ForeColor = System.Drawing.Color.White;
            this.lblAvailableSeatsLabel.Location = new System.Drawing.Point(55, 52);
            this.lblAvailableSeatsLabel.Name = "lblAvailableSeatsLabel";
            this.lblAvailableSeatsLabel.Size = new System.Drawing.Size(131, 15);
            this.lblAvailableSeatsLabel.TabIndex = 1;
            this.lblAvailableSeatsLabel.Text = "Total Available Seats";

            this.pnlAvailableSeats.Controls.Add(this.lblAvailableSeatsValue);
            this.pnlAvailableSeats.Controls.Add(this.lblAvailableSeatsLabel);

            // Add stats panels to stats panel
            this.pnlStats.Controls.Add(this.pnlTotalCourses);
            this.pnlStats.Controls.Add(this.pnlLowSeats);
            this.pnlStats.Controls.Add(this.pnlCriticalSeats);
            this.pnlStats.Controls.Add(this.pnlAvailableSeats);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(930, 250);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(930, 290);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 30);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "📊 Export Data";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // 
            // dgvSeats
            // 
            this.dgvSeats.AllowUserToAddRows = false;
            this.dgvSeats.AllowUserToDeleteRows = false;
            this.dgvSeats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeats.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Location = new System.Drawing.Point(30, 250);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.ReadOnly = true;
            this.dgvSeats.RowHeadersVisible = false;
            this.dgvSeats.Size = new System.Drawing.Size(880, 300);
            this.dgvSeats.TabIndex = 3;
            this.dgvSeats.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeats_CellDoubleClick);

            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlWarning);
            this.pnlContent.Controls.Add(this.pnlStats);
            this.pnlContent.Controls.Add(this.btnRefresh);
            this.pnlContent.Controls.Add(this.btnExport);
            this.pnlContent.Controls.Add(this.dgvSeats);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30);
            this.pnlContent.Size = new System.Drawing.Size(1100, 520);
            this.pnlContent.TabIndex = 1;

            // Add controls to main panel
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlContent);

            // 
            // frmSeatAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSeatAvailability";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seat Availability Dashboard";
            this.Load += new System.EventHandler(this.frmSeatAvailability_Load);
        }

        #endregion

        // Control declarations
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlTotalCourses;
        private System.Windows.Forms.Panel pnlLowSeats;
        private System.Windows.Forms.Panel pnlCriticalSeats;
        private System.Windows.Forms.Panel pnlAvailableSeats;

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Label lblWarningIcon;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblTotalCoursesValue;
        private System.Windows.Forms.Label lblTotalCoursesLabel;
        private System.Windows.Forms.Label lblLowSeatsValue;
        private System.Windows.Forms.Label lblLowSeatsLabel;
        private System.Windows.Forms.Label lblCriticalSeatsValue;
        private System.Windows.Forms.Label lblCriticalSeatsLabel;
        private System.Windows.Forms.Label lblAvailableSeatsValue;
        private System.Windows.Forms.Label lblAvailableSeatsLabel;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvSeats;
    }
}