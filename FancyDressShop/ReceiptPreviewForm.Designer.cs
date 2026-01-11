namespace FancyDressShop
{
    partial class ReceiptPreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptPreviewForm));
            this.btnPrintPdf = new RoundedButton();
            this.picReceiptPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelReceipt = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picReceiptPreview)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelReceipt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintPdf
            // 
            this.btnPrintPdf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnPrintPdf.BorderColor = System.Drawing.Color.Black;
            this.btnPrintPdf.BorderThickness = 0;
            this.btnPrintPdf.CornerRadius = 12;
            this.btnPrintPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnPrintPdf.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnPrintPdf.IsSelected = false;
            this.btnPrintPdf.Location = new System.Drawing.Point(261, 10);
            this.btnPrintPdf.Name = "btnPrintPdf";
            this.btnPrintPdf.Size = new System.Drawing.Size(275, 34);
            this.btnPrintPdf.TabIndex = 30;
            this.btnPrintPdf.Text = "พิมพ์ (บันทึกเป็น PDF)";
            this.btnPrintPdf.UseVisualStyleBackColor = false;
            this.btnPrintPdf.Click += new System.EventHandler(this.btnPrintPdf_Click);
            // 
            // picReceiptPreview
            // 
            this.picReceiptPreview.Location = new System.Drawing.Point(0, 0);
            this.picReceiptPreview.Name = "picReceiptPreview";
            this.picReceiptPreview.Size = new System.Drawing.Size(751, 844);
            this.picReceiptPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picReceiptPreview.TabIndex = 0;
            this.picReceiptPreview.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnPrintPdf, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 992);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 54);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelReceipt
            // 
            this.panelReceipt.AutoScroll = true;
            this.panelReceipt.Controls.Add(this.picReceiptPreview);
            this.panelReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReceipt.Location = new System.Drawing.Point(0, 0);
            this.panelReceipt.Name = "panelReceipt";
            this.panelReceipt.Size = new System.Drawing.Size(798, 992);
            this.panelReceipt.TabIndex = 3;
            // 
            // ReceiptPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(798, 1046);
            this.Controls.Add(this.panelReceipt);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceiptPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ใบเสร็จรับเงิน";
            ((System.ComponentModel.ISupportInitialize)(this.picReceiptPreview)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelReceipt.ResumeLayout(false);
            this.panelReceipt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picReceiptPreview;
        private RoundedButton btnPrintPdf;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelReceipt;
    }
}