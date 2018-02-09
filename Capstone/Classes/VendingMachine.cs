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
        public Dictionary<string, List<Product>> Inventory { get; }
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
                //return Slots;
            }
        }



        public void FeedMoney(int dollars)
        {
            Balance += dollars;

            log.RecordDeposit(dollars, Balance);

        }

        public Product Purchase(string slot)
        {
            Product item = null;

            if (Inventory.ContainsKey(slot))
            {
                List<Product> items = Inventory[slot];
                item = items[0];

                if (items.Count > 0)
                {
                    if (Balance > item.Price)
                    {
                        items.RemoveAt(0);

                        // Deducts the price of the item from Balance

                        Balance -= item.Price;

                        log.RecordPurchase(slot, item.Name, Balance + item.Price, Balance);
                        totalSales += item.Price;

                        

                        if (salesReport.ContainsKey(item.Name))
                        {
                            salesReport[item.Name] = salesReport[item.Name] + 1;
                        }
                        else
                        {
                            salesReport.Add(item.Name, 1);
                        }

                        log.RecordCompleteTransaction(totalSales, salesReport);
                    }
                    else
                    {
                        throw new VendingMachineExceptions("Insufficient funds.");
                    }
                }
                else
                {
                    throw new VendingMachineExceptions("Out of stock!");
                }
            }
            else
            {
                throw new VendingMachineExceptions("Invalid slot!");
            }
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
            Console.WriteLine(output.ChangeAmount);

            return output;



        }
    }
}
