using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public partial class CartItemCard : UserControl
    {
        private CartItem currentItem;
        private int _numberOfDays;

        public event EventHandler ItemChanged;
        public event EventHandler ItemRemoved;

        public CartItemCard(CartItem item, int numberOfDays)
        {
            InitializeComponent();
            this.currentItem = item;

            this._numberOfDays = numberOfDays;

            DisplayItemData();

            UpdatePrice(this._numberOfDays);

            nudQuantity.ValueChanged += nudQuantity_ValueChanged;
        }

        private void DisplayItemData()
        {
            if (currentItem == null) return;

            lblDressName.Text = currentItem.DressName;
            lblSize.Text = $"ไซส์: {currentItem.DressSize}";

            nudQuantity.Value = currentItem.Quantity;
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = currentItem.MaxAvailableQuantity;

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentItem.ImagePath);

            if (!string.IsNullOrEmpty(currentItem.ImagePath) && File.Exists(fullPath))
            {
                try
                {
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    using (var ms = new System.IO.MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        picDressImage.Image = Image.FromStream(ms);
                    }
                    picDressImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                    picDressImage.Image = null;
                }
            }
            else
            {
                picDressImage.Image = null; // หรือใส่รูป Default
            }
        }

        public void UpdatePrice(int numberOfDays)
        {
            this._numberOfDays = numberOfDays;

            if (numberOfDays <= 0)
            {
                lblItemPrice.Text = $"ราคา: {currentItem.RentalPricePerDay:N2} บ./วัน | มัดจำ: {currentItem.DepositPrice:N2} บ.";
                lblItemTotal.Text = "ยอดรวม: 0.00 บ. (กรุณากำหนดวัน)";
                return;
            }

            decimal itemRentalPrice = currentItem.RentalPricePerDay * currentItem.Quantity * numberOfDays;
            decimal itemDeposit = currentItem.DepositPrice * currentItem.Quantity;
            decimal itemGrandTotal = itemRentalPrice + itemDeposit;

            lblItemPrice.Text = $"ราคา: {currentItem.RentalPricePerDay:N2} บ./วัน | มัดจำ: {currentItem.DepositPrice:N2} บ.";
            lblItemTotal.Text = $"ยอดรวม: {itemGrandTotal:N2} บ."; 
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            CartManager.Instance.RemoveItem(currentItem.DressInventoryId);

            ItemRemoved?.Invoke(this, EventArgs.Empty);
        }


        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            int newQuantity = (int)nudQuantity.Value;

            if (newQuantity < 1) return;

            var itemInManager = CartManager.Instance.Items.FirstOrDefault(i => i.DressInventoryId == currentItem.DressInventoryId);
            if (itemInManager != null)
            {
                itemInManager.Quantity = newQuantity;
                currentItem.Quantity = newQuantity;
            }

            UpdatePrice(this._numberOfDays);

            ItemChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
