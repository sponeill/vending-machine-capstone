using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class ChipItem : Product
    {
        public ChipItem(string name, decimal price, string location) : base(name, price, location)
        {
        }

        public override void Consume()
        {
            Console.WriteLine("Crunch Crunch, Yum!");

        }
    }
}
