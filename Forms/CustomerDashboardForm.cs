using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Database;
using SkillBazaar.Models;

namespace SkillBazaar.Forms
{
    public class CustomerDashboardForm : Form
    {
        private readonly Student student;
        private readonly DatabaseConnection db = new DatabaseConnection();
        private TabControl tabs;
        private DataGridView catalogGrid, cartGrid, learningGrid;
        private TextBox searchBox, minPriceBox, maxPriceBox, reviewBox, nameBox, phoneBox, addressBox;
        private ComboBox categoryBox, ratingFilter, reviewRating;
        private Label cartSummary;

        public CustomerDashboardForm(Student currentStudent)
        {
            student = currentStudent;
            Text = "SkillBazaar - Customer";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1240, 720);
            MinimumSize = new Size(1120, 650);
            BackColor = Ui.Page;
            BuildInterface();
            RefreshAll();
        }

        private void BuildInterface()
        {
            tabs = Ui.Tabs();
            tabs.TabPages.Add(BuildCatalog());
            tabs.TabPages.Add(BuildCart());
            tabs.TabPages.Add(BuildLearning());
            tabs.TabPages.Add(BuildProfile());
            Controls.Add(tabs); Controls.Add(Ui.Header(this, "Student", student.FullName, (s, e) => Close()));
        }

        private TabPage Page(string title) { return new TabPage(title) { BackColor = Ui.Page, AutoScroll = true }; }

        private TabPage BuildCatalog()
        {
            TabPage page = Page("Course Catalog");
            page.Controls.Add(Ui.Heading("Find Your Next Course"));
            searchBox = Ui.TextBox(22, 60, 250);
            categoryBox = new ComboBox { Location = new Point(285, 60), Width = 155, DropDownStyle = ComboBoxStyle.DropDownList };
            ratingFilter = new ComboBox { Location = new Point(453, 60), Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
            ratingFilter.Items.AddRange(new object[] { "Any Rating", "1+ Stars", "2+ Stars", "3+ Stars", "4+ Stars", "5 Stars" }); ratingFilter.SelectedIndex = 0;
            minPriceBox = Ui.TextBox(596, 60, 100); minPriceBox.Text = "0";
            maxPriceBox = Ui.TextBox(708, 60, 100);
            Button filter = Ui.Button("Search / Filter", 824, 57, 140); filter.Click += (s, e) => LoadCatalog();
            Button reset = Ui.Button("Reset", 978, 57, 90, Ui.Primary); reset.Click += ResetFilters;
            page.Controls.Add(Ui.FieldLabel("Title or institute", 22, 40));
            page.Controls.Add(Ui.FieldLabel("Category", 285, 40));
            page.Controls.Add(Ui.FieldLabel("Minimum rating", 453, 40));
            page.Controls.Add(Ui.FieldLabel("Min price", 596, 40));
            page.Controls.Add(Ui.FieldLabel("Max price", 708, 40));
            catalogGrid = Ui.Grid(22, 112, 1150, 410);
            Button details = Ui.Button("View Details and Reviews", 735, 542, 215, Ui.Primary); details.Click += ViewDetails;
            Button add = Ui.Button("Add Selected to Cart", 965, 542, 195, Ui.Success); add.Click += AddToCart;
            page.Controls.AddRange(new Control[] { searchBox, categoryBox, ratingFilter, minPriceBox, maxPriceBox, filter, reset, catalogGrid, details, add });
            return page;
        }

        private TabPage BuildCart()
        {
            TabPage page = Page("Shopping Cart");
            page.Controls.Add(Ui.Heading("Your Shopping Cart"));
            cartGrid = Ui.Grid(22, 62, 1150, 395);
            cartSummary = new Label { Text = "0 items  |  Total: Tk 0.00", Location = new Point(22, 480), AutoSize = true, Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Ui.Primary };
            Button decrease = Ui.Button("Quantity -", 570, 476, 120, Ui.Primary); decrease.Click += (s, e) => ChangeQuantity(-1);
            Button increase = Ui.Button("Quantity +", 705, 476, 120, Ui.Primary); increase.Click += (s, e) => ChangeQuantity(1);
            Button remove = Ui.Button("Remove", 840, 476, 120, Ui.Danger); remove.Click += RemoveCartItem;
            Button checkout = Ui.Button("Proceed to Checkout", 975, 476, 185, Ui.Success); checkout.Click += OpenCheckout;
            page.Controls.AddRange(new Control[] { cartGrid, cartSummary, decrease, increase, remove, checkout });
            return page;
        }

        private TabPage BuildLearning()
        {
            TabPage page = Page("My Learning");
            page.Controls.Add(Ui.Heading("Purchased and Enrolled Courses"));
            learningGrid = Ui.Grid(22, 62, 1150, 330); learningGrid.SelectionChanged += LoadSelectedReview;
            page.Controls.Add(learningGrid);
            page.Controls.Add(new Label { Text = "Rate the selected course", Location = new Point(22, 420), AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Bold) });
            reviewRating = new ComboBox { Location = new Point(22, 451), Width = 110, DropDownStyle = ComboBoxStyle.DropDownList };
            reviewRating.Items.AddRange(new object[] { 1, 2, 3, 4, 5 }); reviewRating.SelectedIndex = 4;
            reviewBox = new TextBox { Location = new Point(148, 451), Size = new Size(675, 74), Multiline = true, MaxLength = 500, Font = new Font("Segoe UI", 10F) };
            Button submit = Ui.Button("Save Review", 840, 451, 145, Ui.Success); submit.Click += SaveReview;
            Button details = Ui.Button("Course Details", 1000, 451, 145, Ui.Primary); details.Click += ViewLearningDetails;
            page.Controls.AddRange(new Control[] { reviewRating, reviewBox, submit, details });
            return page;
        }

