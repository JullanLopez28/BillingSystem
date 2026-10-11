using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using ScottPlot;


namespace BillingSystem
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();
            dgvTop5.AutoGenerateColumns = false;
            dgvTop5.Columns["FullName"].DataPropertyName = "FullName";
            dgvTop5.Columns["TotalConsumption"].DataPropertyName = "TotalConsumption";
            dgvTop5.Columns["TotalBilled"].DataPropertyName = "TotalBilled";
        }

        private void LoadKpiSummary()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1) Total number of customers
                string qCustomers = "SELECT COUNT(*) FROM Customers;";
                using (MySqlCommand cmd = new MySqlCommand(qCustomers, conn))
                {
                    lblTotalCustomers.Text = "Total Customers: " + cmd.ExecuteScalar().ToString();
                }

                // 2) Total revenue — sum of all PAID bills
                string qRevenue = "SELECT IFNULL(SUM(TotalAmount), 0) FROM Billing WHERE Status = 'Paid';";
                using (MySqlCommand cmd = new MySqlCommand(qRevenue, conn))
                {
                    decimal totalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotalRevenue.Text = "Total Revenue: P" + totalRevenue.ToString("N2");
                }

                // 3) Total unpaid — sum of all UNPAID bills
                string qUnpaid = "SELECT IFNULL(SUM(TotalAmount), 0) FROM Billing WHERE Status = 'Unpaid';";
                using (MySqlCommand cmd = new MySqlCommand(qUnpaid, conn))
                {
                    decimal totalUnpaid = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotalUnpaid.Text = "Total Unpaid: P" + totalUnpaid.ToString("N2");
                }
            }
        }
        private void LoadMonthlyRevenueChart()
        {
            List<double> revenues = new List<double>();
            string[] monthLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Query revenue summed per month for 2026 (Months 1 to 6)
                for (int m = 1; m <= 6; m++)
                {
                    string query = $@"SELECT IFNULL(SUM(TotalAmount), 0) 
                             FROM Billing 
                             WHERE Status = 'Paid' 
                             AND MONTH(BillingDate) = {m} 
                             AND YEAR(BillingDate) = 2026;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        double monthlySum = Convert.ToDouble(cmd.ExecuteScalar());
                        revenues.Add(monthlySum);
                    }
                }
            }

            // Clear previous plots
            plotMonthlyRevenue.Plot.Clear();

            // ScottPlot 5 syntax for adding bars
            for (int i = 0; i < revenues.Count; i++)
            {
                var bar = plotMonthlyRevenue.Plot.Add.Bar(position: i + 1, value: revenues[i]);
            }

            // Set custom X-axis tick labels for months
            ScottPlot.TickGenerators.NumericManual tickGen = new ScottPlot.TickGenerators.NumericManual();
            for (int i = 0; i < monthLabels.Length; i++)
            {
                tickGen.AddMajor(i + 1, monthLabels[i]);
            }
            plotMonthlyRevenue.Plot.Axes.Bottom.TickGenerator = tickGen;

            // Titles and Labels
            plotMonthlyRevenue.Plot.Title("Monthly Revenue (Jan - Jun 2026)");
            plotMonthlyRevenue.Plot.YLabel("Revenue (P)");
            plotMonthlyRevenue.Plot.XLabel("Month");

            // Auto-scale axis limits and refresh
            plotMonthlyRevenue.Plot.Axes.AutoScale();
            plotMonthlyRevenue.Refresh();
        }

        private void LoadPaidVsUnpaidChart()
        {
            double totalPaid = 0;
            double totalUnpaid = 0;

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Query total paid amount
                string qPaid = "SELECT IFNULL(SUM(TotalAmount), 0) FROM Billing WHERE Status = 'Paid';";
                using (MySqlCommand cmd = new MySqlCommand(qPaid, conn))
                {
                    totalPaid = Convert.ToDouble(cmd.ExecuteScalar());
                }

                // Query total unpaid amount
                string qUnpaid = "SELECT IFNULL(SUM(TotalAmount), 0) FROM Billing WHERE Status = 'Unpaid';";
                using (MySqlCommand cmd = new MySqlCommand(qUnpaid, conn))
                {
                    totalUnpaid = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            // Calculate total billings to compute percentages
            double grandTotal = totalPaid + totalUnpaid;
            double paidPercent = grandTotal > 0 ? (totalPaid / grandTotal) * 100 : 0;
            double unpaidPercent = grandTotal > 0 ? (totalUnpaid / grandTotal) * 100 : 0;

            // Clear previous plots
            plotPaidUnpaid.Plot.Clear();

            // Create pie slice objects with percentages included in the labels
            List<ScottPlot.PieSlice> slices = new List<ScottPlot.PieSlice>
    {
        new ScottPlot.PieSlice()
        {
            Value = totalPaid,
            Label = $"Paid: P{totalPaid:N2}\n({paidPercent:F1}%)",
            FillColor = ScottPlot.Color.FromHex("#2ecc71")
        },
        new ScottPlot.PieSlice()
        {
            Value = totalUnpaid,
            Label = $"Unpaid: P{totalUnpaid:N2}\n({unpaidPercent:F1}%)",
            FillColor = ScottPlot.Color.FromHex("#e74c3c")
        }
    };

            // Add pie chart to plot
            var pie = plotPaidUnpaid.Plot.Add.Pie(slices);

            // Chart formatting
            plotPaidUnpaid.Plot.Title("Paid vs Unpaid Billing Ratio");
            plotPaidUnpaid.Plot.Axes.AutoScale();
            plotPaidUnpaid.Refresh();
        }

        private void LoadTop5Customers()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                c.FullName AS FullName,
                IFNULL(SUM(b.Consumption), 0) AS TotalConsumption,
                IFNULL(SUM(b.TotalAmount), 0) AS TotalBilled
            FROM Customers c
            JOIN Billing b ON c.CustomerID = b.CustomerID
            GROUP BY c.CustomerID, c.FullName
            ORDER BY TotalConsumption DESC
            LIMIT 5;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTop5.DataSource = dt;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            LoadKpiSummary();
            LoadMonthlyRevenueChart();
            LoadPaidVsUnpaidChart();
            LoadTop5Customers();
        }

        private void dgvTop5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCloseAnalysis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotalCustomers_Click(object sender, EventArgs e)
        {

        }
    }
}
