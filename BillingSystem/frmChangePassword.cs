using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        private readonly int loggedInUserId;

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            // 1. Current Password Check
            if (!VerifyCurrentPassword(loggedInUserId, currentPassword))
            {
                MessageBox.Show("Current password is incorrect.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Password Match Check
            if (newPassword != retypePassword)
            {
                MessageBox.Show("New Password and Retype Password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Password Complexity Check
            string complexityError = ValidatePasswordComplexity(newPassword);
            if (!string.IsNullOrEmpty(complexityError))
            {
                MessageBox.Show(complexityError, "Password Requirements Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Update Database
            if (UpdatePasswordInDatabase(loggedInUserId, newPassword))
            {
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update password in database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerifyCurrentPassword(int userId, string inputPassword)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE UserID = @UserId AND Password = @Password;";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Password", inputPassword);
                    conn.Open();
                    long count = Convert.ToInt64(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private string ValidatePasswordComplexity(string password)
        {
            if (password.Length < 8)
                return "Password must be at least 8 characters long.";
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return "Password must contain at least one uppercase letter (A-Z).";
            if (!Regex.IsMatch(password, @"[a-z]"))
                return "Password must contain at least one lowercase letter (a-z).";
            if (!Regex.IsMatch(password, @"[0-9]"))
                return "Password must contain at least one numeric digit (0-9).";
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
                return "Password must contain at least one special character (!@#$%^&*).";

            return null;
        }

        private bool UpdatePasswordInDatabase(int userId, string newPassword)
        {
            string query = "UPDATE Users SET Password = @NewPassword WHERE UserID = @UserId;";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}