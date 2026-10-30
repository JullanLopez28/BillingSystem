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
            dgvBillingHistory = new DataGridView();
            lblCustomerName = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvBillingHistory
            // 
            dgvBillingHistory.AllowUserToAddRows = false;
            dgvBillingHistory.AllowUserToDeleteRows = false;
            dgvBillingHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillingHistory.BackgroundColor = SystemColors.ButtonHighlight;
            dgvBillingHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillingHistory.Location = new Point(47, 89);
            dgvBillingHistory.MultiSelect = false;
            dgvBillingHistory.Name = "dgvBillingHistory";
            dgvBillingHistory.ReadOnly = true;
            dgvBillingHistory.RowHeadersWidth = 51;
            dgvBillingHistory.Size = new Size(881, 291);
            dgvBillingHistory.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(47, 25);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(378, 31);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Billing History — Customer Name";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(834, 430);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmBillingHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 503);
            Controls.Add(btnClose);
            Controls.Add(lblCustomerName);
            Controls.Add(dgvBillingHistory);
            Name = "frmBillingHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing History";
            Load += frmBillingHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBillingHistory;
        private Label lblCustomerName;
        private Button btnClose;
    }
}