        private TabPage BuildProfile()
        {
            TabPage page = Page("My Profile");
            page.Controls.Add(Ui.Heading("Customer Profile"));
            nameBox = Field(page, "Full name *", 40, 90, 480);
            phoneBox = Field(page, "Phone", 40, 165, 480);
            addressBox = Field(page, "Address", 40, 240, 480);
            Button update = Ui.Button("Update Profile", 40, 325, 190, Ui.Success); update.Click += UpdateProfile;
            page.Controls.Add(update);
            return page;
        }

        private TextBox Field(Control page, string label, int x, int y, int width)
        {
            page.Controls.Add(Ui.FieldLabel(label, x, y)); TextBox box = Ui.TextBox(x, y + 23, width); page.Controls.Add(box); return box;
        }

        private void RefreshAll()
        {
            try { LoadCategories(); LoadCatalog(); LoadCart(); LoadLearning(); LoadProfile(); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void LoadCategories()
        {
            string selected = categoryBox.Text;
            DataTable data = db.ExecuteQuery("SELECT DISTINCT Category FROM Courses WHERE Status='Active' ORDER BY Category");
            categoryBox.Items.Clear(); categoryBox.Items.Add("All Categories");
            foreach (DataRow row in data.Rows) categoryBox.Items.Add(row["Category"].ToString());
            categoryBox.SelectedItem = categoryBox.Items.Contains(selected) ? selected : "All Categories";
        }

        private void LoadCatalog()
        {
            decimal minPrice, maxPrice; int minRating = ratingFilter.SelectedIndex;
            if (!decimal.TryParse(minPriceBox.Text, out minPrice) || minPrice < 0) minPrice = 0;
            if (!decimal.TryParse(maxPriceBox.Text, out maxPrice) || maxPrice <= 0) maxPrice = decimal.MaxValue;
            string search = searchBox.Text.Trim(); string category = categoryBox.Text;
            catalogGrid.DataSource = db.ExecuteQuery(@"SELECT c.CourseId,c.Title,i.InstituteName,c.Category,c.PricingType,c.DurationMonths,c.SeatsAvailable,
                c.Price AS RegularPrice,ISNULL(activeOffer.DiscountPercent,0) AS DiscountPercent,
                CAST(c.Price*(1-ISNULL(activeOffer.DiscountPercent,0)/100.0) AS DECIMAL(10,2)) AS FinalPrice,
                ISNULL(reviewStats.AverageRating,0) AS AverageRating,ISNULL(reviewStats.ReviewCount,0) AS Reviews
                FROM Courses c JOIN Institutes i ON c.InstituteId=i.InstituteId
                OUTER APPLY (SELECT MAX(o.DiscountPercent) DiscountPercent FROM Offers o WHERE o.CourseId=c.CourseId AND CAST(GETDATE() AS DATE) BETWEEN o.StartDate AND o.EndDate) activeOffer
                OUTER APPLY (SELECT AVG(CAST(r.Rating AS DECIMAL(4,2))) AverageRating,COUNT(*) ReviewCount FROM Reviews r WHERE r.CourseId=c.CourseId) reviewStats
                WHERE c.Status='Active' AND i.Status='Approved' AND c.SeatsAvailable>0
                AND (@search='' OR c.Title LIKE @like OR i.InstituteName LIKE @like)
                AND (@category='All Categories' OR c.Category=@category)
                AND c.Price*(1-ISNULL(activeOffer.DiscountPercent,0)/100.0) BETWEEN @minPrice AND @maxPrice
                AND ISNULL(reviewStats.AverageRating,0)>=@rating ORDER BY c.Title",
                new[] { new SqlParameter("@search",search),new SqlParameter("@like","%"+search+"%"),new SqlParameter("@category",category),new SqlParameter("@minPrice",minPrice),new SqlParameter("@maxPrice",maxPrice),new SqlParameter("@rating",minRating) });
        }

        private void ResetFilters(object sender, EventArgs e)
        {
            searchBox.Clear(); minPriceBox.Text="0"; maxPriceBox.Clear(); ratingFilter.SelectedIndex=0; categoryBox.SelectedIndex=0; LoadCatalog();
        }

        private void ViewDetails(object sender, EventArgs e)
        {
            int id=SelectedId(catalogGrid,"CourseId"); if(id==0){MessageBox.Show("Select a course.");return;}
            using(CourseDetailsForm form=new CourseDetailsForm(id)) form.ShowDialog(this);
        }

        private void AddToCart(object sender, EventArgs e)
        {
            int courseId=SelectedId(catalogGrid,"CourseId"); if(courseId==0){MessageBox.Show("Select a course.");return;}
            try
            {
                if(Convert.ToInt32(db.ExecuteScalar(@"SELECT COUNT(*) FROM OrderItems oi JOIN Orders o ON oi.OrderId=o.OrderId WHERE o.StudentId=@student AND oi.CourseId=@course AND o.Status='Paid'",new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId)}))>0)
                {MessageBox.Show("You already own this course. Find it under My Learning.");return;}
                int exists=Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(*) FROM Cart WHERE StudentId=@student AND CourseId=@course",new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId)}));
                if(exists>0)
                {
                    int affected=db.ExecuteNonQuery(@"UPDATE Cart SET Quantity=Quantity+1 WHERE StudentId=@student AND CourseId=@course
                        AND Quantity<(SELECT SeatsAvailable FROM Courses WHERE CourseId=@course)",new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId)});
                    if(affected==0){MessageBox.Show("No more seats are available for this course.");return;}
                }
                else db.ExecuteNonQuery("INSERT Cart(StudentId,CourseId,Quantity) VALUES(@student,@course,1)",new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId)});
                LoadCart(); tabs.SelectedIndex=1;
            }
            catch(Exception ex){ShowError(ex);}
        }

        private void LoadCart()
        {
            DataTable data=db.ExecuteQuery(@"SELECT ca.CartId,c.CourseId,c.Title,i.InstituteName,ca.Quantity,c.SeatsAvailable,c.Price AS RegularPrice,
                ISNULL(activeOffer.DiscountPercent,0) DiscountPercent,CAST(c.Price*(1-ISNULL(activeOffer.DiscountPercent,0)/100.0) AS DECIMAL(10,2)) FinalUnitPrice,
                CAST(c.Price*(1-ISNULL(activeOffer.DiscountPercent,0)/100.0)*ca.Quantity AS DECIMAL(10,2)) Subtotal
                FROM Cart ca JOIN Courses c ON ca.CourseId=c.CourseId JOIN Institutes i ON c.InstituteId=i.InstituteId
                OUTER APPLY (SELECT MAX(o.DiscountPercent) DiscountPercent FROM Offers o WHERE o.CourseId=c.CourseId AND CAST(GETDATE() AS DATE) BETWEEN o.StartDate AND o.EndDate) activeOffer
                WHERE ca.StudentId=@student ORDER BY ca.AddedDate",new[]{new SqlParameter("@student",student.UserId)});
            cartGrid.DataSource=data; decimal total=0; int items=0;
            foreach(DataRow row in data.Rows){total+=Convert.ToDecimal(row["Subtotal"]);items+=Convert.ToInt32(row["Quantity"]);}
            cartSummary.Text=items+" item(s)  |  Total after offers: "+Ui.Money(total);
        }

        private void ChangeQuantity(int change)
        {
            int cartId=SelectedId(cartGrid,"CartId"); if(cartId==0){MessageBox.Show("Select a cart item.");return;}
            DataRow row=((DataRowView)cartGrid.CurrentRow.DataBoundItem).Row; int quantity=Convert.ToInt32(row["Quantity"])+change; int seats=Convert.ToInt32(row["SeatsAvailable"]);
            if(quantity<1){RemoveCartItem(null,EventArgs.Empty);return;} if(quantity>seats){MessageBox.Show("Only "+seats+" seat(s) are currently available.");return;}
            try{db.ExecuteNonQuery("UPDATE Cart SET Quantity=@quantity WHERE CartId=@id AND StudentId=@student",new[]{new SqlParameter("@quantity",quantity),new SqlParameter("@id",cartId),new SqlParameter("@student",student.UserId)});LoadCart();}
            catch(Exception ex){ShowError(ex);}
        }

        private void RemoveCartItem(object sender, EventArgs e)
        {
            int cartId=SelectedId(cartGrid,"CartId"); if(cartId==0)return;
            try{db.ExecuteNonQuery("DELETE Cart WHERE CartId=@id AND StudentId=@student",new[]{new SqlParameter("@id",cartId),new SqlParameter("@student",student.UserId)});LoadCart();}
            catch(Exception ex){ShowError(ex);}
        }

        private void OpenCheckout(object sender, EventArgs e)
        {
            if(cartGrid.Rows.Count==0){MessageBox.Show("Your cart is empty.");return;}
            using(CheckoutForm form=new CheckoutForm(student))
            {
                form.ShowDialog(this);
                if(form.PaymentCompleted){LoadCart();LoadCatalog();LoadLearning();tabs.SelectedIndex=2;}
            }
        }

        private void LoadLearning()
        {
            learningGrid.DataSource=db.ExecuteQuery(@"SELECT o.OrderId,c.CourseId,c.Title,i.InstituteName,oi.Subtotal AS PaidAmount,o.PaymentMethod,o.PaymentReference,o.OrderDate,
                r.Rating AS MyRating,r.Comment AS MyReview FROM Orders o JOIN OrderItems oi ON o.OrderId=oi.OrderId JOIN Courses c ON oi.CourseId=c.CourseId
                JOIN Institutes i ON c.InstituteId=i.InstituteId LEFT JOIN Reviews r ON r.CourseId=c.CourseId AND r.StudentId=o.StudentId
                WHERE o.StudentId=@student AND o.Status='Paid' ORDER BY o.OrderDate DESC",new[]{new SqlParameter("@student",student.UserId)});
        }

        private void LoadSelectedReview(object sender, EventArgs e)
        {
            if(learningGrid.CurrentRow==null || learningGrid.CurrentRow.Cells["CourseId"].Value==null)return;
            object rating=learningGrid.CurrentRow.Cells["MyRating"].Value; reviewRating.SelectedItem=rating==DBNull.Value?5:Convert.ToInt32(rating);
            object comment=learningGrid.CurrentRow.Cells["MyReview"].Value; reviewBox.Text=comment==DBNull.Value?"":comment.ToString();
        }

        private void SaveReview(object sender, EventArgs e)
        {
            int courseId=SelectedId(learningGrid,"CourseId"); if(courseId==0){MessageBox.Show("Select an enrolled course.");return;}
            try{int exists=Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(*) FROM Reviews WHERE StudentId=@student AND CourseId=@course",new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId)}));
                string sql=exists==0?"INSERT Reviews(StudentId,CourseId,Rating,Comment) VALUES(@student,@course,@rating,@comment)":"UPDATE Reviews SET Rating=@rating,Comment=@comment,ReviewDate=GETDATE() WHERE StudentId=@student AND CourseId=@course";
                db.ExecuteNonQuery(sql,new[]{new SqlParameter("@student",student.UserId),new SqlParameter("@course",courseId),new SqlParameter("@rating",reviewRating.SelectedItem),new SqlParameter("@comment",reviewBox.Text.Trim())});MessageBox.Show(exists==0?"Review submitted.":"Review updated.");LoadLearning();LoadCatalog();}
            catch(Exception ex){ShowError(ex);}
        }

        private void ViewLearningDetails(object sender,EventArgs e)
        {
            int id=SelectedId(learningGrid,"CourseId");if(id==0){MessageBox.Show("Select a course.");return;}using(CourseDetailsForm form=new CourseDetailsForm(id))form.ShowDialog(this);
        }

        private void LoadProfile()
        {
            DataTable data=db.ExecuteQuery("SELECT FullName,Phone,Address FROM Users WHERE UserId=@id",new[]{new SqlParameter("@id",student.UserId)});
            if(data.Rows.Count==0)return;nameBox.Text=data.Rows[0]["FullName"].ToString();phoneBox.Text=data.Rows[0]["Phone"].ToString();addressBox.Text=data.Rows[0]["Address"].ToString();
        }

        private void UpdateProfile(object sender,EventArgs e)
        {
            if(nameBox.Text.Trim().Length<3){MessageBox.Show("Enter a valid full name.");return;}
            try{db.ExecuteNonQuery("UPDATE Users SET FullName=@name,Phone=@phone,Address=@address WHERE UserId=@id",new[]{new SqlParameter("@name",nameBox.Text.Trim()),new SqlParameter("@phone",phoneBox.Text.Trim()),new SqlParameter("@address",addressBox.Text.Trim()),new SqlParameter("@id",student.UserId)});student.FullName=nameBox.Text.Trim();MessageBox.Show("Profile updated.");}
            catch(Exception ex){ShowError(ex);}
        }

        private int SelectedId(DataGridView grid,string column){return grid!=null&&grid.CurrentRow!=null?Convert.ToInt32(grid.CurrentRow.Cells[column].Value):0;}
        private void ShowError(Exception ex){MessageBox.Show("The operation could not be completed.\n\n"+ex.Message,"SkillBazaar",MessageBoxButtons.OK,MessageBoxIcon.Error);}
    }
}
