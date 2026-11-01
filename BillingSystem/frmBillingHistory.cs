using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private readonly int _customerId;

        // Only the customer's ID is passed in; everything else is
        // looked up from the database.
        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            ConfigureGrid();

            try
            {
                string customerName = GetCustomerName();

                if (customerName == null)
                {
                    MessageBox.Show("The selected customer could not be found.",
                        "Customer Not Found", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblTitle.Text = $"Billing History — {customerName}";
                LoadBillingRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing history:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.BackgroundColor;
            lblTitle.ForeColor = AppTheme.PrimaryColor;
            btnClose.BackColor = AppTheme.SecondaryColor;
            btnClose.ForeColor = Color.White;

            dgvBilling.EnableHeadersVisualStyles = false;
            dgvBilling.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
            dgvBilling.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBilling.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvBilling.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;
        }

        private void ConfigureGrid()
        {
            dgvBilling.AutoGenerateColumns = false;
            dgvBilling.Columns.Clear();
            dgvBilling.ReadOnly = true;
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AllowUserToDeleteRows = false;
            dgvBilling.RowHeadersVisible = false;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddColumn("Billing Month", "BillingMonthText", null, false);
            AddColumn("Previous Reading", "PreviousReading", null, true);
            AddColumn("Present Reading", "PresentReading", null, true);
            AddColumn("Consumption", "Consumption", null, true);
            AddColumn("Rate Per Cubic", "RatePerCubic", "N2", true);
            AddColumn("Total Amount", "TotalAmount", "N2", true);
            AddColumn("Status", "Status", null, false);
        }

        private void AddColumn(string header, string dataProperty,
                               string format, bool alignRight)
        {
            var col = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = dataProperty,
                Name = dataProperty
            };

            if (format != null)
                col.DefaultCellStyle.Format = format;
            if (alignRight)
                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

            dgvBilling.Columns.Add(col);
        }

        /// <summary>
        /// Gets the customer's full name from the Customers table.
        /// Returns null if the customer does not exist.
        /// </summary>
        private string GetCustomerName()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT FullName FROM Customers " +
                             "WHERE CustomerID = @CustomerID;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", _customerId);
                    object result = cmd.ExecuteScalar();

                    return (result == null || result == DBNull.Value)
                        ? null
                        : result.ToString();
                }
            }
        }

        /// <summary>
        /// Loads ONLY the selected customer's billing records.
        /// </summary>
        private void LoadBillingRecords()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT BillingMonth AS BillingMonthText,
                                      PreviousReading,
                                      PresentReading,
                                      (PresentReading - PreviousReading) AS Consumption,
                                      RatePerCubic,
                                      TotalAmount,
                                      Status
                               FROM Billing
                               WHERE CustomerID = @CustomerID
                               ORDER BY BillingDate ASC, BillingID ASC;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", _customerId);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvBilling.DataSource = dt;

                        // POPUP 2: customer exists but has zero billing records
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show(
                                "No billing records were found for this customer.",
                                "No Records", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        // Colors the Status cell using the AppTheme colors
        private void dgvBilling_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvBilling.Columns[e.ColumnIndex].DataPropertyName != "Status") return;

            string status = Convert.ToString(e.Value) ?? "";

            if (status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase))
                e.CellStyle.BackColor = AppTheme.InactiveRowColor;
            else if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase))
                e.CellStyle.BackColor = AppTheme.ActiveRowColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}