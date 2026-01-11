namespace FancyDressShop
{
    partial class PaymentConfirmation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picSlipPath = new System.Windows.Forms.PictureBox();
            this.btnHome = new RoundedButton();
            this.btnSubmitPayment = new RoundedButton();
            this.btnBrowseSlip = new RoundedButton();
            this.roundedPanel1 = new RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblDueDateTime = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblRentalId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPath)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1555, 90);
            this.panel2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(41, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "ข้อมูลชุด";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(1043, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 30);
            this.label2.TabIndex = 31;
            this.label2.Text = "หลักฐานการชำระเงิน";
            // 
            // picSlipPath
            // 
            this.picSlipPath.Location = new System.Drawing.Point(950, 344);
            this.picSlipPath.Name = "picSlipPath";
            this.picSlipPath.Size = new System.Drawing.Size(380, 471);
            this.picSlipPath.TabIndex = 30;
            this.picSlipPath.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnHome.BorderColor = System.Drawing.Color.Black;
            this.btnHome.BorderThickness = 0;
            this.btnHome.CornerRadius = 12;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnHome.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnHome.Location = new System.Drawing.Point(928, 905);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(128, 45);
            this.btnHome.TabIndex = 33;
            this.btnHome.Text = "กลับหน้าหลัก";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSubmitPayment
            // 
            this.btnSubmitPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnSubmitPayment.BorderColor = System.Drawing.Color.Black;
            this.btnSubmitPayment.BorderThickness = 0;
            this.btnSubmitPayment.CornerRadius = 12;
            this.btnSubmitPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnSubmitPayment.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnSubmitPayment.Location = new System.Drawing.Point(645, 905);
            this.btnSubmitPayment.Name = "btnSubmitPayment";
            this.btnSubmitPayment.Size = new System.Drawing.Size(263, 45);
            this.btnSubmitPayment.TabIndex = 32;
            this.btnSubmitPayment.Text = "ส่งหลักฐานการชำระเงิน";
            this.btnSubmitPayment.UseVisualStyleBackColor = false;
            this.btnSubmitPayment.Click += new System.EventHandler(this.btnSubmitPayment_Click);
            // 
            // btnBrowseSlip
            // 
            this.btnBrowseSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnBrowseSlip.BorderColor = System.Drawing.Color.Black;
            this.btnBrowseSlip.BorderThickness = 0;
            this.btnBrowseSlip.CornerRadius = 12;
            this.btnBrowseSlip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnBrowseSlip.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnBrowseSlip.Location = new System.Drawing.Point(1083, 248);
            this.btnBrowseSlip.Name = "btnBrowseSlip";
            this.btnBrowseSlip.Size = new System.Drawing.Size(124, 45);
            this.btnBrowseSlip.TabIndex = 29;
            this.btnBrowseSlip.Text = "Browse...";
            this.btnBrowseSlip.UseVisualStyleBackColor = false;
            this.btnBrowseSlip.Click += new System.EventHandler(this.btnBrowseSlip_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel1.BorderThickness = 0;
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.picQRCode);
            this.roundedPanel1.Controls.Add(this.lblDueDateTime);
            this.roundedPanel1.Controls.Add(this.lblGrandTotal);
            this.roundedPanel1.Controls.Add(this.lblRentalId);
            this.roundedPanel1.CornerRadius = 20;
            this.roundedPanel1.EnableHover = false;
            this.roundedPanel1.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel1.Location = new System.Drawing.Point(112, 139);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(655, 741);
            this.roundedPanel1.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(72, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(516, 28);
            this.label3.TabIndex = 28;
            this.label3.Text = "เหตุหมาย : หากไม่ชำระตามกำหนดเวลา การจองจะถูกยกเว้นอัตโนมัติ";
            // 
            // picQRCode
            // 
            this.picQRCode.Image = global::FancyDressShop.Properties.Resources.qrfancydress;
            this.picQRCode.Location = new System.Drawing.Point(116, 229);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(423, 471);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 27;
            this.picQRCode.TabStop = false;
            // 
            // lblDueDateTime
            // 
            this.lblDueDateTime.AutoSize = true;
            this.lblDueDateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDueDateTime.Location = new System.Drawing.Point(43, 126);
            this.lblDueDateTime.Name = "lblDueDateTime";
            this.lblDueDateTime.Size = new System.Drawing.Size(151, 28);
            this.lblDueDateTime.TabIndex = 26;
            this.lblDueDateTime.Text = "กำหนดวันชำระเงิน";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(43, 85);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(125, 28);
            this.lblGrandTotal.TabIndex = 25;
            this.lblGrandTotal.Text = "ยอดเงินทั้งหมด";
            // 
            // lblRentalId
            // 
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblRentalId.Location = new System.Drawing.Point(135, 39);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new System.Drawing.Size(103, 30);
            this.lblRentalId.TabIndex = 24;
            this.lblRentalId.Text = "ID rental";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label4.Location = new System.Drawing.Point(43, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 30);
            this.label4.TabIndex = 29;
            this.label4.Text = "รหัสบิล:";
            // 
            // PaymentConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSubmitPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSlip);
            this.Controls.Add(this.picSlipPath);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "PaymentConfirmation";
            this.Size = new System.Drawing.Size(1555, 1000);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlipPath)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblRentalId;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label lblDueDateTime;
        private System.Windows.Forms.PictureBox picQRCode;
        private RoundedButton btnBrowseSlip;
        private System.Windows.Forms.PictureBox picSlipPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundedButton btnSubmitPayment;
        private RoundedButton btnHome;
        private System.Windows.Forms.Label label4;
    }
}
