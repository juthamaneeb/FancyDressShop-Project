namespace FancyDressShop
{
    partial class CustomerCart
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
            this.flowLayoutPanelRentals = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCurrentBills = new RoundedButton();
            this.btnHistory = new RoundedButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRentals
            // 
            this.flowLayoutPanelRentals.AutoScroll = true;
            this.flowLayoutPanelRentals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRentals.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelRentals.Name = "flowLayoutPanelRentals";
            this.flowLayoutPanelRentals.Size = new System.Drawing.Size(1500, 910);
            this.flowLayoutPanelRentals.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.pnlHeader.Controls.Add(this.btnCurrentBills);
            this.pnlHeader.Controls.Add(this.btnHistory);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1500, 90);
            this.pnlHeader.TabIndex = 51;
            // 
            // btnCurrentBills
            // 
            this.btnCurrentBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnCurrentBills.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnCurrentBills.BorderThickness = 0;
            this.btnCurrentBills.CornerRadius = 12;
            this.btnCurrentBills.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrentBills.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCurrentBills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnCurrentBills.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnCurrentBills.IsSelected = false;
            this.btnCurrentBills.Location = new System.Drawing.Point(43, 25);
            this.btnCurrentBills.Name = "btnCurrentBills";
            this.btnCurrentBills.Size = new System.Drawing.Size(153, 40);
            this.btnCurrentBills.TabIndex = 10;
            this.btnCurrentBills.Text = "บิลปัจจุบัน";
            this.btnCurrentBills.UseVisualStyleBackColor = false;
            this.btnCurrentBills.Click += new System.EventHandler(this.BtnCurrentBills_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.btnHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnHistory.BorderThickness = 0;
            this.btnHistory.CornerRadius = 12;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnHistory.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(211)))), ((int)(((byte)(110)))));
            this.btnHistory.IsSelected = false;
            this.btnHistory.Location = new System.Drawing.Point(231, 25);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(153, 40);
            this.btnHistory.TabIndex = 9;
            this.btnHistory.Text = "ประวัติ";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.BtnHistory_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.flowLayoutPanelRentals);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 90);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1500, 910);
            this.pnlBody.TabIndex = 0;
            // 
            // CustomerCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CustomerCart";
            this.Size = new System.Drawing.Size(1500, 1000);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRentals;
        private System.Windows.Forms.Panel pnlHeader;
        private RoundedButton btnCurrentBills;
        private RoundedButton btnHistory;
        private System.Windows.Forms.Panel pnlBody;
    }
}
