using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Database;
using SkillBazaar.Models;

namespace SkillBazaar.Forms
{
    public class InstructorDashboardForm : Form
    {
        private readonly Instructor instructor;
        private readonly DatabaseConnection db = new DatabaseConnection();
        private int instituteId;
        private DataGridView courseGrid, seatGrid, enrollmentGrid, reviewGrid, salesGrid, payoutGrid, offerGrid;
        private TextBox titleBox, categoryBox, priceBox, durationBox, seatsBox, minimumBox, descriptionBox, payoutBox, instituteNameBox, instituteCategoryBox, phoneBox, addressBox, discountBox;
        private ComboBox pricingBox, statusBox;
        private DateTimePicker offerStart, offerEnd;
        private Label instituteStatusLabel, courseCountLabel, studentCountLabel, grossLabel, balanceLabel;

        public InstructorDashboardForm(Instructor currentInstructor)
        {
            instructor = currentInstructor;
            Text = "SkillBazaar - Instructor";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1240, 720);
            MinimumSize = new Size(1120, 650);
            BackColor = Ui.Page;
            BuildInterface();
            if (LoadInstitute()) RefreshAll();
        }

        private void BuildInterface()
        {
            TabControl tabs = Ui.Tabs();
            tabs.TabPages.Add(BuildOverview());
            tabs.TabPages.Add(BuildCourses());
            tabs.TabPages.Add(BuildOffers());
            tabs.TabPages.Add(BuildEnrollments());
            tabs.TabPages.Add(BuildReviews());
            tabs.TabPages.Add(BuildEarnings());
            tabs.TabPages.Add(BuildProfile());
            Controls.Add(tabs); Controls.Add(Ui.Header(this, "Instructor", instructor.FullName, (s, e) => Close()));
        }

        private TabPage Page(string title) { return new TabPage(title) { BackColor = Ui.Page, AutoScroll = true }; }

        private Panel Metric(string title, int x, out Label value)
        {
            Panel p = new Panel { Location = new Point(x, 74), Size = new Size(260, 100), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            p.Controls.Add(new Label { Text = title, Location = new Point(15, 14), AutoSize = true, ForeColor = Color.DimGray });
            value = new Label { Text = "0", Location = new Point(15, 43), AutoSize = true, Font = new Font("Segoe UI", 19F, FontStyle.Bold), ForeColor = Ui.Primary };
            p.Controls.Add(value); return p;
        }

        private TabPage BuildOverview()
        {
            TabPage page = Page("Overview");
            page.Controls.Add(Ui.Heading("Instructor Dashboard"));
            instituteStatusLabel = new Label { Text = "Institute status", Location = new Point(24, 48), AutoSize = true, ForeColor = Color.DimGray };
            page.Controls.Add(instituteStatusLabel);
            page.Controls.Add(Metric("Active courses", 22, out courseCountLabel));
            page.Controls.Add(Metric("Total enrollments", 302, out studentCountLabel));
            page.Controls.Add(Metric("Gross sales", 582, out grossLabel));
            page.Controls.Add(Metric("Available balance", 862, out balanceLabel));
            page.Controls.Add(new Label { Text = "Seat availability and low seat alerts", Location = new Point(22, 207), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) });
            seatGrid = Ui.Grid(22, 238, 1150, 330);
            page.Controls.Add(seatGrid);
            return page;
        }

