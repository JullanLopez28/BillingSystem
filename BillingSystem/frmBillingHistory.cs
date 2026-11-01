using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private readonly int customerId;

        public frmBillingHistory(int selectedCustomerId)
        {
            InitializeComponent();
            customerId = selectedCustomerId;
            this.Load += frmBillingHistory_Load;
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            LoadCustomerHeader();
            LoadBillingRecords();
        }

        private void LoadCustomerHeader()
        {
            string query = "SELECT FullName FROM Customers WHERE CustomerID = @CustomerId;";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lblCustomerName.Text = $"Billing History - {result.ToString()}";
                    }
                }
            }
        }

        private void LoadBillingRecords()
        {
            string query = @"
                SELECT 
                    BillingMonth AS 'Billing Month',
                    PreviousReading AS 'Previous Reading',
                    PresentReading AS 'Present Reading',
                    Consumption,
                    RatePerCubic AS 'Rate Per Cubic',
                    TotalAmount AS 'Total Amount',
                    Status 
                FROM Billing 
                WHERE CustomerID = @CustomerId 
                ORDER BY BillingID ASC;";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvBillingHistory.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No billing records found for this customer.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}