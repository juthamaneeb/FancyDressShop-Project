namespace FancyDressShop
{
    partial class AdminRentalManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPaymentStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCheckAutoCancel = new RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRentalStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new RoundedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRejectFine = new RoundedButton();
            this.lblAmountToRefund = new System.Windows.Forms.Label();
            this.lblOutstandingFine = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.linkSlipFine = new System.Windows.Forms.LinkLabel();
            this.linkSlipPayment = new System.Windows.Forms.LinkLabel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.picRefundSlipPreview = new System.Windows.Forms.PictureBox();
            this.btnSelectRefundSlip = new RoundedButton();
            this.btnFinalizeRefund = new RoundedButton();
            this.btnHandOver = new RoundedButton();
            this.btnViewSlip = new RoundedButton();
            this.btnConfirmFinePayment = new RoundedButton();
            this.dtpActionDate = new System.Windows.Forms.DateTimePicker();
            this.btnRecordReturn = new RoundedButton();
            this.btnRejectPayment = new RoundedButton();
            this.btnApprovePayment = new RoundedButton();
            this.picSlipPreview = new System.Windows.Forms.PictureBox();
            this.lblSelectedRentalId = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblRentalStartDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblFinalizeDate = new System.Windows.Forms.Label();
            this.lblRentalDays = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblHandoverDate = new System.Windows.Forms.Label();
            this.lblPaymentConfirmedDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.dgvRentalDetails = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefundSlipPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPreview)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbPaymentStatusFilter);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnCheckAutoCancel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbRentalStatusFilter);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1550, 90);
            this.panel2.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(822, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "สถานะการชำระเงิน :";
            // 
            // cmbPaymentStatusFilter
            // 
            this.cmbPaymentStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmbPaymentStatusFilter.FormattingEnabled = true;
            this.cmbPaymentStatusFilter.Location = new System.Drawing.Point(1000, 30);
            this.cmbPaymentStatusFilter.Name = "cmbPaymentStatusFilter";
            this.cmbPaymentStatusFilter.Size = new System.Drawing.Size(222, 33);
            this.cmbPaymentStatusFilter.TabIndex = 35;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.txtSearch.Location = new System.Drawing.Point(50, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(388, 31);
            this.txtSearch.TabIndex = 18;
            // 
            // btnCheckAutoCancel
            // 
            this.btnCheckAutoCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnCheckAutoCancel.BorderColor = System.Drawing.Color.Black;
            this.btnCheckAutoCancel.BorderThickness = 0;
            this.btnCheckAutoCancel.CornerRadius = 12;
            this.btnCheckAutoCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckAutoCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckAutoCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnCheckAutoCancel.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnCheckAutoCancel.IsSelected = false;
            this.btnCheckAutoCancel.Location = new System.Drawing.Point(1357, 25);
            this.btnCheckAutoCancel.Name = "btnCheckAutoCancel";
            this.btnCheckAutoCancel.Size = new System.Drawing.Size(172, 44);
            this.btnCheckAutoCancel.TabIndex = 34;
            this.btnCheckAutoCancel.Text = "ยกเลิกบิลหมดอายุ";
            this.btnCheckAutoCancel.UseVisualStyleBackColor = false;
            this.btnCheckAutoCancel.Click += new System.EventHandler(this.btnCheckAutoCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(454, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "สถานะการเช่า :";
            // 
            // cmbRentalStatusFilter
            // 
            this.cmbRentalStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRentalStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmbRentalStatusFilter.FormattingEnabled = true;
            this.cmbRentalStatusFilter.Location = new System.Drawing.Point(594, 30);
            this.cmbRentalStatusFilter.Name = "cmbRentalStatusFilter";
            this.cmbRentalStatusFilter.Size = new System.Drawing.Size(222, 33);
            this.cmbRentalStatusFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnSearch.BorderThickness = 0;
            this.btnSearch.CornerRadius = 12;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnSearch.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnSearch.IsSelected = false;
            this.btnSearch.Location = new System.Drawing.Point(1241, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 44);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRentals);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 537);
            this.panel1.TabIndex = 25;
            // 
            // dgvRentals
            // 
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRentals.Location = new System.Drawing.Point(0, 0);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowHeadersWidth = 62;
            this.dgvRentals.RowTemplate.Height = 28;
            this.dgvRentals.Size = new System.Drawing.Size(953, 537);
            this.dgvRentals.TabIndex = 0;
            this.dgvRentals.SelectionChanged += new System.EventHandler(this.dgvRentals_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRejectFine);
            this.panel3.Controls.Add(this.lblAmountToRefund);
            this.panel3.Controls.Add(this.lblOutstandingFine);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblDepositAmount);
            this.panel3.Controls.Add(this.linkSlipFine);
            this.panel3.Controls.Add(this.linkSlipPayment);
            this.panel3.Controls.Add(this.lblTotalPrice);
            this.panel3.Controls.Add(this.picRefundSlipPreview);
            this.panel3.Controls.Add(this.btnSelectRefundSlip);
            this.panel3.Controls.Add(this.btnFinalizeRefund);
            this.panel3.Controls.Add(this.btnHandOver);
            this.panel3.Controls.Add(this.btnViewSlip);
            this.panel3.Controls.Add(this.btnConfirmFinePayment);
            this.panel3.Controls.Add(this.dtpActionDate);
            this.panel3.Controls.Add(this.btnRecordReturn);
            this.panel3.Controls.Add(this.btnRejectPayment);
            this.panel3.Controls.Add(this.btnApprovePayment);
            this.panel3.Controls.Add(this.picSlipPreview);
            this.panel3.Controls.Add(this.lblSelectedRentalId);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(953, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(597, 910);
            this.panel3.TabIndex = 26;
            // 
            // btnRejectFine
            // 
            this.btnRejectFine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnRejectFine.BorderColor = System.Drawing.Color.Black;
            this.btnRejectFine.BorderThickness = 0;
            this.btnRejectFine.CornerRadius = 12;
            this.btnRejectFine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRejectFine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnRejectFine.HoverBackColor = System.Drawing.Color.Black;
            this.btnRejectFine.IsSelected = false;
            this.btnRejectFine.Location = new System.Drawing.Point(321, 749);
            this.btnRejectFine.Name = "btnRejectFine";
            this.btnRejectFine.Size = new System.Drawing.Size(221, 44);
            this.btnRejectFine.TabIndex = 43;
            this.btnRejectFine.Text = "ปฏิเสธค่าปรับ";
            this.btnRejectFine.UseVisualStyleBackColor = false;
            this.btnRejectFine.Click += new System.EventHandler(this.btnRejectFine_Click);
            // 
            // lblAmountToRefund
            // 
            this.lblAmountToRefund.AutoSize = true;
            this.lblAmountToRefund.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountToRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblAmountToRefund.Location = new System.Drawing.Point(303, 167);
            this.lblAmountToRefund.Name = "lblAmountToRefund";
            this.lblAmountToRefund.Size = new System.Drawing.Size(112, 28);
            this.lblAmountToRefund.TabIndex = 42;
            this.lblAmountToRefund.Text = "ยอดที่ต้องคืน";
            // 
            // lblOutstandingFine
            // 
            this.lblOutstandingFine.AutoSize = true;
            this.lblOutstandingFine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblOutstandingFine.Location = new System.Drawing.Point(303, 139);
            this.lblOutstandingFine.Name = "lblOutstandingFine";
            this.lblOutstandingFine.Size = new System.Drawing.Size(43, 28);
            this.lblOutstandingFine.TabIndex = 27;
            this.lblOutstandingFine.Text = "ปรับ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label6.Location = new System.Drawing.Point(365, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 41;
            this.label6.Text = "วันที่ดำเนินการ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label5.Location = new System.Drawing.Point(19, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "รหัสบิล :";
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDepositAmount.Location = new System.Drawing.Point(303, 111);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(54, 28);
            this.lblDepositAmount.TabIndex = 26;
            this.lblDepositAmount.Text = "มัดจำ";
            // 
            // linkSlipFine
            // 
            this.linkSlipFine.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.linkSlipFine.AutoSize = true;
            this.linkSlipFine.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.linkSlipFine.Location = new System.Drawing.Point(167, 411);
            this.linkSlipFine.Name = "linkSlipFine";
            this.linkSlipFine.Size = new System.Drawing.Size(75, 20);
            this.linkSlipFine.TabIndex = 39;
            this.linkSlipFine.TabStop = true;
            this.linkSlipFine.Text = "สลิปค่าปรับ";
            this.linkSlipFine.Visible = false;
            this.linkSlipFine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSlipFine_LinkClicked);
            // 
            // linkSlipPayment
            // 
            this.linkSlipPayment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.linkSlipPayment.AutoSize = true;
            this.linkSlipPayment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.linkSlipPayment.Location = new System.Drawing.Point(75, 411);
            this.linkSlipPayment.Name = "linkSlipPayment";
            this.linkSlipPayment.Size = new System.Drawing.Size(57, 20);
            this.linkSlipPayment.TabIndex = 38;
            this.linkSlipPayment.TabStop = true;
            this.linkSlipPayment.Text = "สลิปจอง";
            this.linkSlipPayment.Visible = false;
            this.linkSlipPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSlipPayment_LinkClicked);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(303, 83);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(45, 28);
            this.lblTotalPrice.TabIndex = 25;
            this.lblTotalPrice.Text = "ยอด";
            // 
            // picRefundSlipPreview
            // 
            this.picRefundSlipPreview.Location = new System.Drawing.Point(19, 475);
            this.picRefundSlipPreview.Name = "picRefundSlipPreview";
            this.picRefundSlipPreview.Size = new System.Drawing.Size(273, 318);
            this.picRefundSlipPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRefundSlipPreview.TabIndex = 37;
            this.picRefundSlipPreview.TabStop = false;
            // 
            // btnSelectRefundSlip
            // 
            this.btnSelectRefundSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnSelectRefundSlip.BorderColor = System.Drawing.Color.Black;
            this.btnSelectRefundSlip.BorderThickness = 0;
            this.btnSelectRefundSlip.CornerRadius = 12;
            this.btnSelectRefundSlip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectRefundSlip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectRefundSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnSelectRefundSlip.HoverBackColor = System.Drawing.Color.Black;
            this.btnSelectRefundSlip.IsSelected = false;
            this.btnSelectRefundSlip.Location = new System.Drawing.Point(106, 810);
            this.btnSelectRefundSlip.Name = "btnSelectRefundSlip";
            this.btnSelectRefundSlip.Size = new System.Drawing.Size(128, 44);
            this.btnSelectRefundSlip.TabIndex = 36;
            this.btnSelectRefundSlip.Text = "Browse...";
            this.btnSelectRefundSlip.UseVisualStyleBackColor = false;
            this.btnSelectRefundSlip.Click += new System.EventHandler(this.btnSelectRefundSlip_Click);
            // 
            // btnFinalizeRefund
            // 
            this.btnFinalizeRefund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnFinalizeRefund.BorderColor = System.Drawing.Color.Black;
            this.btnFinalizeRefund.BorderThickness = 0;
            this.btnFinalizeRefund.CornerRadius = 12;
            this.btnFinalizeRefund.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizeRefund.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizeRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnFinalizeRefund.HoverBackColor = System.Drawing.Color.Black;
            this.btnFinalizeRefund.IsSelected = false;
            this.btnFinalizeRefund.Location = new System.Drawing.Point(321, 810);
            this.btnFinalizeRefund.Name = "btnFinalizeRefund";
            this.btnFinalizeRefund.Size = new System.Drawing.Size(221, 44);
            this.btnFinalizeRefund.TabIndex = 34;
            this.btnFinalizeRefund.Text = "คืนมัดจำ";
            this.btnFinalizeRefund.UseVisualStyleBackColor = false;
            this.btnFinalizeRefund.Click += new System.EventHandler(this.btnFinalizeRefund_Click);
            // 
            // btnHandOver
            // 
            this.btnHandOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnHandOver.BorderColor = System.Drawing.Color.Black;
            this.btnHandOver.BorderThickness = 0;
            this.btnHandOver.CornerRadius = 12;
            this.btnHandOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHandOver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnHandOver.HoverBackColor = System.Drawing.Color.Black;
            this.btnHandOver.IsSelected = false;
            this.btnHandOver.Location = new System.Drawing.Point(321, 564);
            this.btnHandOver.Name = "btnHandOver";
            this.btnHandOver.Size = new System.Drawing.Size(221, 44);
            this.btnHandOver.TabIndex = 33;
            this.btnHandOver.Text = "มอบชุด";
            this.btnHandOver.UseVisualStyleBackColor = false;
            this.btnHandOver.Click += new System.EventHandler(this.btnHandOver_Click);
            // 
            // btnViewSlip
            // 
            this.btnViewSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnViewSlip.BorderColor = System.Drawing.Color.Black;
            this.btnViewSlip.BorderThickness = 0;
            this.btnViewSlip.CornerRadius = 12;
            this.btnViewSlip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewSlip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnViewSlip.HoverBackColor = System.Drawing.Color.Black;
            this.btnViewSlip.IsSelected = false;
            this.btnViewSlip.Location = new System.Drawing.Point(321, 236);
            this.btnViewSlip.Name = "btnViewSlip";
            this.btnViewSlip.Size = new System.Drawing.Size(221, 44);
            this.btnViewSlip.TabIndex = 32;
            this.btnViewSlip.Text = "ดูสลิป";
            this.btnViewSlip.UseVisualStyleBackColor = false;
            this.btnViewSlip.Click += new System.EventHandler(this.btnViewSlip_Click);
            // 
            // btnConfirmFinePayment
            // 
            this.btnConfirmFinePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnConfirmFinePayment.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmFinePayment.BorderThickness = 0;
            this.btnConfirmFinePayment.CornerRadius = 12;
            this.btnConfirmFinePayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmFinePayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmFinePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnConfirmFinePayment.HoverBackColor = System.Drawing.Color.Black;
            this.btnConfirmFinePayment.IsSelected = false;
            this.btnConfirmFinePayment.Location = new System.Drawing.Point(321, 688);
            this.btnConfirmFinePayment.Name = "btnConfirmFinePayment";
            this.btnConfirmFinePayment.Size = new System.Drawing.Size(221, 44);
            this.btnConfirmFinePayment.TabIndex = 31;
            this.btnConfirmFinePayment.Text = "ยืนยันชำระค่าปรับ";
            this.btnConfirmFinePayment.UseVisualStyleBackColor = false;
            this.btnConfirmFinePayment.Click += new System.EventHandler(this.btnConfirmFinePayment_Click);
            // 
            // dtpActionDate
            // 
            this.dtpActionDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActionDate.Location = new System.Drawing.Point(321, 513);
            this.dtpActionDate.Name = "dtpActionDate";
            this.dtpActionDate.Size = new System.Drawing.Size(221, 31);
            this.dtpActionDate.TabIndex = 29;
            // 
            // btnRecordReturn
            // 
            this.btnRecordReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnRecordReturn.BorderColor = System.Drawing.Color.Black;
            this.btnRecordReturn.BorderThickness = 0;
            this.btnRecordReturn.CornerRadius = 12;
            this.btnRecordReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecordReturn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnRecordReturn.HoverBackColor = System.Drawing.Color.Black;
            this.btnRecordReturn.IsSelected = false;
            this.btnRecordReturn.Location = new System.Drawing.Point(321, 625);
            this.btnRecordReturn.Name = "btnRecordReturn";
            this.btnRecordReturn.Size = new System.Drawing.Size(221, 44);
            this.btnRecordReturn.TabIndex = 28;
            this.btnRecordReturn.Text = "บันทึกการรับคืนชุด";
            this.btnRecordReturn.UseVisualStyleBackColor = false;
            this.btnRecordReturn.Click += new System.EventHandler(this.btnRecordReturn_Click);
            // 
            // btnRejectPayment
            // 
            this.btnRejectPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnRejectPayment.BorderColor = System.Drawing.Color.Black;
            this.btnRejectPayment.BorderThickness = 0;
            this.btnRejectPayment.CornerRadius = 12;
            this.btnRejectPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRejectPayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnRejectPayment.HoverBackColor = System.Drawing.Color.Black;
            this.btnRejectPayment.IsSelected = false;
            this.btnRejectPayment.Location = new System.Drawing.Point(321, 356);
            this.btnRejectPayment.Name = "btnRejectPayment";
            this.btnRejectPayment.Size = new System.Drawing.Size(221, 44);
            this.btnRejectPayment.TabIndex = 27;
            this.btnRejectPayment.Text = "ปฏิเสธการชำระเงิน";
            this.btnRejectPayment.UseVisualStyleBackColor = false;
            this.btnRejectPayment.Click += new System.EventHandler(this.btnRejectPayment_Click);
            // 
            // btnApprovePayment
            // 
            this.btnApprovePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnApprovePayment.BorderColor = System.Drawing.Color.Black;
            this.btnApprovePayment.BorderThickness = 0;
            this.btnApprovePayment.CornerRadius = 12;
            this.btnApprovePayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApprovePayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprovePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnApprovePayment.HoverBackColor = System.Drawing.Color.Black;
            this.btnApprovePayment.IsSelected = false;
            this.btnApprovePayment.Location = new System.Drawing.Point(321, 296);
            this.btnApprovePayment.Name = "btnApprovePayment";
            this.btnApprovePayment.Size = new System.Drawing.Size(221, 44);
            this.btnApprovePayment.TabIndex = 3;
            this.btnApprovePayment.Text = "ยืนยันการชำระเงิน";
            this.btnApprovePayment.UseVisualStyleBackColor = false;
            this.btnApprovePayment.Click += new System.EventHandler(this.btnApprovePayment_Click);
            // 
            // picSlipPreview
            // 
            this.picSlipPreview.Location = new System.Drawing.Point(19, 82);
            this.picSlipPreview.Name = "picSlipPreview";
            this.picSlipPreview.Size = new System.Drawing.Size(273, 318);
            this.picSlipPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlipPreview.TabIndex = 26;
            this.picSlipPreview.TabStop = false;
            // 
            // lblSelectedRentalId
            // 
            this.lblSelectedRentalId.AutoSize = true;
            this.lblSelectedRentalId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedRentalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblSelectedRentalId.Location = new System.Drawing.Point(101, 39);
            this.lblSelectedRentalId.Name = "lblSelectedRentalId";
            this.lblSelectedRentalId.Size = new System.Drawing.Size(86, 25);
            this.lblSelectedRentalId.TabIndex = 25;
            this.lblSelectedRentalId.Text = "ID rental";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.dgvRentalDetails);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 627);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(953, 373);
            this.panel5.TabIndex = 36;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(498, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(455, 373);
            this.panel6.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(455, 346);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCreationDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRentalStartDate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDueDate, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFinalizeDate, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblRentalDays, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblReturnDate, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblHandoverDate, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblPaymentConfirmedDate, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(318, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(137, 346);
            this.tableLayoutPanel2.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "ข้อมูลการเช่า";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCreationDate.Location = new System.Drawing.Point(3, 28);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(80, 28);
            this.lblCreationDate.TabIndex = 21;
            this.lblCreationDate.Text = "สร้างเมื่อ:";
            // 
            // lblRentalStartDate
            // 
            this.lblRentalStartDate.AutoSize = true;
            this.lblRentalStartDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalStartDate.Location = new System.Drawing.Point(3, 56);
            this.lblRentalStartDate.Name = "lblRentalStartDate";
            this.lblRentalStartDate.Size = new System.Drawing.Size(67, 28);
            this.lblRentalStartDate.TabIndex = 22;
            this.lblRentalStartDate.Text = "เริ่มเช่า:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDueDate.Location = new System.Drawing.Point(3, 84);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(96, 28);
            this.lblDueDate.TabIndex = 23;
            this.lblDueDate.Text = "กำหนดคืน:";
            // 
            // lblFinalizeDate
            // 
            this.lblFinalizeDate.AutoSize = true;
            this.lblFinalizeDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalizeDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblFinalizeDate.Location = new System.Drawing.Point(3, 224);
            this.lblFinalizeDate.Name = "lblFinalizeDate";
            this.lblFinalizeDate.Size = new System.Drawing.Size(88, 28);
            this.lblFinalizeDate.TabIndex = 29;
            this.lblFinalizeDate.Text = "ปิดบิลเมื่อ:";
            // 
            // lblRentalDays
            // 
            this.lblRentalDays.AutoSize = true;
            this.lblRentalDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalDays.Location = new System.Drawing.Point(3, 112);
            this.lblRentalDays.Name = "lblRentalDays";
            this.lblRentalDays.Size = new System.Drawing.Size(89, 28);
            this.lblRentalDays.TabIndex = 31;
            this.lblRentalDays.Text = "จำนวนวัน:";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblReturnDate.Location = new System.Drawing.Point(3, 196);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(67, 28);
            this.lblReturnDate.TabIndex = 24;
            this.lblReturnDate.Text = "คืนจริง:";
            // 
            // lblHandoverDate
            // 
            this.lblHandoverDate.AutoSize = true;
            this.lblHandoverDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHandoverDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblHandoverDate.Location = new System.Drawing.Point(3, 168);
            this.lblHandoverDate.Name = "lblHandoverDate";
            this.lblHandoverDate.Size = new System.Drawing.Size(100, 28);
            this.lblHandoverDate.TabIndex = 30;
            this.lblHandoverDate.Text = "มอบชุดเมื่อ:";
            // 
            // lblPaymentConfirmedDate
            // 
            this.lblPaymentConfirmedDate.AutoSize = true;
            this.lblPaymentConfirmedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentConfirmedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblPaymentConfirmedDate.Location = new System.Drawing.Point(3, 140);
            this.lblPaymentConfirmedDate.Name = "lblPaymentConfirmedDate";
            this.lblPaymentConfirmedDate.Size = new System.Drawing.Size(124, 28);
            this.lblPaymentConfirmedDate.TabIndex = 28;
            this.lblPaymentConfirmedDate.Text = "อนุมัติชำระเงิน:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerEmail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerAddress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblBankName, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountName, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountNumber, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerPhone, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 346);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "ข้อมูลลูกค้า";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCustomerName.Location = new System.Drawing.Point(3, 28);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(59, 28);
            this.lblCustomerName.TabIndex = 13;
            this.lblCustomerName.Text = "ลูกค้า:";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCustomerEmail.Location = new System.Drawing.Point(3, 84);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(54, 28);
            this.lblCustomerEmail.TabIndex = 14;
            this.lblCustomerEmail.Text = "อีเมล:";
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCustomerAddress.Location = new System.Drawing.Point(3, 112);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(49, 28);
            this.lblCustomerAddress.TabIndex = 16;
            this.lblCustomerAddress.Text = "ที่อยู่:";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblBankName.Location = new System.Drawing.Point(3, 140);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(77, 28);
            this.lblBankName.TabIndex = 17;
            this.lblBankName.Text = "ธนาคาร:";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblAccountName.Location = new System.Drawing.Point(3, 168);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(79, 28);
            this.lblAccountName.TabIndex = 18;
            this.lblAccountName.Text = "ชื่อบัญชี:";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblAccountNumber.Location = new System.Drawing.Point(3, 196);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(101, 28);
            this.lblAccountNumber.TabIndex = 19;
            this.lblAccountNumber.Text = "เลขที่บัญชี :";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCustomerPhone.Location = new System.Drawing.Point(3, 56);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(45, 28);
            this.lblCustomerPhone.TabIndex = 15;
            this.lblCustomerPhone.Text = "โทร:";
            // 
            // dgvRentalDetails
            // 
            this.dgvRentalDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvRentalDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvRentalDetails.Name = "dgvRentalDetails";
            this.dgvRentalDetails.RowHeadersWidth = 62;
            this.dgvRentalDetails.RowTemplate.Height = 28;
            this.dgvRentalDetails.Size = new System.Drawing.Size(498, 373);
            this.dgvRentalDetails.TabIndex = 1;
            // 
            // AdminRentalManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "AdminRentalManager";
            this.Size = new System.Drawing.Size(1550, 1000);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefundSlipPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPreview)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbRentalStatusFilter;
        private System.Windows.Forms.DataGridView dgvRentals;
        private RoundedButton btnRecordReturn;
        private System.Windows.Forms.PictureBox picSlipPreview;
        private System.Windows.Forms.Label lblSelectedRentalId;
        private System.Windows.Forms.DateTimePicker dtpActionDate;
        private RoundedButton btnConfirmFinePayment;
        private RoundedButton btnHandOver;
        private RoundedButton btnCheckAutoCancel;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedButton btnSearch;
        private System.Windows.Forms.Label label1;
        private RoundedButton btnFinalizeRefund;
        private RoundedButton btnSelectRefundSlip;
        private System.Windows.Forms.PictureBox picRefundSlipPreview;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvRentalDetails;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.LinkLabel linkSlipFine;
        private System.Windows.Forms.LinkLabel linkSlipPayment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblRentalStartDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPaymentConfirmedDate;
        private System.Windows.Forms.Label lblHandoverDate;
        private System.Windows.Forms.Label lblFinalizeDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPaymentStatusFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAmountToRefund;
        private System.Windows.Forms.Label lblOutstandingFine;
        private System.Windows.Forms.Label lblDepositAmount;
        private System.Windows.Forms.Label lblTotalPrice;
        private RoundedButton btnViewSlip;
        private RoundedButton btnRejectPayment;
        private RoundedButton btnApprovePayment;
        private System.Windows.Forms.Label lblRentalDays;
        private RoundedButton btnRejectFine;
    }
}
