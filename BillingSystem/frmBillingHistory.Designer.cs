namespace BillingSystem
{
    partial class frmBillingHistory
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
            lblCustomerName = new Label();
            dgvBillingHistory = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerName.Location = new Point(24, 20);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(153, 28);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Billing History";
            // 
            // dgvBillingHistory
            // 
            dgvBillingHistory.AllowUserToAddRows = false;
            dgvBillingHistory.AllowUserToDeleteRows = false;
            dgvBillingHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillingHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillingHistory.Location = new Point(24, 65);
            dgvBillingHistory.MultiSelect = false;
            dgvBillingHistory.Name = "dgvBillingHistory";
            dgvBillingHistory.ReadOnly = true;
            dgvBillingHistory.RowHeadersWidth = 51;
            dgvBillingHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillingHistory.Size = new Size(748, 310);
            dgvBillingHistory.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(652, 395);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmBillingHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 450);
            Controls.Add(btnClose);
            Controls.Add(dgvBillingHistory);
            Controls.Add(lblCustomerName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmBillingHistory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing History";
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerName;
        private DataGridView dgvBillingHistory;
        private Button btnClose;
    }
}