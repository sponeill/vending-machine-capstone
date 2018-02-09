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
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please Select One of the Following Options.");
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("Press 0 at any point of the transaction when you want to quit!");
                Console.WriteLine("Enter your option: ");

                int userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                    DisplayVendingMachine();

                }
                else if (userInput == 2)
                {
                    PurchasingMenuOptions();

                    int userInput2 = Convert.ToInt32(Console.ReadLine());

                    if (userInput2 == 1)
                    {
                        UserInputMoney();

                    }
                    else if (userInput2 == 2)
                    {
                        Console.WriteLine("Please enter the product slot number.");
                        string slot = Console.ReadLine();

                        while(!vendingMachine.Slots.Contains(slot))
                        {
                            Console.WriteLine("Please refine your choice!");
                            slot = Console.ReadLine();
                        }
                        if(vendingMachine.GetQuantityRemaining(slot) == 0)
                        {
                            Console.WriteLine("Sorry! You lose, try something else!");
                            slot = Console.ReadLine();
                        }
                        else
                        {
                            vendingMachine.Purchase(slot);

                        }
                    }
                    else if(userInput2 == 3)
                    {
                        vendingMachine.ReturnChange()
                        {
                            
                        }
                        Console.WriteLine("");

                    }
                }
                else if(userInput == 0)
                {
                    break;
                }

            }
        }

        private void UserInputMoney()
        {
            Console.WriteLine("Please feed in your choice amount.");

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
            foreach (string slot in vendingMachine.Slots)
            {
                Console.WriteLine(slot);
            }
        }
    }
}
