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
        public TransactionLogger log = new TransactionLogger("Log.txt", "SalesReport.txt");

        public decimal Balance { get; private set; }
        private Dictionary<string, List<Product>> Inventory { get; }
        public Dictionary<string, int> salesReport = new Dictionary<string, int>();

        private decimal totalSales = 0;

        public VendingMachine(Dictionary<string, List<Product>> inventory)
        {
            this.Inventory = inventory;

            foreach (var kvp in Inventory)
            {
                salesReport.Add(kvp.Value[0].Name, 0);
            }
        }

        public string[] Slots
        {
            get
            {
                return Inventory.Keys.ToArray();
            }
        }

        public Product GetItemAtSlot(string slot)
        {
            Product product = null;

            if (Inventory.ContainsKey(slot) && GetQuantityRemaining(slot) > 0)
            {
                product = Inventory[slot][0];
            }

            return product;
        }


        public void FeedMoney(int dollars)
        {
            if (dollars > 0)
            {
                Balance += dollars;
                log.RecordDeposit(dollars, Balance);
            }
        }

        public Product Purchase(string slot)
        {
            Product item = null;

            if (!Inventory.ContainsKey(slot))
            {
                throw new VendingMachineExceptions("Invalid slot!");
            }

            if (Inventory[slot].Count == 0)
            {
                throw new VendingMachineExceptions("Out of stock!");
            }

            if (Balance < Inventory[slot][0].Price)
            {
                throw new VendingMachineExceptions("Insufficient funds.");
            }

            item = Inventory[slot][0];
            Inventory[slot].RemoveAt(0);

            // Deducts the price of the item from Balance
            Balance -= item.Price;

            log.RecordPurchase(slot, item.Name, Balance + item.Price, Balance);
            AddPurchaseToSalesReport(item);

            log.RecordCompleteTransaction(totalSales, salesReport);


            return item;
        }

        private void AddPurchaseToSalesReport(Product item)
        {
            totalSales += item.Price;

            if (salesReport.ContainsKey(item.Name))
            {
                salesReport[item.Name] = salesReport[item.Name] + 1;
            }
            else
            {
                salesReport.Add(item.Name, 1);
            }
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
