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

        public VendingMachine(Dictionary<string, List<Product>> inventory)
        {
            this.Inventory = inventory;
            
        }

       public string[] Slots
        {
            get
            {
                Inventory.Keys.ToArray();
                return Slots;
            }
        }



        public void FeedMoney(int dollars)
        {
            Balance += dollars;
        }

        public Product Purchase(string slot)
        {
            List<Product> items = Inventory[slot];
            Product item = null;

            // Gets the item from the dictionary
            if (items.Count > 0)
            {
                if (Balance > item.Price)
                {
                    items.RemoveAt(0);

                    // Deducts the price of the item from Balance

                    Balance -= item.Price;
                }
            }
           

            // Returns the item to the user
            
            return item;
        }

        public int GetQuantityRemaining(string slot)
        {
            List<Product> items = Inventory[slot];

            return items.Count;
        }


        public Change ReturnChange()
        {
            Change output = new Change(Balance);
            Balance = 0;
            return output;
         
        }
    }
}
