using BillingSystem.Database;
using BillingSystem.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Please enter your current password.");
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter your new password.");
                txtNewPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(retypePassword))
            {
                MessageBox.Show("Please retype your new password.");
                txtRetypePassword.Focus();
                return;
            }

            if (newPassword != retypePassword)
            {
                MessageBox.Show("New password and retyped password do not match.",
                                "Password Mismatch",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtRetypePassword.Focus();
                return;
            }

            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must contain at least 8 characters.",
                                "Invalid Password",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            if (!newPassword.Any(char.IsUpper))
            {
                MessageBox.Show("Password must contain at least one uppercase letter (A-Z).",
                                "Invalid Password",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            if (!newPassword.Any(char.IsLower))
            {
                MessageBox.Show("Password must contain at least one lowercase letter (a-z).",
                                "Invalid Password",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            if (!newPassword.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain at least one numeric digit (0-9).",
                                "Invalid Password",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            if (!newPassword.Any(c => "!@#$%^&*".Contains(c)))
            {
                MessageBox.Show(
                    "Password must contain at least one special character (!@#$%^&*).",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string checkSql = @"SELECT Password
                            FROM Users
                            WHERE UserID = @UserID";

                    using (var cmd = new MySqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value ||
                            result.ToString() != currentPassword)
                        {
                            MessageBox.Show(
                                "Your current password is incorrect.",
                                "Password Change Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtCurrentPassword.Focus();
                            return;
                        }

                        string updateSql = @"UPDATE Users
                     SET Password = @NewPassword
                     WHERE UserID = @UserID";

                        using (var updateCmd = new MySqlCommand(updateSql, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                            updateCmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(
                                    "Your password has been changed successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "The password could not be changed. Please try again.",
                                    "Update Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking your password: " + ex.Message);
                return;
            }
        }


        private void lblCurrentPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
