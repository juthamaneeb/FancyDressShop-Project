using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal? OutstandingBalance { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentSlipPath { get; set; }
        public string FineSlipPath { get; set; }
        public string Notes { get; set; }
        public List<RentalDetail> Details { get; set; }
        public string CustomerName { get; set; }
        public DateTime? PaymentConfirmedDate { get; set; }
        public DateTime? HandoverDate { get; set; } 
        public DateTime? FinalizeDate { get; set; }
        public string RefundSlipPath { get; set; }
    }
}
