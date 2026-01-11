using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FancyDressShop.Models;

namespace FancyDressShop
{
    public partial class AdminDashboard : UserControl
    {
        private readonly RentalRepository _rentalRepo;

        public AdminDashboard()
        {
            InitializeComponent();
            _rentalRepo = new RentalRepository();

            dgvCategoryRevenue.AutoGenerateColumns = false;
            dgvTopDresses.AutoGenerateColumns = false;

            dtpStartDate.Value = new DateTime(1753, 1, 1);
            dtpEndDate.Value = new DateTime(9998, 12, 31);

            cmbTimePeriodType.Items.Clear();
            cmbTimePeriodType.Items.Add("วัน");
            cmbTimePeriodType.Items.Add("สัปดาห์");
            cmbTimePeriodType.Items.Add("เดือน");
            cmbTimePeriodType.Items.Add("ปี");
            cmbTimePeriodType.SelectedIndex = 0;

            nudPeriodCount.Minimum = 1;
            nudPeriodCount.Value = 1;

            cmbSpecialPeriod.Items.Clear();
            cmbSpecialPeriod.Items.Add("ทั้งหมด");
            cmbSpecialPeriod.Items.Add("วันนี้");
            cmbSpecialPeriod.Items.Add("เมื่อวาน");
            cmbSpecialPeriod.Items.Add("สัปดาห์นี้");
            cmbSpecialPeriod.Items.Add("สัปดาห์ที่แล้ว");
            cmbSpecialPeriod.Items.Add("เดือนนี้");
            cmbSpecialPeriod.Items.Add("เดือนที่แล้ว");
            cmbSpecialPeriod.Items.Add("ปีนี้");
            cmbSpecialPeriod.Items.Add("ปีที่แล้ว");
            cmbSpecialPeriod.Items.Add("ย้อนหลัง...");
            cmbSpecialPeriod.Items.Add("กำหนดเอง");

            cmbTimePeriodType.Visible = false;
            nudPeriodCount.Visible = false;
            lblPeriodCount.Visible = false;
            lblPeriodType.Visible = false;

            lblDateRange.Visible = false;
            lblTo.Visible = false;
            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;

            cmbSpecialPeriod.SelectedIndexChanged += CmbSpecialPeriod_SelectedIndexChanged;
            cmbTimePeriodType.SelectedIndexChanged += CmbTimePeriodType_SelectedIndexChanged;
            nudPeriodCount.ValueChanged += NudPeriodCount_ValueChanged;
            btnLoadReport.Click += btnLoadReport_Click;

            cmbSpecialPeriod.SelectedIndex = 0;
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            CalculateDateRange();

            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            if (startDate.Date > endDate.Date)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องมาก่อนวันที่สิ้นสุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FinancialSummary summary = _rentalRepo.GetFinancialSummary(startDate, endDate);
                lblTotalRevenue.Text = summary.TotalRevenue.ToString("N2") + " บาท";
                lblTotalFines.Text = summary.TotalFines.ToString("N2") + " บาท";
                lblTotalRentals.Text = summary.TotalRentals.ToString() + " รายการ";

                List<TopDressReport> topDresses = _rentalRepo.GetTopDresses(startDate, endDate, 5);

                dgvTopDresses.Columns.Clear();
                dgvTopDresses.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DressName", HeaderText = "ชื่อชุด", DataPropertyName = "DressName" });
                dgvTopDresses.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Category", HeaderText = "หมวดหมู่", DataPropertyName = "Category" });
                dgvTopDresses.Columns.Add(new DataGridViewTextBoxColumn() { Name = "RentalCount", HeaderText = "จำนวนครั้งที่เช่า", DataPropertyName = "RentalCount" });
                dgvTopDresses.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TotalRevenue", HeaderText = "รายได้รวม", DataPropertyName = "TotalRevenue" });
                dgvTopDresses.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TotalRentalDays", HeaderText = "รวมวันเช่า", DataPropertyName = "TotalRentalDays" });

                dgvTopDresses.DataSource = topDresses;

                if (dgvTopDresses.Columns.Count > 0)
                {
                    dgvTopDresses.Columns["TotalRevenue"].DefaultCellStyle.Format = "N2";
                    dgvTopDresses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                List<CategoryRevenueReport> categoryRevenue = _rentalRepo.GetCategoryRevenue(startDate, endDate);

                dgvCategoryRevenue.Columns.Clear();
                dgvCategoryRevenue.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Category", HeaderText = "หมวดหมู่", DataPropertyName = "Category" });
                dgvCategoryRevenue.Columns.Add(new DataGridViewTextBoxColumn() { Name = "RentalCount", HeaderText = "จำนวนครั้งที่เช่า", DataPropertyName = "RentalCount" });
                dgvCategoryRevenue.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TotalRevenue", HeaderText = "รายได้รวม", DataPropertyName = "TotalRevenue" });

                dgvCategoryRevenue.DataSource = categoryRevenue;

                if (dgvCategoryRevenue.Columns.Count > 0)
                {
                    dgvCategoryRevenue.Columns["TotalRevenue"].DefaultCellStyle.Format = "N2";
                    dgvCategoryRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดรายงาน: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbSpecialPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPeriod = cmbSpecialPeriod.SelectedItem?.ToString();

            bool showCustomDatePickers = (selectedPeriod == "กำหนดเอง");
            bool showPeriodSelectors = (selectedPeriod == "ย้อนหลัง...");

            dtpStartDate.Visible = showCustomDatePickers;
            dtpEndDate.Visible = showCustomDatePickers;
            lblDateRange.Visible = showCustomDatePickers;
            lblTo.Visible = showCustomDatePickers;

            cmbTimePeriodType.Visible = showPeriodSelectors;
            nudPeriodCount.Visible = showPeriodSelectors;
            lblPeriodCount.Visible = showPeriodSelectors;
            lblPeriodType.Visible = showPeriodSelectors;

            if (!showCustomDatePickers)
            {
                CalculateDateRange();

                btnLoadReport_Click(this, EventArgs.Empty);
            }
        }

        private void CmbTimePeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLoadReport_Click(this, EventArgs.Empty);
        }

        private void NudPeriodCount_ValueChanged(object sender, EventArgs e)
        {
            btnLoadReport_Click(this, EventArgs.Empty);
        }

        private void CalculateDateRange()
        {
            DateTime today = DateTime.Now.Date;
            string specialPeriod = cmbSpecialPeriod.SelectedItem?.ToString();

            switch (specialPeriod)
            {
                case "ทั้งหมด":
                    dtpStartDate.Value = new DateTime(1753, 1, 1);
                    dtpEndDate.Value = new DateTime(9998, 12, 31);
                    break;
                case "วันนี้":
                    dtpStartDate.Value = today;
                    dtpEndDate.Value = today;
                    break;
                case "เมื่อวาน":
                    dtpStartDate.Value = today.AddDays(-1);
                    dtpEndDate.Value = today.AddDays(-1);
                    break;
                case "สัปดาห์นี้":
                    int diffThisWeek = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
                    if (diffThisWeek < 0) diffThisWeek += 7;
                    dtpStartDate.Value = today.AddDays(-diffThisWeek);
                    dtpEndDate.Value = today;
                    break;
                case "สัปดาห์ที่แล้ว":
                    DateTime lastWeekStart = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday).AddDays(-7);
                    dtpStartDate.Value = lastWeekStart;
                    dtpEndDate.Value = lastWeekStart.AddDays(6);
                    break;
                case "เดือนนี้":
                    dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
                    dtpEndDate.Value = today;
                    break;
                case "เดือนที่แล้ว":
                    DateTime lastMonth = today.AddMonths(-1);
                    dtpStartDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    dtpEndDate.Value = new DateTime(today.Year, today.Month, 1).AddDays(-1);
                    break;
                case "ปีนี้":
                    dtpStartDate.Value = new DateTime(today.Year, 1, 1);
                    dtpEndDate.Value = today;
                    break;
                case "ปีที่แล้ว":
                    dtpStartDate.Value = new DateTime(today.Year - 1, 1, 1);
                    dtpEndDate.Value = new DateTime(today.Year - 1, 12, 31);
                    break;
                case "ย้อนหลัง...":
                    CalculateDateRangeFromPeriodSelectors();
                    break;
                case "กำหนดเอง":
                    break;
            }
        }

        private void CalculateDateRangeFromPeriodSelectors()
        {
            DateTime today = DateTime.Now.Date;
            string periodType = cmbTimePeriodType.SelectedItem?.ToString();
            int periodCount = (int)nudPeriodCount.Value;

            dtpEndDate.Value = today;

            switch (periodType)
            {
                case "วัน":
                    dtpStartDate.Value = today.AddDays(-periodCount + 1);
                    break;
                case "สัปดาห์":
                    dtpStartDate.Value = today.AddDays(-(periodCount * 7));
                    break;
                case "เดือน":
                    dtpStartDate.Value = today.AddMonths(-periodCount);
                    break;
                case "ปี":
                    dtpStartDate.Value = today.AddYears(-periodCount);
                    break;
            }
        }
    }
}