        private TabPage BuildCourses()
        {
            TabPage page = Page("Course CRUD");
            page.Controls.Add(Ui.Heading("Create and Manage Courses"));
            courseGrid = Ui.Grid(22, 56, 1150, 265); courseGrid.SelectionChanged += SelectCourse;
            page.Controls.Add(courseGrid);
            int y = 348;
            titleBox = Field(page, "Title *", 22, y, 255);
            categoryBox = Field(page, "Category *", 292, y, 165);
            priceBox = Field(page, "Price *", 472, y, 115);
            pricingBox = Combo(page, "Pricing type", 602, y, new object[] { "OneTime", "Subscription" });
            durationBox = Field(page, "Duration months", 762, y, 125);
            seatsBox = Field(page, "Available seats *", 902, y, 115);
            minimumBox = Field(page, "Low seat level", 1032, y, 115);
            descriptionBox = new TextBox { Location = new Point(22, y + 86), Size = new Size(695, 62), Multiline = true, Font = new Font("Segoe UI", 10F) };
            page.Controls.Add(Ui.FieldLabel("Description", 22, y + 65)); page.Controls.Add(descriptionBox);
            statusBox = Combo(page, "Visibility", 732, y + 65, new object[] { "Active", "Hidden" });
            Button add = Ui.Button("Add Course", 895, y + 86, 120, Ui.Success); add.Click += AddCourse;
            Button update = Ui.Button("Update", 1028, y + 86, 105); update.Click += UpdateCourse;
            Button clear = Ui.Button("Clear", 895, y + 130, 120, Ui.Primary); clear.Click += (s, e) => ClearEditor();
            Button delete = Ui.Button("Delete", 1028, y + 130, 105, Ui.Danger); delete.Click += DeleteCourse;
            page.Controls.AddRange(new Control[] { add, update, clear, delete });
            return page;
        }

        private TabPage BuildOffers()
        {
            TabPage page = Page("Discount Offers");
            page.Controls.Add(Ui.Heading("Course Discount Offers"));
            offerGrid = Ui.Grid(22, 58, 1150, 335); page.Controls.Add(offerGrid);
            discountBox = Field(page, "Discount percent", 22, 420, 160);
            page.Controls.Add(Ui.FieldLabel("Start date", 200, 420));
            offerStart = new DateTimePicker { Location = new Point(200, 442), Width = 180, Format = DateTimePickerFormat.Short };
            page.Controls.Add(Ui.FieldLabel("End date", 398, 420));
            offerEnd = new DateTimePicker { Location = new Point(398, 442), Width = 180, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(30) };
            Button add = Ui.Button("Add Offer to Selected Course", 610, 439, 235, Ui.Success); add.Click += AddOffer;
            Button delete = Ui.Button("Delete Selected Offer", 865, 439, 200, Ui.Danger); delete.Click += DeleteOffer;
            page.Controls.AddRange(new Control[] { offerStart, offerEnd, add, delete });
            page.Controls.Add(new Label { Text = "Select a course row without an offer to create one, or select an offer row to delete it.", Location = new Point(22, 500), AutoSize = true, ForeColor = Color.DimGray });
            return page;
        }

        private TabPage BuildEnrollments()
        {
            TabPage page = Page("Enrolled Students");
            page.Controls.Add(Ui.Heading("Students Enrolled in My Courses"));
            enrollmentGrid = Ui.Grid(22, 62, 1150, 500); page.Controls.Add(enrollmentGrid);
            return page;
        }

        private TabPage BuildReviews()
        {
            TabPage page = Page("Ratings and Reviews");
            page.Controls.Add(Ui.Heading("Course Ratings and Student Reviews"));
            reviewGrid = Ui.Grid(22, 62, 1150, 500); page.Controls.Add(reviewGrid);
            return page;
        }

        private TabPage BuildEarnings()
        {
            TabPage page = Page("Earnings and Payouts");
            page.Controls.Add(Ui.Heading("Earnings After 20% Platform Commission"));
            salesGrid = Ui.Grid(22, 62, 760, 350); payoutGrid = Ui.Grid(800, 62, 372, 350);
            payoutBox = Field(page, "Payout amount", 800, 440, 180);
            Button request = Ui.Button("Request Payout", 995, 459, 165, Ui.Success); request.Click += RequestPayout;
            page.Controls.AddRange(new Control[] { salesGrid, payoutGrid, request });
            return page;
        }

