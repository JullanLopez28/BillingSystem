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
            lblCurrentPassword = new Label();
            lblNewPassword = new Label();
            lblRetypePassword = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtRetypePassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(246, 91);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(125, 20);
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Current Password:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(246, 163);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(107, 20);
            lblNewPassword.TabIndex = 1;
            lblNewPassword.Text = "New Password:";
            // 
            // lblRetypePassword
            // 
            lblRetypePassword.AutoSize = true;
            lblRetypePassword.Location = new Point(246, 241);
            lblRetypePassword.Name = "lblRetypePassword";
            lblRetypePassword.Size = new Size(123, 20);
            lblRetypePassword.TabIndex = 2;
            lblRetypePassword.Text = "Retype Password:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(431, 88);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(125, 27);
            txtCurrentPassword.TabIndex = 3;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(431, 160);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(125, 27);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(431, 238);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.Size = new Size(125, 27);
            txtRetypePassword.TabIndex = 5;
            txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(246, 314);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Password";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(431, 314);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRetypePassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblRetypePassword);
            Controls.Add(lblNewPassword);
            Controls.Add(lblCurrentPassword);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentPassword;
        private Label lblNewPassword;
        private Label lblRetypePassword;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtRetypePassword;
        private Button btnSave;
        private Button btnCancel;
    }
}