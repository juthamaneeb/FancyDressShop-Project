namespace FancyDressShop
{
    partial class DressDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedPanel1 = new RoundedPanel();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new RoundedPanel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.roundedPanel4 = new RoundedPanel();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new RoundedPanel();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblDetailPrice = new System.Windows.Forms.Label();
            this.lblDetailDeposit = new System.Windows.Forms.Label();
            this.lblAvailableStock = new System.Windows.Forms.Label();
            this.btnAddToCart = new RoundedButton();
            this.btnBack = new RoundedButton();
            this.picFullDress = new RoundedPictureBox();
            this.flowLayoutPanelRelated = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFullDress)).BeginInit();
            this.SuspendLayout();
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1655, 90);
            this.panel2.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.52174F));
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picFullDress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelRelated, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 653F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1655, 910);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel1.BorderThickness = 0;
            this.roundedPanel1.Controls.Add(this.lblDetailName);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.roundedPanel3);
            this.roundedPanel1.Controls.Add(this.roundedPanel4);
            this.roundedPanel1.Controls.Add(this.label2);
            this.roundedPanel1.Controls.Add(this.label16);
            this.roundedPanel1.Controls.Add(this.roundedPanel2);
            this.roundedPanel1.Controls.Add(this.lblDetailPrice);
            this.roundedPanel1.Controls.Add(this.lblDetailDeposit);
            this.roundedPanel1.Controls.Add(this.lblAvailableStock);
            this.roundedPanel1.Controls.Add(this.btnAddToCart);
            this.roundedPanel1.Controls.Add(this.btnBack);
            this.roundedPanel1.CornerRadius = 20;
            this.roundedPanel1.EnableHover = false;
            this.roundedPanel1.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel1.Location = new System.Drawing.Point(840, 32);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(693, 588);
            this.roundedPanel1.TabIndex = 23;
            // 
            // lblDetailName
            // 
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDetailName.Location = new System.Drawing.Point(49, 18);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(228, 30);
            this.lblDetailName.TabIndex = 1;
            this.lblDetailName.Text = "lblDetailName ชื่อชุด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(49, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "รายละเอียด :";
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.White;
            this.roundedPanel3.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel3.BorderThickness = 1;
            this.roundedPanel3.Controls.Add(this.txtDescription);
            this.roundedPanel3.CornerRadius = 12;
            this.roundedPanel3.EnableHover = false;
            this.roundedPanel3.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel3.Location = new System.Drawing.Point(54, 89);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(558, 136);
            this.roundedPanel3.TabIndex = 13;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.txtDescription.Location = new System.Drawing.Point(19, 0);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(539, 136);
            this.txtDescription.TabIndex = 2;
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.White;
            this.roundedPanel4.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel4.BorderThickness = 1;
            this.roundedPanel4.Controls.Add(this.cmbSize);
            this.roundedPanel4.CornerRadius = 12;
            this.roundedPanel4.EnableHover = false;
            this.roundedPanel4.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel4.Location = new System.Drawing.Point(231, 231);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Size = new System.Drawing.Size(123, 38);
            this.roundedPanel4.TabIndex = 14;
            // 
            // cmbSize
            // 
            this.cmbSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(16, 0);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(107, 36);
            this.cmbSize.TabIndex = 5;
            this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(49, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "ไซส์ที่ต้องการจอง :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.label16.Location = new System.Drawing.Point(49, 284);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 25);
            this.label16.TabIndex = 44;
            this.label16.Text = "จำนวนชุดที่เช่า :";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel2.BorderThickness = 1;
            this.roundedPanel2.Controls.Add(this.nudQuantity);
            this.roundedPanel2.CornerRadius = 12;
            this.roundedPanel2.EnableHover = false;
            this.roundedPanel2.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel2.Location = new System.Drawing.Point(231, 278);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(123, 38);
            this.roundedPanel2.TabIndex = 15;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.nudQuantity.Location = new System.Drawing.Point(21, 0);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(102, 31);
            this.nudQuantity.TabIndex = 45;
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // lblDetailPrice
            // 
            this.lblDetailPrice.AutoSize = true;
            this.lblDetailPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDetailPrice.Location = new System.Drawing.Point(49, 329);
            this.lblDetailPrice.Name = "lblDetailPrice";
            this.lblDetailPrice.Size = new System.Drawing.Size(195, 28);
            this.lblDetailPrice.TabIndex = 3;
            this.lblDetailPrice.Text = "lblDetailPrice ราคาชุด";
            // 
            // lblDetailDeposit
            // 
            this.lblDetailDeposit.AutoSize = true;
            this.lblDetailDeposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDetailDeposit.Location = new System.Drawing.Point(49, 368);
            this.lblDetailDeposit.Name = "lblDetailDeposit";
            this.lblDetailDeposit.Size = new System.Drawing.Size(221, 28);
            this.lblDetailDeposit.TabIndex = 4;
            this.lblDetailDeposit.Text = "lblDetailDeposit ค่ามัดจำ";
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblAvailableStock.Location = new System.Drawing.Point(49, 406);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new System.Drawing.Size(229, 28);
            this.lblAvailableStock.TabIndex = 6;
            this.lblAvailableStock.Text = "lblAvailableStock ชุดที่ว่าง";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnAddToCart.BorderColor = System.Drawing.Color.Black;
            this.btnAddToCart.BorderThickness = 0;
            this.btnAddToCart.CornerRadius = 12;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnAddToCart.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnAddToCart.IsSelected = false;
            this.btnAddToCart.Location = new System.Drawing.Point(231, 476);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(166, 54);
            this.btnAddToCart.TabIndex = 15;
            this.btnAddToCart.Text = "เพิ่มลงตะกร้า";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnBack.BorderColor = System.Drawing.Color.Black;
            this.btnBack.BorderThickness = 0;
            this.btnBack.CornerRadius = 12;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnBack.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnBack.IsSelected = false;
            this.btnBack.Location = new System.Drawing.Point(412, 476);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 54);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "ย้อนกลับ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picFullDress
            // 
            this.picFullDress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picFullDress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.picFullDress.CornerRadius = 40;
            this.picFullDress.Location = new System.Drawing.Point(158, 68);
            this.picFullDress.Name = "picFullDress";
            this.picFullDress.Size = new System.Drawing.Size(403, 516);
            this.picFullDress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFullDress.TabIndex = 24;
            this.picFullDress.TabStop = false;
            // 
            // flowLayoutPanelRelated
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanelRelated, 2);
            this.flowLayoutPanelRelated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRelated.Location = new System.Drawing.Point(3, 656);
            this.flowLayoutPanelRelated.Name = "flowLayoutPanelRelated";
            this.flowLayoutPanelRelated.Size = new System.Drawing.Size(1649, 251);
            this.flowLayoutPanelRelated.TabIndex = 25;
            this.flowLayoutPanelRelated.WrapContents = false;
            // 
            // DressDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "DressDetail";
            this.Size = new System.Drawing.Size(1655, 1000);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFullDress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDetailPrice;
        private System.Windows.Forms.Label lblDetailDeposit;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label lblAvailableStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel3;
        private RoundedPanel roundedPanel4;
        private RoundedButton btnBack;
        private RoundedButton btnAddToCart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPictureBox picFullDress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRelated;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label16;
    }
}