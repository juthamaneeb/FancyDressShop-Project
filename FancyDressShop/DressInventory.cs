using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop
{
    public class DressInventory
    {
        public int InventoryId { get; set; }
        public int DressId { get; set; }
        public string Size { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }

        public DressInventory()
        {
        }
    }
}
