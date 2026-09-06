namespace CourseCatalogform
{
    partial class CartForm
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
            dgvCart = new DataGridView();
            lblTotal = new Label();
            btnCheckout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(62, 182);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(380, 150);
            dgvCart.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(69, 344);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Cart Total: ৳0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(311, 338);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(131, 23);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Proceed to Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCheckout);
            Controls.Add(lblTotal);
            Controls.Add(dgvCart);
            Name = "CartForm";
            Text = "CartForm";
            Load += CartForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCart;
        private Label lblTotal;
        private Button btnCheckout;
    }
}