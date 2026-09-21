using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;



namespace BillingSystem
{
    public partial class CustomerListForm : Form
    {
        public CustomerListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }
        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns[0].DataPropertyName = "CustomerID";
            dgvCustomers.Columns[1].DataPropertyName = "FullName";
            dgvCustomers.Columns[2].DataPropertyName = "Address";
            dgvCustomers.Columns[3].DataPropertyName = "ContactNumber";
            dgvCustomers.Columns[4].DataPropertyName = "Email";
            dgvCustomers.Columns[5].DataPropertyName = "Balance";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Add logic to delete the selected customer from dgvCustomers
            // For now, just show a message box as a placeholder
            MessageBox.Show("Delete button clicked.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Add your logout logic here, for example:
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT CustomerID, FullName, Address,
                                  ContactNumber, Email, Balance, Status
                           FROM Customers
                           ORDER BY CustomerID DESC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.DataSource = dt;

                        // Format columns
                        if (dgvCustomers.Columns.Count > 0)
                        {
                            dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                            dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                            dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact";
                            dgvCustomers.Columns["Balance"].DefaultCellStyle.Format = "N2";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void SearchCustomers(string keyword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized SELECT with WHERE ... LIKE
                    string sql = @"SELECT CustomerID,
                                  FullName,
                                  Address,
                                  ContactNumber,
                                  Email,
                                  Balance,
                                  Status
                           FROM Customers
                           WHERE FullName LIKE @keyword
                              OR Address LIKE @keyword
                              OR ContactNumber LIKE @keyword
                           ORDER BY FullName ASC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // %keyword% matches the search text anywhere in the column
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvCustomers.DataSource = dt;

                            lblTitle.Text = $"Customer List ({dt.Rows.Count} result(s))";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers:\n{ex.Message}",
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Empty search box → show all customers again
                LoadCustomers();
            }
            else
            {
                SearchCustomers(keyword);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        
    }
}
