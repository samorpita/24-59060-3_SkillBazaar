using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Database;

namespace SkillBazaar.Forms
{
    public class CourseDetailsForm : Form
    {
        private readonly int courseId;
        private readonly DatabaseConnection db = new DatabaseConnection();
        private Label titleLabel, instituteLabel, priceLabel, ratingLabel, informationLabel;
        private TextBox descriptionBox;
        private DataGridView reviewGrid;

        public CourseDetailsForm(int selectedCourseId)
        {
            courseId = selectedCourseId;
            Text = "SkillBazaar - Course Details";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(850, 610);
            BackColor = Ui.Page;
            BuildInterface();
            LoadCourse();
        }

        private void BuildInterface()
        {
            Panel top = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Ui.PrimaryDark };
            titleLabel = new Label { Text = "Course Details", Location = new Point(22, 15), AutoSize = true, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = Color.White };
            top.Controls.Add(titleLabel); Controls.Add(top);
            instituteLabel = new Label { Location = new Point(25, 82), AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Ui.Primary };
            priceLabel = new Label { Location = new Point(25, 116), AutoSize = true, Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Ui.Success };
            ratingLabel = new Label { Location = new Point(620, 88), Size = new Size(195, 32), TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
            informationLabel = new Label { Location = new Point(25, 152), Size = new Size(790, 45), Font = new Font("Segoe UI", 9.5F) };
            descriptionBox = new TextBox { Location = new Point(25, 205), Size = new Size(790, 90), Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, BackColor = Color.White, Font = new Font("Segoe UI", 10F) };
            Controls.Add(new Label { Text = "Description", Location = new Point(25, 183), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            Controls.Add(new Label { Text = "Student Reviews", Location = new Point(25, 315), AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Bold) });
            reviewGrid = Ui.Grid(25, 345, 790, 195);
            Button close = Ui.Button("Close", 675, 555, 140, Ui.Primary); close.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { instituteLabel, priceLabel, ratingLabel, informationLabel, descriptionBox, reviewGrid, close });
        }

        private void LoadCourse()
        {
            try
            {
                DataTable course = db.ExecuteQuery(@"SELECT c.Title,i.InstituteName,c.Category,c.Price,c.PricingType,c.DurationMonths,c.SeatsAvailable,c.Description,
                    ISNULL(a.DiscountPercent,0) DiscountPercent,CAST(c.Price*(1-ISNULL(a.DiscountPercent,0)/100.0) AS DECIMAL(10,2)) FinalPrice,
                    ISNULL(r.AverageRating,0) AverageRating,ISNULL(r.ReviewCount,0) ReviewCount
                    FROM Courses c JOIN Institutes i ON c.InstituteId=i.InstituteId
                    OUTER APPLY(SELECT MAX(DiscountPercent) DiscountPercent FROM Offers WHERE CourseId=c.CourseId AND CAST(GETDATE() AS DATE) BETWEEN StartDate AND EndDate)a
                    OUTER APPLY(SELECT AVG(CAST(Rating AS DECIMAL(4,2))) AverageRating,COUNT(*) ReviewCount FROM Reviews WHERE CourseId=c.CourseId)r
                    WHERE c.CourseId=@id", new[] { new SqlParameter("@id", courseId) });
                if (course.Rows.Count == 0) { MessageBox.Show("Course not found."); Close(); return; }
                DataRow row = course.Rows[0];
                titleLabel.Text = row["Title"].ToString();
                instituteLabel.Text = row["InstituteName"] + "  |  " + row["Category"];
                priceLabel.Text = Ui.Money(row["FinalPrice"]) + (Convert.ToDecimal(row["DiscountPercent"]) > 0 ? "  (" + row["DiscountPercent"] + "% offer; regular " + Ui.Money(row["Price"]) + ")" : "");
                ratingLabel.Text = Convert.ToDecimal(row["AverageRating"]).ToString("0.0") + " / 5  (" + row["ReviewCount"] + " reviews)";
                string duration = row["DurationMonths"] == DBNull.Value ? "Not specified" : row["DurationMonths"] + " month(s)";
                informationLabel.Text = "Pricing: " + row["PricingType"] + "    Duration: " + duration + "    Seats available: " + row["SeatsAvailable"];
                descriptionBox.Text = row["Description"].ToString();
                reviewGrid.DataSource = db.ExecuteQuery(@"SELECT u.FullName AS Student,r.Rating,r.Comment,r.ReviewDate FROM Reviews r JOIN Users u ON r.StudentId=u.UserId WHERE r.CourseId=@id ORDER BY r.ReviewDate DESC", new[] { new SqlParameter("@id", courseId) });
            }
            catch (Exception ex) { MessageBox.Show("Could not load course details.\n\n" + ex.Message, "SkillBazaar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
