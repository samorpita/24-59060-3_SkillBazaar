namespace SkillBazaar.Forms
{
    partial class SignUpForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.radioStudent = new System.Windows.Forms.RadioButton();
            this.radioInstructor = new System.Windows.Forms.RadioButton();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Create Your Account";
            //
            // radioStudent
            //
            this.radioStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioStudent.Location = new System.Drawing.Point(50, 65);
            this.radioStudent.Name = "radioStudent";
            this.radioStudent.Size = new System.Drawing.Size(150, 24);
            this.radioStudent.Text = "I\'m a Student";
            this.radioStudent.Checked = true;
            this.radioStudent.TabStop = true;
            //
            // radioInstructor
            //
            this.radioInstructor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioInstructor.Location = new System.Drawing.Point(220, 65);
            this.radioInstructor.Name = "radioInstructor";
            this.radioInstructor.Size = new System.Drawing.Size(150, 24);
            this.radioInstructor.Text = "I\'m an Instructor";
            //
            // lblFullName
            //
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.Location = new System.Drawing.Point(50, 100);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(150, 20);
            this.lblFullName.Text = "Full Name";
            //
            // txtFullName
            //
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(50, 123);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(400, 27);
            //
            // lblEmail
            //
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.Location = new System.Drawing.Point(50, 160);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 20);
            this.lblEmail.Text = "Email";
            //
            // txtEmail
            //
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(50, 183);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 27);
            //
            // lblPassword
            //
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.Location = new System.Drawing.Point(50, 220);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 20);
            this.lblPassword.Text = "Password";
            //
            // txtPassword
            //
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(50, 243);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\u25CF';
            this.txtPassword.Size = new System.Drawing.Size(400, 27);
            //
            // lblPhone
            //
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.Location = new System.Drawing.Point(50, 280);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(150, 20);
            this.lblPhone.Text = "Phone";
            //
            // txtPhone
            //
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(50, 303);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(400, 27);
            //
            // lblAddress
            //
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.Location = new System.Drawing.Point(50, 340);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(150, 20);
            this.lblAddress.Text = "Address";
            //
            // txtAddress
            //
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(50, 363);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 27);
            //
            // btnCreateAccount
            //
            this.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.FlatAppearance.BorderSize = 0;
            this.btnCreateAccount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreateAccount.ForeColor = System.Drawing.Color.White;
            this.btnCreateAccount.Location = new System.Drawing.Point(50, 410);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(400, 45);
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            //
            // lnkLogin
            //
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkLogin.Location = new System.Drawing.Point(50, 465);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(400, 23);
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Already have an account? Log In";
            this.lnkLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            //
            // SignUpForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 520);
            this.Controls.Add(this.lnkLogin);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.radioInstructor);
            this.Controls.Add(this.radioStudent);
            this.Controls.Add(this.lblTitle);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkillBazaar - Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radioStudent;
        private System.Windows.Forms.RadioButton radioInstructor;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.LinkLabel lnkLogin;
    }
}
