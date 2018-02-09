using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachineExceptions : Exception
    {
        public VendingMachineExceptions()
        {

        }

        public VendingMachineExceptions(string message) : base (message)
        {

        }

        public VendingMachineExceptions(string message, Exception inner) : base (message, inner)
        {

        }
    }
}
