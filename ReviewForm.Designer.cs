namespace CourseCatalogform
{
    partial class ReviewForm
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
            cmbRating = new ComboBox();
            txtComment = new TextBox();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbRating
            // 
            cmbRating.FormattingEnabled = true;
            cmbRating.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbRating.Location = new Point(322, 90);
            cmbRating.Name = "cmbRating";
            cmbRating.Size = new Size(88, 23);
            cmbRating.TabIndex = 0;
            cmbRating.Text = "Rating  ";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(12, 90);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(304, 97);
            txtComment.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(18, 206);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 72);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 3;
            label1.Text = "Leave a Review";
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtComment);
            Controls.Add(cmbRating);
            Name = "ReviewForm";
            Text = "ReviewForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRating;
        private TextBox txtComment;
        private Button button1;
        private Label label1;
    }
}