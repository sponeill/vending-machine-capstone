using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineFileReader reader = new VendingMachineFileReader("vendingmachine.csv");
            var inventory = reader.GetInventory();

            VendingMachine vm = new VendingMachine(inventory);

            VendingMachineCLI cli = new VendingMachineCLI(vm);
            cli.Run();
        }
    }
}
