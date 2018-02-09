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
        private VendingMachine VM { get; }

        public VendingMachineCLI(VendingMachine vendingMachine)
        {
            this.VM = vendingMachine;
        }


        public void Run()
        {
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();
            VendingMachine vendingMachine = new VendingMachine(inventory);
           

            Console.WriteLine("WELCOME TO VENDO MATIC");
            Console.WriteLine("Main Menu");
            Console.WriteLine("Please Select One of the Following Options.");
            Console.WriteLine("1) Display Vending Machine Items");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("Enter your option: ");

            int userInput = Convert.ToInt32(Console.ReadLine());

            if(userInput == 1)
            {
                foreach (string slot in vendingMachine.Slots)
                {
                    Console.WriteLine(slot);
                }

            }
            else if(userInput == 2)
            {
                Console.WriteLine("Purchasing Menu");
                Console.WriteLine("1) Enter Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine($"Current Money Provided: ${vendingMachine.Balance}");

                int userInput2 = Convert.ToInt32(Console.ReadLine());

            }

        }
    }
}
