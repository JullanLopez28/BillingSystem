using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        private const int MinLength = 8;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Apply AppTheme colors
            this.BackColor = AppTheme.BackgroundColor;
            lblTitle.ForeColor = AppTheme.PrimaryColor;
            btnSave.BackColor = AppTheme.SuccessColor;
            btnSave.ForeColor = Color.White;
            btnCancel.BackColor = AppTheme.SecondaryColor;
            btnCancel.ForeColor = Color.White;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            try
            {
                // VALIDATION 1: Current Password must match the database
                if (!IsCurrentPasswordCorrect(currentPassword))
                {
                    MessageBox.Show(
                        "The Current Password is incorrect. Your password was not changed.",
                        "Incorrect Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtCurrentPassword.Clear();
                    txtCurrentPassword.Focus();
                    return;
                }

                // VALIDATION 2: New and Retype must match exactly
                if (newPassword != retypePassword)
                {
                    MessageBox.Show(
                        "New Password and Retype Password do not match.",
                        "Passwords Do Not Match", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtRetypePassword.Clear();
                    txtRetypePassword.Focus();
                    return;
                }

                // VALIDATION 3: Complexity rules (all unmet rules shown at once)
                List<string> missing = GetMissingRules(newPassword);
                if (missing.Count > 0)
                {
                    MessageBox.Show(
                        "Your New Password is missing the following requirement(s):\n\n- "
                        + string.Join("\n- ", missing),
                        "Password Too Weak", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return;
                }

                // VALIDATION 4: Save only if everything above passed
                if (UpdatePassword(newPassword))
                {
                    AuditLogger.Log("CHANGE_PASSWORD",
                        $"{AppSession.CurrentUsername} changed their password.");

                    MessageBox.Show("Your password was changed successfully.",
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No account was updated. Please log in again.",
                        "Not Updated", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reads the stored password of the logged-in user (by UserID)
        /// and compares it with what was typed (case-sensitive).
        /// </summary>
        private bool IsCurrentPasswordCorrect(string enteredPassword)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Password FROM Users WHERE UserID = @UserID;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return false;

                    return string.Equals(result.ToString(), enteredPassword,
                                         StringComparison.Ordinal);
                }
            }
        }

        /// <summary>
        /// Returns a list of every complexity rule the password fails.
        /// An empty list means the password is acceptable.
        /// </summary>
        private List<string> GetMissingRules(string password)
        {
            var missing = new List<string>();

            if (password.Length < MinLength)
                missing.Add("At least 8 characters long");
            if (!password.Any(char.IsUpper))
                missing.Add("At least one uppercase letter (A-Z)");
            if (!password.Any(char.IsLower))
                missing.Add("At least one lowercase letter (a-z)");
            if (!password.Any(char.IsDigit))
                missing.Add("At least one number (0-9)");
            if (!password.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
                missing.Add("At least one special character (e.g. !@#$%^&*)");

            return missing;
        }

        /// <summary>
        /// Updates ONLY the logged-in user's row, identified by UserID.
        /// </summary>
        private bool UpdatePassword(string newPassword)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Users
                               SET Password = @NewPassword
                               WHERE UserID = @UserID;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
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