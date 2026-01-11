namespace FancyDressShop
{
    partial class CustomerRentals
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
            this.lblRentalId = new System.Windows.Forms.Label();
            this.lblOutstandingFine = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvRentalDetails = new System.Windows.Forms.DataGridView();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowStoreQR = new RoundedButton();
            this.btnPrintReceipt = new RoundedButton();
            this.btnBack = new RoundedButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoSlipMessage = new System.Windows.Forms.Label();
            this.lblSlipType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblRentalDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblHandoverDate = new System.Windows.Forms.Label();
            this.lblReturnDateActual = new System.Windows.Forms.Label();
            this.lblCreationTime = new System.Windows.Forms.Label();
            this.lblAmountToRefund = new System.Windows.Forms.Label();
            this.lblFineIncurred = new System.Windows.Forms.Label();
            this.linkSlipRefund = new System.Windows.Forms.LinkLabel();
            this.linkSlipFine = new System.Windows.Forms.LinkLabel();
            this.linkSlipPayment = new System.Windows.Forms.LinkLabel();
            this.pnlAction = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectSlip = new RoundedButton();
            this.btnViewSlip = new RoundedButton();
            this.btnCancelRental = new RoundedButton();
            this.btnSubmitSlip = new RoundedButton();
            this.picSlipPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRentalId
            // 
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalId.Location = new System.Drawing.Point(3, 0);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new System.Drawing.Size(119, 28);
            this.lblRentalId.TabIndex = 26;
            this.lblRentalId.Text = "ID บิลที่เลือก";
            // 
            // lblOutstandingFine
            // 
            this.lblOutstandingFine.AutoSize = true;
            this.lblOutstandingFine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblOutstandingFine.Location = new System.Drawing.Point(165, 230);
            this.lblOutstandingFine.Name = "lblOutstandingFine";
            this.lblOutstandingFine.Size = new System.Drawing.Size(116, 25);
            this.lblOutstandingFine.TabIndex = 28;
            this.lblOutstandingFine.Text = "ค่าปรับค้างชำระ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblStatus.Location = new System.Drawing.Point(3, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(156, 25);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "สถานะการเช่าปัจจุบัน";
            // 
            // dgvRentalDetails
            // 
            this.dgvRentalDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvRentalDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvRentalDetails.Name = "dgvRentalDetails";
            this.dgvRentalDetails.RowHeadersWidth = 62;
            this.dgvRentalDetails.RowTemplate.Height = 28;
            this.dgvRentalDetails.Size = new System.Drawing.Size(899, 1000);
            this.dgvRentalDetails.TabIndex = 34;
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDepositAmount.Location = new System.Drawing.Point(165, 95);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(67, 25);
            this.lblDepositAmount.TabIndex = 36;
            this.lblDepositAmount.Text = "ค่ามัดจำ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowStoreQR);
            this.panel1.Controls.Add(this.btnPrintReceipt);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.linkSlipRefund);
            this.panel1.Controls.Add(this.linkSlipFine);
            this.panel1.Controls.Add(this.linkSlipPayment);
            this.panel1.Controls.Add(this.pnlAction);
            this.panel1.Controls.Add(this.picSlipPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(899, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 1000);
            this.panel1.TabIndex = 39;
            // 
            // btnShowStoreQR
            // 
            this.btnShowStoreQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnShowStoreQR.BorderColor = System.Drawing.Color.Black;
            this.btnShowStoreQR.BorderThickness = 1;
            this.btnShowStoreQR.CornerRadius = 12;
            this.btnShowStoreQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStoreQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnShowStoreQR.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnShowStoreQR.IsSelected = false;
            this.btnShowStoreQR.Location = new System.Drawing.Point(384, 662);
            this.btnShowStoreQR.Name = "btnShowStoreQR";
            this.btnShowStoreQR.Size = new System.Drawing.Size(193, 48);
            this.btnShowStoreQR.TabIndex = 48;
            this.btnShowStoreQR.Text = "ช่องทางการชำระเงิน";
            this.btnShowStoreQR.UseVisualStyleBackColor = false;
            this.btnShowStoreQR.Visible = false;
            this.btnShowStoreQR.Click += new System.EventHandler(this.btnShowStoreQR_Click);
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnPrintReceipt.BorderColor = System.Drawing.Color.Black;
            this.btnPrintReceipt.BorderThickness = 1;
            this.btnPrintReceipt.CornerRadius = 12;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnPrintReceipt.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnPrintReceipt.IsSelected = false;
            this.btnPrintReceipt.Location = new System.Drawing.Point(384, 716);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(193, 48);
            this.btnPrintReceipt.TabIndex = 5;
            this.btnPrintReceipt.Text = "ดูและพิมพ์ใบเสร็จ";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.btnBack.BorderColor = System.Drawing.Color.Black;
            this.btnBack.BorderThickness = 1;
            this.btnBack.CornerRadius = 12;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnBack.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnBack.IsSelected = false;
            this.btnBack.Location = new System.Drawing.Point(384, 770);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(193, 50);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "ย้อนกลัย";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblNoSlipMessage, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSlipType, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(47, 418);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(295, 31);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // lblNoSlipMessage
            // 
            this.lblNoSlipMessage.AutoSize = true;
            this.lblNoSlipMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoSlipMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblNoSlipMessage.Location = new System.Drawing.Point(60, 0);
            this.lblNoSlipMessage.Name = "lblNoSlipMessage";
            this.lblNoSlipMessage.Size = new System.Drawing.Size(143, 25);
            this.lblNoSlipMessage.TabIndex = 44;
            this.lblNoSlipMessage.Text = "ยังไม่มีการส่งสลิป";
            this.lblNoSlipMessage.Visible = false;
            // 
            // lblSlipType
            // 
            this.lblSlipType.AutoSize = true;
            this.lblSlipType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlipType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblSlipType.Location = new System.Drawing.Point(3, 0);
            this.lblSlipType.Name = "lblSlipType";
            this.lblSlipType.Size = new System.Drawing.Size(51, 25);
            this.lblSlipType.TabIndex = 43;
            this.lblSlipType.Text = "path";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(42, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 322);
            this.panel2.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblGrandTotal, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRentalId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCountdown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalPrice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDepositAmount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRentalDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDueDate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHandoverDate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblReturnDateActual, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblCreationTime, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblAmountToRefund, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblOutstandingFine, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFineIncurred, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 322);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(165, 140);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(116, 25);
            this.lblGrandTotal.TabIndex = 45;
            this.lblGrandTotal.Text = "ยอดรวมทั้งหมด";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCountdown.Location = new System.Drawing.Point(165, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(151, 28);
            this.lblCountdown.TabIndex = 42;
            this.lblCountdown.Text = "กำหนดวันชำระเงิน";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(165, 50);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(109, 25);
            this.lblTotalPrice.TabIndex = 29;
            this.lblTotalPrice.Text = "ยอดรวมค่าเช่า";
            // 
            // lblRentalDate
            // 
            this.lblRentalDate.AutoSize = true;
            this.lblRentalDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalDate.Location = new System.Drawing.Point(3, 50);
            this.lblRentalDate.Name = "lblRentalDate";
            this.lblRentalDate.Size = new System.Drawing.Size(110, 25);
            this.lblRentalDate.TabIndex = 31;
            this.lblRentalDate.Text = "วันที่เริ่มต้นเช่า";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDueDate.Location = new System.Drawing.Point(3, 95);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(113, 25);
            this.lblDueDate.TabIndex = 33;
            this.lblDueDate.Text = "วันที่กำหนดคืน";
            // 
            // lblHandoverDate
            // 
            this.lblHandoverDate.AutoSize = true;
            this.lblHandoverDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHandoverDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblHandoverDate.Location = new System.Drawing.Point(3, 140);
            this.lblHandoverDate.Name = "lblHandoverDate";
            this.lblHandoverDate.Size = new System.Drawing.Size(81, 25);
            this.lblHandoverDate.TabIndex = 38;
            this.lblHandoverDate.Text = "วันที่รับชุด";
            // 
            // lblReturnDateActual
            // 
            this.lblReturnDateActual.AutoSize = true;
            this.lblReturnDateActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDateActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblReturnDateActual.Location = new System.Drawing.Point(3, 185);
            this.lblReturnDateActual.Name = "lblReturnDateActual";
            this.lblReturnDateActual.Size = new System.Drawing.Size(87, 25);
            this.lblReturnDateActual.TabIndex = 37;
            this.lblReturnDateActual.Text = "วันที่คืนจริง";
            // 
            // lblCreationTime
            // 
            this.lblCreationTime.AutoSize = true;
            this.lblCreationTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreationTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblCreationTime.Location = new System.Drawing.Point(3, 275);
            this.lblCreationTime.Name = "lblCreationTime";
            this.lblCreationTime.Size = new System.Drawing.Size(95, 25);
            this.lblCreationTime.TabIndex = 32;
            this.lblCreationTime.Text = "วันที่สร้างบิล";
            this.lblCreationTime.Visible = false;
            // 
            // lblAmountToRefund
            // 
            this.lblAmountToRefund.AutoSize = true;
            this.lblAmountToRefund.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountToRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblAmountToRefund.Location = new System.Drawing.Point(165, 275);
            this.lblAmountToRefund.Name = "lblAmountToRefund";
            this.lblAmountToRefund.Size = new System.Drawing.Size(129, 25);
            this.lblAmountToRefund.TabIndex = 44;
            this.lblAmountToRefund.Text = "ยอดคืนมัดจำสุทธิ";
            // 
            // lblFineIncurred
            // 
            this.lblFineIncurred.AutoSize = true;
            this.lblFineIncurred.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFineIncurred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblFineIncurred.Location = new System.Drawing.Point(165, 185);
            this.lblFineIncurred.Name = "lblFineIncurred";
            this.lblFineIncurred.Size = new System.Drawing.Size(116, 25);
            this.lblFineIncurred.TabIndex = 43;
            this.lblFineIncurred.Text = "ค่าปรับที่เกิดขึ้น";
            // 
            // linkSlipRefund
            // 
            this.linkSlipRefund.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.linkSlipRefund.AutoSize = true;
            this.linkSlipRefund.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSlipRefund.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.linkSlipRefund.Location = new System.Drawing.Point(219, 833);
            this.linkSlipRefund.Name = "linkSlipRefund";
            this.linkSlipRefund.Size = new System.Drawing.Size(123, 25);
            this.linkSlipRefund.TabIndex = 45;
            this.linkSlipRefund.TabStop = true;
            this.linkSlipRefund.Text = "สลิปคืนเงินมัดจำ";
            this.linkSlipRefund.Visible = false;
            this.linkSlipRefund.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSlipRefund_LinkClicked);
            // 
            // linkSlipFine
            // 
            this.linkSlipFine.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.linkSlipFine.AutoSize = true;
            this.linkSlipFine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSlipFine.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.linkSlipFine.Location = new System.Drawing.Point(121, 833);
            this.linkSlipFine.Name = "linkSlipFine";
            this.linkSlipFine.Size = new System.Drawing.Size(88, 25);
            this.linkSlipFine.TabIndex = 44;
            this.linkSlipFine.TabStop = true;
            this.linkSlipFine.Text = "สลิปค่าปรับ";
            this.linkSlipFine.Visible = false;
            this.linkSlipFine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSlipFine_LinkClicked);
            // 
            // linkSlipPayment
            // 
            this.linkSlipPayment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.linkSlipPayment.AutoSize = true;
            this.linkSlipPayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSlipPayment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.linkSlipPayment.Location = new System.Drawing.Point(42, 833);
            this.linkSlipPayment.Name = "linkSlipPayment";
            this.linkSlipPayment.Size = new System.Drawing.Size(68, 25);
            this.linkSlipPayment.TabIndex = 43;
            this.linkSlipPayment.TabStop = true;
            this.linkSlipPayment.Text = "สลิปจอง";
            this.linkSlipPayment.Visible = false;
            this.linkSlipPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSlipPayment_LinkClicked);
            // 
            // pnlAction
            // 
            this.pnlAction.ColumnCount = 1;
            this.pnlAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlAction.Controls.Add(this.btnSelectSlip, 0, 0);
            this.pnlAction.Controls.Add(this.btnViewSlip, 0, 1);
            this.pnlAction.Controls.Add(this.btnCancelRental, 0, 3);
            this.pnlAction.Controls.Add(this.btnSubmitSlip, 0, 2);
            this.pnlAction.Location = new System.Drawing.Point(378, 440);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.RowCount = 5;
            this.pnlAction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlAction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlAction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlAction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlAction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlAction.Size = new System.Drawing.Size(199, 238);
            this.pnlAction.TabIndex = 41;
            // 
            // btnSelectSlip
            // 
            this.btnSelectSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnSelectSlip.BorderColor = System.Drawing.Color.Black;
            this.btnSelectSlip.BorderThickness = 1;
            this.btnSelectSlip.CornerRadius = 12;
            this.btnSelectSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectSlip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnSelectSlip.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnSelectSlip.IsSelected = false;
            this.btnSelectSlip.Location = new System.Drawing.Point(3, 3);
            this.btnSelectSlip.Name = "btnSelectSlip";
            this.btnSelectSlip.Size = new System.Drawing.Size(193, 48);
            this.btnSelectSlip.TabIndex = 0;
            this.btnSelectSlip.Text = "Browse...";
            this.btnSelectSlip.UseVisualStyleBackColor = false;
            this.btnSelectSlip.Click += new System.EventHandler(this.btnSelectSlip_Click);
            // 
            // btnViewSlip
            // 
            this.btnViewSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnViewSlip.BorderColor = System.Drawing.Color.Black;
            this.btnViewSlip.BorderThickness = 1;
            this.btnViewSlip.CornerRadius = 12;
            this.btnViewSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewSlip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnViewSlip.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnViewSlip.IsSelected = false;
            this.btnViewSlip.Location = new System.Drawing.Point(3, 57);
            this.btnViewSlip.Name = "btnViewSlip";
            this.btnViewSlip.Size = new System.Drawing.Size(193, 48);
            this.btnViewSlip.TabIndex = 4;
            this.btnViewSlip.Text = "ดูสลิป";
            this.btnViewSlip.UseVisualStyleBackColor = false;
            this.btnViewSlip.Click += new System.EventHandler(this.btnViewSlip_Click);
            // 
            // btnCancelRental
            // 
            this.btnCancelRental.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnCancelRental.BorderColor = System.Drawing.Color.Black;
            this.btnCancelRental.BorderThickness = 1;
            this.btnCancelRental.CornerRadius = 12;
            this.btnCancelRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelRental.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelRental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnCancelRental.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnCancelRental.IsSelected = false;
            this.btnCancelRental.Location = new System.Drawing.Point(3, 165);
            this.btnCancelRental.Name = "btnCancelRental";
            this.btnCancelRental.Size = new System.Drawing.Size(193, 48);
            this.btnCancelRental.TabIndex = 2;
            this.btnCancelRental.Text = "ยกเลิกบิล";
            this.btnCancelRental.UseVisualStyleBackColor = false;
            this.btnCancelRental.Click += new System.EventHandler(this.btnCancelRental_Click);
            // 
            // btnSubmitSlip
            // 
            this.btnSubmitSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnSubmitSlip.BorderColor = System.Drawing.Color.Black;
            this.btnSubmitSlip.BorderThickness = 1;
            this.btnSubmitSlip.CornerRadius = 12;
            this.btnSubmitSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmitSlip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnSubmitSlip.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnSubmitSlip.IsSelected = false;
            this.btnSubmitSlip.Location = new System.Drawing.Point(3, 111);
            this.btnSubmitSlip.Name = "btnSubmitSlip";
            this.btnSubmitSlip.Size = new System.Drawing.Size(193, 48);
            this.btnSubmitSlip.TabIndex = 1;
            this.btnSubmitSlip.Text = "อัปโหลดสลิป";
            this.btnSubmitSlip.UseVisualStyleBackColor = false;
            this.btnSubmitSlip.Click += new System.EventHandler(this.btnSubmitSlip_Click_1);
            // 
            // picSlipPreview
            // 
            this.picSlipPreview.Location = new System.Drawing.Point(46, 455);
            this.picSlipPreview.Name = "picSlipPreview";
            this.picSlipPreview.Size = new System.Drawing.Size(296, 364);
            this.picSlipPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlipPreview.TabIndex = 39;
            this.picSlipPreview.TabStop = false;
            // 
            // CustomerRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvRentalDetails);
            this.Name = "CustomerRentals";
            this.Size = new System.Drawing.Size(1550, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRentalId;
        private System.Windows.Forms.Label lblOutstandingFine;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvRentalDetails;
        private RoundedButton btnCancelRental;
        private RoundedButton btnSubmitSlip;
        private RoundedButton btnSelectSlip;
        private System.Windows.Forms.Label lblDepositAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picSlipPreview;
        private RoundedButton btnViewSlip;
        private System.Windows.Forms.TableLayoutPanel pnlAction;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.LinkLabel linkSlipFine;
        private System.Windows.Forms.LinkLabel linkSlipPayment;
        private System.Windows.Forms.LinkLabel linkSlipRefund;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHandoverDate;
        private System.Windows.Forms.Label lblReturnDateActual;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblRentalDate;
        private System.Windows.Forms.Label lblCreationTime;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblSlipType;
        private RoundedButton btnBack;
        private System.Windows.Forms.Label lblFineIncurred;
        private System.Windows.Forms.Label lblAmountToRefund;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblNoSlipMessage;
        private System.Windows.Forms.Label lblGrandTotal;
        private RoundedButton btnPrintReceipt;
        private RoundedButton btnShowStoreQR;
    }
}
