namespace FancyDressShop
{
    partial class CartDisplay
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
            this.flowLayoutPanelItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmptyCart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpRentalDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumDays = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearCart = new RoundedButton();
            this.btnProceed = new RoundedButton();
            this.pnlSummary = new System.Windows.Forms.Label();
            this.lblTotalDeposit = new System.Windows.Forms.Label();
            this.lblTotalRentalPrice = new System.Windows.Forms.Label();
            this.flowLayoutPanelItems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1555, 90);
            this.panel2.TabIndex = 23;
            // 
            // flowLayoutPanelItems
            // 
            this.flowLayoutPanelItems.AutoScroll = true;
            this.flowLayoutPanelItems.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelItems.Controls.Add(this.lblEmptyCart);
            this.flowLayoutPanelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelItems.Location = new System.Drawing.Point(0, 169);
            this.flowLayoutPanelItems.Name = "flowLayoutPanelItems";
            this.flowLayoutPanelItems.Size = new System.Drawing.Size(1103, 831);
            this.flowLayoutPanelItems.TabIndex = 24;
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmptyCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblEmptyCart.Location = new System.Drawing.Point(3, 0);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(138, 25);
            this.lblEmptyCart.TabIndex = 49;
            this.lblEmptyCart.Text = "ไม่มีสินค้าในตะกร้า";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label7.Location = new System.Drawing.Point(331, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "วันที่รับชุด (เริ่มเช่า) :";
            // 
            // dtpRentalDate
            // 
            this.dtpRentalDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpRentalDate.Location = new System.Drawing.Point(489, 27);
            this.dtpRentalDate.Name = "dtpRentalDate";
            this.dtpRentalDate.Size = new System.Drawing.Size(240, 31);
            this.dtpRentalDate.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(67, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 28);
            this.label2.TabIndex = 43;
            this.label2.Text = "กำหนดช่วงเวลาการเช่า";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label8.Location = new System.Drawing.Point(767, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "วันที่กำหนดคืนชุด :";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Location = new System.Drawing.Point(916, 28);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(244, 31);
            this.dtpDueDate.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNumDays);
            this.panel1.Controls.Add(this.dtpRentalDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtpDueDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 79);
            this.panel1.TabIndex = 47;
            // 
            // lblNumDays
            // 
            this.lblNumDays.AutoSize = true;
            this.lblNumDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblNumDays.Location = new System.Drawing.Point(1227, 29);
            this.lblNumDays.Name = "lblNumDays";
            this.lblNumDays.Size = new System.Drawing.Size(81, 25);
            this.lblNumDays.TabIndex = 47;
            this.lblNumDays.Text = "เลขวันเช่า";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearCart);
            this.panel3.Controls.Add(this.btnProceed);
            this.panel3.Controls.Add(this.pnlSummary);
            this.panel3.Controls.Add(this.lblTotalDeposit);
            this.panel3.Controls.Add(this.lblTotalRentalPrice);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1103, 169);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 831);
            this.panel3.TabIndex = 48;
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnClearCart.BorderColor = System.Drawing.Color.Black;
            this.btnClearCart.BorderThickness = 0;
            this.btnClearCart.CornerRadius = 12;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnClearCart.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnClearCart.Location = new System.Drawing.Point(139, 524);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(191, 44);
            this.btnClearCart.TabIndex = 50;
            this.btnClearCart.Text = "ล้างตะกร้า";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnProceed.BorderColor = System.Drawing.Color.Black;
            this.btnProceed.BorderThickness = 0;
            this.btnProceed.CornerRadius = 12;
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProceed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnProceed.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnProceed.Location = new System.Drawing.Point(139, 468);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(191, 50);
            this.btnProceed.TabIndex = 49;
            this.btnProceed.Text = "ดำเนินการชำระเงิน";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.AutoSize = true;
            this.pnlSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.pnlSummary.Location = new System.Drawing.Point(108, 360);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(56, 25);
            this.pnlSummary.TabIndex = 38;
            this.pnlSummary.Text = "ค่ารวม";
            // 
            // lblTotalDeposit
            // 
            this.lblTotalDeposit.AutoSize = true;
            this.lblTotalDeposit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalDeposit.Location = new System.Drawing.Point(108, 303);
            this.lblTotalDeposit.Name = "lblTotalDeposit";
            this.lblTotalDeposit.Size = new System.Drawing.Size(67, 25);
            this.lblTotalDeposit.TabIndex = 36;
            this.lblTotalDeposit.Text = "ค่ามัดจำ";
            // 
            // lblTotalRentalPrice
            // 
            this.lblTotalRentalPrice.AutoSize = true;
            this.lblTotalRentalPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRentalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalRentalPrice.Location = new System.Drawing.Point(108, 250);
            this.lblTotalRentalPrice.Name = "lblTotalRentalPrice";
            this.lblTotalRentalPrice.Size = new System.Drawing.Size(64, 25);
            this.lblTotalRentalPrice.TabIndex = 30;
            this.lblTotalRentalPrice.Text = "ค่าราคา";
            // 
            // CartDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.flowLayoutPanelItems);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CartDisplay";
            this.Size = new System.Drawing.Size(1555, 1000);
            this.flowLayoutPanelItems.ResumeLayout(false);
            this.flowLayoutPanelItems.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpRentalDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumDays;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalRentalPrice;
        private System.Windows.Forms.Label pnlSummary;
        private System.Windows.Forms.Label lblTotalDeposit;
        private RoundedButton btnClearCart;
        private RoundedButton btnProceed;
        private System.Windows.Forms.Label lblEmptyCart;
    }
}
