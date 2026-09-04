using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Database;
using SkillBazaar.Models;

namespace SkillBazaar.Forms
{
    public class SuperAdminDashboardForm : Form
    {
        private readonly SuperAdmin admin;
        private readonly DatabaseConnection db = new DatabaseConnection();
        private DataGridView pendingGrid, instructorGrid, courseGrid, salesGrid, bestGrid, lowRatedGrid, payoutGrid, payoutHistoryGrid;
        private Label revenueLabel, instructorsLabel, studentsLabel, pendingLabel;
        private TextBox instructorSearch, courseSearch;
        private ComboBox instructorStatus;

        public SuperAdminDashboardForm(SuperAdmin currentAdmin)
        {
            admin = currentAdmin;
            Text = "SkillBazaar - Super Admin";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1240, 720);
            MinimumSize = new Size(1100, 650);
            BackColor = Ui.Page;
            BuildInterface();
            RefreshAll();
        }

        private void BuildInterface()
        {
            TabControl tabs = Ui.Tabs();
            tabs.TabPages.Add(BuildOverview());
            tabs.TabPages.Add(BuildInstructors());
            tabs.TabPages.Add(BuildCourses());
            tabs.TabPages.Add(BuildReports());
            tabs.TabPages.Add(BuildPayouts());
            Controls.Add(tabs);
            Controls.Add(Ui.Header(this, "Super Admin", admin.FullName, (s, e) => Close()));
        }

        private TabPage Page(string title)
        {
            return new TabPage(title) { BackColor = Ui.Page, AutoScroll = true };
        }

        private Panel Metric(string title, int x, out Label value)
        {
            Panel panel = new Panel { Location = new Point(x, 58), Size = new Size(255, 94), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            panel.Controls.Add(new Label { Text = title, Location = new Point(15, 13), AutoSize = true, ForeColor = Color.DimGray });
            value = new Label { Text = "0", Location = new Point(15, 40), AutoSize = true, Font = new Font("Segoe UI", 19F, FontStyle.Bold), ForeColor = Ui.Primary };
            panel.Controls.Add(value);
            return panel;
        }

        private TabPage BuildOverview()
        {
            TabPage page = Page("Overview");
            page.Controls.Add(Ui.Heading("Platform Overview"));
            page.Controls.Add(Metric("Platform commission", 22, out revenueLabel));
            page.Controls.Add(Metric("Approved instructors", 292, out instructorsLabel));
            page.Controls.Add(Metric("Registered students", 562, out studentsLabel));
            page.Controls.Add(Metric("Pending approvals", 832, out pendingLabel));
            page.Controls.Add(new Label { Text = "Pending instructor registrations", Location = new Point(22, 177), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) });
            pendingGrid = Ui.Grid(22, 210, 1150, 355);
            page.Controls.Add(pendingGrid);
            Button approve = Ui.Button("Approve Selected", 820, 580, 160, Ui.Success); approve.Click += (s, e) => SetPendingStatus("Approved");
            Button reject = Ui.Button("Reject Selected", 995, 580, 160, Ui.Danger); reject.Click += (s, e) => SetPendingStatus("Suspended");
            page.Controls.AddRange(new Control[] { approve, reject });
            return page;
        }

        private TabPage BuildInstructors()
        {
            TabPage page = Page("Manage Instructors");
            page.Controls.Add(Ui.Heading("Instructor Accounts"));
            instructorSearch = Ui.TextBox(22, 60, 300);
            instructorStatus = new ComboBox { Location = new Point(338, 60), Width = 170, DropDownStyle = ComboBoxStyle.DropDownList };
            instructorStatus.Items.AddRange(new object[] { "All Statuses", "Pending", "Approved", "Suspended" }); instructorStatus.SelectedIndex = 0;
            Button search = Ui.Button("Apply Filter", 525, 57, 125); search.Click += (s, e) => LoadInstructors();
            instructorGrid = Ui.Grid(22, 108, 1150, 395);
            Button approve = Ui.Button("Approve", 650, 525, 140, Ui.Success); approve.Click += (s, e) => SetInstructorStatus("Approved");
            Button suspend = Ui.Button("Suspend", 805, 525, 140, Ui.Danger); suspend.Click += (s, e) => SetInstructorStatus("Suspended");
            Button reactivate = Ui.Button("Reactivate", 960, 525, 140, Ui.Primary); reactivate.Click += (s, e) => SetInstructorStatus("Approved");
            page.Controls.AddRange(new Control[] { instructorSearch, instructorStatus, search, instructorGrid, approve, suspend, reactivate });
            return page;
        }

