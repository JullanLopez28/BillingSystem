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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            btnCloseAnalysis = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(387, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Analytics Dashboard";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += label1_Click;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.Anchor = AnchorStyles.Top;
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCustomers.Location = new Point(177, 67);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(140, 20);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "Total Customers: 0";
            lblTotalCustomers.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalCustomers.Click += lblTotalCustomers_Click;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Anchor = AnchorStyles.Top;
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.Location = new Point(410, 67);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(157, 20);
            lblTotalRevenue.TabIndex = 2;
            lblTotalRevenue.Text = "Total Revenue: ₱0.00";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.Anchor = AnchorStyles.Top;
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUnpaid.Location = new Point(648, 67);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(147, 20);
            lblTotalUnpaid.TabIndex = 3;
            lblTotalUnpaid.Text = "Total Unpaid: ₱0.00";
            lblTotalUnpaid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Anchor = AnchorStyles.Top;
            plotMonthlyRevenue.Location = new Point(12, 103);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(450, 250);
            plotMonthlyRevenue.TabIndex = 4;
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Anchor = AnchorStyles.Top;
            plotPaidUnpaid.Location = new Point(508, 103);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(450, 250);
            plotPaidUnpaid.TabIndex = 5;
            // 
            // lblTop5Title
            // 
            lblTop5Title.AutoSize = true;
            lblTop5Title.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop5Title.Location = new Point(63, 382);
            lblTop5Title.Name = "lblTop5Title";
            lblTop5Title.Size = new Size(293, 20);
            lblTop5Title.TabIndex = 6;
            lblTop5Title.Text = "Top 5 Customers by Consumption";
            // 
            // dgvTop5
            // 
            dgvTop5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTop5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTop5.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTop5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Columns.AddRange(new DataGridViewColumn[] { FullName, TotalConsumption, TotalBilled });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTop5.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTop5.Location = new Point(63, 414);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTop5.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvTop5.Size = new Size(855, 79);
            dgvTop5.TabIndex = 7;
            dgvTop5.CellContentClick += dgvTop5_CellContentClick;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.HeaderText = "FullName";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // TotalConsumption
            // 
            TotalConsumption.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalConsumption.HeaderText = "TotalConsumption";
            TotalConsumption.MinimumWidth = 6;
            TotalConsumption.Name = "TotalConsumption";
            // 
            // TotalBilled
            // 
            TotalBilled.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalBilled.HeaderText = "TotalBilled";
            TotalBilled.MinimumWidth = 6;
            TotalBilled.Name = "TotalBilled";
            // 
            // btnCloseAnalysis
            // 
            btnCloseAnalysis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCloseAnalysis.Location = new Point(802, 542);
            btnCloseAnalysis.Name = "btnCloseAnalysis";
            btnCloseAnalysis.Size = new Size(116, 34);
            btnCloseAnalysis.TabIndex = 8;
            btnCloseAnalysis.Text = "Close";
            btnCloseAnalysis.UseVisualStyleBackColor = true;
            btnCloseAnalysis.Click += btnCloseAnalysis_Click;
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(lblTotalCustomers);
            Controls.Add(lblTotalRevenue);
            Controls.Add(btnCloseAnalysis);
            Controls.Add(lblTotalUnpaid);
            Controls.Add(dgvTop5);
            Controls.Add(lblTop5Title);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(plotMonthlyRevenue);
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
        private Button btnCloseAnalysis;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn TotalConsumption;
        private DataGridViewTextBoxColumn TotalBilled;
    }
}