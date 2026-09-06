namespace CourseCatalogform
{
    partial class CourseDetailsForm
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
            lblTitle = new Label();
            lblPrice = new Label();
            lblDescription = new Label();
            btnAddToCart = new Button();
            dgvReviews = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(43, 51);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(43, 78);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 15);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "label2";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(43, 112);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(38, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "label3";
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(43, 165);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(95, 20);
            btnAddToCart.TabIndex = 3;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click_1;
            // 
            // dgvReviews
            // 
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Location = new Point(43, 258);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.Size = new Size(538, 180);
            dgvReviews.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 223);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 5;
            label1.Text = "Student Reviews";
            // 
            // CourseDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvReviews);
            Controls.Add(btnAddToCart);
            Controls.Add(lblDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblTitle);
            Name = "CourseDetailsForm";
            Text = "CourseDetailsForm";
            Load += CourseDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPrice;
        private Label lblDescription;
        private Button btnAddToCart;
        private DataGridView dgvReviews;
        private Label label1;
    }
}