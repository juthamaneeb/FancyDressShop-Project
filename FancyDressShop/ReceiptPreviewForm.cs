using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public partial class ReceiptPreviewForm : Form
    {
        public FancyDressShop.Rental RentalData { get; private set; }

        public ReceiptPreviewForm(Image receiptImage, FancyDressShop.Rental rentalData)
        {
            InitializeComponent();

            this.picReceiptPreview.Image = receiptImage;

            this.RentalData = rentalData;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(620, 600);
        }

        private void btnPrintPdf_Click(object sender, EventArgs e)
        {
            var generator = new FancyDressShop.ReceiptGenerator();
            generator.GenerateReceipt(this.RentalData);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
