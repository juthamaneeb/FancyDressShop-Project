using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop.Models
{
    public class FancyDress
    {
        public int DressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public decimal DepositPrice { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public string ThaiStatus { get; set; }

        public FancyDress() { }

        public FancyDress(int dressId, string name, string description, string category, string size,
                          decimal rentalPricePerDay, decimal depositPrice, int totalQuantity,
                          int availableQuantity, string imagePath, string status)
        {
            DressId = dressId;
            Name = name;
            Description = description;
            Category = category;
            RentalPricePerDay = rentalPricePerDay;
            DepositPrice = depositPrice;
            ImagePath = imagePath;
            Status = status;
        }
    }
}
