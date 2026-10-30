using BillingSystem.Database;
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
    public partial class frmBillingHistory : Form
    {
        private readonly int customerId;
        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;

            LoadBillingHistory();

        }
        private void LoadBillingHistory()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Retrieve the selected customer's name.
                    string customerSql = @"
                SELECT FullName
                FROM Customers
                WHERE CustomerID = @CustomerID";

                    using (var customerCmd = new MySqlCommand(customerSql, conn))
                    {
                        customerCmd.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        object customerName = customerCmd.ExecuteScalar();

                        if (customerName == null || customerName == DBNull.Value)
                        {
                            MessageBox.Show("Customer not found.");
                            this.Close();
                            return;
                        }

                        lblCustomerName.Text =
                            "Billing History — " + customerName.ToString();
                    }

                    // Retrieve only this customer's billing records.
                    string billingSql = @"
                SELECT BillingMonth,
                       PreviousReading,
                       PresentReading,
                       Consumption,
                       RatePerCubic,
                       TotalAmount,
                       Status
                FROM Billing
                WHERE CustomerID = @CustomerID
                ORDER BY BillingDate DESC";

                    using (var billingCmd = new MySqlCommand(billingSql, conn))
                    {
                        billingCmd.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        using (var adapter = new MySqlDataAdapter(billingCmd))
                        {
                            var table = new System.Data.DataTable();
                            adapter.Fill(table);

                            dgvBillingHistory.DataSource = table;

                            dgvBillingHistory.Columns["BillingMonth"].HeaderText = "Billing Month";
                            dgvBillingHistory.Columns["PreviousReading"].HeaderText = "Previous Reading";
                            dgvBillingHistory.Columns["PresentReading"].HeaderText = "Present Reading";
                            dgvBillingHistory.Columns["Consumption"].HeaderText = "Consumption";
                            dgvBillingHistory.Columns["RatePerCubic"].HeaderText = "Rate Per Cubic";
                            dgvBillingHistory.Columns["TotalAmount"].HeaderText = "Total Amount";
                            dgvBillingHistory.Columns["Status"].HeaderText = "Status";

                            if (table.Rows.Count == 0)
                            {
                                MessageBox.Show(
                                    "No billing records found for this customer.",
                                    "No Billing Records",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load billing history: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public frmBillingHistory()
        {
            InitializeComponent();
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
