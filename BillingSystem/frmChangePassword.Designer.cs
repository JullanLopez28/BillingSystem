namespace BillingSystem
{
    partial class frmChangePassword
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
            label1 = new Label();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblRetypePassword = new Label();
            txtRetypePassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(169, 23);
            label1.Name = "label1";
            label1.Size = new Size(200, 31);
            label1.TabIndex = 0;
            label1.Text = "Change Password";
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(47, 135);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(125, 20);
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "Current Password:";
            lblCurrentPassword.Click += lblCurrentPassword_Click;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(207, 132);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(245, 27);
            txtCurrentPassword.TabIndex = 2;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(47, 213);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(107, 20);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(207, 210);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(245, 27);
            txtNewPassword.TabIndex = 4;
            // 
            // lblRetypePassword
            // 
            lblRetypePassword.AutoSize = true;
            lblRetypePassword.Location = new Point(47, 277);
            lblRetypePassword.Name = "lblRetypePassword";
            lblRetypePassword.Size = new Size(123, 20);
            lblRetypePassword.TabIndex = 5;
            lblRetypePassword.Text = "Retype Password:";
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(207, 274);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.PasswordChar = '*';
            txtRetypePassword.Size = new Size(245, 27);
            txtRetypePassword.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(169, 360);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(358, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 502);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRetypePassword);
            Controls.Add(lblRetypePassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(label1);
            Name = "frmChangePassword";
            Text = "Change Password";
            Load += frmChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblRetypePassword;
        private TextBox txtRetypePassword;
        private Button btnSave;
        private Button btnCancel;
    }
}