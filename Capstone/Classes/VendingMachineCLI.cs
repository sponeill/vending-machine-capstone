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
            
            while (true)
            {
                MainMenuText();

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    DisplayVendingMachine();
                }
                else if (userInput == "2")
                {
                    DispayPurchaseMenu();                    
                }
                else if (userInput == "0")
                {
                    break;
                }
            }
        }

        private void DispayPurchaseMenu()
        {            
            List<Product> purchasedProducts = new List<Product>();

            Console.Clear();

            while (true)
            {
                PurchasingMenuOptions();

                string userInput2 = Console.ReadLine();

                if (userInput2 == "1")
                {                    
                    UserInputMoney();
                }
                else if (userInput2 == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the product slot number.");
                    string slot = Console.ReadLine();

                    try
                    {
                        Product item = vendingMachine.Purchase(slot);
                        purchasedProducts.Add(item);
                    }
                    catch (VendingMachineExceptions ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (userInput2 == "3")
                {
                    Console.Clear();
                    Change change = vendingMachine.ReturnChange();
                    Console.WriteLine(change.ChangeAmount);

                    ConsumeMessages(purchasedProducts);
                    purchasedProducts.Clear();

                    break;
                }
            }
        }

        private static void MainMenuText()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("Please Select One of the Following Options.");
            Console.WriteLine("1) Display Vending Machine Items");
            Console.WriteLine("2) Purchasing Menu");
            Console.WriteLine("Press 0 at any point of the transaction when you want to quit!");
            Console.WriteLine("Enter your option: ");
        }

        private static void ConsumeMessages(List<Product> purchasedProducts)
        {
            foreach (Product item in purchasedProducts)
            {
                item.Consume();
            }        
        }       

        private void UserInputMoney()
        {
            Console.Clear();
            Console.WriteLine("Please feed in your dollar amount.");

            if (int.TryParse(Console.ReadLine(), out int dollars))
            {
                vendingMachine.FeedMoney(dollars);
            }
            else
            {
                Console.WriteLine("That is not a valid dollar amount.");
            }            
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
            Console.Clear();

            foreach (var slot in vendingMachine.Slots)
            {
                Product product = vendingMachine.GetItemAtSlot(slot);

                string message = slot + " - ";
                message += (product != null) ? product.Name + " - " + product.Price.ToString("C") : "Sold-Out";

                Console.WriteLine(message);
            }
        }
    }
}
