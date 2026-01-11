using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyDressShop
{
    public class CartManager
    {
        private static readonly CartManager _instance = new CartManager();

        public List<CartItem> Items { get; private set; } = new List<CartItem>();

        public DateTime? RentalDate { get; set; }
        public DateTime? DueDate { get; set; }

        public static CartManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private CartManager() { }

        public event EventHandler CartUpdated;

        private void OnCartUpdated()
        {
            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public List<CartItem> GetItems()
        {
            return this.Items;
        }

        public void AddOrUpdateItem(CartItem newItem)
        {
            var existingItem = Items.FirstOrDefault(i =>
                i.DressInventoryId == newItem.DressInventoryId);

            if (existingItem != null)
            {
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                Items.Add(newItem);
            }
            OnCartUpdated();
        }

        public void AddItem(CartItem newItem)
        {
            var existingItem = Items.FirstOrDefault(
                i => i.DressInventoryId == newItem.DressInventoryId);

            if (existingItem != null)
            {
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                Items.Add(newItem);
            }
        }

        public void RemoveItem(int inventoryId)
        {
            var itemToRemove = Items.FirstOrDefault(i => i.DressInventoryId == inventoryId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            Items.Clear();
            RentalDate = null;
            DueDate = null;
        }
    }

}