        private TabPage BuildCourses()
        {
            TabPage page = Page("Course Moderation");
            page.Controls.Add(Ui.Heading("All Marketplace Courses"));
            courseSearch = Ui.TextBox(22, 60, 360);
            Button search = Ui.Button("Search", 400, 57, 120); search.Click += (s, e) => LoadCourses();
            courseGrid = Ui.Grid(22, 108, 1150, 400);
            Button hide = Ui.Button("Hide Course", 725, 530, 135, Ui.Danger); hide.Click += (s, e) => SetCourseStatus("Hidden");
            Button restore = Ui.Button("Restore Course", 875, 530, 140, Ui.Success); restore.Click += (s, e) => SetCourseStatus("Active");
            Button delete = Ui.Button("Delete Course", 1030, 530, 130, Ui.Danger); delete.Click += DeleteCourse;
            page.Controls.AddRange(new Control[] { courseSearch, search, courseGrid, hide, restore, delete });
            return page;
        }

        private TabPage BuildReports()
        {
            TabPage page = Page("Reports and Quality");
            page.Controls.Add(Ui.Heading("Platform Reports"));
            page.Controls.Add(new Label { Text = "Instructor sales and commission", Location = new Point(22, 58), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            salesGrid = Ui.Grid(22, 84, 550, 235);
            page.Controls.Add(new Label { Text = "Best selling courses", Location = new Point(600, 58), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            bestGrid = Ui.Grid(600, 84, 572, 235);
            page.Controls.Add(new Label { Text = "Courses rated below 2.5", Location = new Point(22, 342), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Ui.Danger });
            lowRatedGrid = Ui.Grid(22, 370, 1150, 205);
            page.Controls.AddRange(new Control[] { salesGrid, bestGrid, lowRatedGrid });
            return page;
        }

        private TabPage BuildPayouts()
        {
            TabPage page = Page("Payout Requests");
            page.Controls.Add(Ui.Heading("Instructor Payout Requests"));
            page.Controls.Add(new Label { Text = "Pending requests", Location = new Point(22, 60), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            payoutGrid = Ui.Grid(22, 86, 1150, 250);
            Button approve = Ui.Button("Approve Selected", 835, 352, 155, Ui.Success); approve.Click += (s, e) => ProcessPayout("Approved");
            Button reject = Ui.Button("Reject Selected", 1005, 352, 150, Ui.Danger); reject.Click += (s, e) => ProcessPayout("Rejected");
            page.Controls.Add(new Label { Text = "Processed history", Location = new Point(22, 398), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            payoutHistoryGrid = Ui.Grid(22, 425, 1150, 170);
            page.Controls.AddRange(new Control[] { payoutGrid, approve, reject, payoutHistoryGrid });
            return page;
        }

        private void RefreshAll()
        {
            try { LoadOverview(); LoadInstructors(); LoadCourses(); LoadReports(); LoadPayouts(); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void LoadOverview()
        {
            revenueLabel.Text = Ui.Money(db.ExecuteScalar(@"SELECT ISNULL(SUM(oi.Subtotal),0)*0.20 FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId WHERE o.Status='Paid'"));
            instructorsLabel.Text = db.ExecuteScalar("SELECT COUNT(*) FROM Institutes WHERE Status='Approved'").ToString();
            studentsLabel.Text = db.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE UserType='Customer' AND Status='Approved'").ToString();
            pendingLabel.Text = db.ExecuteScalar("SELECT COUNT(*) FROM Institutes WHERE Status='Pending'").ToString();
            pendingGrid.DataSource = db.ExecuteQuery(@"SELECT i.InstituteId,i.InstituteName,u.FullName AS Owner,u.Email,i.Category,i.ContactPhone,i.Address
                                                      FROM Institutes i JOIN Users u ON i.OwnerId=u.UserId WHERE i.Status='Pending' ORDER BY i.InstituteId");
        }

        private void LoadInstructors()
        {
            string status = instructorStatus == null ? "All Statuses" : instructorStatus.Text;
            string search = instructorSearch == null ? "" : instructorSearch.Text.Trim();
            instructorGrid.DataSource = db.ExecuteQuery(@"SELECT i.InstituteId,i.InstituteName,u.FullName AS Owner,u.Email,i.Category,i.Status,i.ContactPhone
                FROM Institutes i JOIN Users u ON i.OwnerId=u.UserId
                WHERE (@status='All Statuses' OR i.Status=@status) AND (@search='' OR i.InstituteName LIKE @like OR u.FullName LIKE @like OR u.Email LIKE @like)
                ORDER BY i.InstituteName", new[] { new SqlParameter("@status", status), new SqlParameter("@search", search), new SqlParameter("@like", "%" + search + "%") });
        }

        private void LoadCourses()
        {
            string search = courseSearch == null ? "" : courseSearch.Text.Trim();
            courseGrid.DataSource = db.ExecuteQuery(@"SELECT c.CourseId,c.Title,i.InstituteName,c.Category,c.Price,c.SeatsAvailable,c.Status,
                ISNULL(AVG(CAST(r.Rating AS DECIMAL(4,2))),0) AS AverageRating
                FROM Courses c JOIN Institutes i ON c.InstituteId=i.InstituteId LEFT JOIN Reviews r ON c.CourseId=r.CourseId
                WHERE @search='' OR c.Title LIKE @like OR i.InstituteName LIKE @like
                GROUP BY c.CourseId,c.Title,i.InstituteName,c.Category,c.Price,c.SeatsAvailable,c.Status ORDER BY c.Title",
                new[] { new SqlParameter("@search", search), new SqlParameter("@like", "%" + search + "%") });
        }

        private void LoadReports()
        {
            salesGrid.DataSource = db.ExecuteQuery(@"SELECT i.InstituteName,COUNT(CASE WHEN o.Status='Paid' THEN oi.OrderItemId END) AS CoursesSold,ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0) AS GrossSales,
                ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0)*0.20 AS Commission,
                ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0)*0.80 AS InstructorNet
                FROM Institutes i LEFT JOIN Courses c ON i.InstituteId=c.InstituteId LEFT JOIN OrderItems oi ON c.CourseId=oi.CourseId LEFT JOIN Orders o ON oi.OrderId=o.OrderId
                GROUP BY i.InstituteName ORDER BY GrossSales DESC");
            bestGrid.DataSource = db.ExecuteQuery(@"SELECT TOP 10 c.Title,i.InstituteName,COUNT(CASE WHEN o.Status='Paid' THEN oi.OrderItemId END) AS Sales,ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0) AS Revenue
                FROM Courses c JOIN Institutes i ON c.InstituteId=i.InstituteId LEFT JOIN OrderItems oi ON c.CourseId=oi.CourseId LEFT JOIN Orders o ON oi.OrderId=o.OrderId
                GROUP BY c.Title,i.InstituteName ORDER BY Sales DESC,Revenue DESC");
            lowRatedGrid.DataSource = db.ExecuteQuery(@"SELECT c.CourseId,c.Title,i.InstituteName,AVG(CAST(r.Rating AS DECIMAL(4,2))) AS AverageRating,COUNT(r.ReviewId) AS Reviews
                FROM Reviews r JOIN Courses c ON r.CourseId=c.CourseId JOIN Institutes i ON c.InstituteId=i.InstituteId
                GROUP BY c.CourseId,c.Title,i.InstituteName HAVING AVG(CAST(r.Rating AS DECIMAL(4,2)))<2.5 ORDER BY AverageRating");
        }

        private void LoadPayouts()
        {
            string available = @"(ISNULL((SELECT SUM(oi.Subtotal)*0.80 FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId JOIN Courses c ON oi.CourseId=c.CourseId WHERE c.InstituteId=i.InstituteId AND o.Status='Paid'),0)-ISNULL((SELECT SUM(RequestedAmount) FROM PayoutRequests px WHERE px.InstituteId=i.InstituteId AND px.Status='Approved'),0))";
            payoutGrid.DataSource = db.ExecuteQuery("SELECT p.PayoutId,i.InstituteName,u.FullName AS Owner," + available + " AS AvailableBalance,p.RequestedAmount,p.RequestDate FROM PayoutRequests p JOIN Institutes i ON p.InstituteId=i.InstituteId JOIN Users u ON i.OwnerId=u.UserId WHERE p.Status='Pending' ORDER BY p.RequestDate");
            payoutHistoryGrid.DataSource = db.ExecuteQuery(@"SELECT TOP 30 p.PayoutId,i.InstituteName,p.RequestedAmount,p.Status,p.RequestDate,p.ProcessedDate FROM PayoutRequests p JOIN Institutes i ON p.InstituteId=i.InstituteId WHERE p.Status<>'Pending' ORDER BY p.ProcessedDate DESC");
        }

        private int SelectedId(DataGridView grid, string column)
        {
            return grid != null && grid.CurrentRow != null ? Convert.ToInt32(grid.CurrentRow.Cells[column].Value) : 0;
        }

        private void SetPendingStatus(string status)
        {
            int id = SelectedId(pendingGrid, "InstituteId"); if (id == 0) { MessageBox.Show("Select an instructor application."); return; }
            UpdateInstituteAndUser(id, status);
        }

        private void SetInstructorStatus(string status)
        {
            int id = SelectedId(instructorGrid, "InstituteId"); if (id == 0) { MessageBox.Show("Select an instructor."); return; }
            UpdateInstituteAndUser(id, status);
        }

        private void UpdateInstituteAndUser(int instituteId, string status)
        {
            try
            {
                using (SqlConnection connection = db.GetConnection())
                {
                    connection.Open(); using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE Institutes SET Status=@status WHERE InstituteId=@id; UPDATE Users SET Status=@status WHERE UserId=(SELECT OwnerId FROM Institutes WHERE InstituteId=@id);", connection, transaction))
                        { command.Parameters.AddWithValue("@status", status); command.Parameters.AddWithValue("@id", instituteId); command.ExecuteNonQuery(); }
                        transaction.Commit();
                    }
                }
                MessageBox.Show("Instructor status updated to " + status + "."); RefreshAll();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void SetCourseStatus(string status)
        {
            int id = SelectedId(courseGrid, "CourseId"); if (id == 0) { MessageBox.Show("Select a course."); return; }
            try { db.ExecuteNonQuery("UPDATE Courses SET Status=@status WHERE CourseId=@id", new[] { new SqlParameter("@status", status), new SqlParameter("@id", id) }); LoadCourses(); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void DeleteCourse(object sender, EventArgs e)
        {
            int id = SelectedId(courseGrid, "CourseId"); if (id == 0) { MessageBox.Show("Select a course."); return; }
            if (MessageBox.Show("Permanently delete this course when it has no purchase history?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                if (Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(*) FROM OrderItems WHERE CourseId=@id", new[] { new SqlParameter("@id", id) })) > 0)
                { MessageBox.Show("This course has purchase history, so it was hidden instead of deleted."); db.ExecuteNonQuery("UPDATE Courses SET Status='Hidden' WHERE CourseId=@id", new[] { new SqlParameter("@id", id) }); }
                else
                { db.ExecuteNonQuery("DELETE FROM Reviews WHERE CourseId=@id; DELETE FROM Cart WHERE CourseId=@id; DELETE FROM Offers WHERE CourseId=@id; DELETE FROM Courses WHERE CourseId=@id;", new[] { new SqlParameter("@id", id) }); }
                LoadCourses();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void ProcessPayout(string status)
        {
            int id = SelectedId(payoutGrid, "PayoutId"); if (id == 0) { MessageBox.Show("Select a payout request."); return; }
            try
            {
                if (status == "Approved")
                {
                    DataRow row = ((DataRowView)payoutGrid.CurrentRow.DataBoundItem).Row;
                    if (Convert.ToDecimal(row["RequestedAmount"]) > Convert.ToDecimal(row["AvailableBalance"])) { MessageBox.Show("The request exceeds the instructor's available balance."); return; }
                }
                db.ExecuteNonQuery("UPDATE PayoutRequests SET Status=@status,ProcessedDate=GETDATE() WHERE PayoutId=@id AND Status='Pending'", new[] { new SqlParameter("@status", status), new SqlParameter("@id", id) });
                MessageBox.Show("Payout request " + status.ToLowerInvariant() + "."); LoadPayouts(); LoadReports();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show("The operation could not be completed.\n\n" + ex.Message, "SkillBazaar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
