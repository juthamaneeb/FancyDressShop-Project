namespace FancyDressShop
{
    partial class AdminDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRentals = new System.Windows.Forms.Label();
            this.lblTotalFines = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.tabControlReports = new System.Windows.Forms.TabControl();
            this.tabPageTopDresses = new System.Windows.Forms.TabPage();
            this.dgvTopDresses = new System.Windows.Forms.DataGridView();
            this.tabPageCategoryReport = new System.Windows.Forms.TabPage();
            this.dgvCategoryRevenue = new System.Windows.Forms.DataGridView();
            this.cmbTimePeriodType = new System.Windows.Forms.ComboBox();
            this.nudPeriodCount = new System.Windows.Forms.NumericUpDown();
            this.cmbSpecialPeriod = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPeriodCount = new System.Windows.Forms.Label();
            this.lblPeriodType = new System.Windows.Forms.Label();
            this.btnLoadReport = new RoundedButton();
            this.panel2.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControlReports.SuspendLayout();
            this.tabPageTopDresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopDresses)).BeginInit();
            this.tabPageCategoryReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodCount)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(474, 29);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(221, 31);
            this.dtpStartDate.TabIndex = 30;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(748, 29);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(220, 31);
            this.dtpEndDate.TabIndex = 31;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(1157, 117);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(125, 28);
            this.lblGrandTotal.TabIndex = 33;
            this.lblGrandTotal.Text = "ยอดเงินทั้งหมด";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1555, 90);
            this.panel2.TabIndex = 34;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lblTo.Location = new System.Drawing.Point(701, 32);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 25);
            this.lblTo.TabIndex = 36;
            this.lblTo.Text = "ถึง :";
            // 
            // lblDateRange
            // 
            this.lblDateRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lblDateRange.Location = new System.Drawing.Point(338, 32);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(130, 25);
            this.lblDateRange.TabIndex = 34;
            this.lblDateRange.Text = "เลือกช่วงเวลา :";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.tableLayoutPanel1);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 90);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1555, 55);
            this.pnlSummary.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalRentals, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalFines, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalRevenue, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1555, 55);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 28);
            this.label1.TabIndex = 37;
            this.label1.Text = "รายได้รวม (ค่าเช่า) :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(273, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 28);
            this.label2.TabIndex = 38;
            this.label2.Text = "รายได้จากค่าปรับ :";
            // 
            // lblTotalRentals
            // 
            this.lblTotalRentals.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalRentals.AutoSize = true;
            this.lblTotalRentals.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRentals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalRentals.Location = new System.Drawing.Point(684, 13);
            this.lblTotalRentals.Name = "lblTotalRentals";
            this.lblTotalRentals.Size = new System.Drawing.Size(24, 28);
            this.lblTotalRentals.TabIndex = 42;
            this.lblTotalRentals.Text = "0";
            // 
            // lblTotalFines
            // 
            this.lblTotalFines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalFines.AutoSize = true;
            this.lblTotalFines.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalFines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalFines.Location = new System.Drawing.Point(447, 13);
            this.lblTotalFines.Name = "lblTotalFines";
            this.lblTotalFines.Size = new System.Drawing.Size(53, 28);
            this.lblTotalFines.TabIndex = 40;
            this.lblTotalFines.Text = "0.00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label5.Location = new System.Drawing.Point(506, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 28);
            this.label5.TabIndex = 41;
            this.label5.Text = "จำนวนบิลทั้งหมด :";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(214, 13);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(53, 28);
            this.lblTotalRevenue.TabIndex = 39;
            this.lblTotalRevenue.Text = "0.00";
            // 
            // tabControlReports
            // 
            this.tabControlReports.Controls.Add(this.tabPageTopDresses);
            this.tabControlReports.Controls.Add(this.tabPageCategoryReport);
            this.tabControlReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReports.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlReports.Location = new System.Drawing.Point(0, 145);
            this.tabControlReports.Name = "tabControlReports";
            this.tabControlReports.SelectedIndex = 0;
            this.tabControlReports.Size = new System.Drawing.Size(1555, 855);
            this.tabControlReports.TabIndex = 36;
            // 
            // tabPageTopDresses
            // 
            this.tabPageTopDresses.Controls.Add(this.dgvTopDresses);
            this.tabPageTopDresses.Location = new System.Drawing.Point(4, 34);
            this.tabPageTopDresses.Name = "tabPageTopDresses";
            this.tabPageTopDresses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTopDresses.Size = new System.Drawing.Size(1547, 817);
            this.tabPageTopDresses.TabIndex = 0;
            this.tabPageTopDresses.Text = "รายได้ตามชุด";
            this.tabPageTopDresses.UseVisualStyleBackColor = true;
            // 
            // dgvTopDresses
            // 
            this.dgvTopDresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopDresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopDresses.Location = new System.Drawing.Point(3, 3);
            this.dgvTopDresses.Name = "dgvTopDresses";
            this.dgvTopDresses.RowHeadersWidth = 62;
            this.dgvTopDresses.RowTemplate.Height = 28;
            this.dgvTopDresses.Size = new System.Drawing.Size(1541, 811);
            this.dgvTopDresses.TabIndex = 0;
            // 
            // tabPageCategoryReport
            // 
            this.tabPageCategoryReport.Controls.Add(this.dgvCategoryRevenue);
            this.tabPageCategoryReport.Location = new System.Drawing.Point(4, 34);
            this.tabPageCategoryReport.Name = "tabPageCategoryReport";
            this.tabPageCategoryReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategoryReport.Size = new System.Drawing.Size(1547, 817);
            this.tabPageCategoryReport.TabIndex = 2;
            this.tabPageCategoryReport.Text = "รายได้ตามหมวดหมู่";
            this.tabPageCategoryReport.UseVisualStyleBackColor = true;
            // 
            // dgvCategoryRevenue
            // 
            this.dgvCategoryRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategoryRevenue.Location = new System.Drawing.Point(3, 3);
            this.dgvCategoryRevenue.Name = "dgvCategoryRevenue";
            this.dgvCategoryRevenue.RowHeadersWidth = 62;
            this.dgvCategoryRevenue.RowTemplate.Height = 28;
            this.dgvCategoryRevenue.Size = new System.Drawing.Size(1541, 811);
            this.dgvCategoryRevenue.TabIndex = 0;
            // 
            // cmbTimePeriodType
            // 
            this.cmbTimePeriodType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTimePeriodType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimePeriodType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmbTimePeriodType.FormattingEnabled = true;
            this.cmbTimePeriodType.Location = new System.Drawing.Point(1085, 28);
            this.cmbTimePeriodType.Name = "cmbTimePeriodType";
            this.cmbTimePeriodType.Size = new System.Drawing.Size(166, 33);
            this.cmbTimePeriodType.TabIndex = 37;
            this.cmbTimePeriodType.SelectedIndexChanged += new System.EventHandler(this.CmbTimePeriodType_SelectedIndexChanged);
            // 
            // nudPeriodCount
            // 
            this.nudPeriodCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudPeriodCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudPeriodCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.nudPeriodCount.Location = new System.Drawing.Point(1331, 29);
            this.nudPeriodCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPeriodCount.Name = "nudPeriodCount";
            this.nudPeriodCount.Size = new System.Drawing.Size(122, 31);
            this.nudPeriodCount.TabIndex = 38;
            this.nudPeriodCount.ValueChanged += new System.EventHandler(this.NudPeriodCount_ValueChanged);
            // 
            // cmbSpecialPeriod
            // 
            this.cmbSpecialPeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSpecialPeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecialPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmbSpecialPeriod.FormattingEnabled = true;
            this.cmbSpecialPeriod.Items.AddRange(new object[] {
            "ทั้งหมด",
            "วันนี้",
            "เมื่อวาน",
            "สัปดาห์นี้",
            "สัปดาห์ที่แล้ว",
            "เดือนนี้",
            "เดือนที่แล้ว",
            "ปีนี้",
            "ปีที่แล้ว",
            "กำหนดเอง",
            "ย้อนหลัง..."});
            this.cmbSpecialPeriod.Location = new System.Drawing.Point(153, 28);
            this.cmbSpecialPeriod.Name = "cmbSpecialPeriod";
            this.cmbSpecialPeriod.Size = new System.Drawing.Size(179, 33);
            this.cmbSpecialPeriod.TabIndex = 39;
            this.cmbSpecialPeriod.SelectedIndexChanged += new System.EventHandler(this.CmbSpecialPeriod_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 12;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnLoadReport, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbSpecialPeriod, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDateRange, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpEndDate, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpStartDate, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTo, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPeriodCount, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbTimePeriodType, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPeriodType, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudPeriodCount, 10, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1555, 90);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // lblPeriodCount
            // 
            this.lblPeriodCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPeriodCount.AutoSize = true;
            this.lblPeriodCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lblPeriodCount.Location = new System.Drawing.Point(974, 32);
            this.lblPeriodCount.Name = "lblPeriodCount";
            this.lblPeriodCount.Size = new System.Drawing.Size(105, 25);
            this.lblPeriodCount.TabIndex = 40;
            this.lblPeriodCount.Text = "ย้อนหลังไป :";
            // 
            // lblPeriodType
            // 
            this.lblPeriodType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPeriodType.AutoSize = true;
            this.lblPeriodType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lblPeriodType.Location = new System.Drawing.Point(1257, 32);
            this.lblPeriodType.Name = "lblPeriodType";
            this.lblPeriodType.Size = new System.Drawing.Size(68, 25);
            this.lblPeriodType.TabIndex = 41;
            this.lblPeriodType.Text = "หน่วย :";
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnLoadReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnLoadReport.BorderThickness = 0;
            this.btnLoadReport.CornerRadius = 12;
            this.btnLoadReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnLoadReport.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnLoadReport.Location = new System.Drawing.Point(23, 25);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(124, 39);
            this.btnLoadReport.TabIndex = 20;
            this.btnLoadReport.Text = "แสดงรายงาน";
            this.btnLoadReport.UseVisualStyleBackColor = false;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.tabControlReports);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblGrandTotal);
            this.Name = "AdminDashboard";
            this.Size = new System.Drawing.Size(1555, 1000);
            this.panel2.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControlReports.ResumeLayout(false);
            this.tabPageTopDresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopDresses)).EndInit();
            this.tabPageCategoryReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodCount)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDateRange;
        private RoundedButton btnLoadReport;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalRentals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalFines;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlReports;
        private System.Windows.Forms.TabPage tabPageTopDresses;
        private System.Windows.Forms.DataGridView dgvTopDresses;
        private System.Windows.Forms.TabPage tabPageCategoryReport;
        private System.Windows.Forms.DataGridView dgvCategoryRevenue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbTimePeriodType;
        private System.Windows.Forms.NumericUpDown nudPeriodCount;
        private System.Windows.Forms.ComboBox cmbSpecialPeriod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPeriodCount;
        private System.Windows.Forms.Label lblPeriodType;
    }
}
