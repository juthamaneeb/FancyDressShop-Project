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
    public partial class RentalCard : UserControl
    {
        private RentalRepository rentalRepository = new RentalRepository();
        public Rental RentalData { get; private set; }
        public event EventHandler<Rental> RentalCardSelected;
        public RentalCard(Rental rental)
        {
            InitializeComponent();
            this.RentalData = rental;
            DisplayRentalData();
        }

        private void DisplayRentalData()
        {
            if (RentalData == null) return;

            lblRentalId.Text = $"ID: {RentalData.RentalId}";
            lblStatus.Text = RentalRepository.ConvertStatusToThai(RentalData.Status);
            lblTotalPrice.Text = $"ยอดรวม: {RentalData.TotalPrice:N2} บ.";
            lblDueDate.Text = $"คืน: {RentalData.DueDate.ToShortDateString()}";

            decimal outstanding = RentalData.OutstandingBalance ?? 0;
            if (outstanding > 0)
            {
                lblOutstandingBalance.Text = $"ค่าปรับค้าง: {outstanding:N2} บ.";
                lblOutstandingBalance.ForeColor = Color.Red;
            }
            else
            {
                lblOutstandingBalance.Text = "ไม่มีค่าปรับ";
                lblOutstandingBalance.ForeColor = Color.Green;
            }

            string relativePath = rentalRepository.GetFirstDressImagePathByRentalId(RentalData.RentalId);

            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            if (!string.IsNullOrEmpty(relativePath) && System.IO.File.Exists(fullPath))
            {
                try
                {
                    using (var stream = new System.IO.FileStream(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    using (var ms = new System.IO.MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        picDressPreview.Image = Image.FromStream(ms);
                    }
                    picDressPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image Load Error: {ex.Message}");
                    picDressPreview.Image = null;
                }
            }
            else
            {
                picDressPreview.Image = null;
            }
        }

        private void RentalCard_Click(object sender, EventArgs e)
        {
            if (this.RentalData != null)
            {
                RentalCardSelected?.Invoke(this, this.RentalData);
            }
        }
    }
}
