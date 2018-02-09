using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        private VendingMachine vendingMachine { get; }

        public VendingMachineCLI(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }


        public void Run()
        {
            
            Console.WriteLine("WELCOME TO VENDO MATIC");
            string slot = "";
            List<string> selectionMemory = new List<string>();

            while (true)
            {
                Console.WriteLine('\n');
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please Select One of the Following Options.");
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchasing Menu");
                Console.WriteLine("Press 0 at any point of the transaction when you want to quit!");
                Console.WriteLine("Enter your option: ");

                int userInput = Convert.ToInt32(Console.ReadLine());
               

                if (userInput == 1)
                {
                    Console.Clear();
                    DisplayVendingMachine(); 

                }
                else if (userInput == 2)
                {
                   Console.Clear();

                    while (true)
                    {
                        
                        PurchasingMenuOptions();

                        int userInput2 = Convert.ToInt32(Console.ReadLine());

                        if (userInput2 == 1)
                        {
                            Console.Clear();
                            UserInputMoney();

                        }
                        else if (userInput2 == 2)
                        {
                            Console.WriteLine("Please enter the product slot number.");
                            slot = Console.ReadLine();
   
                            try
                            {
                                vendingMachine.Purchase(slot);

                                selectionMemory.Add(slot);
                            }
                            catch (VendingMachineExceptions ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                        }
                        else if (userInput2 == 3)
                        {
                            Console.Clear();
                            vendingMachine.ReturnChange();

                            ConsumeMessages(selectionMemory);

                            break;
                        }
                    }
                }
                else if(userInput == 0)
                {
                    break;
                }

            }
        }

        private static void ConsumeMessages(List<string> selectionMemory)
        {
            foreach (string item in selectionMemory)

                if (item.StartsWith("A"))
                {
                    Console.WriteLine("Crunch Crunch, Yum!");
                }
                else if (item.StartsWith("B"))
                {
                    Console.WriteLine("Munch Munch, Yum!");
                }
                else if (item.StartsWith("C"))
                {
                    Console.WriteLine("Glug Glug, Yum!");
                }
                else if (item.StartsWith("D"))
                {
                    Console.WriteLine("Chew Chew, Yum!");
                }
        }

       

        private void UserInputMoney()
        {
            Console.WriteLine("Please feed in your dollar amount.");

            int dollars = Convert.ToInt32(Console.ReadLine());

            vendingMachine.FeedMoney(dollars);
        }

        private void PurchasingMenuOptions()
        {
            Console.WriteLine("Purchasing Menu");
            Console.WriteLine("1) Enter Money");
            Console.WriteLine("2) Select Product");
            Console.WriteLine("3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: ${vendingMachine.Balance}");
        }

        private void DisplayVendingMachine()
        {
            foreach (var kvp in vendingMachine.Inventory)
            {
                Console.WriteLine(kvp.Key + " " + " - " + (kvp.Value.Count() != 0 ? kvp.Value[0].Name : "Sold-Out"));
            }
        }
    }
}