        private TabPage BuildProfile()
        {
            TabPage page = Page("Institute Profile");
            page.Controls.Add(Ui.Heading("Institute Details"));
            instituteNameBox = Field(page, "Institute name *", 40, 85, 460);
            instituteCategoryBox = Field(page, "Category *", 40, 155, 460);
            phoneBox = Field(page, "Contact phone", 40, 225, 460);
            addressBox = Field(page, "Address", 40, 295, 460);
            Button save = Ui.Button("Save Institute Profile", 40, 375, 230, Ui.Success); save.Click += SaveProfile;
            page.Controls.Add(save);
            return page;
        }

        private TextBox Field(Control page, string label, int x, int y, int width)
        {
            page.Controls.Add(Ui.FieldLabel(label, x, y)); TextBox box = Ui.TextBox(x, y + 22, width); page.Controls.Add(box); return box;
        }

        private ComboBox Combo(Control page, string label, int x, int y, object[] values)
        {
            page.Controls.Add(Ui.FieldLabel(label, x, y)); ComboBox box = new ComboBox { Location = new Point(x, y + 22), Width = 145, DropDownStyle = ComboBoxStyle.DropDownList };
            box.Items.AddRange(values); box.SelectedIndex = 0; page.Controls.Add(box); return box;
        }

        private bool LoadInstitute()
        {
            try
            {
                DataTable data = db.ExecuteQuery("SELECT InstituteId,InstituteName,Category,Address,ContactPhone,Status FROM Institutes WHERE OwnerId=@owner", new[] { new SqlParameter("@owner", instructor.UserId) });
                if (data.Rows.Count == 0) { MessageBox.Show("No institute record is linked to this account."); Close(); return false; }
                DataRow row = data.Rows[0]; instituteId = Convert.ToInt32(row["InstituteId"]); instructor.InstituteId = instituteId; instructor.InstituteName = row["InstituteName"].ToString();
                instituteStatusLabel.Text = instructor.InstituteName + "  |  Account status: " + row["Status"];
                instituteNameBox.Text = row["InstituteName"].ToString(); instituteCategoryBox.Text = row["Category"].ToString(); phoneBox.Text = row["ContactPhone"].ToString(); addressBox.Text = row["Address"].ToString();
                return true;
            }
            catch (Exception ex) { ShowError(ex); return false; }
        }

