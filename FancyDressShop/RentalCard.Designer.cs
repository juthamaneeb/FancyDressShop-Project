namespace FancyDressShop
{
    partial class RentalCard
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
            this.pnlRentalCard = new RoundedPanel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblOutstandingBalance = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picDressPreview = new RoundedPictureBox();
            this.lblRentalId = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.pnlRentalCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDressPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRentalCard
            // 
            this.pnlRentalCard.BackColor = System.Drawing.Color.White;
            this.pnlRentalCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.pnlRentalCard.BorderThickness = 3;
            this.pnlRentalCard.Controls.Add(this.lblTotalPrice);
            this.pnlRentalCard.Controls.Add(this.lblOutstandingBalance);
            this.pnlRentalCard.Controls.Add(this.lblStatus);
            this.pnlRentalCard.Controls.Add(this.picDressPreview);
            this.pnlRentalCard.Controls.Add(this.lblRentalId);
            this.pnlRentalCard.Controls.Add(this.lblDueDate);
            this.pnlRentalCard.CornerRadius = 20;
            this.pnlRentalCard.EnableHover = true;
            this.pnlRentalCard.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.pnlRentalCard.Location = new System.Drawing.Point(3, 3);
            this.pnlRentalCard.Name = "pnlRentalCard";
            this.pnlRentalCard.Size = new System.Drawing.Size(265, 384);
            this.pnlRentalCard.TabIndex = 5;
            this.pnlRentalCard.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.Color.White;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(14, 305);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(76, 25);
            this.lblTotalPrice.TabIndex = 6;
            this.lblTotalPrice.Text = "ยอดรวม :";
            this.lblTotalPrice.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // lblOutstandingBalance
            // 
            this.lblOutstandingBalance.AutoSize = true;
            this.lblOutstandingBalance.BackColor = System.Drawing.Color.White;
            this.lblOutstandingBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblOutstandingBalance.Location = new System.Drawing.Point(14, 330);
            this.lblOutstandingBalance.Name = "lblOutstandingBalance";
            this.lblOutstandingBalance.Size = new System.Drawing.Size(108, 25);
            this.lblOutstandingBalance.TabIndex = 5;
            this.lblOutstandingBalance.Text = "ยอดค้างชำระ :";
            this.lblOutstandingBalance.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblStatus.Location = new System.Drawing.Point(14, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 25);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "สถานะ :";
            this.lblStatus.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // picDressPreview
            // 
            this.picDressPreview.CornerRadius = 20;
            this.picDressPreview.Location = new System.Drawing.Point(36, 19);
            this.picDressPreview.Name = "picDressPreview";
            this.picDressPreview.Size = new System.Drawing.Size(193, 191);
            this.picDressPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDressPreview.TabIndex = 3;
            this.picDressPreview.TabStop = false;
            this.picDressPreview.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // lblRentalId
            // 
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.BackColor = System.Drawing.Color.White;
            this.lblRentalId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalId.Location = new System.Drawing.Point(14, 230);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new System.Drawing.Size(46, 25);
            this.lblRentalId.TabIndex = 1;
            this.lblRentalId.Text = "บิล : ";
            this.lblRentalId.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.White;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDueDate.Location = new System.Drawing.Point(14, 255);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(92, 25);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "กำหนดคืน :";
            this.lblDueDate.Click += new System.EventHandler(this.RentalCard_Click);
            // 
            // RentalCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.pnlRentalCard);
            this.Name = "RentalCard";
            this.Size = new System.Drawing.Size(268, 387);
            this.Click += new System.EventHandler(this.RentalCard_Click);
            this.pnlRentalCard.ResumeLayout(false);
            this.pnlRentalCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDressPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel pnlRentalCard;
        private RoundedPictureBox picDressPreview;
        private System.Windows.Forms.Label lblRentalId;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblOutstandingBalance;
        private System.Windows.Forms.Label lblStatus;
    }
}
