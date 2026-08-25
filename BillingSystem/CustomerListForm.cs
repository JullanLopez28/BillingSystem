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
    public partial class CustomerListForm : Form
    {
        public CustomerListForm()
        {
            InitializeComponent();
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
    }
}
