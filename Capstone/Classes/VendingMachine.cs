using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; }
        private Dictionary<string, List<Product>> Inventory { get; }

        public VendingMachine(Dictionary<string, List<Product>> inventory, string[] slots)
        {
            this.Inventory = inventory;
            this.Slots = slots;
        }

        public string[] Slots { get; }


        public void FeedMoney(int dollars)
        {
            Balance += dollars;
        }

        public Product Purchase(string slot)
        {
            List<Product> items = Inventory[slot];
            Product item = items[0];

            // Gets the item from the dictionary
            if (items.Count > 0)
            {
                items.RemoveAt(0);
            }
            // Deducts the price of the item from Balance
            Balance -= item.Price;

            // Returns the item to the user
            return item;
        }


        public Change ReturnChange()
        {
            // Turn Balance into "Change"
            Change change = new Change(Balance);

            // Set Balance to 0
            Balance = 0;
            return null;
        }
    }
}
