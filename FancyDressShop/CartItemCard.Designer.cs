namespace FancyDressShop
{
    partial class CartItemCard
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
            this.roundedPanel1 = new RoundedPanel();
            this.lblItemTotal = new System.Windows.Forms.Label();
            this.btnRemove = new RoundedButton();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblDressName = new System.Windows.Forms.Label();
            this.picDressImage = new System.Windows.Forms.PictureBox();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDressImage)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel1.BorderThickness = 1;
            this.roundedPanel1.Controls.Add(this.lblItemTotal);
            this.roundedPanel1.Controls.Add(this.btnRemove);
            this.roundedPanel1.Controls.Add(this.nudQuantity);
            this.roundedPanel1.Controls.Add(this.lblSize);
            this.roundedPanel1.Controls.Add(this.lblItemPrice);
            this.roundedPanel1.Controls.Add(this.lblDressName);
            this.roundedPanel1.Controls.Add(this.picDressImage);
            this.roundedPanel1.CornerRadius = 20;
            this.roundedPanel1.EnableHover = true;
            this.roundedPanel1.HoverBorderColor = System.Drawing.Color.Red;
            this.roundedPanel1.Location = new System.Drawing.Point(14, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(1173, 157);
            this.roundedPanel1.TabIndex = 0;
            // 
            // lblItemTotal
            // 
            this.lblItemTotal.AutoSize = true;
            this.lblItemTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblItemTotal.Location = new System.Drawing.Point(653, 62);
            this.lblItemTotal.Name = "lblItemTotal";
            this.lblItemTotal.Size = new System.Drawing.Size(162, 25);
            this.lblItemTotal.TabIndex = 52;
            this.lblItemTotal.Text = "ราคารวมของรายการนี้";
            // 
            // btnRemove
            // 
            this.btnRemove.BorderColor = System.Drawing.Color.Black;
            this.btnRemove.BorderThickness = 1;
            this.btnRemove.CornerRadius = 15;
            this.btnRemove.HoverBackColor = System.Drawing.Color.Black;
            this.btnRemove.IsSelected = false;
            this.btnRemove.Location = new System.Drawing.Point(1082, 53);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(51, 46);
            this.btnRemove.TabIndex = 51;
            this.btnRemove.Text = "ลบ";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantity.Location = new System.Drawing.Point(1010, 62);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(56, 31);
            this.nudQuantity.TabIndex = 50;
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblSize.Location = new System.Drawing.Point(157, 62);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(40, 25);
            this.lblSize.TabIndex = 49;
            this.lblSize.Text = "ไซส์";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblItemPrice.Location = new System.Drawing.Point(353, 62);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(87, 25);
            this.lblItemPrice.TabIndex = 48;
            this.lblItemPrice.Text = "ราคาต่อชุด";
            // 
            // lblDressName
            // 
            this.lblDressName.AutoSize = true;
            this.lblDressName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDressName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblDressName.Location = new System.Drawing.Point(158, 12);
            this.lblDressName.Name = "lblDressName";
            this.lblDressName.Size = new System.Drawing.Size(39, 28);
            this.lblDressName.TabIndex = 45;
            this.lblDressName.Text = "ชื่อ";
            // 
            // picDressImage
            // 
            this.picDressImage.Location = new System.Drawing.Point(24, 12);
            this.picDressImage.Name = "picDressImage";
            this.picDressImage.Size = new System.Drawing.Size(127, 126);
            this.picDressImage.TabIndex = 0;
            this.picDressImage.TabStop = false;
            // 
            // CartItemCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.roundedPanel1);
            this.Name = "CartItemCard";
            this.Size = new System.Drawing.Size(1200, 157);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDressImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.PictureBox picDressImage;
        private RoundedButton btnRemove;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblDressName;
        private System.Windows.Forms.Label lblItemTotal;
    }
}
