namespace CourseCatalogform
{
    partial class MyLearningForm
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
            dgvMyCourses = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMyCourses).BeginInit();
            SuspendLayout();
            // 
            // dgvMyCourses
            // 
            dgvMyCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyCourses.Location = new Point(46, 162);
            dgvMyCourses.Name = "dgvMyCourses";
            dgvMyCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyCourses.Size = new Size(240, 150);
            dgvMyCourses.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(49, 333);
            button1.Name = "button1";
            button1.Size = new Size(113, 24);
            button1.TabIndex = 1;
            button1.Text = "Back to Catalog";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(208, 334);
            button2.Name = "button2";
            button2.Size = new Size(111, 23);
            button2.TabIndex = 2;
            button2.Text = "Rate Course";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MyLearningForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvMyCourses);
            Name = "MyLearningForm";
            Text = "MyLearningForm";
            Load += MyLearningForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMyCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMyCourses;
        private Button button1;
        private Button button2;
    }
}