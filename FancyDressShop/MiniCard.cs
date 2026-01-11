using FancyDressShop.Models;
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
    public partial class MiniCard : UserControl
    {
        public int DressId { get; set; }
        public delegate void ViewDetailsHandler(object sender, int dressId);
        public event ViewDetailsHandler OnViewDetailsClicked;
        private FancyDress currentDress;
        public MiniCard()
        {
            InitializeComponent();
        }

        public void SetDressData(FancyDress dress)
        {
            this.DressId = dress.DressId;
            this.currentDress = dress;

            lblName.Text = $"ชื่อ : {dress.Name}";
            lblPrice.Text = $"ราคา: {dress.RentalPricePerDay:N2} บ./วัน";

            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dress.ImagePath);

            if (!string.IsNullOrEmpty(dress.ImagePath) && System.IO.File.Exists(fullPath))
            {
                try
                {
                    using (var stream = new System.IO.FileStream(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        picDress.Image = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image for Dress ID {dress.DressId}: {ex.Message}");
                    picDress.Image = null;
                }
            }
            else
            {
                picDress.Image = null;
            }
        }


        private void MiniCard_Click(object sender, EventArgs e)
        {
            if (OnViewDetailsClicked != null)
            {
                OnViewDetailsClicked(this, this.DressId);
            }
        }
    }
}
