using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop
{
    public class RentalDetail
    {
        public int RentalDetailId { get; set; }
        public int RentalId { get; set; }
        public decimal DailyRentalPrice { get; set; }
        public int DressInventoryId { get; set; }
        public int RentalQuantity { get; set; }
        public decimal PriceAtRental { get; set; }
        public string DressName { get; set; }
        public string DressSize { get; set; }
        public decimal DepositPrice { get; set; }
    }
}
