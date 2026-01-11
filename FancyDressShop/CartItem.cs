using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop
{
    public class CartItem
    {
        public int DressInventoryId { get; set; }
        public string DressName { get; set; }
        public string DressSize { get; set; }
        public int Quantity { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public decimal DepositPrice { get; set; }
        public string ImagePath { get; set; }
        public int MaxAvailableQuantity { get; set; }
    }
}
