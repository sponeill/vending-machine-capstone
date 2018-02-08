using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("WELCOME TO VENDO MATIC");
        }
    }
}
