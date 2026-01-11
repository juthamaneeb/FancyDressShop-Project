namespace FancyDressShop
{
    partial class DressItemControl
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
            this.picDress = new RoundedPictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.roundedPanel2 = new RoundedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).BeginInit();
            this.roundedPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDress
            // 
            this.picDress.CornerRadius = 20;
            this.picDress.Location = new System.Drawing.Point(28, 23);
            this.picDress.Name = "picDress";
            this.picDress.Size = new System.Drawing.Size(229, 243);
            this.picDress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDress.TabIndex = 3;
            this.picDress.TabStop = false;
            this.picDress.Click += new System.EventHandler(this.DressItemControl_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblName.Location = new System.Drawing.Point(13, 285);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "ชื่อ : ";
            this.lblName.Click += new System.EventHandler(this.DressItemControl_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.White;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.lblPrice.Location = new System.Drawing.Point(13, 310);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(55, 25);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "ราคา :";
            this.lblPrice.Click += new System.EventHandler(this.DressItemControl_Click);
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.roundedPanel2.BorderThickness = 3;
            this.roundedPanel2.Controls.Add(this.picDress);
            this.roundedPanel2.Controls.Add(this.lblName);
            this.roundedPanel2.Controls.Add(this.lblPrice);
            this.roundedPanel2.CornerRadius = 20;
            this.roundedPanel2.EnableHover = true;
            this.roundedPanel2.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.roundedPanel2.Location = new System.Drawing.Point(23, 3);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(269, 375);
            this.roundedPanel2.TabIndex = 4;
            this.roundedPanel2.Click += new System.EventHandler(this.DressItemControl_Click);
            // 
            // DressItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.roundedPanel2);
            this.Name = "DressItemControl";
            this.Size = new System.Drawing.Size(295, 389);
            this.Click += new System.EventHandler(this.DressItemControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).EndInit();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private RoundedPictureBox picDress;
        private RoundedPanel roundedPanel2;
    }
}
