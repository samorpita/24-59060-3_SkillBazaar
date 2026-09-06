namespace CourseCatalogform
{
    partial class Form4
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
            dgvCourses = new DataGridView();
            btnAddToCart = new DataGridViewButtonColumn();
            txtSearch = new TextBox();
            cmbCategory = new ComboBox();
            btnSearch = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { btnAddToCart });
            dgvCourses.Location = new Point(14, 288);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.Size = new Size(612, 106);
            dgvCourses.TabIndex = 0;
            dgvCourses.CellContentClick += dgvCourses_CellContentClick;
            dgvCourses.CellDoubleClick += dgvCourses_CellDoubleClick;
            // 
            // btnAddToCart
            // 
            btnAddToCart.HeaderText = "Action";
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseColumnTextForButtonValue = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 54);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(177, 23);
            txtSearch.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All", "Programming", "Admission Prep" });
            cmbCategory.Location = new Point(14, 83);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 2;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(210, 54);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(14, 134);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "View Cart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(589, 54);
            button2.Name = "button2";
            button2.Size = new Size(124, 23);
            button2.TabIndex = 5;
            button2.Text = "My Learning";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnSearch);
            Controls.Add(cmbCategory);
            Controls.Add(txtSearch);
            Controls.Add(dgvCourses);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCourses;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private Button btnSearch;
        private DataGridViewButtonColumn btnAddToCart;
        private Button button1;
        private Button button2;
    }
}