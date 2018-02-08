using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class GumItem : Product
    {
        public GumItem(string name, decimal price, string location) : base(name, price, location)
        {
        }
        public override void Consume()
        {
            Console.WriteLine("Chew Chew, Yum!");

        }
    }
}
