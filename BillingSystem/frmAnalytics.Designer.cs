namespace BillingSystem
{
    partial class frmAnalytics
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
            lblTitle = new Label();
            lblTotalCustomers = new Label();
            lblTotalRevenue = new Label();
            lblTotalUnpaid = new Label();
            plotMonthlyRevenue = new ScottPlot.WinForms.FormsPlot();
            plotPaidUnpaid = new ScottPlot.WinForms.FormsPlot();
            lblTop5Title = new Label();
            dgvTop5 = new DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            TotalConsumption = new DataGridViewTextBoxColumn();
            TotalBilled = new DataGridViewTextBoxColumn();
            btnCloseAnalytics = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(400, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Analytics Dashboard";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCustomers.Location = new Point(95, 42);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(149, 21);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "Total Customers: 0";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalRevenue.Location = new Point(417, 42);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(167, 21);
            lblTotalRevenue.TabIndex = 2;
            lblTotalRevenue.Text = "Total Revenue: ₱0.00";
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalUnpaid.Location = new Point(721, 42);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(157, 21);
            lblTotalUnpaid.TabIndex = 3;
            lblTotalUnpaid.Text = "Total Unpaid: ₱0.00";
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            plotMonthlyRevenue.Location = new Point(12, 66);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(572, 280);
            plotMonthlyRevenue.TabIndex = 4;
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            plotPaidUnpaid.Location = new Point(593, 66);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(379, 280);
            plotPaidUnpaid.TabIndex = 5;
            plotPaidUnpaid.Load += formsPlot1_Load;
            // 
            // lblTop5Title
            // 
            lblTop5Title.AutoSize = true;
            lblTop5Title.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTop5Title.Location = new Point(60, 337);
            lblTop5Title.Name = "lblTop5Title";
            lblTop5Title.Size = new Size(325, 30);
            lblTop5Title.TabIndex = 6;
            lblTop5Title.Text = "Top 5 Customers by Consumption";
            // 
            // dgvTop5
            // 
            dgvTop5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTop5.BackgroundColor = SystemColors.ControlLightLight;
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Columns.AddRange(new DataGridViewColumn[] { FullName, TotalConsumption, TotalBilled });
            dgvTop5.EnableHeadersVisualStyles = false;
            dgvTop5.Location = new Point(60, 370);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.Size = new Size(890, 190);
            dgvTop5.TabIndex = 7;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.FillWeight = 50F;
            FullName.HeaderText = "FullName";
            FullName.Name = "FullName";
            // 
            // TotalConsumption
            // 
            TotalConsumption.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalConsumption.FillWeight = 25F;
            TotalConsumption.HeaderText = "TotalConsumption";
            TotalConsumption.Name = "TotalConsumption";
            // 
            // TotalBilled
            // 
            TotalBilled.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalBilled.FillWeight = 25F;
            TotalBilled.HeaderText = "TotalBilled";
            TotalBilled.Name = "TotalBilled";
            // 
            // btnCloseAnalytics
            // 
            btnCloseAnalytics.Location = new Point(837, 566);
            btnCloseAnalytics.Name = "btnCloseAnalytics";
            btnCloseAnalytics.Size = new Size(94, 35);
            btnCloseAnalytics.TabIndex = 8;
            btnCloseAnalytics.Text = "Close";
            btnCloseAnalytics.UseVisualStyleBackColor = true;
            btnCloseAnalytics.Click += btnCloseAnalytics_Click;
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(btnCloseAnalytics);
            Controls.Add(dgvTop5);
            Controls.Add(lblTop5Title);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(plotMonthlyRevenue);
            Controls.Add(lblTotalUnpaid);
            Controls.Add(lblTotalRevenue);
            Controls.Add(lblTotalCustomers);
            Controls.Add(lblTitle);
            Name = "frmAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Analytics Dashboard";
            Load += frmAnalytics_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTop5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTotalCustomers;
        private Label lblTotalRevenue;
        private Label lblTotalUnpaid;
        private ScottPlot.WinForms.FormsPlot plotMonthlyRevenue;
        private ScottPlot.WinForms.FormsPlot plotPaidUnpaid;
        private Label lblTop5Title;
        private DataGridView dgvTop5;
        private Button btnCloseAnalytics;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn TotalConsumption;
        private DataGridViewTextBoxColumn TotalBilled;
    }
}