        private void RefreshAll()
        {
            try { LoadOverview(); LoadCourses(); LoadOffers(); LoadEnrollments(); LoadReviews(); LoadEarnings(); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void LoadOverview()
        {
            courseCountLabel.Text = db.ExecuteScalar("SELECT COUNT(*) FROM Courses WHERE InstituteId=@id AND Status='Active'", P("@id", instituteId)).ToString();
            studentCountLabel.Text = db.ExecuteScalar(@"SELECT COUNT(*) FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId JOIN Courses c ON oi.CourseId=c.CourseId WHERE c.InstituteId=@id AND o.Status='Paid'", P("@id", instituteId)).ToString();
            decimal gross = Convert.ToDecimal(db.ExecuteScalar(@"SELECT ISNULL(SUM(oi.Subtotal),0) FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId JOIN Courses c ON oi.CourseId=c.CourseId WHERE c.InstituteId=@id AND o.Status='Paid'", P("@id", instituteId)));
            decimal committed = Convert.ToDecimal(db.ExecuteScalar("SELECT ISNULL(SUM(RequestedAmount),0) FROM PayoutRequests WHERE InstituteId=@id AND Status IN ('Pending','Approved')", P("@id", instituteId)));
            grossLabel.Text = Ui.Money(gross); balanceLabel.Text = Ui.Money(Math.Max(0, gross * 0.80m - committed));
            seatGrid.DataSource = db.ExecuteQuery(@"SELECT CourseId,Title,SeatsAvailable,MinSeats,CASE WHEN SeatsAvailable=0 THEN 'SOLD OUT' WHEN SeatsAvailable<=MinSeats THEN 'LOW SEATS' ELSE 'AVAILABLE' END AS SeatAlert,Status FROM Courses WHERE InstituteId=@id ORDER BY SeatsAvailable", P("@id", instituteId));
        }

        private void LoadCourses()
        {
            courseGrid.DataSource = db.ExecuteQuery("SELECT CourseId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Status,Description FROM Courses WHERE InstituteId=@id ORDER BY CourseId DESC", P("@id", instituteId));
        }

        private void LoadOffers()
        {
            offerGrid.DataSource = db.ExecuteQuery(@"SELECT c.CourseId,c.Title,o.OfferId,o.DiscountPercent,o.StartDate,o.EndDate,
                CASE WHEN CAST(GETDATE() AS DATE) BETWEEN o.StartDate AND o.EndDate THEN 'Active' WHEN o.OfferId IS NULL THEN 'No Offer' ELSE 'Expired' END AS OfferStatus
                FROM Courses c LEFT JOIN Offers o ON c.CourseId=o.CourseId WHERE c.InstituteId=@id ORDER BY c.Title,o.EndDate DESC", P("@id", instituteId));
        }

        private void LoadEnrollments()
        {
            enrollmentGrid.DataSource = db.ExecuteQuery(@"SELECT o.OrderId,c.Title,u.FullName AS Student,u.Email,u.Phone,oi.Quantity,oi.Subtotal,o.PaymentMethod,o.OrderDate
                FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId JOIN Courses c ON oi.CourseId=c.CourseId JOIN Users u ON o.StudentId=u.UserId
                WHERE c.InstituteId=@id AND o.Status='Paid' ORDER BY o.OrderDate DESC", P("@id", instituteId));
        }

        private void LoadReviews()
        {
            reviewGrid.DataSource = db.ExecuteQuery(@"SELECT c.Title,u.FullName AS Student,r.Rating,r.Comment,r.ReviewDate
                FROM Reviews r JOIN Courses c ON r.CourseId=c.CourseId JOIN Users u ON r.StudentId=u.UserId
                WHERE c.InstituteId=@id ORDER BY r.ReviewDate DESC", P("@id", instituteId));
        }

        private void LoadEarnings()
        {
            salesGrid.DataSource = db.ExecuteQuery(@"SELECT c.Title,COUNT(CASE WHEN o.Status='Paid' THEN oi.OrderItemId END) AS Sales,
                ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0) AS GrossSales,
                ISNULL(SUM(CASE WHEN o.Status='Paid' THEN oi.Subtotal ELSE 0 END),0)*0.80 AS NetEarnings
                FROM Courses c LEFT JOIN OrderItems oi ON c.CourseId=oi.CourseId LEFT JOIN Orders o ON oi.OrderId=o.OrderId
                WHERE c.InstituteId=@id GROUP BY c.Title ORDER BY GrossSales DESC", P("@id", instituteId));
            payoutGrid.DataSource = db.ExecuteQuery("SELECT PayoutId,RequestedAmount,Status,RequestDate,ProcessedDate FROM PayoutRequests WHERE InstituteId=@id ORDER BY RequestDate DESC", P("@id", instituteId));
        }

        private SqlParameter[] P(string name, object value) { return new[] { new SqlParameter(name, value) }; }

        private bool ValidateCourse(out decimal price, out int seats, out int minimum, out int? duration)
        {
            price = 0; seats = 0; minimum = 0; duration = null;
            int parsedDuration;
            if (titleBox.Text.Trim().Length < 3 || categoryBox.Text.Trim().Length < 2 || !decimal.TryParse(priceBox.Text, out price) || price < 0 || !int.TryParse(seatsBox.Text, out seats) || seats < 0 || !int.TryParse(minimumBox.Text, out minimum) || minimum < 0)
            { MessageBox.Show("Enter a title, category, non-negative price, seats and low seat level."); return false; }
            if (pricingBox.Text == "Subscription")
            {
                if (!int.TryParse(durationBox.Text, out parsedDuration) || parsedDuration <= 0) { MessageBox.Show("Subscription courses require a valid duration in months."); return false; }
                duration = parsedDuration;
            }
            return true;
        }

        private SqlParameter[] CourseParameters(decimal price, int seats, int minimum, int? duration)
        {
            return new[] { new SqlParameter("@institute",instituteId),new SqlParameter("@title",titleBox.Text.Trim()),new SqlParameter("@category",categoryBox.Text.Trim()),new SqlParameter("@price",price),new SqlParameter("@pricing",pricingBox.Text),new SqlParameter("@duration",(object)duration??DBNull.Value),new SqlParameter("@seats",seats),new SqlParameter("@minimum",minimum),new SqlParameter("@description",descriptionBox.Text.Trim()),new SqlParameter("@status",statusBox.Text) };
        }

        private void AddCourse(object sender, EventArgs e)
        {
            decimal price; int seats, minimum; int? duration; if (!ValidateCourse(out price,out seats,out minimum,out duration)) return;
            try { db.ExecuteNonQuery(@"INSERT Courses(InstituteId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Description,Status)
                VALUES(@institute,@title,@category,@price,@pricing,@duration,@seats,@minimum,@description,@status)",CourseParameters(price,seats,minimum,duration)); ClearEditor(); RefreshAll(); MessageBox.Show("Course created."); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void UpdateCourse(object sender, EventArgs e)
        {
            if (courseGrid.CurrentRow==null) { MessageBox.Show("Select a course."); return; }
            decimal price; int seats, minimum; int? duration; if (!ValidateCourse(out price,out seats,out minimum,out duration)) return;
            try { SqlParameter[] values=CourseParameters(price,seats,minimum,duration); Array.Resize(ref values,values.Length+1); values[values.Length-1]=new SqlParameter("@course",courseGrid.CurrentRow.Cells["CourseId"].Value);
                db.ExecuteNonQuery(@"UPDATE Courses SET Title=@title,Category=@category,Price=@price,PricingType=@pricing,DurationMonths=@duration,SeatsAvailable=@seats,MinSeats=@minimum,Description=@description,Status=@status WHERE CourseId=@course AND InstituteId=@institute",values); RefreshAll(); MessageBox.Show("Course updated."); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void DeleteCourse(object sender, EventArgs e)
        {
            if (courseGrid.CurrentRow==null) return; int id=Convert.ToInt32(courseGrid.CurrentRow.Cells["CourseId"].Value);
            if (MessageBox.Show("Delete this course?","Confirm",MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
            try { if (Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(*) FROM OrderItems WHERE CourseId=@id",P("@id",id)))>0) { db.ExecuteNonQuery("UPDATE Courses SET Status='Hidden' WHERE CourseId=@id",P("@id",id)); MessageBox.Show("The course has purchase history, so it was hidden instead."); }
                else db.ExecuteNonQuery("DELETE Reviews WHERE CourseId=@id; DELETE Cart WHERE CourseId=@id; DELETE Offers WHERE CourseId=@id; DELETE Courses WHERE CourseId=@id AND InstituteId=@institute",new[]{new SqlParameter("@id",id),new SqlParameter("@institute",instituteId)}); ClearEditor(); RefreshAll(); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void SelectCourse(object sender, EventArgs e)
        {
            if (courseGrid.CurrentRow==null || courseGrid.CurrentRow.Cells["CourseId"].Value==null) return;
            titleBox.Text=Cell("Title"); categoryBox.Text=Cell("Category"); priceBox.Text=Cell("Price"); pricingBox.Text=Cell("PricingType"); durationBox.Text=Cell("DurationMonths"); seatsBox.Text=Cell("SeatsAvailable"); minimumBox.Text=Cell("MinSeats"); statusBox.Text=Cell("Status"); descriptionBox.Text=Cell("Description");
        }
        private string Cell(string name) { object value=courseGrid.CurrentRow.Cells[name].Value; return value==null || value==DBNull.Value ? "" : value.ToString(); }
        private void ClearEditor() { titleBox.Clear(); categoryBox.Clear(); priceBox.Clear(); durationBox.Clear(); seatsBox.Clear(); minimumBox.Text="5"; descriptionBox.Clear(); pricingBox.SelectedIndex=0; statusBox.SelectedIndex=0; courseGrid.ClearSelection(); }

        private void AddOffer(object sender, EventArgs e)
        {
            if (offerGrid.CurrentRow==null) { MessageBox.Show("Select a course row."); return; }
            decimal discount; if (!decimal.TryParse(discountBox.Text,out discount) || discount<=0 || discount>100 || offerEnd.Value.Date<offerStart.Value.Date) { MessageBox.Show("Enter a discount from 0.01 to 100 and a valid date range."); return; }
            int courseId=Convert.ToInt32(offerGrid.CurrentRow.Cells["CourseId"].Value);
            try { db.ExecuteNonQuery("INSERT Offers(CourseId,DiscountPercent,StartDate,EndDate) VALUES(@course,@discount,@start,@end)",new[]{new SqlParameter("@course",courseId),new SqlParameter("@discount",discount),new SqlParameter("@start",offerStart.Value.Date),new SqlParameter("@end",offerEnd.Value.Date)}); discountBox.Clear(); LoadOffers(); }
            catch(Exception ex){ShowError(ex);}
        }

        private void DeleteOffer(object sender, EventArgs e)
        {
            if (offerGrid.CurrentRow==null || offerGrid.CurrentRow.Cells["OfferId"].Value==DBNull.Value) { MessageBox.Show("Select a row containing an offer."); return; }
            try { db.ExecuteNonQuery("DELETE Offers WHERE OfferId=@id",P("@id",offerGrid.CurrentRow.Cells["OfferId"].Value)); LoadOffers(); }
            catch(Exception ex){ShowError(ex);}
        }

        private void RequestPayout(object sender, EventArgs e)
        {
            decimal amount; if (!decimal.TryParse(payoutBox.Text,out amount) || amount<=0) { MessageBox.Show("Enter a valid payout amount."); return; }
            try { decimal gross=Convert.ToDecimal(db.ExecuteScalar(@"SELECT ISNULL(SUM(oi.Subtotal),0) FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId JOIN Courses c ON oi.CourseId=c.CourseId WHERE c.InstituteId=@id AND o.Status='Paid'",P("@id",instituteId)));
                decimal committed=Convert.ToDecimal(db.ExecuteScalar("SELECT ISNULL(SUM(RequestedAmount),0) FROM PayoutRequests WHERE InstituteId=@id AND Status IN ('Pending','Approved')",P("@id",instituteId)));
                if(amount>gross*0.80m-committed){MessageBox.Show("The request exceeds your available balance.");return;}
                db.ExecuteNonQuery("INSERT PayoutRequests(InstituteId,RequestedAmount) VALUES(@id,@amount)",new[]{new SqlParameter("@id",instituteId),new SqlParameter("@amount",amount)}); payoutBox.Clear(); RefreshAll(); MessageBox.Show("Payout request submitted."); }
            catch(Exception ex){ShowError(ex);}
        }

        private void SaveProfile(object sender, EventArgs e)
        {
            if(instituteNameBox.Text.Trim().Length<3 || instituteCategoryBox.Text.Trim().Length<2){MessageBox.Show("Institute name and category are required.");return;}
            try { db.ExecuteNonQuery("UPDATE Institutes SET InstituteName=@name,Category=@category,ContactPhone=@phone,Address=@address WHERE InstituteId=@id",new[]{new SqlParameter("@name",instituteNameBox.Text.Trim()),new SqlParameter("@category",instituteCategoryBox.Text.Trim()),new SqlParameter("@phone",phoneBox.Text.Trim()),new SqlParameter("@address",addressBox.Text.Trim()),new SqlParameter("@id",instituteId)}); LoadInstitute(); MessageBox.Show("Institute profile updated."); }
            catch(Exception ex){ShowError(ex);}
        }

        private void ShowError(Exception ex) { MessageBox.Show("The operation could not be completed.\n\n"+ex.Message,"SkillBazaar",MessageBoxButtons.OK,MessageBoxIcon.Error); }
    }
}
